'
' Created by SharpDevelop.
' User: rspage
' Date: 7/18/2005
' Time: 8:51 AM
' 



Imports System
Imports System.Windows.Forms
Imports FreeCal.Instruments
Imports System.Drawing

Public Enum InstrumentTypeEnum
    SignalGenerator
    NetworkAnalyzer
    PowerMeter
    SpectrumAnalyzer
End Enum

Public Class InstrumentControl
    Inherits System.Windows.Forms.Control

    Public Event DataSent(ByVal currentInstrument As InstrumentControl, ByVal data As String)
    Public Event DeleteInstrument(ByVal currentInstrument As InstrumentControl)
    Public Event InstrumentClick(ByVal currentInstrument As InstrumentControl)

    Protected WithEvents _Instrument As Instrument
    Protected WithEvents _ContextMenu As ContextMenu
    Protected _Dragging As Boolean = False
    Protected _StartXLocation As Integer
    Protected _StartYLocation As Integer
    Protected _PaintInformation As String
    Protected _InstrumentType As InstrumentTypeEnum
    Protected _IsSelected As Boolean = False

    Public Property IsSelected() As Boolean
        Get
            Return Me._IsSelected
        End Get
        Set(ByVal Value As Boolean)
            Me._IsSelected = Value
        End Set
    End Property

    Public ReadOnly Property InstrumentType() As InstrumentTypeEnum
        Get
            Return Me._InstrumentType
        End Get
    End Property

    Public ReadOnly Property Instrument() As Instrument
        Get
            Return Me._Instrument
        End Get
    End Property

    Public Sub New()
        Me.Size = New Size(50, 50)
        Me._ContextMenu = New ContextMenu
        Dim DeleteMenuItem As New MenuItem("&Delete")
        AddHandler DeleteMenuItem.Click, AddressOf Me.DeleteMenuItemClick
        Me._ContextMenu.MenuItems.Add(DeleteMenuItem)
        Me.ContextMenu = Me._ContextMenu
    End Sub

    Public Sub ShowContextMenu(ByVal location As Point)
        Me._ContextMenu.Show(Me, location)
    End Sub

    Public Sub DeleteMenuItemClick(ByVal sender As Object, ByVal e As EventArgs)
        If CType(sender, MenuItem).Text = "&Delete" Then
            RaiseEvent DeleteInstrument(Me)
        End If
    End Sub

    Protected Overloads Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim FC As Color
        If Me.IsSelected Then
            Me.BackColor = Color.Yellow
            e.Graphics.DrawRectangle(New Pen(Color.Red, 2), Me.ClientRectangle)
            FC = Color.Red
        Else
            Me.BackColor = Color.Red
            FC = Color.Yellow
        End If
        Dim FS As Integer = 7
        Dim StringSize As SizeF = e.Graphics.MeasureString(Me._Instrument.Model & ", " & Me._Instrument.PrimaryAddress, New Font("Comic Sans MS", FS))
        Dim X As Integer = 0
        Dim Y As Integer = 0
        X = Convert.ToInt32((Me.Width - StringSize.Width) / 2)
        e.Graphics.DrawString(Me._Instrument.Model & ", " & Me._Instrument.PrimaryAddress, New Font("Comic Sans MS", FS), New SolidBrush(FC), X, Y)

        StringSize = e.Graphics.MeasureString(Me._PaintInformation, New Font("Comic Sans MS", FS))
        X = Convert.ToInt32((Me.Width - StringSize.Width) / 2)
        Y = Convert.ToInt32(Me.Height - StringSize.Height)
        e.Graphics.DrawString(Me._PaintInformation, New Font("Comic Sans MS", FS), New SolidBrush(FC), X, Y)
    End Sub

    Protected Overloads Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.BringToFront()
        If e.Button = MouseButtons.Right Then
            Me.ShowContextMenu(New Point(e.X, e.Y))
        ElseIf e.Button = MouseButtons.Left Then
            Me._Dragging = True
            Me._StartXLocation = e.X
            Me._StartYLocation = e.Y
        End If
        RaiseEvent InstrumentClick(Me)
    End Sub

    Protected Overloads Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        If Me._Dragging = True Then
            Me.Location = New Point(Me.Location.X + e.X - Me._StartXLocation, Me.Location.Y + e.Y - Me._StartYLocation)
            Me.Refresh()
            MyBase.OnMouseMove(e)
        End If
    End Sub

    Protected Overloads Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        Me._Dragging = False
        MyBase.OnMouseUp(e)
    End Sub

    Protected Overloads Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        Me._Dragging = False
        MyBase.OnMouseLeave(e)
    End Sub

    Public Sub OnInstrumentDataSent(ByVal sender As Instrument, ByVal data As String) Handles _Instrument.DataSent
        RaiseEvent DataSent(Me, data)
    End Sub

End Class

