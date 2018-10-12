Imports System.Net.Sockets
Imports System.Text

Public Class Form1

    Private Sub getWebrelayState()

        Dim tcpClient As New System.Net.Sockets.TcpClient()
        Dim port As Integer


        Try
            'Connect to webrelay
            port = Convert.ToInt32(portTextBox.Text)
            tcpClient.Connect(addressTextBox.Text.ToString(), port)

            If tcpClient.Connected Then

                'Create a network stream object
                Dim netStream As NetworkStream = tcpClient.GetStream()

                'If we can read and write to the stream then do so
                If netStream.CanWrite And netStream.CanRead Then

                    'Send the on command to webrelay
                    Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes("GET /state.xml?noReply=0 HTTP/1.1" & vbCrLf & "Authorization: Basic bm9uZTp3ZWJyZWxheQ==" & vbCrLf & vbCrLf)
                    netStream.Write(sendBytes, 0, sendBytes.Length)

                    'Get the response from webrelay
                    Dim bytes(tcpClient.ReceiveBufferSize) As Byte
                    netStream.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))

                    'Parse the response and update the webrelay state and input text boxes
                    Dim returndata As String = Encoding.ASCII.GetString(bytes)

                    'Parse out the relay state and input state
                    Dim array1 As Char() = returndata.ToCharArray()

                    'Relay State found at index 66
                    If array1(210) = "1" Then
                        relayState.Text = "ON"
                    Else
                        relayState.Text = "OFF"
                    End If

                    'Input State found at index 94
                    If array1(94) = "1" Then
                        inputState.Text = "ON"
                    Else
                        inputState.Text = "OFF"
                    End If

                End If

                'Close the connection
                tcpClient.Close()

            End If

        Catch e As Exception
            inputState.Text = "Error"
            relayState.Text = "Error"
            'Disable the timer
            Timer1.Enabled = False
        End Try

    End Sub

    Private Sub sendRequest(ByVal val As String)

        Dim tcpClient As New System.Net.Sockets.TcpClient()
        Dim port As Integer

        Try
            'Disable the timer
            Timer1.Enabled = False

            'Connect to webrelay
            port = Convert.ToInt32(portTextBox.Text)

            tcpClient.Connect(addressTextBox.Text.ToString(), port)

            If tcpClient.Connected Then

                'Create a network stream object
                Dim netStream As NetworkStream = tcpClient.GetStream()

                'If we can read and write to the stream then do so
                If netStream.CanWrite And netStream.CanRead Then

                    'Send the on command to webrelay
                    Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes("GET /state.xml?relay1State=" & val & " HTTP/1.1" & vbCrLf & "Authorization: Basic bm9uZTp3ZWJyZWxheQ==" & vbCrLf & vbCrLf)
                    netStream.Write(sendBytes, 0, sendBytes.Length)

                    'Get the response from webrelay
                    Dim bytes(tcpClient.ReceiveBufferSize) As Byte
                    netStream.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))

                    'Parse the response and update the webrelay state and input text boxes
                    Dim returndata As String = Encoding.ASCII.GetString(bytes)

                    'Parse out the relay state and input state
                    Dim array1 As Char() = returndata.ToCharArray()

                    'Relay State found at index 66
                    If array1(210) = "1" Then
                        relayState.Text = "ON"
                    Else
                        relayState.Text = "OFF"
                    End If

                    'Input State found at index 94
                    If array1(94) = "1" Then
                        inputState.Text = "ON"
                    Else
                        inputState.Text = "OFF"
                    End If

                End If

                'Close the connection
                tcpClient.Close()

            End If

            'Enable the timer
            Timer1.Enabled = True

        Catch e As Exception
            inputState.Text = "Error"
            relayState.Text = "Error"
            'Disable the timer
            Timer1.Enabled = False
        End Try



    End Sub
    

    Private Sub onButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles onButton.Click

        sendRequest("1")

    End Sub

    Private Sub offButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles offButton.Click

        sendRequest("0")

    End Sub

    Private Sub pulseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pulseButton.Click

        sendRequest("2")

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        getWebrelayState()
    End Sub

    Private Sub addressTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addressTextBox.TextChanged

    End Sub
End Class
