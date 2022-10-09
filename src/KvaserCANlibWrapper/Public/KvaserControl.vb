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


    Public Function SendMessage(ByRef sendMess As Frame, Optional ByVal timeout_ms As Long = 100) As Boolean
        If Not IsOpened Then
            MsgBox("SendMessage is Faild. Port is not Opened.")
            Return False
        End If

        Return MessageSender.SendMessage(sendMess)
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

    Public Shared Sub ShowKvCANErrText(ByVal errCode As Canlib.canStatus)
        If errCode <> Canlib.canStatus.canOK Then
            Dim errText = ""
            Canlib.canGetErrorText(errCode, errText)
            MsgBox(errText)
        End If
    End Sub

End Class
