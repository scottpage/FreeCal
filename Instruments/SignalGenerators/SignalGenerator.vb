'
' Created by SharpDevelop.
' User: rspage
' Date: 6/3/2005
' Time: 3:04 PM
' 

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports NationalInstruments.NI4882
Imports System.Windows.Forms
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public MustInherit Class SignalGenerator
        Inherits FreeCal.Instruments.Instrument

		#Region "Declarations"

		Public Event CWFrequencyChanged(ByVal newfrequency As Double)
		Public Event FrequencySuffixChanged(ByVal suffix As FrequencyEnum)
		Public Event AmplitudeLevelChanged(ByVal level As Double)
		Public Event AmplitudeLevelSuffixChanged(ByVal suffix As AmplitudeEnum)
		Public Event OutputStateChanged(ByVal state As OnOffStateEnum)
        Protected _Commands As SignalGeneratorGPIBCommands
        Protected _Specifications As SignalGeneratorSpecifications
        Protected _Capabilities As SignalGeneratorCapabilities
        Protected _TestPoints As SignalGeneratorTestPoints
		Protected WithEvents _Sections As SignalGeneratorSectionsSection

		#End Region

		#Region "Properties"

		Public ReadOnly Property Sections As SignalGeneratorSectionsSection
			Get
				Return Me._Sections
			End Get
		End Property

		Public ReadOnly Property TestPoints As SignalGeneratorTestPoints
			Get
				Return Me._TestPoints
			End Get
		End Property

		Public ReadOnly Property Commands As SignalGeneratorGPIBCommands
			Get
				Return Me._Commands
			End Get
		End Property

		Public ReadOnly Property Specifications As SignalGeneratorSpecifications
			Get
				Return Me._Specifications
			End Get
		End Property

		Public ReadOnly Property Capabilities As SignalGeneratorCapabilities
			Get
				Return Me._Capabilities
			End Get
		End Property

		#End Region

		#Region "Methods"

        Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, GetSettingsFromInstrument, Simulate)
		    Me._Sections = New SignalGeneratorSectionsSection(Me)
		End Sub

		Public Overridable Sub WriteFrequency(ByVal frequencySetting As Double)
        	Me.Write(Me.Commands.SetCWFrequency & FrequencySetting & Me.GetFrequencyTerminator(Me.Sections.RF.Frequency.Suffix))
		End Sub

		Public Overridable Sub WriteAmplitude(ByVal amplitudeSetting As Double, ByVal suffix As AmplitudeEnum)
       		Me.Write(Me.Commands.SetRFAmplitude & ConvertAmplitude(AmplitudeSetting, suffix, AmplitudeEnum.dBm) & Me.GetAmplitudeTerminator(AmplitudeEnum.dBm))
		End Sub

		Protected Sub OnCWFrequencyChanged(ByVal newfrequency As Double) Handles _Sections.CWFrequencyChanged
			RaiseEvent CWFrequencyChanged(newfrequency)
		End Sub

		Protected Sub OnFrequencySuffixChanged(ByVal suffix As FrequencyEnum) Handles _Sections.FrequencySuffixChanged
			RaiseEvent FrequencySuffixChanged(suffix)
		End Sub

		Protected Sub OnAmplitudeLevelChanged(ByVal level As Double) Handles _Sections.AmplitudeLevelChanged
			RaiseEvent AmplitudeLevelChanged(level)
		End Sub

		Protected Sub OnAmplitudeLevelSuffixChanged(ByVal suffix As AmplitudeEnum) Handles _Sections.AmplitudeLevelSuffixChanged
			RaiseEvent AmplitudeLevelSuffixChanged(suffix)
		End Sub

		Public Sub OnOutputStateChanged(ByVal state As OnOffStateEnum) Handles _Sections.OutputStateChanged
			RaiseEvent OutputStateChanged(state)
		End Sub

		#End Region

		#Region "Functions"

		#End Region

	End Class


