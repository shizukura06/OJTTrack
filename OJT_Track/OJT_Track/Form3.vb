Public Class Form3
    Dim usr As Integer
    Dim i As Integer
    Dim mon As Integer
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        usr = Form1.logg
        modd.connect()
        ds.Clear()
        adapt = New OleDb.OleDbDataAdapter("Select timez" + usr.ToString + " from Timez", konek)
        adapt.Fill(ds, "Timez")
        gru.Refresh()
        gru.DataSource = ds.Tables("Timez")
        i = 0
        While i <> gru.Rows.Count - 1

            Try
                mon = DateAndTime.Month(gru.Item(0, i).Value)
            Catch ex As Exception

            End Try

            If ListView1.Text.ToString.Contains("December") And mon = 12 Then
                ListView1.Text = ListView1.Text & (gru.Item(0, i).Value.ToString) & vbCrLf
                i += 1
            ElseIf ListView1.Text.ToString.Contains("November") And mon = 11 Then
                ListView1.Text = ListView1.Text & (gru.Item(0, i).Value.ToString) & vbCrLf
                i += 1

            ElseIf ListView1.Text.ToString.Contains("October") And mon = 10 Then
                ListView1.Text = ListView1.Text & (gru.Item(0, i).Value.ToString) & vbCrLf
                i += 1

            ElseIf ListView1.Text.ToString.Contains("September") And mon = 9 Then
                ListView1.Text = ListView1.Text & (gru.Item(0, i).Value.ToString) & vbCrLf
                i += 1

            ElseIf ListView1.Text.ToString.Contains("August") And mon = 8 Then
                ListView1.Text = ListView1.Text & (gru.Item(0, i).Value.ToString) & vbCrLf
                i += 1

            ElseIf ListView1.Text.ToString.Contains("July") And mon = 7 Then
                ListView1.Text = ListView1.Text & (gru.Item(0, i).Value.ToString) & vbCrLf
                i += 1

            ElseIf ListView1.Text.ToString.Contains("June") And mon = 6 Then
                ListView1.Text = ListView1.Text & (gru.Item(0, i).Value.ToString) & vbCrLf
                i += 1

            ElseIf ListView1.Text.ToString.Contains("May") And mon = 5 Then
                ListView1.Text = ListView1.Text & (gru.Item(0, i).Value.ToString) & vbCrLf
                i += 1

            ElseIf ListView1.Text.ToString.Contains("April") And mon = 4 Then
                ListView1.Text = ListView1.Text & (gru.Item(0, i).Value.ToString) & vbCrLf
                i += 1

            ElseIf ListView1.Text.ToString.Contains("March") And mon = 3 Then
                ListView1.Text = ListView1.Text & (gru.Item(0, i).Value.ToString) & vbCrLf
                i += 1

            ElseIf ListView1.Text.ToString.Contains("February") And mon = 2 Then
                ListView1.Text = ListView1.Text & (gru.Item(0, i).Value.ToString) & vbCrLf
                i += 1

            ElseIf ListView1.Text.ToString.Contains("January") And mon = 1 Then
                ListView1.Text = ListView1.Text & (gru.Item(0, i).Value.ToString) & vbCrLf
                i += 1

            Else

                Select Case DateAndTime.Month(gru.Item(0, i).Value)
                    Case 1
                        ListView1.Text = ListView1.Text + (vbCrLf + "========January=======" + vbCrLf)
                    Case 2
                        ListView1.Text = ListView1.Text + (vbCrLf + "========February=======" + vbCrLf)
                    Case 3
                        ListView1.Text = ListView1.Text + (vbCrLf + "========March=======" + vbCrLf)
                    Case 4
                        ListView1.Text = ListView1.Text + (vbCrLf + "========April=======" + vbCrLf)
                    Case 5
                        ListView1.Text = ListView1.Text + (vbCrLf + "========May=======" + vbCrLf)
                    Case 6
                        ListView1.Text = ListView1.Text + (vbCrLf + "========June=======" + vbCrLf)
                    Case 7
                        ListView1.Text = ListView1.Text + (vbCrLf + "========July=======" + vbCrLf)
                    Case 8
                        ListView1.Text = ListView1.Text + (vbCrLf + "========August=======" + vbCrLf)
                    Case 9
                        ListView1.Text = ListView1.Text + (vbCrLf + "========September=======" + vbCrLf)
                    Case 10
                        ListView1.Text = ListView1.Text + (vbCrLf + "========October=======" + vbCrLf)
                    Case 11
                        ListView1.Text = ListView1.Text + (vbCrLf + "========November=======" + vbCrLf)
                    Case 12
                        ListView1.Text = ListView1.Text + (vbCrLf + "========December=======" + vbCrLf)
                End Select

                i += 1
            End If
            ListView1.DeselectAll()
        End While
        ListView1.Refresh()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub
End Class