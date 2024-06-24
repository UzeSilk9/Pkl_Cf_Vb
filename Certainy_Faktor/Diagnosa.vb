Imports System.Data.Odbc

Public Class Diagnosa

    Sub kondisi_awal()
        Call AutoNumber()
        Call AutoNumber_Pasien()
        Call Tampil_tabel()
        Call koneksi()
        Cmd = New OdbcCommand("select Kode_Gejala from tabel_gejala", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            ComboBox1.Items.Add(Rd.Item("Kode_Gejala"))
        Loop

        ComboBox2.Items.Add("Tidak")
        ComboBox2.Items.Add("Tidak Tau")
        ComboBox2.Items.Add("Mungkin")
        ComboBox2.Items.Add("Cukup Yakin")
        ComboBox2.Items.Add("Yakin")
        ComboBox2.Items.Add("Sangat Yakin")

        Call koneksi()
        Cmd = New OdbcCommand("select Kode_Pasien from tabel_pasien", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            ComboBox3.Items.Add(Rd.Item("Kode_Pasien"))
        Loop
    End Sub

    Sub Clear_Data()
        ComboBox1.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        ComboBox2.Text = ""
        TextBox4.Text = ""
        TextBox2.Text = ""
        ComboBox3.Text = ""
        TextBox7.Text = ""
        TextBox6.Text = ""
    End Sub

    Sub Tampil_tabel()
        Call koneksi()
        Da = New OdbcDataAdapter("select Nomor,Nama_Gejala,Nilai_Pakar,Nilai_User from tabel_diagnosa", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tabel_diagnosa")
        DataGridView1.DataSource = Ds.Tables("tabel_diagnosa")
        DataGridView1.ReadOnly = True
    End Sub

    Sub AutoNumber()
        Call koneksi()
        Cmd = New OdbcCommand("Select * From tabel_diagnosa where Nomor in (select max(Nomor) from tabel_diagnosa)", Conn)
        Dim Urutan As String
        Dim Hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            Urutan = "DGS" + "001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            If Hitung > 9 Then
                Hitung = 1
            End If
            Urutan = "DGS" + Microsoft.VisualBasic.Right("000" & Hitung, 3)
        End If
        TextBox1.Text = Urutan
    End Sub

    Sub AutoNumber_Pasien()
        Call koneksi()
        Cmd = New OdbcCommand("Select * From tabel_hasil_diagnosa where Kode_Pemeriksaan in (select max(Kode_Pemeriksaan) from tabel_hasil_diagnosa)", Conn)
        Dim Urutan As String
        Dim Hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            Urutan = "LAP" + "001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            Urutan = "LAP" + Microsoft.VisualBasic.Right("000" & Hitung, 3)
        End If
        TextBox8.Text = Urutan
    End Sub

    Private Sub Diagnosa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisi_awal()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call koneksi()
        Cmd = New OdbcCommand("select Nama_Gejala from tabel_gejala where Kode_Gejala='" & ComboBox1.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            TextBox3.Text = Rd.Item("Nama_Gejala")
        Loop

        Call koneksi()
        Cmd = New OdbcCommand("select Nilai_CF from basis_pengetahuan where Kode_Gejala='" & ComboBox1.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            TextBox5.Text = Rd.Item("Nilai_CF")
        Loop
    End Sub

    Private Sub Button6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button6.Click
        Dim Nilai As String
        Dim Nilai_CF As String
        Dim Hasil As String = "" ' Initialize with an empty string

        Nilai_CF = TextBox5.Text

        ' Replace comma with dot to handle both cases
        Nilai_CF = Nilai_CF.Replace(",", ".")

        ' Check Nilai_CF and set Hasil
        Select Case Nilai_CF
            Case "0.1"
                Hasil = "0.1"
            Case "0.2"
                Hasil = "0.2"
            Case "0.3"
                Hasil = "0.3"
            Case "0.4"
                Hasil = "0.4"
            Case "0.5"
                Hasil = "0.5"
            Case "0.6"
                Hasil = "0.6"
            Case "0.7"
                Hasil = "0.7"
            Case "0.8"
                Hasil = "0.8"
            Case "0.9"
                Hasil = "0.9"
            Case "1"
                Hasil = "1"
            Case Else
                MessageBox.Show("Nilai CF tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        ' Check ComboBox2 text and set Nilai
        Select Case ComboBox2.Text
            Case "Tidak"
                Nilai = "0"
            Case "Tidak Tau"
                Nilai = "0.2"
            Case "Mungkin"
                Nilai = "0.4"
            Case "Cukup Yakin"
                Nilai = "0.6"
            Case "Yakin"
                Nilai = "0.8"
            Case "Sangat Yakin"
                Nilai = "1"
            Case Else
                MessageBox.Show("Nilai kepercayaan tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        ' Insert data into the database
        Call koneksi()
        Dim Input_Data As String = "INSERT INTO tabel_diagnosa VALUES ('" & TextBox1.Text & "','" & TextBox3.Text & "','" & Hasil & "','" & Nilai & "')"
        Cmd = New OdbcCommand(Input_Data, Conn)
        Cmd.ExecuteNonQuery()
        Call AutoNumber()
        Call Tampil_tabel()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rowcount As Integer
        rowcount = DataGridView1.Rows.Count()

        If rowcount < 9 Then
            MsgBox("Gejala Yang Anda Input Kurang")
        ElseIf rowcount > 10 Then
            MsgBox("Gejala Yang Anda Input Berlebih")
        Else
            Call koneksi()
            Cmd = New OdbcCommand("Select Nilai_Pakar,Nilai_User From tabel_diagnosa where Nomor='DGS001'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()

            Dim Nilai_Pakar_CF1 As Double = Rd.Item("Nilai_Pakar")
            Dim Nilai_User_CF1 As Double = Rd.Item("Nilai_User")

            Dim Hasil_CF1 As Double = Nilai_Pakar_CF1 * Nilai_User_CF1
            Dim CF1 As Double = 0 + (Hasil_CF1 * (1 - 0))

            Cmd = New OdbcCommand("Select Nilai_Pakar,Nilai_User From tabel_diagnosa where Nomor='DGS002'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()

            Dim Nilai_Pakar_CF2 As Double = Rd.Item("Nilai_Pakar")
            Dim Nilai_User_CF2 As Double = Rd.Item("Nilai_User")

            Dim Hasil_CF2 As Double = Nilai_Pakar_CF2 * Nilai_User_CF2
            Dim CF2 As Double = Hasil_CF1 + (Hasil_CF2 * (1 - Hasil_CF1))

            Cmd = New OdbcCommand("Select Nilai_Pakar,Nilai_User From tabel_diagnosa where Nomor='DGS003'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()

            Dim Nilai_Pakar_CF3 As Double = Rd.Item("Nilai_Pakar")
            Dim Nilai_User_CF3 As Double = Rd.Item("Nilai_User")

            Dim Hasil_CF3 As Double = Nilai_Pakar_CF3 * Nilai_User_CF3
            Dim CF3 As Double = Hasil_CF2 + (Hasil_CF3 * (1 - Hasil_CF2))

            Cmd = New OdbcCommand("Select Nilai_Pakar,Nilai_User From tabel_diagnosa where Nomor='DGS004'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()

            Dim Nilai_Pakar_CF4 As Double = Rd.Item("Nilai_Pakar")
            Dim Nilai_User_CF4 As Double = Rd.Item("Nilai_User")

            Dim Hasil_CF4 As Double = Nilai_Pakar_CF4 * Nilai_User_CF4
            Dim CF4 As Double = Hasil_CF3 + (Hasil_CF4 * (1 - Hasil_CF3))

            Cmd = New OdbcCommand("Select Nilai_Pakar,Nilai_User From tabel_diagnosa where Nomor='DGS005'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()

            Dim Nilai_Pakar_CF5 As Double = Rd.Item("Nilai_Pakar")
            Dim Nilai_User_CF5 As Double = Rd.Item("Nilai_User")

            Dim Hasil_CF5 As Double = Nilai_Pakar_CF5 * Nilai_User_CF5
            Dim CF5 As Double = Hasil_CF4 + (Hasil_CF5 * (1 - Hasil_CF4))

            Cmd = New OdbcCommand("Select Nilai_Pakar,Nilai_User From tabel_diagnosa where Nomor='DGS006'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()

            Dim Nilai_Pakar_CF6 As Double = Rd.Item("Nilai_Pakar")
            Dim Nilai_User_CF6 As Double = Rd.Item("Nilai_User")

            Dim Hasil_CF6 As Double = Nilai_Pakar_CF6 * Nilai_User_CF6
            Dim CF6 As Double = Hasil_CF5 + (Hasil_CF6 * (1 - Hasil_CF5))

            Cmd = New OdbcCommand("Select Nilai_Pakar,Nilai_User From tabel_diagnosa where Nomor='DGS007'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()

            Dim Nilai_Pakar_CF7 As Double = Rd.Item("Nilai_Pakar")
            Dim Nilai_User_CF7 As Double = Rd.Item("Nilai_User")

            Dim Hasil_CF7 As Double = Nilai_Pakar_CF7 * Nilai_User_CF7
            Dim CF7 As Double = Hasil_CF6 + (Hasil_CF7 * (1 - Hasil_CF6))

            Cmd = New OdbcCommand("Select Nilai_Pakar,Nilai_User From tabel_diagnosa where Nomor='DGS008'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()

            Dim Nilai_Pakar_CF8 As Double = Rd.Item("Nilai_Pakar")
            Dim Nilai_User_CF8 As Double = Rd.Item("Nilai_User")

            Dim Hasil_CF8 As Double = Nilai_Pakar_CF8 * Nilai_User_CF8
            Dim CF8 As Double = Hasil_CF7 + (Hasil_CF8 * (1 - Hasil_CF7))

            Cmd = New OdbcCommand("Select Nilai_Pakar,Nilai_User From tabel_diagnosa where Nomor='DGS009'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()

            Dim Nilai_Pakar_CF9 As Double = Rd.Item("Nilai_Pakar")
            Dim Nilai_User_CF9 As Double = Rd.Item("Nilai_User")

            Dim Hasil_CF9 As Double = Nilai_Pakar_CF9 * Nilai_User_CF9
            Dim CF9 As Double = Hasil_CF8 + (Hasil_CF9 * (1 - Hasil_CF8))

            TextBox2.Text = CF9
            Dim Persen As Double = CF9 * 100
            TextBox9.Text = Persen
            TextBox4.Text = "Diabetes Melitus type I dan II"
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Call koneksi()
        Cmd = New OdbcCommand("select Nama_Pasien,Nomor_HP from tabel_pasien where Kode_Pasien='" & ComboBox3.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            TextBox7.Text = Rd.Item("Nama_Pasien")
            TextBox6.Text = Rd.Item("Nomor_HP")
        Loop
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call koneksi()
        Dim Input_Data As String = "insert into tabel_hasil_diagnosa values ('" & TextBox8.Text & "','" & ComboBox3.Text & "','" & TextBox7.Text & "','" & TextBox6.Text & "','" & TextBox4.Text & "','" & TextBox2.Text & "')"
        Cmd = New OdbcCommand(Input_Data, Conn)
        Cmd.ExecuteNonQuery()

        Call koneksi()
        Dim Hapus_Data As String = "TRUNCATE tabel_diagnosa "
        Cmd = New OdbcCommand(Hapus_Data, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Input Data Berhasil")
        Call AutoNumber_Pasien()
        Call Clear_Data()
        Call Tampil_tabel()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Menu_User.Show()
        Me.Hide()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class