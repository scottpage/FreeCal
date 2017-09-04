'
' Created by SharpDevelop.
' User: rspage
' Date: 6/30/2005
' Time: 8:51 AM
' 



Imports System
Imports FreeCal.Common

Public Class ConvertAmplitude

    Public Sub New()
    End Sub

    Public Shared Function FromWattTodBm(ByVal originalAmplitude As Double) As Double
        Return CDbl(10 * Math.Log10(originalAmplitude / 0.001))
    End Function

    Public Shared Function FromdBmToWatt(ByVal originalAmplitude As Double) As Double
        Return CDbl((10 ^ (originalAmplitude / 10)) / 1000)
    End Function

    Public Shared Function FromMilliWattTodBm(ByVal originalAmplitude As Double) As Double
        Return CDbl(10 ^ (originalAmplitude / 10))
    End Function

    Public Shared Function FromdBmToMilliWatt(ByVal originalAmplitude As Double) As Double
        Return CDbl(10 * Math.Log10(originalAmplitude))
    End Function

    Public Shared Function Convert(ByVal amplitudeSetting As Double, ByVal amplitudeSettingSuffix As AmplitudeEnum, ByVal desiredAmplitudeSuffix As AmplitudeEnum) As Double
        Dim NewAmplitudeSetting As Double = amplitudeSetting
        Select Case amplitudeSettingSuffix
            Case AmplitudeEnum.dBm
                Select Case desiredAmplitudeSuffix
                    Case AmplitudeEnum.dBmW
                    Case AmplitudeEnum.mW
                        NewAmplitudeSetting = CDbl(10 * Math.Log10(NewAmplitudeSetting))
                    Case AmplitudeEnum.W
                        NewAmplitudeSetting = CDbl((10 ^ (NewAmplitudeSetting / 10)) / 1000)
                End Select
            Case AmplitudeEnum.dBmW
                Select Case desiredAmplitudeSuffix
                    Case AmplitudeEnum.dBm
                    Case AmplitudeEnum.mW
                    Case AmplitudeEnum.W
                End Select
            Case AmplitudeEnum.mW
                Select Case desiredAmplitudeSuffix
                    Case AmplitudeEnum.dBm
                        NewAmplitudeSetting = CDbl(10 ^ (NewAmplitudeSetting / 10))
                    Case AmplitudeEnum.dBmW
                    Case AmplitudeEnum.W
                        NewAmplitudeSetting = NewAmplitudeSetting * 1000
                End Select
            Case AmplitudeEnum.W
                Select Case desiredAmplitudeSuffix
                    Case AmplitudeEnum.dBm
                        NewAmplitudeSetting = CDbl(10 * Math.Log10(NewAmplitudeSetting / 0.001))
                    Case AmplitudeEnum.dBmW
                    Case AmplitudeEnum.mW
                        NewAmplitudeSetting = NewAmplitudeSetting / 1000
                End Select
        End Select
        Return NewAmplitudeSetting
    End Function

End Class

