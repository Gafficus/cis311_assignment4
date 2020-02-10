'----------------------------------------------
'-             File Name: modDictionaries     -
'-             Part of Project:assignment4    -
'----------------------------------------------
'-             Written By: Nathan Gaffney     -
'-             Written On: 05 Feb 2020        -
'----------------------------------------------
'- File Purpose:This file contains the code   -
'- necessary to create global dictionaries.   -
'- The code was pulled to it's own file to    -
'- simplify testing.                          -
'----------------------------------------------
Module modDictionaries
    Public gDicBasicMaterials As New Dictionary(Of String, String)
    Public gDicSubAssemblies As New Dictionary(Of String, Dictionary(Of String, String))
    Public gDicProducts As New Dictionary(Of String, Dictionary(Of String, Dictionary(Of String, String)))
    Public Sub testDics()
        Dim strItem As String = ""
        Dim strSubAssembly As String = ""
        Dim strProduct As String = ""
        gDicBasicMaterials.Add("Axel", "Axel")
        gDicBasicMaterials.Add("Base", "Base")
        gDicBasicMaterials.Add("Frame", "Frame")
        gDicBasicMaterials.Add("Leg", "Leg")
        gDicBasicMaterials.Add("Long Rail", "Long Rail")
        gDicBasicMaterials.Add("Seat", "Seat")
        gDicBasicMaterials.Add("Short Rail", "Short Rail")
        Dim boxParts As New Dictionary(Of String, String)
        Dim fourWheelFrameParts As New Dictionary(Of String, String)
        Dim sixWheelFrameParts As New Dictionary(Of String, String)
        strItem = "Base"
        boxParts.Add(gDicBasicMaterials.Item(strItem), strItem)
        strItem = "Long Rail"
        boxParts.Add(gDicBasicMaterials.Item(strItem), strItem)
        strItem = "Short Rail"
        boxParts.Add(gDicBasicMaterials.Item(strItem), strItem)
        strSubAssembly = "Box"
        gDicSubAssemblies.Add(strSubAssembly, boxParts)
        'gDicSubAssemblies.Add(boxParts, strSubAssembly)
        strSubAssembly = "4-Wheel Frame"
        gDicSubAssemblies.Add(strSubAssembly, fourWheelFrameParts)
        'gDicSubAssemblies.Add(fourWheelFrameParts, strSubAssembly)
        strSubAssembly = "6-Wheel Frame"
        gDicSubAssemblies.Add(strSubAssembly, fourWheelFrameParts)
        'gDicSubAssemblies.Add(sixWheelFrameParts, strSubAssembly)
        Dim wagonSubAssemblies As New Dictionary(Of String, Dictionary(Of String, String))
        wagonSubAssemblies.Add("Box", boxParts)
        wagonSubAssemblies.Add("4-Wheel Frame", fourWheelFrameParts)
        gDicProducts.Add("Wagon", wagonSubAssemblies)
        'gDicProducts.Add(gDicSubAssemblies, "Wagon")
    End Sub
End Module
