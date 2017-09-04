'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/11/2005
' Time: 6:18 AM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class SignalGeneratorRFSection

		Public Event CWFrequencyChanged(ByVal newfrequency As Double)
		Public Event FrequencySuffixChanged(ByVal suffix As FrequencyEnum)
		Public Event AmplitudeLevelChanged(ByVal level As Double)
		Public Event AmplitudeLevelSuffixChanged(ByVal suffix As AmplitudeEnum)
		Public Event OutputStateChanged(ByVal state As OnOffStateEnum)
        Protected _MainSignalGenerator As SignalGenerator
        Protected WithEvents _Frequency As SignalGeneratorFrequencySection
        Protected WithEvents _Amplitude As SignalGeneratorAmplitudeSection
        Protected _OutputState As OnOffStateEnum

        Public ReadOnly Property Frequency As SignalGeneratorFrequencySection
            Get
                Return Me._Frequency
            End Get
        End Property

        Public ReadOnly Property Amplitude As SignalGeneratorAmplitudeSection
            Get
                Return Me._Amplitude
            End Get
        End Property

        Public Property OutputState As OnOffStateEnum
            Get
                Return Me._OutputState
            End Get
            Set
                Me._OutputState = Value
				If Value = OnOffStateEnum.[On] Then
                	Me._MainSignalGenerator.Write(Me._MainSignalGenerator.Commands.SetRFOutputStateOn)
                ElseIf Value = OnOffStateEnum.[Off] Then
                	Me._MainSignalGenerator.Write(Me._MainSignalGenerator.Commands.SetRFOutputStateOff)
                End If
               	RaiseEvent OutputStateChanged(Value)
            End Set
        End Property

        Public Sub New(ByRef MainSignalGenerator As SignalGenerator)
            Me._MainSignalGenerator = MainSignalGenerator
            Me._Amplitude = New SignalGeneratorAmplitudeSection(Me._MainSignalGenerator)
            Me._Frequency = New SignalGeneratorFrequencySection(Me._MainSignalGenerator)
        End Sub

		Public Overrides Overloads Function ToString As String
			Return Me.OutputState.ToString & NewLine & Me.Frequency.CW & Me.Frequency.Suffix.ToString & NewLine & Me.Amplitude.Level & Me.Amplitude.Suffix.ToString
		End Function

		Protected Sub OnCWFrequencyChanged(ByVal newfrequency As Double) Handles _Frequency.CWFrequencyChanged
			RaiseEvent CWFrequencyChanged(newfrequency)
		End Sub

		Protected Sub OnFrequencySuffixChanged(ByVal suffix As FrequencyEnum) Handles _Frequency.FrequencySuffixChanged
			RaiseEvent FrequencySuffixChanged(suffix)
		End Sub

		Protected Sub OnAmplitudeLevelChanged(ByVal level As Double) Handles _Amplitude.AmplitudeLevelChanged
			RaiseEvent AmplitudeLevelChanged(level)
		End Sub

		Protected Sub OnAmplitudeLevelSuffixChanged(ByVal suffix As AmplitudeEnum) Handles _Amplitude.AmplitudeLevelSuffixChanged
			RaiseEvent AmplitudeLevelSuffixChanged(suffix)
		End Sub

    End Class


