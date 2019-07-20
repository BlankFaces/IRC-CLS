Imports System.IO
Imports System.Net
Imports System.Net.Security
Imports System.Net.Sockets
Imports System.Threading

Public Class Message

    'Define vars
    'Get main ircForm thread window
    Private instance As ircForm
    Private server As Server
    Private fN As String

    'Used for messages
    Private usr As String
    Private message As String
    Private msgAry() As String

    'Network Vars
    Private socket As TcpClient
    Private stream

    Private isTab As Boolean
    Private tab As String

    'Initialise rext and start functions
    Public Sub New(message As String, server As Server, socket As TcpClient, stream As SslStream, usr As String, fN As String, instance As ircForm)

        'Set vars from above to their respected varibles
        Me.instance = instance
        Me.usr = usr
        Me.message = message
        Me.socket = socket
        Me.stream = stream
        Me.server = server
        Me.fN = fN

        'if message was invalid or has no command, it would create an error. If not, no error
        Try
            'Split the string by spaces
            msgAry = Split(Me.message, " ")
            'get the command from the array
            Dim command As String = msgAry(0).ToLower

            'Select command to be checked against
            Select Case command
                Case "/msg" 'If command is /msg, run msgcommand
                    Dim msg As String = GetMsg()
                    isTab = False
                    MsgCommand(msg)
                Case "/join"
                    joinChan()
                Case "/leave"
                    leaveChan()
                Case "/add"
                    AddFriend()
                Case Else
                    instance.Show()
                    isTab = True
                    tab = getTab(instance)
                    MsgCommand(Me.message)

            End Select
        Catch e As Exception
            'Try and find the error for now
            MsgBox(e.ToString)
        End Try
    End Sub

    Private Sub MsgCommand(msg As String)
        'Create var for formatted text to be put into
        Dim concat As String = ""
        If msg <> "" Then
            If isTab = False Then
                'Concats string into correct format
                concat = "PRIVMSG " & msgAry(1) & " :" & msg
                'Send message to user on server, and flushes stream
                SendData(concat, stream)

                'Append to box
                ColourChange("Msg to: " & msgAry(1), "usr", instance)
                instance.msgeBox.AppendText(" | " & msg)

            ElseIf isTab = True Then
                If getTab(instance) <> fN Then
                    'Concats string into correct format
                    concat = "PRIVMSG " & tab & " :" & msg
                    'Send message to user on server, and flushes stream
                    SendData(concat, stream)

                    'Append to box
                    ColourChange(instance.usrLbl.Text, "usr", instance)
                    instance.msgeBox.AppendText(" | " & msg)
                End If
            End If
        End If
    End Sub

    Private Sub AddFriend()
        'Adds user to list
        If msgAry(1) <> "" Or msgAry(1) = Nothing Then
            instance.friendsLBox.Items.Add(msgAry(1))
            My.Computer.FileSystem.WriteAllText("configs/" & fN & "Users", msgAry(1) & " ", True)
        Else
            ColourChange("No username inputted.", "pink", instance)
        End If
    End Sub

    Private Sub chnageNick()
        SendData("NICK " & msgAry(1), stream)
    End Sub

    Private Sub joinChan()
        SendData("JOIN " & msgAry(1), stream)
    End Sub

    Private Sub leaveChan()
        SendData("PART " & msgAry(1), stream)
        instance.channelTab.SelectedTab = instance.channelTab.TabPages(0)
        instance.channelTab.TabPages.RemoveByKey(msgAry(1) & "Tab")
    End Sub

    Private Function GetMsg()
        Dim fMessage As String = ""
        'Loop through array to recreate message
        For i As Integer = 2 To msgAry.Length - 1
            fMessage += msgAry(i) & " "
        Next
        Return fMessage
    End Function
End Class
