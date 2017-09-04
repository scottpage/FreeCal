'
' Created by SharpDevelop.
' User: rspage
' Date: 6/30/2005
' Time: 2:38 PM
' 



Imports System



	Public Module Uncertainty
	
		Public Function StandardDeviation(ByVal dataPoints() As Double) As Double
			Dim DPAverage As Double = Average(DataPoints)
			Dim SqrtOfAverages As Double
			For Each Point As Double In DataPoints
				SqrtOfAverages += (Point - DPAverage)^2
			Next
			Return CDbl(System.Math.Sqrt(SqrtOfAverages / (DataPoints.GetUpperBound(0) - 1)))
		End Function

	End Module

