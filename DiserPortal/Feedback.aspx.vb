Public Class Feedback
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

	End Sub

	Protected Sub btnYes_Click(ByVal senter As Object, ByVal e As System.EventArgs)
		Response.Redirect("Support/Support.aspx")
	End Sub

	Protected Sub btnNo_Click(ByVal senter As Object, ByVal e As System.EventArgs)
		Response.Redirect("Sales/Sales.aspx")
	End Sub

	Protected Sub btnLogout_Click(ByVal senter As Object, ByVal e As System.EventArgs)
		btnLogout.ID = "A2"
		Response.Redirect("~/Default.aspx")
	End Sub

End Class