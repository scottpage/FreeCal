'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/11/2005
' Time: 11:19 AM
' 

Imports System
Imports FreeCal.Common
Imports System.Environment
Imports NationalInstruments
Imports NationalInstruments.NI4882
Imports System.Windows.Forms



	Public Class Agilent8903B
    Inherits AudioAnalyzer

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
        Me._Manufacturer = "Agilent Technologies"
        Me._Model = "8903B"
    End Sub

    Protected Overrides Sub SetupCommandTerminators
            Me._CommandTerminators.dBm = "DB"
            Me._CommandTerminators.KHz = "KZ"
            Me._CommandTerminators.Volt = "VL"
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
	        Me._GeneralCommands.Preset = "IP"
	        Me._Commands.SetSourceFrequency = "FR"
	        Me._Commands.SetSourceStartFrequency = "FA"
	        Me._Commands.SetSourceStopFrequency = "FB"
	        Me._Commands.SetSourceAmplitude = "AP"
	        Me._Commands.SetSourceFrequencyIncrement = "FN"
	        Me._Commands.SetSourceAmplitudeIncrement = "AN"
	        Me._Commands.SetPlotLimit = "PL"
	        Me._Commands.SweepOn = "W1"
	        Me._Commands.SweepOff = "W0"
	        Me._Commands.MeasureACLevel = "M1"
	        Me._Commands.MeasureDCLevel = "S1"
	        Me._Commands.MeasureDistortion = "M3"
	        Me._Commands.MeasureDistortionLevel = "S3"
	        Me._Commands.MeasureSignalToNoise = "S2"
	        Me._Commands.MeasureSINAD = "M2"
	        Me._Commands.SetAllLowPassFiltersOff = "L0"
	        Me._Commands.SetThirtyKHzLowPassFilter = "L1"
	        Me._Commands.SetEightyKHzLowPassFilter = "L2"
	        Me._Commands.TriggerWithSettling = "T3"
		End Sub

	End Class





