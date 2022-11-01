Public Class frmParts
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet5.LINE_ITEM' table. You can move, or remove it, as needed.
        Me.LINE_ITEMTableAdapter.Fill(Me.DataSet5.LINE_ITEM)
        'TODO: This line of code loads data into the 'DataSet3.PARTS' table. You can move, or remove it, as needed.
        Me.PARTSTableAdapter.Fill(Me.DataSet3.PARTS)

    End Sub

    Private Sub tblParts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblParts.CellClick
        'When a row is click the text boxes will fill with selcted details
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = tblParts.Rows(index)
        txtItem_code1.Text = selectedRow.Cells(0).Value.ToString()
        txtDescription.Text = selectedRow.Cells(1).Value.ToString()
        txtPrice_net.Text = selectedRow.Cells(2).Value.ToString()
        txtPrice_gross.Text = selectedRow.Cells(3).Value.ToString()
    End Sub

    Private Sub tblLine_item_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblLine_item.CellClick
        'When a row is click the text boxes will fill with selcted details
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = tblLine_item.Rows(index)
        txtItem_code2.Text = selectedRow.Cells(0).Value.ToString()
        txt_Quote_id.Text = selectedRow.Cells(1).Value.ToString()
        txtQty.Text = selectedRow.Cells(2).Value.ToString()
    End Sub

    Private Sub btnAdd1_Click(sender As Object, e As EventArgs) Handles btnAdd1.Click
        'Add button set to add new row with data in text boxes
        Dim newRow As DataRow = DataSet3.Tables(0).NewRow
        newRow.Item(0) = txtItem_code1.Text
        newRow.Item(1) = txtDescription.Text
        newRow.Item(2) = txtPrice_net.Text
        newRow.Item(3) = txtPrice_gross.Text
        DataSet3.Tables(0).Rows.Add(newRow)
        DataSet3.Tables(0).AcceptChanges()
        Me.PARTSTableAdapter.Insert(txtItem_code1.Text, txtDescription.Text,
                                        txtPrice_net.Text, txtPrice_gross.Text)
    End Sub

    Private Sub btnUpdate1_Click(sender As Object, e As EventArgs) Handles btnUpdate1.Click
        'Update button set to replace data of selected row in table with that in text boxes
        Dim row As DataRow = DataSet3.Tables(0).Rows(tblParts.SelectedRows(0).Index)
        PARTSTableAdapter.Update(txtDescription.Text, txtPrice_net.Text,
                                        txtPrice_gross.Text, row(0), row(1), row(2), row(3))
        LINE_ITEMTableAdapter.Update(DataSet5)
        Me.LINE_ITEMTableAdapter.Fill(Me.DataSet5.LINE_ITEM)
    End Sub

    Private Sub btnDelete1_Click(sender As Object, e As EventArgs) Handles btnDelete1.Click
        'button set to delete contents of a full row
        Dim index As Integer
        index = tblParts.CurrentCell.RowIndex
        tblParts.Rows.RemoveAt(index)
        Me.PARTSTableAdapter.Update(PARTSBindingSource.DataSource)
        PARTSTableAdapter.Update(DataSet3)
    End Sub

    Private Sub btnAdd2_Click(sender As Object, e As EventArgs) Handles btnAdd2.Click
        'Add button set to add new row with data in text boxes
        Dim newRow As DataRow = DataSet5.Tables(0).NewRow
        newRow.Item(0) = txtItem_code2.Text
        newRow.Item(1) = txt_Quote_id.Text
        newRow.Item(2) = txtQty.Text
        DataSet5.Tables(0).Rows.Add(newRow)
        DataSet5.Tables(0).AcceptChanges()
        Me.LINE_ITEMTableAdapter.Insert(txtItem_code2.Text, txt_Quote_id.Text,
                                        txtQty.Text)
    End Sub

    Private Sub btnUpdate2_Click(sender As Object, e As EventArgs) Handles btnUpdate2.Click
        'Update button set to replace data of selected row in table with that in text boxes
        Dim row As DataRow = DataSet5.Tables(0).Rows(tblLine_item.SelectedRows(0).Index)
        LINE_ITEMTableAdapter.Update(txtItem_code2.Text, txt_Quote_id.Text,
                                        txtQty.Text, row(0), row(1), row(2))
        LINE_ITEMTableAdapter.Update(DataSet5)
        Me.LINE_ITEMTableAdapter.Fill(Me.DataSet5.LINE_ITEM)
    End Sub

    Private Sub btnDelete2_Click(sender As Object, e As EventArgs) Handles btnDelete2.Click
        'button set to delete contents of a full row
        Dim index As Integer
        index = tblLine_item.CurrentCell.RowIndex
        tblLine_item.Rows.RemoveAt(index)
        Me.LINE_ITEMTableAdapter.Update(LINEITEMBindingSource.DataSource)
        LINE_ITEMTableAdapter.Update(DataSet5)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'Button set to close only current form
        Close()
    End Sub
End Class