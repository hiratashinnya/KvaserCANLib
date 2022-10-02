Imports Kvaser.CanLib
Imports Kvaser.CanLib.Canlib
Public Class KPortControlUI

    Public Event PortOpened(ByVal sender As Object, ByVal e As EventArgs)
    Public Event PortClosed(ByVal sender As Object, ByVal e As EventArgs)

    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        KvaserControl.SetKPortCtrlUI(Me)
        RegisterPorts()

    End Sub

    Private Sub RegisterPorts()
        PortController.ScanPort()

        If PortController.HasPorts() Then
            ChannelCmbBox.Items.AddRange(PortController.GetPortsInfo())
            OpenBtn.Enabled = True
        Else
            ChannelCmbBox.Items.Add("Port is not found.")
            OpenBtn.Enabled = False
        End If
    End Sub

    Private Function SelectBitrate() As Bitrates
        Return BitRateConfigs.GetBitrate(BitrateCmbBox.SelectedIndex)
    End Function

    Private Sub OpenBtn_Click(sender As Object, e As EventArgs) Handles OpenBtn.Click
        OpenBtn.Enabled = False
        ChannelCmbBox.Enabled = False
        BitrateCmbBox.Enabled = False

        If ChannelCmbBox.SelectedIndex < 0 OrElse BitrateCmbBox.SelectedIndex < 0 Then
            ' 未選択によるエラーハンドリング
            MsgBox("Plese select Bitrate & Channel.")
            OpenBtn.Enabled = True
            ChannelCmbBox.Enabled = True
            BitrateCmbBox.Enabled = True

            Exit Sub
        End If

        If Not PortController.BusOnProcess(ChannelCmbBox.SelectedIndex, SelectBitrate()) Then
            OpenBtn.Enabled = True
            ChannelCmbBox.Enabled = True
            BitrateCmbBox.Enabled = True

            Exit Sub
        End If

        CloseBtn.Enabled = True
        RaiseEvent PortOpened(Me, New EventArgs)　' TODO:KvaserControlによる受信監視の開始処理
    End Sub

    Private Sub CloseBtn_Click(sender As Object, e As EventArgs) Handles CloseBtn.Click
        CloseBtn.Enabled = False

        If Not PortController.BusOff() Then
            CloseBtn.Enabled = True
            Exit Sub
        End If

        RaiseEvent PortClosed(Me, New EventArgs)　' TODO:KvaserControlによる受信監視の停止処理

        OpenBtn.Enabled = True
        ChannelCmbBox.Enabled = True
        BitrateCmbBox.Enabled = True
    End Sub
End Class
