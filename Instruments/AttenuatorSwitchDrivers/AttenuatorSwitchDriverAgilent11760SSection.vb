'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/15/2005
' Time: 5:48 PM
' 

'
' Created by SharpDevelop.
' User: Administrator
' Date: 6/11/2005
' Time: 6:20 AM
' 

Imports System
Imports Microsoft.VisualBasic.ControlChars
Imports NationalInstruments.NI4882
Imports FreeCal.Instruments
Imports FreeCal.Common



    Public Class AttenuatorSwitchDriverAgilent11760SSection

		Protected _MainAttenuatorSwitchDriver As AttenuatorSwitchDriver
		Protected _CurrentConfiguration As AttenuatorSwitchDriverConfigurationEnum

		Public ReadOnly Property MainAttenuatorSwitchDriver As AttenuatorSwitchDriver
			Get
				Return Me._MainAttenuatorSwitchDriver
			End Get
		End Property

		Public Property CurrentConfiguration As AttenuatorSwitchDriverConfigurationEnum
			Get
				Return Me._CurrentConfiguration
			End Get
			Set
				Me._CurrentConfiguration = Value
				Select Value
					Case AttenuatorSwitchDriverConfigurationEnum.HighBandAmplifiedHighLevel
						Me._MainAttenuatorSwitchDriver.Write(Me._MainAttenuatorSwitchDriver.Commands.Agilent11760SHighBandAmplifiedHighLevel)
					Case AttenuatorSwitchDriverConfigurationEnum.HighBandHighLevel
						Me._MainAttenuatorSwitchDriver.Write(Me._MainAttenuatorSwitchDriver.Commands.Agilent11760SHighBandHighLevel)
					Case AttenuatorSwitchDriverConfigurationEnum.HighBandLowLevel
						Me._MainAttenuatorSwitchDriver.Write(Me._MainAttenuatorSwitchDriver.Commands.Agilent11760SHighBandLowLevel)
					Case AttenuatorSwitchDriverConfigurationEnum.LowBandLowLevel
						Me._MainAttenuatorSwitchDriver.Write(Me._MainAttenuatorSwitchDriver.Commands.Agilent11760SLowBandLowLevel)
				End Select
			End Set
		End Property

        Public Sub New(ByRef MainAttenuatorSwitchDriver As AttenuatorSwitchDriver)
            Me._MainAttenuatorSwitchDriver = MainAttenuatorSwitchDriver
        End Sub

		Public Sub LowBandLowLevel
			Me.CurrentConfiguration = AttenuatorSwitchDriverConfigurationEnum.LowBandLowLevel
			Me._MainAttenuatorSwitchDriver.Write(Me._MainAttenuatorSwitchDriver.Commands.Agilent11760SLowBandLowLevel)
		End Sub

		Public Sub HighBandHighLevel
			Me.CurrentConfiguration = AttenuatorSwitchDriverConfigurationEnum.HighBandHighLevel
			Me._MainAttenuatorSwitchDriver.Write(Me._MainAttenuatorSwitchDriver.Commands.Agilent11760SHighBandHighLevel)
		End Sub

    End Class




