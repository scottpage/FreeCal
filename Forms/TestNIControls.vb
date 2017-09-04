Public Class TestNIControls
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ScatterGraph1 As NationalInstruments.UI.WindowsForms.ScatterGraph
    Friend WithEvents XAxis1 As NationalInstruments.UI.XAxis
    Friend WithEvents YAxis1 As NationalInstruments.UI.YAxis
    Friend WithEvents ScatterPlot1 As NationalInstruments.UI.ScatterPlot
    Friend WithEvents XyCursor1 As NationalInstruments.UI.XYCursor
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim AxisCustomDivision1 As NationalInstruments.UI.AxisCustomDivision = New NationalInstruments.UI.AxisCustomDivision
        Me.ScatterGraph1 = New NationalInstruments.UI.WindowsForms.ScatterGraph
        Me.XAxis1 = New NationalInstruments.UI.XAxis
        Me.YAxis1 = New NationalInstruments.UI.YAxis
        Me.ScatterPlot1 = New NationalInstruments.UI.ScatterPlot
        Me.XyCursor1 = New NationalInstruments.UI.XYCursor
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.ScatterGraph1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XyCursor1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ScatterGraph1
        '
        Me.ScatterGraph1.Cursors.AddRange(New NationalInstruments.UI.XYCursor() {Me.XyCursor1})
        Me.ScatterGraph1.Location = New System.Drawing.Point(8, 0)
        Me.ScatterGraph1.Name = "ScatterGraph1"
        Me.ScatterGraph1.Plots.AddRange(New NationalInstruments.UI.ScatterPlot() {Me.ScatterPlot1})
        Me.ScatterGraph1.Size = New System.Drawing.Size(480, 288)
        Me.ScatterGraph1.TabIndex = 0
        Me.ScatterGraph1.XAxes.AddRange(New NationalInstruments.UI.XAxis() {Me.XAxis1})
        Me.ScatterGraph1.YAxes.AddRange(New NationalInstruments.UI.YAxis() {Me.YAxis1})
        '
        'XAxis1
        '
        Me.XAxis1.CustomDivisions.AddRange(New NationalInstruments.UI.AxisCustomDivision() {AxisCustomDivision1})
        '
        'ScatterPlot1
        '
        Me.ScatterPlot1.XAxis = Me.XAxis1
        Me.ScatterPlot1.YAxis = Me.YAxis1
        '
        'XyCursor1
        '
        Me.XyCursor1.Plot = Me.ScatterPlot1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(216, 304)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        '
        'TestNIControls
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 342)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ScatterGraph1)
        Me.Name = "TestNIControls"
        Me.Text = "TestNIControls"
        CType(Me.ScatterGraph1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XyCursor1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.ScatterPlot1.PlotXY(10, 5)
        Me.ScatterPlot1.PlotXYAppend(11, 6)
    End Sub
End Class
