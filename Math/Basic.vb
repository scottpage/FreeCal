'
' Created by SharpDevelop.
' User: rspage
' Date: 5/4/2005
' Time: 8:54 PM
'
'

Imports System


	Public Module Basic

		Public Function Average(ByVal dataPoints() As Double) As Double
			Dim Total As Double
			For Each Point As Double In DataPoints
				Total += Point
			Next
			Return Total / (DataPoints.GetUpperBound(0) + 1)
		End Function

	End Module

