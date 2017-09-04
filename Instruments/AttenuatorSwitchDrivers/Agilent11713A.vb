'
' Created by SharpDevelop.
' User: rspage
' Date: 6/15/2005
' Time: 1:16 PM
' 

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments



	Public Class Agilent11713A
        Inherits FreeCal.Instruments.AttenuatorSwitchDrivers.AttenuatorSwitchDriver

        Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Integer, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, GetSettingsFromInstrument, Simulate)
		    Me._Manufacturer = "Agilent Technologies"
		    Me._Model = "11713A"
		End Sub

		Protected Overrides Sub SetupSpecifications
		End Sub

		Protected Overrides Sub SetupCapabilities
			Me._CanIdentify = False
		End Sub

		Protected Overrides Sub SetupCommands
	        Me._GeneralCommands.Preset = "*RST"
	        Me._Commands.Agilent11760SHighBandAmplifiedHighLevel = "A12B34567890"
	        Me._Commands.Agilent11760SHighBandHighLevel = "A13B24567890"
	        Me._Commands.Agilent11760SHighBandLowLevel = "A123B4567890"
	        Me._Commands.Agilent11760SLowBandLowLevel = "A23B14567890"
	        Me._Commands.X1On = "A1"
	        Me._Commands.X2On = "A2"
	        Me._Commands.X3On = "A3"
	        Me._Commands.X4On = "A4"
	        Me._Commands.Y5On = "A5"
	        Me._Commands.Y6On = "A6"
	        Me._Commands.Y7On = "A7"
	        Me._Commands.Y8On = "A8"
	        Me._Commands.S9On = "A9"
	        Me._Commands.S0On = "A0"
	        Me._Commands.X1Off = "B1"
	        Me._Commands.X2Off = "B2"
	        Me._Commands.X3Off = "B3"
	        Me._Commands.X4Off = "B4"
	        Me._Commands.Y5Off = "B5"
	        Me._Commands.Y6Off = "B6"
	        Me._Commands.Y7Off = "B7"
	        Me._Commands.Y8Off = "B8"
	        Me._Commands.S9Off = "B9"
	        Me._Commands.S0Off = "B0"
	        Me._Commands.SwitchOn = "A"
	        Me._Commands.switchOff = "B"
		End Sub

	End Class




