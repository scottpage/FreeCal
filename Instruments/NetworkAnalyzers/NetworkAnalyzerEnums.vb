'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/13/2005
' Time: 6:42 PM
' 



        Public Enum NetworkAnalyzerListFormatEnum
            FORM1
            FORM2
            FORM3
            FORM4
            FORM5
        End Enum

        Public Enum NetworkAnalyzerParameterEnum
            S11
            S12
            S21
            S22
        End Enum

        Public Enum NetworkAnalyzerNumberOfPointsEnum
            Points51 = 51
            Points101 = 101
            Points201 = 201
            Points401 = 401
            Points801 = 801
        End Enum

        Public Enum NetworkAnalyzerMagnitudeDisplayEnum
            LOGM
            LINM
        End Enum

		Public Enum NetworkAnalyzerConnectorSizeEnum
			N50 = 50
			N75 = 75
		End Enum

		Public Enum NetworkAnalyzerLoadEnum
			BroadBand
			Sliding
			Lowband
		End Enum

		Public Enum NetworkAnalyzerFormatEnum
			LogMag
			LinMag
			SmithChart
			InvertedSmithChart
			Delay
			Phase
			SWR
			Imaginary
			Real
		End Enum

		Public Enum NetworkAnalyzerMarkerEnum
			AllOff = 0
			Marker1 = 1
			Marker2 = 2
			Marker3 = 3
			Marker4 = 4
			Marker5 = 5
		End Enum

		Public Enum NetworkAnalyzerDataFormatEnum
			Form1
			Form2
			Form3
			Form4
			Form5
		End Enum

		Public Enum NetworkAnalyzerOutputDataTypeEnum
			Marker
			Data
			Formated
			FrequencyList
			ActiveParameter
		End Enum


