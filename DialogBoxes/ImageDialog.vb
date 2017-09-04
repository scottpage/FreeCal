'
' Created by SharpDevelop.
' User: Administrator
' Date: 4/3/2005
' Time: 2:30 PM
' 


Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class ImageDialog
    Inherits System.Windows.Forms.Form
    Private CurrentImageLocation As String
    Private WithEvents AutoCloseTimer As System.Timers.Timer
    Private StartTime As Date
    Private Counter As Integer = 0
    Private WithEvents ElapsedTimeCounter As System.Timers.Timer
    Private ElapsedCounterSecond As Integer = 0
    Private ElapsedCounterTenSecond As Integer = 0
    Private ElapsedCounterMinute As Integer = 0
    Private ElapsedCounterHour As Integer = 0
    Private label1 As System.Windows.Forms.Label
    Private btnProceed As System.Windows.Forms.Button
    Private btnAbort As System.Windows.Forms.Button
    Private pbImage As System.Windows.Forms.PictureBox
    Private lblTitle As System.Windows.Forms.Label

    Public Property MyTitle() As String
        Get
            Return Me.lblTitle.Text
        End Get
        Set(ByVal textToShow As String)
            lblTitle.Text = textToShow
            lblTitle.Left = Convert.ToInt32((Width - lblTitle.Width) / 2)
        End Set
    End Property

    Public Property MyImage() As String
        Get
            Return Me.CurrentImageLocation
        End Get
        Set(ByVal imageToShow As String)
            Dim NewImage As Image = Image.FromFile(imageToShow)
            pbImage.Image = NewImage
            If lblTitle.Width > pbImage.Width Then
                Width = lblTitle.Width + 20
                pbImage.Width = NewImage.Width
            Else
                pbImage.Width = NewImage.Width
                Width = pbImage.Width + 10
            End If
            lblTitle.Top = Top + 10
            pbImage.Top = lblTitle.Bottom + 10
            pbImage.Height = NewImage.Height
            Height = btnAbort.Height + pbImage.Height + lblTitle.Height + 30
            btnProceed.Top = pbImage.Bottom + 10
            btnProceed.Left = Convert.ToInt32((Width - btnProceed.Width) / 2 - btnProceed.Width - 5)
            btnAbort.Top = btnProceed.Top
            btnAbort.Left = Convert.ToInt32((Width - btnAbort.Width) / 2 + btnAbort.Width + 5)
            lblTitle.Left = Convert.ToInt32((Width - lblTitle.Width) / 2)
            pbImage.Left = Convert.ToInt32((Width - pbImage.Width) / 2)
            Height = btnAbort.Height + pbImage.Height + lblTitle.Height + 50
            CurrentImageLocation = imageToShow
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
    End Sub

    Public Sub New(ByVal sleepTime As Integer)
        MyBase.New()
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.AutoCloseTimer = New System.Timers.Timer
        Me.AutoCloseTimer.Interval = sleepTime
        Me.AutoCloseTimer.Enabled = True
        Me.ElapsedTimeCounter = New System.Timers.Timer
        Me.ElapsedTimeCounter.Interval = 1000
        Me.ElapsedTimeCounter.Enabled = True
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pbImage = New System.Windows.Forms.PictureBox()
        Me.btnAbort = New System.Windows.Forms.Button()
        Me.btnProceed = New System.Windows.Forms.Button()
        Me.label1 = New System.Windows.Forms.Label()
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbImage
        '
        Me.pbImage.Location = New System.Drawing.Point(16, 89)
        Me.pbImage.Name = "pbImage"
        Me.pbImage.Size = New System.Drawing.Size(1024, 694)
        Me.pbImage.TabIndex = 4
        Me.pbImage.TabStop = False
        '
        'btnAbort
        '
        Me.btnAbort.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAbort.Location = New System.Drawing.Point(576, 857)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(150, 42)
        Me.btnAbort.TabIndex = 3
        Me.btnAbort.Text = "Abort"
        '
        'btnProceed
        '
        Me.btnProceed.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnProceed.Location = New System.Drawing.Point(288, 857)
        Me.btnProceed.Name = "btnProceed"
        Me.btnProceed.Size = New System.Drawing.Size(150, 42)
        Me.btnProceed.TabIndex = 2
        Me.btnProceed.Text = "Proceed"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.label1.Location = New System.Drawing.Point(432, 798)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(0, 13)
        Me.label1.TabIndex = 5
        Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImageDialog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.CancelButton = Me.btnAbort
        Me.ClientSize = New System.Drawing.Size(1074, 934)
        Me.ControlBox = False
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.pbImage)
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.btnProceed)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ImageDialog"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        CType(Me.pbImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub ImageDialogLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub AutoCloseTimerElapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles AutoCloseTimer.Elapsed
        Try
            AutoCloseTimer.Enabled = False
            Me.Close()
        Catch Ex As Exception
            MessageBox.Show(Ex.ToString)
        End Try
    End Sub

    Private Sub ElapsedTimeCounterElapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles ElapsedTimeCounter.Elapsed
        Try
            Me.ElapsedCounterSecond += 1
            If Me.ElapsedCounterSecond = 10 Then
                Me.ElapsedCounterTenSecond += 1
                Me.ElapsedCounterSecond = 0
            End If
            If Me.ElapsedCounterTenSecond = 6 Then
                Me.ElapsedCounterMinute += 1
                Me.ElapsedCounterTenSecond = 0
            End If
            If Me.ElapsedCounterMinute = 60 Then
                Me.ElapsedCounterHour += 1
                Me.ElapsedCounterMinute = 0
            End If
            Me.label1.Text = "Elapsed Time:  " & Me.ElapsedCounterHour & ":" & Me.ElapsedCounterMinute & ":" & Me.ElapsedCounterTenSecond & Me.ElapsedCounterSecond
        Catch Ex As Exception
            MessageBox.Show(Ex.ToString)
        End Try
    End Sub

End Class

