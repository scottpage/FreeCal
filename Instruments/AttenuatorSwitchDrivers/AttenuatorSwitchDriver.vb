'
' Created by SharpDevelop.
' User: rspage
' Date: 6/15/2005
' Time: 1:15 PM
' 

Public MustInherit Class AttenuatorSwitchDriver
    Inherits Instrument

#Region "Declarations"

    Protected _Commands As AttenuatorSwitchDriverGPIBCommands
    Protected _Specifications As AttenuatorSwitchDriverSpecifications
    Protected _Capabilities As AttenuatorSwitchDriverCapabilities
    Protected _TestPoints As AttenuatorSwitchDriverTestPoints
    Protected _Sections As New AttenuatorSwitchDriverSectionsSection(Me)

#End Region

#Region "Properties"

    Public ReadOnly Property Sections As AttenuatorSwitchDriverSectionsSection
        Get
            Return Me._Sections
        End Get
    End Property

    Public ReadOnly Property TestPoints As AttenuatorSwitchDriverTestPoints
        Get
            Return Me._TestPoints
        End Get
    End Property

    Public ReadOnly Property Commands As AttenuatorSwitchDriverGPIBCommands
        Get
            Return Me._Commands
        End Get
    End Property

    Public ReadOnly Property Specifications As AttenuatorSwitchDriverSpecifications
        Get
            Return Me._Specifications
        End Get
    End Property

    Public ReadOnly Property Capabilities As AttenuatorSwitchDriverCapabilities
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


