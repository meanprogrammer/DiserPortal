Public Class RefreshSession
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Dim metaKey As New HtmlMeta()
		metaKey.HttpEquiv = "Refresh"
		metaKey.Content = 300 & "; url=Default.aspx"	' auto logout after 5 minute of no response
		Page.Header.Controls.Add(metaKey)

	End Sub

	Protected Sub btnExtendSes_Click(ByVal senter As Object, ByVal e As System.EventArgs)
		Response.Redirect(Request("ref").Trim)
	End Sub

	Protected Sub btnLogout_Click(ByVal senter As Object, ByVal e As System.EventArgs)
		btnLogout.ID = "A2"
		Response.Redirect("Default.aspx")
	End Sub

End Class