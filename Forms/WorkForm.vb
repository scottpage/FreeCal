'
' Created by SharpDevelop.
' User: rspage
' Date: 6/21/2005
' Time: 2:26 PM
' 



Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports FreeCal.Data
Imports System.Data
Imports MySql.Data.MySqlClient



Public Class WorkForm
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
    End Sub

    Public Sub New(ByRef Parent As Form)
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.MdiParent = Parent
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        '
        'WorkForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(648, 461)
        Me.Name = "WorkForm"
        Me.Text = "WorkForm"
        AddHandler Paint, AddressOf Me.WorkFormPaint
    End Sub
#End Region


    Private Sub WorkFormPaint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs)
    End Sub

End Class

