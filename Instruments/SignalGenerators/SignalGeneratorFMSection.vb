'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/11/2005
' Time: 7:31 AM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class SignalGeneratorFMSection

        Protected _MainSignalGenerator As SignalGenerator
        Protected _OutputState As OnOffStateEnum = OnOffStateEnum.[Off]
        Protected _Frequency As Double = 1
        Protected _FrequencySuffix As FrequencyEnum = FrequencyEnum.KHz
        Protected _Deviation As Double = 50
        Protected _DeviationSuffix As FrequencyEnum = FrequencyEnum.KHz

        Public Property OutputState As OnOffStateEnum
            Get
                Return Me._OutputState
            End Get
            Set
                Me._OutputState = Value
                If Value = OnOffStateEnum.[On] Then
                	Me._MainSignalGenerator.Write(Me._MainSignalGenerator.Commands.SetAMStateOn)
                Else
                	Me._MainSignalGenerator.Write(Me._MainSignalGenerator.Commands.SetAMStateOff)
                End If
            End Set
        End Property

        Public Property FrequencySuffix As FrequencyEnum
            Get
                Return Me._FrequencySuffix
            End Get
            Set
                Me._FrequencySuffix = Value
            End Set
        End Property

        Public Property Frequency As Double
            Get
                Return Me._Frequency
            End Get
            Set
                Me._Frequency = Value
               	Me._MainSignalGenerator.Write(Me._MainSignalGenerator.Commands.SetAMFrequency & Value & Me._MainSignalGenerator.GetFrequencyTerminator(Me._FrequencySuffix))
            End Set
        End Property

		Public Property Deviation As Double
			Get
				Return Me._Deviation
			End Get
			Set
				Me._Deviation = Value
                Me._MainSignalGenerator.Write(Me._MainSignalGenerator.Commands.SetFMDeviation & Value.ToString & " " & Me._DeviationSuffix.ToString)
			End Set
		End Property

        Public Property DeviationSuffix As FrequencyEnum
            Get
                Return Me._DeviationSuffix
            End Get
            Set
                Me._DeviationSuffix = Value
            End Set
        End Property

        Public Sub New(ByRef MainSignalGenerator As SignalGenerator)
            Me._MainSignalGenerator = MainSignalGenerator
        End Sub

    End Class


