Public Class AdvancedOptions

    Private Sub AdvancedOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ColorPrimariesComboBox.SelectedItem = My.Settings.ColorPrimaries
        MatrixCoefficientsComboBox.SelectedItem = My.Settings.MatrixCoefficients
        TransferCharacteristicsComboBox.SelectedItem = My.Settings.TransferCharacteristics
        QualityTuningComboBox.SelectedItem = My.Settings.Tune
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
        Close()
    End Sub
End Class