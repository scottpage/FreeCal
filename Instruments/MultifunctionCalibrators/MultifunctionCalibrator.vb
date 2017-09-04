'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/29/2005
' Time: 5:01 AM
'

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports NationalInstruments.NI4882
Imports System.Windows.Forms
Imports System.ComponentModel


    <TypeConverter(GetType(ExpandableObjectConverter))> _
    Public MustInherit Class MultifunctionCalibrator
        Inherits FreeCal.Instruments.Instrument

#Region "Declarations"

        Protected _Commands As MultifunctionCalibratorGPIBCommands
        Protected _Specifications As MultifunctionCalibratorpecifications
        Protected _Capabilities As MultifunctionCalibratorCapabilities
        Protected _TestPoints As MultifunctionCalibratorTestPoints
        Protected _Sections As MultifunctionCalibratorectionsSection

#End Region

#Region "Properties"

        Public ReadOnly Property Sections() As MultifunctionCalibratorectionsSection
            Get
                Return Me._Sections
            End Get
        End Property

        Public ReadOnly Property TestPoints() As MultifunctionCalibratorTestPoints
            Get
                Return Me._TestPoints
            End Get
        End Property

        Public ReadOnly Property Commands() As MultifunctionCalibratorGPIBCommands
            Get
                Return Me._Commands
            End Get
        End Property

        Public ReadOnly Property Specifications() As MultifunctionCalibratorpecifications
            Get
                Return Me._Specifications
            End Get
        End Property

        Public ReadOnly Property Capabilities() As MultifunctionCalibratorCapabilities
            Get
                Return Me._Capabilities
            End Get
        End Property

#End Region

#Region "Methods"

        Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal secondaryAddress As Byte, Optional ByVal simulate As Boolean = False)
            MyBase.New(boardAddress, primaryAddress, secondaryAddress, simulate)
            Me._Sections = New MultifunctionCalibratorectionsSection(Me)
        End Sub

#End Region

#Region "Functions"

#End Region

    End Class


