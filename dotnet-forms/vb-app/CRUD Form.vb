Imports Microsoft.Data.SqlClient

Public Class CRUD

    Dim connectionString As String = "Server=LAPTOP-P06NSLHF\SQLEXPRESS;Database=vb-db;User Id=sa;Password=admin;TrustServerCertificate=True;"

    ' =============== Load data on form load ===============
    Private Sub LoadData()
        Using con As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM Employees"
            Dim adapter As New SqlDataAdapter(query, con)
            Dim table As New DataTable()
            adapter.Fill(table)

            dgvEmployees.DataSource = table
        End Using
    End Sub

    ' =============== Insert data ===============
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click
        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String = "INSERT INTO Employees (Name, Email, Salary) VALUES (@Name, @Email, @Salary)"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Name", txtName.Text)
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@Salary", Decimal.Parse(txtSalary.Text))

                cmd.ExecuteNonQuery()
                MessageBox.Show("Inserted Successfully")
            End Using
        End Using

        LoadData()
    End Sub

    ' =============== Update data ===============
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If dgvEmployees.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a row first")
            Return
        End If

        Dim id As Integer = dgvEmployees.SelectedRows(0).Cells("Id").Value

        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String = "UPDATE Employees SET Name=@Name, Email=@Email, Salary=@Salary WHERE Id=@Id"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Id", id)
                cmd.Parameters.AddWithValue("@Name", txtName.Text)
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@Salary", Decimal.Parse(txtSalary.Text))

                cmd.ExecuteNonQuery()
                MessageBox.Show("Updated Successfully")
            End Using
        End Using

        LoadData()
    End Sub

    ' =============== Delete data ===============
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvEmployees.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a row first")
            Return
        End If

        Dim id As Integer = dgvEmployees.SelectedRows(0).Cells("Id").Value

        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String = "DELETE FROM Employees WHERE Id=@Id"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Id", id)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Deleted Successfully")
            End Using
        End Using

        LoadData()
    End Sub

    ' =============== Load data on button click ===============
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadData()
    End Sub

    ' =============== Grid cell click to populate textboxes ===============
    Private Sub dgvEmployees_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmployees.CellClick
        If e.RowIndex >= 0 Then
            Dim row = dgvEmployees.Rows(e.RowIndex)

            txtName.Text = row.Cells("Name").Value.ToString()
            txtEmail.Text = row.Cells("Email").Value.ToString()
            txtSalary.Text = row.Cells("Salary").Value.ToString()
        End If
    End Sub

    Private Sub dgvEmployees_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmployees.CellContentClick

    End Sub
End Class