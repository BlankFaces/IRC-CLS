Module global_module
    'Closes form and clears garbage (Frees RAM)
    Public Sub CloseAndFree(form)
        form.Dispose()
        form.Close()
        GC.Collect()
    End Sub

    'Removes hidden characters from string and returns
    Public Function RmHiddenChar(s As String)
        s = s.Replace(vbCrLf, "").Replace(vbLf, "").Replace(vbNullChar, "").Replace(vbCr, "")
        Return s
    End Function
End Module