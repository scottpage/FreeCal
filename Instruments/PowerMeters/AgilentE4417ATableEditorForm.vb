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
		Private btnClearAllTables As System.Windows.Forms.Button
		Private tbNewTableName As System.Windows.Forms.TextBox
		Private dgData As System.Windows.Forms.DataGrid
		Private tbReferenceCF As System.Windows.Forms.TextBox
		Private btnRename As System.Windows.Forms.Button
		Private btnUpload As System.Windows.Forms.Button
		Private lstbTables As System.Windows.Forms.ListBox
		Private btnNewTable As System.Windows.Forms.Button
		Private btnDownload As System.Windows.Forms.Button
		
		Private PwrMtr As AgilentE4417A

		Public Sub New(ByVal parent As Form)
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
			Me.MdiParent = Parent
			Me.PwrMtr = New AgilentE4417A(0, 13, False)
			Me.GetTableNames
		End Sub
		
		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
			Me.btnDownload = New System.Windows.Forms.Button
			Me.btnNewTable = New System.Windows.Forms.Button
			Me.lstbTables = New System.Windows.Forms.ListBox
			Me.btnUpload = New System.Windows.Forms.Button
			Me.btnRename = New System.Windows.Forms.Button
			Me.tbReferenceCF = New System.Windows.Forms.TextBox
			Me.dgData = New System.Windows.Forms.DataGrid
			Me.tbNewTableName = New System.Windows.Forms.TextBox
			Me.btnClearAllTables = New System.Windows.Forms.Button
			CType(Me.dgData,System.ComponentModel.ISupportInitialize).BeginInit
			Me.SuspendLayout
			'
			'btnDownload
			'
			Me.btnDownload.Location = New System.Drawing.Point(400, 8)
			Me.btnDownload.Name = "btnDownload"
			Me.btnDownload.TabIndex = 1
			Me.btnDownload.Text = "Download"
			AddHandler Me.btnDownload.Click, AddressOf Me.BtnDownloadClick
			'
			'btnNewTable
			'
			Me.btnNewTable.Location = New System.Drawing.Point(640, 112)
			Me.btnNewTable.Name = "btnNewTable"
			Me.btnNewTable.TabIndex = 8
			Me.btnNewTable.Text = "New Table"
			AddHandler Me.btnNewTable.Click, AddressOf Me.BtnNewTableClick
			'
			'lstbTables
			'
			Me.lstbTables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.lstbTables.Location = New System.Drawing.Point(480, 0)
			Me.lstbTables.Name = "lstbTables"
			Me.lstbTables.Size = New System.Drawing.Size(128, 446)
			Me.lstbTables.TabIndex = 3
			'
			'btnUpload
			'
			Me.btnUpload.Location = New System.Drawing.Point(400, 40)
			Me.btnUpload.Name = "btnUpload"
			Me.btnUpload.TabIndex = 2
			Me.btnUpload.Text = "Upload"
			AddHandler Me.btnUpload.Click, AddressOf Me.BtnUploadClick
			'
			'btnRename
			'
			Me.btnRename.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.btnRename.Location = New System.Drawing.Point(640, 32)
			Me.btnRename.Name = "btnRename"
			Me.btnRename.TabIndex = 6
			Me.btnRename.Text = "Rename"
			AddHandler Me.btnRename.Click, AddressOf Me.BtnRenameClick
			'
			'tbReferenceCF
			'
			Me.tbReferenceCF.Location = New System.Drawing.Point(400, 80)
			Me.tbReferenceCF.Name = "tbReferenceCF"
			Me.tbReferenceCF.Size = New System.Drawing.Size(72, 20)
			Me.tbReferenceCF.TabIndex = 9
			Me.tbReferenceCF.Text = ""
			'
			'dgData
			'
			Me.dgData.AllowSorting = false
			Me.dgData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
			Me.dgData.DataMember = ""
			Me.dgData.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.dgData.Location = New System.Drawing.Point(8, 8)
			Me.dgData.Name = "dgData"
			Me.dgData.Size = New System.Drawing.Size(384, 440)
			Me.dgData.TabIndex = 0
			'
			'tbNewTableName
			'
			Me.tbNewTableName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.tbNewTableName.Location = New System.Drawing.Point(616, 8)
			Me.tbNewTableName.Name = "tbNewTableName"
			Me.tbNewTableName.Size = New System.Drawing.Size(128, 20)
			Me.tbNewTableName.TabIndex = 5
			Me.tbNewTableName.Text = ""
			'
			'btnClearAllTables
			'
			Me.btnClearAllTables.Location = New System.Drawing.Point(632, 424)
			Me.btnClearAllTables.Name = "btnClearAllTables"
			Me.btnClearAllTables.Size = New System.Drawing.Size(96, 23)
			Me.btnClearAllTables.TabIndex = 7
			Me.btnClearAllTables.Text = "Clear All Tables"
			AddHandler Me.btnClearAllTables.Click, AddressOf Me.BtnClearAllTablesClick
			'
			'AgilentE4417ATableEditorForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(752, 453)
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
			CType(Me.dgData,System.ComponentModel.ISupportInitialize).EndInit
			Me.ResumeLayout(false)
		End Sub
		#End Region

		Private Sub GetTableNames
			Me.lstbTables.Items.Clear
			Me.PwrMtr.Write("MEM:CAT:TABL?")
			Dim strTables As String = Me.PwrMtr.ReadString
			Dim Tables() As String = strTables.Split(",")
			For TableNumber As Integer = 2 To 89 Step 3
				Me.lstbTables.Items.Add(Tables(TableNumber).Replace(Quote, ""))
			Next
			Me.lstbTables.SelectedIndex = 0
		End Sub

		Private Sub BtnDownloadClick(sender As System.Object, e As System.EventArgs)
			Me.dgData.DataMember = Nothing
			Me.dgData.DataSource = Nothing
			Me.PwrMtr.Write("MEM:TABL:SEL " & Quote & Me.lstbTables.SelectedItem & Quote & ";")
			Me.PwrMtr.Write("MEM:TABL:FREQ:POINTS?")
			If CInt(Me.PwrMtr.ReadString.Replace(NewLine, "").Replace(Quote, "")) > 0 Then
				Dim SelectedTableData As New DataTable(Me.lstbTables.SelectedItem)
				SelectedTableData.Columns.Add(New DataColumn("Point Number"))
				SelectedTableData.Columns.Add(New DataColumn("Frequency (GHz)"))
				SelectedTableData.Columns.Add(New DataColumn("Cal Factor (%)"))
				Me.PwrMtr.Write("MEM:TABL:FREQ?")
				Dim strFrequencies As String = Me.PwrMtr.ReadString
				Dim Frequencies() As String = strFrequencies.Split(",")
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
				Dim CalFactors() As String = strCalFactors.Split(",")
				Me.tbReferenceCF.Text = CDbl(CalFactors(0))
				For I As Integer = 0 To SelectedTableData.Rows.Count - 1
					SelectedTableData.Rows(I)(2) = CDbl(CalFactors(I + 1).Replace(Quote, "").Replace(NewLine, ""))
				Next
				Me.dgData.DataMember = Me.lstbTables.SelectedItem
				Me.dgData.DataSource = SelectedTableData
			End If
		End Sub
		
		Private Sub BtnUploadClick(sender As System.Object, e As System.EventArgs)
			Dim DT As DataTable = Me.dgData.DataSource
			Dim Frequencies As String
			Dim CalFactors As String = Me.tbReferenceCF.Text & ","
			For Each DR As DataRow In DT.Rows
				Frequencies = Frequencies & DR(1) & "GHZ,"
				CalFactors = CalFactors & DR(2) & ","
			Next
			Frequencies = Frequencies.Remove(Frequencies.Length - 1, 1)
			CalFactors = CalFactors.Remove(CalFactors.Length - 1, 1)
			Me.PwrMtr.Write("MEM:TABL:SEL " & Quote & Me.lstbTables.SelectedItem & Quote)
			Me.PwrMtr.Write("MEM:TABL:FREQ " & Frequencies & ";")
			Me.PwrMtr.Write("MEM:TABL:GAIN " & CalFactors & ";")
		End Sub
		
		Private Sub BtnRenameClick(sender As System.Object, e As System.EventArgs)
			If Not Me.tbNewTableName.Text.Length = 0 Then
				Me.PwrMtr.Write("MEM:TABL:MOVE " & Quote & Me.lstbTables.SelectedItem & Quote & "," & Quote & Me.tbNewTableName.Text & Quote & ";")
				Me.GetTableNames
			End If
		End Sub
		
		Private Sub BtnClearAllTablesClick(sender As System.Object, e As System.EventArgs)
			Dim I As Integer = 0
			For Each Table As String In Me.lstbTables.Items
				Me.PwrMtr.Write("MEM:TABL:SEL " & Quote & Table & Quote)
				Me.PwrMtr.Write("MEM:TABL:MOVE " & Quote & Table & Quote & "," & Quote & "ABCDEFGH" & I & Quote)
				I += 1
			Next
			Me.GetTableNames
			I = 0
			For Each Table As String In Me.lstbTables.Items
				Me.PwrMtr.Write("MEM:TABL:SEL " & Quote & Table & Quote)
				Me.PwrMtr.Write("MEM:TABL:MOVE " & Quote & Table & Quote & "," & Quote & "CUSTOM_" & I & Quote)
				Me.PwrMtr.Write("MEM:CLEAR " & Quote & "CUSTOM_" & I & Quote)
				I += 1
			Next
			Me.GetTableNames
		End Sub
		
		Private Sub BtnNewTableClick(sender As System.Object, e As System.EventArgs)
			Dim NewTable As New DataTable(Me.lstbTables.SelectedItem)
			NewTable.Columns.Add(New DataColumn("Point Number"))
			NewTable.Columns.Add(New DataColumn("Frequency (GHz)"))
			NewTable.Columns.Add(New DataColumn("Cal Factor (%)"))
			Me.dgData.DataMember = Me.lstbTables.SelectedItem
			Me.dgData.DataSource = NewTable
		End Sub
		
	End Class

