'
' Created by SharpDevelop.
' User: rspage
' Date: 6/21/2005
' Time: 7:36 AM
' 

Public Class CounterFrequencySection

    Protected _MainCounter As Counter

    Public Sub New(ByRef MainCounter As Counter)
        _MainCounter = MainCounter
    End Sub

    Public Sub Automatic()
        _MainCounter.Write(_MainCounter.Commands.FrequencyModeAuto)
    End Sub

End Class
