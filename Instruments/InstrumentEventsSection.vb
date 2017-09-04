'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/7/2005
' Time: 6:53 PM
'

Public Class InstrumentEventsSection
    Inherits InstrumentSection

    Public ReadOnly Property MessageAvailable As Boolean
			Get
            If _MainInstrument.SerialPoll = NationalInstruments.NI4882.SerialPollFlags.MessageAvailable Then
                Return True
            End If
        End Get
		End Property

		Public Sub New(ByRef mainInstrument As Instrument)
			MyBase.New(mainInstrument)
		End Sub

	End Class

