﻿Public Class General
    Public Shared Function PathToAbsolute(ByVal RelativeAbsolutePath As String, ByVal BasePath As String) As String
        ' _, \, c:\, .\, ..\, folder\, \\xxx
        If RelativeAbsolutePath <> String.Empty And Not RelativeAbsolutePath.EndsWith("\") Then RelativeAbsolutePath &= "\"
        If Not BasePath.EndsWith("\") Then BasePath &= "\"
        If RelativeAbsolutePath = String.Empty Then
            RelativeAbsolutePath = BasePath
        ElseIf RelativeAbsolutePath.StartsWith("\\") Then

        ElseIf RelativeAbsolutePath.StartsWith("\") Then
            RelativeAbsolutePath = BasePath.Substring(0, 2) & RelativeAbsolutePath
        ElseIf RelativeAbsolutePath.StartsWith("..") Then
            RelativeAbsolutePath = BasePath & RelativeAbsolutePath
        ElseIf RelativeAbsolutePath.StartsWith(".") Then
            If RelativeAbsolutePath.Length > 2 Then
                RelativeAbsolutePath = BasePath & RelativeAbsolutePath.Substring(2, RelativeAbsolutePath.Length - 2)
            Else
                RelativeAbsolutePath = BasePath
            End If
        ElseIf RelativeAbsolutePath.Length > 1 AndAlso RelativeAbsolutePath.Substring(1, 1) <> ":" Then
            RelativeAbsolutePath = BasePath & RelativeAbsolutePath
        End If
        Return RelativeAbsolutePath
    End Function

    Public Shared Function DataTableToText(ByRef dt As DataTable) As String
        Dim dr As DataRow
        Dim dc As DataColumn
        Dim intCol As Integer
        Dim sb As New Text.StringBuilder()
        For Each dc In dt.Columns
            sb.Append(dc.ColumnName)
            sb.Append(", ")
        Next
        sb.Length = sb.Length - 2
        sb.Append(vbLf)
        For Each dr In dt.Rows
            For intCol = 0 To dr.ItemArray.Length - 1
                sb.Append(dr.ItemArray(intCol))
                sb.Append(", ")
            Next
            sb.Length = sb.Length - 2
            sb.Append(vbLf)
        Next
        Return sb.ToString
    End Function

    Public Shared Function cInteger(ByVal Value As String, ByRef DefaultValue As Integer) As Integer
        Dim intValue As Integer
        If Integer.TryParse(Value, intValue) Then
            Return intValue
        Else
            Return DefaultValue
        End If
    End Function

    Public Shared Function FromHex(ByVal strHex As String) As String
        Dim strValue As String = String.Empty
        If strHex = String.Empty Then Return strValue
        For intPair As Int16 = 0 To strHex.Length - 2 Step 2
            strValue = String.Concat(strValue, Convert.ToChar(Convert.ToInt32(strHex.Substring(intPair, 2), 16)).ToString)
        Next
        Return strValue
    End Function

    Public Shared Function ToHex(ByVal strValue As String) As String
        Dim strHex As String = String.Empty
        If strValue = String.Empty Then Return strHex
        For intChar As Int16 = 0 To strValue.Length - 1
            strHex = String.Concat(strHex, Convert.ToString(Asc(strValue.Substring(intChar, 1)), 16))
        Next
        Return strHex
    End Function

End Class
