'
' Created by SharpDevelop.
' User: rspage
' Date: 6/28/2005
' Time: 11:12 AM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.Windows.Forms
Imports System.Collections
Imports System.Data
Imports Microsoft.VisualBasic
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class NetworkAnalyzerOutputSection

		Protected _MainNetworkAnalyzer As NetworkAnalyzer
		Protected _DataFormat As NetworkAnalyzerDataFormatEnum = NetworkAnalyzerDataFormatEnum.Form4
		Protected _DataType As NetworkAnalyzerOutputDataTypeEnum = NetworkAnalyzerOutputDataTypeEnum.Data

		Public Property DataFormat As NetworkAnalyzerDataFormatEnum
			Get
				Return Me._DataFormat
			End Get
			Set
				Me._DataFormat = Value
			End Set
		End Property

		Public Property DataType As NetworkAnalyzerOutputDataTypeEnum
			Get
				Return Me._DataType
			End Get
			Set
				Me._DataType = Value
			End Set
		End Property

		Public Function Marker As Double
			Select Me._MainNetworkAnalyzer.Sections.[Format].Current
				Case NetworkAnalyzerFormatEnum.LogMag
					Select Me._DataFormat
						Case NetworkAnalyzerDataFormatEnum.Form1
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.LogMagFormat & Me._MainNetworkAnalyzer.Commands.FORM1 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
						Case NetworkAnalyzerDataFormatEnum.Form2
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.LogMagFormat & Me._MainNetworkAnalyzer.Commands.FORM2 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
						Case NetworkAnalyzerDataFormatEnum.Form3
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.LogMagFormat & Me._MainNetworkAnalyzer.Commands.FORM3 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
						Case NetworkAnalyzerDataFormatEnum.Form4
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.LogMagFormat & Me._MainNetworkAnalyzer.Commands.FORM4 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
						Case NetworkAnalyzerDataFormatEnum.Form5
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.LogMagFormat & Me._MainNetworkAnalyzer.Commands.FORM5 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
					End Select
				Case NetworkAnalyzerFormatEnum.SWR
					Select Me._DataFormat
						Case NetworkAnalyzerDataFormatEnum.Form1
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SWRFormat & Me._MainNetworkAnalyzer.Commands.FORM1 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
						Case NetworkAnalyzerDataFormatEnum.Form2
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SWRFormat & Me._MainNetworkAnalyzer.Commands.FORM2 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
						Case NetworkAnalyzerDataFormatEnum.Form3
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SWRFormat & Me._MainNetworkAnalyzer.Commands.FORM3 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
						Case NetworkAnalyzerDataFormatEnum.Form4
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SWRFormat & Me._MainNetworkAnalyzer.Commands.FORM4 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
						Case NetworkAnalyzerDataFormatEnum.Form5
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SWRFormat & Me._MainNetworkAnalyzer.Commands.FORM5 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
					End Select
				Case NetworkAnalyzerFormatEnum.SmithChart
					Select Me._DataFormat
						Case NetworkAnalyzerDataFormatEnum.Form1
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SmithChartFormat & Me._MainNetworkAnalyzer.Commands.FORM1 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
						Case NetworkAnalyzerDataFormatEnum.Form2
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SmithChartFormat & Me._MainNetworkAnalyzer.Commands.FORM2 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
						Case NetworkAnalyzerDataFormatEnum.Form3
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SmithChartFormat & Me._MainNetworkAnalyzer.Commands.FORM3 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
						Case NetworkAnalyzerDataFormatEnum.Form4
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SmithChartFormat & Me._MainNetworkAnalyzer.Commands.FORM4 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
						Case NetworkAnalyzerDataFormatEnum.Form5
							Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SmithChartFormat & Me._MainNetworkAnalyzer.Commands.FORM5 & Me._MainNetworkAnalyzer.Commands.OUTPMARK)
					End Select
			End Select
			Dim Reading As String = Me._MainNetworkAnalyzer.ReadString.Replace(NewLine, "").Trim
        Dim Readings() As String = Reading.Split(","c)
        Return CDbl(Readings(0))
		End Function

		Public Function GetFullData As DataTable
			Dim DT As New DataTable(Me._MainNetworkAnalyzer.Model & " - " & Me._MainNetworkAnalyzer.Sections.Parameter.Current.ToString)
			DT.Columns.Add(New DataColumn("Point"))
			DT.Columns.Add(New DataColumn("Frequency"))
			DT.Columns.Add(New DataColumn("Lin Mag"))
			DT.Columns.Add(New DataColumn("Log Mag"))
			DT.Columns.Add(New DataColumn("Phase"))
			DT.Columns.Add(New DataColumn("SWR"))
			'DT.Columns.Add(New DataColumn("Smith"))
			Dim CurrentFrequency As Double = Me._MainNetworkAnalyzer.Sections.Stimulus.Start
			Dim FrequencyListAdder As Double = ((Me._MainNetworkAnalyzer.Sections.Stimulus.Stop - Me._MainNetworkAnalyzer.Sections.Stimulus.Start) / (Me._MainNetworkAnalyzer.Sections.Stimulus.NumberOfPoints - 1))
			For I As Integer = 1 To Me._MainNetworkAnalyzer.Sections.Stimulus.NumberOfPoints
				Dim DR As DataRow = DT.NewRow
				DR("Point") = I
				DR("Frequency") = Format(Me._MainNetworkAnalyzer.ConvertFrequency(CurrentFrequency, Me._MainNetworkAnalyzer.Sections.Stimulus.Suffix, FrequencyEnum.GHz), "#0.000")
				DT.Rows.Add(DR)
				CurrentFrequency += FrequencyListAdder
			Next
			Dim Points() As Double = Me.GetS11LinMagList
			For I As Integer = 0 To DT.Rows.Count - 1
				DT.Rows(I)("Lin Mag") = Points(I)
			Next
			Points = Me.GetS11LogMagList
			For I As Integer = 0 To DT.Rows.Count - 1
				DT.Rows(I)("Log Mag") = Points(I)
			Next
			Points = Me.GetS11PhaseList
			For I As Integer = 0 To DT.Rows.Count - 1
				DT.Rows(I)("Phase") = Points(I)
			Next
			Points = Me.GetS11SWRList
			For I As Integer = 0 To DT.Rows.Count - 1
				DT.Rows(I)("SWR") = Points(I)
			Next
'			Points = Me.GetS11SmithChartList
'			For I As Integer = 0 To DT.Rows.Count - 1
'				DT.Rows(I)("Smith") = Points(I)
'			Next
			Return DT
		End Function

		Public Function GetDataList As Double()
        Dim NumberOfPoints As Integer = Me._MainNetworkAnalyzer.Sections.Stimulus.NumberOfPoints
        Select Case Me._MainNetworkAnalyzer.Sections.Parameter.Current
				Case NetworkAnalyzerParameterEnum.S11
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.S11)
				Case NetworkAnalyzerParameterEnum.S12
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.S12)
				Case NetworkAnalyzerParameterEnum.S21
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.S21)
				Case NetworkAnalyzerParameterEnum.S22
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.S22)
			End Select
			Select Me._MainNetworkAnalyzer.Sections.[Format].Current
				Case NetworkAnalyzerFormatEnum.LinMag
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.LinMagFormat)
				Case NetworkAnalyzerFormatEnum.LogMag
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.LogMagFormat)
				Case NetworkAnalyzerFormatEnum.SWR
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SWRFormat)
				Case NetworkAnalyzerFormatEnum.Phase
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.PhaseFormat)
			End Select
			Select Me._DataFormat
				Case NetworkAnalyzerDataFormatEnum.Form1
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.Form1)
				Case NetworkAnalyzerDataFormatEnum.Form2
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.Form2)
				Case NetworkAnalyzerDataFormatEnum.Form3
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.Form3)
				Case NetworkAnalyzerDataFormatEnum.Form4
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.Form4)
				Case NetworkAnalyzerDataFormatEnum.Form5
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.Form5)
			End Select
			Select Me._DataType
				Case NetworkAnalyzerOutputDataTypeEnum.Data
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.OUTPDATA)
				Case NetworkAnalyzerOutputDataTypeEnum.Marker
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.OUTPMARK)
				Case NetworkAnalyzerOutputDataTypeEnum.Formated
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.OUTPFORM)
				Case NetworkAnalyzerOutputDataTypeEnum.FrequencyList
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.OUTPFREL)
				Case NetworkAnalyzerOutputDataTypeEnum.ActiveParameter
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.OUTPACTI)
			End Select
            Dim ReadData As String = Me._MainNetworkAnalyzer.ReadString(NumberOfPoints * 50)
            Dim DataPairs() As String = ReadData.Split(LF)
            Dim DataList As New ArrayList
            For Each DataPair As String In DataPairs
            Dim SplitDataPair() As String = DataPair.Split(","c)
            DataList.Add(SplitDataPair(0).Trim)
            Next
            Dim Data(DataList.Count - 1) As Double
            For I As Integer = 0 To DataList.Count - 1
				Try
            		Data(I) = CDbl(DataList(I))
            	Catch
            	End Try
            Next
            Return Data
		End Function

		Public Function GetFrequencyListIncrement As Double
			Return ((Me._MainNetworkAnalyzer.Sections.Stimulus.Stop - Me._MainNetworkAnalyzer.Sections.Stimulus.Start) / (Me._MainNetworkAnalyzer.Sections.Stimulus.NumberOfPoints - 1))
		End Function

		Public Function GetS11PhaseList As Double()
			Me._MainNetworkAnalyzer.Sections.Parameter.Current = NetworkAnalyzerParameterEnum.S11
			Me._MainNetworkAnalyzer.Sections.[Format].Current = NetworkAnalyzerFormatEnum.Phase
			Me._DataFormat = NetworkAnalyzerDataFormatEnum.Form4
			Me._DataType = NetworkAnalyzerOutputDataTypeEnum.Formated
			Return Me.GetDataList
		End Function

		Public Function GetS11LinMagList As Double()
			Me._MainNetworkAnalyzer.Sections.Parameter.Current = NetworkAnalyzerParameterEnum.S11
			Me._MainNetworkAnalyzer.Sections.[Format].Current = NetworkAnalyzerFormatEnum.LinMag
			Me._DataFormat = NetworkAnalyzerDataFormatEnum.Form4
			Me._DataType = NetworkAnalyzerOutputDataTypeEnum.Formated
			Return Me.GetDataList
		End Function

		Public Function GetS11SmithChartList As Double()
			Me._MainNetworkAnalyzer.Sections.Parameter.Current = NetworkAnalyzerParameterEnum.S11
			Me._MainNetworkAnalyzer.Sections.[Format].Current = NetworkAnalyzerFormatEnum.SmithChart
			Dim CurrentFrequency As Double = Me._MainNetworkAnalyzer.Sections.Stimulus.Start
			Me._MainNetworkAnalyzer.Sections.Markers.Suffix = FrequencyEnum.Hz
			Dim FLA As Double = Me.GetFrequencyListIncrement
			Dim DataList As New ArrayList
			Me._MainNetworkAnalyzer.Sections.Markers.Current = NetworkAnalyzerMarkerEnum.Marker1
			For I As Integer = 0 To Me._MainNetworkAnalyzer.Sections.Stimulus.NumberOfPoints - 1
				Me._MainNetworkAnalyzer.Sections.Markers.Frequency = CurrentFrequency
				DataList.Add(Me.Marker)
				CurrentFrequency += FLA
			Next
			Me._DataFormat = NetworkAnalyzerDataFormatEnum.Form4
			Me._DataType = NetworkAnalyzerOutputDataTypeEnum.Marker
            Dim Data(DataList.Count - 1) As Double
            For I As Integer = 0 To DataList.Count - 1
				Try
            		Data(I) = CDbl(DataList(I))
            	Catch
            	End Try
            Next
            Return Data
		End Function

		Public Function GetS11LogMagList As Double()
			Me._MainNetworkAnalyzer.Sections.Parameter.Current = NetworkAnalyzerParameterEnum.S11
			Me._MainNetworkAnalyzer.Sections.[Format].Current = NetworkAnalyzerFormatEnum.LogMag
			Me._DataFormat = NetworkAnalyzerDataFormatEnum.Form4
			Me._DataType = NetworkAnalyzerOutputDataTypeEnum.Formated
			Return Me.GetDataList
		End Function

		Public Function GetS11SWRList As Double()
			Me._MainNetworkAnalyzer.Sections.Parameter.Current = NetworkAnalyzerParameterEnum.S11
			Me._MainNetworkAnalyzer.Sections.[Format].Current = NetworkAnalyzerFormatEnum.SWR
			Me._DataFormat = NetworkAnalyzerDataFormatEnum.Form4
			Me._DataType = NetworkAnalyzerOutputDataTypeEnum.Formated
			Return Me.GetDataList
		End Function

		Public Sub New(ByRef MainNetworkAnalyzer As NetworkAnalyzer)
			Me._MainNetworkAnalyzer = MainNetworkAnalyzer
		End Sub

	End Class

