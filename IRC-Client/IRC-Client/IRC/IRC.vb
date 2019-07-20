'Notes/Help:
'get a minimal viable product working and then refactor and add features
'Single server connection handling messages, joins And quits, Then add threading To keep multiple connections 
'alive at once And add ui code To switch between the channels' list of messages, users, and which socket to send new messages to
'i.e. a suboptimal presentable project Is better than an incomplete but optimal project
'implement the code to connect to a server and parse/display messages coming in and then work on the rest of the stuff

'when you connect ot a channel Or msg a user, add their name to the tabcontrol And hook the tab changed event to set the
'txtbox.text to the messages stored in an array only to ones concerning the selected tab, how you'll keep the messages updated
'And filtered post changing the tab will depend on would dpend on your impleemtnation

'Colour scheme https://coolors.co/39393a-e6e6e6-faa916-fbfffe-6d676e
'https://stackoverflow.com/questions/28430266/visual-basic-how-i-can-put-my-work-at-backgroundworker
'https://stackoverflow.com/questions/2240702/crossthread-operation-not-valid-vb-net

Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class ircForm
    'Create new server connection
    Public freenode = New Server("Freenode", "chat.freenode.net:6697")

    'Threads
    Dim listenThread As Thread
    Dim msgThread As Thread

    'Used to check if connected or not
    Dim num As Integer = 0

    Public PreviousTab As String
    Public CurrentTab As String

    Private Sub ircForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Allows me to write to main thread
        CheckForIllegalCrossThreadCalls = False 'research background worker
        changeColours(Me)
    End Sub

    Private Sub irc_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Kill everything when closing
        For Each _file As String In Directory.GetFiles("temp/")
            File.Delete(_file)
        Next
        Application.Exit()
    End Sub

    Private Sub settingsTSBtn_Click(sender As Object, e As EventArgs) Handles settingsTSBtn.Click
        'Shows settings form
        settingsForm.Show()
    End Sub

    Private Sub sendBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles sendBox.KeyDown
        'run if enter pressed
        If e.KeyCode = Keys.Enter Then
            If num = 1 Then
                'Get text from textbox
                Dim msg As String = sendBox.Text
                'Create a new msgThread
                msgThread = New Thread(Sub() freenode.SendMsg(msg, freenode, Me))
                'Change it to background thread
                msgThread.IsBackground = True
                'Start the thread
                msgThread.Start()
            End If
            'Clears textbox
            sendBox.Text = String.Empty
            'Stops the ding-a-ling
            e.SuppressKeyPress = True
            e.Handled = True
        End If
    End Sub

    Private Sub joinFreeBtn_Click(sender As Object, e As EventArgs) Handles joinFreeBtn.Click
        'If diconnected, you can connect
        If num = 0 Then
            'set to disconnect
            num = 1
            'Connect to server with username in quotes
            freenode.connect("EEEETesting")
            'Start a listen thread for freenode
            StartListen(freenode)
            'Join the channel bellow as default
            'freenode.join("#subhacker")
        End If
    End Sub

    'Start a listen thread
    Private Sub StartListen(server)
        'Create new thread which runs listen on the server inputted
        listenThread = New Thread(Sub() server.listen(Me))
        'Makes it a background thread
        listenThread.IsBackground = True
        'Starts the thread
        listenThread.Start()
    End Sub

    Private Sub disconnectBtn_Click(sender As Object, e As EventArgs) Handles disconnectBtn.Click
        'If connected, you can disconnect
        If num = 1 Then
            'Disconnect from server
            freenode.disconnect(Me)
            listenThread.Abort()
            'Set num to zero to signify that i'm not connected
            num = 0
        End If
    End Sub

    'Kills listen thread, used for server class to stop it
    Public Sub KillListen()
        listenThread.Abort()
    End Sub

    Public Sub SetNum(i As Integer)
        num = i
    End Sub

    Private Sub channelTab_Deselected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles channelTab.Deselected
        PreviousTab = e.TabPage.Text
    End Sub

    Private Sub channelTab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles channelTab.SelectedIndexChanged
        usersLBox.Items.Clear()

        'Open the file and write the text from the texbox into it
        Using writer As StreamWriter = New StreamWriter("logs/" & PreviousTab & ".txt", False)
            'Creates the varible
            Dim curLine As String = msgeBox.Text
            'If greater than one line
            If (msgeBox.Lines.Count > 1) Then
                'Reset Var
                curLine = ""
                'Format the text so there is a break in the line
                For Each line As String In msgeBox.Lines
                    curLine = curLine & vbCrLf & line
                Next
                'Remove bad chars
                curLine = curLine.Trim(vbCr, vbLf)
            End If
            'Write to file
            writer.WriteLine(curLine)
        End Using

        msgeBox.Clear()

        'Open up the file containing the text
        Try
            'Read the text and add the text to box
            Dim fileReader As String
            fileReader = My.Computer.FileSystem.ReadAllText("logs/" & channelTab.SelectedTab.Text & ".txt")
            msgeBox.AppendText(fileReader)

            'Scrolls to bottom of textbox
            msgeBox.ScrollToCaret()
        Catch
            'If doesn't exist just append this to the box
            msgeBox.Text = "The start of a new chat"
        End Try

        Try
            Dim fR = My.Computer.FileSystem.ReadAllText("temp/" & channelTab.SelectedTab.Text.Remove(0, 1) & "Names")

            'Add to users box
            Dim chanUsers = RmHiddenChar(fR).split(" ")
            For i = 0 To chanUsers.length() - 1
                usersLBox.Items.Add(chanUsers(i))
            Next
        Catch

        End Try

        'Turns the lines into a list
        Dim myList As List(Of String) = msgeBox.Lines.ToList()
        If myList.Count > 0 Then
            'Removes the last line
            myList.RemoveAt(myList.Count - 1)
            'Adds it back to textbox
            msgeBox.Lines = myList.ToArray()
            'Refreshes box for update
            msgeBox.Refresh()
        End If
    End Sub
End Class