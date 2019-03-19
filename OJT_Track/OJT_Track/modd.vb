Module modd
    Public konek As OleDb.OleDbConnection
    Public adapt As OleDb.OleDbDataAdapter
    Public ds As New DataSet

    Sub connect()
        konek = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=ttrak.db.mdb;Persist Security Info=False;")
        konek.Open()

    End Sub
End Module
