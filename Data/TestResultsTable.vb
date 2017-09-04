'
' Created by SharpDevelop.
' User: rspage
' Date: 6/23/2005
' Time: 1:37 PM
' 

Imports System.Data
Imports FreeCal.Common

Public Class TestResultsTable
    Inherits System.Data.DataTable

    Protected _DataAdapter As New MySqlDataAdapter
    Protected _AssetNumber As String

    Public Overridable Property AssetNumber As String
        Get
            Return Me._AssetNumber
        End Get
        Set
            Me._AssetNumber = Value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        Me.AddMainColumns()
    End Sub

    Public Sub New(ByVal assetNumber As String)
        MyBase.New(assetNumber)
        Me.AssetNumber = assetNumber
        Me.AddMainColumns()
    End Sub

    Private Sub AddMainColumns()
        Me.Columns.Add(New DataColumn("AssetNumber"))
        Me.Columns.Add(New DataColumn("TestTitle"))
        Me.Columns.Add(New DataColumn("Result"))
        Me._DataAdapter.InsertCommand = New MySqlCommand("", DBConnection)
        Me._DataAdapter.InsertCommand.Parameters.Add("?AssetNumber", MySqlDbType.String, 45, "AssetNumber")
        Me._DataAdapter.InsertCommand.Parameters.Add("?TestTitle", MySqlDbType.String, 45, "TestTitle")
        Me._DataAdapter.InsertCommand.Parameters.Add("?Result", MySqlDbType.String, 45, "Result")
    End Sub

End Class

