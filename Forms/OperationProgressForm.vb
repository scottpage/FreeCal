'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/12/2005
' Time: 5:42 PM
'


Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel


	
	Public Class OperationProgressForm
		Inherits System.Windows.Forms.Form
		Private progressBar1 As System.Windows.Forms.ProgressBar
		Private lblMessage As System.Windows.Forms.Label
		Private WithEvents ProgressTimer As New System.Timers.Timer
		Private _TimerIncreaseValue As Integer = 1

		Public Sub New
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
		End Sub

		Public Sub New(ByVal title As String, ByVal message As String, ByVal minProgressValue As Integer, ByVal maxProgressValue As Integer, ByVal currentProgressValue As Integer)
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
			Me.ProgressTimer.Enabled = False
			Me.Text = title
			Me.lblMessage.Text = message
			Me.progressBar1.Minimum = minProgressValue
			Me.progressBar1.Maximum = maxProgressValue
			Me.progressBar1.Value = currentProgressValue
		End Sub
		
		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.progressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(16, 15)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(992, 251)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "Message"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'progressBar1
        '
        Me.progressBar1.Location = New System.Drawing.Point(16, 281)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(992, 42)
        Me.progressBar1.TabIndex = 0
        '
        'OperationProgressForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(1031, 342)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.progressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OperationProgressForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OperationProgressForm"
        Me.ResumeLayout(False)

    End Sub
#End Region

    <Category("Progress"), Description("Title of this progress window.")> _
		Public Property Title As String
			Get
				Return Me.Text
			End Get
			Set
				Me.Text = Value
			End Set
		End Property

		<Category("Progress"), Description("Information displayed to the user about the current operation.")> _
		Public Property Message As String
			Get
				Return Me.lblMessage.Text
			End Get
			Set
				Me.lblMessage.Text = Value
			End Set
		End Property

		<Category("Progress"), Description("Minumum allowed value of the progress bar.")> _
		Public Property MinimumProgressValue As Integer
			Get
				Return Me.progressBar1.Minimum
			End Get
			Set
				Me.progressBar1.Minimum = Value
			End Set
		End Property

		<Category("Progress"), Description("Maximum allowed value of the progress bar.")> _
		Public Property MaximumProgressValue As Integer
			Get
				Return Me.progressBar1.Maximum
			End Get
			Set
				Me.progressBar1.Maximum = Value
			End Set
		End Property

		<Category("Progress"), Description("Current value of the progress bar.")> _
		Public Property CurrentProgressValue As Integer
			Get
				Return Me.progressBar1.Value
			End Get
			Set
				'If ((Me.progressBar1.Value + Value) < Me.progressBar1.Value) Then
					Me.progressBar1.Value += Value
				'End If
			End Set
		End Property

		Public Sub IncreaseProgressBar(ByVal amountToIncrease As Integer)
			If ((Me.progressBar1.Value + amountToIncrease) < Me.progressBar1.Value) Then
				Me.progressBar1.Value += amountToIncrease
			End If
		End Sub

		Public Sub StartTimer(ByVal interval As Integer, ByVal timerIncreaseAmount As Integer)
			Me._TimerIncreaseValue = timerIncreaseAmount
			Me.ProgressTimer.Interval = interval
			Me.ProgressTimer.Enabled = True
		End Sub

		Private Sub ProgressTimerElapsed(ByVal Sender As Object, ByVal E As System.Timers.ElapsedEventArgs) Handles ProgressTimer.Elapsed
			If Me.progressBar1.Value = Me.progressBar1.Maximum Then
				Me.ProgressTimer.Enabled = False
				Me.Close
			End If
			Me.progressBar1.Value += Me._TimerIncreaseValue
		End Sub

	End Class

