'----------------------------------------------
'-             File Name: frmMain             -
'-             Part of Project:assignment4    -
'----------------------------------------------
'-             Written By: Nathan Gaffney     -
'-             Written On: 05 Feb 2020        -
'----------------------------------------------
'- File Purpose:This file contains the code   -
'- to create the gui for the form, as well as -
'- the event handlers.                        -
'----------------------------------------------
Public Class frmMain
    '------------------------------------------------------------
    '-             Subprogram Name: Form1_Load                  -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 5 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram will initialize the    -
    '- global dictionaries and fill the list box fields with    -
    '- default values.                                          -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '- sender - the object that triggered the method, in this   -
    '- case it is Form1.                                        -
    '-e - Eventargs (Unused)                                    -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub Form1_Load(sender As Object, e As EventArgs) _
                Handles MyBase.Load

        modDictionaries.testDics() 'Populate the dictionaries with sample data

        '-------------------------------
        'Block of subprograms to write text into the lst boxes
        generateLstAllProducts()
        generateLstAllSubAssemblies()
        generateLstAllParts()
        '------------------------------
    End Sub

    '------------------------------------------------------------
    '-             Subprogram Name: generateLstAllProducts      -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 5 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram writes the contents of -
    '- the global dictionary for products into the lstProducts  -
    '- list box.                                                -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub generateLstAllProducts()
        lstProducts.Items.Clear()
        For Each i In gDicProducts.Keys
            lstProducts.Items.Add(i)
        Next
    End Sub
    '------------------------------------------------------------
    '-             Subprogram Name: generateLstAllParts         -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 5 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram writes the contents of -
    '- the basic materials dictionary to the basic materials    -
    '- list box.                                                -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub generateLstAllParts()
        lstAllParts.Items.Clear()
        For Each strKey In gDicBasicMaterials.Keys
            lstAllParts.Items.Add(strKey)
        Next
    End Sub
    '------------------------------------------------------------
    '-      Subprogram Name: generateLstAllSubAssemblies        -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 5 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram will populate the list -
    '- box of lstAllSubAssemblies with the Keys from global     -
    '- variable gDicSubAssemblies. The keys will be all the     -
    '- subassemblies available                                  -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '- (None)                                                   -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub generateLstAllSubAssemblies()
        lstAllSubAssemblies.Items.Clear()
        For Each strKey In gDicSubAssemblies.Keys
            lstAllSubAssemblies.Items.Add(strKey)
        Next
    End Sub
    '------------------------------------------------------------
    '-             Subprogram Name: selectionChanged            -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 6 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram listens for selection  -
    '- change of lstProducts and lstSubAssembliesOfProduct.     -
    '- When the index is changed 
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub selectionChanged(sender As ListBox, e As EventArgs) Handles lstSubAssembliesOfProduct.SelectedIndexChanged,
                                                                            lstProducts.SelectedIndexChanged
        Dim nextObjTag As Integer = sender.Tag + 1
        Dim dictionary As New Object
        'When this subprogram is called we do not know what
        'global dictionary to use. A cheap way to change this
        'is to create a Select case statement. Grab the tag
        'property of the sending object 
        Select Case sender.Tag
            Case 0
                dictionary = gDicProducts
            Case 1
                dictionary = gDicSubAssemblies
            Case Else
                Throw New NotImplementedException
        End Select
        'Look for a control in the active form, the only
        'Active form in this instance is Form1.
        'Me.Controls is a "list" of all controls in the 
        ' form. LINQ will look through these trying to
        'find the controls where the Tag property is equivalent
        ' to nextObjTag. In this case, 1 or 2.
        Dim outputListBox = From controls In Me.Controls
                            Where controls.Tag = nextObjTag
                            Select controls
        'Even though there is only one returned control from the form
        'it still need to be accessed as an array, create a list box
        'as a new list box that is the lower list box. If the slected
        'index was changed in lstProducts the lstSubassemblieOfParts
        'will be changed. If lstSubassemblieOfParts index was changed
        'then change the lstParts list box.
        Dim lstNextListBox As ListBox = outputListBox(0)
        clearListBox(lstNextListBox)
        For Each strkey In (dictionary.item(sender.SelectedItem)).keys
            lstNextListBox.Items.Add(strkey)
        Next

    End Sub
    '------------------------------------------------------------
    '-             Subprogram Name: btnCreateNewProduct_Click   -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 5 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram listens for selection  -
    '- change of lstProducts and lstSubAssembliesOfProduct.     -
    '- When the index is changed 
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- dicNewSubassemblyDictionary - This will hold the empty   -
    '- dictionary for the newly created product.                -
    '------------------------------------------------------------
    Private Sub btnCreateNewProduct_Click(sender As Object, e As EventArgs) _
                Handles btnCreateNewProduct.Click

        Dim dicNewSubassemblyDictionary As New Dictionary(Of String, Dictionary(Of String, String))

        'Creates a new entry in the lstProducts box of the new item
        'The key for this new item in gDicProducts is the text put
        'into the text box
        'An empty dictionary of subassemblies is added as the item for the key
        gDicProducts.Add(txtNewProduct.Text, dicNewSubassemblyDictionary)
        generateLstAllProducts()
    End Sub
    '------------------------------------------------------------
    '-             Subprogram Name: selectionChanged            -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 5 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram listens for selection  -
    '- change of lstProducts and lstSubAssembliesOfProduct.     -
    '- When the index is changed 
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnAddASubAssemblyToProduct_Click(sender As Object, e As EventArgs) _
                Handles btnAddSubAssemblyToProduct.Click
        'Prevents the list of subassemblies for a product from having
        'duplicate values entered
        clearListBox(lstSubAssembliesOfProduct)

        'lstProducts will subassemblies the key to be added to
        'We want to add an item (a dictionary of string of dictionary of string string)
        'to the selected key. We provide the key as the selected item in the 
        'lstAllSubassemblies and the item for this key value pair will be the dictionary
        'the selected subassembly key points to
        For Each lstItemSelected In lstAllSubAssemblies.SelectedItems
            gDicProducts.Item(lstProducts.SelectedItem).Add(lstItemSelected, gDicSubAssemblies.Item(lstItemSelected))
        Next
        'Write the subassemblies to the box
        For Each strkey In (gDicProducts.Item(lstProducts.SelectedItem)).Keys
            lstSubAssembliesOfProduct.Items.Add(strkey)
        Next

    End Sub
    '------------------------------------------------------------
    '- Subprogram Name: btnRemoveASubAssemblyFromProduct_Click  -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 5 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram listens for selection  -
    '- change of lstProducts and lstSubAssembliesOfProduct.     -
    '- When the index is changed 
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnRemoveASubAssemblyFromProduct_Click(sender As Object, e As EventArgs) _
                Handles btnRemoveSubAssemblyFromProduct.Click
        'The for each loop will allow for the removal of multiple items
        'at the same time.
        For Each lstItemSelected In lstSubAssembliesOfProduct.SelectedItems
            gDicProducts.Item(lstProducts.SelectedItem).Remove(lstItemSelected)
        Next
        clearListBox(lstSubAssembliesOfProduct)
        'Write the subassemblies to the box
        For Each strkey In (gDicProducts.Item(lstProducts.SelectedItem)).Keys
            lstSubAssembliesOfProduct.Items.Add(strkey)
        Next
    End Sub
    '------------------------------------------------------------
    '-      Subprogram Name: btnCreateNewSubassembly_Click      -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 8 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram will add a new entry to-
    '- the subassembly list and add a blank dictionary to the   -
    '- key of that entry                                        -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- dicNewParsDictionary - This will hold an empty dictionary-
    '- that will be the paired value for the newly created key  -
    '- in gDicSubAssemblies
    '------------------------------------------------------------
    Private Sub btnCreateNewSubassembly_Click(sender As Object, e As EventArgs) _
                Handles btnCreateNewSubassembly.Click

        Dim dicNewParsDictionary As New Dictionary(Of String, String)
        gDicSubAssemblies.Add(txtNewSubassembly.Text, dicNewParsDictionary)
        generateLstAllSubAssemblies()
    End Sub
    '------------------------------------------------------------
    '-             Subprogram Name: selectionChanged            -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 5 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram listens for selection  -
    '- change of lstProducts and lstSubAssembliesOfProduct.     -
    '- When the index is changed 
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnAddPartToSubassembly_Click(sender As Object, e As EventArgs) _
                Handles btnAddPartToSubAssembly.Click
        For Each lstSelectedItem In lstAllParts.SelectedItems
            gDicSubAssemblies.Item(lstSubAssembliesOfProduct.SelectedItem).Add(lstSelectedItem, gDicBasicMaterials(lstSelectedItem))
        Next
        clearListBox(lstPartsOfSubassembliesOfProduct)
        For Each strKey In (gDicSubAssemblies.Item(lstSubAssembliesOfProduct.SelectedItem)).Keys
            lstPartsOfSubassembliesOfProduct.Items.Add(strKey)
        Next
    End Sub
    '------------------------------------------------------------
    '-             Subprogram Name: selectionChanged            -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 5 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram listens for selection  -
    '- change of lstProducts and lstSubAssembliesOfProduct.     -
    '- When the index is changed 
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnRemovePartFromSubAssemly_Click(sender As Object, e As EventArgs) _
                Handles btnRemovePartFromSubAssembly.Click
        For Each lstSelectedItem In lstPartsOfSubassembliesOfProduct.SelectedItems
            gDicSubAssemblies.Item(lstSubAssembliesOfProduct.SelectedItem).Remove(lstSelectedItem)
        Next
        clearListBox(lstPartsOfSubassembliesOfProduct)
        For Each strKey In (gDicSubAssemblies.Item(lstSubAssembliesOfProduct.SelectedItem)).Keys
            lstPartsOfSubassembliesOfProduct.Items.Add(strKey)
        Next
    End Sub
    '------------------------------------------------------------
    '-             Subprogram Name: selectionChanged            -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 5 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram adds a new part to the -
    '- list of all parts that make up subassemblies.            -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnCreateNewPart_Click(sender As Object, e As EventArgs) _
                Handles btnCreateNewPart.Click
        gDicBasicMaterials.Add(txtNewPart.Text, txtNewPart.Text)
        generateLstAllParts()
    End Sub
    '------------------------------------------------------------
    '-             Subprogram Name: clearListBox                -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 10 February 2019         -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram clears the list box    -
    '- that was passed to the method.                           -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '- lstListBox - this is a reference to the listbox that     -
    '- will be changed by the method.                           -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub clearListBox(lstListBox As ListBox)
        lstListBox.Items.Clear()
        Debug.WriteLine("List box " & lstListBox.Name & " cleared.")
    End Sub
    '------------------------------------------------------------
    '-Subprogram Name: lstAllSubAssemblies_SelectedIndexChanged-
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 10 February 2019         -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram will clear and then    -
    '- write the contents of a selected sub assembly to the     -
    '- parts list box.                                          -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '- sender - this is the objec that sent the method          -
    '- e- holds the arguments that can be sent to the method    -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- (None)                                                   -
    '------------------------------------------------------------

    Private Sub lstAllSubAssemblies_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAllSubAssemblies.SelectedIndexChanged
        clearListBox(lstPartsOfSubassembliesOfProduct)
        'Because we want the parts of a subassembly that has not yet made
        ' it's way into the product, we grab the item from lstAllSubAssemblies
        For Each partInSubAssembly In (gDicSubAssemblies.Item(lstAllSubAssemblies.SelectedItem)).Keys
            lstPartsOfSubassembliesOfProduct.Items.Add(partInSubAssembly)
        Next
    End Sub
End Class
