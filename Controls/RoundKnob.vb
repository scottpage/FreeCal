'
' Created by SharpDevelop.
' User: rspage
' Date: 5/11/2005
' Time: 6:21 PM
' 
'
'


Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Data
Imports System.Windows.Forms

Namespace FreeCal.Controls

' Delegate type for hooking up ValueChanged notifications. 
Public Delegate Sub ValueChangedEH(ByVal sender As Object)

Public Class RoundKnob
        Inherits System.Windows.Forms.UserControl
	
    Private Utility As CUtility
    Private _Minimum As Integer = 0
    Private _Maximum As Integer = 25
    Private _LargeChange As Integer = 5
    Private _SmallChange As Integer = 1
    Private _ShowSmallScale As Boolean = False
    Private _ShowLargeScale As Boolean = True
    Private _isFocused As Boolean = False
    Private _KnobColor As Color = Me.BackColor
    Private _Value As Integer = 0
    Private isKnobRotating As Boolean = False
    Private rKnob As Rectangle
    Private pKnob As Point
    Private rScale As Rectangle
    Private DottedPen As Pen

    Private bKnob As Brush
    Private bKnobPoint As Brush

    ' declare Off screen image and Offscreen graphics       
    Private OffScreenImage As Image
    Private gOffScreen As Graphics

    ' An event that clients can use to be notified whenever 
    ' the Value is Changed.                                 
    Public Event ValueChanged(ByVal valueChangedEH)

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        KnobControl()
        InitializeComponent()

        ' Knob Control
        Me.ImeMode = System.Windows.Forms.ImeMode.On
        Me.Name = "Knob"
        AddHandler Me.Resize, AddressOf Knob_Resize

    End Sub

    'UserControl1 overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			'
			'KnobControl
			'
			Me.Name = "KnobControl"
		End Sub

#End Region

#Region " Public Properties "


    ' Shows Small Scale marking.
    Public Property ShowSmallScale() As Boolean
        Get
            Return _ShowSmallScale
        End Get
        Set(ByVal value As Boolean)
            _ShowSmallScale = Value
            ' Need to redraw 
            Me.Refresh()
        End Set
    End Property


    ' Shows Large Scale marking
    Public Property ShowLargeScale() As Boolean
        Get
            Return _ShowLargeScale
        End Get
        Set(ByVal value As Boolean)
            _ShowLargeScale = Value
            ' Need to redraw
            Me.Refresh()
        End Set
    End Property


    ' Minimum Value for knob Control
    Public Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            _Minimum = Value
        End Set
    End Property


    ' Maximum value for knob control
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            _Maximum = Value
        End Set
    End Property


    ' value set for large change
    Public Property LargeChange() As Integer
        Get
            Return _LargeChange
        End Get
        Set(ByVal value As Integer)
            _LargeChange = Value
            Me.Refresh()
        End Set
    End Property


    ' value set for small change.
    Public Property SmallChange() As Integer
        Get
            Return _SmallChange
        End Get
        Set(ByVal value As Integer)
            _SmallChange = Value
            Me.Refresh()
        End Set
    End Property

    ' Current Value of knob control
    Public Property Value() As Integer
        Get
            Return _Value
        End Get
        Set(ByVal value As Integer)
            _Value = Value
            ' Call delegate  
            OnValueChanged(Me.Value)
            Me.Refresh()
        End Set
    End Property

    ' Set Color of knob control
    Public Property KnobColor() As Color
        Get
            Return _KnobColor
        End Get
        Set(ByVal value As Color)
            _KnobColor = Value
            'Refresh Colors
            Me.Refresh()
        End Set
    End Property

#End Region

    Protected Function OnValueChanged(ByVal sender As Object)
        RaiseEvent ValueChanged(sender)
    End Function

    Public Sub KnobControl()
        Utility = New CUtility()
        DottedPen = New Pen(Utility.getDarkColor(Me.BackColor, 40))
        DottedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot
        DottedPen.DashCap = System.Drawing.Drawing2D.DashCap.Round
        setDimensions()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' create LinearGradientBrush for creating knob            
        bKnob = New System.Drawing.Drawing2D.LinearGradientBrush( _
                rKnob, Utility.getLightColor(KnobColor, 55), _
                Utility.getDarkColor(KnobColor, 55), _
                LinearGradientMode.ForwardDiagonal)
        ' create LinearGradientBrush for knobPoint                
        bKnobPoint = New System.Drawing.Drawing2D.LinearGradientBrush( _
                         rKnob, Utility.getLightColor(Me.BackColor, 55), _
                         Utility.getDarkColor(MyBase.BackColor, 55), _
                         LinearGradientMode.ForwardDiagonal)

        ' Set background color of Image...            
        gOffScreen.Clear(Me.BackColor)
        ' Fill knob Background to give knob effect....
        gOffScreen.FillEllipse(bKnob, rKnob)
        ' Set antialias effect on                     
        gOffScreen.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias
        ' Draw border of knob                         
        gOffScreen.DrawEllipse(New Pen(Me.BackColor), rKnob)

        'if control is focused 
        If (Me._isFocused) Then
            gOffScreen.DrawEllipse(DottedPen, rKnob)
        End If
        ' get current position of pointer             
        Dim Arrow As Point = Me.getKnobPosition()
        ' Draw pointer arrow that shows knob position 
        Utility.DrawInsetCircle(gOffScreen, New Rectangle(Arrow.X - 3, Arrow.Y - 3, 6, 6), New Pen(Me.BackColor))

        '  Draw small and large scale                  
        Dim i As Integer = Minimum
        If (Me._ShowSmallScale) Then
            For i = Minimum To Maximum
                gOffScreen.DrawLine(New Pen(Me.ForeColor), getMarkerPoint(0, i), getMarkerPoint(3, i))
            Next
        End If

        If (Me._ShowLargeScale) Then
            For i = Minimum To Maximum
                gOffScreen.DrawLine(New Pen(Me.ForeColor), getMarkerPoint(0, i), getMarkerPoint(5, i))
            Next
        End If

        ' Drawimage on screen                    
        g.DrawImage(OffScreenImage, 0, 0)
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
        ' Empty To avoid Flickering due do background Drawing
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If (Utility.isPointinRectangle(New Point(e.X, e.Y), rKnob)) Then
            ' Start Rotation of knob         
            Me.isKnobRotating = True
        End If
    End Sub

    ' ----------------------------------------------------------
    ' we need to override IsInputKey method to allow user to   
    ' use up, down, right and bottom keys other wise using me
    ' keys will change focus from current object to another    
    ' object on the form                                       
    ' ----------------------------------------------------------
    Protected Overrides Function IsInputKey(ByVal key As Keys) As Boolean
        Select Case key
            Case Keys.Up, Keys.Down, Keys.Right, Keys.Left
                Return True
            Case Else
                Return False
        End Select
        Return MyBase.IsInputKey(key)
    End Function

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ' Stop rotation                   
        Me.isKnobRotating = False
        If (Utility.isPointinRectangle(New Point(e.X, e.Y), rKnob)) Then
            ' get value                   
            Me.Value = Me.getValueFromPosition(New Point(e.X, e.Y))
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        ' --------------------------------------
        '  Following Handles Knob Rotating     
        ' --------------------------------------
        If (Me.isKnobRotating = True) Then
            Me.Cursor = Cursors.Hand
            Dim p As Point = New Point(e.X, e.Y)
            Dim posVal As Integer = Me.getValueFromPosition(p)
            Value = posVal
        End If
    End Sub

    Protected Overrides Sub OnEnter(ByVal e As EventArgs)
        Me._isFocused = True
        Me.Refresh()
        MyBase.OnEnter(New EventArgs())
    End Sub

    Protected Overrides Sub OnLeave(ByVal e As EventArgs)
        Me._isFocused = False
        Me.Refresh()
        MyBase.OnLeave(New EventArgs())
    End Sub

    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
        ' --------------------------------------------------------
        ' Handles knob rotation with up,down,left and right keys 
        ' --------------------------------------------------------
        If (e.KeyCode = Keys.Up Or e.KeyCode = Keys.Right) Then
            If (_Value < Maximum) Then
                Value = _Value + 1
                Me.Refresh()
            End If
        ElseIf (e.KeyCode = Keys.Down Or e.KeyCode = Keys.Left) Then
            If (_Value > Minimum) Then
                Value = _Value - 1
                Me.Refresh()
            End If
        End If
    End Sub

    Private Sub setDimensions()
        ' get smaller from height and width
        Dim size As Integer = Me.Width
        If (Me.Width > Me.Height) Then
            size = Me.Height
        End If
        ' allow 10% gap on all side to determine size of knob    
        Me.rKnob = New Rectangle((size * 0.1), (size * 0.1), (size * 0.8), (size * 0.8))
        Me.rScale = New Rectangle(2, 2, size - 4, size - 4)
        Me.pKnob = New Point(rKnob.X + rKnob.Width / 2, rKnob.Y + rKnob.Height / 2)
        ' create offscreen image                                 
        Me.OffScreenImage = New Bitmap(Me.Width, Me.Height)
        ' create offscreen graphics                              
        Me.gOffScreen = Graphics.FromImage(OffScreenImage)
    End Sub

    Private Sub Knob_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
        setDimensions()
        Refresh()
    End Sub


    ' gets knob position that is to be drawn on control.
    Private Function getKnobPosition() As Point
        Dim degree As Double = 270 * Me.Value / (Me.Maximum - Me.Minimum)
        degree = (degree + 135) * Math.PI / 180

        Dim Pos As Point = (New Point(0, 0))
        Pos.X = ((Math.Cos(degree) * (rKnob.Width / 2 - 10) + rKnob.X + rKnob.Width / 2))
        Pos.Y = ((Math.Sin(degree) * (rKnob.Width / 2 - 10) + rKnob.Y + rKnob.Height / 2))
        Return Pos
    End Function


    ' gets marker point required to draw scale marker.
    ' <param name="length">distance from center</param>
    ' <param name="Value">value that is to be marked</param>
    ' <returns>Point that describes marker position</returns>
    Private Function getMarkerPoint(ByVal length As Integer, ByVal value As Integer) As Point
        Dim degree As Double = 270 * Value / (Me.Maximum - Me.Minimum)
        degree = (degree + 135) * Math.PI / 180

        Dim Pos As Point = New Point(0, 0)
        Pos.X = (Math.Cos(degree) * (rKnob.Width / 2 - length + 7) + rKnob.X + rKnob.Width / 2)
        Pos.Y = (Math.Sin(degree) * (rKnob.Width / 2 - length + 7) + rKnob.Y + rKnob.Height / 2)
        Return Pos
    End Function


    ' converts geomatrical position in to value..
    ' <param name="p">Point that is to be converted</param>
    ' <returns>Value derived from position</returns>
    Private Function getValueFromPosition(ByVal p As Point) As Integer
        Dim degree As Double = 0.0
        Dim v As Integer = 0
        If (p.X <= pKnob.X) Then
            degree = (pKnob.Y - p.Y) / (pKnob.X - p.X)
            degree = Math.Atan(degree)
            degree = (degree) * (180 / Math.PI) + 45
            v = CInt((degree * (Me.Maximum - Me.Minimum) / 270))
        ElseIf (p.X > pKnob.X) Then
            degree = (p.Y - pKnob.Y) / (p.X - pKnob.X)
            degree = Math.Atan(degree)
            degree = 225 + (degree) * (180 / Math.PI)
            v = (degree * (Me.Maximum - Me.Minimum) / 270)
        End If

        If (v > Maximum) Then v = Maximum
        If (v < Minimum) Then v = Minimum
        Return v
    End Function

End Class

Public Class CUtility

    Public Function getDarkColor(ByVal c As Color, ByVal d As Byte) As Color
        Dim r As Byte = 0
        Dim g As Byte = 0
        Dim b As Byte = 0

        If (c.R > d) Then r = (c.R - d)
        If (c.G > d) Then g = (c.G - d)
        If (c.B > d) Then b = (c.B - d)

        Dim c1 As Color = Color.FromArgb(r, g, b)
        Return c1
    End Function

    Public Function getLightColor(ByVal c As Color, ByVal d As Byte) As Color
        Dim r As Byte = 255
        Dim g As Byte = 255
        Dim b As Byte = 255

        If (CInt(c.R) + CInt(d) <= 255) Then r = (c.R + d)
        If (CInt(c.G) + CInt(d) <= 255) Then g = (c.G + d)
        If (CInt(c.B) + CInt(d) <= 255) Then b = (c.B + d)

        Dim c2 As Color = Color.FromArgb(r, g, b)
        Return c2
    End Function

    ' Method which checks is particular point is in rectangle
    ' <param name="p">Point to be Chaecked</param>
    ' <param name="r">Rectangle</param>
    ' <returns>true is Point is in rectangle, else false</returns>
    Public Function isPointinRectangle(ByVal p As Point, ByVal r As Rectangle) As Boolean
        Dim flag As Boolean = False
        If (p.X > r.X And p.X < r.X + r.Width And p.Y > r.Y And p.Y < r.Y + r.Height) Then
            flag = True
        End If
        Return flag
    End Function

    Public Sub DrawInsetCircle(ByRef g As Graphics, ByRef r As Rectangle, ByVal p As Pen)
        Dim i As Integer
        Dim p1 As Pen = New Pen(getDarkColor(p.Color, 50))
        Dim p2 As Pen = New Pen(getLightColor(p.Color, 50))

        For i = 0 To p.Width
            Dim r1 As Rectangle = New Rectangle(r.X + i, r.Y + i, r.Width - i * 2, r.Height - i * 2)
            g.DrawArc(p2, r1, -45, 180)
            g.DrawArc(p1, r1, 135, 180)
        Next
    End Sub

End Class
End NameSpace
