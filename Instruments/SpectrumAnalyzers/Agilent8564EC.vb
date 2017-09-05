'
' Created by SharpDevelop.
' User: rspage
' Date: 4/15/2005
' Time: 12:08 PM
' 


Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports System.ComponentModel

	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class Agilent8564EC
        Inherits FreeCal.Instruments.SpectrumAnalyzers.SpectrumAnalyzer

        Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, GetSettingsFromInstrument, Simulate)
		    Me._Model = "8564EC"
		    Me._Manufacturer = "Agilent Technologies"
		End Sub

        Protected Overrides Sub SetupCommandTerminators
            Me._CommandTerminators.dBm = " DB"
        End Sub

		Protected Overrides Sub SetupCommands
			Me._GeneralCommands.Identify = "*IDN?;"
	        Me._GeneralCommands.Preset = "IP;"
			Me._Commands.SetReferenceLevel = "RL "
			Me._Commands.SetCenterFrequency = "CF "
			Me._Commands.SetStartFrequency = "FA "
			Me._Commands.SetStopFrequency = "FB "
			Me._Commands.SetSpanWidth = "SP "
			Me._Commands.SetWaitForSweepThenExecuteNextCommand = "TS;"
			Me._Commands.SetPeakSearchHigh = "MKPK HI;"
			Me._Commands.SetReferenceLevelToMarker = "MKRL;"
			Me._Commands.SetDeltaMarker = "MKD;"
			Me._Commands.GetMarkerA = "MKA?;"
			Me._Commands.SetMarkerPosition = "MKN "
			Me._Commands.GetMarkerAmplitude = "MKA?;"
			Me._Commands.GetCenterFrequency = "CF?;"
			Me._Commands.GetStartFrequency = "FA?;"
			Me._Commands.GetStopFrequency = "FB?;"
			Me._Commands.GetSpanWidth = "SP?;"
		End Sub

		Protected Overrides Sub SetupCapabilities
			Me._Capabilities.FundamentalFrequencySuffix = FrequencyEnum.Hz
			Me._Capabilities.MinimumFrequency = 9
			Me._Capabilities.MinimumFrequencyMultiplier = FrequencyEnum.KHz
			Me._Capabilities.MaximumFrequency = 40
			Me._Capabilities.MaximumFrequencyMultiplier = FrequencyEnum.GHz
		End Sub

	End Class


