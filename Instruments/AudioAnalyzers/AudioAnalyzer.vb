'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/11/2005
' Time: 10:41 AM
' 

Public MustInherit Class AudioAnalyzer
    Inherits Instrument

#Region "Declarations"

    Protected _Commands As AudioAnalyzerGPIBCommands
    Protected _Specifications As AudioAnalyzerSpecifications
    Protected _Capabilities As AudioAnalyzerCapabilities
    Protected _TestPoints As AudioAnalyzerTestPoints
    Protected _Sections As New AudioAnalyzerSectionsSection(Me)

#End Region

#Region "Properties"

    Public ReadOnly Property Sections As AudioAnalyzerSectionsSection
        Get
            Return Me._Sections
        End Get
    End Property

    Public ReadOnly Property TestPoints As AudioAnalyzerTestPoints
        Get
            Return Me._TestPoints
        End Get
    End Property

    Public ReadOnly Property Commands As AudioAnalyzerGPIBCommands
        Get
            Return Me._Commands
        End Get
    End Property

    Public ReadOnly Property Specifications As AudioAnalyzerSpecifications
        Get
            Return Me._Specifications
        End Get
    End Property

    Public ReadOnly Property Capabilities As AudioAnalyzerCapabilities
        Get
            Return Me._Capabilities
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
    End Sub

    Public Sub TriggerWithSettling()
        Me.Write(Me.Commands.TriggerWithSettling)
    End Sub

#End Region

#Region "Functions"

    Public Function TriggerWithSettlingAndReadDouble() As Double
        Write(Me.Commands.TriggerWithSettling)
        Return System.Convert.ToDouble(Me.ReadString(10))
    End Function

#End Region

End Class

#Region "Structures"

Public Structure AudioAnalyzerGPIBCommands
    Public SetSourceFrequency As String
    Public SetSourceStartFrequency As String
    Public SetSourceStopFrequency As String
    Public SetSourceAmplitude As String
    Public SetSourceFrequencyIncrement As String
    Public SetSourceAmplitudeIncrement As String
    Public StepUp As String
    Public StepDown As String
    Public SetPlotLimit As String
    Public Special As String
    Public SweepOn As String
    Public SweepOff As String
    Public MeasureACLevel As String
    Public MeasureSINAD As String
    Public MeasureDistortion As String
    Public MeasureDCLevel As String
    Public MeasureSignalToNoise As String
    Public MeasureDistortionLevel As String
    Public SetThirtyKHzLowPassFilter As String
    Public SetEightyKHzLowPassFilter As String
    Public SetAllLowPassFiltersOff As String
    Public TriggerWithSettling As String
End Structure

Public Structure AudioAnalyzerCapabilities
    Public MinimumWarmUpTime As Integer
End Structure

Public Structure AudioAnalyzerTestPoints
    Public None As String
End Structure

Public Structure AudioAnalyzerSpecifications
    Public None As String
End Structure

#End Region

#Region "Enums"

Public Enum AudioAnalyzerMeasurementModeEnum
    ACLevel
    SINAD
    Distortion
    DCLevel
    SignalToNoise
    DistortionLevel
End Enum

#End Region


