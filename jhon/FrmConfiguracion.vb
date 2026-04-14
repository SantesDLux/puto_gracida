Public Class FrmConfiguracion
    Private Sub FrmConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CmbPuertoSeleccionado.Items.Clear()
        CmbPuertoSeleccionado.Items.AddRange(IO.Ports.SerialPort.GetPortNames())
        If CmbPuertoSeleccionado.Items.Count > 0 Then CmbPuertoSeleccionado.SelectedIndex = 0
    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If CmbPuertoSeleccionado.SelectedIndex <> -1 Then
            Me.Tag = CmbPuertoSeleccionado.Text
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Selecciona un puerto, no te hagas...")
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class