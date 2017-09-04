'
' Created by SharpDevelop.
' User: rspage
' Date: 5/11/2005
' Time: 3:40 PM
' 
'
'

Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace System.Windows.Forms

	Public Enum TwoStateOnOffEnum
		[On]
		[Off]
	End Enum

	Public Class ToggleSwitch
		Inherits System.Windows.Forms.UserControl
		Private mCurrentState As FreeCal.Controls.TwoStateOnOffEnum = TwoStateOnOffEnum.[Off]
		Private btnToggle As System.Windows.Forms.Button
		
		Public Property CurrentState As TwoStateOnOffEnum
			Get
				Return Me.mCurrentState
			End Get
			Set
				Me.ToggleSwitch
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
			Me.btnToggle = New System.Windows.Forms.Button
			Me.SuspendLayout
			'
			'btnToggle
			'
			Me.btnToggle.Location = New System.Drawing.Point(3, 3)
			Me.btnToggle.Name = "btnToggle"
			Me.btnToggle.Size = New System.Drawing.Size(20, 20)
			Me.btnToggle.TabIndex = 0
			AddHandler Me.btnToggle.Click, AddressOf Me.BtnToggleClick
			'
			'ToggleSwitch
			'
			Me.Controls.Add(Me.btnToggle)
			Me.Name = "ToggleSwitch"
			Me.Size = New System.Drawing.Size(26, 46)
			AddHandler Click, AddressOf Me.ToggleSwitchClick
			Me.ResumeLayout(false)
		End Sub
		#End Region

		Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
			Dim G As Graphics = E.Graphics
			G.DrawLine(New Pen(SystemColors.ControlDark, 3), 0, 0, 0, Me.Height)
			G.DrawLine(New Pen(SystemColors.ControlDark, 3), 0, 0, Me.Right, 0)
			G.DrawLine(New Pen(SystemColors.ControlLight, 3), 0, Me.Height, Me.Right, Me.Height)
			G.DrawLine(New Pen(SystemColors.ControlLight, 3), Me.Right, 0, Me.Right, Me.Height)
		End Sub

		Protected Overrides Sub OnResize(ByVal e As EventArgs)
			Dim BorderSize As Integer = CInt(Me.Width * 0.1)
			Me.btnToggle.Width = Me.Width - BorderSize
			Me.btnToggle.Height = CInt(Me.Height / 2)
			If Me.mCurrentState = TwoStateOnOffEnum.[On] Then
				Me.btnToggle.Location = New Point(CInt(BorderSize / 2), CInt(BorderSize / 2))
			ElseIf Me.mCurrentState = TwoStateOnOffEnum.[Off] Then
				Me.btnToggle.Location = New Point(CInt(BorderSize / 2), CInt((Me.Height / 2) - BorderSize))
			End If
			Me.Invalidate
		End Sub

		Private Sub ToggleSwitchClick(sender As System.Object, e As System.EventArgs)
			Me.ToggleSwitch
		End Sub
		
		Private Sub BtnToggleClick(sender As System.Object, e As System.EventArgs)
			Me.ToggleSwitch
		End Sub

		Public Sub ToggleSwitch()
			Dim BorderSize As Integer = CInt(Me.Width * 0.1)
			If Me.mCurrentState = TwoStateOnOffEnum.[On] Then
				Me.mCurrentState = TwoStateOnOffEnum.[Off]
				Me.btnToggle.Location = New Point(CInt(BorderSize / 2), CInt((Me.Height / 2) - BorderSize))
			ElseIf Me.mCurrentState = TwoStateOnOffEnum.[Off] Then
				Me.mCurrentState = TwoStateOnOffEnum.[On]
				Me.btnToggle.Location = New Point(CInt(BorderSize / 2), CInt(BorderSize / 2))
			End If
			Me.Invalidate
		End Sub

	End Class
End Namespace
