'
' Created by SharpDevelop.
' User: rspage
' Date: 6/13/2005
' Time: 12:07 PM
' 

Imports System



	Public Enum Agilent437BMeasurementErrorCode
		Test = 1
	End Enum

	Public Enum Agilent437BEntryErrorCode
		Test = 1
	End Enum

	Public Enum Agilent437BOperatingMode
		Normal = 00
		Zeroing = 06
		Calibration = 08
	End Enum

	Public Enum Agilent437BRange
		ManualRange1 = 01
		ManualRange2 = 02
		ManualRange3 = 03
		ManualRange4 = 04
		ManualRange5 = 05
		AutoRange1 = 11
		AutoRange2 = 12
		AutoRange3 = 13
		AutoRange4 = 14
		AutoRange5 = 15
	End Enum

	Public Enum Agilent437BFilter
		ManualFilter1 = 00
		ManualFilter2 = 01
		ManualFilter4 = 02
		ManualFilter8 = 03
		ManualFilter16 = 04
		ManualFilter32 = 05
		ManualFilter64 = 06
		ManualFilter128 = 07
		ManualFilter256 = 08
		ManualFilter512 = 09
		AutoFilter1 = 10
		AutoFilter2 = 11
		AutoFilter4 = 12
		AutoFilter8 = 13
		AutoFilter16 = 14
		AutoFilter32 = 15
		AutoFilter64 = 16
		AutoFilter128 = 17
		AutoFilter256 = 18
		AutoFilter512 = 19
	End Enum

	Public Enum Agilent437BLinearLogStatus
		Linear = 0
		[Log] = 1
	End Enum

	Public Enum Agilent437BRELModeStatus
		[On] = 1
		[Off] = 0
	End Enum

	Public Enum Agilent437BTriggerMode
		FreeRun = 0
		Standby = 1
	End Enum

	Public Enum Agilent437BGroupTriggerMode
		GT0 = 0
		GT1 = 1
		GT2 = 2
	End Enum

	Public Enum Agilent437BLimitsCheckingStatus
		Enabled = 1
		Disabled = 0
	End Enum

	Public Enum Agilent437BLimitsStatus
		InLimits = 0
		OverLimit = 1
		UnderLowLimit = 2
	End Enum

	Public Enum Agilent437BOffsetStatus
		[On] = 1
		[Off] = 0
	End Enum

	Public Enum Agilent437BDutyCycleStatus
		[On] = 1
		[Off] = 0
	End Enum

	Public Enum Agilent437BMeasurementUnits
		Watts = 0
		dBm = 1
		Percent = 2
		dB = 3
	End Enum


