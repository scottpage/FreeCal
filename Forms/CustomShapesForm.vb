'
' Created by SharpDevelop.
' User: rspage
' Date: 5/11/2005
' Time: 3:56 PM
' 
'
'

Imports System
Imports System.Drawing
Imports System.Windows.Forms


	
	Public Class CustomShapesForm
		Inherits System.Windows.Forms.Form
		Private splitter1 As System.Windows.Forms.Splitter
		
		Public Sub New()
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
		End Sub
		
		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
			Me.splitter1 = New System.Windows.Forms.Splitter
			Me.SuspendLayout
			'
			'splitter1
			'
			Me.splitter1.Location = New System.Drawing.Point(0, 0)
			Me.splitter1.Name = "splitter1"
			Me.splitter1.Size = New System.Drawing.Size(3, 430)
			Me.splitter1.TabIndex = 0
			Me.splitter1.TabStop = false
			'
			'CustomShapesForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
			Me.ClientSize = New System.Drawing.Size(592, 430)
			Me.Controls.Add(Me.splitter1)
			Me.Name = "CustomShapesForm"
			Me.Text = "CustomShapesForm"
			Me.ResumeLayout(false)
		End Sub
		#End Region
		
	End Class

