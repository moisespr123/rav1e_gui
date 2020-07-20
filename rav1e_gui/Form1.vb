Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Form1
    Private Exiting As Boolean = False
    Private GUILoaded As Boolean = False
    Private CurrentDirectory = IO.Path.GetDirectoryName(Process.GetCurrentProcess.MainModule.FileName)
    Private Const PipeBuffer As Integer = 1024 * 1024 * 1024
    Private ExtensionsAndFilesList As String() = {".txt", ".opus", "video-part", "InputVideo", ".ivf", "lock"}
    Private Sub InputBrowseBtn_Click(sender As Object, e As EventArgs) Handles InputBrowseBtn.Click
        Dim InputBrowser As New OpenFileDialog With {
            .Title = "Browse for a video file",
            .FileName = IO.Path.GetFileName(InputTxt.Text),
            .Filter = "All Files|*.*"
        }
        If Not String.IsNullOrEmpty(InputTxt.Text) Then InputBrowser.InitialDirectory = IO.Path.GetDirectoryName(InputTxt.Text)
        Dim OkAction As MsgBoxResult = InputBrowser.ShowDialog
        If OkAction = MsgBoxResult.Ok Then
            InputTxt.Text = InputBrowser.FileName
            OutputTxt.Text = IO.Path.ChangeExtension(InputBrowser.FileName, ".webm")
        End If
    End Sub

    Private Sub OutputBrowseBtn_Click(sender As Object, e As EventArgs) Handles OutputBrowseBtn.Click
        Dim OutputBrowser As New SaveFileDialog With {
            .Title = "Save Video File",
            .FileName = IO.Path.GetFileName(OutputTxt.Text),
            .Filter = "WebM|*.webm|Matroska|*.mkv"
        }
        If Not String.IsNullOrEmpty(OutputTxt.Text) Then OutputBrowser.InitialDirectory = IO.Path.GetDirectoryName(OutputTxt.Text)
        Dim OkAction As MsgBoxResult = OutputBrowser.ShowDialog
        If OkAction = MsgBoxResult.Ok Then
            OutputTxt.Text = OutputBrowser.FileName
        End If
    End Sub
    Private Sub CheckForLockFile()
        If Not String.IsNullOrWhiteSpace(tempLocationPath.Text) Then
            Dim videoFound As Boolean = False
            Dim opusFound As Boolean = False
            Dim CheckTempFolder As String() = IO.Directory.GetFiles(tempLocationPath.Text)
            If CheckTempFolder.Count > 0 Then
                If CheckTempFolder.Contains(tempLocationPath.Text + "\lock") And CheckTempFolder.Contains(tempLocationPath.Text + "\rav1e-concatenate-list.txt") Then
                    For Each item In CheckTempFolder
                        If item.Contains("InputVideo") Then
                            If Not videoFound Then videoFound = True
                        ElseIf item.Contains(".opus") Then
                            If Not opusFound Then opusFound = True
                        End If
                    Next
                End If
            End If
            If videoFound And opusFound Then
                Dim result As DialogResult = MsgBox("The temporary folder contains temporary files from a previous session. Do you want to continue the previous encoding session?", MsgBoxStyle.YesNo)
                If result = DialogResult.Yes Then
                    OutputTxt.Text = IO.File.ReadAllText(tempLocationPath.Text + "\lock").TrimEnd
                    ResumePreviousEncodeSession()
                Else
                    Dim result2 As DialogResult = MsgBox("Do you want to clean the folder?", MsgBoxStyle.YesNo)
                    If result2 = DialogResult.Yes Then
                        clean_temp_folder(tempLocationPath.Text)
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub DisableElements()
        StartBtn.Enabled = False
        InputTxt.Enabled = False
        OutputTxt.Enabled = False
        InputBrowseBtn.Enabled = False
        OutputBrowseBtn.Enabled = False
        pieceSeconds.Enabled = False
        audioBitrate.Enabled = False
        quantizer.Enabled = False
        speed.Enabled = False
        MinKeyFrameInterval.Enabled = False
        MaxKeyFrameInterval.Enabled = False
        LowLatencyCheckbox.Enabled = False
        tempLocationPath.Enabled = False
        BrowseTempLocation.Enabled = False
        AdvancedEncoderOptionsButton.Enabled = False
        ShowPSNRMetrics.Enabled = False
        RunRav1eInWSL.Enabled = False
        CPUThreads.Enabled = False
        SaveLogBtn.Enabled = False
        PauseResumeButton.Enabled = True
        twoPass.Enabled = False
        useQuantizer.Enabled = False
        useBitrate.Enabled = False
        UseTilingCheckbox.Enabled = False
        videoBitrate.Enabled = False
    End Sub
    Private Sub ResumePreviousEncodeSession()
        DisableElements()
        Dim StartTasks As New Thread(Sub() Part2(True))
        StartTasks.Start()
    End Sub
    Private Sub StartBtn_Click(sender As Object, e As EventArgs) Handles StartBtn.Click
        If MinKeyFrameInterval.Value > MaxKeyFrameInterval.Value Then
            MsgBox("Minimum Keyframe Interval must be smaller than or equal to the Maximum Keyframe Interval")
        ElseIf String.IsNullOrWhiteSpace(InputTxt.Text) Then
            MsgBox("No input file has been specified. Please enter or browse for an input video file")
        ElseIf String.IsNullOrWhiteSpace(OutputTxt.Text) Then
            MsgBox("No output file has been specified. Please enter or browse for an output video file")
        ElseIf String.IsNullOrWhiteSpace(tempLocationPath.Text) Then
            MsgBox("Temporary folder has not been specified. Please enter or browse for a temporary path")
        Else
            Dim CheckTempFolder As String() = IO.Directory.GetFiles(tempLocationPath.Text)
            If CheckTempFolder.Count > 0 Then
                For Each item In CheckTempFolder
                    If item.Contains(".ivf") Or item.Contains(".txt") Or item.Contains(".y4m") Or item.Contains(".opus") Then
                        Dim result As DialogResult = MsgBox("The temporary folder contains temporary files. It is recommended that the folder is cleaned up for best results. Otherwise, you could get an incorrect AV1 file. Do you want to clean the folder?", MsgBoxStyle.YesNo)
                        If result = DialogResult.Yes Then
                            clean_temp_folder(tempLocationPath.Text)
                        End If
                        Exit For
                    End If
                Next
            End If
            DisableElements()
            If Not IO.Path.GetExtension(OutputTxt.Text) = ".webm" And Not IO.Path.GetExtension(OutputTxt.Text) = ".mkv" Then
                OutputTxt.Text = IO.Path.ChangeExtension(OutputTxt.Text, ".webm")
            End If
            My.Computer.FileSystem.WriteAllText(tempLocationPath.Text + "\lock", OutputTxt.Text, False)
            Dim StartTasks As New Thread(Sub() Part1())
            StartTasks.Start()
        End If
    End Sub

    Private Sub Part1()
        Dim PieceSeconds As Long = 0
        If Not UseTilingCheckbox.Checked Then PieceSeconds = My.Settings.pieceSeconds
        If split_video_file(InputTxt.Text, tempLocationPath.Text, PieceSeconds) Then
            If extract_audio(InputTxt.Text, My.Settings.AudioBitrate, tempLocationPath.Text) Then
                Part2()
            End If
        End If
    End Sub

    Private Sub Part2(Optional ResumeTasks As Boolean = False)
        Dim ItemsToProcess As List(Of String) = New List(Of String)
        If IO.File.Exists(tempLocationPath.Text + "/InputVideo") Then
            ItemsToProcess.Add(IO.File.ReadAllText(tempLocationPath.Text + "/InputVideo"))
        Else
            For Each File As String In IO.Directory.GetFiles(tempLocationPath.Text)
                If IO.Path.GetExtension(File) = IO.File.ReadAllText(tempLocationPath.Text + "/InputVideoExt") And File.Contains("video-part-") Then
                    ItemsToProcess.Add(File)
                End If
            Next
        End If
        ItemsToProcess.Sort()
        ProgressBar1.BeginInvoke(Sub()
                                     ProgressBar1.Maximum = ItemsToProcess.Count
                                     ProgressBar1.Value = 0
                                 End Sub)
        Dim tasks = New List(Of Action)
        If Not ResumeTasks Then
            Dim streamWriter As New IO.StreamWriter(tempLocationPath.Text + "\rav1e-concatenate-list.txt")
            For Counter As Integer = 0 To ItemsToProcess.Count - 1
                streamWriter.WriteLine("file '" + tempLocationPath.Text.Replace("\", "/") + "/" + IO.Path.GetFileNameWithoutExtension(ItemsToProcess(Counter)) + ".ivf" + "'")
                Dim video_item As String = ItemsToProcess(Counter)
                tasks.Add(Function() Run_rav1e(video_item, tempLocationPath.Text + "\" + IO.Path.GetFileNameWithoutExtension(video_item) + ".ivf"))
            Next
            streamWriter.Close()
        Else
            For Counter As Integer = 0 To ItemsToProcess.Count - 1
                Dim video_item As String = ItemsToProcess(Counter)
                tasks.Add(Function() Run_rav1e(video_item, tempLocationPath.Text + "\" + IO.Path.GetFileNameWithoutExtension(video_item) + ".ivf"))
            Next
        End If
        UpdateLog("Encoding Video Segments")
        Dim options As New ParallelOptions With {.MaxDegreeOfParallelism = CPUThreads.Value}
        Parallel.Invoke(options, tasks.ToArray())
        UpdateLog("Video Segments Encoded")
        concatenate_video_files(tempLocationPath.Text + "\rav1e-concatenate-list.txt", tempLocationPath.Text)
        merge_audio_video(OutputTxt.Text, tempLocationPath.Text)
        If RemoveTempFiles.Checked Then clean_temp_folder(tempLocationPath.Text) Else IO.File.Delete(tempLocationPath.Text + "\lock")
        StartBtn.BeginInvoke(Sub()
                                 StartBtn.Enabled = True
                                 audioBitrate.Enabled = True
                                 speed.Enabled = True
                                 MinKeyFrameInterval.Enabled = True
                                 MaxKeyFrameInterval.Enabled = True
                                 LowLatencyCheckbox.Enabled = True
                                 tempLocationPath.Enabled = True
                                 BrowseTempLocation.Enabled = True
                                 OutputTxt.Enabled = True
                                 InputTxt.Enabled = True
                                 InputBrowseBtn.Enabled = True
                                 OutputBrowseBtn.Enabled = True
                                 pieceSeconds.Enabled = Not UseTilingCheckbox.Checked
                                 AdvancedEncoderOptionsButton.Enabled = True
                                 ShowPSNRMetrics.Enabled = True
                                 RunRav1eInWSL.Enabled = True
                                 CPUThreads.Enabled = True
                                 SaveLogBtn.Enabled = True
                                 PauseResumeButton.Enabled = False
                                 useQuantizer.Enabled = True
                                 useBitrate.Enabled = True
                                 UseTilingCheckbox.Enabled = True
                                 If My.Settings.useQuantizer Then
                                     quantizer.Enabled = True
                                     twoPass.Checked = False
                                     twoPass.Enabled = False
                                 End If
                                 If My.Settings.useBitrate Then
                                     videoBitrate.Enabled = True
                                     twoPass.Enabled = True
                                 End If

                             End Sub)
        MsgBox("Finished")
    End Sub
    Private Function Run_rav1e(Input_File As String, Output_File As String, Optional SecondPass As Boolean = False)
        Dim InputPipe As New IO.Pipes.NamedPipeServerStream(IO.Path.GetFileNameWithoutExtension(Input_File) + ".y4m", IO.Pipes.PipeDirection.Out, -1, IO.Pipes.PipeTransmissionMode.Byte, IO.Pipes.PipeOptions.Asynchronous, PipeBuffer, 0)
        UpdateLog("Encoding Video part " + IO.Path.GetFileName(Input_File))
        Dim Original_Input_File As String = Input_File
        Dim Original_Output_File As String = Output_File
        Using rav1eProcess As New Process()
            If RunRav1eInWSL.Checked Then
                Input_File = Regex.Replace(Input_File, "((.):\\)", Function(replace_letter) $"/mnt/{replace_letter.Groups(2).Value.ToLower()}/").Replace("\", "/")
                Output_File = Regex.Replace(Output_File, "((.):\\)", Function(replace_letter) $"/mnt/{replace_letter.Groups(2).Value.ToLower()}/").Replace("\", "/")
            End If
            rav1eProcess.StartInfo.FileName = "rav1e.exe"
            Dim VideoBitrateString As String = String.Empty
            If My.Settings.useBitrate Then
                VideoBitrateString = "-b " + My.Settings.VideoBitrate.ToString()
            Else
                VideoBitrateString = "--quantizer " + My.Settings.quantizer.ToString()
            End If
            If UseTilingCheckbox.Checked Then
                If My.Settings.CPUThreads = 0 Then My.Settings.CPUThreads = Environment.ProcessorCount
                VideoBitrateString += " --threads " + My.Settings.CPUThreads.ToString() + " --tile-rows " + My.Settings.TilingRows.ToString() + " --tile-cols " + My.Settings.TilingColumns.ToString()
            End If
            If My.Settings.twoPass And Not SecondPass Then
                UpdateLog("Doing first pass for video part " + IO.Path.GetFileName(Input_File) + "")
                rav1eProcess.StartInfo.Arguments = """\\.\pipe\" + IO.Path.GetFileNameWithoutExtension(Input_File) + ".y4m"" --first-pass """ + Output_File + ".first-pass-arg-output"" -o """ + Output_File + ".first-pass.ivf""  " + VideoBitrateString + " -s " + My.Settings.speed.ToString() + " -i " + My.Settings.minKeyInt.ToString() + " -I " + My.Settings.maxKeyInt.ToString() + " --tune " + My.Settings.Tune.ToLower() + " --primaries " + My.Settings.ColorPrimaries.ToLower() + " --content_light " + My.Settings.ContentLight + " --matrix " + My.Settings.MatrixCoefficients.ToLower() + " --range " + My.Settings.Range + " --transfer " + My.Settings.TransferCharacteristics.ToLower() + " -v"
            ElseIf My.Settings.twoPass And SecondPass Then
                rav1eProcess.StartInfo.Arguments = """\\.\pipe\" + IO.Path.GetFileNameWithoutExtension(Input_File) + ".y4m"" --second-pass """ + Output_File + ".first-pass-arg-output"" -o """ + Output_File + """  " + VideoBitrateString + " -s " + My.Settings.speed.ToString() + " -i " + My.Settings.minKeyInt.ToString() + " -I " + My.Settings.maxKeyInt.ToString() + " --tune " + My.Settings.Tune.ToLower() + " --primaries " + My.Settings.ColorPrimaries.ToLower() + " --content_light " + My.Settings.ContentLight + " --matrix " + My.Settings.MatrixCoefficients.ToLower() + " --range " + My.Settings.Range + " --transfer " + My.Settings.TransferCharacteristics.ToLower() + " -v"
            Else
                rav1eProcess.StartInfo.Arguments = """\\.\pipe\" + IO.Path.GetFileNameWithoutExtension(Input_File) + ".y4m"" -o """ + Output_File + """  " + VideoBitrateString + " -s " + My.Settings.speed.ToString() + " -i " + My.Settings.minKeyInt.ToString() + " -I " + My.Settings.maxKeyInt.ToString() + " --tune " + My.Settings.Tune.ToLower() + " --primaries " + My.Settings.ColorPrimaries.ToLower() + " --content_light " + My.Settings.ContentLight + " --matrix " + My.Settings.MatrixCoefficients.ToLower() + " --range " + My.Settings.Range + " --transfer " + My.Settings.TransferCharacteristics.ToLower() + " -v"
            End If
            If My.Settings.lowlat Then
                rav1eProcess.StartInfo.Arguments += " --low_latency"
            End If
            If My.Settings.ShowPSNRMetrics Then
                rav1eProcess.StartInfo.Arguments += " --psnr"
            End If
            If RunRav1eInWSL.Checked Then
                rav1eProcess.StartInfo.FileName = ("wsl.exe")
                rav1eProcess.StartInfo.Arguments = "-e " + (Regex.Replace(CurrentDirectory, "((.):\\)", Function(replace_letter) $"/mnt/{replace_letter.Groups(2).Value.ToLower()}/") + "/rav1e").Replace("\", "/") + " " + rav1eProcess.StartInfo.Arguments
            End If
            rav1eProcess.StartInfo.CreateNoWindow = True
            rav1eProcess.StartInfo.RedirectStandardOutput = True
            rav1eProcess.StartInfo.RedirectStandardError = True
            rav1eProcess.StartInfo.RedirectStandardInput = True
            rav1eProcess.StartInfo.UseShellExecute = False
            AddHandler rav1eProcess.OutputDataReceived, New DataReceivedEventHandler(Sub(sender, e)
                                                                                         If Not e.Data = Nothing Then
                                                                                             UpdateLog(e.Data, IO.Path.GetFileName(Input_File))
                                                                                         End If
                                                                                     End Sub)
            AddHandler rav1eProcess.ErrorDataReceived, New DataReceivedEventHandler(Sub(sender, e)
                                                                                        If Not e.Data = Nothing Then
                                                                                            UpdateLog(e.Data, IO.Path.GetFileName(Input_File))
                                                                                        End If
                                                                                    End Sub)
            rav1eProcess.Start()
            rav1eProcess.BeginOutputReadLine()
            rav1eProcess.BeginErrorReadLine()
            WriteByteAsync(InputPipe, Input_File, SecondPass)
            rav1eProcess.WaitForExit()
            If My.Settings.twoPass And Not SecondPass Then
                UpdateLog("Video part " + IO.Path.GetFileName(Input_File) + " First pass encoding complete.")
                Run_rav1e(Original_Input_File, Original_Output_File, True)
            Else
                UpdateLog("Video part " + IO.Path.GetFileName(Input_File) + " encoding complete.")
                If Not Exiting Then
                    If IO.File.Exists(Original_Output_File + ".first-pass-arg-output") Then IO.File.Delete(Original_Output_File + ".first-pass-arg-output")
                    If IO.File.Exists(Original_Output_File + ".first-pass.ivf") Then IO.File.Delete(Original_Output_File + ".first-pass.ivf")
                    If IO.File.Exists(Input_File) Then IO.File.Delete(Input_File)
                End If
                ProgressBar1.BeginInvoke(Sub() ProgressBar1.PerformStep())
            End If
        End Using
        Return True
    End Function
    Private Async Sub WriteByteAsync(InputPipe As IO.Pipes.NamedPipeServerStream, Input As String, SecondPass As Boolean)
        Dim OutputPipe As New IO.Pipes.NamedPipeServerStream(IO.Path.GetFileNameWithoutExtension(Input) + "-out.y4m", IO.Pipes.PipeDirection.In, -1, IO.Pipes.PipeTransmissionMode.Byte, IO.Pipes.PipeOptions.WriteThrough, 0, PipeBuffer)
        Dim ffmpegProcessInfo As New ProcessStartInfo
        Dim ffmpegProcess As Process
        ffmpegProcessInfo.FileName = "ffmpeg.exe"
        ffmpegProcessInfo.Arguments = "-i """ + Input + """ ""\\.\pipe\" + IO.Path.GetFileNameWithoutExtension(Input) + "-out.y4m"" -y"
        ffmpegProcessInfo.CreateNoWindow = True
        ffmpegProcessInfo.RedirectStandardInput = True
        ffmpegProcessInfo.RedirectStandardOutput = True
        ffmpegProcessInfo.UseShellExecute = False
        ffmpegProcess = Process.Start(ffmpegProcessInfo)
        Dim lastRead As Integer
        OutputPipe.WaitForConnection()
        InputPipe.WaitForConnection()
        Dim buffer As Byte() = New Byte(PipeBuffer) {}
        Do
            Try
                lastRead = OutputPipe.Read(buffer, 0, PipeBuffer)
                Await InputPipe.WriteAsync(buffer, 0, lastRead)
            Catch
            End Try
            InputPipe.Flush()
        Loop While lastRead > 0
        OutputPipe.Dispose()
        ffmpegProcess.WaitForExit()
        InputPipe.Dispose()
        If Not Exiting And (Not My.Settings.twoPass Or (My.Settings.twoPass And SecondPass)) Then
            If Not My.Settings.UseTiling Then
                IO.File.Delete(Input)
            End If
        End If
    End Sub
    Private Function split_video_file(input As String, tempFolder As String, pieceSeconds As Integer)
        If pieceSeconds > 0 Then
            Dim ffmpegProcessInfo As New ProcessStartInfo
            Dim ffmpegProcess As Process
            ffmpegProcessInfo.FileName = "ffmpeg.exe"
            UpdateLog("Splitting input video file")
            IO.File.WriteAllText(tempFolder + "/InputVideoExt", IO.Path.GetExtension(input))
            ffmpegProcessInfo.Arguments = "-i """ + input + """ -c copy -f segment -segment_time " + pieceSeconds.ToString() + " """ + tempFolder + "/video-part-%6d" + IO.Path.GetExtension(input) + """ -y"
            ffmpegProcessInfo.CreateNoWindow = True
            ffmpegProcessInfo.RedirectStandardOutput = False
            ffmpegProcessInfo.UseShellExecute = False
            ffmpegProcess = Process.Start(ffmpegProcessInfo)
            ffmpegProcess.WaitForExit()
            UpdateLog("Video file splitted")
        Else
            IO.File.WriteAllText(tempFolder + "/InputVideo", input)
        End If
        Return True
    End Function

    Private Function concatenate_video_files(input As String, tempFolder As String)
        If Not My.Settings.UseTiling Then
            UpdateLog("Concatenating encoded video segments")
            Dim ffmpegProcessInfo As New ProcessStartInfo
            Dim ffmpegProcess As Process
            ffmpegProcessInfo.FileName = "ffmpeg.exe"
            ffmpegProcessInfo.Arguments = "-f concat -safe 0 -i """ + input + """ -c copy """ + tempFolder + "\rav1e-concatenated-file.ivf"" -y"
            ffmpegProcessInfo.CreateNoWindow = True
            ffmpegProcessInfo.RedirectStandardOutput = False
            ffmpegProcessInfo.UseShellExecute = False
            ffmpegProcess = Process.Start(ffmpegProcessInfo)
            ffmpegProcess.WaitForExit()
            UpdateLog("Video concatenated")
        Else
            IO.File.Move(input, tempFolder + "\rav1e-concatenated-file.ivf")
        End If
        Return True
    End Function
    Private Function clean_temp_folder(tempFolder As String)
        For Each file As String In IO.Directory.GetFiles(tempFolder)
            For Each value In ExtensionsAndFilesList
                If file.Contains(value) Then If IO.File.Exists(file) Then IO.File.Delete(file)
            Next
        Next
        Return True
    End Function
    Private Function merge_audio_video(output As String, tempFolder As String)
        UpdateLog("Merging audio and video files")
        Dim ffmpegProcessInfo As New ProcessStartInfo
        Dim ffmpegProcess As Process
        ffmpegProcessInfo.FileName = "ffmpeg.exe"
        If IO.File.Exists(tempFolder + "\rav1e-audio.opus") Then
            ffmpegProcessInfo.Arguments = "-i """ + tempFolder + "\rav1e-concatenated-file.ivf"" -i """ + tempFolder + "\rav1e-audio.opus"" -c:v copy -c:a copy """ + output + """ -y"
        Else
            ffmpegProcessInfo.Arguments = "-i """ + tempFolder + "\rav1e-concatenated-file.ivf"" -c:v copy """ + output + """ -y"
        End If
        ffmpegProcessInfo.CreateNoWindow = True
        ffmpegProcessInfo.RedirectStandardOutput = False
        ffmpegProcessInfo.UseShellExecute = False
        ffmpegProcess = Process.Start(ffmpegProcessInfo)
        ffmpegProcess.WaitForExit()
        UpdateLog("Merge complete")
        Return True
    End Function

    Private Function extract_audio(input As String, bitrate As Integer, tempFolder As String)
        UpdateLog("Extracting and encoding audio")
        Dim ffmpegProcessInfo As New ProcessStartInfo
        Dim ffmpegProcess As Process
        ffmpegProcessInfo.FileName = "ffmpeg.exe"
        ffmpegProcessInfo.Arguments = "-i """ + input + """ -c:a libopus -application audio -b:a " + bitrate.ToString() + "K -af aformat=channel_layouts=""7.1|5.1|stereo"" """ + tempFolder + "\rav1e-audio.opus"" -y"
        ffmpegProcessInfo.CreateNoWindow = True
        ffmpegProcessInfo.RedirectStandardOutput = False
        ffmpegProcessInfo.UseShellExecute = False
        ffmpegProcess = Process.Start(ffmpegProcessInfo)
        ffmpegProcess.WaitForExit()
        UpdateLog("Audio extracted and encoded")
        Return True
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ignoreLocations As Boolean = False
        Dim vars As String() = Environment.GetCommandLineArgs
        If vars.Count > 1 Then
            If vars.Contains("ignore_locations") Then ignoreLocations = True
            For var As Integer = 1 To vars.Count - 1
                If Not vars(var) = "ignore_locations" Then InputTxt.Text = vars(var)
            Next
        End If
        IO.Directory.SetCurrentDirectory(CurrentDirectory)

        CPUThreads.Maximum = Environment.ProcessorCount
        If My.Settings.CPUThreads > 0 Then CPUThreads.Value = My.Settings.CPUThreads Else CPUThreads.Value = CPUThreads.Maximum
        quantizer.Value = My.Settings.quantizer
        videoBitrate.Value = My.Settings.VideoBitrate
        useQuantizer.Checked = My.Settings.useQuantizer
        useBitrate.Checked = My.Settings.useBitrate
        If useBitrate.Checked Then
            twoPass.Checked = My.Settings.twoPass
        Else
            My.Settings.twoPass = False
            My.Settings.Save()
        End If
        speed.Value = My.Settings.speed
        audioBitrate.Value = My.Settings.AudioBitrate
        MinKeyFrameInterval.Value = My.Settings.minKeyInt
        MaxKeyFrameInterval.Value = My.Settings.maxKeyInt
        UseTilingCheckbox.Checked = My.Settings.UseTiling
        pieceSeconds.Value = My.Settings.pieceSeconds
        LowLatencyCheckbox.Checked = My.Settings.lowlat
        tempLocationPath.Text = My.Settings.tempFolder
        RemoveTempFiles.Checked = My.Settings.removeTempFiles
        ShowPSNRMetrics.Checked = My.Settings.ShowPSNRMetrics
        RunRav1eInWSL.Checked = My.Settings.RunRav1eInWSL
        GetRav1eVersion()
        GetFfmpegVersion()
        DetectWSL()
        GUILoaded = True
        If Not String.IsNullOrWhiteSpace(tempLocationPath.Text) Then CheckForLockFile()
    End Sub

    Private Delegate Sub UpdateLogInvoker(message As String, PartName As String)
    Private Sub UpdateLog(message As String, Optional PartName As String = "")
        If ProgressLog.InvokeRequired Then
            ProgressLog.Invoke(New UpdateLogInvoker(AddressOf UpdateLog), message, PartName)
        Else
            If Not PartName = "" Then
                ProgressLog.AppendText(Date.Now().ToString() + " || " + PartName + " || " + message + vbCrLf)
            Else
                ProgressLog.AppendText(Date.Now().ToString() + " || " + message + vbCrLf)
            End If
            ProgressLog.SelectionStart = ProgressLog.Text.Length - 1
            ProgressLog.ScrollToCaret()
        End If
    End Sub
    Private Sub GetRav1eVersion()
        Try
            Dim rav1eProcessInfo As New ProcessStartInfo
            Dim rav1eProcess As Process
            rav1eProcessInfo.FileName = "rav1e.exe"
            rav1eProcessInfo.Arguments = "-0"
            rav1eProcessInfo.CreateNoWindow = True
            rav1eProcessInfo.RedirectStandardOutput = True
            rav1eProcessInfo.UseShellExecute = False
            rav1eProcess = Process.Start(rav1eProcessInfo)
            rav1eProcess.WaitForExit()
            rav1eVersionLabel.Text = "rav1e version: " + rav1eProcess.StandardOutput.ReadLine()
        Catch ex As Exception
            MessageBox.Show("rav1e.exe was not found. Exiting...")
            Process.Start("https://moisescardona.me/rav1e-builds/")
            Me.Close()
        End Try
    End Sub
    Private Sub GetFfmpegVersion()
        Try
            Dim ffmpegProcessInfo As New ProcessStartInfo
            Dim ffmpegProcess As Process
            ffmpegProcessInfo.FileName = "ffmpeg.exe"
            ffmpegProcessInfo.CreateNoWindow = True
            ffmpegProcessInfo.RedirectStandardError = True
            ffmpegProcessInfo.UseShellExecute = False
            ffmpegProcess = Process.Start(ffmpegProcessInfo)
            ffmpegProcess.WaitForExit()
            ffmpegVersionLabel.Text = ffmpegProcess.StandardError.ReadLine()
        Catch ex As Exception
            MessageBox.Show("ffmpeg.exe was not found. Exiting...")
            Process.Start("https://moisescardona.me/downloading-ffmpeg-rav1e-gui/")
            Me.Close()
        End Try
    End Sub

    Private Sub DetectWSL()
        Try
            Dim WSLProcessInfo As New ProcessStartInfo
            Dim WSLProcess As Process
            WSLProcessInfo.FileName = "wsl.exe"
            WSLProcessInfo.Arguments = "--list"
            WSLProcessInfo.CreateNoWindow = True
            WSLProcessInfo.RedirectStandardError = False
            WSLProcessInfo.UseShellExecute = False
            WSLProcess = Process.Start(WSLProcessInfo)
            WSLProcess.WaitForExit()
        Catch ex As Exception
            RunRav1eInWSL.Enabled = False
            RunRav1eInWSL.Checked = False
        End Try
    End Sub

    Private Sub tempLocationPath_TextChanged(sender As Object, e As EventArgs) Handles tempLocationPath.TextChanged
        If GUILoaded Then
            My.Settings.tempFolder = tempLocationPath.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub quantizer_ValueChanged(sender As Object, e As EventArgs) Handles quantizer.ValueChanged
        If GUILoaded Then
            My.Settings.quantizer = quantizer.Value
            My.Settings.Save()
        End If
    End Sub

    Private Sub speed_ValueChanged(sender As Object, e As EventArgs) Handles speed.ValueChanged
        If GUILoaded Then
            My.Settings.speed = speed.Value
            My.Settings.Save()
        End If
    End Sub

    Private Sub audioBitrate_ValueChanged(sender As Object, e As EventArgs) Handles audioBitrate.ValueChanged
        If GUILoaded Then
            My.Settings.AudioBitrate = audioBitrate.Value
            My.Settings.Save()
        End If
    End Sub

    Private Sub BrowseTempLocation_Click(sender As Object, e As EventArgs) Handles BrowseTempLocation.Click
        Dim TempFolderBrowser As New FolderBrowserDialog With {
           .ShowNewFolderButton = False
       }
        Dim OkAction As MsgBoxResult = TempFolderBrowser.ShowDialog
        If OkAction = MsgBoxResult.Ok Then
            tempLocationPath.Text = TempFolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub MinKeyFrameInterval_ValueChanged(sender As Object, e As EventArgs) Handles MinKeyFrameInterval.ValueChanged
        If GUILoaded Then
            My.Settings.minKeyInt = MinKeyFrameInterval.Value
            My.Settings.Save()
        End If
    End Sub
    Private Sub MaxKeyFrameInterval_ValueChanged(sender As Object, e As EventArgs) Handles MaxKeyFrameInterval.ValueChanged
        If GUILoaded Then
            My.Settings.maxKeyInt = MaxKeyFrameInterval.Value
            My.Settings.Save()
        End If
    End Sub

    Private Sub LowLatencyCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles LowLatencyCheckbox.CheckedChanged
        If GUILoaded Then
            My.Settings.lowlat = LowLatencyCheckbox.Checked
            My.Settings.Save()
        End If
    End Sub

    Private Sub RemoveTempFiles_CheckedChanged(sender As Object, e As EventArgs) Handles RemoveTempFiles.CheckedChanged
        If GUILoaded Then
            My.Settings.removeTempFiles = RemoveTempFiles.Checked
            My.Settings.Save()
        End If
    End Sub

    Private Sub pieceSenconds_ValueChanged(sender As Object, e As EventArgs) Handles pieceSeconds.ValueChanged
        If GUILoaded Then
            My.Settings.pieceSeconds = pieceSeconds.Value
            My.Settings.Save()
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Exiting = True
        Dim processes As String() = New String() {"rav1e", "ffmpeg"}
        If RunRav1eInWSL.Checked Then processes.Append("wsl")
        For Each processName In processes
            While True
                Try
                    For Each process_proc In Process.GetProcessesByName("ffmpeg")
                        process_proc.Kill()
                    Next
                Catch
                End Try
                If Process.GetProcessesByName(processName).Length = 0 Then
                    Exit While
                End If
            End While
        Next
        For Each rav1e_proc In Process.GetProcessesByName("rav1e_gui")
            If rav1e_proc.Id = Process.GetCurrentProcess().Id Then rav1e_proc.Kill()
        Next
    End Sub

    Private Sub AdvancedEncoderOptionsButton_Click(sender As Object, e As EventArgs) Handles AdvancedEncoderOptionsButton.Click
        AdvancedOptions.ShowDialog()
    End Sub

    Private Sub ShowPSNRMetrics_CheckedChanged(sender As Object, e As EventArgs) Handles ShowPSNRMetrics.CheckedChanged
        If GUILoaded Then
            My.Settings.ShowPSNRMetrics = ShowPSNRMetrics.Checked
            My.Settings.Save()
        End If
    End Sub

    Private Sub ClearLogBtn_Click(sender As Object, e As EventArgs) Handles ClearLogBtn.Click
        ProgressLog.Clear()
    End Sub

    Private Sub SaveLogBtn_Click(sender As Object, e As EventArgs) Handles SaveLogBtn.Click
        Dim saveDialog As New SaveFileDialog With {
            .Filter = "Log File|*.log",
            .Title = "Browse to save the log file"}
        Dim dialogResult As DialogResult = saveDialog.ShowDialog()
        If DialogResult.OK Then
            IO.File.WriteAllText(saveDialog.FileName, ProgressLog.Text)
        End If
    End Sub

    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        Dim Filename As String = CType(e.Data.GetData(DataFormats.FileDrop), String())(0)
        InputTxt.Text = Filename
        OutputTxt.Text = IO.Path.ChangeExtension(Filename, ".webm")
    End Sub

    Private Sub PauseResumeButton_Click(sender As Object, e As EventArgs) Handles PauseResumeButton.Click
        Dim processes As String() = New String() {"rav1e", "ffmpeg"}
        If RunRav1eInWSL.Checked Then processes.Append("wsl")
        For Each processName In processes
            If PauseResumeButton.Text = "Pause" Then
                UpdateLog("Pausing encode")
                Try
                    For Each process_proc In Process.GetProcessesByName(processName)
                        SuspendResumeProcess.SuspendProcess(process_proc.Id)
                    Next
                Catch
                End Try
                UpdateLog("Encode paused (Some progress may still be reported)")
                PauseResumeButton.Text = "Resume"
            Else
                UpdateLog("Resuming encode")
                Try
                    For Each process_proc In Process.GetProcessesByName(processName)
                        SuspendResumeProcess.ResumeProcess(process_proc.Id)
                    Next
                Catch
                End Try
                UpdateLog("Encode resumed")
                PauseResumeButton.Text = "Pause"
            End If
        Next
    End Sub

    Private Sub UseQuantizer_CheckedChanged(sender As Object, e As EventArgs) Handles useQuantizer.CheckedChanged
        If GUILoaded Then
            My.Settings.useQuantizer = useQuantizer.Checked
            My.Settings.Save()
        End If
        quantizer.Enabled = True
        videoBitrate.Enabled = False
        twoPass.Checked = False
        twoPass.Enabled = False
    End Sub

    Private Sub VideoBitrate_ValueChanged(sender As Object, e As EventArgs) Handles videoBitrate.ValueChanged
        If GUILoaded Then
            My.Settings.VideoBitrate = videoBitrate.Value
            My.Settings.Save()
        End If
    End Sub

    Private Sub UseBitrate_CheckedChanged(sender As Object, e As EventArgs) Handles useBitrate.CheckedChanged
        If GUILoaded Then
            My.Settings.useBitrate = useBitrate.Checked
            My.Settings.Save()
        End If
        quantizer.Enabled = False
        videoBitrate.Enabled = True
        twoPass.Enabled = True
    End Sub

    Private Sub TwoPass_CheckedChanged(sender As Object, e As EventArgs) Handles twoPass.CheckedChanged
        If GUILoaded Then
            My.Settings.twoPass = twoPass.Checked
            My.Settings.Save()
        End If
    End Sub

    Private Sub UseTilingCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles UseTilingCheckbox.CheckedChanged
        If GUILoaded Then
            My.Settings.UseTiling = UseTilingCheckbox.Checked
            My.Settings.Save()
        End If
        pieceSeconds.Enabled = Not UseTilingCheckbox.Checked
    End Sub

    Private Sub CPUThreads_ValueChanged(sender As Object, e As EventArgs) Handles CPUThreads.ValueChanged
        If GUILoaded Then
            My.Settings.CPUThreads = CPUThreads.Value
            My.Settings.Save()
        End If
    End Sub

    Private Sub InputTxt_TextChanged(sender As Object, e As EventArgs) Handles InputTxt.TextChanged
        OutputTxt.Text = IO.Path.ChangeExtension(InputTxt.Text, ".webm")
    End Sub

    Private Sub RunRav1eInWSL_CheckedChanged(sender As Object, e As EventArgs) Handles RunRav1eInWSL.CheckedChanged
        If GUILoaded Then
            My.Settings.RunRav1eInWSL = RunRav1eInWSL.Checked
            My.Settings.Save()
        End If
    End Sub
End Class
