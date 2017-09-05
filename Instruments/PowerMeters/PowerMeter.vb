'
' Created by SharpDevelop.
' User: rspage
' Date: 6/7/2005
' Time: 8:01 AM
' 

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports FreeCal.Logging
Imports System.ComponentModel


<TypeConverter(GetType(ExpandableObjectConverter))>
Public MustInherit Class PowerMeter
    Inherits FreeCal.Instruments.Instrument

#Region "Declarations"

    Protected _Commands As PowerMeterGPIBCommands
    Protected _Specifications As PowerMeterSpecifications
    Protected _Capabilities As PowerMeterCapabilities
    Protected _TestFrequencies As PowerMeterTestFrequencies

    Protected _NumberOfChannels As Integer = 1
    Protected _HasInternalSensorCalibrationTables As Boolean = False
    Protected _Sections As New PowerMeterSectionsSection(Me)

    Protected _FrequencySuffix As FrequencyEnum = FrequencyEnum.MHz

#End Region

#Region "Properties"

    Public ReadOnly Property Sections As PowerMeterSectionsSection
        Get
            Return Me._Sections
        End Get
    End Property

    Public ReadOnly Property HasInternalSensorCalibrationTables As Boolean
        Get
            Return Me._HasInternalSensorCalibrationTables
        End Get
    End Property

    Public ReadOnly Property NumberOfChannels As Integer
        Get
            Return Me._NumberOfChannels
        End Get
    End Property

    Public Property FrequencySuffix As FrequencyEnum
        Get
            Return Me._FrequencySuffix
        End Get
        Set
            Me._FrequencySuffix = Value
        End Set
    End Property

    Public ReadOnly Property TestFrequencies As PowerMeterTestFrequencies
        Get
            Return Me._TestFrequencies
        End Get
    End Property

    Public ReadOnly Property Commands As PowerMeterGPIBCommands
        Get
            Return Me._Commands
        End Get
    End Property

    Public ReadOnly Property Specifications As PowerMeterSpecifications
        Get
            Return Me._Specifications
        End Get
    End Property

    Public ReadOnly Property Capabilities As PowerMeterCapabilities
        Get
            Return Me._Capabilities
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
    End Sub

    Public Sub SetCalibrationFactor(ByVal inputFrequency As Double)
        Me.Write(Me.Commands.SetFrequency & inputFrequency & Me.GetFrequencyTerminator(Me.FrequencySuffix))
    End Sub

    Protected Friend Overridable Sub Zero(ByVal channel As String, Optional ByVal showPrompts As Boolean = True)
    End Sub

    Protected Friend Overridable Sub ZeroAndCalibrate(ByVal channel As String)
    End Sub

    Protected Friend Overridable Sub Calibrate(ByVal channel As String, Optional ByVal showPrompts As Boolean = True)

    End Sub

#End Region

#Region "Functions"
#End Region

End Class




