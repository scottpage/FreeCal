'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/14/2005
' Time: 4:48 AM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.Windows.Forms
Imports System.Collections
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class NetworkAnalyzerFormatSection

		Protected _MainNetworkAnalyzer As NetworkAnalyzer
		Protected _Current As NetworkAnalyzerFormatEnum

		Public Property Current As NetworkAnalyzerFormatEnum
			Get
				Return Me._Current
			End Get
			Set
				Me._Current = Value
				Select Value
					Case NetworkAnalyzerFormatEnum.Delay
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.DelayFormat)
					Case NetworkAnalyzerFormatEnum.Imaginary
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.ImaginaryFormat)
					Case NetworkAnalyzerFormatEnum.InvertedSmithChart
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.InvertedSmithChartFormat)
					Case NetworkAnalyzerFormatEnum.LinMag
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.LinMagFormat)
					Case NetworkAnalyzerFormatEnum.LogMag
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.LogMagFormat)
					Case NetworkAnalyzerFormatEnum.Phase
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.PhaseFormat)
					Case NetworkAnalyzerFormatEnum.Real
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.RealFormat)
					Case NetworkAnalyzerFormatEnum.SmithChart
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SmithChartFormat)
					Case NetworkAnalyzerFormatEnum.SWR
						Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SWRFormat)
				End Select
			End Set
		End Property

		Public Sub New(ByRef MainNetworkAnalyzer As NetworkAnalyzer)
			Me._MainNetworkAnalyzer = MainNetworkAnalyzer
		End Sub

	End Class


