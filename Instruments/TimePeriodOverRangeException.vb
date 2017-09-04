'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/11/2005
' Time: 9:56 AM
' 


Imports System
Imports FreeCal.Common



	Public Class TimePeriodOverRangeException
	    Inherits System.[Exception]

        Protected _AttemptedTimePeriod As Integer
        Protected _MaximumTimePeriod As Integer
        Protected _CurrentTimeSuffix As TimeEnum
        Protected _CurrentMaximumTimeSuffix As TimeEnum
        Protected _Message As String

        Public ReadOnly Property AttemptedTimePeriod As Integer
            Get
                Return Me._AttemptedTimePeriod
            End Get
        End Property

        Public ReadOnly Property MaximumTimePeriod As Integer
            Get
                Return Me._MaximumTimePeriod
            End Get
        End Property

        Public ReadOnly Property CurrentTimeSuffix As Integer
            Get
                Return Me._CurrentTimeSuffix
            End Get
        End Property

        Public ReadOnly Property CurrentMaximumTimeSuffix As Integer
            Get
                Return Me._CurrentMaximumTimeSuffix
            End Get
        End Property

        Public ReadOnly Overrides Property Message As String
            Get
                Return Me._Message
            End Get
        End Property

        Public Sub New(ByVal attemptedTimePeriod As Integer, ByVal maximumTimePeriod As Integer, ByVal currentTimeSuffix As TimeEnum, ByVal currentMaximumTimeSuffix As TimeEnum)
            Me._AttemptedTimePeriod = AttemptedTimePeriod
            Me._MaximumTimePeriod = MaximumTimePeriod
            Me._CurrentTimeSuffix = CurrentTimeSuffix
            Me._CurrentMaximumTimeSuffix = CurrentMaximumTimeSuffix
            Me._Message = "Time period is greater than the Instruments Maximum Sweep Time, please choose another value."
        End Sub

	End Class

