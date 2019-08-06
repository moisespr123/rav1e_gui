<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvancedOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ContentLightTextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.RangeComboBox = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TransferCharacteristicsComboBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MatrixCoefficientsComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ColorPrimariesComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.QualityTuningComboBox = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TilingColumsNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TilingRowsNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout
        Me.GroupBox2.SuspendLayout
        Me.GroupBox3.SuspendLayout
        CType(Me.TilingColumsNumericUpDown,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.TilingRowsNumericUpDown,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.ContentLightTextBox)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.RangeComboBox)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TransferCharacteristicsComboBox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.MatrixCoefficientsComboBox)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ColorPrimariesComboBox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(361, 157)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Color Parameters"
        '
        'ContentLightTextBox
        '
        Me.ContentLightTextBox.Location = New System.Drawing.Point(127, 45)
        Me.ContentLightTextBox.Name = "ContentLightTextBox"
        Me.ContentLightTextBox.Size = New System.Drawing.Size(219, 20)
        Me.ContentLightTextBox.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Location = New System.Drawing.Point(54, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Content Light:"
        '
        'RangeComboBox
        '
        Me.RangeComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.RangeComboBox.FormattingEnabled = true
        Me.RangeComboBox.Items.AddRange(New Object() {"Limited", "Full"})
        Me.RangeComboBox.Location = New System.Drawing.Point(127, 93)
        Me.RangeComboBox.Name = "RangeComboBox"
        Me.RangeComboBox.Size = New System.Drawing.Size(219, 21)
        Me.RangeComboBox.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(85, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Range:"
        '
        'TransferCharacteristicsComboBox
        '
        Me.TransferCharacteristicsComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TransferCharacteristicsComboBox.FormattingEnabled = true
        Me.TransferCharacteristicsComboBox.Items.AddRange(New Object() {"Unspecified", "BT1886", "BT470M", "BT470BG", "ST170M", "ST240M", "Linear", "Logarithmic100", "Logarithmic316", "XVYCC", "BT1361E", "SRGB", "BT2020Ten", "BT2020Twelve", "PerceptualQuantizer", "ST428", "HybridLogGamma"})
        Me.TransferCharacteristicsComboBox.Location = New System.Drawing.Point(127, 116)
        Me.TransferCharacteristicsComboBox.Name = "TransferCharacteristicsComboBox"
        Me.TransferCharacteristicsComboBox.Size = New System.Drawing.Size(219, 21)
        Me.TransferCharacteristicsComboBox.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(6, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Transfer Characteristics:"
        '
        'MatrixCoefficientsComboBox
        '
        Me.MatrixCoefficientsComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.MatrixCoefficientsComboBox.FormattingEnabled = true
        Me.MatrixCoefficientsComboBox.Items.AddRange(New Object() {"Unspecified", "Identity", "B709", "BT470M", "BT470BG", "ST170M", "ST240M", "YCgCo", "BT2020NonConstantLuminance", "BT2020ConstantLuminance", "ST2085", "ChromaticityDerivedNonConstantLuminance", "ChromaticityDerivedConstantLuminance", "ICtCp"})
        Me.MatrixCoefficientsComboBox.Location = New System.Drawing.Point(127, 69)
        Me.MatrixCoefficientsComboBox.Name = "MatrixCoefficientsComboBox"
        Me.MatrixCoefficientsComboBox.Size = New System.Drawing.Size(219, 21)
        Me.MatrixCoefficientsComboBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(31, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Matrix Coefficients:"
        '
        'ColorPrimariesComboBox
        '
        Me.ColorPrimariesComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.ColorPrimariesComboBox.FormattingEnabled = true
        Me.ColorPrimariesComboBox.Items.AddRange(New Object() {"Unspecified", "BT709", "BT470M", "BT470BG", "ST170M", "ST240M", "Film", "BT2020", "ST428", "P3DCI", "P3Display", "Tech3213"})
        Me.ColorPrimariesComboBox.Location = New System.Drawing.Point(128, 21)
        Me.ColorPrimariesComboBox.Name = "ColorPrimariesComboBox"
        Me.ColorPrimariesComboBox.Size = New System.Drawing.Size(219, 21)
        Me.ColorPrimariesComboBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(48, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Color Primaries:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.QualityTuningComboBox)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 175)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(361, 61)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Other Options"
        '
        'QualityTuningComboBox
        '
        Me.QualityTuningComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.QualityTuningComboBox.FormattingEnabled = true
        Me.QualityTuningComboBox.Items.AddRange(New Object() {"Psnr", "Psychovisual"})
        Me.QualityTuningComboBox.Location = New System.Drawing.Point(128, 27)
        Me.QualityTuningComboBox.Name = "QualityTuningComboBox"
        Me.QualityTuningComboBox.Size = New System.Drawing.Size(219, 21)
        Me.QualityTuningComboBox.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(49, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Quality Tuning:"
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.CloseButton.Location = New System.Drawing.Point(13, 355)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(360, 23)
        Me.CloseButton.TabIndex = 2
        Me.CloseButton.Text = "Close"
        Me.CloseButton.UseVisualStyleBackColor = true
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.TilingColumsNumericUpDown)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.TilingRowsNumericUpDown)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 242)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(361, 61)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = false
        Me.GroupBox3.Text = "Tiling"
        '
        'TilingColumsNumericUpDown
        '
        Me.TilingColumsNumericUpDown.Location = New System.Drawing.Point(180, 26)
        Me.TilingColumsNumericUpDown.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.TilingColumsNumericUpDown.Name = "TilingColumsNumericUpDown"
        Me.TilingColumsNumericUpDown.Size = New System.Drawing.Size(51, 20)
        Me.TilingColumsNumericUpDown.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Location = New System.Drawing.Point(124, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Columns:"
        '
        'TilingRowsNumericUpDown
        '
        Me.TilingRowsNumericUpDown.Location = New System.Drawing.Point(49, 26)
        Me.TilingRowsNumericUpDown.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
        Me.TilingRowsNumericUpDown.Name = "TilingRowsNumericUpDown"
        Me.TilingRowsNumericUpDown.Size = New System.Drawing.Size(51, 20)
        Me.TilingRowsNumericUpDown.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Location = New System.Drawing.Point(6, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Rows:"
        '
        'AdvancedOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 399)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "AdvancedOptions"
        Me.Text = "Advanced Encoder Options"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.GroupBox3.ResumeLayout(false)
        Me.GroupBox3.PerformLayout
        CType(Me.TilingColumsNumericUpDown,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.TilingRowsNumericUpDown,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents MatrixCoefficientsComboBox As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ColorPrimariesComboBox As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TransferCharacteristicsComboBox As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents QualityTuningComboBox As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CloseButton As Button
    Friend WithEvents RangeComboBox As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ContentLightTextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TilingColumsNumericUpDown As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents TilingRowsNumericUpDown As NumericUpDown
End Class
