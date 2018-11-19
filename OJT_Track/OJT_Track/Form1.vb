Public Class Form1
    Dim i As Integer
    Public logg As Integer
    Public Sub login()
        adapt = New OleDb.OleDbDataAdapter("SELECT * FROM Users where userD = '" + TextBox1.Text + "'", konek)
        adapt.Fill(ds, "Users")
        grid.DataSource = ds.Tables("Users")
        If grid.Item(0, 0).Value = vbNullString Then
            MsgBox("Invalid Username!", MsgBoxStyle.Exclamation)
        Else
            If TextBox2.Text <> grid.Item(2, 0).Value Then
                MsgBox("Invalid Password!", MsgBoxStyle.Exclamation)
            Else
                logg = grid.Item(0, 0).Value
                Form2.Show()
                Me.Hide()
            End If
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        modd.connect()
    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        login()
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyValue = 13 Then
            SendKeys.Send(vbBack)
            login()
            SendKeys.Send(vbBack)
        End If
    End Sub
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyValue = 13 Then
            SendKeys.Send(vbBack)
            login()
            SendKeys.Send(vbBack)
        End If
    End Sub

    Private Sub NewOJTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewOJTToolStripMenuItem.Click
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class
