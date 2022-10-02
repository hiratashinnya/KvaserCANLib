Public Class Frame
    Public CANID As Integer
    Public DLC As Integer

    Friend Flags As Integer
    Public IsError As Boolean
    Public Data As Byte()
    Public Timestamp_ms As Long

    Public Property IsRemote As Boolean
        Get
            Return (Flags And MsgFlags.Remote) <> 0
        End Get
        Set(value As Boolean)
            If value Then
                Flags = (Flags Or MsgFlags.Remote)
            End If
        End Set
    End Property

    Public Property IsExtend As Boolean
        Get
            Return (Flags And MsgFlags.Extend) <> 0
        End Get
        Set(value As Boolean)
            If value Then
                Flags = ((Flags Or MsgFlags.Extend) And (Not MsgFlags.Standard))
            Else
                Flags = ((Flags Or MsgFlags.Standard) And (Not MsgFlags.Extend))
            End If
        End Set
    End Property

    ''' <summary>
    ''' Cannot use both flags Standard And Extend
    ''' </summary>
    <Flags>
    Public Enum MsgFlags
        Remote = 1
        Standard = 2
        Extend = 4
        ''' <summary>
        ''' SWC Hardware
        ''' </summary>
        WakeUp = 8
    End Enum

    Public Sub New()
        CANID = 0
        DLC = 8
        Flags = 0
        Data(7) = New Byte
        Timestamp_ms = 0
    End Sub

    Public Sub New(ByVal iniVal As Byte)
        CANID = 0
        DLC = 8
        Flags = 0
        Data = Enumerable.Repeat(iniVal, 8).ToArray()
        Timestamp_ms = 0
    End Sub

    Public Sub New(ByVal source As Frame)
        CANID = source.CANID
        DLC = source.DLC
        Flags = source.Flags
        Data(source.Data.Length - 1) = New Byte
        source.Data.CopyTo(Data, 0)
        Timestamp_ms = source.Timestamp_ms
    End Sub

    Public Function Clone() As Frame
        Return New Frame(Me)
    End Function

    ''' <summary>
    ''' CANID, DLC, IsRemote, IsExtend, Data0, .. , Data7, Timestamp_ms
    ''' </summary>
    ''' <returns></returns>
    Public Function ToCSV() As String
        Dim csv = New List(Of String)(13) ' Num Columns

        csv.Add(CANID.ToString("X2"))
        csv.Add(DLC.ToString)
        csv.Add(IsRemote.ToString)
        csv.Add(IsExtend.ToString)
        csv.AddRange(Data.Select(Function(x) x.ToString("X2")))
        csv.Add(Timestamp_ms.ToString)

        Return String.Join(",", csv)
    End Function
End Class
