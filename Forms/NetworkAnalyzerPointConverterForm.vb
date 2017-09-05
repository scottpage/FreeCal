'
' Created by SharpDevelop.
' User: rspage
' Date: 5/4/2005
' Time: 9:40 PM
' 
'
'

Imports System.Data
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class NetworkAnalyzerPointConverterForm
    Inherits System.Windows.Forms.Form

    Private WithEvents tbPointToAdd As System.Windows.Forms.TextBox
    Private WithEvents lstPoints As System.Windows.Forms.ListBox
    Private WithEvents btnOK As System.Windows.Forms.Button
    Private WithEvents btnRemove As System.Windows.Forms.Button
    Private WithEvents btnConvert As System.Windows.Forms.Button
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnAddPoint As System.Windows.Forms.Button

    Public NWADataTable As DataTable

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
    End Sub

    Public Sub New(ByVal title As String, ByVal parent As Form, ByVal data As DataTable)
        MyBase.New
        Me.InitializeComponent()
        Me.Text = title
        Me.MdiParent = parent
        Me.NWADataTable = data
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.btnAddPoint = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lstPoints = New System.Windows.Forms.ListBox()
        Me.tbPointToAdd = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnAddPoint
        '
        Me.btnAddPoint.Location = New System.Drawing.Point(256, 89)
        Me.btnAddPoint.Name = "btnAddPoint"
        Me.btnAddPoint.Size = New System.Drawing.Size(150, 42)
        Me.btnAddPoint.TabIndex = 1
        Me.btnAddPoint.Text = "Add"
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(240, 635)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(150, 43)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(256, 236)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(150, 43)
        Me.btnConvert.TabIndex = 6
        Me.btnConvert.Text = "Convert"
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(256, 148)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(150, 42)
        Me.btnRemove.TabIndex = 2
        Me.btnRemove.Text = "Remove"
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(32, 635)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(150, 43)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        '
        'lstPoints
        '
        Me.lstPoints.ItemHeight = 25
        Me.lstPoints.Location = New System.Drawing.Point(432, 30)
        Me.lstPoints.Name = "lstPoints"
        Me.lstPoints.Size = New System.Drawing.Size(368, 629)
        Me.lstPoints.TabIndex = 0
        '
        'tbPointToAdd
        '
        Me.tbPointToAdd.Location = New System.Drawing.Point(16, 30)
        Me.tbPointToAdd.Name = "tbPointToAdd"
        Me.tbPointToAdd.Size = New System.Drawing.Size(400, 31)
        Me.tbPointToAdd.TabIndex = 3
        '
        'NetworkAnalyzerPointConverterForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(851, 715)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.tbPointToAdd)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAddPoint)
        Me.Controls.Add(Me.lstPoints)
        Me.Name = "NetworkAnalyzerPointConverterForm"
        Me.Text = "NetworkAnalyzerPointConverterForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub BtnOKClick(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub BtnRemoveClick(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click

    End Sub

    Private Sub BtnCancelClick(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub BtnAddPointClick(sender As System.Object, e As System.EventArgs) Handles btnAddPoint.Click
        If (Me.tbPointToAdd.Text.Length > 0 And IsNumeric(Me.tbPointToAdd.Text)) Then
            Me.lstPoints.Items.Add(Me.tbPointToAdd.Text)
        ElseIf Me.tbPointToAdd.Text.Length = 0 Then
            MessageBox.Show("You cannot add a blank value.")
        ElseIf Not IsNumeric(Me.tbPointToAdd.Text) Then
            MessageBox.Show("The point must only contain numeric values.")
        End If
    End Sub

    Private Sub BtnConvertClick(sender As System.Object, e As System.EventArgs) Handles btnConvert.Click
        'Dim PreviousValue As Integer
        For Each OldPoint As String In Me.NWADataTable.Rows
            Dim Point As Integer = CInt(OldPoint)
            For Each NewPoint As String In Me.lstPoints.Items

            Next
        Next
    End Sub

End Class

