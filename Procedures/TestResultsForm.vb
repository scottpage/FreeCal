'
' Created by SharpDevelop.
' User: rspage
' Date: 6/29/2005
' Time: 9:37 AM
' 



Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data
Imports FreeCal.Data
Imports MySql.Data.MySqlClient
Imports FreeCal.Common
Imports ZedGraph



Public Class TestResultsForm
    Inherits System.Windows.Forms.Form
    Protected _MeasurementsPPL As PointPairList
    Protected _UpperTolerancePPL As PointPairList
    Protected _LowerTolerancePPL As PointPairList
    Protected _DUTAssetNumber As String
    Protected lblCurrentParameters As System.Windows.Forms.Label
    Protected chtResults As ZedGraph.ZedGraphControl
    Protected dgResults As System.Windows.Forms.DataGrid

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        Me.dgResults = New System.Windows.Forms.DataGrid
        Me.chtResults = New ZedGraph.ZedGraphControl
        Me.lblCurrentParameters = New System.Windows.Forms.Label
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgResults
        '
        Me.dgResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgResults.DataMember = ""
        Me.dgResults.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgResults.Location = New System.Drawing.Point(416, 8)
        Me.dgResults.Name = "dgResults"
        Me.dgResults.Size = New System.Drawing.Size(400, 400)
        Me.dgResults.TabIndex = 1
        '
        'chtResults
        '
        Me.chtResults.IsEnableHPan = True
        Me.chtResults.IsEnableVPan = True
        Me.chtResults.IsEnableZoom = True
        Me.chtResults.IsShowContextMenu = True
        Me.chtResults.IsShowPointValues = True
        Me.chtResults.Location = New System.Drawing.Point(8, 8)
        Me.chtResults.Name = "chtResults"
        Me.chtResults.PointDateFormat = "g"
        Me.chtResults.PointValueFormat = "G"
        Me.chtResults.Size = New System.Drawing.Size(400, 400)
        Me.chtResults.TabIndex = 3
        '
        'lblCurrentParameters
        '
        Me.lblCurrentParameters.AutoSize = True
        Me.lblCurrentParameters.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblCurrentParameters.Location = New System.Drawing.Point(352, 416)
        Me.lblCurrentParameters.Name = "lblCurrentParameters"
        Me.lblCurrentParameters.Size = New System.Drawing.Size(116, 17)
        Me.lblCurrentParameters.TabIndex = 2
        Me.lblCurrentParameters.Text = "Current Parameters"
        '
        'TestResultsForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(824, 437)
        Me.Controls.Add(Me.chtResults)
        Me.Controls.Add(Me.dgResults)
        Me.Controls.Add(Me.lblCurrentParameters)
        Me.Name = "TestResultsForm"
        Me.Text = "Test Results"
        CType(Me.dgResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub
#End Region

    Public ReadOnly Property DUTAssetNumber As String
        Get
            Return Me._DUTAssetNumber
        End Get
    End Property

    Public ReadOnly Property ChartTitle As String
        Get
            Return Me.chtResults.GraphPane.Title.Text
        End Get
    End Property

    Public ReadOnly Property ChartXAxisTitle As String
        Get
            Return Me.chtResults.GraphPane.XAxis.Title.Text
        End Get
    End Property

    Public ReadOnly Property ChartYAxisTitle As String
        Get
            Return Me.chtResults.GraphPane.YAxis.Title.Text
        End Get
    End Property

End Class

