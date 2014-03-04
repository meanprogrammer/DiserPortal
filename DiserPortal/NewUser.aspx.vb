Public Class NewUser
    Inherits System.Web.UI.Page

    Public conn As New clsConn
    Public ed As New clsED
    Public where, qry As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            checkSession()

            ''check if a question has already been entered
            'Dim retFld(1), retVal(1) As String

            'retFld(0) = ""

            conn.loadToDropDownList("tbl_Question", ddlSQ, False, "*", "", "questionID", "question", "", "")
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        txtNPwd.Text = ""
        txtCPwd.Text = ""
        ddlSQ.SelectedIndex = -1
        txtAns.Text = ""
        Session.Clear()
        Response.Redirect("~/Default.aspx")
    End Sub

    Public Sub checkSession()
        If Session("userID") Is Nothing Then
            Session.Clear()
            Response.Redirect("~/Default.aspx")
        End If
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdate.Click
        checksession()
        lbleMsg.Text = ""

        If Len(txtNPwd.Text.Trim) < 8 Then
            lbleMsg.Text = "Password should be at least 8 characters long."
            txtNPwd.Text = ""
            txtCPwd.Text = ""
            txtNPwd.Focus()
            Exit Sub

        ElseIf txtNPwd.Text.Trim <> txtCPwd.Text.Trim Then
            lbleMsg.Text = "Password Mismatch!"
            txtNPwd.Text = ""
            txtCPwd.Text = ""
            txtNPwd.Focus()
            Exit Sub
        End If

        If ddlSQ.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Security Question is required."
            ddlSQ.Focus()
            Exit Sub
        End If

        If txtAns.Text.Trim = "" Then
            lbleMsg.Text = "Answer to the security question is required."
            txtAns.Focus()
            Exit Sub
        End If

        'check if pwd is still the def pwd
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "pwd"

            where = "userID = " & Session("userID")
            .getValues("tbl_Login", "userID, pwd", where, 1, retFld, retVal, "", "", "")

            If txtNPwd.Text.Trim = ed.DecryptData(retVal(0)) Then
                lbleMsg.Text = "You need to change your password. Your last registered password will not be honored."
                txtNPwd.Text = ""
                txtCPwd.Text = ""
                Exit Sub

            Else
                'update record
                Dim fld(5), val(5), dt(5) As String

                fld(0) = "pwd"
                fld(1) = "questionID"
                fld(2) = "answer"
                fld(3) = "lockedCount"
                fld(4) = "lockedDate"
                fld(5) = "loginStatusID"

                dt(0) = "C"
                dt(1) = "N"
                dt(2) = "C"
                dt(3) = "N"
                dt(4) = "C"
                dt(5) = "N"

                val(0) = ed.EncryptData(txtNPwd.Text.Trim)
                val(1) = ddlSQ.SelectedValue.Trim
                val(2) = txtAns.Text.Trim
                val(3) = "0"
                val(4) = ""
                val(5) = "1"    'Active

                where = "userID = " & Session("userID")
                .UpdateDB("tbl_Login", fld, val, dt, where)

                Response.Redirect("~/HomePage.aspx")
            End If
        End With
    End Sub
End Class