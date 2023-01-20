Public Class MainScreen
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub EmployeeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeToolStripMenuItem.Click
        Dim efrm As New EmpFrm
        efrm.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Dim x As New Object
        x = MsgBox("Are You Sure to EXIT ...?", MsgBoxStyle.YesNo)
        If vbYes Then
            Application.Exit()
        Else
        End If

    End Sub
End Class