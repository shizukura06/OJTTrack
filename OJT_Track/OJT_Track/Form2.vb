Public Class Form2
    Dim usr As Integer
    Dim strt, stp, strt1, many, logintime
    Dim prt As PrintControllerWithStatusDialog
    Dim aw As Drawing.Printing.PrintDocument

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Print(0)
        usr = Form1.logg
        modd.connect()
        adapt = New OleDb.OleDbDataAdapter("Select * from Users where ID = " & usr.ToString, konek)
        adapt.Fill(ds, "Users")
        gru.DataSource = ds.Tables("Users")
        'prt.OnStartPage(
        If gru.Item(9, 0).Value.ToString = "" Then
            ds.Clear()
            adapt = New OleDb.OleDbDataAdapter("Update Users set lastAD = '" + Date.Now + "' where ID = " & usr.ToString, konek)
            adapt.Fill(ds, "Users")
            ds.Clear()
            adapt = New OleDb.OleDbDataAdapter("Select * from Users where ID = " & usr.ToString, konek)
            adapt.Fill(ds, "Users")
            gru.DataSource = ds.Tables("Users")
        End If
        If Date.Now.Year - DateAndTime.Year(gru.Item(9, 0).Value) < 2 Then

            strt = Date.Now
            strt1 = strt
            Timer1.Start()
            logintime = TimeOfDay.ToShortTimeString
            Try
                ds.Clear()
                adapt = New OleDb.OleDbDataAdapter("Insert into Timez (timez" & usr.ToString & ") values('" & strt.ToString & "')", konek)
                adapt.Fill(ds, "Timez")
            Catch ex As Exception
                ds.Clear()
                adapt = New OleDb.OleDbDataAdapter("ALTER TABLE Timez Add timez" & usr.ToString & " Date", konek)
                adapt.Fill(ds, "Timez")
                ds.Clear()
                adapt = New OleDb.OleDbDataAdapter("Insert into Timez (timez" & usr.ToString & ") values('" & strt.ToString & "')", konek)
                adapt.Fill(ds, "Timez")
            End Try


            ds.Clear()
            adapt = New OleDb.OleDbDataAdapter("Select * from Users where ID = " & usr.ToString, konek)
            adapt.Fill(ds, "Users")
            gru.DataSource = ds.Tables("Users")
            Label6.Text = gru.Item(3, 0).Value
            Label7.Text = gru.Item(4, 0).Value
            Label8.Text = gru.Item(5, 0).Value
            Label15.Text = gru.Item(8, 0).Value
            Label16.Text = gru.Item(9, 0).Value
            many = gru.Item(6, 0).Value + 1
            Label24.Text = many.ToString + " Time/s"
            Label10.Text = gru.Item(7, 0).Value
            Label9.Text = Val(Label8.Text) - Val(Label10.Text)
            If Label17.Text = "0" Then
                Label17.Text = "(Gain hours first to compute)"
            End If
            Label17.Text = Val(Label10.Text) / 8 & " Days Left"
            adapt = New OleDb.OleDbDataAdapter("Update Users Set howmany = " + many.ToString + " where ID = " + usr.ToString, konek)
            adapt.Fill(ds, "Users")
            ds.Clear()
        Else
            MsgBox("Please configure time on your computer!", MsgBoxStyle.Critical)
            End
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If DateAndTime.Hour(stp) - DateAndTime.Hour(strt1) = 1 Then
            Timer1.Stop()
            adapt = New OleDb.OleDbDataAdapter("Select * from Users where ID = " & usr.ToString, konek)
            adapt.Fill(ds, "Users")
            gru.DataSource = ds.Tables("Users")
            Dim a = gru.Item(7, 0).Value - 1
            ds.Clear()
            adapt = New OleDb.OleDbDataAdapter("Update Users Set hoursL = " + a.ToString + " where ID = " + usr.ToString, konek)
            adapt.Fill(ds, "Users")
            ds.Clear()
            adapt = New OleDb.OleDbDataAdapter("Select * from Users where ID = " & usr.ToString, konek)
            adapt.Fill(ds, "Users")
            gru.DataSource = ds.Tables("Users")
            Label10.Text = gru.Item(7, 0).Value
            Label9.Text = Val(Label8.Text) - Val(Label10.Text)
            strt1 = Date.Now
            Timer1.Start()
        End If
        If DateAndTime.Hour(stp) - DateAndTime.Hour(strt) = 3.5 Then
            Timer1.Stop()
            Me.Show()
            MsgBox("Half hour left before turning completing 4 hours", MsgBoxStyle.Information)
            If MsgBoxResult.Ok Then
                Timer1.Start()
                TextBox1.Enabled = True
                TextBox2.Enabled = True
                TextBox3.Enabled = True
                Button4.Enabled = True
            End If
        End If
        If DateAndTime.Hour(stp) - DateAndTime.Hour(strt) = 4 Then
            Timer1.Stop()
            Me.Show()
            MsgBox("4 hours completed!", MsgBoxStyle.Information)
            If MsgBoxResult.Ok Then
                Timer1.Start()
                ds.Clear()
                adapt = New OleDb.OleDbDataAdapter("Update Users set lastAD ='" + strt + "' where ID = " & usr.ToString, konek)
                adapt.Fill(ds, "Users")
                End
            End If
        End If
        stp = Date.Now
        Label14.Text = "Date: " + stp
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("This function is soon to be done, please tell steven to finish this sooner :)")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form3.Show()
    End Sub
    Private Sub Button7_MouseHover(sender As Object, e As EventArgs) Handles Button7.MouseHover
        Label25.Visible = True
    End Sub

    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles Button7.MouseLeave
        Label25.Visible = False
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        Button4.Enabled = False
    End Sub
    Private Sub OnDestroy(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        Try
            Taposna()
        Catch ex As Exception
            Taposna()
        End Try

    End Sub
    Sub Taposna()
        End
    End Sub
End Class