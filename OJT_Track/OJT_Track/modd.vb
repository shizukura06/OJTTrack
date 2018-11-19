Module modd
    Public konek As OleDb.OleDbConnection
    Public adapt As OleDb.OleDbDataAdapter
    Public ds As New DataSet
    Public asd As ds1TableAdapters.UsersTableAdapter

    Sub connect()
        konek = New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Steven Dale Lucero\HomeLand\OJT_Track\OJT_Track\ttrak.db.mdb;Persist Security Info=False;")
        konek.Open()

    End Sub
End Module
