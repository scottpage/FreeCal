'
' Created by SharpDevelop.
' User: rspage
' Date: 6/30/2005
' Time: 8:50 AM
' 


Imports System
Imports FreeCal.Common

	Public Class ConvertFrequency

		Public Shared Function FromHzToKHz(ByVal originalFrequency As Double) As Double
			Return OriginalFrequency * 1000
		End Function

		Public Shared Function FromHzToMHz(ByVal originalFrequency As Double) As Double
			Return OriginalFrequency * 1000000
		End Function

		Public Shared Function FromHzToGHz(ByVal originalFrequency As Double) As Double
			Return OriginalFrequency * 1000000000
		End Function

		Public Shared Function FromKHzToHz(ByVal originalFrequency As Double) As Double
			Return OriginalFrequency / 1000
		End Function

		Public Shared Function FromKHzToMHz(ByVal originalFrequency As Double) As Double
			Return OriginalFrequency * 1000
		End Function

		Public Shared Function FromKHzToGHz(ByVal originalFrequency As Double) As Double
			Return OriginalFrequency * 1000000
		End Function

		Public Shared Function FromMHzToHz(ByVal originalFrequency As Double) As Double
			Return OriginalFrequency / 1000000
		End Function

		Public Shared Function FromMHzToKHz(ByVal originalFrequency As Double) As Double
			Return OriginalFrequency / 1000
		End Function

		Public Shared Function FromMHzToGHz(ByVal originalFrequency As Double) As Double
			Return OriginalFrequency * 1000
		End Function

		Public Shared Function FromGHzToHz(ByVal originalFrequency As Double) As Double
			Return OriginalFrequency / 1000000000
		End Function

		Public Shared Function FromGHzToKHz(ByVal originalFrequency As Double) As Double
			Return OriginalFrequency / 1000000
		End Function

		Public Shared Function FromGHzToMHz(ByVal originalFrequency As Double) As Double
			Return OriginalFrequency / 1000
		End Function

		Public Shared Function Convert(ByVal frequencySetting As Double, ByVal frequencySettingSuffix As FrequencyEnum, ByVal desiredFrequencySuffix As FrequencyEnum) As Double
			Dim NewFrequencySetting As Double = FrequencySetting
			Select FrequencySettingSuffix
				Case FrequencyEnum.GHz
					Select DesiredFrequencySuffix
						Case FrequencyEnum.MHz
							NewFrequencySetting = NewFrequencySetting * 1000
						Case FrequencyEnum.KHz
							NewFrequencySetting = NewFrequencySetting * 1000000
						Case FrequencyEnum.Hz
							NewFrequencySetting = NewFrequencySetting * 1000000000
					End Select
				Case FrequencyEnum.MHz
					Select DesiredFrequencySuffix
						Case FrequencyEnum.GHz
							NewFrequencySetting = NewFrequencySetting / 1000
						Case FrequencyEnum.KHz
							NewFrequencySetting = NewFrequencySetting / 1000000
						Case FrequencyEnum.Hz
							NewFrequencySetting = NewFrequencySetting * 1000000
					End Select
				Case FrequencyEnum.KHz
					Select DesiredFrequencySuffix
						Case FrequencyEnum.GHz
							NewFrequencySetting = NewFrequencySetting / 1000000
						Case FrequencyEnum.MHz
							NewFrequencySetting = NewFrequencySetting / 1000
						Case FrequencyEnum.Hz
							NewFrequencySetting = NewFrequencySetting * 1000
					End Select
				Case FrequencyEnum.Hz
					Select DesiredFrequencySuffix
						Case FrequencyEnum.GHz
							NewFrequencySetting = NewFrequencySetting / 1000000000
						Case FrequencyEnum.MHz
							NewFrequencySetting = NewFrequencySetting / 1000000
						Case FrequencyEnum.KHz
							NewFrequencySetting = NewFrequencySetting / 1000
					End Select
			End Select
			Return NewFrequencySetting
		End Function

	End Class
