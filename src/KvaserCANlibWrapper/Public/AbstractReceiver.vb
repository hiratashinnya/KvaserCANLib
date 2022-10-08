Imports System.Collections.Concurrent

Public MustInherit Class AbstractReceiver(Of T As Structure)
    Implements IReceiver

    ''' <summary>
    ''' Parseメソッドを呼ぶ。
    ''' 対象データの場合、OwnDataReceivedイベントを発生させる
    ''' </summary>
    ''' <param name="recvMess"></param>
    Protected Friend Overridable Sub ReceiveProccess(recvMess As Frame) Implements IReceiver.ReceiveProccess
        If Parse(recvMess) Then
            RaiseEvent OwnDataReceived(Me, New EventArgs)
        End If
    End Sub

    ''' <summary>
    ''' 受信解析処理. buffの更新、受信データ識別子のエンキューはこのメソッド内で行うこと。
    ''' recvMessが受信対象データの場合、Trueを返す。
    ''' </summary>
    ''' <param name="recvMess"></param>
    Protected MustOverride Function Parse(recvMess As Frame) As Boolean

    Public Function StartRecv() As Boolean
        If ReceiverManager.StartRecv(Me) Then
            IsReceiving = True
        End If
        Return IsReceiving
    End Function

    Public Function StopRecv() As Boolean
        If ReceiverManager.StopRecv(Me) Then
            IsReceiving = False
        End If
        Return IsReceiving
    End Function

    ''' <summary>
    ''' ReceiveProcess有効化中
    ''' </summary>
    ''' <returns></returns>
    Public Property IsReceiving As Boolean

    Private Buff As Dictionary(Of T, String) = New Dictionary(Of T, String)
    ''' <summary>
    ''' Parse後のデータを格納するバッファ
    ''' </summary>
    ''' <param name="key"></param>
    ''' <returns></returns>
    Public Property RecvData(ByVal key As T) As String
        Get
            If Buff.ContainsKey(key) Then
                Return Buff(key)
            Else
                Return Nothing
            End If
        End Get
        Protected Set(ByVal value As String)
            Buff(key) = value
        End Set
    End Property

    Public Sub ClearBuff()
        Buff.Clear()
    End Sub

    Private RecvDataID_q As ConcurrentQueue(Of T) = New ConcurrentQueue(Of T)

    ''' <summary>
    ''' 受信データ識別子のエンキュー・デキュー操作。
    ''' デキュー失敗時はNothingを返す。
    ''' </summary>
    ''' <returns></returns>
    Public Property RecvDataID As Nullable(Of T)
        Get
            Dim ret As Nullable(Of T) = New Nullable(Of T)
            If Not RecvDataID_q.TryDequeue(ret.Value) Then
                ret = Nothing
            End If
            Return ret
        End Get
        Protected Set(value As Nullable(Of T))
            RecvDataID_q.Enqueue(value.Value)
        End Set
    End Property

    ''' <summary>
    ''' Parseした結果、対象データだった場合、発生する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Event OwnDataReceived(ByVal sender As Object, ByVal e As EventArgs)

End Class
