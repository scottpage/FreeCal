'
' Created by SharpDevelop.
' User: rspage
' Date: 4/27/2005
' Time: 3:30 PM
' 
'

Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports FreeCal.Common
Imports FreeCal.Data
Imports System.Data
Imports System.Collections
Imports MySql.Data.MySqlClient
Imports FreeCal.Instruments.NetworkAnalyzers
Imports FreeCal.Instruments.NetworkAnalyzers.Agilent8510C
Imports Microsoft.VisualBasic
Imports System.IO
'Imports iTextSharp.text
'Imports iTextSharp.text.pdf


	
	Public Class AgilentNetworkAnalyzerForm
		Inherits System.Windows.Forms.Form
		Private NWA As NetworkAnalyzer
		Private _Data As New DataTable
		Private label10 As System.Windows.Forms.Label
		Private btnExportToExcel As System.Windows.Forms.Button
		Private btnGetDataList As System.Windows.Forms.Button
		Private tbAssetNumber As System.Windows.Forms.TextBox
		Private button1 As System.Windows.Forms.Button
		Private dgMeasurementResults As System.Windows.Forms.DataGrid
		Private btnCalibrate As System.Windows.Forms.Button
		
        Public Sub New(ByRef NWA As NetworkAnalyzer)
			MyBase.New
			Me.InitializeComponent
			Me.NWA = NWA
            SetControlConfigurationOptions(Me, Me.Controls)
			Me._Data.Columns.Add(New DataColumn("Point"))
			Me._Data.Columns.Add(New DataColumn("Frequency"))
			Me._Data.Columns.Add(New DataColumn("Lin Mag"))
			Me._Data.Columns.Add(New DataColumn("Phase"))
			Me._Data.Columns.Add(New DataColumn("SWR"))
        End Sub

		#Region " Windows Forms Designer generated code "
		' This method is required for Windows Forms designer support.
		' Do not change the method contents inside the source code editor. The Forms designer might
		' not be able to load this method if it was changed manually.
		Private Sub InitializeComponent()
			Me.btnCalibrate = New System.Windows.Forms.Button
			Me.dgMeasurementResults = New System.Windows.Forms.DataGrid
			Me.button1 = New System.Windows.Forms.Button
			Me.tbAssetNumber = New System.Windows.Forms.TextBox
			Me.btnGetDataList = New System.Windows.Forms.Button
			Me.btnExportToExcel = New System.Windows.Forms.Button
			Me.label10 = New System.Windows.Forms.Label
			CType(Me.dgMeasurementResults,System.ComponentModel.ISupportInitialize).BeginInit
			Me.SuspendLayout
			'
			'btnCalibrate
			'
			Me.btnCalibrate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.btnCalibrate.Location = New System.Drawing.Point(688, 456)
			Me.btnCalibrate.Name = "btnCalibrate"
			Me.btnCalibrate.Size = New System.Drawing.Size(80, 23)
			Me.btnCalibrate.TabIndex = 38
			Me.btnCalibrate.Text = "Calibrate"
			AddHandler Me.btnCalibrate.Click, AddressOf Me.BtnCalibrateClick
			'
			'dgMeasurementResults
			'
			Me.dgMeasurementResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.dgMeasurementResults.DataMember = ""
			Me.dgMeasurementResults.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.dgMeasurementResults.Location = New System.Drawing.Point(0, 0)
			Me.dgMeasurementResults.Name = "dgMeasurementResults"
			Me.dgMeasurementResults.Size = New System.Drawing.Size(680, 581)
			Me.dgMeasurementResults.TabIndex = 1
			'
			'button1
			'
			Me.button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.button1.Location = New System.Drawing.Point(776, 456)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(88, 23)
			Me.button1.TabIndex = 39
			Me.button1.Text = "Export to PDF"
			AddHandler Me.button1.Click, AddressOf Me.Button1Click
			'
			'tbAssetNumber
			'
			Me.tbAssetNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.tbAssetNumber.Location = New System.Drawing.Point(744, 24)
			Me.tbAssetNumber.Name = "tbAssetNumber"
			Me.tbAssetNumber.Size = New System.Drawing.Size(120, 20)
			Me.tbAssetNumber.TabIndex = 18
			Me.tbAssetNumber.Text = ""
			'
			'btnGetDataList
			'
			Me.btnGetDataList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.btnGetDataList.Location = New System.Drawing.Point(688, 424)
			Me.btnGetDataList.Name = "btnGetDataList"
			Me.btnGetDataList.Size = New System.Drawing.Size(80, 23)
			Me.btnGetDataList.TabIndex = 0
			Me.btnGetDataList.Text = "Get Data"
			AddHandler Me.btnGetDataList.Click, AddressOf Me.btnGetDataListClick
			'
			'btnExportToExcel
			'
			Me.btnExportToExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.btnExportToExcel.Location = New System.Drawing.Point(776, 424)
			Me.btnExportToExcel.Name = "btnExportToExcel"
			Me.btnExportToExcel.Size = New System.Drawing.Size(88, 23)
			Me.btnExportToExcel.TabIndex = 37
			Me.btnExportToExcel.Text = "Export to Excel"
			AddHandler Me.btnExportToExcel.Click, AddressOf Me.BtnExportToExcelClick
			'
			'label10
			'
			Me.label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
			Me.label10.AutoSize = true
			Me.label10.Font = New System.Drawing.Font("Tahoma", 11!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World)
			Me.label10.Location = New System.Drawing.Point(744, 8)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(84, 17)
			Me.label10.TabIndex = 29
			Me.label10.Text = "Asset Number"
			'
			'AgilentNetworkAnalyzerForm
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(872, 581)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.btnCalibrate)
			Me.Controls.Add(Me.btnExportToExcel)
			Me.Controls.Add(Me.tbAssetNumber)
			Me.Controls.Add(Me.dgMeasurementResults)
			Me.Controls.Add(Me.btnGetDataList)
			Me.Controls.Add(Me.label10)
			Me.Location = New System.Drawing.Point(13, 13)
			Me.Name = "AgilentNetworkAnalyzerForm"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Communicate with Agilent Network Analyzer"
			CType(Me.dgMeasurementResults,System.ComponentModel.ISupportInitialize).EndInit
			Me.ResumeLayout(false)
		End Sub
		#End Region

		Private Sub btnGetDataListClick(sender As System.Object, e As System.EventArgs)
			Me.dgMeasurementResults.DataMember = ""
			Me.dgMeasurementResults.DataSource = Nothing
			Dim DT As DataTable = Me.NWA.Sections.Output.GetFullData
			Me.dgMeasurementResults.DataMember = DT.TableName
			Me.dgMeasurementResults.DataSource = DT
		End Sub

		Private Sub BtnStoreDataClick(sender As System.Object, e As System.EventArgs)
		End Sub

		Private Sub BtnClearDataClick(sender As System.Object, e As System.EventArgs)
			Me.dgMeasurementResults.DataSource = Nothing
		End Sub

		Private Sub BtnExportToExcelClick(sender As System.Object, e As System.EventArgs)
		End Sub

		Private Sub BtnCalibrateClick(sender As System.Object, e As System.EventArgs)
			Me.NWA.Sections.Calibration.S11OnePort(ConnectorTypeEnum.N, GenderEnum.Female, NetworkAnalyzerLoadEnum.BroadBand)
		End Sub

		Private Sub Button1Click(sender As System.Object, e As System.EventArgs)
'			Dim DT As DataTable = Me.dgMeasurementResults.DataSource
'			Dim T As New Document(PageSize.A4, 10, 10, 10, 10)
'			PDFWriter.GetInstance(T, New FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & Me.tbAssetNumber.Text & "-" & Format(DateTime.Now.Month, "00") & DateTime.Now.Year.ToString.Substring(2) & ".pdf", FileMode.Create))
'			T.AddAuthor("Scott Page")
'			T.AddCreationDate
'			T.AddCreator("Scott Page")
'			T.AddSubject("Calibration Data")
'			T.AddTitle("Calibration Data for " & Me.tbAssetNumber.Text)
'			Dim h1 As new Paragraph("Technical Operations", FontFactory.getFont(FontFactory.TIMES_BOLD, 16))
'			Dim h2 As new Paragraph("Stennis Integrated Metrology Center", FontFactory.getFont(FontFactory.TIMES, 16))
'			Dim p1 As new Paragraph("Calibration Data", FontFactory.getFont(FontFactory.TIMES_BOLD, 18))
'			Dim p2 As new Paragraph("Model Number:  " & Me.NWA.Model, FontFactory.getFont(FontFactory.TIMES, 10))
'			Dim p3 As new Paragraph("Serial Number:  3312A48834", FontFactory.getFont(FontFactory.TIMES, 10)) 
'			Dim p4 As New Paragraph("Asset Number:  " & Me.tbAssetNumber.Text, FontFactory.getFont(FontFactory.TIMES, 10))
'			h1.Alignment = Element.ALIGN_CENTER
'			h2.Alignment = Element.ALIGN_CENTER
'			p1.Alignment = Element.ALIGN_CENTER
'			p2.Alignment = Element.ALIGN_CENTER
'			p3.Alignment = Element.ALIGN_CENTER
'			p4.Alignment = Element.ALIGN_CENTER
'			Dim F As New HeaderFooter(New Phrase("Page "), True)
'			F.Border = iTextSharp.text.Rectangle.NO_BORDER
'			F.Alignment = Element.ALIGN_CENTER
'			T.Open
'			Dim LMImage As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Logo.bmp")
'			LMImage.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE
'			T.Add(LMImage)
'			T.Add(h1)
'			T.Add(h2)
'			T.Add(New Paragraph(" ", FontFactory.GetFont(FontFactory.TIMES, 18)))
'			T.Add(p1)
'			T.Add(p2)
'			T.Add(p3)
'			T.Add(p4)
'			T.Add(New Paragraph(" ", FontFactory.GetFont(FontFactory.TIMES, 18)))
'			T.Footer = F
'			Dim datatable As PdfPTable = New PdfPTable(DT.Columns.Count)
'			datatable.DefaultCell.Padding = 2
'			Dim ColWidths(DT.Columns.Count - 1) As Double
'			For I As Integer = 0 To DT.Columns.Count - 1
'				ColWidths(I) = 10
'			Next
'			datatable.setWidths(ColWidths)
'			datatable.WidthPercentage = 100
'			datatable.DefaultCell.BorderWidth = 1
'			datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER
'			For Each C As DataColumn In DT.Columns
'				datatable.AddCell(C.ColumnName)
'			Next
'			datatable.HeaderRows = 1
'			datatable.DefaultCell.GrayFill = 0
'			Dim i2 As Integer = 0
'			While i2 < DT.Rows.Count
'				Dim x As Integer = 0
'				While x < DT.Columns.Count
'					datatable.addCell(DT.Rows(i2)(x))
'					System.Math.Min(System.Threading.Interlocked.Increment(x),x-1)
'				End While
'				System.Math.Min(System.Threading.Interlocked.Increment(i2),i2-1)
'			End While
'			T.Add(datatable)
'			T.Close
		End Sub

	End Class


