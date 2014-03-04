Public Class SalesReport
    Inherits System.Web.UI.Page

    Public conn As New clsConn
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

            Dim where As String
            Dim retFld(2), retVal(2) As String

            retFld(0) = "empName"
            retFld(1) = "weekCoverage"
            retFld(2) = "dSubmitted"

            where = "userID = " & Session("userID")
            conn.getValues("vw_SalesSub", "empName, weekCoverage, dSubmitted", where, 3, retFld, retVal, "", "", "")

            lblDiser.Text = retVal(0)
            lblWeek.Text = retVal(1)
            lblDSub.Text = Format(CDate(retVal(2)), "MMM dd, yyyy")
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("~/Sales/Sales.aspx")
    End Sub
End Class