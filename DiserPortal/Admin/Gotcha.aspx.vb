Public Class Gotcha
    Inherits System.Web.UI.Page

    Public conn As New clsConn
    Public ed As New clsED

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Session("userID") <> "2" Then
                Response.Redirect("~/Admin/Admin.aspx")
            End If
        End If
    End Sub

    Protected Sub btnUGoGirl_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUGoGirl.Click
        If txtUID.Text.Trim <> "" Then
            If Session("userID") <> 2 Then
                Response.Redirect("~/Default.aspx")

            Else
                Dim retFld(0), retVal(0) As String
                retFld(0) = "pwd"

                conn.checkID("tbl_Login", "*", "userID = 2", 1, retVal, retFld, "", "")

                If txtUID.Text.Trim = ed.DecryptData(retVal(0)) Then
                    Session("gotcha") = "True"
                    Response.Redirect("~/Admin/SuperAdmin.aspx")
                Else
                    Session("gotcha") = "False"
                End If
            End If
        End If
    End Sub
End Class