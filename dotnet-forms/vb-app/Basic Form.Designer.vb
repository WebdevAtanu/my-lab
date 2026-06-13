<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btn_showMessage = New Button()
        Btn_showName = New Button()
        Btn_dataTypes = New Button()
        textBoxName = New TextBox()
        textBoxEmail = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Btn_submit = New Button()
        ListBoxItems = New ListBox()
        ListBoxSelected = New ListBox()
        Btn_addItem = New Button()
        Btn_removeItem = New Button()
        TextBoxNum1 = New TextBox()
        TextBoxNum2 = New TextBox()
        Btn_sum = New Button()
        TextBoxSum = New TextBox()
        SuspendLayout()
        ' 
        ' btn_showMessage
        ' 
        btn_showMessage.Location = New Point(12, 12)
        btn_showMessage.Name = "btn_showMessage"
        btn_showMessage.Size = New Size(106, 29)
        btn_showMessage.TabIndex = 0
        btn_showMessage.Text = "Click Me"
        btn_showMessage.UseVisualStyleBackColor = True
        ' 
        ' Btn_showName
        ' 
        Btn_showName.Location = New Point(124, 12)
        Btn_showName.Name = "Btn_showName"
        Btn_showName.Size = New Size(97, 29)
        Btn_showName.TabIndex = 1
        Btn_showName.Text = "Show Name"
        Btn_showName.UseVisualStyleBackColor = True
        ' 
        ' Btn_dataTypes
        ' 
        Btn_dataTypes.Location = New Point(227, 12)
        Btn_dataTypes.Name = "Btn_dataTypes"
        Btn_dataTypes.Size = New Size(94, 29)
        Btn_dataTypes.TabIndex = 2
        Btn_dataTypes.Text = "Data Types"
        Btn_dataTypes.UseVisualStyleBackColor = True
        ' 
        ' textBoxName
        ' 
        textBoxName.Location = New Point(12, 102)
        textBoxName.Name = "textBoxName"
        textBoxName.Size = New Size(133, 27)
        textBoxName.TabIndex = 3
        ' 
        ' textBoxEmail
        ' 
        textBoxEmail.Location = New Point(151, 102)
        textBoxEmail.Name = "textBoxEmail"
        textBoxEmail.Size = New Size(133, 27)
        textBoxEmail.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 74)
        Label1.Name = "Label1"
        Label1.Size = New Size(49, 20)
        Label1.TabIndex = 5
        Label1.Text = "Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(153, 74)
        Label2.Name = "Label2"
        Label2.Size = New Size(46, 20)
        Label2.TabIndex = 6
        Label2.Text = "Email"
        ' 
        ' Btn_submit
        ' 
        Btn_submit.Location = New Point(290, 101)
        Btn_submit.Name = "Btn_submit"
        Btn_submit.Size = New Size(94, 29)
        Btn_submit.TabIndex = 7
        Btn_submit.Text = "Submit"
        Btn_submit.UseVisualStyleBackColor = True
        ' 
        ' ListBoxItems
        ' 
        ListBoxItems.FormattingEnabled = True
        ListBoxItems.Items.AddRange(New Object() {"Mango", "Apple"})
        ListBoxItems.Location = New Point(12, 164)
        ListBoxItems.Name = "ListBoxItems"
        ListBoxItems.Size = New Size(150, 104)
        ListBoxItems.TabIndex = 8
        ' 
        ' ListBoxSelected
        ' 
        ListBoxSelected.FormattingEnabled = True
        ListBoxSelected.Location = New Point(245, 164)
        ListBoxSelected.Name = "ListBoxSelected"
        ListBoxSelected.Size = New Size(150, 104)
        ListBoxSelected.TabIndex = 9
        ' 
        ' Btn_addItem
        ' 
        Btn_addItem.Location = New Point(168, 184)
        Btn_addItem.Name = "Btn_addItem"
        Btn_addItem.Size = New Size(71, 29)
        Btn_addItem.TabIndex = 10
        Btn_addItem.Text = ">>"
        Btn_addItem.UseVisualStyleBackColor = True
        ' 
        ' Btn_removeItem
        ' 
        Btn_removeItem.Location = New Point(168, 219)
        Btn_removeItem.Name = "Btn_removeItem"
        Btn_removeItem.Size = New Size(71, 29)
        Btn_removeItem.TabIndex = 11
        Btn_removeItem.Text = "<<"
        Btn_removeItem.UseVisualStyleBackColor = True
        ' 
        ' TextBoxNum1
        ' 
        TextBoxNum1.BackColor = SystemColors.Window
        TextBoxNum1.Location = New Point(512, 14)
        TextBoxNum1.Name = "TextBoxNum1"
        TextBoxNum1.PlaceholderText = "Num1"
        TextBoxNum1.Size = New Size(125, 27)
        TextBoxNum1.TabIndex = 12
        TextBoxNum1.Tag = ""
        ' 
        ' TextBoxNum2
        ' 
        TextBoxNum2.Location = New Point(512, 71)
        TextBoxNum2.Name = "TextBoxNum2"
        TextBoxNum2.PlaceholderText = "Num2"
        TextBoxNum2.Size = New Size(125, 27)
        TextBoxNum2.TabIndex = 13
        ' 
        ' Btn_sum
        ' 
        Btn_sum.BackColor = SystemColors.HotTrack
        Btn_sum.ForeColor = SystemColors.ButtonFace
        Btn_sum.Location = New Point(643, 42)
        Btn_sum.Name = "Btn_sum"
        Btn_sum.Size = New Size(94, 29)
        Btn_sum.TabIndex = 14
        Btn_sum.Text = "SUM"
        Btn_sum.UseVisualStyleBackColor = False
        ' 
        ' TextBoxSum
        ' 
        TextBoxSum.Location = New Point(743, 42)
        TextBoxSum.Name = "TextBoxSum"
        TextBoxSum.ReadOnly = True
        TextBoxSum.Size = New Size(125, 27)
        TextBoxSum.TabIndex = 15
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1131, 715)
        Controls.Add(TextBoxSum)
        Controls.Add(Btn_sum)
        Controls.Add(TextBoxNum2)
        Controls.Add(TextBoxNum1)
        Controls.Add(Btn_removeItem)
        Controls.Add(Btn_addItem)
        Controls.Add(ListBoxSelected)
        Controls.Add(ListBoxItems)
        Controls.Add(Btn_submit)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(textBoxEmail)
        Controls.Add(textBoxName)
        Controls.Add(Btn_dataTypes)
        Controls.Add(Btn_showName)
        Controls.Add(btn_showMessage)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btn_showMessage As Button
    Friend WithEvents Btn_showName As Button
    Friend WithEvents Btn_dataTypes As Button
    Friend WithEvents textBoxName As TextBox
    Friend WithEvents textBoxEmail As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Btn_submit As Button
    Friend WithEvents ListBoxItems As ListBox
    Friend WithEvents ListBoxSelected As ListBox
    Friend WithEvents Btn_addItem As Button
    Friend WithEvents Btn_removeItem As Button
    Friend WithEvents TextBoxNum1 As TextBox
    Friend WithEvents TextBoxNum2 As TextBox
    Friend WithEvents Btn_sum As Button
    Friend WithEvents TextBoxSum As TextBox

End Class
