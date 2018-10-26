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
        Me.audioBitrate = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BrowseTempLocation = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tempLocationPath = New System.Windows.Forms.TextBox()
        Me.speed = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.quantizer = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rav1eVersionLabel = New System.Windows.Forms.Label()
        Me.KeyFrameInterval = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LowLatencyCheckbox = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout
        CType(Me.audioBitrate,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.speed,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.quantizer,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.KeyFrameInterval,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Step 1: Browse for an input file"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Step 2: Output location and filename:"
        '
        'InputTxt
        '
        Me.InputTxt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.InputTxt.Location = New System.Drawing.Point(15, 26)
        Me.InputTxt.Name = "InputTxt"
        Me.InputTxt.Size = New System.Drawing.Size(356, 20)
        Me.InputTxt.TabIndex = 1
        '
        'OutputTxt
        '
        Me.OutputTxt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.OutputTxt.Location = New System.Drawing.Point(15, 68)
        Me.OutputTxt.Name = "OutputTxt"
        Me.OutputTxt.Size = New System.Drawing.Size(356, 20)
        Me.OutputTxt.TabIndex = 3
        '
        'InputBrowseBtn
        '
        Me.InputBrowseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.InputBrowseBtn.Location = New System.Drawing.Point(377, 24)
        Me.InputBrowseBtn.Name = "InputBrowseBtn"
        Me.InputBrowseBtn.Size = New System.Drawing.Size(75, 23)
        Me.InputBrowseBtn.TabIndex = 2
        Me.InputBrowseBtn.Text = "Browse"
        Me.InputBrowseBtn.UseVisualStyleBackColor = true
        '
        'OutputBrowseBtn
        '
        Me.OutputBrowseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.OutputBrowseBtn.Location = New System.Drawing.Point(377, 68)
        Me.OutputBrowseBtn.Name = "OutputBrowseBtn"
        Me.OutputBrowseBtn.Size = New System.Drawing.Size(75, 23)
        Me.OutputBrowseBtn.TabIndex = 4
        Me.OutputBrowseBtn.Text = "Browse"
        Me.OutputBrowseBtn.UseVisualStyleBackColor = true
        '
        'StartBtn
        '
        Me.StartBtn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.StartBtn.Location = New System.Drawing.Point(15, 245)
        Me.StartBtn.Name = "StartBtn"
        Me.StartBtn.Size = New System.Drawing.Size(440, 37)
        Me.StartBtn.TabIndex = 12
        Me.StartBtn.Text = "Start"
        Me.StartBtn.UseVisualStyleBackColor = true
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(15, 292)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Progress:"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(18, 309)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(437, 23)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(15, 380)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "GUI by Moises Cardona"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = true
        Me.Label6.Location = New System.Drawing.Point(427, 390)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "v1.0"
        '
        'OpusVersionLabel
        '
        Me.OpusVersionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.OpusVersionLabel.AutoSize = true
        Me.OpusVersionLabel.Location = New System.Drawing.Point(15, 358)
        Me.OpusVersionLabel.Name = "OpusVersionLabel"
        Me.OpusVersionLabel.Size = New System.Drawing.Size(88, 13)
        Me.OpusVersionLabel.TabIndex = 14
        Me.OpusVersionLabel.Text = "opusenc version:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.LowLatencyCheckbox)
        Me.GroupBox1.Controls.Add(Me.KeyFrameInterval)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.audioBitrate)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.BrowseTempLocation)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.tempLocationPath)
        Me.GroupBox1.Controls.Add(Me.speed)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.quantizer)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 94)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(437, 139)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Encoder Options"
        '
        'audioBitrate
        '
        Me.audioBitrate.Location = New System.Drawing.Point(124, 37)
        Me.audioBitrate.Maximum = New Decimal(New Integer() {320, 0, 0, 0})
        Me.audioBitrate.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.audioBitrate.Name = "audioBitrate"
        Me.audioBitrate.Size = New System.Drawing.Size(65, 20)
        Me.audioBitrate.TabIndex = 7
        Me.audioBitrate.Value = New Decimal(New Integer() {64, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Location = New System.Drawing.Point(121, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "audio bitrate:"
        '
        'BrowseTempLocation
        '
        Me.BrowseTempLocation.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.BrowseTempLocation.Location = New System.Drawing.Point(356, 105)
        Me.BrowseTempLocation.Name = "BrowseTempLocation"
        Me.BrowseTempLocation.Size = New System.Drawing.Size(75, 23)
        Me.BrowseTempLocation.TabIndex = 11
        Me.BrowseTempLocation.Text = "Browse"
        Me.BrowseTempLocation.UseVisualStyleBackColor = true
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = true
        Me.Label8.Location = New System.Drawing.Point(9, 91)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Temporary File Location:"
        '
        'tempLocationPath
        '
        Me.tempLocationPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tempLocationPath.Location = New System.Drawing.Point(12, 107)
        Me.tempLocationPath.Name = "tempLocationPath"
        Me.tempLocationPath.Size = New System.Drawing.Size(338, 20)
        Me.tempLocationPath.TabIndex = 10
        '
        'speed
        '
        Me.speed.Location = New System.Drawing.Point(68, 37)
        Me.speed.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.speed.Name = "speed"
        Me.speed.Size = New System.Drawing.Size(50, 20)
        Me.speed.TabIndex = 6
        Me.speed.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Location = New System.Drawing.Point(65, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "speed:"
        '
        'quantizer
        '
        Me.quantizer.Location = New System.Drawing.Point(12, 37)
        Me.quantizer.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.quantizer.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.quantizer.Name = "quantizer"
        Me.quantizer.Size = New System.Drawing.Size(50, 20)
        Me.quantizer.TabIndex = 5
        Me.quantizer.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(9, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "quantizer:"
        '
        'rav1eVersionLabel
        '
        Me.rav1eVersionLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.rav1eVersionLabel.AutoSize = true
        Me.rav1eVersionLabel.Location = New System.Drawing.Point(15, 345)
        Me.rav1eVersionLabel.Name = "rav1eVersionLabel"
        Me.rav1eVersionLabel.Size = New System.Drawing.Size(74, 13)
        Me.rav1eVersionLabel.TabIndex = 16
        Me.rav1eVersionLabel.Text = "rav1e version:"
        '
        'KeyFrameInterval
        '
        Me.KeyFrameInterval.Location = New System.Drawing.Point(195, 37)
        Me.KeyFrameInterval.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.KeyFrameInterval.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.KeyFrameInterval.Name = "KeyFrameInterval"
        Me.KeyFrameInterval.Size = New System.Drawing.Size(87, 20)
        Me.KeyFrameInterval.TabIndex = 8
        Me.KeyFrameInterval.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Location = New System.Drawing.Point(192, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "keyframe interval:"
        '
        'LowLatencyCheckbox
        '
        Me.LowLatencyCheckbox.AutoSize = true
        Me.LowLatencyCheckbox.Checked = true
        Me.LowLatencyCheckbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LowLatencyCheckbox.Location = New System.Drawing.Point(12, 67)
        Me.LowLatencyCheckbox.Name = "LowLatencyCheckbox"
        Me.LowLatencyCheckbox.Size = New System.Drawing.Size(87, 17)
        Me.LowLatencyCheckbox.TabIndex = 9
        Me.LowLatencyCheckbox.Text = "Low Latency"
        Me.LowLatencyCheckbox.UseVisualStyleBackColor = true
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 408)
        Me.Controls.Add(Me.rav1eVersionLabel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.OpusVersionLabel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.StartBtn)
        Me.Controls.Add(Me.OutputBrowseBtn)
        Me.Controls.Add(Me.InputBrowseBtn)
        Me.Controls.Add(Me.OutputTxt)
        Me.Controls.Add(Me.InputTxt)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = false
        Me.Name = "Form1"
        Me.Text = "rav1e GUI"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        CType(Me.audioBitrate,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.speed,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.quantizer,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.KeyFrameInterval,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

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
    Friend WithEvents quantizer As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents rav1eVersionLabel As Label
    Friend WithEvents audioBitrate As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents KeyFrameInterval As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents LowLatencyCheckbox As CheckBox
End Class
