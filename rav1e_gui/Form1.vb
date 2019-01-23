Imports System.Threading

Public Class Form1
    Private Exiting As Boolean = False
    Private GUILoaded As Boolean = False
    Private Sub InputBrowseBtn_Click(sender As Object, e As EventArgs) Handles InputBrowseBtn.Click
        Dim InputBrowser As New OpenFileDialog With {
            .Title = "Browse for a video file",
            .FileName = "",
            .Filter = "All Files|*.*"
        }
        Dim OkAction As MsgBoxResult = InputBrowser.ShowDialog
        If OkAction = MsgBoxResult.Ok Then
            InputTxt.Text = InputBrowser.FileName
        End If
    End Sub

    Private Sub OutputBrowseBtn_Click(sender As Object, e As EventArgs) Handles OutputBrowseBtn.Click
        Dim OutputBrowser As New SaveFileDialog With {
            .Title = "Save Video File",
            .FileName = "",
            .Filter = "WebM|*.webm|Matroska|*.mkv"
        }
        Dim OkAction As MsgBoxResult = OutputBrowser.ShowDialog
        If OkAction = MsgBoxResult.Ok Then
            OutputTxt.Text = OutputBrowser.FileName
        End If
    End Sub
    Private Sub CheckForLockFile()
        If Not String.IsNullOrWhiteSpace(tempLocationPath.Text) Then
            Dim y4mFound As Boolean = False
            Dim wavFound As Boolean = False
            Dim CheckTempFolder As String() = IO.Directory.GetFiles(tempLocationPath.Text)
            If CheckTempFolder.Count > 0 Then
                If CheckTempFolder.Contains(tempLocationPath.Text + "\lock") And CheckTempFolder.Contains(tempLocationPath.Text + "\rav1e-concatenate-list.txt") Then
                    For Each item In CheckTempFolder
                        If IO.Path.GetExtension(item) = ".y4m" And item.Contains("y4m-part-") Then
                            If Not y4mFound Then y4mFound = True
                        ElseIf item.Contains(".wav") Then
                            If Not wavFound Then wavFound = True
                        End If
                    Next
                End If
            End If
            If y4mFound And wavFound Then
                Dim result As DialogResult = MsgBox("The temporary folder contains temporary files from an uninterrumpted session. Do you want to continue the previous encoding session?", MsgBoxStyle.YesNo)
                If result = DialogResult.Yes Then
                    OutputTxt.Text = My.Computer.FileSystem.ReadAllText(tempLocationPath.Text + "\lock").TrimEnd
                    ResumePreviousEncodeSession()
                Else
                    Dim result2 As DialogResult = MsgBox("Do you want to clean the folder?", MsgBoxStyle.YesNo)
                    If result2 = DialogResult.Yes Then
                        For Each ItemToDelete In CheckTempFolder
                            If ItemToDelete.Contains(".ivf") Or ItemToDelete.Contains(".txt") Or ItemToDelete.Contains(".y4m") Or ItemToDelete.Contains(".wav") Or ItemToDelete.Contains(".opus") Then My.Computer.FileSystem.DeleteFile(ItemToDelete)
                        Next
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
        CPUThreads.Enabled = False
        SaveLogBtn.Enabled = False
        ClearLogBtn.Enabled = False
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
                    If item.Contains(".ivf") Or item.Contains(".txt") Or item.Contains(".y4m") Or item.Contains(".wav") Or item.Contains(".opus") Then
                        Dim result As DialogResult = MsgBox("The temporary folder contains temporary files. It is recommended that the folder is cleaned up for best results. Otherwise, you could get an incorrect AV1 file. Do you want to clean the folder?", MsgBoxStyle.YesNo)
                        If result = DialogResult.Yes Then
                            For Each ItemToDelete In CheckTempFolder
                                If ItemToDelete.Contains(".ivf") Or ItemToDelete.Contains(".txt") Or ItemToDelete.Contains(".y4m") Or ItemToDelete.Contains(".wav") Or ItemToDelete.Contains(".opus") Then My.Computer.FileSystem.DeleteFile(ItemToDelete)
                            Next
                        End If
                        Exit For
                    End If
                Next
            End If
            DisableElements()
            If Not IO.Path.GetExtension(OutputTxt.Text) = ".webm" And Not IO.Path.GetExtension(OutputTxt.Text) = ".mkv" Then
                OutputTxt.Text = My.Computer.FileSystem.GetParentPath(OutputTxt.Text) + "\" + IO.Path.GetFileNameWithoutExtension(OutputTxt.Text) + ".webm"
            End If
            My.Computer.FileSystem.WriteAllText(tempLocationPath.Text + "\lock", OutputTxt.Text, False)
            Dim StartTasks As New Thread(Sub() Part1())
            StartTasks.Start()
        End If
    End Sub

    Private Sub Part1()
        If split_video_file(InputTxt.Text, tempLocationPath.Text, My.Settings.pieceSeconds) Then
            If extract_audio(InputTxt.Text, tempLocationPath.Text) Then
                Part2()
            End If
        End If
    End Sub

    Private Sub Part2(Optional ResumeTasks As Boolean = False)
        Dim ItemsToProcess As List(Of String) = New List(Of String)
        For Each File As String In IO.Directory.GetFiles(tempLocationPath.Text)
            If IO.Path.GetExtension(File) = ".y4m" And File.Contains("y4m-part-") Then
                ItemsToProcess.Add(File)
            End If
        Next
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
        Run_opus(My.Settings.bitrate, tempLocationPath.Text)
        concatenate_video_files(tempLocationPath.Text + "\rav1e-concatenate-list.txt", tempLocationPath.Text)
        merge_audio_video(OutputTxt.Text, tempLocationPath.Text)
        If RemoveTempFiles.Checked Then clean_temp_folder(tempLocationPath.Text)
        StartBtn.BeginInvoke(Sub()
                                 StartBtn.Enabled = True
                                 audioBitrate.Enabled = True
                                 quantizer.Enabled = True
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
                                 pieceSeconds.Enabled = True
                                 AdvancedEncoderOptionsButton.Enabled = True
                                 ShowPSNRMetrics.Enabled = True
                                 CPUThreads.Enabled = True
                                 SaveLogBtn.Enabled = True
                                 ClearLogBtn.Enabled = True
                             End Sub)
        MsgBox("Finished")
    End Sub
    Private Function Run_opus(audio_bitrate As Integer, tempFolder As String)
        UpdateLog("Encoding Audio")
        Dim opusProcessInfo As New ProcessStartInfo
        Dim opusProcess As Process
        opusProcessInfo.FileName = "opusenc.exe"
        opusProcessInfo.Arguments = "--music --bitrate " & audio_bitrate & " """ + tempFolder + "\rav1e-audio.wav"""
        opusProcessInfo.CreateNoWindow = True
        opusProcessInfo.RedirectStandardOutput = False
        opusProcessInfo.UseShellExecute = False
        opusProcess = Process.Start(opusProcessInfo)
        opusProcess.WaitForExit()
        UpdateLog("Audio encoded")
        Return True
    End Function
    Private Function Run_rav1e(Input_File As String, Output_File As String)
        UpdateLog("Encoding Video part " + IO.Path.GetFileName(Input_File))
        Using rav1eProcess As New Process()
            rav1eProcess.StartInfo.FileName = "rav1e.exe"
            rav1eProcess.StartInfo.Arguments = """" + Input_File + """ -o """ + Output_File + """ --quantizer " + My.Settings.quantizer.ToString() + " -s " + My.Settings.speed.ToString() + " -i " + My.Settings.minKeyInt.ToString() + " -I " + My.Settings.maxKeyInt.ToString() + " --tune " + My.Settings.Tune.ToLower() + " --primaries " + My.Settings.ColorPrimaries.ToLower() + " --matrix " + My.Settings.MatrixCoefficients.ToLower() + " --transfer " + My.Settings.TransferCharacteristics.ToLower() + " -v"
            If Not My.Settings.lowlat Then
                rav1eProcess.StartInfo.Arguments += " --low_latency false"
            End If
            If My.Settings.ShowPSNRMetrics Then
                rav1eProcess.StartInfo.Arguments += " --psnr"
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
            rav1eProcess.WaitForExit()
            UpdateLog("Video part " + IO.Path.GetFileName(Input_File) + " Encoding complete.")
            If Not Exiting Then
                IO.File.Delete(Input_File)
            End If
            ProgressBar1.BeginInvoke(Sub() ProgressBar1.PerformStep())
        End Using
        Return True
    End Function
    Private Function split_video_file(input As String, tempFolder As String, pieceSenconds As Integer)
        UpdateLog("Splitting input video file")
        Dim ffmpegProcessInfo As New ProcessStartInfo
        Dim ffmpegProcess As Process
        ffmpegProcessInfo.FileName = "ffmpeg.exe"
        ffmpegProcessInfo.Arguments = "-i """ + input + """ -f segment -segment_time " + pieceSenconds.ToString() + " """ + tempFolder + "/y4m-part-%6d.y4m"" -y"
        ffmpegProcessInfo.CreateNoWindow = True
        ffmpegProcessInfo.RedirectStandardOutput = False
        ffmpegProcessInfo.UseShellExecute = False
        ffmpegProcess = Process.Start(ffmpegProcessInfo)
        ffmpegProcess.WaitForExit()
        UpdateLog("Video file splitted")
        Return True
    End Function

    Private Function concatenate_video_files(input As String, tempFolder As String)
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
        Return True
    End Function
    Private Function clean_temp_folder(tempFolder As String)
        For Each File As String In IO.Directory.GetFiles(tempFolder)
            If (IO.Path.GetExtension(File) = ".y4m" Or IO.Path.GetExtension(File) = ".ivf" And File.Contains("y4m-part-")) Or IO.Path.GetFileName(File) = "rav1e-audio.opus" Or IO.Path.GetFileName(File) = "rav1e-audio.wav" Or IO.Path.GetFileName(File) = "rav1e-concatenated-file.ivf" Or IO.Path.GetFileName(File) = "rav1e-concatenate-list.txt" Then
                My.Computer.FileSystem.DeleteFile(File)
            End If
        Next
        My.Computer.FileSystem.DeleteFile(tempFolder + "\lock")
        Return True
    End Function
    Private Function merge_audio_video(output As String, tempFolder As String)
        UpdateLog("Merging audio and video files")
        Dim ffmpegProcessInfo As New ProcessStartInfo
        Dim ffmpegProcess As Process
        ffmpegProcessInfo.FileName = "ffmpeg.exe"
        ffmpegProcessInfo.Arguments = "-i """ + tempFolder + "\rav1e-concatenated-file.ivf"" -i """ + tempFolder + "\rav1e-audio.opus"" -c:v copy -c:a copy """ + output + """ -y"
        ffmpegProcessInfo.CreateNoWindow = True
        ffmpegProcessInfo.RedirectStandardOutput = False
        ffmpegProcessInfo.UseShellExecute = False
        ffmpegProcess = Process.Start(ffmpegProcessInfo)
        ffmpegProcess.WaitForExit()
        UpdateLog("Merge complete")
        Return True
    End Function

    Private Function extract_audio(input As String, tempFolder As String)
        UpdateLog("Extracting audio")
        Dim ffmpegProcessInfo As New ProcessStartInfo
        Dim ffmpegProcess As Process
        ffmpegProcessInfo.FileName = "ffmpeg.exe"
        ffmpegProcessInfo.Arguments = "-i """ + input + """ -vn """ + tempFolder + "\rav1e-audio.wav"" -y"
        ffmpegProcessInfo.CreateNoWindow = True
        ffmpegProcessInfo.RedirectStandardOutput = False
        ffmpegProcessInfo.UseShellExecute = False
        ffmpegProcess = Process.Start(ffmpegProcessInfo)
        ffmpegProcess.WaitForExit()
        UpdateLog("Audio extracted")
        Return True
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IO.Directory.SetCurrentDirectory(IO.Path.GetDirectoryName(Process.GetCurrentProcess.MainModule.FileName))
        CPUThreads.Maximum = Environment.ProcessorCount
        CPUThreads.Value = CPUThreads.Maximum
        quantizer.Value = My.Settings.quantizer
        speed.Value = My.Settings.speed
        audioBitrate.Value = My.Settings.bitrate
        MinKeyFrameInterval.Value = My.Settings.minKeyInt
        MaxKeyFrameInterval.Value = My.Settings.maxKeyInt
        pieceSeconds.Value = My.Settings.pieceSeconds
        LowLatencyCheckbox.Checked = My.Settings.lowlat
        tempLocationPath.Text = My.Settings.tempFolder
        RemoveTempFiles.Checked = My.Settings.removeTempFiles
        ShowPSNRMetrics.Checked = My.Settings.ShowPSNRMetrics
        If OpusEncExists() Then
            GetOpusencVersion()
        Else
            MessageBox.Show("opusenc.exe was not found. Exiting...")
            Process.Start("https://moisescardona.me/opusenc_compiles")
            Me.Close()
        End If
        If rav1eExists() Then
            GetRav1eVersion()
        Else
            MessageBox.Show("rav1e.exe was not found. Exiting...")
            Process.Start("https://moisescardona.me/rav1e_compiles")
            Me.Close()
        End If
        If Not ffmpegExists() Then
            MessageBox.Show("ffmpeg.exe was not found. Exiting...")
            Process.Start("https://moisescardona.me/downloading_ffmpeg_rav1e_gui")
            Me.Close()
        End If
        Dim vars As String() = Environment.GetCommandLineArgs
        If vars.Count > 1 Then
            InputTxt.Text = vars(1)
        End If
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
    Private Sub GetOpusencVersion()
        Dim opusProcessInfo As New ProcessStartInfo
        Dim opusProcess As Process
        opusProcessInfo.FileName = "opusenc.exe"
        opusProcessInfo.Arguments = "-V"
        opusProcessInfo.CreateNoWindow = True
        opusProcessInfo.RedirectStandardOutput = True
        opusProcessInfo.UseShellExecute = False
        opusProcess = Process.Start(opusProcessInfo)
        opusProcess.WaitForExit()
        OpusVersionLabel.Text = "opusenc version: " + opusProcess.StandardOutput.ReadLine()
    End Sub
    Private Sub GetRav1eVersion()
        Dim rav1eProcessInfo As New ProcessStartInfo
        Dim rav1eProcess As Process
        rav1eProcessInfo.FileName = "rav1e.exe"
        rav1eProcessInfo.Arguments = "-V"
        rav1eProcessInfo.CreateNoWindow = True
        rav1eProcessInfo.RedirectStandardOutput = True
        rav1eProcessInfo.UseShellExecute = False
        rav1eProcess = Process.Start(rav1eProcessInfo)
        rav1eProcess.WaitForExit()
        rav1eVersionLabel.Text = "rav1e version: " + rav1eProcess.StandardOutput.ReadLine()
    End Sub

    Private Function rav1eExists() As Boolean
        If My.Computer.FileSystem.FileExists("rav1e.exe") Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function ffmpegExists() As Boolean
        If My.Computer.FileSystem.FileExists("ffmpeg.exe") Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Function OpusEncExists() As Boolean
        If My.Computer.FileSystem.FileExists("opusenc.exe") Then
            Return True
        Else
            Return False
        End If
    End Function

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
            My.Settings.bitrate = audioBitrate.Value
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
        While True
            Try
                For Each rav1e_proc In Process.GetProcessesByName("rav1e")
                    rav1e_proc.Kill()
                Next
            Catch
            End Try
            Dim Processes As Array = Process.GetProcessesByName("rav1e")
            If Processes.Length = 0 Then
                Exit While
            End If
        End While
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
            My.Computer.FileSystem.WriteAllText(saveDialog.FileName, ProgressLog.Text, False)
        End If
    End Sub

    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles MyBase.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        InputTxt.Text = CType(e.Data.GetData(DataFormats.FileDrop), String())(0)
    End Sub
End Class
