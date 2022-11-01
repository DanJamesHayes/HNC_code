Public Class frmStart
    'Itialise login as false and disable buttons until true
    Dim loginCorrect = False
    Public Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'If statement to check login details and give message dependent on correct or incorrect details
        If txtUsername.Text = "DJMHayes" And txtPassword.Text = "12345" Then
            MsgBox("Login Succecsful")
            txtUsername.Text = ""
            txtPassword.Text = ""
            loginCorrect = True
        Else
            MsgBox("Username or Password incorrect")
            txtUsername.Text = ""
            txtPassword.Text = ""
        End If
    End Sub
    'Button to show each form and one to quit the application.
    Private Sub btnCustomer_Click(sender As Object, e As EventArgs) Handles btnCustomer.Click
        If loginCorrect = True Then
            frmCustomer.Show()
        End If
    End Sub

    Private Sub btnQuote_Click(sender As Object, e As EventArgs) Handles btnQuote.Click
        If loginCorrect = True Then
            frmQuote.Show()
        End If
    End Sub

    Private Sub btnParts_Click(sender As Object, e As EventArgs) Handles btnParts.Click
        If loginCorrect = True Then
            frmParts.Show()
        End If
    End Sub

    Private Sub btnPayments_Click(sender As Object, e As EventArgs) Handles btnPayments.Click
        If loginCorrect = True Then
            frmPayments.Show()
        End If
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        End
    End Sub
    'Button to show quote detail query results
    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If loginCorrect = True Then
            frmQuotedetail.Show()
        End If
    End Sub

End Class
