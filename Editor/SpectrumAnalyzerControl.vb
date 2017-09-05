'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/24/2005
' Time: 3:40 PM
'

Imports FreeCal.Instruments.SpectrumAnalyzers

Public Class SpectrumAnalyzerControl
    Inherits FreeCal.Editor.InstrumentControl

    Public Sub New(ByVal model As String, ByVal primaryAddress As Byte)
        MyBase.New
        Me._InstrumentType = InstrumentTypeEnum.SpectrumAnalyzer
        Select Case model.ToLower
            Case "agilent8564ec"
                Me._Instrument = New Agilent8564EC(0, primaryAddress, False)
        End Select
        Me._PaintInformation = Me.Instrument.Sections.Frequency.ToString
    End Sub

    Public Shadows ReadOnly Property Instrument As SpectrumAnalyzer
        Get
            Return CType(Me._Instrument, SpectrumAnalyzer)
        End Get
    End Property

End Class



