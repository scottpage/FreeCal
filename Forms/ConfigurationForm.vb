'
' Created by SharpDevelop.
' User: Administrator
' Date: 4/13/2005
' Time: 4:57 AM
' 


Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports FreeCal.Common


Public Class ConfigurationForm
    Inherits System.Windows.Forms.Form
    Private WithEvents lblFormForeColor As System.Windows.Forms.Label
    Private WithEvents lblGroupBoxBackColor As System.Windows.Forms.Label
    Private WithEvents tcDateTime As System.Windows.Forms.TabControl
    Private WithEvents lblGroupBoxForeColor As System.Windows.Forms.Label
    Private WithEvents tbMath As System.Windows.Forms.TabPage
    Private WithEvents btnSaveConfiguration As System.Windows.Forms.Button
    Private WithEvents tpColor As System.Windows.Forms.TabPage
    Private WithEvents tpGraphsCharts As System.Windows.Forms.TabPage
    Private WithEvents tpStartup As System.Windows.Forms.TabPage
    Private WithEvents btnGroupBoxBackColor As System.Windows.Forms.Button
    Private WithEvents btnTextBoxBackColor As System.Windows.Forms.Button
    Private WithEvents btnFormForeColor As System.Windows.Forms.Button
    Private WithEvents btnLabelBackColor As System.Windows.Forms.Button
    Private WithEvents SelectColorDialog As System.Windows.Forms.ColorDialog
    Private WithEvents lblButtonBackColor As System.Windows.Forms.Label
    Private WithEvents lblLabelForeColor As System.Windows.Forms.Label
    Private WithEvents tpPrinting As System.Windows.Forms.TabPage
    Private WithEvents btnGroupBoxForeColor As System.Windows.Forms.Button
    Private WithEvents btnButtonForeColor As System.Windows.Forms.Button
    Private WithEvents tpDateTime As System.Windows.Forms.TabPage
    Private WithEvents lblButtonForeColor As System.Windows.Forms.Label
    Private WithEvents btnTextBoxForeColor As System.Windows.Forms.Button
    Private WithEvents btnLabelForeColor As System.Windows.Forms.Button
    Private WithEvents lblTextBoxForeColor As System.Windows.Forms.Label
    Private WithEvents lblFormBackColor As System.Windows.Forms.Label
    Private WithEvents btnButtonBackColor As System.Windows.Forms.Button
    Private WithEvents tpInstruments As System.Windows.Forms.TabPage
    Private WithEvents tpReports As System.Windows.Forms.TabPage
    Private WithEvents tpFilesDirectories As System.Windows.Forms.TabPage
    Private WithEvents lblLablelBackColor As System.Windows.Forms.Label
    Private WithEvents lblTextBoxBackColor As System.Windows.Forms.Label
    Private WithEvents btnCancel As System.Windows.Forms.Button
    Private WithEvents btnFormBackColor As System.Windows.Forms.Button

    Public Sub New()
        MyBase.New()
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
    End Sub

    Public Sub New(ByVal title As String, ByVal parent As Form)
        Me.InitializeComponent()
        Me.Text = title
        Me.MdiParent = parent
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.btnFormBackColor = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblTextBoxBackColor = New System.Windows.Forms.Label()
        Me.lblLablelBackColor = New System.Windows.Forms.Label()
        Me.tpFilesDirectories = New System.Windows.Forms.TabPage()
        Me.tpReports = New System.Windows.Forms.TabPage()
        Me.tpInstruments = New System.Windows.Forms.TabPage()
        Me.btnButtonBackColor = New System.Windows.Forms.Button()
        Me.lblFormBackColor = New System.Windows.Forms.Label()
        Me.lblTextBoxForeColor = New System.Windows.Forms.Label()
        Me.btnLabelForeColor = New System.Windows.Forms.Button()
        Me.btnTextBoxForeColor = New System.Windows.Forms.Button()
        Me.lblButtonForeColor = New System.Windows.Forms.Label()
        Me.tpDateTime = New System.Windows.Forms.TabPage()
        Me.btnButtonForeColor = New System.Windows.Forms.Button()
        Me.btnGroupBoxForeColor = New System.Windows.Forms.Button()
        Me.tpPrinting = New System.Windows.Forms.TabPage()
        Me.lblLabelForeColor = New System.Windows.Forms.Label()
        Me.lblButtonBackColor = New System.Windows.Forms.Label()
        Me.SelectColorDialog = New System.Windows.Forms.ColorDialog()
        Me.btnLabelBackColor = New System.Windows.Forms.Button()
        Me.btnFormForeColor = New System.Windows.Forms.Button()
        Me.btnTextBoxBackColor = New System.Windows.Forms.Button()
        Me.btnGroupBoxBackColor = New System.Windows.Forms.Button()
        Me.tpStartup = New System.Windows.Forms.TabPage()
        Me.tpGraphsCharts = New System.Windows.Forms.TabPage()
        Me.tpColor = New System.Windows.Forms.TabPage()
        Me.lblGroupBoxForeColor = New System.Windows.Forms.Label()
        Me.lblGroupBoxBackColor = New System.Windows.Forms.Label()
        Me.lblFormForeColor = New System.Windows.Forms.Label()
        Me.btnSaveConfiguration = New System.Windows.Forms.Button()
        Me.tbMath = New System.Windows.Forms.TabPage()
        Me.tcDateTime = New System.Windows.Forms.TabControl()
        Me.tpColor.SuspendLayout()
        Me.tcDateTime.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnFormBackColor
        '
        Me.btnFormBackColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.btnFormBackColor.ImageIndex = 0
        Me.btnFormBackColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnFormBackColor.Location = New System.Drawing.Point(80, 59)
        Me.btnFormBackColor.Name = "btnFormBackColor"
        Me.btnFormBackColor.Size = New System.Drawing.Size(400, 37)
        Me.btnFormBackColor.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(1008, 635)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(150, 43)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        '
        'lblTextBoxBackColor
        '
        Me.lblTextBoxBackColor.AutoSize = True
        Me.lblTextBoxBackColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblTextBoxBackColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextBoxBackColor.Location = New System.Drawing.Point(80, 295)
        Me.lblTextBoxBackColor.Name = "lblTextBoxBackColor"
        Me.lblTextBoxBackColor.Size = New System.Drawing.Size(124, 13)
        Me.lblTextBoxBackColor.TabIndex = 0
        Me.lblTextBoxBackColor.Text = "TextBox Background"
        '
        'lblLablelBackColor
        '
        Me.lblLablelBackColor.AutoSize = True
        Me.lblLablelBackColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblLablelBackColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLablelBackColor.Location = New System.Drawing.Point(80, 207)
        Me.lblLablelBackColor.Name = "lblLablelBackColor"
        Me.lblLablelBackColor.Size = New System.Drawing.Size(107, 13)
        Me.lblLablelBackColor.TabIndex = 0
        Me.lblLablelBackColor.Text = "Label Background"
        '
        'tpFilesDirectories
        '
        Me.tpFilesDirectories.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tpFilesDirectories.ImageIndex = 0
        Me.tpFilesDirectories.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tpFilesDirectories.Location = New System.Drawing.Point(8, 43)
        Me.tpFilesDirectories.Name = "tpFilesDirectories"
        Me.tpFilesDirectories.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tpFilesDirectories.Size = New System.Drawing.Size(1155, 569)
        Me.tpFilesDirectories.TabIndex = 0
        '
        'tpReports
        '
        Me.tpReports.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tpReports.ImageIndex = 0
        Me.tpReports.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tpReports.Location = New System.Drawing.Point(8, 43)
        Me.tpReports.Name = "tpReports"
        Me.tpReports.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tpReports.Size = New System.Drawing.Size(1155, 569)
        Me.tpReports.TabIndex = 0
        '
        'tpInstruments
        '
        Me.tpInstruments.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tpInstruments.ImageIndex = 0
        Me.tpInstruments.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tpInstruments.Location = New System.Drawing.Point(8, 43)
        Me.tpInstruments.Name = "tpInstruments"
        Me.tpInstruments.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tpInstruments.Size = New System.Drawing.Size(1155, 569)
        Me.tpInstruments.TabIndex = 0
        '
        'btnButtonBackColor
        '
        Me.btnButtonBackColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.btnButtonBackColor.ImageIndex = 0
        Me.btnButtonBackColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnButtonBackColor.Location = New System.Drawing.Point(80, 148)
        Me.btnButtonBackColor.Name = "btnButtonBackColor"
        Me.btnButtonBackColor.Size = New System.Drawing.Size(400, 37)
        Me.btnButtonBackColor.TabIndex = 0
        '
        'lblFormBackColor
        '
        Me.lblFormBackColor.AutoSize = True
        Me.lblFormBackColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblFormBackColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFormBackColor.Location = New System.Drawing.Point(80, 30)
        Me.lblFormBackColor.Name = "lblFormBackColor"
        Me.lblFormBackColor.Size = New System.Drawing.Size(106, 13)
        Me.lblFormBackColor.TabIndex = 0
        Me.lblFormBackColor.Text = "Form Background"
        '
        'lblTextBoxForeColor
        '
        Me.lblTextBoxForeColor.AutoSize = True
        Me.lblTextBoxForeColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblTextBoxForeColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTextBoxForeColor.Location = New System.Drawing.Point(592, 295)
        Me.lblTextBoxForeColor.Name = "lblTextBoxForeColor"
        Me.lblTextBoxForeColor.Size = New System.Drawing.Size(83, 13)
        Me.lblTextBoxForeColor.TabIndex = 0
        Me.lblTextBoxForeColor.Text = "TextBox Text"
        '
        'btnLabelForeColor
        '
        Me.btnLabelForeColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.btnLabelForeColor.ImageIndex = 0
        Me.btnLabelForeColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLabelForeColor.Location = New System.Drawing.Point(592, 236)
        Me.btnLabelForeColor.Name = "btnLabelForeColor"
        Me.btnLabelForeColor.Size = New System.Drawing.Size(400, 37)
        Me.btnLabelForeColor.TabIndex = 0
        '
        'btnTextBoxForeColor
        '
        Me.btnTextBoxForeColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.btnTextBoxForeColor.ImageIndex = 0
        Me.btnTextBoxForeColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnTextBoxForeColor.Location = New System.Drawing.Point(592, 325)
        Me.btnTextBoxForeColor.Name = "btnTextBoxForeColor"
        Me.btnTextBoxForeColor.Size = New System.Drawing.Size(400, 37)
        Me.btnTextBoxForeColor.TabIndex = 0
        '
        'lblButtonForeColor
        '
        Me.lblButtonForeColor.AutoSize = True
        Me.lblButtonForeColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblButtonForeColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblButtonForeColor.Location = New System.Drawing.Point(592, 118)
        Me.lblButtonForeColor.Name = "lblButtonForeColor"
        Me.lblButtonForeColor.Size = New System.Drawing.Size(74, 13)
        Me.lblButtonForeColor.TabIndex = 0
        Me.lblButtonForeColor.Text = "Button Text"
        '
        'tpDateTime
        '
        Me.tpDateTime.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tpDateTime.ImageIndex = 0
        Me.tpDateTime.Location = New System.Drawing.Point(8, 43)
        Me.tpDateTime.Name = "tpDateTime"
        Me.tpDateTime.Size = New System.Drawing.Size(1155, 569)
        Me.tpDateTime.TabIndex = 0
        '
        'btnButtonForeColor
        '
        Me.btnButtonForeColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.btnButtonForeColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnButtonForeColor.Location = New System.Drawing.Point(592, 148)
        Me.btnButtonForeColor.Name = "btnButtonForeColor"
        Me.btnButtonForeColor.Size = New System.Drawing.Size(400, 37)
        Me.btnButtonForeColor.TabIndex = 0
        '
        'btnGroupBoxForeColor
        '
        Me.btnGroupBoxForeColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.btnGroupBoxForeColor.ImageIndex = 0
        Me.btnGroupBoxForeColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGroupBoxForeColor.Location = New System.Drawing.Point(592, 414)
        Me.btnGroupBoxForeColor.Name = "btnGroupBoxForeColor"
        Me.btnGroupBoxForeColor.Size = New System.Drawing.Size(400, 36)
        Me.btnGroupBoxForeColor.TabIndex = 0
        '
        'tpPrinting
        '
        Me.tpPrinting.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tpPrinting.ImageIndex = 0
        Me.tpPrinting.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tpPrinting.Location = New System.Drawing.Point(8, 43)
        Me.tpPrinting.Name = "tpPrinting"
        Me.tpPrinting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tpPrinting.Size = New System.Drawing.Size(1155, 569)
        Me.tpPrinting.TabIndex = 0
        '
        'lblLabelForeColor
        '
        Me.lblLabelForeColor.AutoSize = True
        Me.lblLabelForeColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblLabelForeColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLabelForeColor.Location = New System.Drawing.Point(592, 207)
        Me.lblLabelForeColor.Name = "lblLabelForeColor"
        Me.lblLabelForeColor.Size = New System.Drawing.Size(66, 13)
        Me.lblLabelForeColor.TabIndex = 0
        Me.lblLabelForeColor.Text = "Label Text"
        '
        'lblButtonBackColor
        '
        Me.lblButtonBackColor.AutoSize = True
        Me.lblButtonBackColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblButtonBackColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblButtonBackColor.Location = New System.Drawing.Point(80, 118)
        Me.lblButtonBackColor.Name = "lblButtonBackColor"
        Me.lblButtonBackColor.Size = New System.Drawing.Size(115, 13)
        Me.lblButtonBackColor.TabIndex = 0
        Me.lblButtonBackColor.Text = "Button Background"
        '
        'SelectColorDialog
        '
        Me.SelectColorDialog.AnyColor = True
        '
        'btnLabelBackColor
        '
        Me.btnLabelBackColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.btnLabelBackColor.ImageIndex = 0
        Me.btnLabelBackColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLabelBackColor.Location = New System.Drawing.Point(80, 236)
        Me.btnLabelBackColor.Name = "btnLabelBackColor"
        Me.btnLabelBackColor.Size = New System.Drawing.Size(400, 37)
        Me.btnLabelBackColor.TabIndex = 0
        '
        'btnFormForeColor
        '
        Me.btnFormForeColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.btnFormForeColor.ImageIndex = 0
        Me.btnFormForeColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnFormForeColor.Location = New System.Drawing.Point(592, 59)
        Me.btnFormForeColor.Name = "btnFormForeColor"
        Me.btnFormForeColor.Size = New System.Drawing.Size(400, 37)
        Me.btnFormForeColor.TabIndex = 0
        '
        'btnTextBoxBackColor
        '
        Me.btnTextBoxBackColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.btnTextBoxBackColor.ImageIndex = 0
        Me.btnTextBoxBackColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnTextBoxBackColor.Location = New System.Drawing.Point(80, 325)
        Me.btnTextBoxBackColor.Name = "btnTextBoxBackColor"
        Me.btnTextBoxBackColor.Size = New System.Drawing.Size(400, 37)
        Me.btnTextBoxBackColor.TabIndex = 0
        '
        'btnGroupBoxBackColor
        '
        Me.btnGroupBoxBackColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.btnGroupBoxBackColor.ImageIndex = 0
        Me.btnGroupBoxBackColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnGroupBoxBackColor.Location = New System.Drawing.Point(80, 414)
        Me.btnGroupBoxBackColor.Name = "btnGroupBoxBackColor"
        Me.btnGroupBoxBackColor.Size = New System.Drawing.Size(400, 36)
        Me.btnGroupBoxBackColor.TabIndex = 0
        '
        'tpStartup
        '
        Me.tpStartup.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tpStartup.ImageIndex = 0
        Me.tpStartup.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tpStartup.Location = New System.Drawing.Point(8, 43)
        Me.tpStartup.Name = "tpStartup"
        Me.tpStartup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tpStartup.Size = New System.Drawing.Size(1155, 569)
        Me.tpStartup.TabIndex = 0
        '
        'tpGraphsCharts
        '
        Me.tpGraphsCharts.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tpGraphsCharts.ImageIndex = 0
        Me.tpGraphsCharts.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tpGraphsCharts.Location = New System.Drawing.Point(8, 43)
        Me.tpGraphsCharts.Name = "tpGraphsCharts"
        Me.tpGraphsCharts.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tpGraphsCharts.Size = New System.Drawing.Size(1155, 569)
        Me.tpGraphsCharts.TabIndex = 0
        Me.tpGraphsCharts.Text = "Chart and Graphs"
        '
        'tpColor
        '
        Me.tpColor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tpColor.Controls.Add(Me.btnButtonForeColor)
        Me.tpColor.Controls.Add(Me.btnLabelBackColor)
        Me.tpColor.Controls.Add(Me.btnGroupBoxForeColor)
        Me.tpColor.Controls.Add(Me.btnGroupBoxBackColor)
        Me.tpColor.Controls.Add(Me.btnTextBoxForeColor)
        Me.tpColor.Controls.Add(Me.btnTextBoxBackColor)
        Me.tpColor.Controls.Add(Me.btnLabelForeColor)
        Me.tpColor.Controls.Add(Me.btnFormForeColor)
        Me.tpColor.Controls.Add(Me.btnButtonBackColor)
        Me.tpColor.Controls.Add(Me.btnFormBackColor)
        Me.tpColor.Controls.Add(Me.lblGroupBoxForeColor)
        Me.tpColor.Controls.Add(Me.lblGroupBoxBackColor)
        Me.tpColor.Controls.Add(Me.lblTextBoxForeColor)
        Me.tpColor.Controls.Add(Me.lblTextBoxBackColor)
        Me.tpColor.Controls.Add(Me.lblLabelForeColor)
        Me.tpColor.Controls.Add(Me.lblLablelBackColor)
        Me.tpColor.Controls.Add(Me.lblButtonForeColor)
        Me.tpColor.Controls.Add(Me.lblButtonBackColor)
        Me.tpColor.Controls.Add(Me.lblFormForeColor)
        Me.tpColor.Controls.Add(Me.lblFormBackColor)
        Me.tpColor.ImageIndex = 0
        Me.tpColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tpColor.Location = New System.Drawing.Point(8, 43)
        Me.tpColor.Name = "tpColor"
        Me.tpColor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.tpColor.Size = New System.Drawing.Size(1155, 569)
        Me.tpColor.TabIndex = 0
        Me.tpColor.Text = "Color"
        '
        'lblGroupBoxForeColor
        '
        Me.lblGroupBoxForeColor.AutoSize = True
        Me.lblGroupBoxForeColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblGroupBoxForeColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGroupBoxForeColor.Location = New System.Drawing.Point(592, 384)
        Me.lblGroupBoxForeColor.Name = "lblGroupBoxForeColor"
        Me.lblGroupBoxForeColor.Size = New System.Drawing.Size(91, 13)
        Me.lblGroupBoxForeColor.TabIndex = 0
        Me.lblGroupBoxForeColor.Text = "GroupBox Text"
        '
        'lblGroupBoxBackColor
        '
        Me.lblGroupBoxBackColor.AutoSize = True
        Me.lblGroupBoxBackColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblGroupBoxBackColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGroupBoxBackColor.Location = New System.Drawing.Point(80, 384)
        Me.lblGroupBoxBackColor.Name = "lblGroupBoxBackColor"
        Me.lblGroupBoxBackColor.Size = New System.Drawing.Size(132, 13)
        Me.lblGroupBoxBackColor.TabIndex = 0
        Me.lblGroupBoxBackColor.Text = "GroupBox Background"
        '
        'lblFormForeColor
        '
        Me.lblFormForeColor.AutoSize = True
        Me.lblFormForeColor.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblFormForeColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblFormForeColor.Location = New System.Drawing.Point(592, 30)
        Me.lblFormForeColor.Name = "lblFormForeColor"
        Me.lblFormForeColor.Size = New System.Drawing.Size(65, 13)
        Me.lblFormForeColor.TabIndex = 0
        Me.lblFormForeColor.Text = "Form Text"
        '
        'btnSaveConfiguration
        '
        Me.btnSaveConfiguration.Location = New System.Drawing.Point(816, 635)
        Me.btnSaveConfiguration.Name = "btnSaveConfiguration"
        Me.btnSaveConfiguration.Size = New System.Drawing.Size(150, 43)
        Me.btnSaveConfiguration.TabIndex = 1
        Me.btnSaveConfiguration.Text = "Save"
        '
        'tbMath
        '
        Me.tbMath.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbMath.ImageIndex = 0
        Me.tbMath.Location = New System.Drawing.Point(8, 43)
        Me.tbMath.Name = "tbMath"
        Me.tbMath.Size = New System.Drawing.Size(1155, 569)
        Me.tbMath.TabIndex = 0
        '
        'tcDateTime
        '
        Me.tcDateTime.Controls.Add(Me.tpDateTime)
        Me.tcDateTime.Controls.Add(Me.tpColor)
        Me.tcDateTime.Controls.Add(Me.tpInstruments)
        Me.tcDateTime.Controls.Add(Me.tpPrinting)
        Me.tcDateTime.Controls.Add(Me.tpGraphsCharts)
        Me.tcDateTime.Controls.Add(Me.tbMath)
        Me.tcDateTime.Controls.Add(Me.tpReports)
        Me.tcDateTime.Controls.Add(Me.tpFilesDirectories)
        Me.tcDateTime.Controls.Add(Me.tpStartup)
        Me.tcDateTime.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcDateTime.Location = New System.Drawing.Point(0, 0)
        Me.tcDateTime.Name = "tcDateTime"
        Me.tcDateTime.Padding = New System.Drawing.Point(0, 0)
        Me.tcDateTime.SelectedIndex = 0
        Me.tcDateTime.Size = New System.Drawing.Size(1171, 620)
        Me.tcDateTime.TabIndex = 0
        '
        'ConfigurationForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(1171, 726)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSaveConfiguration)
        Me.Controls.Add(Me.tcDateTime)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConfigurationForm"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.tpColor.ResumeLayout(False)
        Me.tpColor.PerformLayout()
        Me.tcDateTime.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private Sub ColorButtonClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnTextBoxForeColor.Click, btnTextBoxBackColor.Click, btnLabelForeColor.Click, btnLabelBackColor.Click, btnGroupBoxForeColor.Click, btnGroupBoxBackColor.Click, btnFormForeColor.Click, btnFormBackColor.Click, btnButtonForeColor.Click, btnButtonBackColor.Click
        If Me.SelectColorDialog.ShowDialog(Me) = DialogResult.OK Then
            DirectCast(sender, Control).BackColor = Me.SelectColorDialog.Color
        End If
    End Sub

    Private Sub BtnSaveConfigurationClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveConfiguration.Click
        FormBackColor = Me.btnFormBackColor.BackColor
        FormForeColor = Me.btnFormForeColor.BackColor
        ButtonBackColor = Me.btnButtonBackColor.BackColor
        ButtonForeColor = Me.btnButtonForeColor.BackColor
        LabelBackColor = Me.btnLabelBackColor.BackColor
        LabelForeColor = Me.btnLabelForeColor.BackColor
        TextBoxBackColor = Me.btnTextBoxBackColor.BackColor
        TextBoxForeColor = Me.btnTextBoxForeColor.BackColor
        GroupBoxBackColor = Me.btnGroupBoxBackColor.BackColor
        GroupBoxForeColor = Me.btnGroupBoxForeColor.BackColor
    End Sub

    Private Sub BtnCancelClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ConfigurationFormLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.btnFormBackColor.BackColor = FormBackColor
        Me.btnFormForeColor.BackColor = FormForeColor
        Me.btnButtonBackColor.BackColor = ButtonBackColor
        Me.btnButtonForeColor.BackColor = ButtonForeColor
        Me.btnLabelBackColor.BackColor = LabelBackColor
        Me.btnLabelForeColor.BackColor = LabelForeColor
        Me.btnTextBoxBackColor.BackColor = TextBoxBackColor
        Me.btnTextBoxForeColor.BackColor = TextBoxForeColor
        Me.btnGroupBoxBackColor.BackColor = GroupBoxBackColor
        Me.btnGroupBoxForeColor.BackColor = GroupBoxForeColor
    End Sub

End Class

