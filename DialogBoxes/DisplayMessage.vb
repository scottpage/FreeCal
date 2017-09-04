'
' Created by SharpDevelop.
' User: Administrator
' Date: 4/3/2005
' Time: 12:48 PM
' 


Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class DisplayMessage
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'DisplayMessage
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(1409, 558)
        Me.Name = "DisplayMessage"
        Me.Text = "DisplayMessage"
        Me.ResumeLayout(False)

    End Sub
#End Region

End Class

