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

    Public Shared Sub ShowKvCANErrText(ByVal errCode As Canlib.canStatus)
        Dim errText = ""
        Canlib.canGetErrorText(errCode, errText)
        MsgBox(errText)
    End Sub

End Class
