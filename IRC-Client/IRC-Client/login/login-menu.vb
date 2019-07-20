Public Class loginMenu
    Private Sub loginMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'When a user presses tab, it switches focus of each object
        userBox.TabIndex = 0
        passBox.TabIndex = 1
        loginBtn.TabIndex = 2
        regBtn.TabIndex = 3
        forgotBtn.TabIndex = 4
        resetBtn.TabIndex = 5
    End Sub

    Private Sub regBtn_Click(sender As Object, e As EventArgs) Handles regBtn.Click
        'Shows register form, hides current
        registerForm.Show()
        Me.Close()
        logoImg.Image = IRC_Client.My.Resources.Resources.Logo
    End Sub

    Private Sub forgotBtn_Click(sender As Object, e As EventArgs) Handles forgotBtn.Click
        'Shows forgot form, hides current
        forgotForm.Show()
        Me.Hide()
        logoImg.Image = IRC_Client.My.Resources.Resources.Logo
    End Sub

    Private Sub resetBtn_Click(sender As Object, e As EventArgs) Handles resetBtn.Click
        'Shows reset form, hides current
        resetForm.Show()
        Me.Hide()
        logoImg.Image = IRC_Client.My.Resources.Resources.Logo
    End Sub

    Private Sub loginBtn_Click(sender As Object, e As EventArgs) Handles loginBtn.Click
        'Disable buttons when clicked to stop network spam
        DisableButtons(Me)

        'Declare a bloolean and check for connection
        Dim checkConn As Boolean
        checkConn = CheckForConnection("http://" & GetLoginIp()(0))

        'If there was a connection, send data to login server
        If checkConn = True Then
            'Declares varibles to be used to send login info after starting the login thread
            Dim user As String = userBox.Text
            Dim pass As String = passBox.Text
            pass = GenSHA256SHash(pass) 'Hashes password so it adds more characters

            'Creates the string to be sent to the server, and starts the connection
            Dim concat As Byte() = System.Text.Encoding.ASCII.GetBytes(user & " " & pass)
            Dim returndata As String = LServerRequest("login", concat)

            'If the connection failed display a message box and enable buttons
            If returndata = "error" Then
                'Enable buttons when finished
                EnableButtons(Me)
                MessageBox.Show("Error: Server side error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                'Checks data to see if the server reply was positive
                If returndata = "PASS" Then
                    ircForm.Show()
                    CloseAndFree(Me)
                ElseIf returndata = "ADMIN" Then
                    ircForm.Show()
                    CloseAndFree(Me)
                ElseIf returndata = "FAIL" Then
                    logoImg.Image = IRC_Client.My.Resources.Resources.LoginError
                End If

                EnableButtons(Me)
                GC.Collect()
            End If
        Else
            'Enable buttons when finished
            EnableButtons(Me)
            MessageBox.Show("Error: No connection to server" & vbNewLine & "Check if you are connected to the server, or if the server is online", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            GC.Collect()
        End If
    End Sub

    Private Sub enter_KeyDown(sender As Object, e As KeyEventArgs) Handles userBox.KeyDown, passBox.KeyDown
        Try
            'If user presses enter, send info to server
            If e.KeyValue = Keys.Enter Then
                loginBtn.PerformClick()
                e.SuppressKeyPress = True
                e.Handled = True
                Threading.Thread.Sleep(3000)
            ElseIf e.KeyValue = Keys.VolumeDown Then 'DEBUG: Else, if volume down pressed, open IRC form
                ircForm.Show()
                Me.Hide()
                e.SuppressKeyPress = True
                e.Handled = True
            End If
        Catch ex As Exception 'If given error display it
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
