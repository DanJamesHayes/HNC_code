Public Class frmQuote
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet2.QUOTE' table. You can move, or remove it, as needed.
        Me.QUOTETableAdapter.Fill(Me.DataSet2.QUOTE)
    End Sub

    Private Sub tblQuote_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblQuote.CellClick
        'When a row is click the text boxes will fill with selcted details
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = tblQuote.Rows(index)
        txtQuote_ID.Text = selectedRow.Cells(0).Value.ToString()
        txtCust_ID.Text = selectedRow.Cells(1).Value.ToString()
        dtpQuoteDate.Value = selectedRow.Cells(2).Value.ToString()
        txtWork_loc.Text = selectedRow.Cells(3).Value.ToString()
        'If statement to remove DBNull error
        If Not IsDBNull(selectedRow.Cells(4).Value) Then
            dtpEstimatedStartDate.Value = selectedRow.Cells(4).Value
        End If

        txtSub_total.Text = selectedRow.Cells(5).Value.ToString()
        txtTotal.Text = selectedRow.Cells(6).Value.ToString()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Add button set to add new row with data in text boxes/date time picker boxes
        Dim newRow As DataRow = DataSet2.Tables(0).NewRow
        newRow.Item(0) = txtQuote_ID.Text
        newRow.Item(1) = txtCust_ID.Text
        newRow.Item(2) = dtpQuoteDate.Value
        newRow.Item(3) = txtWork_loc.Text
        newRow.Item(4) = dtpEstimatedStartDate.Value
        newRow.Item(5) = txtSub_total.Text
        newRow.Item(6) = txtTotal.Text
        DataSet2.Tables(0).Rows.Add(newRow)
        DataSet2.Tables(0).AcceptChanges()
        Me.QUOTETableAdapter.Insert(txtQuote_ID.Text, txtCust_ID.Text,
                                       dtpQuoteDate.Value, txtWork_loc.Text, dtpEstimatedStartDate.Value, txtSub_total.Text, txtTotal.Text)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim strError As String = String.Empty
        'Update button set to replace data of selected row in table with that in text boxes/date time picker boxes
        'If statements to remove errors from empty fields
        Dim total As Decimal = 0
        Dim subtotal As Decimal = 0
        If txtSub_total.Text.Length = 0 Then
            txtSub_total.Text = "0"
        End If
        If txtTotal.Text.Length = 0 Then
            txtTotal.Text = "0"
        End If
        If Not IsNumeric(txtTotal.Text) Then
            strError = " invalid total" & vbCrLf
        Else
            total = CType(txtTotal.Text, Decimal)
        End If
        If Not IsNumeric(txtSub_total.Text) Then
            strError = " invalid sub-total" & vbCrLf
        Else
            subtotal = CType(txtSub_total.Text, Decimal)
        End If
        If strError.Length > 0 Then
            MsgBox(strError, MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If
        Dim original_work_loc As String = String.Empty
        Dim row As DataRow = DataSet2.Tables(0).Rows(tblQuote.SelectedRows(0).Index)
        If IsDBNull(row(3)) Then
            original_work_loc = ""
        Else
            original_work_loc = row(3)
        End If
        QUOTETableAdapter.Update(txtCust_ID.Text, dtpQuoteDate.Value, txtWork_loc.Text, dtpEstimatedStartDate.Value, subtotal, total,
                                 row(0), row(1), row(2), original_work_loc, row(4), row.Item("SUB_TOTAL"), row.Item("TOTAL"))
        Me.QUOTETableAdapter.Fill(Me.DataSet2.QUOTE)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'button set to delete contents of a full row
        Dim index As Integer
        index = tblQuote.CurrentCell.RowIndex
        tblQuote.Rows.RemoveAt(index)
        Me.QUOTETableAdapter.Update(QUOTEBindingSource.DataSource)
        QUOTETableAdapter.Update(DataSet2)
    End Sub
    'Buttons to navigate to parts or payment table
    Private Sub btnParts_Click(sender As Object, e As EventArgs) Handles btnParts.Click
        frmParts.Show()
    End Sub

    Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click
        frmPayments.Show()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'Button set to close only current form
        Close()
    End Sub

End Class