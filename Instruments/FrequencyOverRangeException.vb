'
' Created by SharpDevelop.
' User: rspage
' Date: 6/13/2005
' Time: 11:08 AM
' 

Imports System
Imports FreeCal.Common



	Public Class FrequencyOverRangeException
	    Inherits System.[Exception]

    Protected _AttemptedFrequency As Double
    Protected _MaximumFrequency As Double
    Protected _AttemptedFrequencySuffix As FrequencyEnum
    Protected _MaximumFrequencySuffix As FrequencyEnum
    Protected _InstrumentModel As String
    Protected _Message As String

    Public ReadOnly Property AttemptedFrequency As Double
        Get
            Return Me._AttemptedFrequency
        End Get
    End Property

    Public ReadOnly Property MaximumFrequency As Double
        Get
            Return Me._MaximumFrequency
        End Get
    End Property

    Public ReadOnly Property AttemptedFrequencySuffix As Double
        Get
            Return Me._AttemptedFrequencySuffix
        End Get
    End Property

    Public ReadOnly Property MaximumFrequencySuffix As Double
        Get
            Return Me._MaximumFrequencySuffix
        End Get
    End Property

    Public ReadOnly Property InstrumentModel As String
        Get
            Return Me._InstrumentModel
        End Get
    End Property

    Public Overrides ReadOnly Property Message As String
        Get
            Return Me._Message
        End Get
    End Property

    Public Sub New(ByVal instrumentModel As String, ByVal attemptedFrequency As Double, ByVal maximumFrequency As Double, ByVal attemptedFrequencySuffix As FrequencyEnum, ByVal maximumFrequencySuffix As FrequencyEnum)
        Me._AttemptedFrequency = attemptedFrequency
        Me._MaximumFrequency = maximumFrequency
        Me._AttemptedFrequencySuffix = attemptedFrequencySuffix
        Me._MaximumFrequencySuffix = maximumFrequencySuffix
        Me._InstrumentModel = instrumentModel
        Me._Message = "Attempted Frequency setting is greater than the " & instrumentModel & " Maximum Frequency, please choose another value." & NewLine & "Attempted Frequency = " & Me._AttemptedFrequency & Me._AttemptedFrequencySuffix.ToString & NewLine & "Maximum Frequency = " & Me._MaximumFrequency & Me._MaximumFrequencySuffix.ToString
    End Sub

End Class

