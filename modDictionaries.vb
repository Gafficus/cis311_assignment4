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
        '--------------------------------------------
        strItem = "Base"
        boxParts.Add(gDicBasicMaterials.Item(strItem), strItem)
        strItem = "Long Rail"
        boxParts.Add(gDicBasicMaterials.Item(strItem), strItem)
        strItem = "Short Rail"
        boxParts.Add(gDicBasicMaterials.Item(strItem), strItem)
        strSubAssembly = "Box"
        gDicSubAssemblies.Add(strSubAssembly, boxParts)
        '------------------------------------------------
        strItem = "Frame"
        fourWheelFrameParts.Add(gDicBasicMaterials.Item(strItem), strItem)
        strItem = "Leg"
        fourWheelFrameParts.Add(gDicBasicMaterials.Item(strItem), strItem)
        strItem = "Seat"
        fourWheelFrameParts.Add(gDicBasicMaterials.Item(strItem), strItem)
        strSubAssembly = "4-Wheel Frame"
        gDicSubAssemblies.Add(strSubAssembly, fourWheelFrameParts)
        'gDicSubAssemblies.Add(fourWheelFrameParts, strSubAssembly)

        '------------------------------------------------
        strItem = "Short Rail"
        sixWheelFrameParts.Add(gDicBasicMaterials.Item(strItem), strItem)
        strItem = "Seat"
        sixWheelFrameParts.Add(gDicBasicMaterials.Item(strItem), strItem)
        strItem = "Leg"
        sixWheelFrameParts.Add(gDicBasicMaterials.Item(strItem), strItem)
        strSubAssembly = "6-Wheel Frame"
        gDicSubAssemblies.Add(strSubAssembly, sixWheelFrameParts)
        '----------------------------------------------------

        Dim wagonSubAssemblies As New Dictionary(Of String, Dictionary(Of String, String))
        wagonSubAssemblies.Add("Box", boxParts)
        wagonSubAssemblies.Add("4-Wheel Frame", fourWheelFrameParts)
        gDicProducts.Add("Wagon", wagonSubAssemblies)

        Dim roverSubAssemblies As New Dictionary(Of String, Dictionary(Of String, String))
        roverSubAssemblies.Add("Box", boxParts)
        roverSubAssemblies.Add("4-Wheel Frame", fourWheelFrameParts)
        roverSubAssemblies.Add("6-Wheel Frame", sixWheelFrameParts)
        gDicProducts.Add("Rover", roverSubAssemblies)
    End Sub
End Module
