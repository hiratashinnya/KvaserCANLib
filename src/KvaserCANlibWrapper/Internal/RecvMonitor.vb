Imports Kvaser.CanLib
Imports System.Threading
Module RecvMonitor
    Private MonitoringThread As Thread
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

    Private RawBuff As Queue(Of Frame) = New Queue(Of Frame)
    Friend ReadOnly Property IsMonitoring As Boolean
        Get
            Return (Not IsNothing(MonitoringThread)) AndAlso MonitoringThread.IsAlive
        End Get
    End Property

    ''' <summary>
    ''' falseにセットすることで、MonitoringLoopを停止する
    ''' </summary>
    Private MonitoringControlFlag As Boolean
    Friend Function StartMonitoring() As Boolean
        If IsMonitoring Then
            Return True
        End If

        MonitoringThread = New Thread(AddressOf MonitoringLoop)
        MonitoringThread.IsBackground = True
        MonitoringThread.Start()

        Thread.Sleep(500)

        Return IsMonitoring
    End Function

    Friend Function StopMonitoring() As Boolean
        If Not IsMonitoring Then
            Return True
        End If

        MonitoringControlFlag = False
        Thread.Sleep(500)

        Return IsMonitoring
    End Function

    Private Sub MonitoringLoop()
        MonitoringControlFlag = True

        Do While MonitoringControlFlag
            Do While ReadBus()
            Loop

            ExcuteReceiveProcess()
        Loop
    End Sub

    ' Hack: CallReceiveProccessをリエントラントに修正すればExcuteRecieveProccessを非同期化できるかも
    Private Sub ExcuteReceiveProcess()
        Do While RawBuff.Count > 0
            Dim recvMess = RawBuff.Dequeue()
            ReceiverManager.CallReceiveProccess(recvMess)
        Loop
    End Sub

    Private Function ReadBus() As Boolean
        Dim recvMess = New Frame
        Dim stat As Canlib.canStatus

        If Not IsOpened Then
            MsgBox("BusReadError is happened. Port is not Opened.")
            Return False
        End If

        With recvMess
            stat = Canlib.canRead(HandleNo, .CANID, .Data, .DLC, .Flags, .Timestamp_ms)
        End With

        If stat = Canlib.canStatus.canOK Then
            RawBuff.Enqueue(recvMess)
            Return True
        ElseIf stat = Canlib.canStatus.canERR_NOMSG Then
            Return False
        Else
            KvaserControl.ShowKvCANErrText(stat)
            Return False
        End If
    End Function

    Friend Sub ClearBuff()
        RawBuff.Clear()
    End Sub

End Module
