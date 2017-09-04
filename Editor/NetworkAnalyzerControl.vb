'
' Created by SharpDevelop.
' User: rspage
' Date: 7/18/2005
' Time: 8:28 AM
' 

Imports System
Imports System.ComponentModel
Imports FreeCal.Instruments.NetworkAnalyzers
Imports System.Windows.Forms
Imports System.Drawing
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports Microsoft.VisualBasic.ControlChars



	Public Class NetworkAnalyzerControl
		Inherits FreeCal.Editor.InstrumentControl

		Public Sub New(ByVal model As String, ByVal primaryAddress As String)
			MyBase.New
			Me._InstrumentType = InstrumentTypeEnum.NetworkAnalyzer
			Select model.ToLower
				Case "agilent8510c"
					Me._Instrument = New Agilent8510C(0, primaryAddress, False)
			End Select
			Me._PaintInformation = Me.Instrument.Sections.Stimulus.ToString
		End Sub

		Public Shadows ReadOnly Property Instrument As NetworkAnalyzer
			Get
				Return CType(Me._Instrument, NetworkAnalyzer)
			End Get
		End Property

	End Class

