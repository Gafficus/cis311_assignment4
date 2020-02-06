﻿'----------------------------------------------
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
        modDictionaries.testDics()
        For Each i In gDicProducts.Keys
            lstProducts.Items.Add(i)
        Next
        generateLstAllSubAssemblies()
        generateLstAllParts()
    End Sub
    '------------------------------------------------------------
    '-             Subprogram Name: generateLstAllParts         -
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
    Private Sub generateLstAllParts()
        'Throw New NotImplementedException()
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

        For Each strKey In (dictionary.Item(sender.SelectedItem)).Keys
            lstNextListBox.Items.Add(strKey)
        Next
    End Sub
    '------------------------------------------------------------
    '-       Subprogram Name: lstProducts_SelectedIndexChanged  -
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

    'Private Sub lstProducts_SelectedIndexChanged(sender As Object, e As EventArgs) _
    '            Handles lstProducts.SelectedIndexChanged
    '    lstSubAssembliesOfProduct.Items.Clear()
    '    For Each productSubAssembly In (gDicProducts.Item(lstProducts.SelectedItem)).Keys
    '        lstSubAssembliesOfProduct.Items.Add(productSubAssembly)
    '    Next
    'End Sub

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

    'Private Sub lstSubAssembliesOfProduct_SelectedIndexChanged(sender As Object, e As EventArgs) _
    '            Handles lstSubAssembliesOfProduct.SelectedIndexChanged
    '    lstPartsOfSubassembliesOfProduct.Items.Clear()
    '    For Each partInSubAssembly In (gDicSubAssemblies.Item(lstSubAssembliesOfProduct.SelectedItem)).Keys
    '        lstPartsOfSubassembliesOfProduct.Items.Add(partInSubAssembly)
    '    Next
    'End Sub
    Private Sub btnCreateNewProduct_Click(sender As Object, e As EventArgs) _
                Handles btnCreateNewProduct.Click

    End Sub
    Private Sub btnAddASubAssemblyToProduct_Click(sender As Object, e As EventArgs) _
                Handles btnAddSubAssemblyToProduct.Click

    End Sub

    Private Sub btnRemoveASubAssemblyFromProduct_Click(sender As Object, e As EventArgs) _
                Handles btnRemoveSubAssemblyFromProduct.Click

    End Sub
    Private Sub btnCreateNewSubassembly_Click(sender As Object, e As EventArgs) _
                Handles btnCreateNewSubassembly.Click

    End Sub
    Private Sub btnAddPartToSubassembly_Click(sender As Object, e As EventArgs) _
                Handles btnAddPartToSubAssembly.Click

    End Sub
    Private Sub btnRemovePartFromSubAssemly_Click(sender As Object, e As EventArgs) _
                Handles btnRemovePartFromSubAssembly.Click

    End Sub
    Private Sub btnCreateNewPart_Click(sender As Object, e As EventArgs) _
                Handles btnCreateNewPart.Click

    End Sub

End Class