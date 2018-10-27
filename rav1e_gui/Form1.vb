Public Class Form1
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
            .Filter = "WebM|*.webm"
        }
        Dim OkAction As MsgBoxResult = OutputBrowser.ShowDialog
        If OkAction = MsgBoxResult.Ok Then
            OutputTxt.Text = OutputBrowser.FileName
        End If
    End Sub

    Private Sub StartBtn_Click(sender As Object, e As EventArgs) Handles StartBtn.Click
        StartBtn.Enabled = False
        InputTxt.Enabled = False
        OutputTxt.Enabled = False
        InputBrowseBtn.Enabled = False
        OutputBrowseBtn.Enabled = False
        audioBitrate.Enabled = False
        quantizer.Enabled = False
        speed.Enabled = False
        KeyFrameInterval.Enabled = False
        LowLatencyCheckbox.Enabled = False
        tempLocationPath.Enabled = False
        BrowseTempLocation.Enabled = False
        If Not IO.Path.GetExtension(OutputTxt.Text) = ".webm" Then
            OutputTxt.Text = My.Computer.FileSystem.GetParentPath(OutputTxt.Text) + "\" + IO.Path.GetFileNameWithoutExtension(OutputTxt.Text) + ".webm"
        End If
        Dim StartTasks As New Threading.Thread(Sub() StartThreads())
        StartTasks.Start()
    End Sub
    Private Sub StartThreads()
        If split_video_file(InputTxt.Text, tempLocationPath.Text) Then
            If extract_audio(InputTxt.Text, tempLocationPath.Text) Then
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
                Dim streamWriter As New IO.StreamWriter(tempLocationPath.Text + "\rav1e-concatenate-list.txt")
                For Counter As Integer = 0 To ItemsToProcess.Count - 1
                    Dim args As Array = {ItemsToProcess(Counter), tempLocationPath.Text + "\" + IO.Path.GetFileNameWithoutExtension(ItemsToProcess(Counter)) + ".ivf", My.Settings.quantizer, My.Settings.speed, My.Settings.keyint, My.Settings.lowlat}
                    streamWriter.WriteLine("file '" + tempLocationPath.Text.Replace("\", "/") + "/" + IO.Path.GetFileNameWithoutExtension(ItemsToProcess(Counter)) + ".ivf" + "'")
                    tasks.Add(Function() Run_rav1e(args))
                Next
                streamWriter.Close()
                Dim options As New ParallelOptions With {.MaxDegreeOfParallelism = Environment.ProcessorCount}
                Parallel.Invoke(options, tasks.ToArray())
                Run_opus(My.Settings.bitrate, tempLocationPath.Text)
                concatenate_video_files(tempLocationPath.Text + "\rav1e-concatenate-list.txt", tempLocationPath.Text)
                merge_audio_video(OutputTxt.Text, tempLocationPath.Text)
                if RemoveTempFiles.Checked Then clean_temp_folder(tempLocationPath.Text)
                StartBtn.BeginInvoke(Sub()
                                         StartBtn.Enabled = True
                                         audioBitrate.Enabled = True
                                         quantizer.Enabled = True
                                         speed.Enabled = True
                                         KeyFrameInterval.Enabled = True
                                         LowLatencyCheckbox.Enabled = True
                                         tempLocationPath.Enabled = True
                                         BrowseTempLocation.Enabled = True
                                         OutputTxt.Enabled = True
                                         InputTxt.Enabled = True
                                         InputBrowseBtn.Enabled = True
                                         OutputBrowseBtn.Enabled = True
                                     End Sub)
                MsgBox("Finished")
            End If
        End If
    End Sub
    Private Function Run_opus(audio_bitrate As Integer, tempFolder As String)
        Dim opusProcessInfo As New ProcessStartInfo
        Dim opusProcess As Process
        opusProcessInfo.FileName = "opusenc.exe"
        opusProcessInfo.Arguments = "--music --bitrate " & audio_bitrate & " """ + tempFolder + "\rav1e-audio.wav"""
        opusProcessInfo.CreateNoWindow = True
        opusProcessInfo.RedirectStandardOutput = False
        opusProcessInfo.UseShellExecute = False
        opusProcess = Process.Start(opusProcessInfo)
        opusProcess.WaitForExit()
        Return True
    End Function
    Private Function Run_rav1e(args As Array)
        Dim Input_File As String = args(0)
        Dim Output_File As String = args(1)
        Dim Quantizer As Integer = args(2)
        Dim Speed As Integer = args(3)
        Dim KeyInt As Integer = args(4)
        Dim LowLat As Boolean = args(5)
        Dim rav1eProcessInfo As New ProcessStartInfo
        Dim rav1eProcess As Process
        rav1eProcessInfo.FileName = "rav1e.exe"
        rav1eProcessInfo.Arguments = """" + Input_File + """ -o """ + Output_File + """ --quantizer " + Quantizer.ToString() + " -s " + Speed.ToString() + " -I " + KeyInt.ToString()
        If Not LowLat Then
            rav1eProcessInfo.Arguments += " --low_latency false"
        End If
        rav1eProcessInfo.CreateNoWindow = True
        rav1eProcessInfo.RedirectStandardOutput = False
        rav1eProcessInfo.UseShellExecute = False
        rav1eProcess = Process.Start(rav1eProcessInfo)
        rav1eProcess.WaitForExit()
        ProgressBar1.BeginInvoke(Sub() ProgressBar1.PerformStep())
        Return True
    End Function

    Private Function split_video_file(input As String, tempFolder As String)
        Dim ffmpegProcessInfo As New ProcessStartInfo
        Dim ffmpegProcess As Process
        ffmpegProcessInfo.FileName = "ffmpeg.exe"
        ffmpegProcessInfo.Arguments = "-i """ + input + """ -f segment -segment_time 1 """ + tempFolder + "/y4m-part-%6d.y4m"""
        ffmpegProcessInfo.CreateNoWindow = True
        ffmpegProcessInfo.RedirectStandardOutput = False
        ffmpegProcessInfo.UseShellExecute = False
        ffmpegProcess = Process.Start(ffmpegProcessInfo)
        ffmpegProcess.WaitForExit()
        Return True
    End Function

    Private Function concatenate_video_files(input As String, tempFolder As String)
        Dim ffmpegProcessInfo As New ProcessStartInfo
        Dim ffmpegProcess As Process
        ffmpegProcessInfo.FileName = "ffmpeg.exe"
        ffmpegProcessInfo.Arguments = "-f concat -safe 0 -i """ + input + """ -c copy """ + tempFolder + "\rav1e-concatenated-file.ivf"""
        ffmpegProcessInfo.CreateNoWindow = True
        ffmpegProcessInfo.RedirectStandardOutput = False
        ffmpegProcessInfo.UseShellExecute = False
        ffmpegProcess = Process.Start(ffmpegProcessInfo)
        ffmpegProcess.WaitForExit()
        Return True
    End Function
    Private Function clean_temp_folder(tempFolder As String)
        For Each File As String In IO.Directory.GetFiles(tempLocationPath.Text)
            If (IO.Path.GetExtension(File) = ".y4m" Or IO.Path.GetExtension(File) = ".ivf" And File.Contains("y4m-part-")) Or IO.Path.GetFileName(File) = "rav1e-audio.opus" Or IO.Path.GetFileName(File) = "rav1e-audio.wav" Or IO.Path.GetFileName(File) = "rav1e-concatenated-file.ivf" Or IO.Path.GetFileName(File) = "rav1e-concatenate-list.txt" Then
                My.Computer.FileSystem.DeleteFile(File)
            End If
        Next
        Return True
    End Function
    Private Function merge_audio_video(output As String, tempFolder As String)
        Dim ffmpegProcessInfo As New ProcessStartInfo
        Dim ffmpegProcess As Process
        ffmpegProcessInfo.FileName = "ffmpeg.exe"
        ffmpegProcessInfo.Arguments = "-i """ + tempFolder + "\rav1e-concatenated-file.ivf"" -i """ + tempFolder + "\rav1e-audio.opus"" -c:v copy -c:a copy """ + output + """"
        ffmpegProcessInfo.CreateNoWindow = True
        ffmpegProcessInfo.RedirectStandardOutput = False
        ffmpegProcessInfo.UseShellExecute = False
        ffmpegProcess = Process.Start(ffmpegProcessInfo)
        ffmpegProcess.WaitForExit()
        Return True
    End Function

    Private Function extract_audio(input As String, tempFolder As String)
        Dim ffmpegProcessInfo As New ProcessStartInfo
        Dim ffmpegProcess As Process
        ffmpegProcessInfo.FileName = "ffmpeg.exe"
        ffmpegProcessInfo.Arguments = "-i """ + input + """ -vn """ + tempFolder + "\rav1e-audio.wav"""
        ffmpegProcessInfo.CreateNoWindow = True
        ffmpegProcessInfo.RedirectStandardOutput = False
        ffmpegProcessInfo.UseShellExecute = False
        ffmpegProcess = Process.Start(ffmpegProcessInfo)
        ffmpegProcess.WaitForExit()
        Return True
    End Function
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        quantizer.Value = My.Settings.quantizer
        speed.Value = My.Settings.speed
        audioBitrate.Value = My.Settings.bitrate
        KeyFrameInterval.Value = My.Settings.keyint
        LowLatencyCheckbox.Checked = My.Settings.lowlat
        tempLocationPath.Text = My.Settings.tempFolder
        RemoveTempFiles.Checked = My.Settings.removeTempFiles 
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
        GUILoaded = True
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

    Private Sub KeyFrameInterval_ValueChanged(sender As Object, e As EventArgs) Handles KeyFrameInterval.ValueChanged
        If GUILoaded Then
            My.Settings.keyint = KeyFrameInterval.Value
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
End Class
