Imports System.Data.Odbc

Module Module1
    Public Conn As New OdbcConnection
    Public Da As New OdbcDataAdapter
    Public Ds As New DataSet
    Public Rd As OdbcDataReader
    Public Cmd As New OdbcCommand
    Public MyDB As String
    Public Sub koneksi()
        MyDB = "Driver={Mysql ODBC 3.51 driver};Database=db_certainty;server=localhost;uid=root"
        Conn = New OdbcConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub
End Module
