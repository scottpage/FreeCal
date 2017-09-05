'
' Created by SharpDevelop.
' User: rspage
' Date: 6/23/2005
' Time: 9:29 AM
' 

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports FreeCal.Data
Imports System.Data
Imports MySql.Data.MySqlClient



Public Class DatabaseUtilitiesForm
    Inherits System.Windows.Forms.Form

    Private dataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Private dataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Private dataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Private dataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Private dataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Private dataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Private WithEvents lblTableNames As System.Windows.Forms.Label
    Private WithEvents cbTableNames As System.Windows.Forms.ComboBox
    Private WithEvents btnCreateTables As System.Windows.Forms.Button
    Private WithEvents dataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Private WithEvents gbRecords As System.Windows.Forms.GroupBox
    Private WithEvents btnGetRecords As System.Windows.Forms.Button
    Private WithEvents dgData As System.Windows.Forms.DataGrid
    Private WithEvents btnDeleteRecords As System.Windows.Forms.Button
    Private WithEvents btnCreateAdd As System.Windows.Forms.Button
    Private WithEvents btnGetSpecificRecords As System.Windows.Forms.Button
    Private WithEvents tbAssetNumber As System.Windows.Forms.TextBox
    Private WithEvents btnUpdateRecords As System.Windows.Forms.Button
    Private WithEvents lblAssetNumber As System.Windows.Forms.Label
    Private WithEvents btnGetDetails As System.Windows.Forms.Button

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Dim DT As DataTable = DatabaseUtilities.GetTableNames
        For Each DR As DataRow In DT.Rows
            Me.cbTableNames.Items.Add(DR(0))
        Next
        If Me.cbTableNames.Items.Count > 0 Then
            Me.cbTableNames.SelectedIndex = 0
        End If
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.btnGetDetails = New System.Windows.Forms.Button()
        Me.lblAssetNumber = New System.Windows.Forms.Label()
        Me.btnUpdateRecords = New System.Windows.Forms.Button()
        Me.tbAssetNumber = New System.Windows.Forms.TextBox()
        Me.btnGetSpecificRecords = New System.Windows.Forms.Button()
        Me.btnCreateAdd = New System.Windows.Forms.Button()
        Me.btnDeleteRecords = New System.Windows.Forms.Button()
        Me.dgData = New System.Windows.Forms.DataGrid()
        Me.dataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.dataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.dataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.dataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.dataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.dataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.dataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnGetRecords = New System.Windows.Forms.Button()
        Me.gbRecords = New System.Windows.Forms.GroupBox()
        Me.btnCreateTables = New System.Windows.Forms.Button()
        Me.cbTableNames = New System.Windows.Forms.ComboBox()
        Me.lblTableNames = New System.Windows.Forms.Label()
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbRecords.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGetDetails
        '
        Me.btnGetDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGetDetails.Location = New System.Drawing.Point(1134, 89)
        Me.btnGetDetails.Name = "btnGetDetails"
        Me.btnGetDetails.Size = New System.Drawing.Size(144, 42)
        Me.btnGetDetails.TabIndex = 13
        Me.btnGetDetails.Text = "Get Details"
        '
        'lblAssetNumber
        '
        Me.lblAssetNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAssetNumber.AutoSize = True
        Me.lblAssetNumber.Location = New System.Drawing.Point(80, 42)
        Me.lblAssetNumber.Name = "lblAssetNumber"
        Me.lblAssetNumber.Size = New System.Drawing.Size(147, 25)
        Me.lblAssetNumber.TabIndex = 7
        Me.lblAssetNumber.Text = "Asset Number"
        '
        'btnUpdateRecords
        '
        Me.btnUpdateRecords.Enabled = False
        Me.btnUpdateRecords.Location = New System.Drawing.Point(80, 192)
        Me.btnUpdateRecords.Name = "btnUpdateRecords"
        Me.btnUpdateRecords.Size = New System.Drawing.Size(144, 42)
        Me.btnUpdateRecords.TabIndex = 15
        Me.btnUpdateRecords.Text = "Update"
        '
        'tbAssetNumber
        '
        Me.tbAssetNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAssetNumber.Location = New System.Drawing.Point(16, 74)
        Me.tbAssetNumber.Name = "tbAssetNumber"
        Me.tbAssetNumber.Size = New System.Drawing.Size(272, 31)
        Me.tbAssetNumber.TabIndex = 3
        '
        'btnGetSpecificRecords
        '
        Me.btnGetSpecificRecords.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGetSpecificRecords.Location = New System.Drawing.Point(80, 131)
        Me.btnGetSpecificRecords.Name = "btnGetSpecificRecords"
        Me.btnGetSpecificRecords.Size = New System.Drawing.Size(144, 43)
        Me.btnGetSpecificRecords.TabIndex = 17
        Me.btnGetSpecificRecords.Text = "Get"
        '
        'btnCreateAdd
        '
        Me.btnCreateAdd.Location = New System.Drawing.Point(80, 310)
        Me.btnCreateAdd.Name = "btnCreateAdd"
        Me.btnCreateAdd.Size = New System.Drawing.Size(144, 43)
        Me.btnCreateAdd.TabIndex = 18
        Me.btnCreateAdd.Text = "Create"
        '
        'btnDeleteRecords
        '
        Me.btnDeleteRecords.Location = New System.Drawing.Point(80, 251)
        Me.btnDeleteRecords.Name = "btnDeleteRecords"
        Me.btnDeleteRecords.Size = New System.Drawing.Size(144, 43)
        Me.btnDeleteRecords.TabIndex = 16
        Me.btnDeleteRecords.Text = "Delete"
        '
        'dgData
        '
        Me.dgData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgData.DataMember = ""
        Me.dgData.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgData.Location = New System.Drawing.Point(16, 15)
        Me.dgData.Name = "dgData"
        Me.dgData.Size = New System.Drawing.Size(1022, 934)
        Me.dgData.TabIndex = 1
        Me.dgData.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dataGridTableStyle1})
        '
        'dataGridTableStyle1
        '
        Me.dataGridTableStyle1.DataGrid = Me.dgData
        Me.dataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.dataGridTextBoxColumn6, Me.dataGridTextBoxColumn1, Me.dataGridTextBoxColumn2, Me.dataGridTextBoxColumn3, Me.dataGridTextBoxColumn4, Me.dataGridTextBoxColumn5})
        Me.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'dataGridTextBoxColumn6
        '
        Me.dataGridTextBoxColumn6.Format = ""
        Me.dataGridTextBoxColumn6.FormatInfo = Nothing
        Me.dataGridTextBoxColumn6.HeaderText = "Model"
        Me.dataGridTextBoxColumn6.MappingName = "Model"
        Me.dataGridTextBoxColumn6.Width = 75
        '
        'dataGridTextBoxColumn1
        '
        Me.dataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.dataGridTextBoxColumn1.Format = ""
        Me.dataGridTextBoxColumn1.FormatInfo = Nothing
        Me.dataGridTextBoxColumn1.HeaderText = "Frequency (GHz)"
        Me.dataGridTextBoxColumn1.MappingName = "FrequencyGHz"
        Me.dataGridTextBoxColumn1.Width = 75
        '
        'dataGridTextBoxColumn2
        '
        Me.dataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.dataGridTextBoxColumn2.Format = ""
        Me.dataGridTextBoxColumn2.FormatInfo = Nothing
        Me.dataGridTextBoxColumn2.HeaderText = "Port 2 Magnitude"
        Me.dataGridTextBoxColumn2.MappingName = "Port2Magnitude"
        Me.dataGridTextBoxColumn2.Width = 75
        '
        'dataGridTextBoxColumn3
        '
        Me.dataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.dataGridTextBoxColumn3.Format = ""
        Me.dataGridTextBoxColumn3.FormatInfo = Nothing
        Me.dataGridTextBoxColumn3.HeaderText = "Port 2 Phase"
        Me.dataGridTextBoxColumn3.MappingName = "Port2Phase"
        Me.dataGridTextBoxColumn3.Width = 75
        '
        'dataGridTextBoxColumn4
        '
        Me.dataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.dataGridTextBoxColumn4.Format = ""
        Me.dataGridTextBoxColumn4.FormatInfo = Nothing
        Me.dataGridTextBoxColumn4.HeaderText = "Port 3 Magnitude"
        Me.dataGridTextBoxColumn4.MappingName = "Port3Magnitude"
        Me.dataGridTextBoxColumn4.Width = 75
        '
        'dataGridTextBoxColumn5
        '
        Me.dataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.dataGridTextBoxColumn5.Format = ""
        Me.dataGridTextBoxColumn5.FormatInfo = Nothing
        Me.dataGridTextBoxColumn5.HeaderText = "Port 3 Phase"
        Me.dataGridTextBoxColumn5.MappingName = "Port3Phase"
        Me.dataGridTextBoxColumn5.Width = 75
        '
        'btnGetRecords
        '
        Me.btnGetRecords.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGetRecords.Location = New System.Drawing.Point(1102, 148)
        Me.btnGetRecords.Name = "btnGetRecords"
        Me.btnGetRecords.Size = New System.Drawing.Size(208, 42)
        Me.btnGetRecords.TabIndex = 14
        Me.btnGetRecords.Text = "Get All Records"
        '
        'gbRecords
        '
        Me.gbRecords.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbRecords.Controls.Add(Me.btnCreateAdd)
        Me.gbRecords.Controls.Add(Me.btnDeleteRecords)
        Me.gbRecords.Controls.Add(Me.btnUpdateRecords)
        Me.gbRecords.Controls.Add(Me.tbAssetNumber)
        Me.gbRecords.Controls.Add(Me.lblAssetNumber)
        Me.gbRecords.Controls.Add(Me.btnGetSpecificRecords)
        Me.gbRecords.Location = New System.Drawing.Point(1054, 236)
        Me.gbRecords.Name = "gbRecords"
        Me.gbRecords.Size = New System.Drawing.Size(304, 370)
        Me.gbRecords.TabIndex = 15
        Me.gbRecords.TabStop = False
        Me.gbRecords.Text = "Table Records"
        '
        'btnCreateTables
        '
        Me.btnCreateTables.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreateTables.Location = New System.Drawing.Point(1118, 679)
        Me.btnCreateTables.Name = "btnCreateTables"
        Me.btnCreateTables.Size = New System.Drawing.Size(176, 45)
        Me.btnCreateTables.TabIndex = 11
        Me.btnCreateTables.Text = "Create Tables"
        '
        'cbTableNames
        '
        Me.cbTableNames.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbTableNames.Location = New System.Drawing.Point(1070, 44)
        Me.cbTableNames.Name = "cbTableNames"
        Me.cbTableNames.Size = New System.Drawing.Size(288, 33)
        Me.cbTableNames.TabIndex = 16
        '
        'lblTableNames
        '
        Me.lblTableNames.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTableNames.AutoSize = True
        Me.lblTableNames.Location = New System.Drawing.Point(1134, 15)
        Me.lblTableNames.Name = "lblTableNames"
        Me.lblTableNames.Size = New System.Drawing.Size(133, 25)
        Me.lblTableNames.TabIndex = 17
        Me.lblTableNames.Text = "TableNames"
        '
        'DatabaseUtilitiesForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(1374, 958)
        Me.Controls.Add(Me.cbTableNames)
        Me.Controls.Add(Me.gbRecords)
        Me.Controls.Add(Me.btnGetDetails)
        Me.Controls.Add(Me.btnCreateTables)
        Me.Controls.Add(Me.dgData)
        Me.Controls.Add(Me.lblTableNames)
        Me.Controls.Add(Me.btnGetRecords)
        Me.Name = "DatabaseUtilitiesForm"
        Me.Text = "WorkForm"
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbRecords.ResumeLayout(False)
        Me.gbRecords.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub BtnCreateTablesClick(sender As System.Object, e As System.EventArgs) Handles btnCreateTables.Click
        DatabaseUtilities.CreateFreeCalDatabases()
    End Sub

    Private Sub BtnGetDetailsClick(sender As System.Object, e As System.EventArgs) Handles btnGetDetails.Click
        If Not (Me.cbTableNames.SelectedItem.ToString = "") Then
            Me.dgData.DataMember = ""
            Me.dgData.DataSource = Nothing
            Me.dgData.DataMember = Me.cbTableNames.SelectedItem.ToString
            Me.dgData.DataSource = DatabaseUtilities.GetTableDetails(Me.cbTableNames.SelectedItem.ToString)
        Else
            MessageBox.Show("You must select a Table Name!")
        End If
    End Sub

    Private Sub BtnGetRecordsClick(sender As System.Object, e As System.EventArgs) Handles btnGetRecords.Click
        If Not (Me.cbTableNames.SelectedItem.ToString = "") Then
            Me.dgData.DataMember = ""
            Me.dgData.DataSource = Nothing
            Me.dgData.DataMember = Me.cbTableNames.SelectedItem.ToString
            Me.dgData.DataSource = DatabaseUtilities.GetTableRecords(Me.cbTableNames.SelectedItem.ToString)
        Else
            MessageBox.Show("You must select a Table Name!")
        End If
    End Sub

    Private Sub BtnUpdateRecordsClick(sender As System.Object, e As System.EventArgs) Handles btnUpdateRecords.Click
        If Not (Me.tbAssetNumber.Text = "" Or Me.cbTableNames.SelectedItem.ToString = "") Then
            Me.dgData.DataMember = ""
            Me.dgData.DataSource = Nothing
            Me.dgData.DataMember = Me.cbTableNames.SelectedItem.ToString
            Me.dgData.DataSource = DatabaseUtilities.GetTableRecords(Me.cbTableNames.SelectedItem.ToString)
        Else
            MessageBox.Show("You must specify an Asset number and a select a Table Name!")
        End If
    End Sub

    Private Sub BtnDeleteRecordsClick(sender As System.Object, e As System.EventArgs) Handles btnDeleteRecords.Click
        If Not (Me.tbAssetNumber.Text = "" Or Me.cbTableNames.SelectedItem.ToString = "") Then
            Me.dgData.DataMember = ""
            Me.dgData.DataSource = Nothing
            Me.dgData.DataMember = Me.cbTableNames.SelectedItem.ToString
            Me.dgData.DataSource = DatabaseUtilities.DeleteTableRecords(Me.cbTableNames.SelectedItem.ToString, Me.tbAssetNumber.Text)
        Else
            MessageBox.Show("You must specify an Asset number and a select a Table Name!")
        End If
    End Sub

    Private Sub BtnGetSpecificRecordsClick(sender As System.Object, e As System.EventArgs) Handles btnGetSpecificRecords.Click
        If Not (Me.tbAssetNumber.Text = "" Or Me.cbTableNames.SelectedItem.ToString = "") Then
            Me.dgData.DataMember = ""
            Me.dgData.DataSource = Nothing
            Me.dgData.DataMember = Me.cbTableNames.SelectedItem.ToString
            Me.dgData.DataSource = DatabaseUtilities.GetTableRecords(Me.cbTableNames.SelectedItem.ToString, Me.tbAssetNumber.Text)
        Else
            MessageBox.Show("You must specify an Asset number and a select a Table Name!")
        End If
    End Sub

    Private Sub BtnCreateAddClick(sender As System.Object, e As System.EventArgs) Handles btnCreateAdd.Click
        If Me.btnCreateAdd.Text = "Create" Then
            Dim DT As New DataTable
            Me.dgData.DataMember = ""
            Me.dgData.DataSource = DT
        End If
    End Sub

End Class

