Public Class Menu_Pakar

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Dim result As MsgBoxResult = MsgBox("Apakah anda ingin keluar?", MsgBoxStyle.Critical + vbYesNo, "Keluar")
        If result = MsgBoxResult.Ok Or result = MsgBoxResult.Yes Then
            Login.Show()
            Login.TextBox1.Clear()
            Login.TextBox2.Clear()
            Login.TextBox1.Focus()
            Me.Hide()
        End If
    End Sub

    Private Sub InputGejalaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InputGejalaToolStripMenuItem.Click
        Input_Gejala.Show()
        Me.Hide()
    End Sub

    Private Sub InputPenyakitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InputPenyakitToolStripMenuItem.Click
        Input_Penyakit.Show()
        Me.Hide()
    End Sub

    Private Sub InputRoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InputRoleToolStripMenuItem.Click
        Basis_Pengetahuan.Show()
        Me.Hide()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class