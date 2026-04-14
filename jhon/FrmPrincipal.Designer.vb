<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BUSCARCOMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.COMDISPONIBLEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BtnConectar = New System.Windows.Forms.Button()
        Me.BtnLimpiar = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.LblPuertoActual = New System.Windows.Forms.Label()
        Me.LblValorActual = New System.Windows.Forms.Label()
        Me.SalirToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(164, 40)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(431, 300)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.BUSCARCOMToolStripMenuItem, Me.COMDISPONIBLEToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatosToolStripMenuItem, Me.SalirToolStripMenuItem1})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.ArchivoToolStripMenuItem.Text = "ARCHIVO"
        '
        'DatosToolStripMenuItem
        '
        Me.DatosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportarToolStripMenuItem, Me.ImportarToolStripMenuItem})
        Me.DatosToolStripMenuItem.Name = "DatosToolStripMenuItem"
        Me.DatosToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DatosToolStripMenuItem.Text = "Datos"
        '
        'BUSCARCOMToolStripMenuItem
        '
        Me.BUSCARCOMToolStripMenuItem.Name = "BUSCARCOMToolStripMenuItem"
        Me.BUSCARCOMToolStripMenuItem.Size = New System.Drawing.Size(94, 20)
        Me.BUSCARCOMToolStripMenuItem.Text = "BUSCAR COM"
        '
        'COMDISPONIBLEToolStripMenuItem
        '
        Me.COMDISPONIBLEToolStripMenuItem.Name = "COMDISPONIBLEToolStripMenuItem"
        Me.COMDISPONIBLEToolStripMenuItem.Size = New System.Drawing.Size(114, 20)
        Me.COMDISPONIBLEToolStripMenuItem.Text = "COM DISPONIBLE"
        '
        'BtnConectar
        '
        Me.BtnConectar.Location = New System.Drawing.Point(164, 389)
        Me.BtnConectar.Name = "BtnConectar"
        Me.BtnConectar.Size = New System.Drawing.Size(75, 23)
        Me.BtnConectar.TabIndex = 2
        Me.BtnConectar.Text = "CONECTAR"
        Me.BtnConectar.UseVisualStyleBackColor = True
        '
        'BtnLimpiar
        '
        Me.BtnLimpiar.Location = New System.Drawing.Point(519, 389)
        Me.BtnLimpiar.Name = "BtnLimpiar"
        Me.BtnLimpiar.Size = New System.Drawing.Size(75, 23)
        Me.BtnLimpiar.TabIndex = 3
        Me.BtnLimpiar.Text = "LIMPIAR"
        Me.BtnLimpiar.UseVisualStyleBackColor = True
        '
        'LblPuertoActual
        '
        Me.LblPuertoActual.AutoSize = True
        Me.LblPuertoActual.Location = New System.Drawing.Point(324, 363)
        Me.LblPuertoActual.Name = "LblPuertoActual"
        Me.LblPuertoActual.Size = New System.Drawing.Size(121, 13)
        Me.LblPuertoActual.TabIndex = 4
        Me.LblPuertoActual.Text = "Sin puerto seleccionado"
        '
        'LblValorActual
        '
        Me.LblValorActual.AutoSize = True
        Me.LblValorActual.Location = New System.Drawing.Point(357, 389)
        Me.LblValorActual.Name = "LblValorActual"
        Me.LblValorActual.Size = New System.Drawing.Size(48, 13)
        Me.LblValorActual.TabIndex = 5
        Me.LblValorActual.Text = "Sin valor"
        '
        'SalirToolStripMenuItem1
        '
        Me.SalirToolStripMenuItem1.Name = "SalirToolStripMenuItem1"
        Me.SalirToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.SalirToolStripMenuItem1.Text = "Salir"
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ExportarToolStripMenuItem.Text = "Exportar"
        '
        'ImportarToolStripMenuItem
        '
        Me.ImportarToolStripMenuItem.Name = "ImportarToolStripMenuItem"
        Me.ImportarToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ImportarToolStripMenuItem.Text = "Importar"
        '
        'FrmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.LblValorActual)
        Me.Controls.Add(Me.LblPuertoActual)
        Me.Controls.Add(Me.BtnLimpiar)
        Me.Controls.Add(Me.BtnConectar)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmPrincipal"
        Me.Text = "Main"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BUSCARCOMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents COMDISPONIBLEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BtnConectar As Button
    Friend WithEvents BtnLimpiar As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents LblPuertoActual As Label
    Friend WithEvents ExportarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents LblValorActual As Label
End Class
