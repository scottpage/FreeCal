'
' Created by SharpDevelop.
' User: rspage
' Date: 6/24/2005
' Time: 2:56 PM
' 

Imports System.ComponentModel
Imports Microsoft.VisualBasic.ControlChars


<TypeConverter(GetType(ExpandableObjectConverter))>
Public Class PowerMeterMemorySection

    Protected _MainPowerMeter As PowerMeter

    Public Sub New(ByRef mainPowerMeter As PowerMeter)
        Me._MainPowerMeter = mainPowerMeter
    End Sub

    Public Function GetCalibrationFactorTableNames() As String()
        Dim TableNames As New List(Of String)
        _MainPowerMeter.Write("MEM:CAT:TABL?")
        Dim strTables As String = _MainPowerMeter.ReadString
        Dim Tables() As String = strTables.Split(","c)
        For TableNumber As Integer = 2 To 89 Step 3
            TableNames.Add(Tables(TableNumber).Replace(Quote, ""))
        Next
        Return TableNames.ToArray
    End Function

    Public Sub SelectTable(ByVal tableName As String)
        'TODO:  Find out what this was meant for
    End Sub

End Class


