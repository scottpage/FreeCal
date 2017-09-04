'
' Created by SharpDevelop.
' User: rspage
' Date: 6/23/2005
' Time: 8:37 AM
' 



Imports System
Imports System.Data
Imports MySql.Data.MySqlClient
Imports FreeCal.Common

Public Class StandardCharacterizationDataTable
    Inherits System.Data.DataTable

    Protected _AssetNumber As String

    Public ReadOnly Property AssetNumber() As String
        Get
            Return Me._AssetNumber
        End Get
    End Property

    Public Sub New(ByVal assetNumber As String)
        MyBase.New(assetNumber)
        Me.AddMainColumns()
    End Sub

    Private Sub AddMainColumns()
        Me.Columns.Add("RowID")
        Me.Columns.Add("AssetNumber")
        Me.Columns.Add("Model")
    End Sub

End Class

