Public Class Community
    Inherits System.Web.UI.Page

    Public formatToSave As String = "d/M/yyyy"
    Public formatToShow As String = "MMM dd, yyyy"

    Public conn As New clsConn
    Public where As String

    Private Sub Community_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            checkSession()
            setMenu()

            'retrieve today's month
            Session("monthID") = 10 'Now.Month
            Session("wYr") = Now.Year

            lblDNote.Text = "#1 Merchandiser for " & Format(Now, "MMMM") & " " & Now.Year

            'load top 1
            With conn
                Dim retFld(5), retVal(5) As String

                retFld(0) = "empName"
                retFld(1) = "totalSales"
                retFld(2) = "FCName"
                retFld(3) = "SFCName"
                retFld(4) = "dealer"
                retFld(5) = "location"

                where = "wMonthID = " & Session("monthID") & " AND wYear = '" & Session("wYr") & "'"
                .getValues("vw_TopDiser", "TOP 1 *", where, 6, retFld, retVal, "totalSales", "", "")

                lblDiser.Text = retVal(0)
                lblSales.Text = retVal(1)
                lblFC.Text = retVal(2)
                lblSFC.Text = retVal(3)
                lblStore.Text = retVal(4)
                lblLoc.Text = retVal(5)
            End With
        End If
    End Sub

    Public Sub setMenu()
        lkbDiser.CssClass = ""
    End Sub
    Public Sub checkSession()
        If Session("userID") Is Nothing Then
            Session.Clear()
            Response.Redirect("~/Default.aspx")
        End If
    End Sub
End Class