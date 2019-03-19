Public Class Form4

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or
            TextBox2.Text = "" Or
            TextBox3.Text = "" Or
            TextBox4.Text = "" Or
            TextBox5.Text = "" Or
            TextBox6.Text = "" Then
            MsgBox("Please fill all field!", MsgBoxStyle.Critical)
        ElseIf Integer.TryParse(TextBox5.Text, 0) = 0 Then
            MsgBox("Hours field is not in numerals!", MsgBoxStyle.Critical)
        ElseIf Date.TryParse(TextBox6.Text, "01/01/01") = 0 Then
            MsgBox("Started Date field is not valid!", MsgBoxStyle.Critical)
        Else

            adapt = New OleDb.OleDbDataAdapter("Insert into Users(userD, pass, fullname , course, hours, startD, hoursL) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "'," + TextBox5.Text + ",'" + TextBox6.Text + "'," + TextBox5.Text + ")", konek)
        'adapt = New OleDb.OleDbDataAdapter("Insert into Users (userD)  Values('" + TextBox1.Text + "')", konek)
        adapt.Fill(ds, "Users")
        MsgBox("Account is registered!", MsgBoxStyle.Information)
        Close()
        Form1.Show()
        End If
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        modd.connect()

    End Sub
End Class