'Import libraries 
Imports System.Net
Imports System.Text
Imports System.Security.Cryptography
Imports System.Net.Sockets
Imports System.IO

Module login_modules

    'Starts connection and sends data to server
    Public Function LServerRequest(rString, concat)

        'Declares a tcp client and a networkstream
        Dim clientSocket As New TcpClient()
        Dim serverStream As NetworkStream
        Dim returndata As String
        Dim ip As Array = GetLoginIp()

        'Starts a connection with the server
        clientSocket.Connect(ip(0), CInt(ip(1)))
        serverStream = clientSocket.GetStream()

        'Declares the outbound data stream
        Dim outStream As Byte() = System.Text.Encoding.ASCII.GetBytes(rString)

        'sends "login" to the server and flushes data from the stream
        serverStream.Write(outStream, 0, outStream.Length)
        serverStream.Flush()

        'When recieved data put it into the inStream varible
        Dim inStream(1024) As Byte
        serverStream.Read(inStream, 0, 1024)

        'Format the data returned for the if statement.
        returndata = RmHiddenChar(System.Text.Encoding.ASCII.GetString(inStream))

        'If the server didnt send "LOGIN" output error, else see what the response was and output it
        If returndata = rString.ToUpper Then

            'Send the concat varible from earlier to the server
            serverStream.Write(concat, 0, concat.Length)
            serverStream.Flush()

            'Read the data into the inStream varible, and turn from bytes to ascii string
            serverStream.Read(inStream, 0, 1024)
            returndata = RmHiddenChar(System.Text.Encoding.ASCII.GetString(inStream))

            Return returndata

        Else
            MsgBox("error: malformed request") 'Temp, If didn't recieve "LOGIN" should return an error
            'Enable buttons when finished
            Return "error"
        End If
    End Function

    'Opens file to get ip
    Public Function GetLoginIp()
        Try
            Using sr As StreamReader = New StreamReader("configs/ip")
                Dim oIp As String = RmHiddenChar(sr.ReadToEnd())
                Dim ip As Array = oIp.Split(":")
                Return ip
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Return 0
        End Try

    End Function

    'Checks for connectiond
    Public Function CheckForConnection(ip) As Boolean
        Try 'Try and connect to the ip
            Using client = New WebClient()
                Using stream = client.OpenRead(ip) 'Try connect to the ip
                    Return True 'If connected without error return true
                End Using
            End Using
        Catch 'If can't get a connection
            Return False
        End Try
    End Function

    'Generates a string from the hash
    Public Function GenSHA256SHash(ByVal pass) As String
        'Computes the hash for the input data using the managed library
        Dim sha256 As SHA256 = SHA256Managed.Create()
        'Encodes the password, and convert to bytes
        Dim bytes As Byte() = Encoding.ASCII.GetBytes(pass)
        'Computes the hash and stores it in the var
        Dim hash As Byte() = sha256.ComputeHash(bytes)
        Dim sB As New StringBuilder()
        'Turns the bytes to string
        For i As Integer = 0 To hash.Length - 1
            sB.Append(hash(i).ToString("X2"))
        Next

        Return sB.ToString()
    End Function

    'Disables buttons to prevent network spam
    Public Sub DisableButtons(con As Control)
        For Each c As Control In con.Controls
            If TypeOf c Is Button Then
                c.Enabled = False
            End If
        Next
    End Sub

    'Enables buttons to allow user input
    Public Sub EnableButtons(con As Control)
        Threading.Thread.Sleep(3000)
        For Each c As Control In con.Controls
            If TypeOf c Is Button Then
                c.Enabled = True
            End If
        Next
    End Sub

    'Clear and show menu
    Public Sub OpenLoginMenu(form)
        loginMenu.Show()
        CloseAndFree(form)
    End Sub

End Module