'
' Created by SharpDevelop.
' User: rspage
' Date: 5/7/2005
' Time: 2:01 PM
' 
'
'

Imports System.ComponentModel
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Design
Imports System.Drawing.Text
Imports System.Windows.Forms

Namespace FreeCal.Controls

	Public Enum TwoStateOnOffEnum
		[On]
		[Off]
	End Enum

	Public Class TwoStateLED
		Inherits System.Windows.Forms.Control

		Public Event Toggle(ByVal currentState As TwoStateOnOffEnum)

		Private mOnColor As Color = Color.Green
		Private mOffColor As Color = Color.Red
		Private mCurrentColor As Color = Me.mOnColor
		Private mCurrentState As TwoStateOnOffEnum = TwoStateOnOffEnum.[On]

		Public Property OnColor As Color
			Get
				Return Me.mOnColor
			End Get
			Set
				Me.mOnColor = Value
				Me.Invalidate
			End Set
		End Property

		Public Property OffColor As Color
			Get
				Return Me.mOffColor
			End Get
			Set
				Me.mOffColor = Value
				Me.Invalidate
			End Set
		End Property

		Public Property CurrentState As TwoStateOnOffEnum
			Get
				Return Me.mCurrentState
			End Get
			Set
				Me.mCurrentState = Value
				Me.Invalidate
			End Set
		End Property

		Public Sub New()
			MyBase.New()
			Me.ResizeRedraw = True
			Me.Height = 50
			Me.Width = 50
		End Sub

		Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
			Dim G As Graphics = pe.Graphics
			If Me.mCurrentState = TwoStateOnOffEnum.[On] Then
				Me.mCurrentColor = Me.mOnColor
			ElseIf Me.mCurrentState = TwoStateOnOffEnum.[Off] Then
				Me.mCurrentColor = Me.mOffColor
			End If
			Dim LEDOuterEllipsePath As New GraphicsPath
			LEDOuterEllipsePath.AddEllipse(0, 0, Me.Width, Me.Height)
			G.FillPath(New SolidBrush(Me.mCurrentColor), LEDOuterEllipsePath)
			Dim LEDGradientPath As New GraphicsPath
			LEDGradientPath.AddEllipse(CInt(Me.Width * 0.15), CInt(Me.Height * 0.15), CInt(Me.Width - (Me.Width * 0.3)), CInt(Me.Height - (Me.Height * 0.3)))
			Dim LEDBrush As New PathGradientBrush(LEDGradientPath)
			LEDBrush.CenterColor = Color.WhiteSmoke
			Dim LEDOuterGradientColors() As Color = {Me.mCurrentColor}
			LEDBrush.SurroundColors = LEDOuterGradientColors
			G.FillPath(LEDBrush, LEDGradientPath)
			Me.Region = New Region(LEDOuterEllipsePath)
			G.DrawEllipse(New Pen(Color.Black, CInt(Me.Width * 0.05)), New Rectangle(0, 0, Me.Width, Me.Height))
		End Sub

		Protected Overrides Sub OnClick(ByVal e As EventArgs)
			If Me.mCurrentState = TwoStateOnOffEnum.[On] Then
				Me.mCurrentState = TwoStateOnOffEnum.[Off]
				RaiseEvent Toggle(Me.mCurrentState)
				Me.Invalidate
			ElseIf Me.mCurrentState = TwoStateOnOffEnum.[Off] Then
				Me.mCurrentState = TwoStateOnOffEnum.[On]
				RaiseEvent Toggle(Me.mCurrentState)
				Me.Invalidate
			End If
		End Sub

		Public Sub ToggleState()
			If Me.mCurrentState = TwoStateOnOffEnum.[On] Then
				Me.mCurrentState = TwoStateOnOffEnum.[Off]
				RaiseEvent Toggle(Me.mCurrentState)
				Me.Invalidate
			ElseIf Me.mCurrentState = TwoStateOnOffEnum.[Off] Then
				Me.mCurrentState = TwoStateOnOffEnum.[On]
				RaiseEvent Toggle(Me.mCurrentState)
				Me.Invalidate
			End If
		End Sub

	End Class
End Namespace
