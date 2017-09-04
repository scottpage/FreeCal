'
' Created by SharpDevelop.
' User: rspage
' Date: 6/9/2005
' Time: 1:03 PM
' 

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports NationalInstruments.NI4882
Imports System.Windows.Forms


#Region "Enums"

#End Region

Public MustInherit Class FunctionGenerator
    Inherits FreeCal.Instruments.Instrument

#Region "Declarations"

    Protected _Commands As FunctionGeneratorGPIBCommands
    Protected _Specifications As FunctionGeneratorSpecifications
    Protected _Capabilities As FunctionGeneratorCapabilities
    Protected _TestPoints As FunctionGeneratorTestPoints

    Protected _Frequency As Double
    Protected _Amplitude As Double
    Protected _Waveform As WaveformEnum
    Protected _FrequencySuffix As FrequencyEnum
    Protected _AmplitudeSuffix As AmplitudeEnum
    Protected _Output As FunctionGeneratorOutputEnum

#End Region

#Region "Properties"

    Public Property Frequency() As Double
        Get
            Return Me._Frequency
        End Get
        Set(ByVal Value As Double)
            Me._Frequency = Value
            Me.Write(Me._Commands.SetFrequency & Value & Me.GetFrequencyTerminator(Me._FrequencySuffix))
        End Set
    End Property

    Public Property FrequencySuffix() As FrequencyEnum
        Get
            Return Me._FrequencySuffix
        End Get
        Set(ByVal Value As FrequencyEnum)
            Me._FrequencySuffix = Value
        End Set
    End Property

    Public Property Amplitude() As Double
        Get
            Me.Write("AM?")
            Me._Amplitude = Me.ReadDouble
            Return Me._Amplitude
        End Get
        Set(ByVal Value As Double)
            Me._Amplitude = Value
            Me.Write(Me._Commands.SetAmplitude & Value & Me.GetAmplitudeTerminator(Me._AmplitudeSuffix))
        End Set
    End Property

    Public Property AmplitudeSuffix() As AmplitudeEnum
        Get
            Return Me._AmplitudeSuffix
        End Get
        Set(ByVal Value As AmplitudeEnum)
            Me._AmplitudeSuffix = Value
        End Set
    End Property

    Public Property Waveform() As WaveformEnum
        Get
            Return Me._Waveform
        End Get
        Set(ByVal Value As WaveformEnum)
            Me._Waveform = Value
            Select Case Value
                Case WaveformEnum.Sine
                    Me.Write(Me._Commands.SetSineWaveform & Value)
            End Select
        End Set
    End Property

    Public Property Output() As FunctionGeneratorOutputEnum
        Get
            Return Me._Output
        End Get
        Set(ByVal Value As FunctionGeneratorOutputEnum)
            Me._Output = Value
            Select Case Value
                Case FunctionGeneratorOutputEnum.Front
                    Me.Write(Me._Commands.FrontOnlyOutput)
                Case FunctionGeneratorOutputEnum.Rear
                    Me.Write(Me._Commands.RearOnlyOutput)
            End Select
        End Set
    End Property

    Public ReadOnly Property TestPoints() As FunctionGeneratorTestPoints
        Get
            Return Me._TestPoints
        End Get
    End Property

    Public ReadOnly Property Commands() As FunctionGeneratorGPIBCommands
        Get
            Return Me._Commands
        End Get
    End Property

    Public ReadOnly Property Specifications() As FunctionGeneratorSpecifications
        Get
            Return Me._Specifications
        End Get
    End Property

    Public ReadOnly Property Capabilities() As FunctionGeneratorCapabilities
        Get
            Return Me._Capabilities
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
    End Sub

#End Region

#Region "Functions"

#End Region

End Class




