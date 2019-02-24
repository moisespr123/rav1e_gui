<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.InputTxt = New System.Windows.Forms.TextBox()
        Me.OutputTxt = New System.Windows.Forms.TextBox()
        Me.InputBrowseBtn = New System.Windows.Forms.Button()
        Me.OutputBrowseBtn = New System.Windows.Forms.Button()
        Me.StartBtn = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.OpusVersionLabel = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CPUThreads = New System.Windows.Forms.NumericUpDown()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ShowPSNRMetrics = New System.Windows.Forms.CheckBox()
        Me.AdvancedEncoderOptionsButton = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.MaxKeyFrameInterval = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.MinKeyFrameInterval = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pieceSeconds = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.RemoveTempFiles = New System.Windows.Forms.CheckBox()
        Me.LowLatencyCheckbox = New System.Windows.Forms.CheckBox()
        Me.audioBitrate = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BrowseTempLocation = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tempLocationPath = New System.Windows.Forms.TextBox()
        Me.speed = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rav1eVersionLabel = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ProgressLog = New System.Windows.Forms.RichTextBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PauseResumeButton = New System.Windows.Forms.Button()
        Me.ClearLogBtn = New System.Windows.Forms.Button()
        Me.SaveLogBtn = New System.Windows.Forms.Button()
        Me.quantizer = New System.Windows.Forms.NumericUpDown()
        Me.useQuantizer = New System.Windows.Forms.RadioButton()
        Me.useBitrate = New System.Windows.Forms.RadioButton()
        Me.videoBitrate = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.twoPass = New System.Windows.Forms.CheckBox()
        Me.ffmpegVersionLabel = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CPUThreads, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MaxKeyFrameInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MinKeyFrameInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pieceSeconds, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.audioBitrate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.speed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.quantizer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Step 1: Browse for an input file"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Step 2: Output location and filename:"
        '
        'InputTxt
        '
        Me.InputTxt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InputTxt.Location = New System.Drawing.Point(6, 26)
        Me.InputTxt.Name = "InputTxt"
        Me.InputTxt.Size = New System.Drawing.Size(349, 20)
        Me.InputTxt.TabIndex = 1
        '
        'OutputTxt
        '
        Me.OutputTxt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OutputTxt.Location = New System.Drawing.Point(6, 68)
        Me.OutputTxt.Name = "OutputTxt"
        Me.OutputTxt.Size = New System.Drawing.Size(349, 20)
        Me.OutputTxt.TabIndex = 3
        '
        'InputBrowseBtn
        '
        Me.InputBrowseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InputBrowseBtn.Location = New System.Drawing.Point(361, 22)
        Me.InputBrowseBtn.Name = "InputBrowseBtn"
        Me.InputBrowseBtn.Size = New System.Drawing.Size(75, 23)
        Me.InputBrowseBtn.TabIndex = 2
        Me.InputBrowseBtn.Text = "Browse"
        Me.InputBrowseBtn.UseVisualStyleBackColor = True
        '
        'OutputBrowseBtn
        '
        Me.OutputBrowseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OutputBrowseBtn.Location = New System.Drawing.Point(361, 66)
        Me.OutputBrowseBtn.Name = "OutputBrowseBtn"
        Me.OutputBrowseBtn.Size = New System.Drawing.Size(75, 23)
        Me.OutputBrowseBtn.TabIndex = 4
        Me.OutputBrowseBtn.Text = "Browse"
        Me.OutputBrowseBtn.UseVisualStyleBackColor = True
        '
        'StartBtn
        '
        Me.StartBtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StartBtn.Location = New System.Drawing.Point(6, 310)
        Me.StartBtn.Name = "StartBtn"
        Me.StartBtn.Size = New System.Drawing.Size(430, 37)
        Me.StartBtn.TabIndex = 15
        Me.StartBtn.Text = "Start"
        Me.StartBtn.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 355)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Progress:"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(9, 371)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(427, 23)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 446)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "GUI by Moises Cardona"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(408, 446)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "v1.9"
        '
        'OpusVersionLabel
        '
        Me.OpusVersionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OpusVersionLabel.AutoSize = True
        Me.OpusVersionLabel.Location = New System.Drawing.Point(6, 414)
        Me.OpusVersionLabel.Name = "OpusVersionLabel"
        Me.OpusVersionLabel.Size = New System.Drawing.Size(88, 13)
        Me.OpusVersionLabel.TabIndex = 14
        Me.OpusVersionLabel.Text = "opusenc version:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.twoPass)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.ShowPSNRMetrics)
        Me.GroupBox1.Controls.Add(Me.CPUThreads)
        Me.GroupBox1.Controls.Add(Me.videoBitrate)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.useBitrate)
        Me.GroupBox1.Controls.Add(Me.AdvancedEncoderOptionsButton)
        Me.GroupBox1.Controls.Add(Me.useQuantizer)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.quantizer)
        Me.GroupBox1.Controls.Add(Me.LowLatencyCheckbox)
        Me.GroupBox1.Controls.Add(Me.MaxKeyFrameInterval)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.MinKeyFrameInterval)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.pieceSeconds)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.audioBitrate)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.speed)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 156)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(430, 148)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Encoder Options"
        '
        'CPUThreads
        '
        Me.CPUThreads.Location = New System.Drawing.Point(216, 32)
        Me.CPUThreads.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.CPUThreads.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.CPUThreads.Name = "CPUThreads"
        Me.CPUThreads.Size = New System.Drawing.Size(47, 20)
        Me.CPUThreads.TabIndex = 34
        Me.CPUThreads.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(210, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Threads:"
        '
        'ShowPSNRMetrics
        '
        Me.ShowPSNRMetrics.AutoSize = True
        Me.ShowPSNRMetrics.Checked = True
        Me.ShowPSNRMetrics.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowPSNRMetrics.Location = New System.Drawing.Point(152, 123)
        Me.ShowPSNRMetrics.Name = "ShowPSNRMetrics"
        Me.ShowPSNRMetrics.Size = New System.Drawing.Size(150, 17)
        Me.ShowPSNRMetrics.TabIndex = 32
        Me.ShowPSNRMetrics.Text = "Show PSNR metrics in log"
        Me.ShowPSNRMetrics.UseVisualStyleBackColor = True
        '
        'AdvancedEncoderOptionsButton
        '
        Me.AdvancedEncoderOptionsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AdvancedEncoderOptionsButton.Location = New System.Drawing.Point(308, 119)
        Me.AdvancedEncoderOptionsButton.Name = "AdvancedEncoderOptionsButton"
        Me.AdvancedEncoderOptionsButton.Size = New System.Drawing.Size(113, 23)
        Me.AdvancedEncoderOptionsButton.TabIndex = 31
        Me.AdvancedEncoderOptionsButton.Text = "Advanced Options"
        Me.AdvancedEncoderOptionsButton.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(331, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 13)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "keyframe intervals:"
        '
        'MaxKeyFrameInterval
        '
        Me.MaxKeyFrameInterval.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MaxKeyFrameInterval.Location = New System.Drawing.Point(334, 67)
        Me.MaxKeyFrameInterval.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.MaxKeyFrameInterval.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MaxKeyFrameInterval.Name = "MaxKeyFrameInterval"
        Me.MaxKeyFrameInterval.Size = New System.Drawing.Size(87, 20)
        Me.MaxKeyFrameInterval.TabIndex = 11
        Me.MaxKeyFrameInterval.Value = New Decimal(New Integer() {240, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(305, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "max:"
        '
        'MinKeyFrameInterval
        '
        Me.MinKeyFrameInterval.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MinKeyFrameInterval.Location = New System.Drawing.Point(334, 37)
        Me.MinKeyFrameInterval.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.MinKeyFrameInterval.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MinKeyFrameInterval.Name = "MinKeyFrameInterval"
        Me.MinKeyFrameInterval.Size = New System.Drawing.Size(87, 20)
        Me.MinKeyFrameInterval.TabIndex = 10
        Me.MinKeyFrameInterval.Value = New Decimal(New Integer() {12, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(305, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "min:"
        '
        'pieceSeconds
        '
        Me.pieceSeconds.Location = New System.Drawing.Point(136, 32)
        Me.pieceSeconds.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.pieceSeconds.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.pieceSeconds.Name = "pieceSeconds"
        Me.pieceSeconds.Size = New System.Drawing.Size(76, 20)
        Me.pieceSeconds.TabIndex = 8
        Me.pieceSeconds.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(133, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "part seconds:"
        '
        'RemoveTempFiles
        '
        Me.RemoveTempFiles.AutoSize = True
        Me.RemoveTempFiles.Checked = True
        Me.RemoveTempFiles.CheckState = System.Windows.Forms.CheckState.Checked
        Me.RemoveTempFiles.Location = New System.Drawing.Point(6, 135)
        Me.RemoveTempFiles.Name = "RemoveTempFiles"
        Me.RemoveTempFiles.Size = New System.Drawing.Size(143, 17)
        Me.RemoveTempFiles.TabIndex = 14
        Me.RemoveTempFiles.Text = "Remove Temporary Files"
        Me.RemoveTempFiles.UseVisualStyleBackColor = True
        '
        'LowLatencyCheckbox
        '
        Me.LowLatencyCheckbox.AutoSize = True
        Me.LowLatencyCheckbox.Location = New System.Drawing.Point(6, 123)
        Me.LowLatencyCheckbox.Name = "LowLatencyCheckbox"
        Me.LowLatencyCheckbox.Size = New System.Drawing.Size(87, 17)
        Me.LowLatencyCheckbox.TabIndex = 9
        Me.LowLatencyCheckbox.Text = "Low Latency"
        Me.LowLatencyCheckbox.UseVisualStyleBackColor = True
        '
        'audioBitrate
        '
        Me.audioBitrate.Location = New System.Drawing.Point(65, 32)
        Me.audioBitrate.Maximum = New Decimal(New Integer() {320, 0, 0, 0})
        Me.audioBitrate.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.audioBitrate.Name = "audioBitrate"
        Me.audioBitrate.Size = New System.Drawing.Size(65, 20)
        Me.audioBitrate.TabIndex = 7
        Me.audioBitrate.Value = New Decimal(New Integer() {64, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(62, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "audio bitrate:"
        '
        'BrowseTempLocation
        '
        Me.BrowseTempLocation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BrowseTempLocation.Location = New System.Drawing.Point(361, 106)
        Me.BrowseTempLocation.Name = "BrowseTempLocation"
        Me.BrowseTempLocation.Size = New System.Drawing.Size(75, 23)
        Me.BrowseTempLocation.TabIndex = 13
        Me.BrowseTempLocation.Text = "Browse"
        Me.BrowseTempLocation.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Temporary File Location:"
        '
        'tempLocationPath
        '
        Me.tempLocationPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tempLocationPath.Location = New System.Drawing.Point(6, 109)
        Me.tempLocationPath.Name = "tempLocationPath"
        Me.tempLocationPath.Size = New System.Drawing.Size(349, 20)
        Me.tempLocationPath.TabIndex = 12
        '
        'speed
        '
        Me.speed.Location = New System.Drawing.Point(9, 32)
        Me.speed.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.speed.Name = "speed"
        Me.speed.Size = New System.Drawing.Size(50, 20)
        Me.speed.TabIndex = 6
        Me.speed.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "speed:"
        '
        'rav1eVersionLabel
        '
        Me.rav1eVersionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.rav1eVersionLabel.AutoSize = True
        Me.rav1eVersionLabel.Location = New System.Drawing.Point(6, 401)
        Me.rav1eVersionLabel.Name = "rav1eVersionLabel"
        Me.rav1eVersionLabel.Size = New System.Drawing.Size(74, 13)
        Me.rav1eVersionLabel.TabIndex = 16
        Me.rav1eVersionLabel.Text = "rav1e version:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 9)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 13)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "Log:"
        '
        'ProgressLog
        '
        Me.ProgressLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressLog.BackColor = System.Drawing.SystemColors.Window
        Me.ProgressLog.Location = New System.Drawing.Point(6, 26)
        Me.ProgressLog.Name = "ProgressLog"
        Me.ProgressLog.ReadOnly = True
        Me.ProgressLog.Size = New System.Drawing.Size(579, 409)
        Me.ProgressLog.TabIndex = 18
        Me.ProgressLog.Text = ""
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ffmpegVersionLabel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rav1eVersionLabel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.OpusVersionLabel)
        Me.SplitContainer1.Panel1.Controls.Add(Me.InputTxt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.OutputTxt)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.InputBrowseBtn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ProgressBar1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.RemoveTempFiles)
        Me.SplitContainer1.Panel1.Controls.Add(Me.OutputBrowseBtn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.StartBtn)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BrowseTempLocation)
        Me.SplitContainer1.Panel1.Controls.Add(Me.tempLocationPath)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PauseResumeButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ClearLogBtn)
        Me.SplitContainer1.Panel2.Controls.Add(Me.SaveLogBtn)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ProgressLog)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label14)
        Me.SplitContainer1.Size = New System.Drawing.Size(1049, 473)
        Me.SplitContainer1.SplitterDistance = 448
        Me.SplitContainer1.TabIndex = 19
        '
        'PauseResumeButton
        '
        Me.PauseResumeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PauseResumeButton.Enabled = False
        Me.PauseResumeButton.Location = New System.Drawing.Point(6, 441)
        Me.PauseResumeButton.Name = "PauseResumeButton"
        Me.PauseResumeButton.Size = New System.Drawing.Size(163, 23)
        Me.PauseResumeButton.TabIndex = 21
        Me.PauseResumeButton.Text = "Pause"
        Me.PauseResumeButton.UseVisualStyleBackColor = True
        '
        'ClearLogBtn
        '
        Me.ClearLogBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ClearLogBtn.Location = New System.Drawing.Point(175, 441)
        Me.ClearLogBtn.Name = "ClearLogBtn"
        Me.ClearLogBtn.Size = New System.Drawing.Size(202, 23)
        Me.ClearLogBtn.TabIndex = 20
        Me.ClearLogBtn.Text = "Clear Log"
        Me.ClearLogBtn.UseVisualStyleBackColor = True
        '
        'SaveLogBtn
        '
        Me.SaveLogBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveLogBtn.Location = New System.Drawing.Point(383, 441)
        Me.SaveLogBtn.Name = "SaveLogBtn"
        Me.SaveLogBtn.Size = New System.Drawing.Size(202, 23)
        Me.SaveLogBtn.TabIndex = 19
        Me.SaveLogBtn.Text = "Save Log"
        Me.SaveLogBtn.UseVisualStyleBackColor = True
        '
        'quantizer
        '
        Me.quantizer.Location = New System.Drawing.Point(9, 87)
        Me.quantizer.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.quantizer.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.quantizer.Name = "quantizer"
        Me.quantizer.Size = New System.Drawing.Size(50, 20)
        Me.quantizer.TabIndex = 5
        Me.quantizer.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'useQuantizer
        '
        Me.useQuantizer.AutoSize = True
        Me.useQuantizer.Location = New System.Drawing.Point(9, 64)
        Me.useQuantizer.Name = "useQuantizer"
        Me.useQuantizer.Size = New System.Drawing.Size(70, 17)
        Me.useQuantizer.TabIndex = 0
        Me.useQuantizer.TabStop = True
        Me.useQuantizer.Text = "Quantizer"
        Me.useQuantizer.UseVisualStyleBackColor = True
        '
        'useBitrate
        '
        Me.useBitrate.AutoSize = True
        Me.useBitrate.Location = New System.Drawing.Point(83, 65)
        Me.useBitrate.Name = "useBitrate"
        Me.useBitrate.Size = New System.Drawing.Size(55, 17)
        Me.useBitrate.TabIndex = 6
        Me.useBitrate.TabStop = True
        Me.useBitrate.Text = "Bitrate"
        Me.useBitrate.UseVisualStyleBackColor = True
        '
        'videoBitrate
        '
        Me.videoBitrate.Location = New System.Drawing.Point(83, 87)
        Me.videoBitrate.Name = "videoBitrate"
        Me.videoBitrate.Size = New System.Drawing.Size(60, 20)
        Me.videoBitrate.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(149, 94)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(30, 13)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "kbps"
        '
        'twoPass
        '
        Me.twoPass.AutoSize = True
        Me.twoPass.Location = New System.Drawing.Point(90, 123)
        Me.twoPass.Name = "twoPass"
        Me.twoPass.Size = New System.Drawing.Size(58, 17)
        Me.twoPass.TabIndex = 35
        Me.twoPass.Text = "2-Pass"
        Me.twoPass.UseVisualStyleBackColor = True
        '
        'ffmpegVersionLabel
        '
        Me.ffmpegVersionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ffmpegVersionLabel.AutoSize = True
        Me.ffmpegVersionLabel.Location = New System.Drawing.Point(6, 427)
        Me.ffmpegVersionLabel.Name = "ffmpegVersionLabel"
        Me.ffmpegVersionLabel.Size = New System.Drawing.Size(79, 13)
        Me.ffmpegVersionLabel.TabIndex = 17
        Me.ffmpegVersionLabel.Text = "ffmpeg version:"
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 473)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Form1"
        Me.Text = "rav1e GUI"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CPUThreads, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MaxKeyFrameInterval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MinKeyFrameInterval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pieceSeconds, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.audioBitrate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.speed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.quantizer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents InputTxt As TextBox
    Friend WithEvents OutputTxt As TextBox
    Friend WithEvents InputBrowseBtn As Button
    Friend WithEvents OutputBrowseBtn As Button
    Friend WithEvents StartBtn As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents OpusVersionLabel As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents BrowseTempLocation As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents tempLocationPath As TextBox
    Friend WithEvents speed As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents rav1eVersionLabel As Label
    Friend WithEvents audioBitrate As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents LowLatencyCheckbox As CheckBox
    Friend WithEvents RemoveTempFiles As CheckBox
    Friend WithEvents pieceSeconds As NumericUpDown
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents MaxKeyFrameInterval As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents MinKeyFrameInterval As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents ProgressLog As RichTextBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents AdvancedEncoderOptionsButton As Button
    Friend WithEvents ShowPSNRMetrics As CheckBox
    Friend WithEvents CPUThreads As NumericUpDown
    Friend WithEvents Label15 As Label
    Friend WithEvents ClearLogBtn As Button
    Friend WithEvents SaveLogBtn As Button
    Friend WithEvents PauseResumeButton As Button
    Friend WithEvents quantizer As NumericUpDown
    Friend WithEvents Label16 As Label
    Friend WithEvents videoBitrate As TextBox
    Friend WithEvents useBitrate As RadioButton
    Friend WithEvents useQuantizer As RadioButton
    Friend WithEvents twoPass As CheckBox
    Friend WithEvents ffmpegVersionLabel As Label
End Class
