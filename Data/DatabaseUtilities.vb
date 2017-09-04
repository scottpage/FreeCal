'
' Created by SharpDevelop.
' User: rspage
' Date: 6/23/2005
' Time: 7:06 AM
' 



Imports System
Imports System.Data
Imports MySql.Data.MySqlClient
Imports FreeCal.Common

Public Class DatabaseUtilities

    Public Sub New()
    End Sub

    Public Shared Sub CreateFreeCalDatabases()
        Try
            If (DBConnection.State = ConnectionState.Closed) Then
                DBConnection.Open()
            End If
            Dim MySqlCmd As MySqlCommand
            MySqlCmd = New MySqlCommand("CREATE TABLE IF NOT EXISTS `freecal`.`powersensors` (`RowID` INTEGER UNSIGNED NOT NULL AUTO_INCREMENT, `AssetNumber` VARCHAR(45) NOT NULL, `Model` VARCHAR(45) NOT NULL, `FrequencyGHz` FLOAT UNSIGNED NOT NULL, `CalibrationFactor` FLOAT UNSIGNED NOT NULL, PRIMARY KEY(`RowID`))TYPE = InnoDB;", DBConnection)
            MySqlCmd.ExecuteNonQuery()
            MySqlCmd = New MySqlCommand("CREATE TABLE IF NOT EXISTS `freecal`.`powersplitters` (`RowID` INTEGER UNSIGNED NOT NULL AUTO_INCREMENT, `AssetNumber` VARCHAR(45) NOT NULL, `Model` VARCHAR(45) NOT NULL, `FrequencyGHz` FLOAT UNSIGNED NOT NULL, `Port2Magnitude` FLOAT UNSIGNED NOT NULL, `Port2Phase` FLOAT SIGNED NOT NULL, `Port3Magnitude` FLOAT UNSIGNED NOT NULL, `Port3Phase` FLOAT SIGNED NOT NULL, PRIMARY KEY(`RowID`))TYPE = InnoDB;", DBConnection)
            MySqlCmd.ExecuteNonQuery()
            MySqlCmd = New MySqlCommand("CREATE TABLE IF NOT EXISTS `freecal`.`directionalcouplers` (`RowID` INTEGER UNSIGNED NOT NULL AUTO_INCREMENT, `AssetNumber` VARCHAR(45) NOT NULL, `Model` VARCHAR(45) NOT NULL, `FrequencyGHz` FLOAT UNSIGNED NOT NULL, `ForwardInsertionLoss` FLOAT UNSIGNED NOT NULL, `ReverseInsertionLoss` FLOAT SIGNED NOT NULL, `CouplerLoss` FLOAT SIGNED NOT NULL, PRIMARY KEY(`RowID`))TYPE = InnoDB;", DBConnection)
            MySqlCmd.ExecuteNonQuery()
            MySqlCmd = New MySqlCommand("CREATE TABLE IF NOT EXISTS `freecal`.`powersensortestresults` (`RowID` INTEGER UNSIGNED NOT NULL AUTO_INCREMENT, `AssetNumber` VARCHAR(45) NOT NULL, `TestTitle` VARCHAR(45) NOT NULL, `FrequencyGHz` FLOAT UNSIGNED NOT NULL, `CalibrationFactor` FLOAT UNSIGNED NOT NULL, `Result` VARCHAR(45) NOT NULL, `Date` DATE NOT NULL, PRIMARY KEY(`RowID`))TYPE = InnoDB;", DBConnection)
            MySqlCmd.ExecuteNonQuery()
        Catch
        Finally
            If (DBConnection.State = ConnectionState.Open) Then
                DBConnection.Close()
            End If
        End Try
    End Sub

    Public Shared Function GetTableNames() As DataTable
        Dim DT As New DataTable("FreeCal Tables")
        Try
            If (DBConnection.State = ConnectionState.Closed) Then
                DBConnection.Open()
            End If
            Dim DA As New MySqlDataAdapter
            DA.SelectCommand = New MySqlCommand("SHOW TABLES;", DBConnection)
            DA.SelectCommand.ExecuteNonQuery()
            DA.Fill(DT)
        Catch
        Finally
            If (DBConnection.State = ConnectionState.Open) Then
                DBConnection.Close()
            End If
        End Try
        Return DT
    End Function

    Public Shared Function GetTableDetails(ByVal tableName As String) As DataTable
        Dim DT As New DataTable(tableName & " Details")
        Try
            If (DBConnection.State = ConnectionState.Closed) Then
                DBConnection.Open()
            End If
            Dim DA As New MySqlDataAdapter
            DA.SelectCommand = New MySqlCommand("DESCRIBE " & tableName & ";", DBConnection)
            DA.SelectCommand.ExecuteNonQuery()
            DA.Fill(DT)
        Catch
        Finally
            If (DBConnection.State = ConnectionState.Open) Then
                DBConnection.Close()
            End If
        End Try
        Return DT
    End Function

    Public Shared Function GetTableRecords(ByVal tableName As String) As DataTable
        Dim DT As New DataTable(tableName & " Records")
        Try
            If (DBConnection.State = ConnectionState.Closed) Then
                DBConnection.Open()
            End If
            Dim DA As New MySqlDataAdapter
            DA.SelectCommand = New MySqlCommand("SELECT * FROM " & tableName & ";", DBConnection)
            DA.SelectCommand.ExecuteNonQuery()
            DA.Fill(DT)
        Catch
        Finally
            If (DBConnection.State = ConnectionState.Open) Then
                DBConnection.Close()
            End If
        End Try
        Return DT
    End Function

    Public Shared Function GetTableRecords(ByVal tableName As String, ByVal assetNumber As String) As DataTable
        Dim DT As New DataTable(tableName & " Records")
        Try
            If (DBConnection.State = ConnectionState.Closed) Then
                DBConnection.Open()
            End If
            Dim DA As New MySqlDataAdapter
            DA.SelectCommand = New MySqlCommand("SELECT * FROM " & tableName & " WHERE AssetNumber='" & assetNumber & "';", DBConnection)
            DA.SelectCommand.ExecuteNonQuery()
            DA.Fill(DT)
        Catch
        Finally
            If (DBConnection.State = ConnectionState.Open) Then
                DBConnection.Close()
            End If
        End Try
        Return DT
    End Function

    Public Shared Function DeleteTableRecords(ByVal tableName As String, ByVal assetNumber As String) As DataTable
        Dim DT As DataTable = Nothing
        Try
            If (DBConnection.State = ConnectionState.Closed) Then
                DBConnection.Open()
            End If
            Dim DA As New MySqlDataAdapter
            DA.DeleteCommand = New MySqlCommand("DELETE FROM " & tableName & " WHERE AssetNumber='" & assetNumber & "';", DBConnection)
            DA.DeleteCommand.ExecuteNonQuery()
            DT = GetTableRecords(tableName, assetNumber)
        Catch
        Finally
            If (DBConnection.State = ConnectionState.Open) Then
                DBConnection.Close()
            End If
        End Try
        Return DT
    End Function

End Class

