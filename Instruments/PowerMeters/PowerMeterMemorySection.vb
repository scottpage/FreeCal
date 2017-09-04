'
' Created by SharpDevelop.
' User: rspage
' Date: 6/24/2005
' Time: 2:56 PM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.Windows.Forms
Imports System.Threading
Imports System.Collections
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class PowerMeterMemorySection

		Protected _MainPowerMeter As PowerMeter

        Public Sub New(ByRef mainPowerMeter As PowerMeter)
            Me._MainPowerMeter = mainPowerMeter
        End Sub

		Public Function GetCalibrationFactorTableNames As String()
			Dim TableNames As New ArrayList
			Me._MainPowerMeter.Write("MEM:CAT:TABL?")
			Dim strTables As String = Me._MainPowerMeter.ReadString
			Dim Tables() As String = strTables.Split(",")
			For TableNumber As Integer = 2 To 89 Step 3
				TableNames.Add(Tables(TableNumber).Replace(Quote, ""))
			Next
			Dim TN(TableNames.Count - 1) As String
			For I As Integer = 0 To TableNames.Count - 1
				TN(I) = TableNames(I)
			Next
			Return TN
		End Function

		Public Sub SelectTable(ByVal tableName As String)
			
		End Sub

    End Class


