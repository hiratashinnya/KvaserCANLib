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


    Public Function SendMessage(ByRef sendMess As Frame) As Boolean
        If Not IsOpened Then
            MsgBox("SendMessage is Faild. Port is not Opened.")
            Return False
        End If

        Return MessageSender.SendMessage(sendMess)
    End Function

    Public Shared Sub ShowKvCANErrText(ByVal errCode As Canlib.canStatus)
        Dim errText = ""
        Canlib.canGetErrorText(errCode, errText)
        MsgBox(errText)
    End Sub

End Class
