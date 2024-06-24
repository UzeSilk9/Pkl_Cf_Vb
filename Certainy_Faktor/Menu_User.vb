Public Class Menu_User

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        Dim result As MsgBoxResult = MsgBox("Apakah anda ingin keluar?", MsgBoxStyle.Critical + vbYesNo, "Keluar")
        If result = MsgBoxResult.Ok Or result = MsgBoxResult.Yes Then
            Login.Show()
            Login.TextBox1.Clear()
            Login.TextBox2.Clear()
            Login.TextBox1.Focus()
            Me.Hide()
        End If
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Diagnosa.Show()
        Me.Hide()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Input_Data_Pasien.Show()
        Me.Hide()
    End Sub
End Class