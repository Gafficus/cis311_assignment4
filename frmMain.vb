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
    '- sender as ListBox - The control that triggerd the event  -
    '- this is then cast to a Listbox instead of an object to   -
    '- provide access to Listbox control methods.               -
    '- e - Holds the event args, currently unused               -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- lstNextListBox - This is the "child" list box that will  -
    '- be changed.                                              -
    '- objDictionaryPointer - This will hold a shallow copy of  -
    '- global dictionary that is being accessed for its items   -
    '- nextObjTag - This integer holds the child tag number     -
    '- to get the child tag simply add one. The tags start at 0 -
    '- for products and increment by one for each lstBox        -
    '------------------------------------------------------------
    Private Sub selectionChanged(sender As ListBox, e As EventArgs) Handles lstSubAssembliesOfProduct.SelectedIndexChanged,
                                                                            lstProducts.SelectedIndexChanged
        Dim nextObjTag As Integer = sender.Tag + 1
        Dim objDictionaryPointer As New Object
        'When this subprogram is called we do not know what
        'global dictionary to use. A cheap way to change this
        'is to create a Select case statement. Grab the tag
        'property of the sending object 
        Select Case sender.Tag
            Case 0
                objDictionaryPointer = gDicProducts
            Case 1
                objDictionaryPointer = gDicSubAssemblies
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
        Try
            clearListBox(lstNextListBox)
            For Each strkey In (objDictionaryPointer.item(sender.SelectedItem)).keys
                lstNextListBox.Items.Add(strkey)
            Next
        Catch ex As Exception
            'An exception is thrown when the user clicks outside
            'of the index area for a created value. To prevent 
            'a no key selectd error we will use a catch.
            Debug.WriteLine("Caught an exception from selecting an index.")
        End Try


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
        If (Not gDicProducts.ContainsKey(txtNewProduct.Text)) And (Not txtNewProduct.Text.Equals("")) Then
            gDicProducts.Add(txtNewProduct.Text, dicNewSubassemblyDictionary)
            generateLstAllProducts()
        Else
            txtNewProduct.Clear()
            MessageBox.Show("Please ensure that:" & vbCrLf &
                            "1. Product does not already exist." & vbCrLf &
                            "2. Entered value is not blank.")
        End If
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
            If Not gDicProducts.Item(lstProducts.SelectedItem).ContainsKey(lstItemSelected) Then
                gDicProducts.Item(lstProducts.SelectedItem).Add(lstItemSelected, gDicSubAssemblies.Item(lstItemSelected))
            End If

        Next
        Try
            'Write the subassemblies to the box
            For Each strkey In (gDicProducts.Item(lstProducts.SelectedItem)).Keys
                lstSubAssembliesOfProduct.Items.Add(strkey)
            Next
        Catch ex As System.ArgumentNullException
            MessageBox.Show("Please select a valid entry.")
        End Try


    End Sub
    '------------------------------------------------------------
    '- Subprogram Name: btnRemoveASubAssemblyFromProduct_Click  -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 5 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram will remove the        -
    '- selected subassemblie from the selected part and then    -
    '- re-list all the subassemblies of the selected part       -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '- sender - the control that triggered the event            -
    '- e - event args, currently unused                         -
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
        Try
            'Write the subassemblies to the box
            For Each strkey In (gDicProducts.Item(lstProducts.SelectedItem)).Keys
                lstSubAssembliesOfProduct.Items.Add(strkey)
            Next
        Catch ex As System.ArgumentNullException
            MessageBox.Show("Please select a valid entry.")
        End Try

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


        If (Not gDicSubAssemblies.ContainsKey(txtNewSubassembly.Text)) And
            (Not txtNewSubassembly.Text.Equals("")) Then
            gDicSubAssemblies.Add(txtNewSubassembly.Text, dicNewParsDictionary)
            generateLstAllSubAssemblies()
        Else
            txtNewSubassembly.Clear()
            MessageBox.Show("Please ensure that:" & vbCrLf &
                            "1. Sub-Assembly does not already exist." & vbCrLf &
                            "2. Entered value is not blank.")
        End If
    End Sub

    '------------------------------------------------------------
    '-Subprogram Name: btnAddPartToSubassembly_Click            -
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
        'Check to make sure the item does not already exist.
        For Each lstSelectedItem In lstAllParts.SelectedItems
            If Not gDicSubAssemblies.Item(lstSubAssembliesOfProduct.SelectedItem).ContainsKey(lstSelectedItem) Then
                gDicSubAssemblies.Item(lstSubAssembliesOfProduct.SelectedItem).Add(lstSelectedItem, gDicBasicMaterials(lstSelectedItem))
            End If
        Next
        clearListBox(lstPartsOfSubassembliesOfProduct)
        Try
            For Each strKey In (gDicSubAssemblies.Item(lstSubAssembliesOfProduct.SelectedItem)).Keys
                lstPartsOfSubassembliesOfProduct.Items.Add(strKey)
            Next
        Catch ex As System.ArgumentNullException
            MessageBox.Show("Please select a valid entry.")
        End Try

    End Sub
    '------------------------------------------------------------
    '-Subprogram Name: btnRemovePartFromSubAssemly_Click        -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 5 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram removes a part from    -
    '- the selcted sub assembly                                 -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '- sender - the control that triggered the event            -
    '- e - event arguments currently unused                     -
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
        Try
            For Each strKey In (gDicSubAssemblies.Item(lstSubAssembliesOfProduct.SelectedItem)).Keys
                lstPartsOfSubassembliesOfProduct.Items.Add(strKey)
            Next
        Catch ex As System.ArgumentNullException
            MessageBox.Show("Please select a valid entry!")
        End Try

    End Sub
    '------------------------------------------------------------
    '-             Subprogram Name: btnCreateNewPart_Click       -
    '------------------------------------------------------------
    '-                    Written By: Nathan Gaffney            -
    '-                     Written On: 5 February 2019          -
    '------------------------------------------------------------
    '- Subprogram Purpose:This subrogram adds a new part to the -
    '- list of all parts that make up subassemblies.            -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order)                -
    '- sender - the control that triggered the event            -
    '- e - event argument currently unused                      - 
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically)               -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub btnCreateNewPart_Click(sender As Object, e As EventArgs) _
                Handles btnCreateNewPart.Click
        If (Not gDicBasicMaterials.ContainsKey(txtNewPart.Text)) And
            (Not txtNewPart.Text.Equals("")) Then
            gDicBasicMaterials.Add(txtNewPart.Text, txtNewPart.Text)
            generateLstAllParts()
        Else
            txtNewPart.Clear()
            MessageBox.Show("Please ensure that:" & vbCrLf &
                            "1. Part does not already exist." & vbCrLf &
                            "2. Entered value is not blank.")
        End If

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
        Try
            For Each partInSubAssembly In (gDicSubAssemblies.Item(lstAllSubAssemblies.SelectedItem)).Keys
                lstPartsOfSubassembliesOfProduct.Items.Add(partInSubAssembly)
            Next
        Catch ex As Exception
            'Cat exception to prevent the program from crashing
            Debug.WriteLine("Caught an exception from deslecting and index, creating an error.")
        End Try

    End Sub

End Class
