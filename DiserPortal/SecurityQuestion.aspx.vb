Public Class SecurityQuestion
    Inherits System.Web.UI.Page

    Public conn As New clsConn
    Public ed As New clsED

    Public where, selFld As String
    Public mstr As New MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            lbleMsg.Text = ""
            txtAnswer.Text = ""

            'retrieve security question
            With conn
                Dim retFld(1), retVal(1) As String
                retFld(0) = "question"
                retFld(1) = "answer"

                selFld = "userID, question, answer"
                where = "userID = " & Session("userID")
                .getValues("vw_Login", selFld, where, 2, retFld, retVal, "", "", "")

                txtQuestion.Text = retVal(0)
                Session.Add("answer", LCase(retVal(1)))
            End With
        End If
    End Sub

    Protected Sub btnValidate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnValidate.Click
        checkSession()
        lbleMsg.Text = ""

        If Trim(txtAnswer.Text) = "" Then
            lbleMsg.Text = "Kindly answer the security question."
            Exit Sub

        Else
            If LCase(txtAnswer.Text) = Session("answer") Then
                Response.Redirect("~/Password_Retrieve.aspx")

            Else
                lbleMsg.Text = "Invalid answer."
                txtAnswer.Focus()
            End If
        End If
    End Sub

    Public Sub checkSession()
        If Session("userID") Is Nothing Then
            Session.Clear()
            Response.Redirect("~/Default.aspx")
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Session.Clear()
        Response.Redirect("~/Default.aspx")
    End Sub
End Class