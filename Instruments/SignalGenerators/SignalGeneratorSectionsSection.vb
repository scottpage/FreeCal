'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/10/2005
' Time: 7:04 PM
'


Imports System
Imports System.ComponentModel
Imports FreeCal.Common


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class SignalGeneratorSectionsSection

		Public Event CWFrequencyChanged(ByVal newfrequency As Double)
		Public Event FrequencySuffixChanged(ByVal suffix As FrequencyEnum)
		Public Event AmplitudeLevelChanged(ByVal level As Double)
		Public Event AmplitudeLevelSuffixChanged(ByVal suffix As AmplitudeEnum)
		Public Event OutputStateChanged(ByVal state As OnOffStateEnum)
        Protected WithEvents _RF As SignalGeneratorRFSection
        Protected _Sweep As SignalGeneratorSweepSection
        Protected _Modulation As SignalGeneratorModulationSection
		Protected _MainSignalGenerator AS SignalGenerator

        Public ReadOnly Property RF As SignalGeneratorRFSection
            Get
                Return Me._RF
            End Get
        End Property

        Public ReadOnly Property Sweep As SignalGeneratorSweepSection
            Get
                Return Me._Sweep
            End Get
        End Property

        Public ReadOnly Property Modulation As SignalGeneratorModulationSection
            Get
                Return Me._Modulation
            End Get
        End Property

		Public Sub New(ByRef mainSignalGenerator As SignalGenerator)
			Me._MainSignalGenerator = mainSignalGenerator
	        Me._RF = New SignalGeneratorRFSection(Me._MainSignalGenerator)
	        Me._Sweep = New SignalGeneratorSweepSection(Me._MainSignalGenerator)
	        Me._Modulation = New SignalGeneratorModulationSection(Me._MainSignalGenerator)
		End Sub

		Protected Sub OnCWFrequencyChanged(ByVal newfrequency As Double) Handles _RF.CWFrequencyChanged
			RaiseEvent CWFrequencyChanged(newfrequency)
		End Sub

		Protected Sub OnFrequencySuffixChanged(ByVal suffix As FrequencyEnum) Handles _RF.FrequencySuffixChanged
			RaiseEvent FrequencySuffixChanged(suffix)
		End Sub

		Protected Sub OnAmplitudeLevelChanged(ByVal level As Double) Handles _RF.AmplitudeLevelChanged
			RaiseEvent AmplitudeLevelChanged(level)
		End Sub

		Protected Sub OnAmplitudeLevelSuffixChanged(ByVal suffix As AmplitudeEnum) Handles _RF.AmplitudeLevelSuffixChanged
			RaiseEvent AmplitudeLevelSuffixChanged(suffix)
		End Sub

		Public Sub OnOutputStateChanged(ByVal state As OnOffStateEnum) Handles _RF.OutputStateChanged
        	RaiseEvent OutputStateChanged(state)
		End Sub

		Public Overrides Overloads Function ToString As String
			Return "RF, Sweep, Modulation"
		End Function

	End Class

