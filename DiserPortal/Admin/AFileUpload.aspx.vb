Imports System.IO

Public Class AFileUpload
    Inherits System.Web.UI.Page

    Public conn As New clsConn
    Public loadAtt As New clsLoadAttachment

    Public where As String
    Public mstr As MasterPage

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

            lkbMyAccnt.CssClass = "imageLink"
            lkbMyAccnt.CommandName = ""

            lkbAccount.CssClass = "imageLink"
            lkbAccount.CommandName = ""

            lkbAccess.CssClass = "imageLink"
            lkbAccess.CommandName = ""

            lkbApplicant.CssClass = "imageLink-Selected"
            lkbApplicant.CommandName = "clicked"

            lkbClient.CssClass = "imageLink"
            lkbClient.CommandName = ""

            lkbEmployee.CssClass = "imageLink"
            lkbEmployee.CommandName = ""
        End With
    End Sub

    Public Function getPicStorage() As String
        With conn
            'get storage path
            Dim retFld(0), retVal(0) As String

            retFld(0) = "announcePicPath"

            .getValues("tbl_Storage", "", "storageID = 2", 1, retFld, retVal, "", "", "")

            getPicStorage = retVal(0)
        End With
    End Function

    Protected Sub imbPicAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPicAdd.Click
        System.Threading.Thread.Sleep(5000)
        checkSession()
        lbleMsg.Text = ""

        If fupPic.HasFile = True Then
            Dim docFilename As String = fupPic.FileName
            Dim docExt() As String = Split(docFilename, ".")

            fupPic.SaveAs(getPicStorage() & docFilename)

            'update tbl_Announce
            With conn
                Dim retVal(0), retFld(0) As String

                where = "announceID = " & Session("announceID")
                If .checkID("tbl_Announce", "announceID", where, 0, retVal, retFld, "", "") = "True" Then
                    'update record
                    Dim fld(0), val(0), dt(0) As String

                    fld(0) = "thumbnail"
                    val(0) = docFilename
                    dt(0) = "C"

                    where = "announceID = " & Session("announceID")
                    .UpdateDB("tbl_Announce", fld, val, dt, where)
                Else
                    'add record
                    Dim fld, val As String

                    fld = "announceID, thumbnail"
                    val = Session("announceID") & ", '" & docFilename & "'"

                    .saveInfo("tbl_Announce", fld, val)
                End If

                retrievePic()
                imbPicRemove.Visible = True
                fupPic.Visible = False
                imbPicAdd.Visible = False
            End With
        End If
    End Sub

    Public Sub retrievePic()
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "thumbnail"

            where = "announceID = " & Session("announceID")
            .getValues("tbl_Announce", "", where, 1, retFld, retVal, "", "", "")

            Dim picPath = getPicPath()

            If retVal(0) = "" Then
                imgApp.ImageUrl = picPath & "announce.jpg"
                imbPicRemove.Visible = False
            Else
                imgApp.ImageUrl = picPath & retVal(0)
                imbPicRemove.Visible = True
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

    Protected Sub imbExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbExit.Click
        checkSession()
        Response.Redirect("~/Admin/AFileUpload.aspx")
    End Sub

    Public Sub checkSession()
        'Dim lblUserID As Label = mstr.FindControl("lblUserID")

        If Session("userID") Is Nothing Then
            Session.Clear()
            Response.Redirect("~/Default.aspx")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            checkSession()
            'setMenuBar()

            panID.Visible = True
            retrievePic()
        End If
    End Sub

    Public Function getResumePath() As String
        With conn
            'get storage path
            Dim retFld(0), retVal(0) As String

            retFld(0) = "resumePath"

            .getValues("tbl_Storage", "", "storageID = 1", 1, retFld, retVal, "", "", "")

            getResumePath = retVal(0)
        End With
    End Function

    Public Function getResumeStorage() As String
        With conn
            'get storage path
            Dim retFld(0), retVal(0) As String

            retFld(0) = "resumePath"

            .getValues("tbl_Storage", "", "storageID = 2", 1, retFld, retVal, "", "", "")

            getResumeStorage = retVal(0)
        End With
    End Function

    Public Sub LoadAttachment(ByVal fileContentDispo As String, ByVal filePath As String, ByVal FilenameDotExtension As String)
        'get content type
        Dim fileParse() As String = Split(FilenameDotExtension, ".")

        'Clear buffer	
        Response.Clear()

        With loadAtt
            Response.ContentType = .GetContentType(fileParse(fileParse.Length - 1))

            'get content disposition
            Select Case fileContentDispo
                Case "attachment"
                    Response.AddHeader("Content-Disposition", "attachment: filename=" & FilenameDotExtension)
                Case "inline"
                    Response.AddHeader("Content-Disposition", "inline: filename=" & FilenameDotExtension)
            End Select

            Response.WriteFile(filePath & FilenameDotExtension)
            Response.End()
        End With
    End Sub

    Protected Sub imbPicRemove_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPicRemove.Click
        System.Threading.Thread.Sleep(5000)
        checkSession()
        lbleMsg.Text = ""

        With conn
            'retrieve pic filename
            Dim retFld(0), retVal(0) As String
            retFld(0) = "filename"

            where = "applicantID = " & Session("appID")
            .getValues("tbl_AppPic", "filename, applicantID", where, 1, retFld, retVal, "", "", "")

            Dim fName As String = getPicStorage() & retVal(0)

            If File.Exists(fName) = True Then
                File.Delete(fName)
            End If

            .deleteRecord("tbl_AppPic", where)
            retrievePic()
        End With
    End Sub
End Class