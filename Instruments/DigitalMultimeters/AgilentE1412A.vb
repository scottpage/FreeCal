'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/28/2005
' Time: 8:49 PM
'

Imports System
Imports FreeCal.Common

Imports FreeCal.Instruments
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ControlChars


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class AgilentE1412A
        Inherits FreeCal.Instruments.DigitalMultimeters.DigitalMultimeter

        Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal secondaryAddress As Byte, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, SecondaryAddress, Simulate)
		    Me._Manufacturer = "Agilent Technologies"
		    Me._Model = "E1412A"
		End Sub

        Public Overrides Sub SetupInstrument
        End Sub

        Protected Overrides Sub SetupCommandTerminators
            Me._CommandTerminators.dBm = "DM"
            Me._CommandTerminators.Hz = "HZ"
            Me._CommandTerminators.KHz = "KZ"
            Me._CommandTerminators.MHz = "MZ"
            Me._CommandTerminators.GHz = "GZ"
        End Sub

			'All voltages as based on Volt
			'All currents is based on Amp
			'All frequency is based on Hz
			'All resistance is based on Ohm
		Protected Overrides Sub SetupTestPoints
			Me._TestPoints.ACVoltTestRanges = New Double(){0.1, 0.1, 0.1, 1, 1, 10, 10, 10, 100, 100, 300, 300}
			Me._TestPoints.ACVoltTestAppliedVoltages = New Double(){0.01, 0.1, 0.1, 1, 1, 10, 10, 10, 100, 100, 300, 300}
			Me._TestPoints.ACVoltTestAppliedFrequencies = New Double(){1000, 1000, 50000, 1000, 50000, 1000, 50000, 10, 1000, 50000, 1000, 50000}
			Me._TestPoints.DCVoltTestRanges = New Double(){0.1, 1, 10, 10, 100, 300}
			Me._TestPoints.DCVoltTestAppliedVoltages = New Double(){0.1, 1, 10, -10, 100, 300}
			Me._TestPoints.ACCurrentTestRanges = New Double(){1, 3}
			Me._TestPoints.ACCurrentTestAppliedCurrents = New Double(){1, 2}
			Me._TestPoints.ACCurrentTestAppliedFrequencies = New Double(){1000, 1000}
			Me._TestPoints.DCCurrentTestRanges = New Double(){0.01, 0.1, 1, 3}
			Me._TestPoints.DCCurrentTestAppliedCurrents = New Double(){0.01, 0.1, 1, 2}
			Me._TestPoints.TwoWireResistanceTestRanges = New Double(){100, 1000, 10000, 100000, 1000000, 10000000, 100000000}
			Me._TestPoints.TwoWireResistanceTestAppliedOhms = New Double(){100, 1000, 10000, 100000, 1000000, 10000000, 100000000}
			Me._TestPoints.FourWireResistanceTestRanges = New Double(){100, 1000, 10000, 100000, 1000000, 10000000, 100000000}
			Me._TestPoints.FourWireResistanceTestAppliedOhms = New Double(){100, 1000, 10000, 100000, 1000000, 10000000, 100000000}
			Me._TestPoints.FrequencyTestRanges = New Double(){0.1, 1}
			Me._TestPoints.FrequencyTestAppliedVoltages = New Double(){0.01, 1}
			Me._TestPoints.FrequencyTestAppliedFrequencies = New Double(){100, 100000}
		End Sub

		Protected Overrides Sub SetupSpecifications
		End Sub

		Protected Overrides Sub SetupCapabilities
			Me._CanIdentify = True
			Me._Capabilities.TwoWireOhms = True
			Me._Capabilities.FourWireOhms = True
			Me._Capabilities.DCVolts = True
			Me._Capabilities.ACVolta = True
			Me._Capabilities.DCCurrent = True
			Me._Capabilities.ACCurrent = True
		End Sub

		Protected Overrides Sub SetupCommands
			Me._GeneralCommands.Identify = "*IDN?"
	        Me._GeneralCommands.Preset = "*RST"
	        Me._Commands.ACCurrentMode = "CONF:CURR:AC"
	        Me._Commands.ACVoltMode = "CONF:VOLT:AC"
	        Me._Commands.DCCurrentMode = "CONF:CURR:DC"
	        Me._Commands.DCVoltMode = "CONF:VOLT:DC"
	        Me._Commands.TwoWireResistanceMode = "CONF:RES"
	        Me._Commands.FourWireResistanceMode = "CONF:FRES"
	        Me._Commands.ACVoltRange = "VOLT:AC:RANG "
	        Me._Commands.DCVoltRange = "VOLT:DC:RANG "
	        Me._Commands.ACAmpRange = "CURR:AC:RANG "
	        Me._Commands.DCAmpRange = "CURR:DC:RANG "
	        Me._Commands.TwoWireResistanceRange = "RES:RANG "
	        Me._Commands.FourWireResistanceRange = "FRES:RANG "
	        Me._Commands.Read = "READ?"
		End Sub

	End Class







