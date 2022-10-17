Imports Kvaser.CanLib
Public Class KvaserControl
#Region "Singleton"

    Public Shared ReadOnly Property MyInstance As KvaserControl = New KvaserControl

    Private Sub New()
        Canlib.canInitializeLibrary()
    End Sub
#End Region

    Friend Shared Sub SetKPortCtrlUI(ByRef portCtrlUI As KPortControlUI)
        MyInstance.KPortCtrlUI = portCtrlUI
    End Sub
    Private WithEvents KPortCtrlUI As KPortControlUI

    Private ReadOnly Property HandleNo As Integer
        Get
            Return PortController.HandleNo
        End Get
    End Property

    Public ReadOnly Property IsOpened() As Boolean
        Get
            Return PortController.IsOpened
        End Get
    End Property

    Public Event MessageSend(ByVal sender As Object, ByVal e As EventArgs)

    Public Class MessageSendEventArgs
        Inherits EventArgs

        Public SendMess As Frame
        Public SendTime As Long
        Public Sub New(ByVal sendMess As Frame, ByVal sendTime As Long)
            Me.SendMess = sendMess
            Me.SendTime = sendTime
        End Sub
    End Class

    Public Function SendMessage(ByRef sendMess As Frame, Optional ByVal timeout_ms As Long = 100) As Boolean
        If Not IsOpened Then
            MsgBox("SendMessage is Faild. Port is not Opened.")
            Return False
        End If

        If MessageSender.SendMessage(sendMess) Then
            Dim time = GetBusTimestamp()
            Dim args = New MessageSendEventArgs(sendMess, time)

            RaiseEvent MessageSend(Me, args)
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' コマンドを送信し、指定時間応答を待機する
    ''' </summary>
    ''' <param name="command"></param>
    ''' <param name="timeout_ms">コマンド送信後、応答を待機する時間(msec)</param>
    ''' <returns></returns>
    Public Function SendCommand(ByRef command As ICommand, Optional ByVal timeout_ms As Long = 100) As Boolean
        If Not IsOpened Then
            MsgBox("SendMessage is Faild. Port is not Opened.")
            Return False
        End If

        Return MessageSender.SendAndWait(command, timeout_ms)
    End Function

    Public Function GetBusTimestamp() As Long
        If Not IsOpened Then
            Return -1
        Else
            Dim ret As Long = 0
            Dim stat = Canlib.kvReadTimer64(HandleNo, ret)
            If stat = Canlib.canStatus.canOK Then
                Return ret
            Else
                ShowKvCANErrText(stat)
                Return -1
            End If
        End If
    End Function

    Public Shared Sub ShowKvCANErrText(ByVal errCode As Canlib.canStatus)
        If errCode <> Canlib.canStatus.canOK Then
            Dim errText = ""
            Canlib.canGetErrorText(errCode, errText)
            MsgBox(errText)
        End If
    End Sub

End Class
