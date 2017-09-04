'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/13/2005
' Time: 6:42 PM
' 

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports NationalInstruments.NI4882
Imports System.Windows.Forms
Imports System.Collections
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public MustInherit Class NetworkAnalyzer
        Inherits FreeCal.Instruments.Instrument

		#Region "Declarations"

		Public Event FormClose
        Protected _Commands As NetworkAnalyzerGPIBCommands
        Protected _Specifications As NetworkAnalyzerSpecifications
        Protected _Capabilities As NetworkAnalyzerCapabilities
        Protected _TestPoints As NetworkAnalyzerTestPoints

		Protected _Sections As New NetworkAnalyzerSectionsSection(Me)

		#End Region

		#Region "Properties"

		Public ReadOnly Property TestPoints As NetworkAnalyzerTestPoints
			Get
				Return Me._TestPoints
			End Get
		End Property

		Public ReadOnly Property Sections As NetworkAnalyzerSectionsSection
			Get
				Return Me._Sections
			End Get
		End Property

		Public ReadOnly Property Commands As NetworkAnalyzerGPIBCommands
			Get
				Return Me._Commands
			End Get
		End Property

		Public ReadOnly Property Specifications As NetworkAnalyzerSpecifications
			Get
				Return Me._Specifications
			End Get
		End Property

		Public ReadOnly Property Capabilities As NetworkAnalyzerCapabilities
			Get
				Return Me._Capabilities
			End Get
		End Property

		#End Region

		#Region "Methods"

		Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, GetSettingsFromInstrument, Simulate)
		End Sub

		Public Sub DisplayDataCollectionForm
			Dim DCF As New NetworkAnalyzerDataCollectionForm(Me)
			AddHandler DCF.Closed, AddressOf Me.FormClosed
			DCF.Show
		End Sub

		Public Sub DisplayDataCollectionForm2
			Dim DCF As New AgilentNetworkAnalyzerForm(Me)
			AddHandler DCF.Closed, AddressOf Me.FormClosed
			DCF.Show
		End Sub

		Public Sub FormClosed(ByVal Sender As Object, ByVal E As EventArgs)
			RaiseEvent FormClose
		End Sub

		#End Region

		#Region "Functions"

		#End Region

	End Class


