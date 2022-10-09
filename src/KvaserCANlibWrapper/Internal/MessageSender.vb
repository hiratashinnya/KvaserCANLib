Imports Kvaser.CanLib
Module MessageSender
    Private ReadOnly Property HandleNo As Integer
        Get
            Return PortController.HandleNo
        End Get
    End Property

    Private ReadOnly Property IsOpened() As Boolean
        Get
            Return PortController.IsOpened
        End Get
    End Property

    Friend Function SendMessage(ByRef sendMess As Frame, Optional ByVal timeout_ms As Long = 100) As Boolean
        If Not IsOpened OrElse IsNothing(sendMess) Then
            Return False
        ElseIf sendMess.IsInvalidFormat() OrElse timeout_ms < 0 Then
            Return False
        End If

        Dim statWrite As Canlib.canStatus
        Dim statReadTimer As Canlib.canStatus
        With sendMess
            statWrite = Canlib.canWriteWait(HandleNo, .CANID, .Data, .DLC, .Flags, timeout_ms)
            If statWrite = Canlib.canStatus.canOK Then
                statReadTimer = Canlib.kvReadTimer64(HandleNo, .Timestamp_ms)
                If statReadTimer = Canlib.canStatus.canOK Then
                    Return True
                End If
            End If
        End With

        KvaserControl.ShowKvCANErrText(statWrite)
        KvaserControl.ShowKvCANErrText(statReadTimer)
        Return False
    End Function

End Module
