Public Class frmPayments
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet4.PAYMENTS' table. You can move, or remove it, as needed.
        Me.PAYMENTSTableAdapter.Fill(Me.DataSet4.PAYMENTS)

    End Sub

    Private Sub tblPayments_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblPayments.CellClick
        'When a row is click the text boxes will fill with selcted details
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = tblPayments.Rows(index)
        If Not IsDBNull(selectedRow.Cells(0).Value) Then
            dtpPaymentDate.Value = selectedRow.Cells(0).Value
        End If
        txtQuote_id.Text = selectedRow.Cells(1).Value.ToString()
        txtAmount.Text = selectedRow.Cells(2).Value.ToString()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Add button set to add new row with data in text boxes/date time picker box
        Dim newRow As DataRow = DataSet4.Tables(0).NewRow
        newRow.Item(0) = dtpPaymentDate.Value
        newRow.Item(1) = txtQuote_id.Text
        newRow.Item(2) = txtAmount.Text
        DataSet4.Tables(0).Rows.Add(newRow)
        DataSet4.Tables(0).AcceptChanges()
        Me.PAYMENTSTableAdapter.Insert(dtpPaymentDate.Value, txtQuote_id.Text, txtAmount.Text)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'Update button set to replace data of selected row in table with that in text boxes/date time picker box
        Dim row As DataRow = DataSet4.Tables(0).Rows(tblPayments.SelectedRows(0).Index)
        PAYMENTSTableAdapter.Update(dtpPaymentDate.Value, txtQuote_id.Text, txtAmount.Text,
                                 row(0), row(1), row(2))
        PAYMENTSTableAdapter.Update(DataSet4)
        Me.PAYMENTSTableAdapter.Fill(Me.DataSet4.PAYMENTS)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'button set to delete contents of a full row
        Dim index As Integer
        index = tblPayments.CurrentCell.RowIndex
        tblPayments.Rows.RemoveAt(index)
        Me.PAYMENTSTableAdapter.Update(PAYMENTSBindingSource.DataSource)
        PAYMENTSTableAdapter.Update(DataSet4)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'Button set to close only current form
        Close()
    End Sub
End Class