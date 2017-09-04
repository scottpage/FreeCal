'
' Created by SharpDevelop.
' User: rspage
' Date: 6/3/2005
' Time: 3:04 PM
' 

Public MustInherit Class MeasuringReceiver
    Inherits FreeCal.Instruments.Instrument

#Region "Declarations"

    Protected _Specifications As MeasuringReceiverSpecifications
    Protected _Capabilities As MeasuringReceiverCapabilities
    Protected _TestFrequencies As MeasuringReceiverTestFrequencies
    Protected _Commands As MeasuringReceiverGPIBCommands
    Protected _Sections As New MeasuringReceiverSectionsSection(Me)

    Protected _InputFrequency As Double

#End Region

#Region "Properties"

    Public ReadOnly Property Sections As MeasuringReceiverSectionsSection
        Get
            Return Me._Sections
        End Get
    End Property

    Public Property InputFrequency As Double
        Get
            Return Me._InputFrequency
        End Get
        Set
            Me._InputFrequency = Value
            Me.Write(Value & Me.Commands.InputFrequencyMHz)
        End Set
    End Property

    Public ReadOnly Property Commands As MeasuringReceiverGPIBCommands
        Get
            Return Me._Commands
        End Get
    End Property



    Public ReadOnly Property TestFrequencies As MeasuringReceiverTestFrequencies
        Get
            Return Me._TestFrequencies
        End Get
    End Property

    Public ReadOnly Property Specifications As MeasuringReceiverSpecifications
        Get
            Return Me._Specifications
        End Get
    End Property

    Public ReadOnly Property Capabilities As MeasuringReceiverCapabilities
        Get
            Return Me._Capabilities
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
        MyBase.New(boardAddress, primaryAddress, getSettingsFromInstrument, simulate)
    End Sub

    Public Overrides Sub Preset()
        Me.Write(Me.GeneralCommands.Preset)
        Me.SetupInstrument()
        Me.Sections.Measurements.FrequencyOffsetMode.Preset()
    End Sub

    Public Function GetReading() As Double
        Return CDbl(Me.ReadString(15))
    End Function

#End Region

#Region "Functions"
#End Region

End Class




