Public Class AdvancedOptions

    Private Sub AdvancedOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ColorPrimariesComboBox.SelectedItem = My.Settings.ColorPrimaries
        ContentLightTextBox.Text = My.Settings.ContentLight
        MatrixCoefficientsComboBox.SelectedItem = My.Settings.MatrixCoefficients
        TransferCharacteristicsComboBox.SelectedItem = My.Settings.TransferCharacteristics
        RangeComboBox.SelectedItem = My.Settings.Range
        QualityTuningComboBox.SelectedItem = My.Settings.Tune
        TilingRowsNumericUpDown.Value = My.Settings.TilingRows
        TilingColumnsNumericUpDown.Value = My.Settings.TilingColumns
    End Sub
    Private Sub ColorPrimariesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ColorPrimariesComboBox.SelectedIndexChanged
        My.Settings.ColorPrimaries = ColorPrimariesComboBox.SelectedItem
        My.Settings.Save()
    End Sub

    Private Sub MatrixCoefficientsComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MatrixCoefficientsComboBox.SelectedIndexChanged
        My.Settings.MatrixCoefficients = MatrixCoefficientsComboBox.SelectedItem
        My.Settings.Save()
    End Sub

    Private Sub TransferCharacteristicsComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TransferCharacteristicsComboBox.SelectedIndexChanged
        My.Settings.TransferCharacteristics = TransferCharacteristicsComboBox.SelectedItem
        My.Settings.Save()
    End Sub

    Private Sub QualityTuningComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QualityTuningComboBox.SelectedIndexChanged
        My.Settings.Tune = QualityTuningComboBox.SelectedItem
        My.Settings.Save()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        If Not IsPowerOfTwo(TilingRowsNumericUpDown.Value) Then
            MsgBox("The Tile Rows is not a power of 2. It must be a power of 2 for rav1e to work correctly.")
        ElseIf Not IsPowerOfTwo(TilingColumnsNumericUpDown.Value) Then
            MsgBox("The Tile Columns is not a power of 2. It must be a power of 2 for rav1e to work correctly.")

        Else
            Close()
        End If
    End Sub

    Private Sub ContentLightTextBox_TextChanged(sender As Object, e As EventArgs) Handles ContentLightTextBox.TextChanged
        My.Settings.ContentLight = ContentLightTextBox.Text
        My.Settings.Save()
    End Sub

    Private Sub RangeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RangeComboBox.SelectedIndexChanged
        My.Settings.Range = RangeComboBox.SelectedItem
        My.Settings.Save()
    End Sub

    Private Sub TilingRowsNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles TilingRowsNumericUpDown.ValueChanged
        My.Settings.TilingRows = TilingRowsNumericUpDown.Value
        My.Settings.Save()
    End Sub

    Private Sub TilingColumsNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles TilingColumnsNumericUpDown.ValueChanged
        My.Settings.TilingColumns = TilingColumnsNumericUpDown.Value
        My.Settings.Save()
    End Sub


    Private Function IsPowerOfTwo(number As Integer) As Boolean
        Return (number And (number - 1)) = 0
    End Function
End Class