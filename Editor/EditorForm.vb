'
' Created by SharpDevelop.
' User: Administrator
' Date: 7/14/2005
' Time: 9:43 PM
'

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel.Design.Serialization
Imports System.Reflection
Imports Microsoft.VisualBasic.ControlChars
Imports FreeCal.Instruments
Imports FreeCal.Instruments.SignalGenerators
Imports FreeCal.Instruments.NetworkAnalyzers
Imports FreeCal.Instruments.PowerMeters
Imports FreeCal.Instruments.SpectrumAnalyzers
Imports FreeCal.Common
Imports System.Collections


Public Class EditorForm
    Inherits System.Windows.Forms.Form
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents tbGPIBTraffic As System.Windows.Forms.TextBox
    Private WithEvents testEditorPanel1 As FreeCal.Editor.TestEditorPanel
    Private WithEvents propertyGrid1 As System.Windows.Forms.PropertyGrid
    Private WithEvents cbAddress As System.Windows.Forms.ComboBox
    Friend WithEvents SplitContainer1 As SplitContainer
    Private WithEvents tvInstruments As System.Windows.Forms.TreeView

    Public Shared Sub Main()
        Dim fMainForm As New EditorForm
        fMainForm.ShowDialog()
    End Sub

    Public Sub New()
        MyBase.New()
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
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Signal Generators")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Spectrum Analyzers")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Network Analyzers")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Power Meters")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Microwave Counters")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Function Generators")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Measuring Receivers")
        Me.tvInstruments = New System.Windows.Forms.TreeView()
        Me.cbAddress = New System.Windows.Forms.ComboBox()
        Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.tbGPIBTraffic = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.testEditorPanel1 = New FreeCal.Editor.TestEditorPanel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvInstruments
        '
        Me.tvInstruments.AllowDrop = True
        Me.tvInstruments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvInstruments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvInstruments.Location = New System.Drawing.Point(16, 15)
        Me.tvInstruments.Name = "tvInstruments"
        TreeNode8.Name = ""
        TreeNode8.Text = "Signal Generators"
        TreeNode9.Name = ""
        TreeNode9.Text = "Spectrum Analyzers"
        TreeNode10.Name = ""
        TreeNode10.Text = "Network Analyzers"
        TreeNode11.Name = ""
        TreeNode11.Text = "Power Meters"
        TreeNode12.Name = ""
        TreeNode12.Text = "Microwave Counters"
        TreeNode13.Name = ""
        TreeNode13.Text = "Function Generators"
        TreeNode14.Name = ""
        TreeNode14.Text = "Measuring Receivers"
        Me.tvInstruments.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode8, TreeNode9, TreeNode10, TreeNode11, TreeNode12, TreeNode13, TreeNode14})
        Me.tvInstruments.Size = New System.Drawing.Size(304, 604)
        Me.tvInstruments.TabIndex = 0
        '
        'cbAddress
        '
        Me.cbAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbAddress.Location = New System.Drawing.Point(16, 649)
        Me.cbAddress.Name = "cbAddress"
        Me.cbAddress.Size = New System.Drawing.Size(304, 33)
        Me.cbAddress.TabIndex = 0
        '
        'propertyGrid1
        '
        Me.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
        Me.propertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.propertyGrid1.Name = "propertyGrid1"
        Me.propertyGrid1.Size = New System.Drawing.Size(547, 1204)
        Me.propertyGrid1.TabIndex = 2
        '
        'tbGPIBTraffic
        '
        Me.tbGPIBTraffic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbGPIBTraffic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbGPIBTraffic.Location = New System.Drawing.Point(16, 693)
        Me.tbGPIBTraffic.Multiline = True
        Me.tbGPIBTraffic.Name = "tbGPIBTraffic"
        Me.tbGPIBTraffic.Size = New System.Drawing.Size(304, 547)
        Me.tbGPIBTraffic.TabIndex = 0
        '
        'label1
        '
        Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(112, 619)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(91, 25)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Address"
        '
        'testEditorPanel1
        '
        Me.testEditorPanel1.AllowDrop = True
        Me.testEditorPanel1.AutoScroll = True
        Me.testEditorPanel1.BackColor = System.Drawing.Color.LightGray
        Me.testEditorPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.testEditorPanel1.Location = New System.Drawing.Point(0, 0)
        Me.testEditorPanel1.Name = "testEditorPanel1"
        Me.testEditorPanel1.Size = New System.Drawing.Size(874, 1204)
        Me.testEditorPanel1.TabIndex = 3
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(340, 15)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.testEditorPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.propertyGrid1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1425, 1204)
        Me.SplitContainer1.SplitterDistance = 874
        Me.SplitContainer1.TabIndex = 4
        '
        'EditorForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(1790, 1249)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.tvInstruments)
        Me.Controls.Add(Me.tbGPIBTraffic)
        Me.Controls.Add(Me.cbAddress)
        Me.Controls.Add(Me.label1)
        Me.Name = "EditorForm"
        Me.Text = "Visual Editor"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub LbControlsMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tvInstruments.MouseDown
        Me.tvInstruments.DoDragDrop(Me.tvInstruments.SelectedNode.Text, DragDropEffects.Copy)
    End Sub

    Private Sub MainFormLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For I As Integer = 1 To 30
            Me.cbAddress.Items.Add(I)
        Next
        Me.cbAddress.SelectedIndex = 0
        Dim FCResources As String = ResourceDirectory & "\FreeCal.Instruments."
        'Dim FCResources As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\FreeCalVS\Program\Resources\FreeCal.Instruments."
        Dim SignalGeneratorAssembly As [Assembly] = [Assembly].LoadFrom(FCResources & "SignalGenerators.dll")
        For Each Res As [Type] In SignalGeneratorAssembly.GetTypes
            Try
                If Res.BaseType.Name = "SignalGenerator" Then
                    Me.tvInstruments.Nodes(0).Nodes.Add(New TreeNode(Res.Name))
                End If
            Catch Ex As Exception
                'MessageBox.Show(Ex.ToString)
            End Try
        Next
        SignalGeneratorAssembly = Nothing
        Dim NetworkAnalyzerAssembly As [Assembly] = [Assembly].LoadFrom(FCResources & "NetworkAnalyzers.dll")
        For Each Res As [Type] In NetworkAnalyzerAssembly.GetTypes
            Try
                If Res.BaseType.Name = "NetworkAnalyzer" Then
                    Me.tvInstruments.Nodes(2).Nodes.Add(New TreeNode(Res.Name))
                End If
            Catch Ex As Exception
                'MessageBox.Show(Ex.ToString)
            End Try
        Next
        NetworkAnalyzerAssembly = Nothing
        Dim PowerMeterAssembly As [Assembly] = [Assembly].LoadFrom(FCResources & "PowerMeters.dll")
        For Each Res As [Type] In PowerMeterAssembly.GetTypes
            Try
                If Res.BaseType.Name = "PowerMeter" Then
                    Me.tvInstruments.Nodes(3).Nodes.Add(New TreeNode(Res.Name))
                End If
            Catch Ex As Exception
                'MessageBox.Show(Ex.ToString)
            End Try
        Next
        PowerMeterAssembly = Nothing
        Dim SpectrumAnalyzerAssembly As [Assembly] = [Assembly].LoadFrom(FCResources & "SpectrumAnalyzers.dll")
        For Each Res As [Type] In SpectrumAnalyzerAssembly.GetTypes
            Try
                If Res.BaseType.Name = "SpectrumAnalyzer" Then
                    Me.tvInstruments.Nodes(1).Nodes.Add(New TreeNode(Res.Name))
                End If
            Catch Ex As Exception
                'MessageBox.Show(Ex.ToString)
            End Try
        Next
        SpectrumAnalyzerAssembly = Nothing
    End Sub

    Private Sub TestEditorPanel1InstrumentClick(ByVal currentinstrument As InstrumentControl) Handles testEditorPanel1.InstrumentClick
        Select Case currentinstrument.InstrumentType
            Case InstrumentTypeEnum.NetworkAnalyzer
                Me.propertyGrid1.SelectedObject = CType(currentinstrument.Instrument, NetworkAnalyzer)
            Case InstrumentTypeEnum.SignalGenerator
                Me.propertyGrid1.SelectedObject = CType(currentinstrument.Instrument, SignalGenerator)
            Case InstrumentTypeEnum.PowerMeter
                Me.propertyGrid1.SelectedObject = CType(currentinstrument.Instrument, PowerMeter)
            Case InstrumentTypeEnum.SpectrumAnalyzer
                Me.propertyGrid1.SelectedObject = CType(currentinstrument.Instrument, SpectrumAnalyzer)
        End Select
        Me.propertyGrid1.Update()
    End Sub

    Private Sub TestEditorPanel1DataSent(ByVal currentinstrument As InstrumentControl, ByVal data As String) Handles testEditorPanel1.DataSent
        Me.tbGPIBTraffic.AppendText(currentinstrument.Instrument.PrimaryAddress & " - " & data & NewLine)
        Me.Refresh()
    End Sub

    Private Sub SortAddressList()
        Dim AL As New ArrayList
        For Each V As Integer In Me.cbAddress.Items
            AL.Add(CInt(V))
        Next
        AL.Sort(New SingleComparer)
        Me.cbAddress.Items.Clear()
        For Each V As Double In AL
            Me.cbAddress.Items.Add(V)
        Next
        Me.cbAddress.SelectedIndex = 0
    End Sub

    Private Sub TestEditorPanel1InstrumentAdded(ByVal newinstrument As InstrumentControl) Handles testEditorPanel1.InstrumentAdded
        Me.propertyGrid1.SelectedObject = newinstrument.Instrument
        Dim MatchedRow As Integer = -1
        For I As Integer = 0 To Me.cbAddress.Items.Count - 1
            If Convert.ToByte(Me.cbAddress.Items(I)) = newinstrument.Instrument.PrimaryAddress Then
                MatchedRow = I
            End If
        Next
        If Not MatchedRow = -1 Then
            Me.cbAddress.Items.RemoveAt(MatchedRow)
        End If
    End Sub

    Private Sub TvInstrumentsDragLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tvInstruments.DragLeave
        Me.testEditorPanel1.Tag = Me.cbAddress.SelectedItem
    End Sub

    Private Sub TestEditorPanel1InstrumentDeleted(ByVal primaryAddress As System.Byte) Handles testEditorPanel1.InstrumentDeleted
        Me.cbAddress.Items.Add(primaryAddress)
        Me.SortAddressList()
        Me.propertyGrid1.SelectedObject = Nothing
        Me.cbAddress.SelectedIndex = 0
    End Sub

End Class

