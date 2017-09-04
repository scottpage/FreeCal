'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/11/2005
' Time: 7:30 AM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class SignalGeneratorAMSection

        Protected _MainSignalGenerator As SignalGenerator
        Protected _OutputState As OnOffStateEnum = OnOffStateEnum.[Off]
        Protected _Depth As Double = 50
        Protected _Frequency As Double = 1
        Protected _FrequencySuffix As FrequencyEnum = FrequencyEnum.KHz

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

        Public Property Depth As Double
            Get
                Return Me._Depth
            End Get
            Set
                Me._Depth = Value
                Me._MainSignalGenerator.Write(Me._MainSignalGenerator.Commands.SetAMDepth & Value & Me._MainSignalGenerator.CommandTerminators.Percent)
            End Set
        End Property

        Public Sub New(ByRef MainSignalGenerator As SignalGenerator)
            Me._MainSignalGenerator = MainSignalGenerator
        End Sub

    End Class



