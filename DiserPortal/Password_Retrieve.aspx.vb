Public Class Password_Retrieve
    Inherits System.Web.UI.Page

    Public conn As New clsConn
    Public ed As New clsED

    Public where, selFld As String

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        checkSession()
        lbleMsg.Text = ""

        If txtNPwd.Text.Trim <> txtCPwd.Text.Trim Then
            lbleMsg.Text = "Password Mismatch!"
            txtNPwd.Focus()
            Exit Sub

        ElseIf Len(txtNPwd.Text.Trim) < 8 Then
            lbleMsg.Text = "Password should be at least 8 characters long."
            Exit Sub

        Else
            With conn
                Dim fld(2), val(2), dt(2) As String

                fld(0) = "pwd"
                fld(1) = "lockedCount"
                fld(2) = "loginStatusID"

                dt(0) = "C"
                dt(1) = "N"
                dt(2) = "N"

                val(0) = ed.EncryptData(txtNPwd.Text.Trim)
                val(1) = "0"
                val(2) = 1

                where = "userID = " & Session("userID")
                .UpdateDB("tbl_Login", fld, val, dt, where)

                'retrieve accessRights
                Dim retFld(0), retVal(0) As String

                retFld(0) = "accessRights"

                selFld = "userID, accessRights"
                where = "userID = " & Session("userID")
                .getValues("vw_Login", selFld, where, 1, retFld, retVal, "", "", "")

                Session.Add("accessRights", Trim(retVal(0)))
                Response.Redirect("~/HomePage.aspx")
            End With
        End If
    End Sub

    Public Sub checkSession()
        If Session("userID") Is Nothing Then
            Session.Clear()
            Response.Redirect("~/Default.aspx")
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Session.Clear()
        Response.Redirect("~/Default.aspx")
    End Sub
End Class