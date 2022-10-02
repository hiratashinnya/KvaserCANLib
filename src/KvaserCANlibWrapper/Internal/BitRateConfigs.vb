Imports Kvaser.CanLib

Module BitRateConfigs

    Friend Structure BitrateConfig
        Public Discription As String
        Public Bitrate As Bitrates

        Friend Sub New(ByVal discription As String, bitrate As Bitrates)
            Me.Discription = discription
            Me.Bitrate = bitrate
        End Sub
    End Structure

    Friend Enum Bitrates
        BITRATE_10K = Canlib.canBITRATE_10K
        BITRATE_50K = Canlib.canBITRATE_50K
        BITRATE_100K = Canlib.canBITRATE_100K
        BITRATE_125K = Canlib.canBITRATE_125K
        BITRATE_250K = Canlib.canBITRATE_250K
        BITRATE_500K = Canlib.canBITRATE_500K
        BITRATE_1M = Canlib.canBITRATE_1M
    End Enum

    Friend Property GetConfigs As BitrateConfig() =
    {
       New BitrateConfig("50Kbit/sec", Bitrates.BITRATE_50K),
       New BitrateConfig("100Kbit/sec", Bitrates.BITRATE_100K),
       New BitrateConfig("125Kbit/sec", Bitrates.BITRATE_125K),
       New BitrateConfig("250Kbit/sec", Bitrates.BITRATE_250K),
       New BitrateConfig("500Kbit/sec", Bitrates.BITRATE_500K),
       New BitrateConfig("1Mbit/sec", Bitrates.BITRATE_1M)
    }

    Friend Function GetConfigStr() As String()
        Return GetConfigs.Select(Function(x) x.Discription).ToArray()
    End Function
    Friend ReadOnly Property GetBitrate(idx As Integer) As Bitrates
        Get
            Return GetConfigs(idx).Bitrate
        End Get
    End Property
End Module
