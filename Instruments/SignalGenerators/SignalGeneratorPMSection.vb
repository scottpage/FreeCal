'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/11/2005
' Time: 7:31 AM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class SignalGeneratorPMSection

        Protected _MainSignalGenerator As SignalGenerator

        Public Sub New(ByRef MainSignalGenerator As SignalGenerator)
            Me._MainSignalGenerator = MainSignalGenerator
        End Sub

    End Class


