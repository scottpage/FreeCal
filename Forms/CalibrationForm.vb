'
' Created by SharpDevelop.
' User: rspage
' Date: 4/26/2005
' Time: 1:24 PM
' 


Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient


	
	Public Class CalibrationForm
		Inherits System.Windows.Forms.Form
		
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
            '
            'CalibrationForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(688, 445)
            Me.Name = "CalibrationForm"
            Me.Text = "CalibrationForm"
        End Sub
		#End Region
		
	End Class

