Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Net.Sockets
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Server
    'Create varibles for connection details
    Public servName As String
    Public url As String
    Public port As Integer
    Public username As String

    'Socket varibles
    Private socket As New TcpClient()
    Private socketStream

    'Threads
    Private pingThread As Thread
    Private generalThread As Thread

    'Data varibles
    Private outStream As Byte()
    Private message(2048) As Byte
    Private fMessage As String

    Private tab As String

    'Initialise sub
    Public Sub New(name As String, url As String)
        'Splits the url in half
        Dim pathAndPort = url.Split(":")
        'Get port
        port = CInt(pathAndPort(1))

        'Get the url to connect to
        Me.url = pathAndPort(0)
        'Get user friendly name and set the var
        servName = name

        If File.Exists("configs/" & servName & "Users") = False Then
            File.Create("configs/" & servName & "Users").Dispose()
        End If

    End Sub

    'Connect to server
    Public Sub Connect(username As String)
        Dim fileReader As String
        fileReader = My.Computer.FileSystem.ReadAllText("configs/" & servName & "Users")
        Dim fU = fileReader.Substring(0, fileReader.Length - 1).Split(" ")
        If fU.Length = 1 Then
            If ircForm.friendsLBox.Items.Contains(fU(0)) = False Then
                ircForm.friendsLBox.Items.Add(fU(0))
            End If
        Else
            For i = 0 To fU.Length() - 1
                If ircForm.friendsLBox.Items.Contains(fU(i)) = False Then
                    ircForm.friendsLBox.Items.Add(fU(i))
                End If
            Next
        End If

        'Change username text to inputted username
        ircForm.usrLbl.Text = username
        Me.username = username

        'Adjust sendBox size to show username lable
        AdjustSendBox()

        'Change ircForm title text
        ircForm.Text = username & " : " & servName
        ircForm.serverPage.Text = servName

        'Check if server has previously been connected to
        If ircForm.serverLBox.Items.Contains(servName) Then
            'Used to continue loop if not connected
            Dim con = True
            'Used to add seconds to wait for connection
            Dim count As Integer = 0

            'When not connected
            While con = True
                'Try to connect
                Try
                    'Connect
                    SetupConn()
                    'Stops loop
                    con = False

                Catch ex As Exception
                    'Adds to count
                    count += 1

                    'Notifies user on how long to wait
                    With ircForm.msgeBox
                        .SelectionColor = Color.Yellow
                        .AppendText("Connecting in " & count & " second/s" & vbCrLf)
                        .SelectionColor = Color.FromArgb(230, 230, 230)
                    End With

                    'Waits for count in seconds
                    Thread.Sleep(count * 1000)
                End Try
            End While
        Else
            ircForm.serverLBox.Items.Add(servName)

            'Start the connection
            SetupConn()
        End If

        'Send user details, and their nickname to start connection with the server
        SendData("USER " & username & " " & username & " " & username & " :" & username, socketStream)
        SendData("NICK " & username, socketStream)

        'Authrises account with server, is temporary, removed password for git push
        SendData("PRIVMSG NickServ :identify (password)", socketStream) 'Temp

        'Sets header to say that you have connected to the server
        ircForm.headerBox.Text = "You have connected to " & servName

        'ircForm.serverLBox.Items.Add(servName)
    End Sub

    'Disconnect from server
    Public Sub Disconnect(instance As ircForm)
        'send quit message
        SendData("QUIT Bye!", socketStream)
        'Kill thread
        instance.KillListen()

        With instance.msgeBox
            'change colour
            .AppendText(vbNewLine)
            .SelectionColor = Color.Red
            .AppendText("###############")
            .AppendText(vbCr & "#")
            .SelectionColor = Color.FromArgb(230, 230, 230)
            .AppendText(" Disconnected ")
            .SelectionColor = Color.Red
            .AppendText("#")
            .AppendText(vbCr & "###############" & vbLf)
            .SelectionColor = Color.FromArgb(230, 230, 230)
        End With

        'Close and dispose networking vars
        socket.Close()
        socket.Dispose()
        socketStream.Close()
        socketStream.Dispose()

        'Kill the listen thread and remove not needed RAM
        GC.Collect()
    End Sub

    'Listen to incoming data
    Public Sub Listen(instance As ircForm)
        'Starts listening for data
        While 1
            'Get incoming data
            socketStream.Read(message, 0, 2048)

            'Turn to string and remove null characters
            fMessage = RmNull(System.Text.Encoding.ASCII.GetString(message))
            tab = getTab(instance)

            If fMessage = Nothing Then
                MsgBox(fMessage)

                'If the response was PING
            ElseIf fMessage.Substring(0, 4) = "PING" Then
                'Start pong thread
                pingThread = New Thread(AddressOf Pong)
                pingThread.IsBackground = True
                pingThread.Start()
            Else
                'Regex captured string into seperate groups
                For Each m As Match In Regex.Matches(fMessage, ":((\w+)!)?(.+) (.+) (.+) :(.+)\r?")
                    'Define easy to read vars
                    Dim fMessage = m.Groups(6).Value
                    Dim usr = m.Groups(2).Value

                    'Vars to get first and last char so you can see if it is a CTCP message
                    Dim c1 = Left(fMessage, 1)
                    Dim c2 = Right(fMessage.Replace(vbCr, String.Empty), 1)

                    If m.Groups(5).Value.StartsWith("#") Then
                        If instance.channelTab.TabPages.ContainsKey(m.Groups(5).Value & "Tab") = False Then
                            Dim newPage As New TabPage()
                            setupTab(m.Groups(5).Value, newPage, instance)
                        End If

                    ElseIf usr <> Nothing Then
                        If instance.channelTab.TabPages.ContainsKey(usr & "Tab") = False Then
                            Dim newPage As New TabPage()
                            setupTab(usr, newPage, instance)
                        End If
                    End If

                    'If the vars are the right ones
                    If c1 = c2 And c1 = ChrW(&H1) Then
                        If usr = Nothing Then
                            Try
                                'Get the username from the badly parsed regex
                                usr = m.Groups(3).Value.Split("!")(0)
                            Catch

                            End Try
                        End If
                        'Add usr to msgBox with colour
                        ColourChange(usr, "usr", instance)

                        'Append recieved message
                        instance.msgeBox.AppendText("  | -> Recived CTCP '" & RmHiddenChar(fMessage).Replace(ChrW(&H1), String.Empty) & "'")

                        'If nickname or channel doesn't exist, and sends back text, parse and change colour
                    ElseIf fMessage = "No such nick/channel" & vbCr Then
                        noUsr(fMessage, instance)

                        'if no channel, parse and change colour
                    ElseIf fMessage = "No such channel" & vbCr Then
                        noUsr(fMessage, instance)

                        'After successfulling connecting, channel sends back this, change to pink
                    ElseIf fMessage = "End of /NAMES list." & vbCr Then
                        'noUsr(fMessage, instance)

                        'If group 3 length is 3 and...
                    ElseIf (m.Groups(3).Value).Split(" ").Length = 3 Then
                        'That it sent the names of users due to the 353 code
                        If (m.Groups(3).Value).Split(" ")(1) = "353" Then

                            Dim chan As String = m.Groups(5).Value.Remove(0, 1)
                            Dim path As String = "temp/" & chan & "Names"

                            If tab = chan Then
                                Dim fR = My.Computer.FileSystem.ReadAllText("temp/" & tab & "Names")

                                'Add to users box
                                Dim chanUsers = RmHiddenChar(fR).split(" ")
                                For i = 0 To chanUsers.length() - 1
                                    instance.usersLBox.Items.Add(chanUsers(i))
                                Next
                            Else
                                Using writer As StreamWriter = New StreamWriter(path, False)
                                    writer.WriteLine(fMessage)
                                End Using
                            End If

                        End If

                        'if there was no username in the message
                    ElseIf usr = Nothing Then
                        'If on the correct tab, the main server tab
                        If tab = servName Then
                            'Adds text to the tab
                            instance.msgeBox.AppendText(fMessage)
                        Else
                            'Saves it to a text file to be read later
                            logFile(fMessage.Replace(vbCr, String.Empty), servName)
                        End If
                    Else
                        'If the response is a channel
                        If m.Groups(5).Value.StartsWith("#") Then

                            'And that tab is currently open
                            If tab = m.Groups(5).Value Then
                                'Print username
                                usrColour(m.Groups(2).Value, instance)
                                'Add message
                                instance.msgeBox.AppendText(fMessage.Replace(vbCr, String.Empty))
                            Else
                                'Save to file
                                logFile(m.Groups(2).Value & " | " & fMessage.Replace(vbCr, String.Empty), m.Groups(5).Value)
                            End If
                        Else
                            'If the message is from a user
                            If tab = usr Then
                                'Print the username
                                usrColour(usr, instance)
                                'Add to textbox
                                instance.msgeBox.AppendText(fMessage.Replace(vbCr, String.Empty))
                            Else
                                'Save the message
                                logFile(usr & " | " & fMessage.Replace(vbcr, String.Empty), usr)
                            End If
                        End If
                    End If
                Next
            End If
            'Clears the aray
            Array.Clear(message, message.GetLowerBound(0), message.Length)
        End While
    End Sub

    'Gets needed network vars and message to then be sent to server
    Public Sub SendMsg(msg As String, server As Server, instance As ircForm)
        'Creates message class
        Dim message As New Message(msg, server, socket, socketStream, username, servName, instance)
    End Sub

    'Pong the server when they ping client
    Private Sub Pong()
        'Send pong to server for connection to last
        SendData("PONG", socketStream)
        'Kill thread as not needed
        Thread.CurrentThread.Abort()
    End Sub

    'Removes null valuses
    Public Function RmNull(s As String)
        s = s.Replace(vbNullChar, "")
        Return s
    End Function

    'Sets up connection with server
    Private Sub SetupConn()
        'Creates new socket
        socket = New TcpClient()
        'Connect to the url and port
        socket.Connect(url, port)

        'Check if it is ssl
        If port = 6697 Then
            'open ssl stream and authenticate
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls
            socketStream = New SslStream(socket.GetStream())
            socketStream.AuthenticateAsClient(url)
        Else
            'Use unencrypted connection
            socketStream = socket.GetStream()
        End If
    End Sub

    'Adjusts send box
    Private Sub AdjustSendBox()
        'Used to check bounds are not intersecting
        Dim b As Boolean = True

        While b = True
            'When still intersecting
            b = ircForm.sendBox.Bounds.IntersectsWith(ircForm.usrLbl.Bounds)
            If b = False Then 'If not intersecting, success and leave look
                Exit While
            Else
                'Gets current position of the text box and adds one to x axis
                ircForm.sendBox.Location = New Point(ircForm.sendBox.Location.X + 1, ircForm.sendBox.Location.Y)
                'Reduces size of the box
                ircForm.sendBox.Width = ircForm.sendBox.Width - 1
            End If
        End While
    End Sub

    'Saves text with no name to main log, and if on main tab write to tab
    Private Sub noUsr(msg As String, instance As ircForm)
        tab = getTab(instance)

        If tab = servName Then
            'If username found add text to box
            ColourChange(RmHiddenChar(msg), "Pink", instance)
        Else
            logFile(msg.Replace(vbCr, String.Empty), servName)
        End If
    End Sub

    'Changes colour of usernames
    Private Sub usrColour(usr As String, instance As ircForm)
        ColourChange(usr, "usr", instance)
        instance.msgeBox.AppendText(" | ")
    End Sub
End Class
