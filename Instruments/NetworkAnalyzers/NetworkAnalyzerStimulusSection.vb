'
' Created by SharpDevelop.
' User: rspage
' Date: 6/29/2005
' Time: 7:36 AM
' 



Imports System
Imports FreeCal.Common
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
	Public Class NetworkAnalyzerStimulusSection

		Protected _MainNetworkAnalyzer As NetworkAnalyzer
		Protected _FrequencyList() As Double
		Protected _Start As Double
		Protected _Stop As Double
		Protected _Center As Double
		Protected _Span As Double
		Protected _Suffix As FrequencyEnum = FrequencyEnum.Hz
		Protected _NumberOfPoints As Integer

		Public Property Suffix As FrequencyEnum
			Get
				Return Me._Suffix
			End Get
			Set
				Me._Suffix = Value
			End Set
		End Property

		Public Property Start As Double
			Get
				Me._MainNetworkAnalyzer.Write("STAR;OUTPACTI;")
				Me._Start = Me._MainNetworkAnalyzer.ReadDouble
				Return Me._Start
			End Get
			Set
				Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.StartFrequency & Value & Me._MainNetworkAnalyzer.GetFrequencyTerminator(Me._Suffix))
			End Set
		End Property

		Public Property [Stop] As Double
			Get
				Me._MainNetworkAnalyzer.Write("STOP;OUTPACTI;")
				Me._Stop = Me._MainNetworkAnalyzer.ReadDouble
				Return Me._Stop
			End Get
			Set
				Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.StopFrequency & Value & Me._MainNetworkAnalyzer.GetFrequencyTerminator(Me._Suffix))
			End Set
		End Property

		Public Property Center As Double
			Get
				Me._MainNetworkAnalyzer.Write("CENT;OUTPACTI;")
				Me._Center = Me._MainNetworkAnalyzer.ReadDouble
				Return Me._Center
			End Get
			Set
				Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.CenterFrequency & Value & Me._MainNetworkAnalyzer.GetFrequencyTerminator(Me._Suffix))
			End Set
		End Property

		Public Property FrequencyList As Double()
			Get
				Return Me._FrequencyList
			End Get
			Set
				Me._FrequencyList = Value
				Me._MainNetworkAnalyzer.Write("EDITLIST;LISTTYPELSTP;")
				Me._MainNetworkAnalyzer.Write("CLEL;")
				Me._MainNetworkAnalyzer.Write("EDITLIST")
				For CustomFrequency As Integer = 1 To Value.GetUpperBound(0) - 1
					Me._MainNetworkAnalyzer.Write("SADD;")
					Me._MainNetworkAnalyzer.Write("STAR " & Value(CustomFrequency - 1) & " GHZ;")
					Me._MainNetworkAnalyzer.Write("STOP " & Value(CustomFrequency) & " GHZ;")
					Me._MainNetworkAnalyzer.Write("POIN11;")
					Me._MainNetworkAnalyzer.Write("SDON;")
				Next CustomFrequency
				Me._MainNetworkAnalyzer.Write("EDITDONE;")
				Me._MainNetworkAnalyzer.Write("LISTFREQ;")
			End Set
		End Property

		Public Property NumberOfPoints As Integer
			Get
				Me._MainNetworkAnalyzer.Write("POIN;" & Me._MainNetworkAnalyzer.Commands.OUTPACTI)
            Me._NumberOfPoints = Convert.ToInt32(Me._MainNetworkAnalyzer.ReadDouble)
            Return Me._NumberOfPoints
			End Get
			Set
				Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SetNumberOfPoints & Value & Me._MainNetworkAnalyzer.CommandTerminators.MultipleCommandSeperator & Me._MainNetworkAnalyzer.Commands.GetNumberOfPoints)
				Me._NumberOfPoints = Me._MainNetworkAnalyzer.ReadInt16
			End Set
		End Property

		Public Sub New(ByRef MainNetworkAnalyzer As NetworkAnalyzer)
			Me._MainNetworkAnalyzer = MainNetworkAnalyzer
		End Sub

	End Class

