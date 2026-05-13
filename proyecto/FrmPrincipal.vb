Imports System.IO
Imports System.IO.Ports
Imports System.Windows.Forms.DataVisualization.Charting

Public Class FrmPrincipal
    Dim modoSimulacion As Boolean = False
    Dim tiempo As Integer = 0
    Dim puertoConfigurado As Boolean = False
    Dim rnd As New Random()

    Dim valoresCelsius As New List(Of Double)

    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 500
        Chart1.Series.Clear()
        Chart1.Series.Add("Sensor")
        With Chart1.Series("Sensor")
            .ChartType = SeriesChartType.Line
            .BorderWidth = 2
        End With
        Chart1.ChartAreas(0).AxisX.Title = "Tiempo"
        Chart1.ChartAreas(0).AxisY.Title = "Señal"
        LblPuertoActual.Text = "Sin puerto seleccionado"
    End Sub

    Private Sub BUSCARCOMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BUSCARCOMToolStripMenuItem.Click
        If SerialPort1.IsOpen Then
            MsgBox("Desconéctate primero antes de cambiar el puerto.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim ventana As New FrmConfiguracion()
        If ventana.ShowDialog() = DialogResult.OK Then
            If Not SerialPort1.IsOpen Then
                SerialPort1.PortName = ventana.Tag.ToString()
                LblPuertoActual.Text = "Puerto: " & SerialPort1.PortName
                puertoConfigurado = True
            End If
        End If
    End Sub

    Private Sub BtnConectar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If SerialPort1.IsOpen Or modoSimulacion Then
            If modoSimulacion Then
                Timer1.Stop()
                modoSimulacion = False
                BtnAceptar.Text = "Conectar"
                MsgBox("Simulación detenida.")
            Else
                SerialPort1.Close()
                BtnAceptar.Text = "Conectar"
                MsgBox("Desconectado del puerto.")
            End If
            Return
        End If

        If puertoConfigurado Then
            Try
                With SerialPort1
                    .BaudRate = 9600
                    .Parity = Parity.None
                    .DataBits = 8
                    .StopBits = StopBits.One
                End With
                SerialPort1.Open()
                BtnAceptar.Text = "Desconectar"
                MsgBox("Conectado a " & SerialPort1.PortName)
            Catch ex As Exception
                MsgBox("Error al conectar: " & ex.Message)
            End Try
        Else
            Dim respuesta = MsgBox("No has seleccionado puerto. ¿Quieres activar el MODO SIMULACIÓN?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
            If respuesta = MsgBoxResult.Yes Then
                modoSimulacion = True
                Timer1.Start()
                BtnAceptar.Text = "Detener Simulación"
            End If
        End If
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        If modoSimulacion Then Return

        Try
            Dim datoCrudo As String = SerialPort1.ReadExisting()
            Debug.WriteLine("Recibido: " & datoCrudo)

            Me.Invoke(Sub()
                          Dim valor As Double
                          If Double.TryParse(datoCrudo.Trim(), valor) Then
                              GraficarPunto(valor)
                          End If
                      End Sub)
        Catch ex As Exception
            Debug.WriteLine("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub GraficarPunto(valorCelsius As Double)
        valoresCelsius.Add(valorCelsius)

        Dim valorFinal As Double = valorCelsius

        Chart1.Series("Sensor").Points.AddXY(tiempo, valorFinal)

        tiempo += 1

        If Chart1.Series("Sensor").Points.Count > 20 Then
            Chart1.ChartAreas(0).AxisX.Minimum = tiempo - 20
            Chart1.ChartAreas(0).AxisX.Maximum = tiempo
        End If
    End Sub

    Private Sub BtnLimpiar_Click(sender As Object, e As EventArgs) Handles BtnLimpíar.Click
        Dim resp = MsgBox("¿Seguro que quieres limpiar la gráfica? Se perderán los datos.",
                          MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
        If resp = MsgBoxResult.No Then Return

        Chart1.Series("Sensor").Points.Clear()
        valoresCelsius.Clear()
        tiempo = 0
    End Sub

    Private Sub ExportarCSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarToolStripMenuItem.Click
        If Chart1.Series("Sensor").Points.Count = 0 Then
            MsgBox("No hay datos para exportar.", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim dlg As New SaveFileDialog With {
            .Filter = "Archivo CSV (*.csv)|*.csv",
            .FileName = "datos_sensor_" & Format(Now, "yyyyMMdd_HHmmss")
        }

        If dlg.ShowDialog() = DialogResult.OK Then
            Using sw As New StreamWriter(dlg.FileName)
                sw.WriteLine("Tiempo,Celsius")
                For i As Integer = 0 To valoresCelsius.Count - 1
                    sw.WriteLine(i.ToString() & "," & valoresCelsius(i).ToString())
                Next
            End Using
            MsgBox("CSV exportado correctamente en:" & vbNewLine & dlg.FileName)
        End If
    End Sub

    Private Sub ImportarCSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarToolStripMenuItem.Click
        Dim dlg As New OpenFileDialog With {
            .Filter = "Archivo CSV (*.csv)|*.csv"
        }

        If dlg.ShowDialog() = DialogResult.OK Then
            Try
                Chart1.Series("Sensor").Points.Clear()
                valoresCelsius.Clear()
                tiempo = 0

                Dim lineas() As String = File.ReadAllLines(dlg.FileName)
                Dim inicio As Integer = 0

                If lineas(0).ToUpper().Contains("TIEMPO") Then inicio = 1

                For i As Integer = inicio To lineas.Length - 1
                    Dim partes() As String = lineas(i).Split(",")
                    If partes.Length >= 2 Then
                        Dim t As Double
                        Dim v As Double
                        If Double.TryParse(partes(0).Trim(), t) AndAlso Double.TryParse(partes(1).Trim(), v) Then
                            valoresCelsius.Add(v)
                            Chart1.Series("Sensor").Points.AddXY(t, v)
                            tiempo = CInt(t) + 1
                        End If
                    End If
                Next

                MsgBox("CSV importado correctamente.")
            Catch ex As Exception
                MsgBox("Error al importar: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub FrmPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If SerialPort1.IsOpen Then SerialPort1.Close()
    End Sub

    Private Sub SALIRToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SALIRToolStripMenuItem1.Click
        If SerialPort1.IsOpen Then
            Dim resp = MsgBox("Estás conectado. ¿Seguro que quieres salir?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question)
            If resp = MsgBoxResult.No Then Return
            SerialPort1.Close()
        End If
        Beep()
        End
    End Sub

    Private Sub SerialPort1_ErrorReceived(sender As Object, e As SerialErrorReceivedEventArgs) Handles SerialPort1.ErrorReceived
        Debug.WriteLine("Error de puerto serial: " & e.EventType.ToString())
    End Sub

    Dim angulo As Double = 0

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim baseTemp As Double = 27 + 5 * Math.Sin(angulo)

        Dim ruido As Double = rnd.NextDouble() * 1.5 - 0.75

        Dim valorSimulado As Double = baseTemp + ruido

        GraficarPunto(Math.Round(valorSimulado, 2))

        angulo += 0.2
    End Sub

End Class