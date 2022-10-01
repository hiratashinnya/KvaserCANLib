Imports Kvaser.CanLib
Module PortController
    Private Ports As Dictionary(Of Integer, PortParameter)
    Friend HandleNo As Integer

    Friend Property BitRateConfigs As String() =
    {
        "10Kbit/sec ",
        "50Kbit/sec ",
        "100Kbit/sec",
        "125Kbit/sec",
        "250Kbit/sec",
        "500Kbit/sec",
        "1Mbit/sec"
    }

    Sub New()
        Ports = New Dictionary(Of Integer, PortParameter)
    End Sub

    Friend Function HasPorts() As Boolean
        Return Ports.Count > 0
    End Function
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

    Private Function SetBusParam(ByVal busbitrate As Integer) As Boolean
        Dim stat = Canlib.canSetBusParams(HandleNo, busbitrate, 0, 0, 0, 1)
        If stat = Canlib.canStatus.canOK Then
            Return True
        Else
            Dim buffStr As String = ""
            Canlib.canGetErrorText(stat, buffStr)
            MsgBox(buffStr)
            Return False
        End If
    End Function
    Friend Function BusOn(ByVal bitrate As Integer, ByVal handleNo As Integer) As Boolean
        If Not Ports.ContainsKey(handleNo) Then
            MsgBox($"port {handleNo} is not found.", Title:="Port BusOn Error!")
            Return False
        End If

        If Not SetBusParam(bitrate) Then
            Return False
        End If

        Dim stat = Canlib.canBusOn(handleNo)
        If stat <> Canlib.canStatus.canOK Then
            Dim buffStr As String = ""
            Canlib.canGetErrorText(stat, buffStr)
            MsgBox(buffStr)
            Return False

        Else ' canOK = Canlib.canBusOn(handleNo)
            PortController.HandleNo = handleNo
            Return True
        End If
    End Function

    Friend Function BusOff() As Boolean
        Dim stat = Canlib.canBusOff(HandleNo)
        If stat = Canlib.canStatus.canOK Then
            Return True
        Else
            Dim buffStr As String = ""
            Canlib.canGetErrorText(stat, buffStr)
            MsgBox(buffStr)
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
