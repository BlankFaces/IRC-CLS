Imports System.IO

Module IRC_module

    Private nickColour() As Integer

    'Send the data to the server correctly
    Public Sub SendData(text, socketStream)
        'Formats the text to ASCII bytes
        Dim outstream = System.Text.Encoding.ASCII.GetBytes(text & vbNewLine)
        'Sends the server the text
        socketStream.Write(outstream, 0, outstream.Length)
        'Flushes the socket stream
        socketStream.Flush()
    End Sub

    Public Sub ColourChange(text As String, uC As String, instance As ircForm)
        Dim c

        If uC = "usr" Then
            Try
                c = Color.FromArgb(nickColour(0), nickColour(1), nickColour(2))
            Catch
                c = Color.Orange
            End Try

        Else
            c = Color.FromName(uC)
        End If

        With instance.msgeBox
            'change colour
            .SelectionColor = c
            'Append username
            .AppendText(vbLf & text)
            'Change back to default text
            .SelectionColor = Color.FromArgb(230, 230, 230)
        End With
    End Sub

    'Creates tab for new user / channel
    Public Sub setupTab(text As String, tab As TabPage, instance As ircForm)
        'Creates settings of new tab
        tab.Name = text & "Tab"
        tab.Text = text
        tab.BackColor = Color.FromArgb(57, 57, 58)

        'Adds it to main thread GUI
        instance.BeginInvoke(CType(Function()
                                       instance.channelTab.TabPages.Add(tab)
                                   End Function, MethodInvoker))
    End Sub

    'Saves to appropriate file
    Public Sub logFile(text As String, file As String)
        Using writer As StreamWriter = New StreamWriter("logs/" & file & ".txt", True)
            text = text.Trim(vbCr, vbLf)
            writer.WriteLine(text)
        End Using
    End Sub

    'Gets current tabs text
    Public Function getTab(instance As ircForm)
        Dim tab = instance.channelTab.SelectedTab.Text
        Return tab
    End Function

    Public Sub changeColours(instance As ircForm)

        Try
            'opens up the file
            Dim fileReader As String = My.Computer.FileSystem.ReadAllText("configs/colours")

            'Creates string arrays to store the values from above in
            'Stores all settings
            Dim settings() As String
            'stores one setting
            Dim setting() As String

            'Splits the data in the file into different sections.
            settings = fileReader.Split(" ")

            For i = 0 To 5
                'Change form background
                If i = 1 Then
                    setting = settings(0).Split(",")
                    instance.BackColor = Color.FromArgb(setting(0), setting(1), setting(2))
                    setting = {}

                    'Change control Background
                ElseIf i = 2 Then
                    setting = settings(1).Split(",")

                    For Each c As Control In instance.Controls
                        c.BackColor = Color.FromArgb(setting(0), setting(1), setting(2))
                    Next

                    setting = {}

                    'Change text Colour
                ElseIf i = 3 Then
                    setting = settings(2).Split(",")

                    For Each c As Control In instance.Controls
                        c.ForeColor = Color.FromArgb(setting(0), setting(1), setting(2))
                    Next

                    setting = {}

                    'Change nick Colour
                ElseIf i = 4 Then
                    setting = settings(3).Split(",")

                    For Each c As Control In instance.Controls
                        setNickColour(setting)
                    Next

                    'Change font Size
                Else
                    For Each c As Control In instance.Controls
                        Dim fnt As Font = New Font("Microsoft Sans Serif", settings(4))
                        ircForm.msgeBox.Font = fnt
                    Next
                End If
            Next
        Catch

        End Try
    End Sub

    'Gets the nick name colour
    Function getNickColour()
        Return nickColour
    End Function

    'Sets the nick name colour
    Sub setNickColour(uRGB() As String)
        Dim RGB(2) As Integer

        For i = 0 To 2
            RGB(i) = CInt(uRGB(i))
        Next

        nickColour = RGB
    End Sub
End Module
