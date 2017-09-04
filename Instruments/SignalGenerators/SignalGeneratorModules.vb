'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/14/2005
' Time: 6:40 PM
' 

Imports System
Imports FreeCal.Common
Imports FreeCal.Instruments
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Module SignalGeneratorFunctions

		Public Function GetNewSignalGenerator(ByVal signalGeneratorClass As SignalGeneratorEnum, ByVal boardNumber As Integer, ByVal primaryAddress As Byte, ByVal getSettingsFromInstrument As Boolean) As SignalGenerator
        Select Case SignalGeneratorClass
            Case SignalGeneratorEnum.Agilent8340A
                Return New Agilent8340A(BoardNumber, PrimaryAddress, GetSettingsFromInstrument)
            Case SignalGeneratorEnum.Agilent8660D
                Return New Agilent8660D(BoardNumber, PrimaryAddress, GetSettingsFromInstrument)
            Case SignalGeneratorEnum.AgilentE4433B
                Return New AgilentE4433B(BoardNumber, PrimaryAddress, GetSettingsFromInstrument)
            Case SignalGeneratorEnum.AnritsuMG3696A
                Return New AnritsuMG3696A(BoardNumber, PrimaryAddress, GetSettingsFromInstrument)
            Case SignalGeneratorEnum.IFR2050
                Return New IFR2050(BoardNumber, PrimaryAddress, GetSettingsFromInstrument)
        End Select
        Return Nothing
    End Function

	End Module


