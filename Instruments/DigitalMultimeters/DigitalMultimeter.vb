'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/28/2005
' Time: 8:24 PM
'

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports NationalInstruments.NI4882
Imports System.Windows.Forms
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public MustInherit Class DigitalMultimeter
        Inherits FreeCal.Instruments.Instrument

		#Region "Declarations"

        Protected _Commands As DigitalMultimeterGPIBCommands
        Protected _Specifications As DigitalMultimeterSpecifications
        Protected _Capabilities As DigitalMultimeterCapabilities
        Protected _TestPoints As DigitalMultimeterTestPoints
		Protected _Sections As DigitalMultimeterSectionsSection

		#End Region

		#Region "Properties"

		Public ReadOnly Property Sections As DigitalMultimeterSectionsSection
			Get
				Return Me._Sections
			End Get
		End Property

		Public ReadOnly Property TestPoints As DigitalMultimeterTestPoints
			Get
				Return Me._TestPoints
			End Get
		End Property

		Public ReadOnly Property Commands As DigitalMultimeterGPIBCommands
			Get
				Return Me._Commands
			End Get
		End Property

		Public ReadOnly Property Specifications As DigitalMultimeterSpecifications
			Get
				Return Me._Specifications
			End Get
		End Property

		Public ReadOnly Property Capabilities As DigitalMultimeterCapabilities
			Get
				Return Me._Capabilities
			End Get
		End Property

		#End Region

		#Region "Methods"

        Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal secondaryAddress As Byte, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, SecondaryAddress, Simulate)
			Me._Sections = New DigitalMultimeterSectionsSection(Me)
		End Sub

		Protected Friend Overridable Sub SetDCVoltageRange(ByVal setting As Double)
			If Not Me.Sections.Configure.Mode = DigitalMultimeterModeEnum.DCVolts Then
				Me.Sections.Configure.Mode = DigitalMultimeterModeEnum.DCVolts
			End If
			Me.Sections.Configure.DC._VoltRange = setting
			Me.Write(Me._Commands.DCVoltRange & setting)
		End Sub

		#End Region

		#Region "Functions"

		#End Region

	End Class


