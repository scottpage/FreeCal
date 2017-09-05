'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/16/2005
' Time: 7:35 PM
' 


Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Collections
Imports FreeCal.Common



Public Class PowerSensorTestFrequencyForm
    Inherits System.Windows.Forms.Form
    Private button2 As System.Windows.Forms.Button
    Private label1 As System.Windows.Forms.Label
    Private tbFrequencyToAdd As System.Windows.Forms.TextBox
    Private btnRemove As System.Windows.Forms.Button
    Private btnAdd As System.Windows.Forms.Button
    Private button1 As System.Windows.Forms.Button
    Private comboBox1 As System.Windows.Forms.ComboBox
    Private listBox1 As System.Windows.Forms.ListBox

    Public FrequencyList() As Double
    Public FrequencyListSuffix As FrequencyEnum

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
        Me.listBox1 = New System.Windows.Forms.ListBox
        Me.comboBox1 = New System.Windows.Forms.ComboBox
        Me.button1 = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.tbFrequencyToAdd = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.button2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'listBox1
        '
        Me.listBox1.Items.AddRange(New Object() {"0.05", "2", "10", "14", "18", "20", "22", "24", "26", "28", "30", "32", "34", "36", "38", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50"})
        Me.listBox1.Location = New System.Drawing.Point(8, 8)
        Me.listBox1.Name = "listBox1"
        Me.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.listBox1.Size = New System.Drawing.Size(224, 485)
        Me.listBox1.TabIndex = 5
        '
        'comboBox1
        '
        Me.comboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comboBox1.Items.AddRange(New Object() {"GHz", "MHz", "KHz", "Hz"})
        Me.comboBox1.Location = New System.Drawing.Point(256, 312)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(121, 21)
        Me.comboBox1.TabIndex = 3
        Me.comboBox1.Text = "GHz"
        '
        'button1
        '
        Me.button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.button1.Location = New System.Drawing.Point(240, 472)
        Me.button1.Name = "button1"
        Me.button1.TabIndex = 1
        Me.button1.Text = "Ok"
        AddHandler Me.button1.Click, AddressOf Me.Button1Click
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(240, 8)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.TabIndex = 6
        Me.btnAdd.Text = "Add"
        AddHandler Me.btnAdd.Click, AddressOf Me.btnAddClick
        '
        'btnRemove
        '
        Me.btnRemove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemove.Location = New System.Drawing.Point(240, 40)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.TabIndex = 7
        Me.btnRemove.Text = "Remove"
        AddHandler Me.btnRemove.Click, AddressOf Me.btnRemoveClick
        '
        'tbFrequencyToAdd
        '
        Me.tbFrequencyToAdd.Location = New System.Drawing.Point(240, 72)
        Me.tbFrequencyToAdd.Name = "tbFrequencyToAdd"
        Me.tbFrequencyToAdd.TabIndex = 8
        Me.tbFrequencyToAdd.Text = ""
        '
        'label1
        '
        Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(264, 288)
        Me.label1.Name = "label1"
        Me.label1.TabIndex = 4
        Me.label1.Text = "Frequency Suffix"
        '
        'button2
        '
        Me.button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.button2.Location = New System.Drawing.Point(336, 472)
        Me.button2.Name = "button2"
        Me.button2.TabIndex = 2
        Me.button2.Text = "Cancel"
        AddHandler Me.button2.Click, AddressOf Me.Button2Click
        '
        'PowerSensorTestFrequencyForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(432, 509)
        Me.Controls.Add(Me.tbFrequencyToAdd)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.listBox1)
        Me.Controls.Add(Me.comboBox1)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.label1)
        Me.MinimumSize = New System.Drawing.Size(440, 168)
        Me.Name = "PowerSensorTestFrequencyForm"
        Me.Text = "PowerSensorTestFrequencyForm"
        Me.ResumeLayout(False)
    End Sub
#End Region

    Private Sub Button2Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1Click(sender As System.Object, e As System.EventArgs)
        Dim Fs(Me.listBox1.Items.Count - 1) As Double
        For F As Integer = 0 To Me.listBox1.Items.Count - 1
            Fs(F) = CDbl(Me.listBox1.Items(F))
        Next
        Me.FrequencyList = Fs
        Me.FrequencyListSuffix = CType([Enum].Parse(GetType(FrequencyEnum), Me.comboBox1.SelectedItem.ToString), FrequencyEnum)
        Me.Close()
    End Sub

    Private Sub btnAddClick(sender As System.Object, e As System.EventArgs)
        Me.listBox1.Items.Add(Me.tbFrequencyToAdd.Text.Trim)
        Me.SortFrequencyList()
    End Sub

    Private Sub btnRemoveClick(sender As System.Object, e As System.EventArgs)
        For I As Integer = Me.listBox1.SelectedIndices.Count - 1 To 0 Step -1
            Me.listBox1.Items.RemoveAt(Me.listBox1.SelectedIndices(I))
        Next
    End Sub

    Private Sub SortFrequencyList()
        Dim AL As New ArrayList
        For Each V As Double In Me.listBox1.Items
            AL.Add(CDbl(V))
        Next
        AL.Sort(New SingleComparer)
        Me.listBox1.Items.Clear()

        For Each V As Double In AL
            Me.listBox1.Items.Add(V)
        Next
    End Sub

End Class


