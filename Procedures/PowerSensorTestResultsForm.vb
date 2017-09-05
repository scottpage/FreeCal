'
' Created by SharpDevelop.
' User: rspage
' Date: 6/29/2005
' Time: 12:27 PM
' 



Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data
Imports FreeCal.Data
Imports FreeCal.Common
Imports MySql.Data.MySqlClient
Imports ZedGraph



Public Class PowerSensorTestResultsForm
    Inherits FreeCal.Procedures.TestResultsForm

    Protected _dtResults As PowerSensorTestResultsTable
    Protected _FrequencySuffix As FrequencyEnum = FrequencyEnum.GHz
    Protected _CalibrationFactorScale As CalibrationFactorScaleEnum = CalibrationFactorScaleEnum.Percent

    Public Sub New()
        MyBase.New
        '
        ' The Me.InitializeComponent call is required for Windows Forms designer support.
        '
        Me.InitializeComponent()
        Me.chtResults.GraphPane.XAxis.Title.Text = "Frequency (GHZ)"
        Me.chtResults.GraphPane.XAxis.Title.Text = "Calibration Factor (%)"
    End Sub

#Region " Windows Forms Designer generated code "
    ' This method is required for Windows Forms designer support.
    ' Do not change the method contents inside the source code editor. The Forms designer might
    ' not be able to load this method if it was changed manually.
    Private Sub InitializeComponent()
        '
        'PowerSensorTestResultsForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "PowerSensorTestResultsForm"
        Me.Text = "PowerSensorTestResultsForm"
    End Sub
#End Region

    Public Property CalibrationFactorScale As CalibrationFactorScaleEnum
        Get
            Return Me._CalibrationFactorScale
        End Get
        Set
            Me._CalibrationFactorScale = Value
            If Value = CalibrationFactorScaleEnum.Percent Then
                Me.chtResults.GraphPane.XAxis.Title.Text = "Calibration Factor (%)"
            Else
                Me.chtResults.GraphPane.XAxis.Title.Text = "Calibration Factor (dBm)"
            End If
        End Set
    End Property

    Public Property FrequencySuffix As FrequencyEnum
        Get
            Return Me._FrequencySuffix
        End Get
        Set
            Me._FrequencySuffix = Value
            Me.chtResults.GraphPane.XAxis.Title.Text = "Frequency (" & Value.ToString & ")"
        End Set
    End Property

    Public Overridable Sub AddResult(ByVal testFrequency As Double, ByVal measurement As Double)
        Me.lblCurrentParameters.Text = "Currently Testing:  " & testFrequency & Me._FrequencySuffix.ToString
        Me.lblCurrentParameters.Left = CInt(CInt(Me.Width / 2) - CInt(Me.lblCurrentParameters.Width / 2))
        Me.chtResults.GraphPane.CurveList(Me.DUTAssetNumber).AddPoint(New PointPair(testFrequency, measurement))
        Me.chtResults.AxisChange()
        Dim NewDR As DataRow = Me._dtResults.NewRow
        Me._dtResults.Rows.Add(NewDR)
        Me.Refresh()
    End Sub

    Public Sub NewResults(ByVal newDUTAssetNumber As String)
        Me.dgResults.DataMember = ""
        Me.dgResults.DataSource = Nothing
        Me.chtResults.GraphPane.CurveList.Clear()
        Me._LowerTolerancePPL = New PointPairList
        Me._MeasurementsPPL = New PointPairList
        Me._UpperTolerancePPL = New PointPairList
        Me._DUTAssetNumber = newDUTAssetNumber
        Me.chtResults.GraphPane.AddCurve(newDUTAssetNumber, New PointPairList, Color.Green, SymbolType.Diamond)
        Me.chtResults.GraphPane.AddCurve("Upper Tolerance", New PointPairList, Color.Red, SymbolType.Triangle)
        Me.chtResults.GraphPane.AddCurve("Lower Tolerance", New PointPairList, Color.Red, SymbolType.TriangleDown)
        Me.chtResults.AxisChange()
        Me._dtResults = New PowerSensorTestResultsTable(newDUTAssetNumber)
        Me.dgResults.DataMember = newDUTAssetNumber
        Me.dgResults.DataSource = Me._dtResults
        Me.Refresh()
    End Sub


End Class

