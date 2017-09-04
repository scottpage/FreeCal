'
' Created by SharpDevelop.
' User: Administrator
' Date: 4/3/2005
' Time: 2:30 PM
' 


Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class TextDialog
    Inherits System.Windows.Forms.Form
    Private tbText As System.Windows.Forms.TextBox
    Private btnProceed As System.Windows.Forms.Button
    Private btnAbort As System.Windows.Forms.Button
    Private lblTitle As System.Windows.Forms.Label

    Public Property MyTitle() As String
        Get
            Return Me.lblTitle.Text
        End Get
        Set(ByVal textToShow As String)
            Me.lblTitle.Text = textToShow
            If Me.lblTitle.Width < 510 Then
                Me.Width = 520
                Me.tbText.Width = 510
            Else
                Me.Width = Me.lblTitle.Width + 20
                Me.tbText.Width = Me.Width - 20
            End If
            Me.lblTitle.Left = Convert.ToInt32((Width - lblTitle.Width) / 2)
        End Set
    End Property

    Public Property MyBody() As String
        Get
            Return Me.tbText.Text
        End Get
        Set(ByVal textToShow As String)
            Me.tbText.Text = textToShow
            Me.tbText.Select(0, 0)
            Me.tbText.Width = Me.Width - 20
            Me.tbText.Top = Me.lblTitle.Bottom + 10
        End Set
    End Property

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
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnAbort = New System.Windows.Forms.Button()
        Me.btnProceed = New System.Windows.Forms.Button()
        Me.tbText = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(464, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(54, 24)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Title"
        '
        'btnAbort
        '
        Me.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAbort.Location = New System.Drawing.Point(528, 812)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(150, 43)
        Me.btnAbort.TabIndex = 3
        Me.btnAbort.Text = "Abort"
        '
        'btnProceed
        '
        Me.btnProceed.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnProceed.Location = New System.Drawing.Point(288, 812)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(150, 43)
        Me.btnProceed.TabIndex = 2
        Me.btnProceed.Text = "Proceed"
        '
        'tbText
        '
        Me.tbText.Enabled = False
        Me.tbText.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.tbText.Location = New System.Drawing.Point(16, 118)
        Me.tbText.Multiline = True
        Me.tbText.Name = "tbText"
        Me.tbText.Size = New System.Drawing.Size(1024, 680)
        Me.tbText.TabIndex = 1
        Me.tbText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextDialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.CancelButton = Me.btnAbort
        Me.ClientSize = New System.Drawing.Size(1056, 891)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.btnProceed)
        Me.Controls.Add(Me.tbText)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TextDialog"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

End Class

