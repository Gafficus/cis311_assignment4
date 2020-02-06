<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.lstProducts = New System.Windows.Forms.ListBox()
        Me.lstSubAssembliesOfProduct = New System.Windows.Forms.ListBox()
        Me.lstPartsOfSubassembliesOfProduct = New System.Windows.Forms.ListBox()
        Me.lstAllSubAssemblies = New System.Windows.Forms.ListBox()
        Me.lstAllParts = New System.Windows.Forms.ListBox()
        Me.btnAddSubAssemblyToProduct = New System.Windows.Forms.Button()
        Me.btnRemoveSubAssemblyFromProduct = New System.Windows.Forms.Button()
        Me.btnAddPartToSubAssembly = New System.Windows.Forms.Button()
        Me.btnRemovePartFromSubAssembly = New System.Windows.Forms.Button()
        Me.btnCreateNewPart = New System.Windows.Forms.Button()
        Me.btnCreateNewSubassembly = New System.Windows.Forms.Button()
        Me.btnCreateNewProduct = New System.Windows.Forms.Button()
        Me.txtNewProduct = New System.Windows.Forms.TextBox()
        Me.txtNewPart = New System.Windows.Forms.TextBox()
        Me.txtNewSubassembly = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lstProducts
        '
        Me.lstProducts.FormattingEnabled = True
        Me.lstProducts.Location = New System.Drawing.Point(23, 12)
        Me.lstProducts.Name = "lstProducts"
        Me.lstProducts.Size = New System.Drawing.Size(855, 95)
        Me.lstProducts.TabIndex = 0
        Me.lstProducts.Tag = "0"
        '
        'lstSubAssembliesOfProduct
        '
        Me.lstSubAssembliesOfProduct.FormattingEnabled = True
        Me.lstSubAssembliesOfProduct.Location = New System.Drawing.Point(23, 185)
        Me.lstSubAssembliesOfProduct.Name = "lstSubAssembliesOfProduct"
        Me.lstSubAssembliesOfProduct.Size = New System.Drawing.Size(272, 121)
        Me.lstSubAssembliesOfProduct.TabIndex = 1
        Me.lstSubAssembliesOfProduct.Tag = "1"
        '
        'lstPartsOfSubassembliesOfProduct
        '
        Me.lstPartsOfSubassembliesOfProduct.FormattingEnabled = True
        Me.lstPartsOfSubassembliesOfProduct.Location = New System.Drawing.Point(23, 402)
        Me.lstPartsOfSubassembliesOfProduct.Name = "lstPartsOfSubassembliesOfProduct"
        Me.lstPartsOfSubassembliesOfProduct.Size = New System.Drawing.Size(272, 121)
        Me.lstPartsOfSubassembliesOfProduct.TabIndex = 2
        Me.lstPartsOfSubassembliesOfProduct.Tag = "2"
        '
        'lstAllSubAssemblies
        '
        Me.lstAllSubAssemblies.FormattingEnabled = True
        Me.lstAllSubAssemblies.Location = New System.Drawing.Point(606, 185)
        Me.lstAllSubAssemblies.Name = "lstAllSubAssemblies"
        Me.lstAllSubAssemblies.Size = New System.Drawing.Size(272, 121)
        Me.lstAllSubAssemblies.TabIndex = 3
        Me.lstAllSubAssemblies.Tag = "4"
        '
        'lstAllParts
        '
        Me.lstAllParts.FormattingEnabled = True
        Me.lstAllParts.Location = New System.Drawing.Point(606, 402)
        Me.lstAllParts.Name = "lstAllParts"
        Me.lstAllParts.Size = New System.Drawing.Size(272, 121)
        Me.lstAllParts.TabIndex = 4
        Me.lstAllParts.Tag = "3"
        '
        'btnAddSubAssemblyToProduct
        '
        Me.btnAddSubAssemblyToProduct.Location = New System.Drawing.Point(394, 185)
        Me.btnAddSubAssemblyToProduct.Name = "btnAddSubAssemblyToProduct"
        Me.btnAddSubAssemblyToProduct.Size = New System.Drawing.Size(95, 60)
        Me.btnAddSubAssemblyToProduct.TabIndex = 5
        Me.btnAddSubAssemblyToProduct.Tag = "12"
        Me.btnAddSubAssemblyToProduct.Text = "< - -"
        Me.btnAddSubAssemblyToProduct.UseVisualStyleBackColor = True
        '
        'btnRemoveSubAssemblyFromProduct
        '
        Me.btnRemoveSubAssemblyFromProduct.Location = New System.Drawing.Point(394, 251)
        Me.btnRemoveSubAssemblyFromProduct.Name = "btnRemoveSubAssemblyFromProduct"
        Me.btnRemoveSubAssemblyFromProduct.Size = New System.Drawing.Size(95, 60)
        Me.btnRemoveSubAssemblyFromProduct.TabIndex = 6
        Me.btnRemoveSubAssemblyFromProduct.Tag = "12"
        Me.btnRemoveSubAssemblyFromProduct.Text = "- - >"
        Me.btnRemoveSubAssemblyFromProduct.UseVisualStyleBackColor = True
        '
        'btnAddPartToSubAssembly
        '
        Me.btnAddPartToSubAssembly.Location = New System.Drawing.Point(394, 402)
        Me.btnAddPartToSubAssembly.Name = "btnAddPartToSubAssembly"
        Me.btnAddPartToSubAssembly.Size = New System.Drawing.Size(95, 60)
        Me.btnAddPartToSubAssembly.TabIndex = 7
        Me.btnAddPartToSubAssembly.Tag = "12"
        Me.btnAddPartToSubAssembly.Text = "< - -"
        Me.btnAddPartToSubAssembly.UseVisualStyleBackColor = True
        '
        'btnRemovePartFromSubAssembly
        '
        Me.btnRemovePartFromSubAssembly.Location = New System.Drawing.Point(394, 468)
        Me.btnRemovePartFromSubAssembly.Name = "btnRemovePartFromSubAssembly"
        Me.btnRemovePartFromSubAssembly.Size = New System.Drawing.Size(95, 60)
        Me.btnRemovePartFromSubAssembly.TabIndex = 8
        Me.btnRemovePartFromSubAssembly.Tag = "12"
        Me.btnRemovePartFromSubAssembly.Text = "- - >"
        Me.btnRemovePartFromSubAssembly.UseVisualStyleBackColor = True
        '
        'btnCreateNewPart
        '
        Me.btnCreateNewPart.Location = New System.Drawing.Point(606, 541)
        Me.btnCreateNewPart.Name = "btnCreateNewPart"
        Me.btnCreateNewPart.Size = New System.Drawing.Size(57, 43)
        Me.btnCreateNewPart.TabIndex = 9
        Me.btnCreateNewPart.Tag = "12"
        Me.btnCreateNewPart.Text = "Add Part"
        Me.btnCreateNewPart.UseVisualStyleBackColor = True
        '
        'btnCreateNewSubassembly
        '
        Me.btnCreateNewSubassembly.Location = New System.Drawing.Point(606, 327)
        Me.btnCreateNewSubassembly.Name = "btnCreateNewSubassembly"
        Me.btnCreateNewSubassembly.Size = New System.Drawing.Size(57, 43)
        Me.btnCreateNewSubassembly.TabIndex = 10
        Me.btnCreateNewSubassembly.Tag = "12"
        Me.btnCreateNewSubassembly.Text = "Add Subasm"
        Me.btnCreateNewSubassembly.UseVisualStyleBackColor = True
        '
        'btnCreateNewProduct
        '
        Me.btnCreateNewProduct.Location = New System.Drawing.Point(606, 123)
        Me.btnCreateNewProduct.Name = "btnCreateNewProduct"
        Me.btnCreateNewProduct.Size = New System.Drawing.Size(57, 43)
        Me.btnCreateNewProduct.TabIndex = 11
        Me.btnCreateNewProduct.Tag = "12"
        Me.btnCreateNewProduct.Text = "Add Product"
        Me.btnCreateNewProduct.UseVisualStyleBackColor = True
        '
        'txtNewProduct
        '
        Me.txtNewProduct.Location = New System.Drawing.Point(669, 135)
        Me.txtNewProduct.Name = "txtNewProduct"
        Me.txtNewProduct.Size = New System.Drawing.Size(196, 20)
        Me.txtNewProduct.TabIndex = 12
        Me.txtNewProduct.Tag = "12"
        '
        'txtNewPart
        '
        Me.txtNewPart.Location = New System.Drawing.Point(669, 553)
        Me.txtNewPart.Name = "txtNewPart"
        Me.txtNewPart.Size = New System.Drawing.Size(196, 20)
        Me.txtNewPart.TabIndex = 13
        Me.txtNewPart.Tag = "12"
        '
        'txtNewSubassembly
        '
        Me.txtNewSubassembly.Location = New System.Drawing.Point(669, 339)
        Me.txtNewSubassembly.Name = "txtNewSubassembly"
        Me.txtNewSubassembly.Size = New System.Drawing.Size(196, 20)
        Me.txtNewSubassembly.TabIndex = 14
        Me.txtNewSubassembly.Tag = "12"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 665)
        Me.Controls.Add(Me.txtNewSubassembly)
        Me.Controls.Add(Me.txtNewPart)
        Me.Controls.Add(Me.txtNewProduct)
        Me.Controls.Add(Me.btnCreateNewProduct)
        Me.Controls.Add(Me.btnCreateNewSubassembly)
        Me.Controls.Add(Me.btnCreateNewPart)
        Me.Controls.Add(Me.btnRemovePartFromSubAssembly)
        Me.Controls.Add(Me.btnAddPartToSubAssembly)
        Me.Controls.Add(Me.btnRemoveSubAssemblyFromProduct)
        Me.Controls.Add(Me.btnAddSubAssemblyToProduct)
        Me.Controls.Add(Me.lstAllParts)
        Me.Controls.Add(Me.lstAllSubAssemblies)
        Me.Controls.Add(Me.lstPartsOfSubassembliesOfProduct)
        Me.Controls.Add(Me.lstSubAssembliesOfProduct)
        Me.Controls.Add(Me.lstProducts)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstProducts As ListBox
    Friend WithEvents lstSubAssembliesOfProduct As ListBox
    Friend WithEvents lstPartsOfSubassembliesOfProduct As ListBox
    Friend WithEvents lstAllSubAssemblies As ListBox
    Friend WithEvents lstAllParts As ListBox
    Friend WithEvents btnAddSubAssemblyToProduct As Button
    Friend WithEvents btnRemoveSubAssemblyFromProduct As Button
    Friend WithEvents btnAddPartToSubAssembly As Button
    Friend WithEvents btnRemovePartFromSubAssembly As Button
    Friend WithEvents btnCreateNewPart As Button
    Friend WithEvents btnCreateNewSubassembly As Button
    Friend WithEvents btnCreateNewProduct As Button
    Friend WithEvents txtNewProduct As TextBox
    Friend WithEvents txtNewPart As TextBox
    Friend WithEvents txtNewSubassembly As TextBox
End Class
