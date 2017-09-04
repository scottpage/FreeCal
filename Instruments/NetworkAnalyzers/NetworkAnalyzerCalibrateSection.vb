'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/14/2005
' Time: 4:49 AM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common
Imports System.Windows.Forms
Imports System.ComponentModel


	<TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Class NetworkAnalyzerCalibrationSection

		Protected _MainNetworkAnalyzer As NetworkAnalyzer

        Public Sub New(ByRef MainNetworkAnalyzer As NetworkAnalyzer)
			Me._MainNetworkAnalyzer = MainNetworkAnalyzer
        End Sub

		Public Sub S11OnePort(ByVal size As ConnectorTypeEnum, ByVal gender As GenderEnum, ByVal load As NetworkAnalyzerLoadEnum)
			Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.MENUOFF)
			Select Case Size
				Case ConnectorTypeEnum.N
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.CALKN50)
			End Select
			Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.CALIS111)
			Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.CLASS11A)
			MessageBox.Show("Connect the standard OPEN to 'PORT 1' and click OK.")
			Select Case Gender
				Case GenderEnum.Male
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.STANA)
				Case GenderEnum.Female
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.STANB)
			End Select
			Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.DONE)
			Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.CLASS11B)
			MessageBox.Show("Connect the standard SHORT to 'PORT 1' and click OK.")
			Select Case Gender
				Case GenderEnum.Male
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.STANA)
				Case GenderEnum.Female
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.GetOPC & Me._MainNetworkAnalyzer.Commands.STANB)
			End Select
			Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.DONE)
			Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.CLASS11C)
			MessageBox.Show("Connect the standard SHORT to 'PORT 1' and click OK.")
			Select Case Load
				Case NetworkAnalyzerLoadEnum.BroadBand
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.STANA)
				Case NetworkAnalyzerLoadEnum.Sliding
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.STANB)
				Case NetworkAnalyzerLoadEnum.LowBand
					Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.STANC)
			End Select
			Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.DONE)
			Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.SAV1)
			Me._MainNetworkAnalyzer.Write(Me._MainNetworkAnalyzer.Commands.MENUON)
			MessageBox.Show("Calibration is complete, click OK to proceed.")
		End Sub

    End Class



