Module ReceiverManager

    Private Property Receivers As HashSet(Of IReceiver) = New HashSet(Of IReceiver)
    Private Property AddingReceivers As HashSet(Of IReceiver) = New HashSet(Of IReceiver)
    Private Property RemovingReceivers As HashSet(Of IReceiver) = New HashSet(Of IReceiver)

    Private Property Commands As HashSet(Of ICommand) = New HashSet(Of ICommand)
    Private Property AddingCommands As HashSet(Of ICommand) = New HashSet(Of ICommand)
    Private Property RemovingCommands As HashSet(Of ICommand) = New HashSet(Of ICommand)


    ''' <summary>
    ''' 受信解析処理中又は既に登録済みの場合、False
    ''' </summary>
    ''' <param name="receiver"></param>
    ''' <returns></returns>
    Friend Function StartRecv(receiver As IReceiver) As Boolean
        Return AddingReceivers.Add(receiver)
    End Function


    ''' <summary>
    ''' 受信解析処理中又は未登録の場合、False
    ''' </summary>
    ''' <param name="receiver"></param>
    ''' <returns></returns>
    Friend Function StopRecv(receiver As IReceiver) As Boolean
        Return RemovingReceivers.Add(receiver)
    End Function

    Friend Sub ClearReceivers()
        RemovingReceivers = New HashSet(Of IReceiver)(Receivers)
    End Sub

    ''' <summary>
    ''' 受信解析処理中又は既に登録済みの場合、False
    ''' </summary>
    ''' <param name="Command"></param>
    ''' <returns></returns>
    Friend Function StartRecv(Command As ICommand) As Boolean
        Return AddingCommands.Add(Command)
    End Function


    ''' <summary>
    ''' 受信解析処理中又は未登録の場合、False
    ''' </summary>
    ''' <param name="Command"></param>
    ''' <returns></returns>
    Friend Function StopRecv(Command As ICommand) As Boolean
        Return RemovingCommands.Add(Command)
    End Function

    Friend Sub ClearCommands()
        RemovingCommands = New HashSet(Of ICommand)(Commands)
    End Sub


    ''' <summary>
    ''' Receiversを更新し、StartRecv済みのIReceiverにデータフレームを受信解析させる
    ''' </summary>
    ''' <param name="recvMess"></param>
    Friend Sub CallReceiveProccess(ByVal recvMess As Frame)
        If AddingReceivers.Count > 0 Then
            Receivers.UnionWith(AddingReceivers)
            AddingReceivers.Clear()
        End If

        If RemovingReceivers.Count > 0 Then
            Receivers.ExceptWith(RemovingReceivers)
            RemovingReceivers.Clear()
        End If


        Dim options = New ParallelOptions
        options.MaxDegreeOfParallelism = Math.Min(Receivers.Count, 4)
        Parallel.ForEach(Receivers, options,
            Sub(receiver As IReceiver) receiver.ReceiveProccess(recvMess)
        )


        If AddingCommands.Count > 0 Then
            Commands.UnionWith(AddingCommands)
            AddingCommands.Clear()
        End If

        If RemovingCommands.Count > 0 Then
            Commands.ExceptWith(RemovingCommands)
            RemovingCommands.Clear()
        End If

        Parallel.ForEach(Commands, options,
            Sub(command As ICommand)
                If command.IsTimeout() Then
                    StopRecv(command)
                ElseIf command.Parse(recvMess) Then ' ACK/NACKの判断はParseの中で実施するので、command.Stateは操作しない。
                    command.RecvFrame = recvMess.Clone()
                    StopRecv(command)
                End If
            End Sub
        )

    End Sub

End Module
