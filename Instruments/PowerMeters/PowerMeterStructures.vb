'
' Created by SharpDevelop.
' User: rspage
' Date: 6/13/2005
' Time: 11:45 AM
' 



    Public Structure PowerMeterGPIBCommands
        Public Measure As String
        Public MeasureChannelA As String
        Public MeasureChannelB As String
        Public ZeroAndCalibrateChannelA As String
        Public ZeroAndCalibrateChannelB As String
        Public SetFrequency As String
        Public ZeroChannelA As String
        Public ZeroChannelB As String
        Public GetChannelAZeroStatus As String
        Public GetChannelBZeroStatus As String
        Public Calibrate As String
    End Structure

	Public Structure PowerMeterCapabilities
		Private Temp As String
	End Structure

	Public Structure PowerMeterTestFrequencies
		Private Temp As String
	End Structure

	Public Structure PowerMeterSpecifications
		Private Temp As String
	End Structure


