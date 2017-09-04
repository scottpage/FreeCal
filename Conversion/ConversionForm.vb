'
' Created by SharpDevelop.
' User: rspage
' Date: 6/30/2005
' Time: 10:02 AM
' 

Imports System
Imports FreeCal.Common

Public Enum ConversionUnits
		GigaHertz
		MegaHertz
		KiloHertz
		Hertz
		milliHertz
		microHertz
		nanoHertz
		picoHertz
		dBm
		megaWatt
		kiloWatt
		Watt
		milliWatt
		microWatt
		nanoWatt
		picoWatt
		megaAmp
		kiloAmp
		Amp
		milliAmp
		microAmp
		nanoAmp
		picoAmp
		Year
		Month
		Day
		Hour
		Minute
		Second
		milliSecond
		microSecond
		nanoSecond
		picoSecond
		megaVolt
		kiloVolt
		Volt
		milliVolt
		microVolt
		nanoVolt
		picoVolt
	End Enum

	Public Class ConversionForm
    Inherits System.Windows.Forms.Form

    Private WithEvents lbFromUnit As System.Windows.Forms.ListBox
    Private WithEvents lbToUnit As System.Windows.Forms.ListBox
    Private WithEvents tbOriginalValue As System.Windows.Forms.TextBox
    Private WithEvents btnConvert As System.Windows.Forms.Button
    Private WithEvents lblResult As System.Windows.Forms.Label

    Public Sub New()
			MyBase.New
			'
			' The Me.InitializeComponent call is required for Windows Forms designer support.
			'
			Me.InitializeComponent
			Me.FillListBoxes
		End Sub
		
		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.tbOriginalValue = New System.Windows.Forms.TextBox()
        Me.lbToUnit = New System.Windows.Forms.ListBox()
        Me.lbFromUnit = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
        Me.lblResult.Location = New System.Drawing.Point(336, 133)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(10, 13)
        Me.lblResult.TabIndex = 4
        Me.lblResult.Text = " "
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(272, 74)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(150, 42)
        Me.btnConvert.TabIndex = 0
        Me.btnConvert.Text = "Convert"
        '
        'tbOriginalValue
        '
        Me.tbOriginalValue.Location = New System.Drawing.Point(272, 15)
        Me.tbOriginalValue.Name = "tbOriginalValue"
        Me.tbOriginalValue.Size = New System.Drawing.Size(144, 31)
        Me.tbOriginalValue.TabIndex = 2
        '
        'lbToUnit
        '
        Me.lbToUnit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbToUnit.ItemHeight = 25
        Me.lbToUnit.Location = New System.Drawing.Point(448, 15)
        Me.lbToUnit.Name = "lbToUnit"
        Me.lbToUnit.Size = New System.Drawing.Size(240, 629)
        Me.lbToUnit.TabIndex = 5
        '
        'lbFromUnit
        '
        Me.lbFromUnit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbFromUnit.ItemHeight = 25
        Me.lbFromUnit.Location = New System.Drawing.Point(16, 15)
        Me.lbFromUnit.Name = "lbFromUnit"
        Me.lbFromUnit.Size = New System.Drawing.Size(240, 629)
        Me.lbFromUnit.TabIndex = 3
        '
        'ConversionForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 24)
        Me.ClientSize = New System.Drawing.Size(783, 691)
        Me.Controls.Add(Me.lbToUnit)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.lbFromUnit)
        Me.Controls.Add(Me.tbOriginalValue)
        Me.Controls.Add(Me.btnConvert)
        Me.Name = "ConversionForm"
        Me.Text = "Unit Conversion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub FillListBoxes()
        Me.lbFromUnit.DataSource = [Enum].GetNames(GetType(ConversionUnits))
        Me.lbToUnit.DataSource = [Enum].GetNames(GetType(ConversionUnits))
    End Sub

    Private Sub BtnConvertClick(sender As System.Object, e As System.EventArgs) Handles btnConvert.Click
        Dim FromUnit As ConversionUnits = CType([Enum].Parse(GetType(ConversionUnits), Convert.ToString(lbFromUnit.SelectedItem)), ConversionUnits)
        Dim ToUnit As ConversionUnits = CType([Enum].Parse(GetType(ConversionUnits), Convert.ToString(lbToUnit.SelectedItem)), ConversionUnits)
        Select Case FromUnit
            Case ConversionUnits.GigaHertz
                Select Case ToUnit
                    Case ConversionUnits.MegaHertz
                        Me.lblResult.Text = CType(ConvertFrequency.Convert(Convert.ToDouble(tbOriginalValue.Text), FrequencyEnum.GHz, FrequencyEnum.MHz), String)
                End Select
        End Select
    End Sub

End Class

