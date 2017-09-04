'
' Created by SharpDevelop.
' User: rspage
' Date: 6/23/2005
' Time: 1:37 PM
' 

Imports System
Imports System.Data
Imports MySql.Data.MySqlClient
Imports FreeCal.Common
Imports FreeCal.Conversion

Public Class CounterTestResultsTable
    Inherits FreeCal.Data.TestResultsTable

    Public Sub New(ByVal assetNumber As String)
        MyBase.New(assetNumber)
        Me.AddColumns()
    End Sub

    Private Sub AddColumns()
        Me.Columns.Add(New DataColumn("TestParameters"))
        Me.Columns.Add(New DataColumn("LowerTolerance"))
        Me.Columns.Add(New DataColumn("UpperTolerance"))
        Me.Columns.Add(New DataColumn("Measurement"))
        Me.Columns.Add(New DataColumn("Result"))
        Me.Columns.Add(New DataColumn("FrequencyGHz"))
        Me.Columns.Add(New DataColumn("AmplitudedBm"))
        Me._DataAdapter.InsertCommand.CommandText = "INSERT INTO Countertestresults (AssetNumber, TestTitle, TestParameters, LowerTolerance, UpperTolerance, Measurement, Result, FrequencyGHz, AmplitudedBm) VALUES (?AssetNumber, ?TestTitle, ?TestParameters, ?LowerTolerance, ?UpperTolerance, ?Measurement, ?Result, ?FrequencyGHz, ?AmplitudedBm);"
        Me._DataAdapter.InsertCommand.Parameters.Add("?TestParameters", MySqlDbType.Float, 45, "TestParameters")
        Me._DataAdapter.InsertCommand.Parameters.Add("?LowerTolerance", MySqlDbType.Float, 45, "LowerTolerance")
        Me._DataAdapter.InsertCommand.Parameters.Add("?UpperTolerance", MySqlDbType.Float, 45, "UpperTolerance")
        Me._DataAdapter.InsertCommand.Parameters.Add("?Measurement", MySqlDbType.Float, 45, "Measurement")
        Me._DataAdapter.InsertCommand.Parameters.Add("?Result", MySqlDbType.String, 45, "Result")
        Me._DataAdapter.InsertCommand.Parameters.Add("?FrequencyGHz", MySqlDbType.String, 45, "FrequencyGHz")
        Me._DataAdapter.InsertCommand.Parameters.Add("?AmplitudedBm", MySqlDbType.String, 45, "AmplitudedBm")
    End Sub

    Public Sub StoreResult(ByVal testTitle As String, ByVal testParameters As String, ByVal lowerTolerance As Double, ByVal upperTolerance As Double, ByVal measurement As Double, ByVal frequencyGHz As Double, ByVal frequencySuffix As FrequencyEnum, ByVal amplitudedBm As Double)
        Try
            Dim NewFrequency As Double = ConvertFrequency.Convert(frequencyGHz, frequencySuffix, FrequencyEnum.GHz)
            Dim NewDR As DataRow = Me.NewRow
            NewDR("AssetNumber") = Me._AssetNumber
            NewDR("TestTitle") = testTitle
            NewDR("TestParameters") = testParameters
            NewDR("LowerTolerance") = lowerTolerance
            NewDR("UpperTolerance") = upperTolerance
            NewDR("Measurement") = measurement
            NewDR("FrequencyGHz") = NewFrequency
            NewDR("AmplitudedBm") = amplitudedBm
            If (measurement > upperTolerance Or measurement < lowerTolerance) Then
                NewDR("Result") = "Fail"
            Else
                NewDR("Result") = "Pass"
            End If
            Me.Rows.Add(NewDR)
            If (Not DBConnection.State = ConnectionState.Closed) Then
                DBConnection.Open()
            End If
            Me._DataAdapter.Update(Me)
        Catch
        Finally
            If (Not DBConnection.State = ConnectionState.Open) Then
                DBConnection.Close()
            End If
        End Try
    End Sub

End Class

