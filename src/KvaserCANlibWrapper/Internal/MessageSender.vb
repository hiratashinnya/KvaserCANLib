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

    ''' <summary>
    ''' コマンドを送信し、指定時間応答を待機する。ACK応答受信時Trueを返す。
    ''' </summary>
    ''' <param name="sendCommand"></param>
    ''' <param name="timeout_ms">コマンド送信後、応答を待機する時間(msec)</param>
    ''' <returns></returns>
    Friend Function SendAndWait(ByRef sendCommand As ICommand, Optional ByVal timeout_ms As Long = 100) As Boolean
        If Not IsOpened OrElse IsNothing(sendCommand) OrElse timeout_ms < 0 Then
            Return False
        End If

        sendCommand.State = ICommand.CommandStates.NotSend
        sendCommand.IsSuccessedSend = SendMessage(sendCommand.SendFrame)

        If sendCommand.IsSuccessedSend Then
            sendCommand.State = ICommand.CommandStates.Waiting
            ReceiverManager.StartRecv(sendCommand)
            Dim sw = New Stopwatch
            sw.Start()

            Do While sendCommand.State = ICommand.CommandStates.Waiting
                If sw.ElapsedMilliseconds >= timeout_ms Then
                    sendCommand.State = ICommand.CommandStates.Timeout
                End If

                Application.DoEvents()
            Loop

            sw.Stop()

            Return sendCommand.State = ICommand.CommandStates.RecvACK

        Else ' 送信失敗
            sendCommand.State = ICommand.CommandStates.SendFail
            Return False
        End If
    End Function
End Module
