'
' Created by SharpDevelop.
' User: rspage
' Date: 7/21/2005
' Time: 10:10 AM
' 

Imports System
Imports System.ComponentModel
Imports FreeCal.Instruments.PowerMeters
Imports System.Windows.Forms
Imports System.Drawing
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports Microsoft.VisualBasic.ControlChars
Imports System.Threading



	Public Class PowerMeterControl
		Inherits FreeCal.Editor.InstrumentControl

		Protected _Zeroing As Boolean = False

		Public Sub New(ByVal model As String, ByVal primaryAddress As String)
			MyBase.New
			Me._InstrumentType = InstrumentTypeEnum.PowerMeter
			Select model.ToLower
				Case "agilente4417a"
					Me._Instrument = New AgilentE4417A(0, primaryAddress, False)
			End Select
			Dim ZeroAMenuItem As New MenuItem("&Zero A")
			Me._ContextMenu.MenuItems.Add(ZeroAMenuItem)
			AddHandler ZeroAMenuItem.Click, AddressOf Me.ZeroAMenuItemClick
			Me._PaintInformation = Me._Instrument.ToString
		End Sub

		Public Shadows ReadOnly Property Instrument As PowerMeter
			Get
				Return CType(Me._Instrument, PowerMeter)
			End Get
		End Property

		Protected Sub ZeroAMenuItemClick(ByVal sender As Object, ByVal e As EventArgs)
			If Not Me._Zeroing Then
				Dim T As New Thread(New ThreadStart(AddressOf Me.ZeroMeter))
				Me._Zeroing = True
				T.Start
			Else
				MessageBox.Show("The meter is currently zeroing, try again after it completes.")
			End If
		End Sub

		Protected Sub ZeroMeter
			Me.Instrument.Sections.Calibration.Zero("A", False)
			Me._Zeroing = False
			MessageBox.Show("Zero completed successfully!")
		End Sub

	End Class




