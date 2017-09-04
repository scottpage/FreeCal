'
' Created by SharpDevelop.
' User: rspage
' Date: 6/27/2005
' Time: 7:10 AM
' 

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports FreeCal.Data
Imports System.Data
Imports MySql.Data.MySqlClient
Imports ZedGraph
Imports FreeCal.Common


	
	Public Class PowerSensorCalibrationChartForm
		Inherits System.Windows.Forms.Form
		Protected _Chart As ZedGraph.ZedGraphControl
		Private zedGraphControl1 As ZedGraph.ZedGraphControl
		
		Public Property Chart As ZedGraphControl
			Get
				Return Me._Chart
			End Get
			Set
				Me._Chart = Value
			End Set
		End Property

		Public Sub New()
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
			Me.Chart.GraphPane.Title = "Power Sensor Calibration"
			Me.Chart.GraphPane.XAxis.Title = "Frequency (GHz)"
			Me.Chart.GraphPane.YAxis.Title = "Calibration Factor (%)"
		End Sub

		Public Sub New(ByRef Parent As Form)
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
			Me.MdiParent = Parent
			Me.Chart.GraphPane.Title = "Power Sensor Calibration"
			Me.Chart.GraphPane.XAxis.Title = "Frequency (GHz)"
			Me.Chart.GraphPane.YAxis.Title = "Calibration Factor (%)"
		End Sub
		
		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
			Me.zedGraphControl1 = New ZedGraph.ZedGraphControl
			Me.SuspendLayout
			'
			'zedGraphControl1
			'
			Me.zedGraphControl1.IsShowPointValues = false
			Me.zedGraphControl1.Location = New System.Drawing.Point(8, 8)
			Me.zedGraphControl1.Name = "zedGraphControl1"
			Me.zedGraphControl1.PointValueFormat = "G"
			Me.zedGraphControl1.Size = New System.Drawing.Size(632, 416)
			Me.zedGraphControl1.TabIndex = 0
			'
			'WorkForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(648, 461)
			Me.Controls.Add(Me.zedGraphControl1)
			Me.Name = "WorkForm"
			Me.Text = "WorkForm"
			AddHandler Paint, AddressOf Me.WorkFormPaint
			Me.ResumeLayout(false)
		End Sub
		#End Region

		
		Private Sub WorkFormPaint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs)
			Me.Chart.GraphPane.Draw(e.Graphics)
		End Sub
		
	End Class



