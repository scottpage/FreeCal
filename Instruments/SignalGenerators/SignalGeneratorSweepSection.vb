'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/11/2005
' Time: 9:31 AM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Enum SignalGeneratorSweepModeEnum
		[Auto] = 1
		[Manual] = 0
	End Enum

	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class SignalGeneratorSweepSection

        Protected _MainSignalGenerator As SignalGenerator
    Protected _Time As Integer
    Protected _TimeSuffix As TimeEnum
		Protected _Mode As SignalGeneratorSweepModeEnum

    Public Property Time As Integer
        Get
            Return Me._Time
        End Get
        Set
            If TimePeriodIsToLarge(Value, Me._MainSignalGenerator.Capabilities.MaximumSweepTime, Me._TimeSuffix, Me._MainSignalGenerator.Capabilities.MaximumSweepTimeSuffix) Then
                Throw New TimePeriodOverRangeException(Value, Me._MainSignalGenerator.Capabilities.MaximumSweepTime, Me._TimeSuffix, Me._MainSignalGenerator.Capabilities.MaximumSweepTimeSuffix)
            Else
                Me._Time = Value
                Me._MainSignalGenerator.Write(Me._MainSignalGenerator.Commands.SetSweepTime & Value & Me._MainSignalGenerator.GetTimeTerminator(Me._TimeSuffix))
            End If
        End Set
    End Property

    Public Property Mode As SignalGeneratorSweepModeEnum
			Get
				Return Me._Mode
			End Get
			Set
				Me._Mode = Value
				Me._MainSignalGenerator.Write(Me._MainSignalGenerator.Commands.SetSweepMode & Value.ToString)
			End Set
		End Property

		Public Property TimeSuffix As TimeEnum
			Get
				Return Me._TimeSuffix
			End Get
			Set
				Me._TimeSuffix = Value
			End Set
		End Property

        Public Sub New(ByRef MainSignalGenerator As SignalGenerator)
            Me._MainSignalGenerator = MainSignalGenerator
        End Sub

    End Class



