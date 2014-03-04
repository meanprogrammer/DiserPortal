Public Class Profile
    Inherits System.Web.UI.Page

    Public conn As New clsConn
    Public ed As New clsED

    Public mstr As New MasterPage
    Public selFld, where As String
    Public bgEColor = Drawing.Color.PeachPuff
    Public bgVColor = Drawing.Color.White
    Public bgStyle = BorderStyle.Groove

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            checkSession()
            'setMenuBar()

            LoadDetails()
            LoadDropDowns()
            disablePage()
            setBGColor("View")
        End If
    End Sub

    Public Sub LoadDropDowns()
        With conn
            .loadToDropDownList("tbl_Question", ddlQuestion, False, "*", "", "questionID", "question", "", "")
        End With
    End Sub

    Public Sub setMenuBar()
        mstr = Page.Master
        With mstr
            Dim lkbHome As LinkButton = .FindControl("lkbHome")
            Dim lkbData As LinkButton = .FindControl("lkbData")
            Dim lkbMyAccnt As LinkButton = .FindControl("lkbMyAccnt")
            Dim lkbAccount As LinkButton = .FindControl("lkbAccount")
            Dim lkbAccess As LinkButton = .FindControl("lkbAccess")
            Dim lkbApplicant As LinkButton = .FindControl("lkbApplicant")
            Dim lkbClient As LinkButton = .FindControl("lkbClient")
            Dim lkbEmployee As LinkButton = .FindControl("lkbEmployee")

            lkbHome.CssClass = "imageLink"
            lkbHome.CommandName = ""

            lkbData.CssClass = "imageLink"
            lkbData.CommandName = ""

            lkbMyAccnt.CssClass = "imageLink-Selected"
            lkbMyAccnt.CommandName = "clicked"

            lkbAccount.CssClass = "imageLink"
            lkbAccount.CommandName = ""

            lkbAccess.CssClass = "imageLink"
            lkbAccess.CommandName = ""

            lkbApplicant.CssClass = "imageLink"
            lkbApplicant.CommandName = ""

            lkbClient.CssClass = "imageLink"
            lkbClient.CommandName = ""

            lkbEmployee.CssClass = "imageLink"
            lkbEmployee.CommandName = ""
        End With
    End Sub

    Public Sub checkSession()
        If Session("userID") Is Nothing Then
            Session.Clear()
            Response.Redirect("~/Default.aspx")
        End If
    End Sub

    Public Sub LoadDetails()
        With conn
            Dim retFld(12), retVal(12) As String

            retFld(0) = "uname"
            retFld(1) = "pwd"
            retFld(2) = "lockedCount"
            retFld(3) = "loginStatus"
            retFld(4) = "accntType"
            retFld(5) = "questionID"
            retFld(6) = "answer"
            retFld(7) = "empName"
            retFld(8) = "FCname"
            retFld(9) = "question"
            retFld(10) = "address"
            retFld(11) = "contact"
            retFld(12) = "sLoc"

            where = "userID = " & Session("userID")
            .getValues("vw_Users", "*", where, 13, retFld, retVal, "", "", "")

            txtUname.Text = retVal(0)

            RetrievePwd()

            txtLCount.Text = retVal(2)
            txtUStatus.Text = retVal(3)
            txtAType.Text = retVal(4)

            If retVal(5) = "" Or retVal(5) = "0" Then
                ddlQuestion.SelectedIndex = -1
            Else
                ddlQuestion.SelectedValue = retVal(5)
            End If

            RetrieveAns()

            txtName.Text = retVal(7)
            txtFC.Text = retVal(8)
            txtQuestion.Text = retVal(9)

            txtAdd.Text = retVal(10)
            txtContact.Text = retVal(11)
            txtStore.Text = retVal(12)
        End With
    End Sub

    Public Sub disablePage()
        txtPwd.ReadOnly = True
        txtAnswer.ReadOnly = True

        txtAType.Visible = True
        txtQuestion.Visible = True

        ddlQuestion.Visible = False
    End Sub

    Public Sub enablePage()
        ddlQuestion.Enabled = True
        txtAType.Visible = False
        txtQuestion.Visible = False

        ddlQuestion.Visible = True
    End Sub

    Public Sub setBGColor(ByVal pageMode As String)
        If pageMode = "View" Then
            '=============
            'set bg color
            '=============
            txtUname.BackColor = bgVColor
            txtLCount.BackColor = bgVColor
            txtUStatus.BackColor = bgVColor
            ddlQuestion.BackColor = bgVColor
            txtName.BackColor = bgVColor
            txtStore.BackColor = bgVColor

        ElseIf pageMode = "Create" Or pageMode = "Modify" Then
            txtUname.BackColor = bgEColor
            txtLCount.BackColor = bgEColor
            txtUStatus.BackColor = bgEColor
            ddlQuestion.BackColor = bgEColor
            txtName.BackColor = bgEColor
            txtStore.BackColor = bgEColor
        End If
    End Sub

    Public Sub updateInfo()
        With CONN
            Dim fld(2), val(2), dt(2) As String

            fld(0) = "uname"
            fld(1) = "answer"
            fld(2) = "questionID"

            val(0) = Trim(txtUname.Text)
            val(1) = Replace(txtAnswer.Text.Trim, "'", "''")
            val(2) = ddlQuestion.SelectedValue

            dt(0) = "C"
            dt(1) = "C"
            dt(2) = "N"

            where = "userID = " & Session("userID")
            .UpdateDB("tbl_Login", fld, val, dt, where)
        End With
    End Sub

    Protected Sub imbMPwd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        checkSession()
        lbleMsg.Text = ""

        If imbMPwd.AlternateText = "Modify" Then
            txtPwd.BackColor = bgEColor
            txtCPwd.BackColor = bgEColor

            lblPwd.Visible = False
            txtPwd.Visible = True
            txtCPwd.Visible = True
            txtPwd.ReadOnly = False
            txtPwd.TextMode = TextBoxMode.Password

            imbCPwd.Visible = True
            imbMPwd.AlternateText = "Save"
			imbMPwd.ImageUrl = "~/images/icons/save.png"
			imbMPwd.ToolTip = "Save"

        Else
            If Trim(txtPwd.Text) = "" Or Trim(txtCPwd.Text) = "" Then
                lbleMsg.Text = "Please enter your new password."
                Exit Sub

            ElseIf Len(Trim(txtPwd.Text)) < 8 Then
                lbleMsg.Text = "Password should be at least 8 characters long."
                Exit Sub

            ElseIf Trim(txtPwd.Text) <> Trim(txtCPwd.Text) Then
                lbleMsg.Text = "Password Mismatch"
                Exit Sub

            Else
                With conn
                    Dim fld(0), val(0), dt(0) As String

                    fld(0) = "pwd"
                    val(0) = ed.EncryptData(txtPwd.Text.Trim)
                    dt(0) = "C"

                    where = "userID = " & Session("userID")
                    .UpdateDB("tbl_Login", fld, val, dt, where)

                    txtCPwd.Text = ""
                    txtCPwd.Visible = False

                    txtPwd.Text = ""
                    txtPwd.TextMode = TextBoxMode.SingleLine
                    RetrievePwd()

                    txtPwd.ReadOnly = True
                    txtPwd.Visible = False
                    lblPwd.Visible = True
                    imbMPwd.AlternateText = "Modify"
					imbMPwd.ImageUrl = "~/images/icons/modify.png"
                    imbCPwd.Visible = False

                    txtPwd.BackColor = bgVColor
                    txtCPwd.BackColor = bgVColor
                End With
            End If
        End If
    End Sub

    Public Sub RetrievePwd()
        'load password
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "pwd"

            where = "userID = " & Session("userID")
            .getValues("tbl_Login", "userID, pwd", where, 1, retFld, retVal, "", "", "")

            Dim pwdLen As Integer = Len(ed.DecryptData(retVal(0)))
            Dim cnt As Integer = 1
            Dim counter As Integer = 0

            txtPwd.Text = ""

            Do While cnt <= pwdLen
                If lblPwd.Text = "" Then
                    lblPwd.Text = "x"
                Else
                    lblPwd.Text += "x"
                End If
                cnt += 1
                counter += 1
            Loop
        End With
    End Sub

    Public Sub RetrieveAns()
        'load password
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "answer"

            where = "userID = " & Session("userID")
            .getValues("tbl_Login", "userID, answer", where, 1, retFld, retVal, "", "", "")

            Dim ansLen As Integer = Len(retVal(0))
            Dim cnt As Integer = 1
            Dim counter As Integer = 0

            txtAnswer.Text = ""

            Do While cnt <= ansLen
                If lblAnswer.Text = "" Then
                    lblAnswer.Text = "x"
                Else
                    lblAnswer.Text += "x"
                End If
                cnt += 1
                counter += 1
            Loop
        End With
    End Sub

    Protected Sub imbCPwd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        checkSession()
        lbleMsg.Text = ""

        txtPwd.BackColor = bgVColor
        txtCPwd.BackColor = bgVColor

        txtPwd.Text = ""
        txtPwd.TextMode = TextBoxMode.SingleLine

        RetrievePwd()

        txtPwd.ReadOnly = True
        txtPwd.Visible = False
        lblPwd.Visible = True
        txtCPwd.Text = ""
        txtCPwd.Visible = False
        imbCPwd.Visible = False
        imbMPwd.AlternateText = "Modify"
		imbMPwd.ImageUrl = "~/images/icons/modify.png"
    End Sub

    Protected Sub imbMAns_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbMAns.Click
        checkSession()
        lbleMsg.Text = ""

        If imbMAns.AlternateText = "Modify" Then
            txtQuestion.Visible = False
            ddlQuestion.Visible = True

            ddlQuestion.BackColor = bgEColor

            lblAnswer.Visible = False
            txtAnswer.Visible = True
            txtAnswer.BackColor = bgEColor

            txtAnswer.ReadOnly = False
            txtAnswer.TextMode = TextBoxMode.Password

            imbMAns.AlternateText = "Save"
			imbMAns.ImageUrl = "~/images/icons/save.png"
			imbMAns.ToolTip = "Save"
            imbCAns.Visible = True


        Else
            If ddlQuestion.SelectedValue.Trim = "" Then
                lbleMsg.Text = "Security Question is required."
                Exit Sub

            ElseIf Trim(txtAnswer.Text) = "" Then
                lbleMsg.Text = "Kindly answer the security question you selected."
                Exit Sub

            Else
                With conn
                    Dim fld(1), val(1), dt(1) As String

                    fld(0) = "answer"
                    fld(1) = "questionID"

                    val(0) = Replace(txtAnswer.Text.Trim, "'", "''")
                    val(1) = ddlQuestion.SelectedValue.Trim

                    dt(0) = "C"
                    dt(1) = "N"

                    where = "userID = " & Session("userID")
                    .UpdateDB("tbl_Login", fld, val, dt, where)

                    txtAnswer.Text = ""
                    txtAnswer.TextMode = TextBoxMode.SingleLine
                    RetrieveAns()

                    txtAnswer.ReadOnly = True
                    lblAnswer.Visible = True
                    txtAnswer.Visible = False
                    imbMAns.AlternateText = "Modify"
					imbMAns.ImageUrl = "~/images/icons/modify.png"
                    imbCAns.Visible = False

                    ddlQuestion.BackColor = bgVColor
                    ddlQuestion.Visible = False
                    txtQuestion.Visible = True

                    txtAnswer.BackColor = bgVColor

                    txtQuestion.Text = ddlQuestion.SelectedItem.Text.Trim
                End With
            End If
        End If
    End Sub

    Protected Sub imbCAns_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbCAns.Click
        checkSession()
        lbleMsg.Text = ""

        ddlQuestion.BackColor = bgVColor
        ddlQuestion.Visible = False
        txtQuestion.Visible = True

        txtAnswer.BackColor = bgVColor

        txtAnswer.Text = ""
        txtAnswer.TextMode = TextBoxMode.SingleLine

        RetrieveAns()

        txtAnswer.ReadOnly = True
        txtAnswer.Visible = False
        lblAnswer.Visible = True
        imbCAns.Visible = False
        imbMAns.AlternateText = "Modify"
		imbMAns.ImageUrl = "~/images/icons/modify.png"
    End Sub

    'Protected Sub btnModify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModify.Click
    '    checkSession()
    '    lbleMsg.Text = ""

    '    If btnModify.Text = "Modify" Then
    '        imbMPwd.Enabled = False
    '        imbMPwd.AlternateText = "Modify"
    '        imbMPwd.ImageUrl = "~/images/icons/modify1.gif"

    '        imbMAns.Enabled = False
    '        imbMAns.AlternateText = "Modify"
    '        imbMAns.ImageUrl = "~/images/icons/modify1.gif"

    '        btnModify.Text = "Update"
    '        btnCancel.Visible = True

    '        enablePage()
    '        setBGColor("Modify")

    '    ElseIf btnModify.Text = "Update" Then
    '        updateInfo()
    '        disablePage()
    '        setBGColor("View")

    '        imbMPwd.Enabled = True
    '        imbMPwd.AlternateText = "Modify"
    '        imbMPwd.ImageUrl = "~/images/icons/modify.gif"

    '        imbMAns.Enabled = True
    '        imbMAns.AlternateText = "Modify"
    '        imbMAns.ImageUrl = "~/images/icons/modify.gif"

    '        btnModify.Text = "Modify"
    '        btnCancel.Visible = False

    '        LoadDetails()
    '    End If
    'End Sub

    'Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
    '    checkSession()
    '    lbleMsg.Text = ""

    '    LoadDetails()
    '    RetrievePwd()
    '    RetrieveAns()
    '    setBGColor("View")
    '    disablePage()

    '    btnCancel.Visible = False
    '    btnModify.Text = "Modify"

    '    imbMPwd.Enabled = True
    '    imbMPwd.AlternateText = "Modify"
    '    imbMPwd.ImageUrl = "~/images/icons/modify.gif"

    '    imbMAns.Enabled = True
    '    imbMAns.AlternateText = "Modify"
    '    imbMAns.ImageUrl = "~/images/icons/modify.gif"
    'End Sub
End Class