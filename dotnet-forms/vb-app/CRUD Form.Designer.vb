<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CRUD
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        txtName = New TextBox()
        txtSalary = New TextBox()
        txtEmail = New TextBox()
        btnInsert = New Button()
        btnLoad = New Button()
        btnDelete = New Button()
        btnUpdate = New Button()
        dgvEmployees = New DataGridView()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        CType(dgvEmployees, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(10, 38)
        txtName.Name = "txtName"
        txtName.Size = New Size(478, 27)
        txtName.TabIndex = 0
        ' 
        ' txtSalary
        ' 
        txtSalary.Location = New Point(12, 156)
        txtSalary.Name = "txtSalary"
        txtSalary.Size = New Size(476, 27)
        txtSalary.TabIndex = 1
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(10, 96)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(478, 27)
        txtEmail.TabIndex = 2
        ' 
        ' btnInsert
        ' 
        btnInsert.Location = New Point(12, 203)
        btnInsert.Name = "btnInsert"
        btnInsert.Size = New Size(94, 29)
        btnInsert.TabIndex = 3
        btnInsert.Text = "INSERT"
        btnInsert.UseVisualStyleBackColor = True
        ' 
        ' btnLoad
        ' 
        btnLoad.Location = New Point(394, 203)
        btnLoad.Name = "btnLoad"
        btnLoad.Size = New Size(94, 29)
        btnLoad.TabIndex = 4
        btnLoad.Text = "REFRESH"
        btnLoad.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(212, 203)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(94, 29)
        btnDelete.TabIndex = 5
        btnDelete.Text = "DELETE"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnUpdate
        ' 
        btnUpdate.Location = New Point(112, 203)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(94, 29)
        btnUpdate.TabIndex = 6
        btnUpdate.Text = "UPDATE"
        btnUpdate.UseVisualStyleBackColor = True
        ' 
        ' dgvEmployees
        ' 
        dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvEmployees.Location = New Point(507, 22)
        dgvEmployees.Name = "dgvEmployees"
        dgvEmployees.RowHeadersWidth = 51
        dgvEmployees.Size = New Size(602, 633)
        dgvEmployees.TabIndex = 7
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(10, 12)
        Label1.Name = "Label1"
        Label1.Size = New Size(49, 20)
        Label1.TabIndex = 8
        Label1.Text = "Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 133)
        Label2.Name = "Label2"
        Label2.Size = New Size(49, 20)
        Label2.TabIndex = 9
        Label2.Text = "Salary"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(10, 73)
        Label3.Name = "Label3"
        Label3.Size = New Size(46, 20)
        Label3.TabIndex = 10
        Label3.Text = "Email"
        ' 
        ' CRUD
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1121, 682)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(dgvEmployees)
        Controls.Add(btnUpdate)
        Controls.Add(btnDelete)
        Controls.Add(btnLoad)
        Controls.Add(btnInsert)
        Controls.Add(txtEmail)
        Controls.Add(txtSalary)
        Controls.Add(txtName)
        Name = "CRUD"
        Text = "Form2"
        CType(dgvEmployees, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtName As TextBox
    Friend WithEvents txtSalary As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnInsert As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents dgvEmployees As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
