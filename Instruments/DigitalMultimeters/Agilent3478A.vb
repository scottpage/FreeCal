'
' Created by SharpDevelop.
' User: rspage
' Date: 7/29/2005
' Time: 11:07 AM
' 

Imports System
Imports FreeCal.Common

Imports FreeCal.Instruments
Imports System.ComponentModel
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.ControlChars
Imports System.Windows.Forms


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class Agilent3478A
        Inherits FreeCal.Instruments.DigitalMultimeters.DigitalMultimeter

        Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal secondaryAddress As Byte, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, SecondaryAddress, Simulate)
		    Me._Manufacturer = "Agilent Technologies"
		    Me._Model = "3478A"
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
	        Me._Commands.ACVoltMode = "F2"
	        Me._Commands.DCCurrentMode = "CONF:CURR:DC"
	        Me._Commands.DCVoltMode = "F1"
	        Me._Commands.TwoWireResistanceMode = "CONF:RES"
	        Me._Commands.FourWireResistanceMode = "CONF:FRES"
	        Me._Commands.ACVoltRange = "R"
	        Me._Commands.DCVoltRange = "R"
	        Me._Commands.ACAmpRange = "R"
	        Me._Commands.DCAmpRange = "R"
	        Me._Commands.TwoWireResistanceRange = "R"
	        Me._Commands.FourWireResistanceRange = "R"
	        Me._Commands.Read = "?"
		End Sub

		Protected Friend Overrides Overloads Sub SetDCVoltageRange(ByVal setting As Double)
			If Not Me.Sections.Configure.Mode = DigitalMultimeterModeEnum.DCVolts Then
				Me.Sections.Configure.Mode = DigitalMultimeterModeEnum.DCVolts
			End If
			Me.Sections.Configure.DC._VoltRange = setting
			If (setting <= 300 And setting > 30)
				Me.Write(Me._Commands.DCVoltRange & 2)
			ElseIf (setting <= 30 And setting > 3)
				Me.Write(Me._Commands.DCVoltRange & 1)
			ElseIf (setting <= 3 And setting > 0.3)
				Me.Write(Me._Commands.DCVoltRange & 0)
			End If
		End Sub

		Public Overrides Overloads Sub Write(ByVal data As String)
			MyBase.Write(data & NewLine)
		End Sub

	End Class


