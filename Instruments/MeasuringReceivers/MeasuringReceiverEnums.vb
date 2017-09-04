'
' Created by SharpDevelop.
' User: rspage
' Date: 6/14/2005
' Time: 9:13 AM
' 

Public Enum MeasuringReceiverDisplayScaleEnum
    Logarithmic
    Linear
End Enum

Public Enum MeasuringReceiverMeasurementsEnum
    Frequency
    RFPower
    TunedRFLevel
    FM
    AM
    PM
    IFLevel
    AudioFrequency
    AudioDistortion
End Enum

Public Class MeasuringReceiverFrequencyOffsetControlEnum
    Public Const ExitFrequencyOffsetMode As Double = 27.0
    Public Const EnterFrequencyOffsetMode As Double = 27.1
    Public Const DisplayExternalLOFrequency As Double = 27.2
    Public Const PrepareToEnter As Double = 27.3
End Class

Public Enum MeasuringReceiverHighPassFilterEnum
    AllOff = 0
    FiftyHz = 1
    ThreeHundredHz = 2
End Enum

Public Enum MeasuringReceiverLowPassFilterEnum
    AllOff = 0
    ThreekHz = 1
    FifteenkHz = 2
    Above20kHz
End Enum

Public Enum MeasuringReceiverDetectorEnum
    PeakPositive = 1
    PeakNegative = 2
    PeakHold = 3
    RMSCalibratedAverage = 4
    OnekHzDistortion = 5
    FourHundredkHzDistortion = 6
    RMS = 8
    PeakPositiveAndNegativeDividedBy2 = 9
End Enum


