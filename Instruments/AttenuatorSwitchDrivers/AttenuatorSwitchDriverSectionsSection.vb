'
' Created by SharpDevelop.
' User: rspage
' Date: 7/11/2005
' Time: 8:22 AM
' 



Imports System



	Public Class AttenuatorSwitchDriverSectionsSection

		Protected _MainAttenuatorSwitchDriver As AttenuatorSwitchDriver
		Protected _Agilent11760S As AttenuatorSwitchDriverAgilent11760SSection

		Public ReadOnly Property Agilent11760S As AttenuatorSwitchDriverAgilent11760SSection
			Get
				Return Me._Agilent11760S
			End Get
		End Property

		Public Sub New(ByRef mainAttenuatorSwitchDriver As AttenuatorSwitchDriver)
			Me._MainAttenuatorSwitchDriver = mainAttenuatorSwitchDriver
			Me._Agilent11760S = New AttenuatorSwitchDriverAgilent11760SSection(Me._MainAttenuatorSwitchDriver)
		End Sub
	End Class

