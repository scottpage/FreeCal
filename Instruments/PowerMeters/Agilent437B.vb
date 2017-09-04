'
' Created by SharpDevelop.
' User: rspage
' Date: 5/2/2005
' Time: 10:03 PM
'
'
Imports System
Imports System.Windows.Forms
Imports FreeCal.Common
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ControlChars



	Public Class Agilent437B
        Inherits FreeCal.Instruments.PowerMeters.PowerMeter

		Protected _PowerSensorModelNumber As String
		Protected _PowerSensorSerialNumber As String

		Public Property PowerSensorModelNumber As String
			Get
				Return Me._PowerSensorModelNumber
			End Get
			Set
				Me._PowerSensorModelNumber = Value
			End Set
		End Property

		Public Property PowerSensorSerialNumber As String
			Get
				Return Me._PowerSensorSerialNumber
			End Get
			Set
				Me._PowerSensorSerialNumber = Value
			End Set
		End Property

        Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Integer, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, GetSettingsFromInstrument, Simulate)
		    Me._Model = "437B"
		    Me._Manufacturer = "Agilent Technologies"
		End Sub

        Protected Overrides Sub SetupCommandTerminators
        	Me._CommandTerminators.KHz = "KZ"
        	Me._CommandTerminators.MHz = "MZ"
        	Me._CommandTerminators.GHz = "GZ"
        	Me._CommandTerminators.Percent = "%"
        	Me._CommandTerminators.MultipleCommandSeperator = "EN;"
        End Sub

		Protected Overrides Sub SetupCommands
			Me._GeneralCommands.Identify = "*IDN?"
	        Me._GeneralCommands.Preset = "*RST"
	        Me._Commands.Measure = "?"
	        Me._Commands.Calibrate = "CAL"
	        Me._Commands.SetFrequency = "FR"
		End Sub

	End Class

