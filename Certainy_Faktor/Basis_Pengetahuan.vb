Imports System.Data.Odbc

Public Class Basis_Pengetahuan

    Sub kondisi_awal()
        TextBox1.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox3.Text = ""
        ComboBox1.Text = ""
        ComboBox2.Text = ""

        Call koneksi()
        Da = New OdbcDataAdapter("select Kode_Basis,Kode_Penyakit,Kode_Gejala,Nilai_CF from basis_pengetahuan", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "basis_pengetahuan")
        DataGridView1.DataSource = Ds.Tables("basis_pengetahuan")
        DataGridView1.ReadOnly = True
    End Sub

    Sub tampil_penyakit()
        Call koneksi()
        Cmd = New OdbcCommand("Select Kode_Penyakit From tabel_penyakit", Conn)
        Rd = Cmd.ExecuteReader

        If Rd.HasRows Then
            Do While Rd.Read
                ComboBox1.Items.Add(Rd("Kode_Penyakit"))
            Loop
        Else
            ComboBox1.Text = "Tidak Ada Data"
        End If
    End Sub

    Sub tampil_gejala()
        Call koneksi()
        Cmd = New OdbcCommand("Select Kode_Gejala From tabel_gejala", Conn)
        Rd = Cmd.ExecuteReader

        If Rd.HasRows Then
            Do While Rd.Read
                ComboBox2.Items.Add(Rd("Kode_Gejala"))
            Loop
        Else
            ComboBox2.Text = "Tidak Ada Data"
        End If
    End Sub

    Sub penyakit()
        Call koneksi()
        Cmd = New OdbcCommand("Select * From tabel_penyakit where Kode_Penyakit='" & ComboBox1.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()

        If Not Rd.HasRows Then
            TextBox3.Text = "Tidak Ada Data"
        Else
            TextBox3.Text = Rd.Item("Nama_Penyakit")
        End If
    End Sub

    Sub gejala()
        Call koneksi()
        Cmd = New OdbcCommand("Select * From tabel_gejala where Kode_Gejala='" & ComboBox2.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()

        If Not Rd.HasRows Then
            TextBox4.Text = "Tidak Ada Data"
        Else
            TextBox4.Text = Rd.Item("Nama_Gejala")
        End If
    End Sub

    Private Sub Input_Rules_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Call kondisi_awal()
        Call tampil_penyakit()
        Call tampil_gejala()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call penyakit()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Call gejala()
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Call koneksi()
        Dim Input_Data As String = "insert into basis_pengetahuan values ('" & TextBox1.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & TextBox5.Text & "')"
        Cmd = New OdbcCommand(Input_Data, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Input Data Berhasil")
        Call kondisi_awal()
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click

        Call koneksi()
        Dim Update_Data As String = "update basis_pengetahuan set Kode_Basis='" & TextBox1.Text & "',Kode_Penyakit='" & ComboBox1.Text & "',Kode_Gejala='" & ComboBox2.Text & "',Nilai_CF='" & TextBox5.Text & "' where Kode_Basis='" & TextBox1.Text & "'"
        Cmd = New OdbcCommand(Update_Data, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Update Data Berhasil")
        Call kondisi_awal()
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        Call koneksi()
        Dim Delete_Data As String = "delete from basis_pengetahuan where Kode_Basis='" & TextBox1.Text & "'"
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