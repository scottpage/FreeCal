'
' Created by SharpDevelop.
' User: rspage
' Date: 7/25/2005
' Time: 2:59 PM
' 

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports NationalInstruments.NI4882
Imports System.Windows.Forms
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public MustInherit Class IntervalAnalyzer
        Inherits FreeCal.Instruments.Instrument

		#Region "Declarations"

        Protected _Commands As IntervalAnalyzerGPIBCommands
        Protected _Specifications As IntervalAnalyzerSpecifications
        Protected _Capabilities As IntervalAnalyzerCapabilities
        Protected _TestPoints As IntervalAnalyzerTestPoints
		Protected _Sections As IntervalAnalyzerSectionsSection

		#End Region

		#Region "Properties"

		Public ReadOnly Property Sections As IntervalAnalyzerSectionsSection
			Get
				Return Me._Sections
			End Get
		End Property

		Public ReadOnly Property TestPoints As IntervalAnalyzerTestPoints
			Get
				Return Me._TestPoints
			End Get
		End Property

		Public ReadOnly Property Commands As IntervalAnalyzerGPIBCommands
			Get
				Return Me._Commands
			End Get
		End Property

		Public ReadOnly Property Specifications As IntervalAnalyzerSpecifications
			Get
				Return Me._Specifications
			End Get
		End Property

		Public ReadOnly Property Capabilities As IntervalAnalyzerCapabilities
			Get
				Return Me._Capabilities
			End Get
		End Property

		#End Region

		#Region "Methods"

        Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, GetSettingsFromInstrument, Simulate)
		    Me._Sections = New IntervalAnalyzerSectionsSection(Me)
		End Sub

		#End Region

		#Region "Functions"

		#End Region

	End Class


