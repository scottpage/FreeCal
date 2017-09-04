'
' Created by SharpDevelop.
' User: rspage
' Date: 6/9/2005
' Time: 1:12 PM
' 

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports Microsoft.VisualBasic.ControlChars
Imports System.Windows.Forms
Imports System.ComponentModel

	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class Agilent8566B
        Inherits FreeCal.Instruments.SpectrumAnalyzers.SpectrumAnalyzer

        Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Integer, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, GetSettingsFromInstrument, Simulate)
		    Me._Model = "8566B"
		    Me._Manufacturer = "Agilent Technologies"
		End Sub

        Protected Overrides Sub SetupCommandTerminators
            Me._CommandTerminators.dBm = " DB"
            Me._CommandTerminators.KHz = " KZ"
            Me._CommandTerminators.MHz = " MZ"
            Me._CommandTerminators.GHz = " GZ"
            Me._CommandTerminators.Second = " SC"
        End Sub

		Protected Overrides Sub SetupTestPoints
			Dim CenterFrequencyReadoutAccuracyTestFrequenciesList() As Double = {2000, 3000, 6000, 9000, 12000, 15000, 18000}
			Me._TestPoints.CenterFrequencyReadoutAccuracyTestFrequencies = CenterFrequencyReadoutAccuracyTestFrequenciesList
			Dim CenterFrequencyReadoutAccuracyTestSpanWidthsList() As Double = {1, 10, 100, 1000}
			Me._TestPoints.CenterFrequencyReadoutAccuracyTestSpanWidths = CenterFrequencyReadoutAccuracyTestSpanWidthsList
			Dim FrequencySpanAccuracyTestCenterFrequenciesList() As Double = {40, 4000, 10000, 15000, 20000}
			Me._TestPoints.FrequencySpanAccuracyTestCenterFrequencies = FrequencySpanAccuracyTestCenterFrequenciesList
			Dim LowFrequencySpanAccuracyTestSpanWidthsList() As Double = {0.02, 0.05, 0.15, 0.2, 1, 2, 6, 10, 50}
			Me._TestPoints.LowFrequencySpanAccuracyTestSpanWidths = LowFrequencySpanAccuracyTestSpanWidthsList
			Dim HighFrequencySpanAccuracyTestSpanWidthsList() As Double = {500, 1000, 5000, 10000}
			Me._TestPoints.HighFrequencySpanAccuracyTestSpanWidths = HighFrequencySpanAccuracyTestSpanWidthsList		
			Me._TestPoints.FrequencySpanAccuracyTestLowToHighTolerancePoint = 5
			Dim ResolutionBandWidthAccuracyTestResolutionBandWidthsList() As SpectrumAnalyzerResolutionBandwidthEnum = {SpectrumAnalyzerResolutionBandwidthEnum.ThreeMHz, SpectrumAnalyzerResolutionBandwidthEnum.OneMHz, SpectrumAnalyzerResolutionBandwidthEnum.ThreeHundredKHz, SpectrumAnalyzerResolutionBandwidthEnum.OneHundredKHz, SpectrumAnalyzerResolutionBandwidthEnum.ThirtyKHz, SpectrumAnalyzerResolutionBandwidthEnum.TenKHz, SpectrumAnalyzerResolutionBandwidthEnum.ThreeKHz, SpectrumAnalyzerResolutionBandwidthEnum.OneKHz, SpectrumAnalyzerResolutionBandwidthEnum.ThreeHundredHz, SpectrumAnalyzerResolutionBandwidthEnum.OneHundredHz, SpectrumAnalyzerResolutionBandwidthEnum.ThirtyHz, SpectrumAnalyzerResolutionBandwidthEnum.TenHz}
			Me._TestPoints.ResolutionBandWidthAccuracyTestResolutionBandWidths = ResolutionBandWidthAccuracyTestResolutionBandWidthsList
			Dim ResolutionBandWidthAccuracyTestSpanWidthsList() As Double = {5, 2, 0.5, 0.2, 0.05, 0.02, 0.005, 0.002, 0.0005, 0.0002, 0.0001, 0.0001}
			Me._TestPoints.ResolutionBandWidthAccuracyTestSpanWidths = ResolutionBandWidthAccuracyTestSpanWidthsList
		End Sub

		Protected Overrides Sub SetupSpecifications
			Me._Specifications.CenterFrequencyReadoutAccuracyTolernace = 0.00000000002
			Me._Specifications.LowFrequencySpanAccuracyTolerance = 0.01
			Me._Specifications.HighFrequencySpanAccuracyTolerance = 0.03
		End Sub

		Protected Overrides Sub SetupCapabilities
			Me._CanIdentify = True
			Me._Capabilities.NumberOfFrequencyBands = 4
			Me._Capabilities.ReferenceOscillatorFrequency = 10
			Me._Capabilities.ReferenceOscillatorFrequencyMultiplier = FrequencyEnum.MHz
		End Sub

		Protected Overrides Sub SetupCommands
			Me._GeneralCommands.Identify = "*IDN?"
	        Me._GeneralCommands.Preset = "IP;"

			Me._Commands.SetReferenceLevel = "RL "

			Me._Commands.SetCenterFrequency = "CF "
			Me._Commands.SetStartFrequency = "FA "
			Me._Commands.SetStopFrequency = "FB "
			Me._Commands.SetSpanWidth = "SP "
			Me._Commands.SetSweepTime = "ST "

			Me._Commands.SetWaitForSweepThenExecuteNextCommand = "TS;"
			Me._Commands.SetPeakSearchHigh = "MKPK HI;"
			Me._Commands.SetReferenceLevelToMarker = "MKRL;"
			Me._Commands.SetDeltaMarker = "MKD;"
			Me._Commands.GetMarkerA = "MKA?"
			Me._Commands.SetMarkerPosition = "MKN "
			Me._Commands.RecallStateNumber = "RCLS "
			Me._Commands.SetReadoutToFrequency = "MKREAD FRQ;"
			Me._Commands.GetFrequencyReadOut = "MF?"
			Me._Commands.SetResolutionBandwidth = "RB "
			Me._Commands.SetScaleToLinear = "LN;"
			Me._Commands.SetScaleToLog = "LG;"
			Me._Commands.GetMarkerAmplitude = "MKA?"
			Me._Commands.SetdBMAmplitudeUnits = "MKTYPE AMP;"
		End Sub

		Public Overrides Sub Calibrate
			MessageBox.Show("Connect CAL OUTPUT to RF INPUT.")
			Me.Preset
			Me.RecallState(Agilent8566BInstrumentStateEnum.Nine)
			Messagebox.Show("Adjust FREQ ZERO for maximum amplitude trace.")
			Me.Preset
		End Sub

		Public Sub RecallState(ByVal state As Agilent8566BInstrumentStateEnum)
			Me.Write(Me.Commands.RecallStateNumber & State & Me.CommandTerminators.MultipleCommandSeperator)
		End Sub

	End Class

	Public Enum Agilent8566BInstrumentStateEnum
		ZeroToTwoPointFiveGHz = 1
		TwoToTwentyTwoGHz = 2
		One = 1
		Two = 2
		Three = 3
		Nine = 9
	End Enum




