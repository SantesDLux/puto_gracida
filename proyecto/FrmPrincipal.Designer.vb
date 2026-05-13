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
        Me.ARCHIVOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SALIRToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BUSCARCOMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.COMDISPONIBLESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.LblPuertoActual = New System.Windows.Forms.Label()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnLimpíar = New System.Windows.Forms.Button()
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
        Me.Chart1.Location = New System.Drawing.Point(39, 38)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(470, 300)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ARCHIVOToolStripMenuItem, Me.BUSCARCOMToolStripMenuItem, Me.COMDISPONIBLESToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(573, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ARCHIVOToolStripMenuItem
        '
        Me.ARCHIVOToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DatosToolStripMenuItem, Me.SALIRToolStripMenuItem1})
        Me.ARCHIVOToolStripMenuItem.Name = "ARCHIVOToolStripMenuItem"
        Me.ARCHIVOToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.ARCHIVOToolStripMenuItem.Text = "ARCHIVO"
        '
        'DatosToolStripMenuItem
        '
        Me.DatosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportarToolStripMenuItem, Me.ExportarToolStripMenuItem})
        Me.DatosToolStripMenuItem.Name = "DatosToolStripMenuItem"
        Me.DatosToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
        Me.DatosToolStripMenuItem.Text = "Datos"
        '
        'ImportarToolStripMenuItem
        '
        Me.ImportarToolStripMenuItem.Name = "ImportarToolStripMenuItem"
        Me.ImportarToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ImportarToolStripMenuItem.Text = "Importar"
        '
        'ExportarToolStripMenuItem
        '
        Me.ExportarToolStripMenuItem.Name = "ExportarToolStripMenuItem"
        Me.ExportarToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ExportarToolStripMenuItem.Text = "Exportar"
        '
        'SALIRToolStripMenuItem1
        '
        Me.SALIRToolStripMenuItem1.Name = "SALIRToolStripMenuItem1"
        Me.SALIRToolStripMenuItem1.Size = New System.Drawing.Size(104, 22)
        Me.SALIRToolStripMenuItem1.Text = "SALIR"
        '
        'BUSCARCOMToolStripMenuItem
        '
        Me.BUSCARCOMToolStripMenuItem.Name = "BUSCARCOMToolStripMenuItem"
        Me.BUSCARCOMToolStripMenuItem.Size = New System.Drawing.Size(94, 20)
        Me.BUSCARCOMToolStripMenuItem.Text = "BUSCAR COM"
        '
        'COMDISPONIBLESToolStripMenuItem
        '
        Me.COMDISPONIBLESToolStripMenuItem.Name = "COMDISPONIBLESToolStripMenuItem"
        Me.COMDISPONIBLESToolStripMenuItem.Size = New System.Drawing.Size(120, 20)
        Me.COMDISPONIBLESToolStripMenuItem.Text = "COM DISPONIBLES"
        '
        'Timer1
        '
        '
        'SerialPort1
        '
        '
        'LblPuertoActual
        '
        Me.LblPuertoActual.AutoSize = True
        Me.LblPuertoActual.Location = New System.Drawing.Point(215, 359)
        Me.LblPuertoActual.Name = "LblPuertoActual"
        Me.LblPuertoActual.Size = New System.Drawing.Size(121, 13)
        Me.LblPuertoActual.TabIndex = 2
        Me.LblPuertoActual.Text = "Sin puerto seleccionado"
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(39, 389)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BtnAceptar.TabIndex = 3
        Me.BtnAceptar.Text = "CONECTAR"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'BtnLimpíar
        '
        Me.BtnLimpíar.Location = New System.Drawing.Point(434, 389)
        Me.BtnLimpíar.Name = "BtnLimpíar"
        Me.BtnLimpíar.Size = New System.Drawing.Size(75, 23)
        Me.BtnLimpíar.TabIndex = 4
        Me.BtnLimpíar.Text = "LIMPIAR"
        Me.BtnLimpíar.UseVisualStyleBackColor = True
        '
        'FrmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 450)
        Me.Controls.Add(Me.BtnLimpíar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.LblPuertoActual)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmPrincipal"
        Me.Text = "Form1"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ARCHIVOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BUSCARCOMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents COMDISPONIBLESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents LblPuertoActual As Label
    Friend WithEvents BtnAceptar As Button
    Friend WithEvents BtnLimpíar As Button
    Friend WithEvents DatosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SALIRToolStripMenuItem1 As ToolStripMenuItem
End Class
