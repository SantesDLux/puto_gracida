Imports System.IO
Imports System.IO.Ports
Imports System.Windows.Forms.DataVisualization.Charting

Public Class FrmPrincipal
    Dim modoSimulacion As Boolean = False
    Dim tiempo As Integer = 0
    Dim puertoConfigurado As Boolean = False
    Dim rnd As New Random()

    ' Lista interna para guardar SIEMPRE los valores originales en Celsius
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
        Chart1.ChartAreas(0).AxisY.Title = "Temperatura (°C)"
        LblPuertoActual.Text = "Sin puerto seleccionado"
        cmbMedida.Text = "Celsius"
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

    ' CORRECCIÓN PRINCIPAL:
    ' - Recibe siempre el valor en Celsius
    ' - Lo guarda en la lista interna
    ' - Convierte al mostrar según la unidad seleccionada
    ' - El label muestra la unidad correcta
    Private Sub GraficarPunto(valorCelsius As Double)
        ' Guardar el valor original en Celsius
        valoresCelsius.Add(valorCelsius)

        Dim valorFinal As Double
        Dim unidad As String

        If cmbMedida.Text = "Fahrenheit" Then
            valorFinal = (valorCelsius * 9 / 5) + 32
            unidad = "°F"
        Else
            valorFinal = valorCelsius
            unidad = "°C"
        End If

        Chart1.Series("Sensor").Points.AddXY(tiempo, valorFinal)

        ' Label con unidad correcta
        LblValorActual.Text = "Valor: " & valorFinal.ToString("F2") & " " & unidad

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
        valoresCelsius.Clear()   ' Limpiar también la lista interna
        tiempo = 0
        LblValorActual.Text = "Valor: -"
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
                ' Exportar siempre en Celsius para consistencia
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
                valoresCelsius.Clear()   ' Limpiar lista interna al importar
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
                            ' El CSV guarda valores en Celsius
                            valoresCelsius.Add(v)

                            Dim valorFinal As Double
                            If cmbMedida.Text = "Fahrenheit" Then
                                valorFinal = (v * 9 / 5) + 32
                            Else
                                valorFinal = v
                            End If

                            Chart1.Series("Sensor").Points.AddXY(t, valorFinal)
                            tiempo = CInt(t) + 1
                        End If
                    End If
                Next

                LblValorActual.Text = "CSV cargado: " & (lineas.Length - inicio) & " puntos"
                ActualizarTituloEje()
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

    ' CORRECCIÓN PRINCIPAL del bug de conversión acumulada:
    ' Antes: tomaba el valor ya convertido y lo volvía a convertir → datos corruptos
    ' Ahora: reconstruye la gráfica desde los valores originales en Celsius
    Private Sub cmbMedida_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMedida.SelectedIndexChanged
        ActualizarTituloEje()

        If valoresCelsius.Count = 0 Then Return

        Dim esFahrenheit As Boolean = (cmbMedida.Text = "Fahrenheit")

        Chart1.Series("Sensor").Points.Clear()

        For i As Integer = 0 To valoresCelsius.Count - 1
            Dim valorFinal As Double
            If esFahrenheit Then
                valorFinal = (valoresCelsius(i) * 9 / 5) + 32
            Else
                valorFinal = valoresCelsius(i)
            End If
            Chart1.Series("Sensor").Points.AddXY(i, valorFinal)
        Next

        ' Actualizar el label con el último valor y la unidad correcta
        Dim ultimo As Double = valoresCelsius(valoresCelsius.Count - 1)
        If esFahrenheit Then
            LblValorActual.Text = "Valor: " & ((ultimo * 9 / 5) + 32).ToString("F2") & " °F"
        Else
            LblValorActual.Text = "Valor: " & ultimo.ToString("F2") & " °C"
        End If

        Chart1.Invalidate()
    End Sub

    ' Método auxiliar para mantener el título del eje Y consistente con la unidad
    Private Sub ActualizarTituloEje()
        If cmbMedida.Text = "Fahrenheit" Then
            Chart1.ChartAreas(0).AxisY.Title = "Temperatura (°F)"
        Else
            Chart1.ChartAreas(0).AxisY.Title = "Temperatura (°C)"
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim valorSimulado As Double = rnd.NextDouble() * (35.0 - 20.0) + 20.0
        GraficarPunto(valorSimulado)
    End Sub

End Class