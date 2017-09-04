'
' Created by SharpDevelop.
' User: rspage
' Date: 6/28/2005
' Time: 8:04 AM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.Windows.Forms
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class NetworkAnalyzerParameterSection

		Protected _MainNetworkAnalyzer As NetworkAnalyzer
		Protected _Current As NetworkAnalyzerParameterEnum

		Public Property Current As NetworkAnalyzerParameterEnum
			Get
				Return Me._Current
			End Get
			Set
				Me._Current = Value
				Select Value
					Case NetworkAnalyzerParameterEnum.S11
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.S11)
					Case NetworkAnalyzerParameterEnum.S12
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.S12)
					Case NetworkAnalyzerParameterEnum.S21
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.S21)
					Case NetworkAnalyzerParameterEnum.S22
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.S22)
				End Select
			End Set
		End Property

		Public Sub New(ByRef MainNetworkAnalyzer As NetworkAnalyzer)
			Me._MainNetworkAnalyzer = MainNetworkAnalyzer
		End Sub

	End Class

