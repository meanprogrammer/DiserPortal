Imports System.IO

Public Class HomePage
    Inherits System.Web.UI.Page

    Public conn As New clsConn
    Public where As String
    Public mstr As New MasterPage
    Public formatToSave As String = "d/M/yyyy"
    Public formatToShow As String = "MMM dd, yyyy"

    Public Sub checkSession()
        mstr = Page.Master
        Dim lblUserID As Label = mstr.FindControl("lblUserID")

        If Session("userID") Is Nothing Then
            Session.Clear()
            Response.Redirect("~/Default.aspx")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            checkSession()
            populateWeek()
        End If
    End Sub

    Public Sub PopulateWeek()

    End Sub
    Private Sub grdAnnounce_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAnnounce.DataBound
        'With conn
        '    .Page_Setup(grdAnnounce.TopPagerRow, grdAnnounce, "ddlPageNo")
        '    .Page_Setup(grdAnnounce.BottomPagerRow, grdAnnounce, "ddlPageNo")
        'End With
    End Sub

    Public Sub ddlPageNo_OnSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim ddlPageNo As DropDownList = sender

        If ddlPageNo IsNot Nothing Then
            If grdAnnounce.Rows.Count > 0 Then
                If ddlPageNo.SelectedIndex < grdAnnounce.PageCount Or _
                    ddlPageNo.SelectedIndex >= 0 Then

                    grdAnnounce.PageIndex = ddlPageNo.SelectedIndex
                End If
            End If
        End If
    End Sub

    Private Sub grdAnnounce_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdAnnounce.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim imgPic As Image = e.Row.FindControl("imgPic")

            If imgPic IsNot Nothing Then
                'Dim imgPic As Image = e.Row.FindContr.DataItemIndex.Value.ToString)
                retrievePic(imgPic, grdAnnounce.DataKeys(e.Row.RowIndex).Value.ToString)
            End If

        ElseIf e.Row.RowType = DataControlRowType.Pager Then
            With conn
                'check reccount of announcement
                where = "aStatusID = 1"
                Dim recCount As Double = .GetRecordCount("tbl_Announce", "announceID", where)

                If recCount <> 0 Then
                    'Dim i1 As ImageButton = grdAnnounce.BottomPagerRow.FindControl("i1")
                    'Dim i2 As ImageButton = grdAnnounce.BottomPagerRow.FindControl("i2")
                    'Dim i3 As ImageButton = grdAnnounce.BottomPagerRow.FindControl("i3")
                    'Dim i4 As ImageButton = grdAnnounce.BottomPagerRow.FindControl("i4")
                    'Dim i5 As ImageButton = grdAnnounce.BottomPagerRow.FindControl("i5")

                    Dim i1 As ImageButton = e.Row.FindControl("i1")
                    Dim i2 As ImageButton = e.Row.FindControl("i2")
                    Dim i3 As ImageButton = e.Row.FindControl("i3")
                    Dim i4 As ImageButton = e.Row.FindControl("i4")
                    Dim i5 As ImageButton = e.Row.FindControl("i5")

                    'i1.CommandArgument = ""
                    'i2.CommandArgument = ""
                    'i3.CommandArgument = ""
                    'i4.CommandArgument = ""
                    'i5.CommandArgument = ""

                    'grdAnnounce.DataBind()

                    Dim cnt As Integer = 1
                    Dim counter As Integer = 0

                    Dim retFld(0), retVal(0) As String
                    retFld(0) = "announceID"

                    where = "aStatusID = 1"
                    .getRecords("tbl_Announce", "TOP 5 *", where, 1, retFld, retVal, "announceID", "desc")

                    If retVal(0) <> "" Then
                        Dim aID() As String = Split(retVal(0), "+")

                        Do While cnt <= UBound(aID) + 1
                            Select Case cnt
                                Case 1
                                    i1.CommandArgument = aID(counter)
                                    i1.Visible = True
                                    i1.ImageUrl = "~/images/icons/pinkIC.png"

                                Case 2
                                    i2.CommandArgument = aID(counter)
                                    i2.Visible = True
                                    i2.ImageUrl = "~/images/icons/greenIC.png"

                                Case 3
                                    i3.CommandArgument = aID(counter)
                                    i3.Visible = True
                                    i3.ImageUrl = "~/images/icons/greenIC.png"

                                Case 4
                                    i4.CommandArgument = aID(counter)
                                    i4.Visible = True
                                    i4.ImageUrl = "~/images/icons/greenIC.png"

                                Case 5
                                    i5.CommandArgument = aID(counter)
                                    i5.Visible = True
                                    i5.ImageUrl = "~/images/icons/greenIC.png"
                            End Select
                            cnt += 1
                            counter += 1
                        Loop
                        'grdAnnounce.DataBind()
                    End If
                End If
            End With
        End If
    End Sub

    Public Sub retrievePic(ByVal imgPic As Image, ByVal recNo As String)
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "thumbnail"

            where = "announceID = " & recNo
            .getValues("tbl_Announce", "announceID, thumbnail", where, 1, retFld, retVal, "", "", "")

            Dim picPath = getPicPath()

            If retVal(0) = "" Then
                imgPic.ImageUrl = picPath & "announce.jpg"
            Else
                imgPic.ImageUrl = picPath & retVal(0)
            End If
        End With
    End Sub

    Public Function getPicPath() As String
        With conn
            'get storage path
            Dim retFld(0), retVal(0) As String

            retFld(0) = "announcePicPath"

            .getValues("tbl_Storage", "*", "storageID = 1", 1, retFld, retVal, "", "", "")

            getPicPath = retVal(0)
        End With
    End Function

    Protected Sub i1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        With grdAnnounce.Rows(0)
            Dim i1 As ImageButton = sender
            Dim i2 As ImageButton = sender.namingcontainer.findcontrol("i2")
            Dim i3 As ImageButton = sender.namingcontainer.findcontrol("i3")
            Dim i4 As ImageButton = sender.namingcontainer.findcontrol("i4")
            Dim i5 As ImageButton = sender.namingcontainer.findcontrol("i5")

            i1.ImageUrl = "~/images/icons/pinkIC.png"
            i2.ImageUrl = "~/images/icons/greenIC.png"
            i3.ImageUrl = "~/images/icons/greenIC.png"
            i4.ImageUrl = "~/images/icons/greenIC.png"
            i5.ImageUrl = "~/images/icons/greenIC.png"

            Dim aID As Double = Convert.ToInt64(i1.CommandArgument)

            Dim lblTitle As Label = .FindControl("lblTitle")
            Dim lblDate As Label = .FindControl("lblDate")
            Dim imgPic As Image = .FindControl("imgPic")
            Dim lblIntro As Label = .FindControl("lblIntro")
            Dim lnkMore As LinkButton = .FindControl("lnkMore")

            Dim retFld(3), retVal(3) As String

            retFld(0) = "aTitle"
            retFld(1) = "header"
            retFld(2) = "thumbnail"
            retFld(3) = "intro"

            where = "announceID = " & aID
            conn.getValues("vw_Announce", "*", where, 4, retFld, retVal, "", "", "")

            lblTitle.Text = retVal(0)
            lblDate.Text = retVal(1)
            lblIntro.Text = retVal(3)
            lnkMore.CommandArgument = aid

            retrievePic(imgPic, aID)
        End With
    End Sub

    Protected Sub i2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        With grdAnnounce.Rows(0)
            Dim i1 As ImageButton = sender.namingcontainer.findcontrol("i1")
            Dim i2 As ImageButton = sender
            Dim i3 As ImageButton = sender.namingcontainer.findcontrol("i3")
            Dim i4 As ImageButton = sender.namingcontainer.findcontrol("i4")
            Dim i5 As ImageButton = sender.namingcontainer.findcontrol("i5")

            i1.ImageUrl = "~/images/icons/greenIC.png"
            i2.ImageUrl = "~/images/icons/pinkIC.png"
            i3.ImageUrl = "~/images/icons/greenIC.png"
            i4.ImageUrl = "~/images/icons/greenIC.png"
            i5.ImageUrl = "~/images/icons/greenIC.png"

            Dim aID As Double = Convert.ToInt64(i2.CommandArgument)

            Dim lblTitle As Label = .FindControl("lblTitle")
            Dim lblDate As Label = .FindControl("lblDate")
            Dim imgPic As Image = .FindControl("imgPic")
            Dim lblIntro As Label = .FindControl("lblIntro")
            Dim lnkMore As LinkButton = .FindControl("lnkMore")

            Dim retFld(3), retVal(3) As String

            retFld(0) = "aTitle"
            retFld(1) = "header"
            retFld(2) = "thumbnail"
            retFld(3) = "intro"

            where = "announceID = " & aID
            conn.getValues("vw_Announce", "*", where, 4, retFld, retVal, "", "", "")

            lblTitle.Text = retVal(0)
            lblDate.Text = retVal(1)
            lblIntro.Text = retVal(3)
            lnkMore.CommandArgument = aID

            retrievePic(imgPic, aID)
        End With
    End Sub

    Protected Sub i3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        With grdAnnounce.Rows(0)
            Dim i1 As ImageButton = sender.namingcontainer.findcontrol("i1")
            Dim i2 As ImageButton = sender.namingcontainer.findcontrol("i2")
            Dim i3 As ImageButton = sender
            Dim i4 As ImageButton = sender.namingcontainer.findcontrol("i4")
            Dim i5 As ImageButton = sender.namingcontainer.findcontrol("i5")

            i1.ImageUrl = "~/images/icons/greenIC.png"
            i2.ImageUrl = "~/images/icons/greenIC.png"
            i3.ImageUrl = "~/images/icons/pinkIC.png"
            i4.ImageUrl = "~/images/icons/greenIC.png"
            i5.ImageUrl = "~/images/icons/greenIC.png"

            Dim aID As Double = Convert.ToInt64(i3.CommandArgument)

            Dim lblTitle As Label = .FindControl("lblTitle")
            Dim lblDate As Label = .FindControl("lblDate")
            Dim imgPic As Image = .FindControl("imgPic")
            Dim lblIntro As Label = .FindControl("lblIntro")
            Dim lnkMore As LinkButton = .FindControl("lnkMore")

            Dim retFld(3), retVal(3) As String

            retFld(0) = "aTitle"
            retFld(1) = "header"
            retFld(2) = "thumbnail"
            retFld(3) = "intro"

            where = "announceID = " & aID
            conn.getValues("vw_Announce", "*", where, 4, retFld, retVal, "", "", "")

            lblTitle.Text = retVal(0)
            lblDate.Text = retVal(1)
            lblIntro.Text = retVal(3)
            lnkMore.CommandArgument = aID

            retrievePic(imgPic, aID)
        End With
    End Sub

    Protected Sub i4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        With grdAnnounce.Rows(0)
            Dim i1 As ImageButton = sender.namingcontainer.findcontrol("i1")
            Dim i2 As ImageButton = sender.namingcontainer.findcontrol("i2")
            Dim i3 As ImageButton = sender.namingcontainer.findcontrol("i3")
            Dim i4 As ImageButton = sender
            Dim i5 As ImageButton = sender.namingcontainer.findcontrol("i5")

            i1.ImageUrl = "~/images/icons/greenIC.png"
            i2.ImageUrl = "~/images/icons/greenIC.png"
            i3.ImageUrl = "~/images/icons/greenIC.png"
            i4.ImageUrl = "~/images/icons/pinkIC.png"
            i5.ImageUrl = "~/images/icons/greenIC.png"

            Dim aID As Double = Convert.ToInt64(i4.CommandArgument)

            Dim lblTitle As Label = .FindControl("lblTitle")
            Dim lblDate As Label = .FindControl("lblDate")
            Dim imgPic As Image = .FindControl("imgPic")
            Dim lblIntro As Label = .FindControl("lblIntro")
            Dim lnkMore As LinkButton = .FindControl("lnkMore")

            Dim retFld(3), retVal(3) As String

            retFld(0) = "aTitle"
            retFld(1) = "header"
            retFld(2) = "thumbnail"
            retFld(3) = "intro"

            where = "announceID = " & aID
            conn.getValues("vw_Announce", "*", where, 4, retFld, retVal, "", "", "")

            lblTitle.Text = retVal(0)
            lblDate.Text = retVal(1)
            lblIntro.Text = retVal(3)
            lnkMore.CommandArgument = aID

            retrievePic(imgPic, aID)
        End With
    End Sub

    Protected Sub i5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        With grdAnnounce.Rows(0)
            Dim i1 As ImageButton = sender.namingcontainer.findcontrol("i1")
            Dim i2 As ImageButton = sender.namingcontainer.findcontrol("i2")
            Dim i3 As ImageButton = sender.namingcontainer.findcontrol("i3")
            Dim i4 As ImageButton = sender.namingcontainer.findcontrol("i4")
            Dim i5 As ImageButton = sender

            i1.ImageUrl = "~/images/icons/greenIC.png"
            i2.ImageUrl = "~/images/icons/greenIC.png"
            i3.ImageUrl = "~/images/icons/greenIC.png"
            i4.ImageUrl = "~/images/icons/greenIC.png"
            i5.ImageUrl = "~/images/icons/pinkIC.png"

            Dim aID As Double = Convert.ToInt64(i5.CommandArgument)

            Dim lblTitle As Label = .FindControl("lblTitle")
            Dim lblDate As Label = .FindControl("lblDate")
            Dim imgPic As Image = .FindControl("imgPic")
            Dim lblIntro As Label = .FindControl("lblIntro")
            Dim lnkMore As LinkButton = .FindControl("lnkMore")

            Dim retFld(3), retVal(3) As String

            retFld(0) = "aTitle"
            retFld(1) = "header"
            retFld(2) = "thumbnail"
            retFld(3) = "intro"

            where = "announceID = " & aID
            conn.getValues("vw_Announce", "*", where, 4, retFld, retVal, "", "", "")

            lblTitle.Text = retVal(0)
            lblDate.Text = retVal(1)
            lblIntro.Text = retVal(3)
            lnkMore.CommandArgument = aID

            retrievePic(imgPic, aID)
        End With
    End Sub

    Protected Sub lnkMore_Click(ByVal sender As Object, ByVal e As EventArgs)
        Session("announceID") = Convert.ToInt64(sender.commandargument)
        Response.Redirect("~/Community/Announcement.aspx")
    End Sub

    Protected Sub lnkView_Click(ByVal sender As Object, ByVal e As EventArgs)
        Session("announceID") = Nothing
        Response.Redirect("~/Community/Announcement.aspx")
    End Sub

    Protected Sub imbSales_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSales.Click
        Session("announceID") = Nothing
        Response.Redirect("~/Sales/Sales.aspx")
    End Sub

    Protected Sub imbReport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbReport.Click
        Session("announceID") = Nothing
        Response.Redirect("~/Report/Report.aspx")
    End Sub

    Protected Sub imbSupport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSupport.Click
        Session("announceID") = Nothing
        Response.Redirect("~/Support/Support.aspx")
    End Sub

    Protected Sub imbComm_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Session("announceID") = Nothing
        Response.Redirect("~/Community/Community.aspx")
    End Sub
End Class