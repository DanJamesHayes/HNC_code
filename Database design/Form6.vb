Public Class frmQuotedetail
    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet6.CUST_QUOTE_VIEW' table. You can move, or remove it, as needed.
        Me.CUST_QUOTE_VIEWTableAdapter.Fill(Me.DataSet6.CUST_QUOTE_VIEW)

    End Sub

    Private Sub btnCloseform_Click(sender As Object, e As EventArgs) Handles btnCloseform.Click
        Close()
    End Sub
End Class