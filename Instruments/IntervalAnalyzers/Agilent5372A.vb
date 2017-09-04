'
' Created by SharpDevelop.
' User: rspage
' Date: 7/25/2005
' Time: 3:06 PM
' 

Imports System.ComponentModel
Imports Microsoft.VisualBasic.ControlChars


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class Agilent5372A
    Inherits IntervalAnalyzer

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
        Me._Manufacturer = "Agilent Technologies"
        Me._Model = "5372A"
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

		Protected Overrides Sub SetupTestPoints
		End Sub

		Protected Overrides Sub SetupSpecifications
		End Sub

		Protected Overrides Sub SetupCapabilities
			Me._CanIdentify = True
			Me._Capabilities.ReferenceOscillatorFrequency = 10
			Me._Capabilities.ReferenceOscillatorFrequencySuffix = FrequencyEnum.MHz
		End Sub

		Protected Overrides Sub SetupCommands
			Me._GeneralCommands.Identify = "*IDN?"
	        Me._GeneralCommands.Preset = "PRES"
	        Me._Commands.SetInterfaceOutputToASCII = "INT;OUTPUT ASCII"
	        Me._Commands.SetInterfaceOutputToBinary = "INT;OUTPUT BINARY"
	        Me._Commands.SetInterfaceOutputToFloatingPoint = "INT;OUTPUT FPOINT"
	        Me._Commands.SetMeasurementFunctionToFrequency = "MEAS;FUNC FREQ"
	        Me._Commands.SetMeasurementSourceToA = "MEAS;SOUR A"
	        Me._Commands.SetSourceAManualTrigger = "INP;SOUR A;TRIG,MAN"
	        Me._Commands.SetSourceATriggerLevelTo0Volts = "INP;SOUR A;LEV 0"
	        Me._Commands.SetMeasurementArmingToISampling = "MEAS;ARM ISAM"
	        Me._Commands.SetSourceAStatisticsOn = "PROC;SOUR A;STAT ON"
	        Me._Commands.SetMeasurementReadySRQMask = "*SRE 16"
		End Sub

		Public Overrides Overloads Sub Write(ByVal data As String)
			MyBase.Write(data & NewLine)
		End Sub

	End Class






