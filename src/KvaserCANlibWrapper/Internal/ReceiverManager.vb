Module ReceiverManager

    Private Property Receivers As HashSet(Of IReceiver) = New HashSet(Of IReceiver)
    Private Property AddingReceivers As HashSet(Of IReceiver) = New HashSet(Of IReceiver)
    Private Property RemovingReceivers As HashSet(Of IReceiver) = New HashSet(Of IReceiver)
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

        For Each receiver As IReceiver In Receivers
            receiver.ReceiveProccess(recvMess)
        Next
    End Sub

End Module
