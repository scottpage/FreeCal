'
' Created by SharpDevelop.
' User: rspage
' Date: 7/18/2005
' Time: 8:28 AM
' 

Imports FreeCal.Instruments.NetworkAnalyzers

Public Class NetworkAnalyzerControl
    Inherits InstrumentControl

    Public Sub New(ByVal model As String, ByVal primaryAddress As Byte)
        MyBase.New
        Me._InstrumentType = InstrumentTypeEnum.NetworkAnalyzer
        Select Case model.ToLower
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

