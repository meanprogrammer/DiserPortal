Public Class _Default1
    Inherits System.Web.UI.Page

    Public conn As New clsConn

    'Protected Sub btnPwd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPwd.Click
    '    With conn
    '        Dim retFld(0), retVal(0) As String
    '        retFld(0) = "uname"

    '        .getRecords("Sheet1$", "*", "", 1, retFld, retVal, "", "")

    '        Dim pItem() As String = Split(retVal(0), "+")
    '        Dim cnt As Integer = 1
    '        Dim counter As Integer = 0

    '        Do While cnt <= UBound(pItem) + 1
    '            Dim values As String

    '            values = "'" & ed.EncryptData(pItem(counter)) & "'"

    '            .saveInfo("tbl_Pwd", "pwd", values)
    '            cnt += 1
    '            counter += 1
    '        Loop
    '    End With
    'End Sub

    'Protected Sub btnParse_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnParse.Click
    '    With conn
    '        Dim retFld(0), retVal(0) As String
    '        retFld(0) = "name"

    '        .getRecords("emp$", "*", "", 1, retFld, retVal, "", "")

    '        Dim eName() As String = Split(retVal(0), "+")
    '        Dim cnt As Integer = 1
    '        Dim counter As Integer = 0

    '        Do While cnt <= UBound(eName) + 1
    '            If eName(counter) <> "" Then
    '                Dim pName() As String = Split(eName(counter), ",")
    '                Dim lname As String = pName(0)

    '                Dim eFName() As String = Split(Trim(pName(1)), " ")
    '                Dim sCnt As Integer = 1
    '                Dim sCounter As Integer = 0
    '                Dim fname As String = ""
    '                Dim mname = ""

    '                Do While sCnt <= UBound(eFName) + 1
    '                    If Len(eFName(sCounter)) <= 3 Then
    '                        mname = eFName(sCounter)

    '                    Else
    '                        If fname = "" Then
    '                            fname = eFName(sCounter)
    '                        Else
    '                            fname += " " & eFName(sCounter)
    '                        End If
    '                    End If
    '                    sCnt += 1
    '                    sCounter += 1
    '                Loop

    '                Dim field, values As String

    '                field = "fname, mname, lname"
    '                values = "'" & fname & "', '" _
    '                            & mname & "', '" _
    '                            & lname & "'"

    '                .saveInfo("tbl_Emp", field, values)
    '            End If

    '            cnt += 1
    '            counter += 1
    '        Loop
    '    End With
    'End Sub
End Class