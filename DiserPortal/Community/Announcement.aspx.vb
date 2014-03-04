Public Class Announcement
    Inherits System.Web.UI.Page

    Public conn As New clsConn
    Public where As String
    Public formatToSave As String = "d/M/yyyy"
    Public formatToShow As String = "MMM dd, yyyy"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Session("announceID") Is Nothing Then
                grdAnnounce.Visible = True
                panAnnounce.Visible = False
            Else
                grdAnnounce.Visible = False
                panAnnounce.Visible = True
                LoadDetails()
                retrievePic()
            End If
        End If
    End Sub

    Public Sub LoadDetails()
        With conn
            Dim retFld(6), retVal(6) As String

            retFld(0) = "aTitle"
            retFld(1) = "intro"
            retFld(2) = "story"

            retFld(3) = "dateCreated"
            retFld(4) = "cBy"
            retFld(5) = "lastUpdate"
            retFld(6) = "mBy"

            where = "announceID = " & Session("announceID")
            .getValues("vw_Announce", "*", where, 5, retFld, retVal, "", "", "")

            lblTitle.Text = retVal(0)
            lblIntro.Text = retVal(1)
            lblStory.Text = retVal(2)

            If retVal(3) <> "" Then
                If IsDate(retVal(3)) = True Then
                    lblCDate.Text = Format(CDate(retVal(3)), formatToShow)
                Else
                    lblCDate.Text = retVal(3)
                End If

            Else
                lblCDate.Text = ""
            End If

            lblCBy.Text = retVal(4)

            If retVal(5) <> "" Then
                iMDate.Visible = True
                If IsDate(retVal(5)) = True Then
                    lblMDate.Text = Format(CDate(retVal(5)), formatToShow)
                Else
                    lblMDate.Text = retVal(5)
                End If

            Else
                iMDate.Visible = False
                lblMDate.Text = ""
            End If

            If retVal(6) = "" Then
                lblMBy.Text = ""
                iMBy.Visible = False
            Else
                lblMBy.Text = retVal(6)
                iMBy.Visible = True
            End If

        End With
    End Sub

    Public Sub retrievePic()
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "thumbnail"

            where = "announceID = " & Session("announceID")
            .getValues("tbl_Announce", "", where, 1, retFld, retVal, "", "", "")

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

            .getValues("tbl_Storage", "", "storageID = 1", 1, retFld, retVal, "", "", "")

            getPicPath = retVal(0)
        End With
    End Function

    Protected Sub grdAnnounce_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdAnnounce.SelectedIndexChanged
        Session("announceID") = grdAnnounce.DataKeys(grdAnnounce.SelectedIndex).Values(0).ToString()
        LoadDetails()
        retrievePic()
        grdAnnounce.Visible = False
        panAnnounce.Visible = True
    End Sub

    Protected Sub lnkAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAll.Click
        Session("announceID") = Nothing
        grdAnnounce.Visible = True
        panAnnounce.Visible = False
        grdAnnounce.DataBind()
    End Sub
End Class