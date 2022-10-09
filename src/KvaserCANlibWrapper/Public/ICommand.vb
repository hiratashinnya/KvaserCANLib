''' <summary>
''' 送信・応答がペアになっているコマンド処理を実現するインターフェース
''' </summary>
Public Interface ICommand
    Property SendFrame As Frame
    Property RecvFrame As Frame
    Property IsTimeout As Boolean
    Property IsSuccessedSend As Boolean

    Property State As CommandStates
    Enum CommandStates
        NotSend = 0
        SendFail
        Waiting
        RecvACK
        RecvNACK
        Canceled
        Timeout
    End Enum

    Function Parse(recvMess As Frame) As Boolean



End Interface
