Module ReceiverManager
    Private ReceiverLock As Object = New Object
    Private Property Receivers As HashSet(Of IReceiver) = New HashSet(Of IReceiver)


    Private CommandLock As Object = New Object
    Private Property Commands As HashSet(Of ICommand) = New HashSet(Of ICommand)



    ''' <summary>
    ''' 受信解析処理中又は既に登録済みの場合、False
    ''' </summary>
    ''' <param name="receiver"></param>
    ''' <returns></returns>
    Friend Function StartRecv(receiver As IReceiver) As Boolean
        SyncLock ReceiverLock
            Return Receivers.Add(receiver)
        End SyncLock
    End Function


    ''' <summary>
    ''' 受信解析処理中又は未登録の場合、False
    ''' </summary>
    ''' <param name="receiver"></param>
    ''' <returns></returns>
    Friend Function StopRecv(receiver As IReceiver) As Boolean
        SyncLock ReceiverLock
            Return Receivers.Remove(receiver)
        End SyncLock
    End Function

    Friend Sub ClearReceivers()
        SyncLock ReceiverLock
            Receivers.Clear()
        End SyncLock
    End Sub

    ''' <summary>
    ''' 受信解析処理中又は既に登録済みの場合、False
    ''' </summary>
    ''' <param name="Command"></param>
    ''' <returns></returns>
    Friend Function StartRecv(Command As ICommand) As Boolean
        SyncLock CommandLock
            Return Commands.Add(Command)
        End SyncLock
    End Function


    ''' <summary>
    ''' 受信解析処理中又は未登録の場合、False
    ''' </summary>
    ''' <param name="Command"></param>
    ''' <returns></returns>
    Friend Function StopRecv(Command As ICommand) As Boolean
        SyncLock CommandLock
            Return Commands.Remove(Command)
        End SyncLock
    End Function

    Friend Sub ClearCommands()
        SyncLock CommandLock
            Commands.Clear()
        End SyncLock
    End Sub


    ''' <summary>
    ''' Receiversを更新し、StartRecv済みのIReceiverにデータフレームを受信解析させる
    ''' </summary>
    ''' <param name="recvMess"></param>
    Friend Sub CallReceiveProccess(ByVal recvMess As Frame)
        Dim options = New ParallelOptions
        options.MaxDegreeOfParallelism = Math.Min(Receivers.Count, 4)

        SyncLock ReceiverLock
            Parallel.ForEach(Receivers, options,
            Sub(receiver As IReceiver) receiver.ReceiveProccess(recvMess)
        )
        End SyncLock

        SyncLock CommandLock
            Parallel.ForEach(New HashSet(Of ICommand)(Commands), options,
            Sub(command As ICommand)
                If command.IsTimeout() Then
                    StopRecv(command)
                ElseIf command.Parse(recvMess) Then ' ACK/NACKの判断はParseの中で実施するので、command.Stateは操作しない。
                    command.RecvFrame = recvMess.Clone()
                    StopRecv(command)
                End If
            End Sub
        )
        End SyncLock

    End Sub

End Module
