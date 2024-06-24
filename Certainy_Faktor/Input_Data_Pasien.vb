Imports System.Data.Odbc

Public Class Input_Data_Pasien

    Sub kondisi_awal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Call koneksi()
        Cmd = New OdbcCommand("Select * From tabel_pasien where Kode_Pasien='" & TextBox1.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()

        If Not Rd.HasRows Then
            MsgBox("Kode Tidak Ditemukan")
        Else
            TextBox1.Text = Rd.Item("Kode_Pasien")
            TextBox2.Text = Rd.Item("Nama_Pasien")
            TextBox3.Text = Rd.Item("Alamat")
            TextBox4.Text = Rd.Item("Nomor_HP")
            TextBox5.Text = Rd.Item("Umur")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call koneksi()
        Dim Input_Data As String = "insert into tabel_pasien values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
        Cmd = New OdbcCommand(Input_Data, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Input Data Berhasil")
        Call kondisi_awal()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call kondisi_awal()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Menu_User.Show()
        Me.Hide()
    End Sub
End Class