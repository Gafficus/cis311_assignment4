Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        modDictionaries.testDics()
        For Each i In gDicProducts.Keys
            ListBox1.Items.Add(i)
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox2.Items.Clear()
        For Each productSubAssembly In (gDicProducts.Item(ListBox1.SelectedItem)).Keys
            ListBox2.Items.Add(productSubAssembly)
        Next
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        ListBox3.Items.Clear()
        For Each partInSubAssembly In (gDicSubAssemblies.Item(ListBox2.SelectedItem)).Keys
            ListBox3.Items.Add(partInSubAssembly)
        Next
    End Sub
End Class
