'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/11/2005
' Time: 11:11 AM
' 

Public Class AudioAnalyzerSourceSection

    Protected _MainAudioAnalyzer As AudioAnalyzer
    Protected _Frequency As Double
    Protected _FrequencySuffix As FrequencyEnum
    Protected _FrequencyIncrement As Double
    Protected _Amplitude As Double
    Protected _AmplitudeSuffix As AmplitudeEnum
    Protected _AmplitudeIncrement As Double

    Public Property Frequency As Double
        Get
            Return Me._Frequency
        End Get
        Set
            Me._Frequency = Value
            Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.SetSourceFrequency & Value & Me._MainAudioAnalyzer.GetFrequencyTerminator(Me._FrequencySuffix))
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

    Public Property FrequencyIncrement As Double
        Get
            Return Me._FrequencyIncrement
        End Get
        Set
            Me._FrequencyIncrement = Value
            Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.SetSourceFrequencyIncrement & Value & Me._MainAudioAnalyzer.GetFrequencyTerminator(Me._FrequencySuffix))
        End Set
    End Property

    Public Property Amplitude As Double
        Get
            Return Me._Amplitude
        End Get
        Set
            Me._Amplitude = Value
            Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.SetSourceAmplitude & Value & Me._MainAudioAnalyzer.GetAmplitudeTerminator(Me._AmplitudeSuffix))
        End Set
    End Property

    Public Property AmplitudeSuffix As AmplitudeEnum
        Get
            Return Me._AmplitudeSuffix
        End Get
        Set
            Me._AmplitudeSuffix = Value
        End Set
    End Property

    Public Property AmplitudeIncrement As Double
        Get
            Return Me._AmplitudeIncrement
        End Get
        Set
            Me._AmplitudeIncrement = Value
            Me._MainAudioAnalyzer.Write(Me._MainAudioAnalyzer.Commands.SetSourceAmplitudeIncrement & Value & Me._MainAudioAnalyzer.GetAmplitudeTerminator(Me._AmplitudeSuffix))
        End Set
    End Property

    Public Sub New(ByRef MainAudioAnalyzer As AudioAnalyzer)
        Me._MainAudioAnalyzer = MainAudioAnalyzer
    End Sub

End Class



