'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/17/2005
' Time: 8:29 PM
'

Imports System
Imports System.ComponentModel
Imports FreeCal.Instruments.SignalGenerators
Imports System.Windows.Forms
Imports System.Drawing
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports Microsoft.VisualBasic.ControlChars



	Public Class SignalGeneratorControl
		Inherits FreeCal.Editor.InstrumentControl

		Public Sub New(ByVal model As String, ByVal primaryAddress As String)
			MyBase.New
			Me._InstrumentType = InstrumentTypeEnum.SignalGenerator
			Select model.ToLower
				Case "anritsumg3696a"
					Me._Instrument = New AnritsuMG3696A(0, primaryAddress, False)
				Case "agilent8340a"
					Me._Instrument = New Agilent8340A(0, primaryAddress, False)
				Case "agilent8340b"
					Me._Instrument = New Agilent8340B(0, primaryAddress, False)
				Case "agilente4433b"
					Me._Instrument = New AgilentE4433B(0, primaryAddress, False)
				Case "agilent83651a"
					Me._Instrument = New Agilent83651A(0, primaryAddress, False)
				Case "agilent8643a"
					Me._Instrument = New Agilent8643A(0, primaryAddress, False)
				Case "agilent8660d"
					Me._Instrument = New Agilent8660D(0, primaryAddress, False)
				Case "agilent8672a"
					Me._Instrument = New Agilent8672A(0, primaryAddress, False)
				Case "ifr2050"
					Me._Instrument = New IFR2050(0, primaryAddress, False)
			End Select
			Dim RFOffMenuItem As New MenuItem("&RF Off")
			Me._ContextMenu.MenuItems.Add(RFOffMenuItem)
			AddHandler RFOffMenuItem.Click, AddressOf Me.RFOffMenuItemClick
			AddHandler CType(Me._Instrument, SignalGenerator).OutputStateChanged, AddressOf Me.OnOutputStateChanged
			AddHandler CType(Me._Instrument, SignalGenerator).AmplitudeLevelChanged, AddressOf Me.OnAmplitudeLevelChanged
			AddHandler CType(Me._Instrument, SignalGenerator).AmplitudeLevelSuffixChanged, AddressOf Me.OnAmplitudeLevelSuffixChanged
			AddHandler CType(Me._Instrument, SignalGenerator).CWFrequencyChanged, AddressOf Me.OnCWFrequencyChanged
			AddHandler CType(Me._Instrument, SignalGenerator).FrequencySuffixChanged, AddressOf Me.OnFrequencySuffixChanged
			Me._PaintInformation = Me.Instrument.Sections.RF.ToString
		End Sub

		Public Shadows ReadOnly Property Instrument As SignalGenerator
			Get
				Return CType(Me._Instrument, SignalGenerator)
			End Get
		End Property

		Public Sub RFOffMenuItemClick(ByVal sender As Object, ByVal e As EventArgs)
			CType(Me._Instrument, SignalGenerator).Sections.RF.OutputState = OnOffStateEnum.[Off]
			Me.Invalidate
		End Sub

		Public Sub OnOutputStateChanged(ByVal state As OnOffStateEnum)
			Me.Invalidate
		End Sub

		Protected Sub OnCWFrequencyChanged(ByVal newfrequency As Double)
			Me.Invalidate
		End Sub

		Protected Sub OnFrequencySuffixChanged(ByVal suffix As FrequencyEnum)
			Me.Invalidate
		End Sub

		Protected Sub OnAmplitudeLevelChanged(ByVal level As Double)
			Me.Invalidate
		End Sub

		Protected Sub OnAmplitudeLevelSuffixChanged(ByVal suffix As AmplitudeEnum)
			Me.Invalidate
		End Sub

	End Class


