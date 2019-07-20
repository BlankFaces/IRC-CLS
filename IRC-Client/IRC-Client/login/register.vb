Public Class registerForm
    Private Sub register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'When a user presses tab, it switches focus of each object
        emailBox.TabIndex = 0
        userBox.TabIndex = 1
        passBox.TabIndex = 2
        backBtn.TabIndex = 3
        regBtn.TabIndex = 4
    End Sub

    Private Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        OpenLoginMenu(Me)
    End Sub

    Private Sub reg_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        OpenLoginMenu(Me)
    End Sub

    Private Sub regBtn_Click(sender As Object, e As EventArgs) Handles regBtn.Click
        'Disable buttons when clicked to stop network spam
        DisableButtons(Me)

        'Declare a bloolean and check for connection
        Dim checkConn As Boolean
        checkConn = CheckForConnection("http://" & GetLoginIp()(0))

        'If there was a connection, send data to login server
        If checkConn = True Then

            'Declares varibles for sending for later, hashes password
            Dim email As String = emailBox.Text
            Dim user As String = userBox.Text
            Dim pass As String = passBox.Text
            pass = GenSHA256SHash(pass) 'Hashes password so it adds more characters

            'Creates the string to be sent to the server, and starts the connection
            Dim concat As Byte() = System.Text.Encoding.ASCII.GetBytes(user & " " & email & " " & pass)
            Dim returndata As String = LServerRequest("register", concat)

            'If the connection failed display a message box and enable buttons
            If returndata = "error" Then
                'Enable buttons when finished
                EnableButtons(Me)
                MessageBox.Show("Error: Server side error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                'Checks data to see if the server reply was positive
                If returndata = "CREATED" Then
                    regLbl.Text = "Created!"
                ElseIf returndata = "USER EXISTS" Then
                    regLbl.Left = 50
                    regLbl.Text = "User Exists."
                ElseIf returndata = "EMAIL EXISTS" Then
                    regLbl.Left = 50
                    regLbl.Text = "Email Used."
                ElseIf returndata = "EMAIL NOT VALID" Then
                    regLbl.Left = 40
                    regLbl.Text = "Email Invalid."
                End If

                'Enables all buttons
                EnableButtons(Me)
                GC.Collect()
            End If

        Else
            'Enable buttons when finished
            EnableButtons(Me)
            GC.Collect()
            MessageBox.Show("Error: No connection to server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub buttons_KeyDown(sender As Object, e As KeyEventArgs) Handles userBox.KeyDown, passBox.KeyDown, emailBox.KeyDown
        Try
            'If user presses enter, send info to server
            If e.KeyValue = Keys.Enter Then
                regBtn.PerformClick()
                e.SuppressKeyPress = True
                e.Handled = True
            End If
        Catch ex As Exception 'If given error display it
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class