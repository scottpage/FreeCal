'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/17/2005
' Time: 6:58 AM
'

Imports System

Public Class AmplitudeOutOfRangeException
    Inherits System.[Exception]

    Protected _AttemptedAmplitude As Double
    Protected _MaximumAmplitude As Double
    Protected _AttemptedAmplitudeSuffix As AmplitudeEnum
    Protected _MaximumAmplitudeSuffix As AmplitudeEnum
    Protected _InstrumentModel As String
    Protected _Message As String

    Public ReadOnly Property AttemptedAmplitude As Double
        Get
            Return Me._AttemptedAmplitude
        End Get
    End Property

    Public ReadOnly Property MaximumAmplitude As Double
        Get
            Return Me._MaximumAmplitude
        End Get
    End Property

    Public ReadOnly Property AttemptedAmplitudeSuffix As Double
        Get
            Return Me._AttemptedAmplitudeSuffix
        End Get
    End Property

    Public ReadOnly Property MaximumAmplitudeSuffix As Double
        Get
            Return Me._MaximumAmplitudeSuffix
        End Get
    End Property

    Public ReadOnly Property InstrumentModel As String
        Get
            Return _InstrumentModel
        End Get
    End Property

    Public Overrides ReadOnly Property Message As String
        Get
            Return Me._Message
        End Get
    End Property

    Public Sub New(ByVal instrumentModel As String, ByVal attemptedAmplitude As Double, ByVal maximumAmplitude As Double, ByVal attemptedAmplitudeSuffix As AmplitudeEnum, ByVal maximumAmplitudeSuffix As AmplitudeEnum)
        Me._AttemptedAmplitude = attemptedAmplitude
        Me._MaximumAmplitude = Convert.ToInt32(ConvertAmplitude(maximumAmplitude, maximumAmplitudeSuffix, attemptedAmplitudeSuffix))
        Me._AttemptedAmplitudeSuffix = attemptedAmplitudeSuffix
        Me._MaximumAmplitudeSuffix = attemptedAmplitudeSuffix
        Me._InstrumentModel = instrumentModel

        Me._Message = "Attempted Amplitude setting is greater than the " & instrumentModel & " Maximum Amplitude, please choose another value." & NewLine & "Attempted Amplitude = " & Me._AttemptedAmplitude & Me._AttemptedAmplitudeSuffix.ToString & NewLine & "Maximum Amplitude = " & Me._MaximumAmplitude & Me._AttemptedAmplitudeSuffix.ToString
    End Sub

End Class
