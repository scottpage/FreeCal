'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/11/2005
' Time: 6:20 AM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.Windows.Forms
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class SignalGeneratorFrequencySection

        Protected _MainSignalGenerator As SignalGenerator
		Public Event CWFrequencyChanged(ByVal level As Double)
		Public Event FrequencySuffixChanged(ByVal suffix As FrequencyEnum)
        Protected _CW As Double
        Protected _Suffix As FrequencyEnum = FrequencyEnum.GHz

        Public Property CW As Double
            Get
                Return Me._CW
            End Get
            Set
                If FrequencySettingIsToLarge(Value, Me._MainSignalGenerator.Capabilities.MaximumFrequency, Me._Suffix, Me._MainSignalGenerator.Capabilities.MaximumFrequencySuffix) Then
                    Throw New FrequencyOverRangeException(Me._MainSignalGenerator.Model, Value, Me._MainSignalGenerator.Capabilities.MaximumFrequency, Me._Suffix, Me._MainSignalGenerator.Capabilities.MaximumFrequencySuffix)
                Else
	            	Me._CW = Value
					Me._MainSignalGenerator.WriteFrequency(Value)
					RaiseEvent CWFrequencyChanged(Value)
                End If
            End Set
        End Property

        Public Property Suffix As FrequencyEnum
            Get
                Return Me._Suffix
            End Get
            Set
            	Me._CW = Me._MainSignalGenerator.ConvertFrequency(Me._CW, Me._Suffix, Value)
            	RaiseEvent CWFrequencyChanged(Me._CW)
                Me._Suffix = Value
                RaiseEvent FrequencySuffixChanged(Value)
            End Set
        End Property

        Public Sub New(ByRef MainSignalGenerator As SignalGenerator)
           	Me._MainSignalGenerator = MainSignalGenerator
        End Sub

    End Class


