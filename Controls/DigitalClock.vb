'
' Created by SharpDevelop.
' User: rspage
' Date: 5/7/2005
' Time: 3:58 PM
' 
'
'

Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Namespace FreeCal.Controls
	
	Public Class DigitalClock
		Inherits System.Windows.Forms.UserControl
		Private StartTime As Date
		Private Running As Boolean
		Private mCountDown As Boolean
		Private mAlarmTime As Date
		Private ClockTimer As System.Timers.Timer
		Private lblClock As System.Windows.Forms.Label
		
		Public Property CountDown() As Boolean
			Get
				Return mCountDown
			End Get
			Set
				mCountDown = Value
			End Set
		End Property

		Public Property AlarmTime() As Date
			Get
				Return mAlarmTime
			End Get
			Set
				mAlarmTime = Value
			End Set
		End Property

		Public Sub New()
			MyBase.New
			' Must be called for initialization
			Me.InitializeComponent
		End Sub
		
		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
			Me.lblClock = New System.Windows.Forms.Label
			Me.ClockTimer = New System.Timers.Timer
			CType(Me.ClockTimer,System.ComponentModel.ISupportInitialize).BeginInit
			Me.SuspendLayout
			'
			'lblClock
			'
			Me.lblClock.Font = New System.Drawing.Font("Lucida Console", 30!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
			Me.lblClock.Location = New System.Drawing.Point(0, 0)
			Me.lblClock.Name = "lblClock"
			Me.lblClock.Size = New System.Drawing.Size(232, 96)
			Me.lblClock.TabIndex = 0
			Me.lblClock.Text = "12:00:00"
			Me.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'ClockTimer
			'
			Me.ClockTimer.SynchronizingObject = Me
			AddHandler Me.ClockTimer.Elapsed, AddressOf Me.ClockTimerElapsed
			'
			'DigitalClock
			'
			Me.Controls.Add(Me.lblClock)
			Me.Name = "DigitalClock"
			Me.Size = New System.Drawing.Size(232, 96)
			AddHandler Resize, AddressOf Me.DigitalClockResize
			CType(Me.ClockTimer,System.ComponentModel.ISupportInitialize).EndInit
			Me.ResumeLayout(false)
		End Sub
		#End Region
		
		Private Sub DigitalClockResize(sender As System.Object, e As System.EventArgs)
			Me.lblClock.Size = Me.Size
			Me.Invalidate
		End Sub

		Public Sub StartTimer()
			If Not Me.Running Then
				Me.ClockTimer.Enabled = True
				Me.Running = True
				Me.StartTime = Now
			End If
		End Sub

		Public Sub StopTimer()
			If Me.Running Then
				Me.ClockTimer.Enabled = False
				Me.Running = False
			End If
		End Sub

		Private Sub ClockTimerElapsed(sender As System.Object, e As System.Timers.ElapsedEventArgs)
			Dim TimeDiff As TimeSpan = Me.mAlarmTime.Subtract(Now)
			If TimeDiff.Seconds < 0 Then
			End If
		End Sub

	End Class
End Namespace
