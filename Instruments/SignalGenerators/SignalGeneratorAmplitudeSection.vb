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
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class SignalGeneratorAmplitudeSection

        Protected _MainSignalGenerator As SignalGenerator
		Public Event AmplitudeLevelChanged(ByVal level As Double)
		Public Event AmplitudeLevelSuffixChanged(ByVal suffix As AmplitudeEnum)
        Protected _Level As Double
        Protected _Suffix As AmplitudeEnum

        Public Overridable Property Level As Double
            Get
            	Return Me._Level
            End Get
            Set
                If AmplitudeSettingIsToLarge(Value, Me._MainSignalGenerator.Capabilities.MaximumRFAmplitude, Me._Suffix, Me._MainSignalGenerator.Capabilities.RFAmplitudeSuffix) Then
                Throw New AmplitudeOutOfRangeException(Me._MainSignalGenerator.Model, Value, _MainSignalGenerator.Capabilities.MaximumRFAmplitude, Me._Suffix, Me._MainSignalGenerator.Capabilities.RFAmplitudeSuffix)
            Else
	            	Me._Level = Value
					Me._MainSignalGenerator.WriteAmplitude(Value, Me._Suffix)
					RaiseEvent AmplitudeLevelChanged(value)
				End If
            End Set
        End Property

        Public Property Suffix As AmplitudeEnum
            Get
                Return Me._Suffix
            End Get
            Set
            	Me._Level = Me._MainSignalGenerator.ConvertAmplitude(Me._Level, Me._Suffix, Value)
            	RaiseEvent AmplitudeLevelChanged(Me._Level)
                Me._Suffix = Value
                RaiseEvent AmplitudeLevelSuffixChanged(Value)
             End Set
        End Property

        Public Sub New(ByRef MainSignalGenerator As SignalGenerator)
            Me._MainSignalGenerator = MainSignalGenerator
        End Sub

		Public Overrides Overloads Function ToString As String
			Return "Level: " & Me.Level & ", Suffix: " & Me.Suffix.ToString
		End Function

    End Class



