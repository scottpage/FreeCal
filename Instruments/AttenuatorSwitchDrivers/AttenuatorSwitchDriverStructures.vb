'
' Created by SharpDevelop.
' User: rspage
' Date: 6/15/2005
' Time: 1:20 PM
' 

'
' Created by SharpDevelop.
' User: rspage
' Date: 6/13/2005
' Time: 10:20 AM
' 

Imports System
Imports FreeCal.Common



    Public Structure AttenuatorSwitchDriverGPIBCommands
    	Public Agilent11760SHighBandAmplifiedHighLevel As String
        Public Agilent11760SHighBandHighLevel As String
        Public Agilent11760SHighBandLowLevel As String
        Public Agilent11760SLowBandLowLevel As String
	    Public X1On As String
	    Public X2On As String
	    Public X3On As String
	    Public X4On As String
	    Public Y5On As String
	    Public Y6On As String
	    Public Y7On As String
	    Public Y8On As String
	    Public S9On As String
	    Public S0On As String
	    Public X1Off As String
	    Public X2Off As String
	    Public X3Off As String
	    Public X4Off As String
	    Public Y5Off As String
	    Public Y6Off As String
	    Public Y7Off As String
	    Public Y8Off As String
	    Public S9Off As String
	    Public S0Off As String
	    Public SwitchOn As String
	    Public SwitchOff As String
    End Structure

	Public Structure AttenuatorSwitchDriverCapabilities
		Public None As Boolean
	End Structure

	Public Structure AttenuatorSwitchDriverTestPoints
		Public None As Double
	End Structure

	Public Structure AttenuatorSwitchDriverSpecifications
		Public None As Double
	End Structure




