'
' Created by SharpDevelop.
' User: rspage
' Date: 6/23/2005
' Time: 9:03 AM
' 



Imports System.Data
Imports FreeCal.Common

Public Class PowerSplitterDataTable
    Inherits StandardCharacterizationDataTable

    Private _Parameters As MySqlParameterCollection
    Private _DataAdapter As New MySqlDataAdapter

    Public Sub New(ByVal assetNumber As String)
        MyBase.New(assetNumber)
        Me.AddColumns()
        Me.AddPowerSplitterDataAdapter()
        Me._DataAdapter.Fill(Me)
    End Sub

    Private Sub AddColumns()
        Me.Columns.Add(New DataColumn("FrequencyGHz"))
        Me.Columns.Add(New DataColumn("Port2Magnitude"))
        Me.Columns.Add(New DataColumn("Port2Phase"))
        Me.Columns.Add(New DataColumn("Port3Magnitude"))
        Me.Columns.Add(New DataColumn("Port3Phase"))
    End Sub

    Private Sub AddPowerSplitterDataAdapter()
        Me._DataAdapter.SelectCommand = New MySqlCommand("SELECT * FROM powersplitters WHERE AssetNumber='" & Me._AssetNumber & "';", DBConnection)
        Me._DataAdapter.SelectCommand.Parameters.Add("?RowID", MySqlDbType.Int16, 45, "RowID")
        Me._DataAdapter.SelectCommand.Parameters.Add("?AssetNumber", MySqlDbType.String, 45, "AssetNumber")
        Me._DataAdapter.SelectCommand.Parameters.Add("?Model", MySqlDbType.String, 45, "Model")
        Me._DataAdapter.SelectCommand.Parameters.Add("?FrequencyGHz", MySqlDbType.Float, 45, "AssetNumber")
        Me._DataAdapter.SelectCommand.Parameters.Add("?Port2Magnitude", MySqlDbType.Float, 45, "Port2Magnitude")
        Me._DataAdapter.SelectCommand.Parameters.Add("?Port2Phase", MySqlDbType.Float, 45, "Port2Phase")
        Me._DataAdapter.SelectCommand.Parameters.Add("?Port3Magnitude", MySqlDbType.Float, 45, "Port3Magnitude")
        Me._DataAdapter.SelectCommand.Parameters.Add("?Port3Phase", MySqlDbType.Float, 45, "Port3Phase")
        Me._DataAdapter.UpdateCommand = New MySqlCommand("UPDATE powersplitters WHERE RowID=?RowID AND AssetNumber=?AssetNumber;", DBConnection)
        Me._DataAdapter.UpdateCommand.Parameters.Add("?RowID", MySqlDbType.Int16, 45, "RowID")
        Me._DataAdapter.UpdateCommand.Parameters.Add("?AssetNumber", MySqlDbType.String, 45, "AssetNumber")
        Me._DataAdapter.UpdateCommand.Parameters.Add("?Model", MySqlDbType.String, 45, "Model")
        Me._DataAdapter.UpdateCommand.Parameters.Add("?FrequencyGHz", MySqlDbType.Float, 45, "AssetNumber")
        Me._DataAdapter.UpdateCommand.Parameters.Add("?Port2Magnitude", MySqlDbType.Float, 45, "Port2Magnitude")
        Me._DataAdapter.UpdateCommand.Parameters.Add("?Port2Phase", MySqlDbType.Float, 45, "Port2Phase")
        Me._DataAdapter.UpdateCommand.Parameters.Add("?Port3Magnitude", MySqlDbType.Float, 45, "Port3Magnitude")
        Me._DataAdapter.UpdateCommand.Parameters.Add("?Port3Phase", MySqlDbType.Float, 45, "Port3Phase")
        Me._DataAdapter.DeleteCommand = New MySqlCommand("DELETE FROM powersplitters WHERE RowID=?RowID;", DBConnection)
        Me._DataAdapter.DeleteCommand.Parameters.Add("?RowID", MySqlDbType.Int16, 45, "RowID")
        Me._DataAdapter.DeleteCommand.Parameters.Add("?AssetNumber", MySqlDbType.String, 45, "AssetNumber")
        Me._DataAdapter.DeleteCommand.Parameters.Add("?Model", MySqlDbType.String, 45, "Model")
        Me._DataAdapter.DeleteCommand.Parameters.Add("?FrequencyGHz", MySqlDbType.Float, 45, "AssetNumber")
        Me._DataAdapter.DeleteCommand.Parameters.Add("?Port2Magnitude", MySqlDbType.Float, 45, "Port2Magnitude")
        Me._DataAdapter.DeleteCommand.Parameters.Add("?Port2Phase", MySqlDbType.Float, 45, "Port2Phase")
        Me._DataAdapter.DeleteCommand.Parameters.Add("?Port3Magnitude", MySqlDbType.Float, 45, "Port3Magnitude")
        Me._DataAdapter.DeleteCommand.Parameters.Add("?Port3Phase", MySqlDbType.Float, 45, "Port3Phase")
        Me._DataAdapter.InsertCommand = New MySqlCommand("INSERT INTO powersplitters (Model, AssetNumber, FrequencyGHz, Port2Magnitude, Port2Phase, Port3Magnitude, Port3Phase) VALUES (Model=?Model, AssetNumber=?AssetNumber, FrequencyGHz=?FrequencyGHz, Port2Magnitude=?Port2Magnitude, Port2Phase=?Port2Phase, Port3Magnitude=?Port3Magnitude, Port3Phase=?Port3Phase;", DBConnection)
        Me._DataAdapter.InsertCommand.Parameters.Add("?RowID", MySqlDbType.Int16, 45, "RowID")
        Me._DataAdapter.InsertCommand.Parameters.Add("?AssetNumber", MySqlDbType.String, 45, "AssetNumber")
        Me._DataAdapter.InsertCommand.Parameters.Add("?Model", MySqlDbType.String, 45, "Model")
        Me._DataAdapter.InsertCommand.Parameters.Add("?FrequencyGHz", MySqlDbType.Float, 45, "AssetNumber")
        Me._DataAdapter.InsertCommand.Parameters.Add("?Port2Magnitude", MySqlDbType.Float, 45, "Port2Magnitude")
        Me._DataAdapter.InsertCommand.Parameters.Add("?Port2Phase", MySqlDbType.Float, 45, "Port2Phase")
        Me._DataAdapter.InsertCommand.Parameters.Add("?Port3Magnitude", MySqlDbType.Float, 45, "Port3Magnitude")
        Me._DataAdapter.InsertCommand.Parameters.Add("?Port3Phase", MySqlDbType.Float, 45, "Port3Phase")
    End Sub

End Class

