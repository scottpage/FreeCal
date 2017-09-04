'
' Created by SharpDevelop.
' User: rspage
' Date: 4/22/2005
' Time: 3:15 PM
' 


Imports System
Imports System.Windows.Forms
Imports FreeCal.Common


Public Class Agilent53131AGPIBCommands
    Public FrequencyModeAuto As String = "AU"
    Public FrequencyModeManual As String = "M"
    Public ManualCenterFrequency As String = "SM"
    Public AmplitudeMode As String = "AM"
    Public FrequencyOffsetMode As String = "OM"
    Public FrequencyOffset As String = "SOM"
    Public AmplitudeOffset As String = "SOB"
    Public Resolution As String = "SR"
    Public LowRange As String = "L"
    Public HighRange As String = "H"
    Public CWMode As String = "C"
    Public FMMode As String = "F"
    Public SampleRate As String = "T"
    Public OutputMode As String = "ST"
    Public [Reset] As String = "RE"
    Public AutomaticFrequencyOffset As String = "SOMB"
    Public AutomaticAmlitudeOffset As String = "SOBB"
    Public CheckMode As String = "SR1"
    Public Identity As String = "*IDN?"
End Class

Public Class Agilent53131A
    Inherits FreeCal.Instruments.Instrument

    Public Enum ResolutionValue
        OneHz = 3
        TenHz = 4
        OneHundredHz = 5
        OneKHz = 6
        TenKHz = 7
        OneHundredKHz = 8
        OneMHz = 9
    End Enum

    Public Enum SampleRateValue
        FrontPanelSampleRate = 0
        Hold = 1
        FastSampleNoDelay = 2
        SampleThenHold = 3
    End Enum

    Public Enum OutputModeValue
        OutputOnlyWhenAddressed = 1
        WaitUntilAddressed = 2
    End Enum

    Public Enum FrequencyOffsetModeValue
        [On] = 1
        [Off] = 0
    End Enum

    Public Enum AmplitudeModeValue
        [On] = 1
        [Off] = 0
    End Enum

    Public Commands As New Agilent53131AGPIBCommands

    Public Sub New(ByVal boardID As Integer, ByVal primaryAddress As Integer, ByVal secondaryAddress As Integer)
        MyBase.New(boardID, primaryAddress, secondaryAddress)
        Me.SetMyVariables()
    End Sub

    Private Sub SetMyVariables()
        Me._CanIdentify = True
    End Sub

    Public Function GetIdentity(ByVal storeResult As Boolean) As String
        Me.Write(Me.Commands.Identity)
        If storeResult Then
            Me._FullIdentity = Me.ReadString()
            Dim Delimeters As Char() = New Char() {" ", ",", "/"}
            Me.ProcessIdentity(FullIdentity, Delimeters)
            Return Me.FullIdentity
        Else
            Return Me.ReadString()
        End If
    End Function

    Public Sub SetFrequencyModeTo(ByVal autoManual As String)
        Select Case autoManual
            Case "Auto"
                Me.Write(Me.Commands.FrequencyModeAuto)
            Case "Manual"
                Me.Write(Me.Commands.FrequencyModeManual)
        End Select
    End Sub

    Public Sub SetManualCenterFrequencyTo(ByVal mHz As Integer)
        Me.Write(Me.Commands.ManualCenterFrequency & mHz & "E")
    End Sub

    Public Sub SetAmplitudeModeTo(ByVal onOff As AmplitudeModeValue)
        Me.Write(Me.Commands.AmplitudeMode & onOff)
    End Sub

    Public Sub SetFrequencyOffsetModeTo(ByVal onOff As FrequencyOffsetModeValue)
        Me.Write(Me.Commands.FrequencyOffsetMode & onOff)
    End Sub

    Public Sub SetFrequencyOffsetTo(ByVal posOrNegMHz As Double)
        Me.Write(Me.Commands.FrequencyOffset & posOrNegMHz & "E")
    End Sub

    Public Sub SetAmplitudeOffsetTo(ByVal posOrNegDB As Double)
        Me.Write(Me.Commands.AmplitudeOffset & posOrNegDB & "E")
    End Sub

    Public Sub SetResolutionTo(ByVal newResolution As ResolutionValue)
        Me.Write(Me.Commands.Resolution & newResolution)
    End Sub

    Public Sub SetRangeTo(ByVal highLow As String)
        Select Case highLow
            Case "High"
                Me.Write(Me.Commands.HighRange)
            Case "Low"
                Me.Write(Me.Commands.LowRange)
        End Select
    End Sub

    Public Sub SetModeTo(ByVal cWorFM As String)
        Select Case cWorFM
            Case "CW"
                Me.Write(Me.Commands.CWMode)
            Case "FM"
                Me.Write(Me.Commands.FMMode)
        End Select
    End Sub

    Public Sub SetSampleRateTo(ByVal newSampleRate As SampleRateValue)
        Me.Write(Me.Commands.SampleRate & newSampleRate)
    End Sub

    Public Sub SetOutPutModeTo(ByVal newOutputMode As OutputModeValue)
        Me.Write(Me.Commands.OutputMode & newOutputMode)
    End Sub

    Public Function Measure() As Double
        Me.Write("?")
        Return Me.ReadString
    End Function

End Class

