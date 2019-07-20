Public Class forgotForm
    Private Sub forgotForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'When a user presses tab, it switches focus of each object
        userBox.TabIndex = 0
        backBtn.TabIndex = 1
        forgotBtn.TabIndex = 2
    End Sub

    Private Sub backBtn_Click(sender As Object, e As EventArgs) Handles backBtn.Click
        OpenLoginMenu(Me)
    End Sub

    Private Sub forgot_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        OpenLoginMenu(Me)
    End Sub

    Private Sub forgotBtn_Click(sender As Object, e As EventArgs) Handles forgotBtn.Click
        'Disable buttons when clicked to stop network spam
        DisableButtons(Me)

        'Declare a bloolean and check for connection
        Dim checkConn As Boolean
        checkConn = CheckForConnection("http://" & GetLoginIp()(0))

        'If there was a connection, send data to login server
        If checkConn = True Then
            'Creates the string to be sent to the server, and starts the connection
            Dim concat As Byte() = System.Text.Encoding.ASCII.GetBytes(userBox.Text)
            Dim returndata As String = LServerRequest("forgot", concat)

            'If the connection failed display a message box and enable buttons
            If returndata = "error" Then
                'Enable buttons when finished
                EnableButtons(Me)
                MessageBox.Show("Error: Server side error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                'Checks data to see if the server reply was positive
                If returndata = "SENTT" Then
                    forgotLbl.Left = 110
                    forgotLbl.Text = "Sent!"
                ElseIf returndata = "FAILT" Then
                    forgotLbl.Left = 5
                    forgotLbl.Text = "Couldn't send, try Again."
                ElseIf returndata = "DENYT" Then
                    forgotLbl.Left = 45
                    forgotLbl.Text = "No Such User."
                End If
                EnableButtons(Me)
            End If
        Else
            'Enable buttons when finished
            EnableButtons(Me)
            GC.Collect()
            MessageBox.Show("Error: No connection to server" & vbNewLine & "Passwords don't match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub userBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles userBox.KeyDown
        Try
            'If user presses enter, send info to server
            If e.KeyValue = Keys.Enter Then
                e.SuppressKeyPress = True
                e.Handled = True
                forgotBtn.PerformClick()
            End If
        Catch ex As Exception 'If given error display it
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class