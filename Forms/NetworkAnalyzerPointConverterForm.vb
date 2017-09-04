'
' Created by SharpDevelop.
' User: rspage
' Date: 5/4/2005
' Time: 9:40 PM
' 
'
'

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data
Imports Microsoft.VisualBasic


	
	Public Class NetworkAnalyzerPointConverterForm
		Inherits System.Windows.Forms.Form
		Private tbPointToAdd As System.Windows.Forms.TextBox
		Private lstPoints As System.Windows.Forms.ListBox
		Private btnOK As System.Windows.Forms.Button
		Private btnRemove As System.Windows.Forms.Button
		Private btnConvert As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
		Private btnAddPoint As System.Windows.Forms.Button
		
		Public NWADataTable As DataTable

		Public Sub New()
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
		End Sub

		Public Sub New(ByVal title As String, ByVal parent As Form, ByVal data As DataTable)
			MyBase.New
			Me.InitializeComponent
			Me.Text = Title
			Me.MdiParent = Parent
			Me.NWADataTable = Data
		End Sub

		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
			Me.btnAddPoint = New System.Windows.Forms.Button
			Me.btnCancel = New System.Windows.Forms.Button
			Me.btnConvert = New System.Windows.Forms.Button
			Me.btnRemove = New System.Windows.Forms.Button
			Me.btnOK = New System.Windows.Forms.Button
			Me.lstPoints = New System.Windows.Forms.ListBox
			Me.tbPointToAdd = New System.Windows.Forms.TextBox
			Me.SuspendLayout
			'
			'btnAddPoint
			'
			Me.btnAddPoint.Location = New System.Drawing.Point(128, 48)
			Me.btnAddPoint.Name = "btnAddPoint"
			Me.btnAddPoint.TabIndex = 1
			Me.btnAddPoint.Text = "Add"
			AddHandler Me.btnAddPoint.Click, AddressOf Me.BtnAddPointClick
			'
			'btnCancel
			'
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(120, 344)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.TabIndex = 4
			Me.btnCancel.Text = "Cancel"
			AddHandler Me.btnCancel.Click, AddressOf Me.BtnCancelClick
			'
			'btnConvert
			'
			Me.btnConvert.Location = New System.Drawing.Point(128, 128)
			Me.btnConvert.Name = "btnConvert"
			Me.btnConvert.TabIndex = 6
			Me.btnConvert.Text = "Convert"
			AddHandler Me.btnConvert.Click, AddressOf Me.BtnConvertClick
			'
			'btnRemove
			'
			Me.btnRemove.Location = New System.Drawing.Point(128, 80)
			Me.btnRemove.Name = "btnRemove"
			Me.btnRemove.TabIndex = 2
			Me.btnRemove.Text = "Remove"
			AddHandler Me.btnRemove.Click, AddressOf Me.BtnRemoveClick
			'
			'btnOK
			'
			Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnOK.Location = New System.Drawing.Point(16, 344)
			Me.btnOK.Name = "btnOK"
			Me.btnOK.TabIndex = 5
			Me.btnOK.Text = "OK"
			AddHandler Me.btnOK.Click, AddressOf Me.BtnOKClick
			'
			'lstPoints
			'
			Me.lstPoints.Location = New System.Drawing.Point(216, 16)
			Me.lstPoints.Name = "lstPoints"
			Me.lstPoints.Size = New System.Drawing.Size(184, 355)
			Me.lstPoints.TabIndex = 0
			'
			'tbPointToAdd
			'
			Me.tbPointToAdd.Location = New System.Drawing.Point(8, 16)
			Me.tbPointToAdd.Name = "tbPointToAdd"
			Me.tbPointToAdd.Size = New System.Drawing.Size(200, 20)
			Me.tbPointToAdd.TabIndex = 3
			Me.tbPointToAdd.Text = ""
			'
			'NetworkAnalyzerPointConverterForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(408, 382)
			Me.Controls.Add(Me.btnConvert)
			Me.Controls.Add(Me.btnOK)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.tbPointToAdd)
			Me.Controls.Add(Me.btnRemove)
			Me.Controls.Add(Me.btnAddPoint)
			Me.Controls.Add(Me.lstPoints)
			Me.Name = "NetworkAnalyzerPointConverterForm"
			Me.Text = "NetworkAnalyzerPointConverterForm"
			Me.ResumeLayout(false)
		End Sub
		#End Region
		
		Private Sub BtnOKClick(sender As System.Object, e As System.EventArgs)
			Me.Close
		End Sub

		Private Sub BtnRemoveClick(sender As System.Object, e As System.EventArgs)
			
		End Sub

		Private Sub BtnCancelClick(sender As System.Object, e As System.EventArgs)
			
		End Sub

		Private Sub BtnAddPointClick(sender As System.Object, e As System.EventArgs)
			If (Me.tbPointToAdd.Text.Length > 0 And IsNumeric(Me.tbPointToAdd.Text)) Then
				Me.lstPoints.Items.Add(Me.tbPointToAdd.Text)
			ElseIf Me.tbPointToAdd.Text.Length = 0 Then
				MessageBox.Show("You cannot add a blank value.")
			ElseIf Not IsNumeric(Me.tbPointToAdd.Text) Then
				MessageBox.Show("The point must only contain numeric values.")
			End If
		End Sub

		Private Sub BtnConvertClick(sender As System.Object, e As System.EventArgs)
			Dim PreviousValue As Integer
			For Each OldPoint As String In Me.NWADataTable.Rows
				Dim Point As Integer = CInt(OldPoint)
				For Each NewPoint As String In Me.lstPoints.Items
					
				Next
			Next
		End Sub

	End Class

