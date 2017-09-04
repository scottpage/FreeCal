'
' Created by SharpDevelop.
' User: rspage
' Date: 7/5/2005
' Time: 12:48 PM
' 

Imports System
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class ScalarNetworkAnalyzer
		Inherits FreeCal.Instruments.Instrument

		Protected _Sections As New ScalarNetworkAnalyzerSectionsSection(Me)

		Public ReadOnly Property Sections As ScalarNetworkAnalyzerSectionsSection
			Get
				Return Me._Sections
			End Get
		End Property

		Public Sub New(ByVal boardAddress As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean, Optional ByVal simulate As Boolean = False)
		    MyBase.New(BoardAddress, PrimaryAddress, GetSettingsFromInstrument, Simulate)
		End Sub

	End Class

