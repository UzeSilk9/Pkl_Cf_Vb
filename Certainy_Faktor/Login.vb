Imports System.Data.Odbc

Public Class Login

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Pakar")
        ComboBox1.Items.Add("User")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (ComboBox1.Text = "Pakar") Then
            Call koneksi()
            Cmd = New OdbcCommand("SELECT * FROM tabel_user where Username ='" & TextBox1.Text & "'and Password ='" & TextBox2.Text & "'and Level = '" & ComboBox1.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()

            If Not Rd.HasRows Then
                MsgBox("Login Gagal!! Cek Username Dan Password")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox1.Focus()
            Else
                Me.Visible = False
                MsgBox("Selamat Datang '" & TextBox1.Text & "'")
                Menu_Pakar.Show()
                Me.Hide()
            End If
        ElseIf (ComboBox1.Text = "User") Then
            Call koneksi()
            Cmd = New OdbcCommand("SELECT * FROM tabel_user where Username ='" & TextBox1.Text & "'and Password ='" & TextBox2.Text & "'and Level = '" & ComboBox1.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()

            If Not Rd.HasRows Then
                MsgBox("Login Gagal!! Cek Username Dan Password")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox1.Focus()
            Else
                Me.Visible = False
                MsgBox("Selamat Datang '" & TextBox1.Text & "'")
                Menu_User.Show()
                Me.Hide()
            End If
        End If
    End Sub
End Class
