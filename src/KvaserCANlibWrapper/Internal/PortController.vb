Imports Kvaser.CanLib
Module PortController
    Private Ports As Dictionary(Of Integer, PortParameter)
    Friend HandleNo As Integer = Canlib.canINVALID_HANDLE

    Sub New()
        Ports = New Dictionary(Of Integer, PortParameter)
    End Sub

    Friend Function HasPorts() As Boolean
        Return Ports.Count > 0
    End Function

    Friend ReadOnly Property IsOpened() As Boolean
        Get
            Return HandleNo <> Canlib.canINVALID_HANDLE
        End Get
    End Property
    Friend Sub ScanPort()
        Dim num As Integer
        If Canlib.canGetNumberOfChannels(num) <> Canlib.canStatus.canOK Then
            Exit Sub
        End If

        Dim buff = New Object
        For i As Integer = 0 To num - 1
            Dim port = New PortParameter
            port.No = i

            Canlib.canGetChannelData(i, Canlib.canCHANNELDATA_CHANNEL_NAME, buff)
            port.Name = buff.ToString

            Canlib.canGetChannelData(i, Canlib.canCHANNELDATA_CARD_SERIAL_NO, buff)
            port.SerialNo = CInt(buff)

            Canlib.canGetChannelData(i, Canlib.canCHANNELDATA_CARD_TYPE, buff)
            port.IsVirtual = (CInt(buff) = Canlib.canHWTYPE_VIRTUAL)

            Ports(port.No) = port
        Next
    End Sub

    Friend Function GetPortsInfo() As String()
        Return Ports.Values.Select(Function(x) x.ToString()).ToArray()
    End Function

    Friend Function GetPhysicalPorts() As List(Of PortParameter)
        Return Ports.Values.Where(Function(x As PortParameter) Not x.IsVirtual).ToList
    End Function

    Friend Function GetVirtualPorts() As List(Of PortParameter)
        Return Ports.Values.Where(Function(x As PortParameter) x.IsVirtual).ToList
    End Function

    Friend Function BusOnProcess(ByVal channel As Integer, ByVal bitrate As Bitrates) As Boolean
        If Not Ports.ContainsKey(channel) Then
            MsgBox($"port {channel} is not found.", Title:="Port BusOnProcess Error!")
            Return False
        End If

        Dim handle = Canlib.canOpenChannel(channel, Canlib.canOPEN_ACCEPT_VIRTUAL)
        If handle < 0 Then
            Dim errCode = CType(handle, Canlib.canStatus)
            KvaserControl.ShowKvCANErrText(errCode)
            Return False
        End If

        If Not SetBusParam(handle, bitrate) Then
            Return False
        End If

        If BusOn(handle) Then
            Return RecvMonitor.StartMonitoring()
        Else
            Return False
        End If
    End Function

    Private Function SetBusParam(ByVal handle As Integer, ByVal busbitrate As Integer) As Boolean
        Dim stat = Canlib.canSetBusParams(handle, busbitrate, 0, 0, 0, 1)
        If stat = Canlib.canStatus.canOK Then
            Return True
        Else
            KvaserControl.ShowKvCANErrText(stat)
            Return False
        End If
    End Function

    Private Function BusOn(handle As Integer) As Boolean
        Dim stat = Canlib.canBusOn(handle)
        If stat = Canlib.canStatus.canOK Then
            HandleNo = handle
            Return True
        Else
            KvaserControl.ShowKvCANErrText(stat)
            Return False
        End If
    End Function

    Friend Function BusOff() As Boolean
        RecvMonitor.StopMonitoring()

        Dim stat = Canlib.canBusOff(HandleNo)
        If stat = Canlib.canStatus.canOK Then
            HandleNo = Canlib.canINVALID_HANDLE
            Return True
        Else
            KvaserControl.ShowKvCANErrText(stat)
            Return False
        End If
    End Function

    Friend Structure PortParameter
        Public No As Integer
        Public Name As String
        Public SerialNo As Integer
        Public IsVirtual As Boolean

        Public Overrides Function ToString() As String
            If IsVirtual Then
                Return $"virtual { No} { Name}:{ SerialNo}"
            Else
                Return "physical { No} { Name}:{ SerialNo}"
            End If
        End Function
    End Structure
End Module
