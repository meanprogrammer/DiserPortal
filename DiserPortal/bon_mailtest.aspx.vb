Imports System.Net.Mail
Imports System.Data
Imports System.Net.Mail.SmtpClient

Public Class bon_mailtest
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		If clsMailer.PleaseSend("bondeveyra@gmail.com", "bondeveyra@gmail.com", "bondeveyra@gmail.com", "PleaseSend Test", "PleaseSend Body deveyra.com", 1, "bon@deveyra.com", "Bon", "mail.deveyra.com", 587, "bonafide") = True Then
			Me.litPleaseSendResult.Text = "PleaseSend was a go!"
		Else
			Me.litPleaseSendResult.Text = "PleaseSend was a error!"
		End If

	End Sub

End Class