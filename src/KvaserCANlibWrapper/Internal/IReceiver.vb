Imports System.Collections.Concurrent
''' <summary>
''' KvaserCANlibWrapperライブラリでCANデータを受信するためのInterface
''' </summary>
Friend Interface IReceiver

    Sub ReceiveProccess(recvMess As Frame)

End Interface
