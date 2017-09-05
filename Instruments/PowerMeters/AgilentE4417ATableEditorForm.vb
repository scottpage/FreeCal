'
' Created by SharpDevelop.
' User: rspage
' Date: 6/20/2005
' Time: 2:05 PM
' 


Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports FreeCal.Instruments.PowerMeters
Imports System.Data
Imports Microsoft.VisualBasic.ControlChars



Public Class AgilentE4417ATableEditorForm
    Inherits System.Windows.Forms.Form

    Private WithEvents btnClearAllTables As System.Windows.Forms.Button
    Private WithEvents tbNewTableName As System.Windows.Forms.TextBox
    Private WithEvents dgData As System.Windows.Forms.DataGrid
    Private WithEvents tbReferenceCF As System.Windows.Forms.TextBox
    Private WithEvents btnRename As System.Windows.Forms.Button
    Private WithEvents btnUpload As System.Windows.Forms.Button
    Private WithEvents lstbTables As System.Windows.Forms.ListBox
    Private WithEvents btnNewTable As System.Windows.Forms.Button
    Private WithEvents btnDownload As System.Windows.Forms.Button

    Private PwrMtr As AgilentE4417A

    Public Sub New(ByVal parent As Form)
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.MdiParent = parent
        Me.PwrMtr = New AgilentE4417A(0, 13, False)
        Me.GetTableNames()
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.btnNewTable = New System.Windows.Forms.Button()
        Me.lstbTables = New System.Windows.Forms.ListBox()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.btnRename = New System.Windows.Forms.Button()
        Me.tbReferenceCF = New System.Windows.Forms.TextBox()
        Me.dgData = New System.Windows.Forms.DataGrid()
        Me.tbNewTableName = New System.Windows.Forms.TextBox()
        Me.btnClearAllTables = New System.Windows.Forms.Button()
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDownload
        '
        Me.btnDownload.Location = New System.Drawing.Point(800, 15)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(150, 42)
        Me.btnDownload.TabIndex = 1
        Me.btnDownload.Text = "Download"
        '
        'btnNewTable
        '
        Me.btnNewTable.Location = New System.Drawing.Point(1280, 207)
        Me.btnNewTable.Name = "btnNewTable"
        Me.btnNewTable.Size = New System.Drawing.Size(150, 42)
        Me.btnNewTable.TabIndex = 8
        Me.btnNewTable.Text = "New Table"
        '
        'lstbTables
        '
        Me.lstbTables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstbTables.ItemHeight = 25
        Me.lstbTables.Location = New System.Drawing.Point(960, 0)
        Me.lstbTables.Name = "lstbTables"
        Me.lstbTables.Size = New System.Drawing.Size(254, 1029)
        Me.lstbTables.TabIndex = 3
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(800, 74)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(150, 42)
        Me.btnUpload.TabIndex = 2
        Me.btnUpload.Text = "Upload"
        '
        'btnRename
        '
        Me.btnRename.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRename.Location = New System.Drawing.Point(1278, 59)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(150, 43)
        Me.btnRename.TabIndex = 6
        Me.btnRename.Text = "Rename"
        '
        'tbReferenceCF
        '
        Me.tbReferenceCF.Location = New System.Drawing.Point(800, 148)
        Me.tbReferenceCF.Name = "tbReferenceCF"
        Me.tbReferenceCF.Size = New System.Drawing.Size(144, 31)
        Me.tbReferenceCF.TabIndex = 9
        '
        'dgData
        '
        Me.dgData.AllowSorting = False
        Me.dgData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgData.DataMember = ""
        Me.dgData.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgData.Location = New System.Drawing.Point(16, 15)
        Me.dgData.Name = "dgData"
        Me.dgData.Size = New System.Drawing.Size(768, 1066)
        Me.dgData.TabIndex = 0
        '
        'tbNewTableName
        '
        Me.tbNewTableName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbNewTableName.Location = New System.Drawing.Point(1230, 15)
        Me.tbNewTableName.Name = "tbNewTableName"
        Me.tbNewTableName.Size = New System.Drawing.Size(256, 31)
        Me.tbNewTableName.TabIndex = 5
        '
        'btnClearAllTables
        '
        Me.btnClearAllTables.Location = New System.Drawing.Point(1264, 783)
        Me.btnClearAllTables.Name = "btnClearAllTables"
        Me.btnClearAllTables.Size = New System.Drawing.Size(192, 42)
        Me.btnClearAllTables.TabIndex = 7
        Me.btnClearAllTables.Text = "Clear All Tables"
        '
        'AgilentE4417ATableEditorForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(1502, 1090)
        Me.Controls.Add(Me.tbReferenceCF)
        Me.Controls.Add(Me.btnNewTable)
        Me.Controls.Add(Me.btnClearAllTables)
        Me.Controls.Add(Me.btnRename)
        Me.Controls.Add(Me.tbNewTableName)
        Me.Controls.Add(Me.lstbTables)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.btnDownload)
        Me.Controls.Add(Me.dgData)
        Me.Name = "AgilentE4417ATableEditorForm"
        Me.Text = "MainForm"
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub GetTableNames()
        Me.lstbTables.Items.Clear()
        Me.PwrMtr.Write("MEM:CAT:TABL?")
        Dim strTables As String = Me.PwrMtr.ReadString
        Dim Tables() As String = strTables.Split(","c)
        For TableNumber As Integer = 2 To 89 Step 3
            Me.lstbTables.Items.Add(Tables(TableNumber).Replace(Quote, ""))
        Next
        Me.lstbTables.SelectedIndex = 0
    End Sub

    Private Sub BtnDownloadClick(sender As System.Object, e As System.EventArgs) Handles btnDownload.Click
        Me.dgData.DataMember = Nothing
        Me.dgData.DataSource = Nothing
        Me.PwrMtr.Write("MEM:TABL:SEL " & Quote & Me.lstbTables.SelectedItem.ToString & Quote & ";")
        Me.PwrMtr.Write("MEM:TABL:FREQ:POINTS?")
        If CInt(Me.PwrMtr.ReadString.Replace(NewLine, "").Replace(Quote, "")) > 0 Then
            Dim SelectedTableData As New DataTable(Me.lstbTables.SelectedItem.ToString)
            SelectedTableData.Columns.Add(New DataColumn("Point Number"))
            SelectedTableData.Columns.Add(New DataColumn("Frequency (GHz)"))
            SelectedTableData.Columns.Add(New DataColumn("Cal Factor (%)"))
            Me.PwrMtr.Write("MEM:TABL:FREQ?")
            Dim strFrequencies As String = Me.PwrMtr.ReadString
            Dim Frequencies() As String = strFrequencies.Split(","c)
            Dim Count As Integer = 1
            For Each Frequency As String In Frequencies
                Dim NewDR As DataRow = SelectedTableData.NewRow
                NewDR(0) = Count
                NewDR(1) = CDbl(Frequency.Replace(Quote, "").Replace(NewLine, "")) / 1000000000
                SelectedTableData.Rows.Add(NewDR)
                Count += 1
            Next
            Me.PwrMtr.Write("MEM:TABL:GAIN?")
            Dim strCalFactors As String = Me.PwrMtr.ReadString
            Dim CalFactors() As String = strCalFactors.Split(","c)
            Me.tbReferenceCF.Text = CDbl(CalFactors(0)).ToString
            For I As Integer = 0 To SelectedTableData.Rows.Count - 1
                SelectedTableData.Rows(I)(2) = CDbl(CalFactors(I + 1).Replace(Quote, "").Replace(NewLine, ""))
            Next
            Me.dgData.DataMember = Me.lstbTables.SelectedItem.ToString
            Me.dgData.DataSource = SelectedTableData
        End If
    End Sub

    Private Sub BtnUploadClick(sender As System.Object, e As System.EventArgs) Handles btnUpload.Click
        Dim DT As DataTable = CType(Me.dgData.DataSource, DataTable)
        Dim Frequencies As String = String.Empty
        Dim CalFactors As String = Me.tbReferenceCF.Text & ","
        For Each DR As DataRow In DT.Rows
            Frequencies = Frequencies & DR(1).ToString & "GHZ,"
            CalFactors = CalFactors & DR(2).ToString & ","
        Next
        Frequencies = Frequencies.Remove(Frequencies.Length - 1, 1)
        CalFactors = CalFactors.Remove(CalFactors.Length - 1, 1)
        Me.PwrMtr.Write("MEM:TABL:SEL " & Quote & Me.lstbTables.SelectedItem.ToString & Quote)
        Me.PwrMtr.Write("MEM:TABL:FREQ " & Frequencies & ";")
        Me.PwrMtr.Write("MEM:TABL:GAIN " & CalFactors & ";")
    End Sub

    Private Sub BtnRenameClick(sender As System.Object, e As System.EventArgs) Handles btnRename.Click
        If Not Me.tbNewTableName.Text.Length = 0 Then
            Me.PwrMtr.Write("MEM:TABL:MOVE " & Quote & Me.lstbTables.SelectedItem.ToString & Quote & "," & Quote & Me.tbNewTableName.Text & Quote & ";")
            Me.GetTableNames()
        End If
    End Sub

    Private Sub BtnClearAllTablesClick(sender As System.Object, e As System.EventArgs) Handles btnClearAllTables.Click
        Dim I As Integer = 0
        For Each Table As String In Me.lstbTables.Items
            Me.PwrMtr.Write("MEM:TABL:SEL " & Quote & Table & Quote)
            Me.PwrMtr.Write("MEM:TABL:MOVE " & Quote & Table & Quote & "," & Quote & "ABCDEFGH" & I & Quote)
            I += 1
        Next
        Me.GetTableNames()
        I = 0
        For Each Table As String In Me.lstbTables.Items
            Me.PwrMtr.Write("MEM:TABL:SEL " & Quote & Table & Quote)
            Me.PwrMtr.Write("MEM:TABL:MOVE " & Quote & Table & Quote & "," & Quote & "CUSTOM_" & I & Quote)
            Me.PwrMtr.Write("MEM:CLEAR " & Quote & "CUSTOM_" & I & Quote)
            I += 1
        Next
        Me.GetTableNames()
    End Sub

    Private Sub BtnNewTableClick(sender As System.Object, e As System.EventArgs) Handles btnNewTable.Click
        Dim NewTable As New DataTable(Me.lstbTables.SelectedItem.ToString)
        NewTable.Columns.Add(New DataColumn("Point Number"))
        NewTable.Columns.Add(New DataColumn("Frequency (GHz)"))
        NewTable.Columns.Add(New DataColumn("Cal Factor (%)"))
        Me.dgData.DataMember = Me.lstbTables.SelectedItem.ToString
        Me.dgData.DataSource = NewTable
    End Sub

End Class

