Imports System.IO

Public Class settingsForm
    Private Sub settingsForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'Removes unnecessary data in RAM and closes the form correctly.
        CloseAndFree(Me)
    End Sub

    Private Sub saveBtn_Click(sender As Object, e As EventArgs) Handles saveBtn.Click

        'Gets the path of where to save the file to
        Dim path As String = "configs/colours"

        'Checks if the file exists, otherwise creates it.
        If Not System.IO.File.Exists(path) = True Then
            Dim f As System.IO.FileStream
            f = System.IO.File.Create(path)
            f.Close()
        End If

        'Used to see if each box is filled
        Dim count As Integer = 0

        'Loops through each element / control
        For Each c As Control In Me.Controls
            'If a textbox then
            If TypeOf c Is TextBox Then
                'Get the text in the box
                Dim txt = c.Text
                'And replace all the spaces with nothing
                Dim temp As String = txt.Replace(" ", "")

                'If the last box on the settings tab
                If c.Name = "fontBox" Then
                    'And is an integer
                    If temp.ToUpper = temp.ToLower Then
                        'Check that the box is filled
                        count += 1
                    End If

                    'otherwise check if it is not empty
                ElseIf temp <> "" Or txt <> Nothing Then
                    'And they are only integers and punctuation
                    If temp.ToUpper = temp.ToLower Then
                        'Check they are filled
                        count += 1
                    End If
                End If
            End If
        Next

        'If all filled
        If count = 5 Then

            'Write to the fille
            Using writer As StreamWriter = New StreamWriter(path, False)
                Text = Text.Trim(vbCr, vbLf)
                writer.WriteLine(backBox.Text & " " & foregroundBox.Text & " " & textCBox.Text & " " & nickBox.Text & " " & fontBox.Text)
            End Using

            'And change the theme
            changeColours(ircForm)
        Else
            'Otherwise report an error
            MsgBox("Please fill out each section correctly")
        End If

        'Reset the count
        count = 0

        'And close the form
        Me.Close()
    End Sub

    Private Sub settingsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        backBox.TabIndex = 0
        foregroundBox.TabIndex = 1
        textCBox.TabIndex = 2
        nickBox.TabIndex = 3
        fontBox.TabIndex = 4
        saveBtn.TabIndex = 5
    End Sub
End Class