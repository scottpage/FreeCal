'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/11/2005
' Time: 12:37 PM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common



    Public Class AudioAnalyzerFilterSection

        Protected _MainAudioAnalyzer As AudioAnalyzer
        Protected _CurrentFilter As AudioAnalyzerFilterEnum

    Public Property CurrentFilter As AudioAnalyzerFilterEnum
        Get
            Return _CurrentFilter
        End Get
        Set(value As AudioAnalyzerFilterEnum)
            _CurrentFilter = value
            Select Case value
                Case AudioAnalyzerFilterEnum.AllLowPassFiltersOff
                    _MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.SetAllLowPassFiltersOff)
                Case AudioAnalyzerFilterEnum.ThirtyKHzLowPass
                    _MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.SetThirtyKHzLowPassFilter)
                Case AudioAnalyzerFilterEnum.EightyKHzLowPass
                    _MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.SetEightyKHzLowPassFilter)
            End Select
        End Set
    End Property

    Public Sub AllLowPassFiltersOff
            Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.SetAllLowPassFiltersOff)
            Me._CurrentFilter = AudioAnalyzerFilterEnum.AllLowPassFiltersOff
        End Sub

        Public Sub ThirtyKHzLowPass
            Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.SetThirtyKHzLowPassFilter)
            Me._CurrentFilter = AudioAnalyzerFilterEnum.ThirtyKHzLowPass
        End Sub

        Public Sub EightyKHzLowPass
            Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.SetEightyKHzLowPassFilter)
            Me._CurrentFilter = AudioAnalyzerFilterEnum.EightyKHzLowPass
        End Sub

        Public Sub New(ByRef MainAudioAnalyzer As AudioAnalyzer)
            Me._MainAudioAnalyzer = MainAudioAnalyzer
        End Sub

    End Class

    Public Enum AudioAnalyzerFilterEnum
        ThirtyKHzLowPass
        EightyKHzLowPass
        AllLowPassFiltersOff
    End Enum




