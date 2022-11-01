Imports System.Data.SqlClient

Public Class frmCustomer
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.CUSTOMERS' table. You can move, or remove it, as needed.
        Me.CUSTOMERSTableAdapter.Fill(Me.DataSet1.CUSTOMERS)
    End Sub

    Private Sub tblCustomers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblCustomers.CellClick
        'When a row is click the text boxes will fill with selcted details
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = tblCustomers.Rows(index)
        txtCust_id.Text = selectedRow.Cells(0).Value.ToString()
        txtFirst_name.Text = selectedRow.Cells(1).Value.ToString()
        txtSurname.Text = selectedRow.Cells(2).Value.ToString()
        txtAddress.Text = selectedRow.Cells(3).Value.ToString()
        txtTown.Text = selectedRow.Cells(4).Value.ToString()
        txtPostocde.Text = selectedRow.Cells(5).Value.ToString()
        txtEmail_add.Text = selectedRow.Cells(6).Value.ToString()
        txtPhone_no.Text = selectedRow.Cells(7).Value.ToString()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'Add button set to add new row with data in text boxe
        Dim newRow As DataRow = DataSet1.Tables(0).NewRow
        newRow.Item(0) = txtCust_id.Text
        newRow.Item(1) = txtFirst_name.Text
        newRow.Item(2) = txtSurname.Text
        newRow.Item(3) = txtAddress.Text
        newRow.Item(4) = txtTown.Text
        newRow.Item(5) = txtPostocde.Text
        newRow.Item(6) = txtEmail_add.Text
        newRow.Item(7) = txtPhone_no.Text
        DataSet1.Tables(0).Rows.Add(newRow)
        DataSet1.Tables(0).AcceptChanges()
        Me.CUSTOMERSTableAdapter.Insert(txtCust_id.Text, txtFirst_name.Text, txtSurname.Text,
                                        txtAddress.Text, txtTown.Text, txtPostocde.Text, txtEmail_add.Text,
                                        txtPhone_no.Text)
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'Update button set to replace data of selected row in table with that in text boxes
        Dim row As DataRow = DataSet1.Tables(0).Rows(tblCustomers.SelectedRows(0).Index)
        CUSTOMERSTableAdapter.Update(txtFirst_name.Text, txtSurname.Text,
                                        txtAddress.Text, txtTown.Text, txtPostocde.Text, txtEmail_add.Text,
                                        txtPhone_no.Text, row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7))
        CUSTOMERSTableAdapter.Update(DataSet1)
        Me.CUSTOMERSTableAdapter.Fill(Me.DataSet1.CUSTOMERS)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'button set to delete contents of a full row
        Dim index As Integer
        index = tblCustomers.CurrentCell.RowIndex
        tblCustomers.Rows.RemoveAt(index)
        Me.CUSTOMERSTableAdapter.Update(CUSTOMERSBindingSource.DataSource)
        CUSTOMERSTableAdapter.Update(DataSet1)
    End Sub

    Private Sub btnQuote_Click(sender As Object, e As EventArgs) Handles btnQuote.Click
        'Button set to navigate to quote form
        frmQuote.Show()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'Button set to close only current form
        Close()
    End Sub

End Class