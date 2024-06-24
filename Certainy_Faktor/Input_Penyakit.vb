Imports System.Data.Odbc

Public Class Input_Penyakit

    Sub kondisi_awal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""

        Call koneksi()
        Da = New OdbcDataAdapter("select Kode_Penyakit,Nama_Penyakit,Solusi from tabel_penyakit", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tabel_penyakit")
        DataGridView1.DataSource = Ds.Tables("tabel_penyakit")
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub Input_Penyakit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisi_awal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call koneksi()
        Dim Input_Data As String = "insert into tabel_penyakit values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
        Cmd = New OdbcCommand(Input_Data, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Input Data Berhasil")
        Call kondisi_awal()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call koneksi()
        Dim Update_Data As String = "update tabel_penyakit set Kode_Penyakit='" & TextBox1.Text & "',Nama_Penyakit='" & TextBox2.Text & "',Solusi='" & TextBox3.Text & "' where Kode_Penyakit='" & TextBox1.Text & "'"
        Cmd = New OdbcCommand(Update_Data, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Update Data Berhasil")
        Call kondisi_awal()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Call koneksi()
        Cmd = New OdbcCommand("Select * From tabel_penyakit where Kode_Penyakit='" & TextBox1.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()

        If Not Rd.HasRows Then
            MsgBox("Kode Tidak Ditemukan")
        Else
            TextBox1.Text = Rd.Item("Kode_Penyakit")
            TextBox2.Text = Rd.Item("Nama_Penyakit")
            TextBox3.Text = Rd.Item("Solusi")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call koneksi()
        Dim Delete_Data As String = "delete from tabel_penyakit where Kode_Penyakit='" & TextBox1.Text & "'"
        Cmd = New OdbcCommand(Delete_Data, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Delete Data Berhasil")
        Call kondisi_awal()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Call kondisi_awal()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Menu_Pakar.Show()
        Me.Hide()
    End Sub
End Class