'
' Created by SharpDevelop.
' User: rspage
' Date: 6/8/2005
' Time: 11:43 AM
' 

Imports System
Imports FreeCal.Common
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.ControlChars
Imports System.ComponentModel



	#Region "Enums"

	#End Region
	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public MustInherit Class SpectrumAnalyzer
        Inherits FreeCal.Instruments.Instrument

		#Region "Declarations"

        Protected _Commands As SpectrumAnalyzerGPIBCommands
        Protected _Specifications As SpectrumAnalyzerSpecifications
        Protected _Capabilities As SpectrumAnalyzerCapabilities
        Protected _TestPoints As SpectrumAnalyzerTestPoints

		Protected _Sections As New SpectrumAnalyzerSectionsSection(Me)

		Protected _Scale As SpectrumAnalyzerScaleEnum

		#End Region

		#Region "Properties"

		Public Shadows ReadOnly Property Sections As SpectrumAnalyzerSectionsSection
			Get
				Return Me._Sections
			End Get
		End Property

		Public Property Scale As SpectrumAnalyzerScaleEnum
			Get
				Return Me._Scale
			End Get
			Set
				Me._Scale = Value
				If Value = SpectrumAnalyzerScaleEnum.Linear Then
					Me.Write(Me.Commands.SetScaleToLinear)
				Else
					Me.Write(Me.Commands.SetScaleToLog)
				End If
			End Set
		End Property

		Public ReadOnly Property TestPoints As SpectrumAnalyzerTestPoints
			Get
				Return Me._TestPoints
			End Get
		End Property

		Public ReadOnly Property Commands As SpectrumAnalyzerGPIBCommands
			Get
				Return Me._Commands
			End Get
		End Property

		Public ReadOnly Property Specifications As SpectrumAnalyzerSpecifications
			Get
				Return Me._Specifications
			End Get
		End Property

		Public ReadOnly Property Capabilities As SpectrumAnalyzerCapabilities
			Get
				Return Me._Capabilities
			End Get
		End Property

		Public ReadOnly Property FrequencyReadout As Double
			Get
				Me.Write(Me.Commands.GetFrequencyReadout)
				Return Me.ReadDouble / 1000000
			End Get
		End Property

		#End Region

		#Region "Methods"

        Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, GetSettingsFromInstrument, Simulate)
		End Sub

		Public Sub WaitForSweepThenExecuteNextCommand
			Me.Write(Me.Commands.SetWaitForSweepThenExecuteNextCommand)
		End Sub

		Public Overridable Sub Calibrate  'Required for derived SpecAns that have a built in calibration routine
		End Sub

		#End Region

		#Region "Functions"

		#End Region

	End Class

	#Region "Structures"

	Public Structure SpectrumAnalyzerCapabilities
		Public MinimumWarmUpTime As Integer

		Public MinimumFrequency As Double
		Public MinimumFrequencyMultiplier As FrequencyEnum
		Public MaximumFrequency As Double
		Public MaximumFrequencyMultiplier As FrequencyEnum
		Public NumberOfFrequencyBands As Integer

		Public MinimumRFAmplitude As Double
		Public MaximumRFAmplitude As Double
		Public RFAmplitudeMultiplier As AmplitudeEnum
		Public FundamentalFrequencySuffix As FrequencyEnum
		Public ReferenceOscillatorFrequency As Double
		Public ReferenceOscillatorFrequencyMultiplier As FrequencyEnum
	End Structure

	Public Structure SpectrumAnalyzerTestPoints
		Public CenterFrequencyReadoutAccuracyTestFrequencies() As Double
		Public CenterFrequencyReadoutAccuracyTestSpanWidths() As Double
		Public FrequencySpanAccuracyTestCenterFrequencies() As Double
		Public LowFrequencySpanAccuracyTestSpanWidths() As Double
		Public HighFrequencySpanAccuracyTestSpanWidths() As Double
		Public FrequencySpanAccuracyTestLowToHighTolerancePoint As Double
		Public ResolutionBandWidthAccuracyTestSpanWidths() As Double
		Public ResolutionBandWidthAccuracyTestResolutionBandWidths() As SpectrumAnalyzerResolutionBandwidthEnum
	End Structure

	Public Structure SpectrumAnalyzerSpecifications
		Public CenterFrequencyReadoutAccuracyTolernace As Double
		Public LowFrequencySpanAccuracyTolerance As Double
		Public HighFrequencySpanAccuracyTolerance As Double
	End Structure

	Public Enum SpectrumAnalyzerInstrumentStateEnum
		ZeroToTwoPointFiveGHz = 1
		TwoToTwentyTwoGHz = 2
	End Enum

	Public Enum MarkerReadoutEnum
		Frequency
	End Enum

	Public Enum SpectrumAnalyzerResolutionBandwidthEnum As Integer
		TenHz = 10
		ThirtyHz = 30
		OneHundredHz = 100
		ThreeHundredHz = 300
		OneKHz = 1000
		ThreeKHz = 3000
		TenKHz = 10000
		ThirtyKHz = 30000
		OneHundredKHz = 100000
		ThreeHundredKHz = 300000
		OneMHz = 1000000
		ThreeMHz = 3000000
	End Enum

	Public Enum SpectrumAnalyzerScaleEnum
		Linear
		[Log]
	End Enum

	#End Region




