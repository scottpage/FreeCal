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
	Public Class Fluke5700A
    Inherits FreeCal.Instruments.MultifunctionCalibrators.MultifunctionCalibrator

        Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal secondaryAddress As Byte, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, SecondaryAddress, Simulate)
		    Me._Manufacturer = "Fluke"
		    Me._Model = "5700A"
		    Me.Sections.Output.State = OnOffStateEnum.[Off]
		    Me.Sections.Output.AmpSuffix = AmplitudeEnum.I
		    Me.Sections.Output.OhmSuffix = AmplitudeEnum.Ohm
		    Me.Sections.Output.VoltSuffix = AmplitudeEnum.V
		    Me.Sections.Output.FrequencySuffix = FrequencyEnum.Hz
		    Me.Sections.Output.Amps = 0
		    Me.Sections.Output.Frequency = 0
		    Me.Sections.Output.Ohms = 0
		    Me.Sections.Output.Volts = 0.001
		End Sub

        Public Overrides Sub SetupInstrument
        End Sub

        Protected Overrides Sub SetupCommandTerminators
        	Me._CommandTerminators.dB = "DB"
            Me._CommandTerminators.dBm = "DBM"
            Me._CommandTerminators.Hz = "HZ"
            Me._CommandTerminators.KHz = "KHZ"
            Me._CommandTerminators.MHz = "MHZ"
            Me._CommandTerminators.GHz = "GHZ"
            Me._CommandTerminators.Percent = "PCT"
            Me._CommandTerminators.Amp = "A"
            Me._CommandTerminators.Volt = "V"
            Me._CommandTerminators.Ohm = "OHM"
        End Sub

		Protected Overrides Sub SetupTestPoints
		End Sub

		Protected Overrides Sub SetupSpecifications
		End Sub

		Protected Overrides Sub SetupCapabilities
			Me._CanIdentify = True
		End Sub

		Protected Overrides Sub SetupCommands
			Me._GeneralCommands.Identify = "*IDN?"
	        Me._GeneralCommands.Preset = "*RST"
	        Me._Commands.OutputParameters = "OUT "
	        Me._Commands.Operate = "OPER"
	        Me._Commands.StandBy = "STBY"
	        Me._Commands.ExternalSenseOn = "EXTSENSE ON"
	        Me._Commands.ExternalSenseOff = "EXTSENSE OFF"
	        Me._Commands.ACOff = "OUT 0 HZ"
		End Sub

	End Class







