Public Class resetForm
    Private Sub resetForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'When a user presses tab, it switches focus of each object
        userBox.TabIndex = 0
        pass1Box.TabIndex = 1
        pass2Box.TabIndex = 2
        resetBox.TabIndex = 3
        backBtn.TabIndex = 4
        resetBtn.TabIndex = 5
    End Sub

    Private Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        OpenLoginMenu(Me)
    End Sub

    Private Sub reset_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        OpenLoginMenu(Me)
    End Sub

    Private Sub resetBtn_Click(sender As Object, e As EventArgs) Handles resetBtn.Click
        'Disable buttons when clicked to stop network spam
        DisableButtons(Me)
        If pass1Box.Text = pass2Box.Text And pass1Box.Text <> "" Then
            'Declare a bloolean and check for connection
            Dim checkConn As Boolean
            checkConn = CheckForConnection("http://" & GetLoginIp()(0))

            If checkConn = True Then
                'Declares varibles for sending for later, hashes password
                Dim user As String = userBox.Text
                Dim pass As String = pass1Box.Text
                Dim reset As String = resetBox.Text
                pass = GenSHA256SHash(pass) 'Hashes password so it adds more characters

                'Creates the string to be sent to the server, and starts the connection
                Dim concat As Byte() = System.Text.Encoding.ASCII.GetBytes(user & " " & reset & " " & pass)
                Dim returndata As String = LServerRequest("reset", concat)

                'If the connection failed display a message box and enable buttons
                If returndata = "error" Then
                    'Enable buttons when finished
                    EnableButtons(Me)
                    MessageBox.Show("Error: Server side error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    'Checks data to see if the server reply was positive
                    If returndata = "CHANGED" Then
                        resetLbl.Left = 55
                        resetLbl.Text = "Success!"
                    ElseIf returndata = "DENY" Then
                        resetLbl.Left = 85
                        resetLbl.Text = "Failed!"
                    End If

                    'Enables all buttons
                    EnableButtons(Me)
                    GC.Collect()
                End If
            Else
                EnableButtons(Me)
                GC.Collect()
                MessageBox.Show("Error: No connection to server", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            EnableButtons(Me)
            GC.Collect()
            MessageBox.Show("Passwords don't match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub buttons_KeyDown(sender As Object, e As KeyEventArgs) Handles userBox.KeyDown, resetBox.KeyDown, pass2Box.KeyDown, pass1Box.KeyDown
        Try
            'If user presses enter, send info to server
            If e.KeyValue = Keys.Enter Then
                resetBtn.PerformClick()
                e.SuppressKeyPress = True
                e.Handled = True
            End If
        Catch ex As Exception 'If given error display it
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class