Public Class Support
    Inherits System.Web.UI.Page

    Public formatToSave As String = "d/M/yyyy"
    Public formatToShow As String = "MMM dd, yyyy"

    Public conn As New clsConn

    Public where, qry As String
    Public mstr As New MasterPage

    Public Sub checkSession()
        mstr = Page.Master
        Dim lblUserID As Label = mstr.FindControl("lblUserID")

        If Session("userID") Is Nothing Then
            Session.Clear()
            Response.Redirect("~/Default.aspx")
        End If
    End Sub

    Protected Sub lnkSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkSubmit.Click
        checkSession()
        lbleMsg.Text = ""

        panSubmit.Visible = True
        panMyTicket.Visible = False

        lnkSubmit.CssClass = "tabprop-Selected"
        lnkMyTicket.CssClass = "tabprop"
    End Sub

    Protected Sub lnkMyTicket_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkMyTicket.Click
        checkSession()
        lbleMsg.Text = ""

        panSubmit.Visible = False
        panMyTicket.Visible = True

        lnkSubmit.CssClass = "tabprop"
        lnkMyTicket.CssClass = "tabprop-Selected"
    End Sub

    Private Sub Support_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            With conn
                .loadToDropDownList("tbl_Subject", ddlSubj, False, "*", "", "subjID", "subject", "subject", "")
            End With
        End If
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReset.Click
        ddlSubj.SelectedIndex = -1
        txtComments.Text = ""
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
        checkSession()
        lbleMsg.Text = ""

        If ddlSubj.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Please select a subject."
            Exit Sub
        End If

        If txtComments.Text.Trim = "" Then
            lbleMsg.Text = "Comments are required."
            Exit Sub
        End If

        With conn
            Dim field, values As String

            field = "subjID, comments, supportStatusID, dateSubmitted, userID"
            values = ddlSubj.SelectedValue.Trim & ", '" _
                        & txtComments.Text.Trim & "', 1, '" _
                        & Format(Now, "MMM dd, yyyy HH:mm") & "', " _
                        & Session("userID")

            .saveInfo("tbl_Support", field, values)
        End With

        ddlSubj.SelectedIndex = -1
        txtComments.Text = ""

        lnkMyTicket.CssClass = "tabprop-Selected"
        lnkSubmit.CssClass = "tabprop"

        panSubmit.Visible = False
        panMyTicket.Visible = True
    End Sub

    Protected Sub grdSupport_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdSupport.SelectedIndexChanged
        System.Threading.Thread.Sleep(500)

        'Session("supportID") = grdSupport.DataKeys(grdSupport.SelectedIndex).Values(0).ToString()
        Session("supportID") = grdSupport.DataKeys.Item(grdSupport.SelectedIndex).Value.ToString
        panSDetails.Visible = True
        panSupport.Visible = False

        LoadSupportData()
        txtReply.Text = ""
        rblSStat.SelectedValue = 1
    End Sub

    Public Sub LoadSupportData()
        With conn
            Dim retFld(6), retVal(6) As String

            retFld(0) = "supportID"
            retFld(1) = "subject"
            retFld(2) = "comments"
            retFld(3) = "supportStatus"
            retFld(4) = "dateSubmitted"
            retFld(5) = "createdBy"
            retFld(6) = "supportStatusID"

            where = "supportID = " & Session("supportID")
            .getValues("vw_Support", "*", where, 7, retFld, retVal, "", "", "")

            lblTNo.Text = retVal(0)
            lblSubj.Text = retVal(1)
            lblComment.Text = retVal(2)
            lblStatus.Text = retVal(3)
            lblDCreated.Text = retVal(4)

            If retVal(6) = "1" Then
                panReply.Visible = True
                btnSubmit1.Visible = True
            Else
                panReply.Visible = False
                btnSubmit1.Visible = False
            End If

            grdSTrans.DataBind()
        End With
    End Sub

    Protected Sub btnAllSupport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAllSupport.Click
        panSDetails.Visible = False
        panSupport.Visible = True

        grdSupport.DataBind()
        grdSupport.SelectedIndex = -1
    End Sub

    Protected Sub btnSubmit1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit1.Click
        If txtReply.Text.Trim = "" Then
            lbleMsg4.Text = "Your reply is required."
            Exit Sub

        Else
            With conn
                Dim field, values As String

                field = "supportID, reply, repliedByID, supportStatusID, dateReplied"
                values = Session("supportID") & ", '" _
                            & Replace(txtReply.Text.Trim, "'", "''") & "', " _
                            & Session("userID") & ", "

                If rblSStat.SelectedValue = 2 Then
                    values += "2, '"
                Else
                    values += "1, '"
                End If

                values += Format(CDate(Now), "MMM dd, yyyy HH:mm") & "'"

                .saveInfo("tbl_SupportTrans", field, values)

                'update tbl_support
                Dim fld(0), val(0), dt(0) As String

                fld(0) = "supportStatusID"
                dt(0) = "N"

                If rblSStat.SelectedValue = 2 Then
                    val(0) = "2"
                Else
                    val(0) = "1"
                End If

                where = "supportID = " & Session("supportID")
                .UpdateDB("tbl_Support", fld, val, dt, where)

                grdSupport.DataBind()
                grdSupport.SelectedIndex = -1
                panSDetails.Visible = False
                panSupport.Visible = True
            End With
        End If
    End Sub
End Class
