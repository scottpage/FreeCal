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
    Private label1 As System.Windows.Forms.Label
    Private tbGPIBTraffic As System.Windows.Forms.TextBox
    Private WithEvents testEditorPanel1 As FreeCal.Editor.TestEditorPanel
    Private propertyGrid1 As System.Windows.Forms.PropertyGrid
    Private cbAddress As System.Windows.Forms.ComboBox
    Private tvInstruments As System.Windows.Forms.TreeView

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
        Me.tvInstruments = New System.Windows.Forms.TreeView
        Me.cbAddress = New System.Windows.Forms.ComboBox
        Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid
        Me.testEditorPanel1 = New FreeCal.Editor.TestEditorPanel
        Me.tbGPIBTraffic = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'tvInstruments
        '
        Me.tvInstruments.AllowDrop = True
        Me.tvInstruments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
           Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tvInstruments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tvInstruments.ImageIndex = -1
        Me.tvInstruments.Location = New System.Drawing.Point(8, 8)
        Me.tvInstruments.Name = "tvInstruments"
        Me.tvInstruments.Nodes.AddRange(New System.Windows.Forms.TreeNode() {New System.Windows.Forms.TreeNode("Signal Generators"), New System.Windows.Forms.TreeNode("Spectrum Analyzers"), New System.Windows.Forms.TreeNode("Network Analyzers"), New System.Windows.Forms.TreeNode("Power Meters"), New System.Windows.Forms.TreeNode("Microwave Counters"), New System.Windows.Forms.TreeNode("Function Generators"), New System.Windows.Forms.TreeNode("Measuring Receivers")})
        Me.tvInstruments.SelectedImageIndex = -1
        Me.tvInstruments.Size = New System.Drawing.Size(152, 224)
        Me.tvInstruments.TabIndex = 0
        AddHandler Me.tvInstruments.MouseDown, AddressOf Me.LbControlsMouseDown
        AddHandler Me.tvInstruments.DragLeave, AddressOf Me.TvInstrumentsDragLeave
        '
        'cbAddress
        '
        Me.cbAddress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbAddress.Location = New System.Drawing.Point(8, 248)
        Me.cbAddress.Name = "cbAddress"
        Me.cbAddress.Size = New System.Drawing.Size(152, 21)
        Me.cbAddress.TabIndex = 0
        '
        'propertyGrid1
        '
        Me.propertyGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
           Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.propertyGrid1.CommandsVisibleIfAvailable = True
        Me.propertyGrid1.LargeButtons = False
        Me.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
        Me.propertyGrid1.Location = New System.Drawing.Point(608, 8)
        Me.propertyGrid1.Name = "propertyGrid1"
        Me.propertyGrid1.Size = New System.Drawing.Size(256, 560)
        Me.propertyGrid1.TabIndex = 2
        Me.propertyGrid1.Text = "PropertyGrid"
        Me.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window
        Me.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText
        '
        'testEditorPanel1
        '
        Me.testEditorPanel1.AllowDrop = True
        Me.testEditorPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
           Or System.Windows.Forms.AnchorStyles.Left) _
           Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.testEditorPanel1.AutoScroll = True
        Me.testEditorPanel1.BackColor = System.Drawing.Color.LightGray
        Me.testEditorPanel1.Location = New System.Drawing.Point(168, 8)
        Me.testEditorPanel1.Name = "testEditorPanel1"
        Me.testEditorPanel1.Size = New System.Drawing.Size(432, 560)
        Me.testEditorPanel1.TabIndex = 3
        AddHandler Me.testEditorPanel1.InstrumentAdded, AddressOf Me.TestEditorPanel1InstrumentAdded
        AddHandler Me.testEditorPanel1.InstrumentClick, AddressOf Me.TestEditorPanel1InstrumentClick
        AddHandler Me.testEditorPanel1.InstrumentDeleted, AddressOf Me.TestEditorPanel1InstrumentDeleted
        '
        'tbGPIBTraffic
        '
        Me.tbGPIBTraffic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbGPIBTraffic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbGPIBTraffic.Location = New System.Drawing.Point(8, 272)
        Me.tbGPIBTraffic.Multiline = True
        Me.tbGPIBTraffic.Name = "tbGPIBTraffic"
        Me.tbGPIBTraffic.Size = New System.Drawing.Size(152, 296)
        Me.tbGPIBTraffic.TabIndex = 0
        Me.tbGPIBTraffic.Text = ""
        '
        'label1
        '
        Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(56, 232)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(49, 17)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Address"
        '
        'EditorForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(872, 573)
        Me.Controls.Add(Me.testEditorPanel1)
        Me.Controls.Add(Me.propertyGrid1)
        Me.Controls.Add(Me.tvInstruments)
        Me.Controls.Add(Me.tbGPIBTraffic)
        Me.Controls.Add(Me.cbAddress)
        Me.Controls.Add(Me.label1)
        Me.Name = "EditorForm"
        Me.Text = "MainForm"
        AddHandler Load, AddressOf Me.MainFormLoad
        Me.ResumeLayout(False)
    End Sub
#End Region

    Private Sub LbControlsMouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Me.tvInstruments.DoDragDrop(Me.tvInstruments.SelectedNode.Text, DragDropEffects.Copy)
    End Sub

    Private Sub MainFormLoad(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub TestEditorPanel1InstrumentClick(ByVal currentinstrument As InstrumentControl)
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

    Private Sub TestEditorPanel1InstrumentAdded(ByVal newinstrument As InstrumentControl)
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

    Private Sub TvInstrumentsDragLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.testEditorPanel1.Tag = Me.cbAddress.SelectedItem
    End Sub

    Private Sub TestEditorPanel1InstrumentDeleted(ByVal primaryAddress As System.Byte)
        Me.cbAddress.Items.Add(primaryAddress)
        Me.SortAddressList()
        Me.propertyGrid1.SelectedObject = Nothing
        Me.cbAddress.SelectedIndex = 0
    End Sub

End Class

