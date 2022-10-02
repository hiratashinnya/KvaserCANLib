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

    Private ReadOnly Property HandleNo As Integer
        Get
            Return PortController.HandleNo
        End Get
    End Property
    Private WithEvents KPortCtrlUI As KPortControlUI

    Public ReadOnly Property IsOpened() As Boolean
        Get
            Return HandleNo <> Canlib.canINVALID_HANDLE
        End Get
    End Property

End Class
