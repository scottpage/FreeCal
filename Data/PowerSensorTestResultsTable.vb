'
' Created by SharpDevelop.
' User: rspage
' Date: 6/23/2005
' Time: 2:12 PM
' 

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
Imports System.Windows.Forms
Imports FreeCal.Conversion

Public Class PowerSensorTestResultsTable
    Inherits FreeCal.Data.TestResultsTable

    Public SourceAssetNumber As String
    Public StandardDUTPowerMeterAssetNumber As String
    Public ReferencePowerMeterAssetNumber As String
    Public PowerSplitterAssetNumber As String
    Public StandardSensorAssetNumber As String
    Public ReferenceSensorAssetNumber As String
    Protected _OldDUTCalibrationFactors As PowerSensorTestResultsTable
    Protected _UseOldDUTCalibrationFactors As Boolean = False

    Public ReadOnly Property UseOldDUTCalibrationFactors() As Boolean
        Get
            Return Me._UseOldDUTCalibrationFactors
        End Get
    End Property

    Public Property OldDUTCalibrationFactors() As PowerSensorTestResultsTable
        Get
            Return Me._OldDUTCalibrationFactors
        End Get
        Set(ByVal Value As PowerSensorTestResultsTable)
            If Value.Rows.Count > 0 Then
                Me._OldDUTCalibrationFactors = Value
                Me._UseOldDUTCalibrationFactors = True
            End If
        End Set
    End Property

    Public Sub New(ByVal assetNumber As String)
        MyBase.New(assetNumber)
        Me.AddColumns()
    End Sub

    Private Sub AddColumns()
        Me.Columns.Add(New DataColumn("SourceAssetNumber"))
        Me.Columns.Add(New DataColumn("StandardDUTPowerMeterAssetNumber"))
        Me.Columns.Add(New DataColumn("ReferencePowerMeterAssetNumber"))
        Me.Columns.Add(New DataColumn("PowerSplitterAssetNumber"))
        Me.Columns.Add(New DataColumn("StandardSensorAssetNumber"))
        Me.Columns.Add(New DataColumn("ReferenceSensorAssetNumber"))
        Me.Columns.Add(New DataColumn("FrequencyGHz"))
        Me.Columns.Add(New DataColumn("CalibrationFactor"))
        Me.Columns.Add(New DataColumn("Date"))
        Me._DataAdapter.InsertCommand = New MySqlCommand("INSERT INTO powersensortestresults (AssetNumber, TestTitle, FrequencyGHz, CalibrationFactor) VALUES (?AssetNumber, ?TestTitle, ?FrequencyGHz, ?CalibrationFactor);", DBConnection)
        Me._DataAdapter.InsertCommand.Parameters.Add("?AssetNumber", MySqlDbType.String, 45, "AssetNumber")
        Me._DataAdapter.InsertCommand.Parameters.Add("?TestTitle", MySqlDbType.String, 45, "TestTitle")
        Me._DataAdapter.InsertCommand.Parameters.Add("?Result", MySqlDbType.String, 45, "Result")
        Me._DataAdapter.InsertCommand.Parameters.Add("?FrequencyGHz", MySqlDbType.Float, 45, "FrequencyGHz")
        Me._DataAdapter.InsertCommand.Parameters.Add("?CalibrationFactor", MySqlDbType.Float, 45, "CalibrationFactor")

    End Sub

    Public Sub StoreResult(ByVal testTitle As String, ByVal testFrequency As Double, ByVal frequencySuffix As FrequencyEnum, ByVal calibrationFactor As Double)
        Dim NewFrequency As Double = ConvertFrequency.Convert(testFrequency, frequencySuffix, FrequencyEnum.GHz)
        Dim NewDR As DataRow = Me.NewRow
        NewDR("AssetNumber") = Me._AssetNumber
        NewDR("TestTitle") = testTitle
        NewDR("FrequencyGHz") = NewFrequency
        NewDR("CalibrationFactor") = calibrationFactor
        If Me.UseOldDUTCalibrationFactors Then
            If (calibrationFactor <= Me.GetOldCalibrationFactor(NewFrequency) + 2 And calibrationFactor >= Me.GetOldCalibrationFactor(NewFrequency) - 2) Then
                NewDR("Result") = "Pass"
            Else
                NewDR("Result") = "Fail"
            End If
        Else
            NewDR("Result") = "No Previous Data"
        End If
        NewDR("Date") = DateTime.Now.Year & "-" & DateTime.Now.Month & "-" & DateTime.Now.Day
        Me.Rows.Add(NewDR)
        Try
            If (DBConnection.State = ConnectionState.Closed) Then
                DBConnection.Open()
            End If
            Me._DataAdapter.Update(Me)
        Catch Ex As Exception
            MessageBox.Show(Ex.ToString)
        Finally
            If (Not DBConnection.State = ConnectionState.Open) Then
                DBConnection.Close()
            End If
        End Try
    End Sub

    Private Function GetOldCalibrationFactor(ByVal searchFrequency As Double) As Double
        For Each DR As DataRow In Me._OldDUTCalibrationFactors.Rows
            If Convert.ToDouble(DR("FrequencyGHz")) = searchFrequency Then
                Return Convert.ToDouble(DR("CalibrationFactor"))
            End If
        Next
        Return 0
    End Function

    Public Shared Function GetOldCalibrationResults(ByVal searchAssetNumber As String, ByVal calibrationDate As Date) As PowerSensorTestResultsTable
        Dim DA As New MySqlDataAdapter
        Dim OldCalResultsCmd As New MySqlCommand("Select * FROM powersensortestresults WHERE AssetNumber='" & searchAssetNumber & "' And Date='" & calibrationDate.Year & "-" & calibrationDate.Month & "-" & calibrationDate.Day & "';", DBConnection)
        DA.SelectCommand = OldCalResultsCmd
        Dim DT As New PowerSensorTestResultsTable(searchAssetNumber)
        If (DA.SelectCommand.Connection.State <> ConnectionState.Open) Then
            DA.SelectCommand.Connection.Open()
        End If
        DA.Fill(DT)
        Return DT
    End Function

End Class


