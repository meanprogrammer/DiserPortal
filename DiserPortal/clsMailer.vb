Imports System.Net.Mail
Imports System.Data
Imports System.net.Mail.SmtpClient

Public Class clsMailer
    Inherits System.Web.UI.Page

	Public Shared Function Send_Mail(ByVal mTo As String, _
							ByVal mCC As String, _
							ByVal mBCC As String, _
							ByVal mSubj As String, _
							ByVal mBody As String, _
							ByVal priority As Integer, _
							ByVal mAtt As String) As Boolean

		' ''Dim objEmail As New Mail.MailMessage()
		' ''Dim bodyFormat As String = Mail.MailFormat.Text

		' ''Mail.SmtpMail.SmtpServer = "localhost"
		' ''objEmail.From = "jaceatwork@hotmail.com"

		'' ''Mail.SmtpMail.SmtpServer = "smtp.gmail.com/smtp.live.com/smtp.mail.yahoo.com/mail.abs-cbn.com"
		'' ''objEmail.From = "property@abs-cbn.com"
		' ''objEmail.To = mTo

		'' ''cc
		' ''If Trim(mCC) <> "" Then
		' ''    objEmail.Cc = mCC
		' ''End If

		'' ''bcc
		' ''If Trim(mBCC) <> "" Then
		' ''    objEmail.Bcc = mBCC
		' ''End If

		' ''objEmail.Subject = mSubj
		' ''objEmail.Body = mBody

		' ''Select Case priority
		' ''    Case 1  'Normal
		' ''        objEmail.Priority = MailPriority.Normal

		' ''    Case 2  'Low
		' ''        objEmail.Priority = MailPriority.Low

		' ''    Case 3  'High
		' ''        objEmail.Priority = MailPriority.High
		' ''End Select

		'' ''attachments
		' ''Dim att() As String = Split(mAtt, "/")
		' ''Dim cnt, counter As Integer
		' ''cnt = 1
		' ''counter = 0

		' ''Do While cnt <= UBound(att) + 1
		' ''    objEmail.Attachments.Add(New Mail.MailAttachment(att(counter)))
		' ''    cnt += 1
		' ''    counter += 1
		' ''Loop

		' ''Try
		' ''    Mail.SmtpMail.Send(objEmail)
		' ''    Return True

		' ''Catch exc As Exception
		' ''    Return False
		' ''End Try


		Dim bodyFormat As String = Mail.MailFormat.Text
		'Dim smtpClient As New SmtpClient("smtp.gmail.com", 587) '465 / 587)
		'smtpClient.Credentials = New System.Net.NetworkCredential("christinesantos03", "@im4C#3F!!!")
		'smtpClient.UseDefaultCredentials = False
		'smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network
		'smtpClient.EnableSsl = True

		Dim objEmail As New Mail.MailMessage()

		Dim myMail As New MailMessage()

		'Setting From , To and CC
		myMail.From = New MailAddress("christinesantos03@gmail.com", "MyWeb Site")
		myMail.To.Add(New MailAddress(mTo))
		'myMail.CC.Add(New MailAddress(mCC))

		'myMail.Bcc.Add(New MailAddress(mBCC))
		'myMail.BodyEncoding = System.Text.Encoding.UTF8
		myMail.Subject = mSubj
		myMail.IsBodyHtml = False
		myMail.BodyEncoding = System.Text.Encoding.UTF8
		myMail.Body = mBody
		myMail.Priority = MailPriority.High

		Dim att() As String = Split(mAtt, "/")
		Dim cnt, counter As Integer
		cnt = 1
		counter = 0

		Do While cnt <= UBound(att) + 1
			'objEmail.Attachments.Add(New Mail.MailAttachment(att(counter)))
			cnt += 1
			counter += 1
		Loop



		'Mail.SmtpMail.SmtpServer = "mail.abs-cbn.com"
		' Mail.SmtpMail.SmtpServer = "smtp.live.com"
		'objEmail.From = "property@abs-cbn.com"
		'objEmail.To = mTo

		''cc
		'If Trim(mCC) <> "" Then
		'    objEmail.Cc = mCC
		'End If

		''bcc
		'If Trim(mBCC) <> "" Then
		'    objEmail.Bcc = mBCC
		'End If

		'objEmail.Subject = mSubj
		'objEmail.Body = mBody

		'Select Case priority
		'    Case 1  'Normal
		'        objEmail.Priority = MailPriority.Normal

		'    Case 2  'Low
		'        objEmail.Priority = MailPriority.Low

		'    Case 3  'High
		'        objEmail.Priority = MailPriority.High
		'End Select

		Try
			'smtpClient.Send(objEmail)



			Dim oSmtpClient As New SmtpClient()	  '("smtp.gmail.com", "465")
			oSmtpClient.UseDefaultCredentials = False
			oSmtpClient.Credentials = New Net.NetworkCredential("christinesantos03", "W@k0W@k0!", "smtp.gmail.com")
			oSmtpClient.Port = 587		'587
			oSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network
			oSmtpClient.Host = "smtp.gmail.com"

			oSmtpClient.EnableSsl = True

			oSmtpClient.Send(myMail)
			'Mail.SmtpMail.Send(objEmail)
			Return True

		Catch exc As Exception
			'MsgBox("An error occurred while sending your e-mail. Please try again.")
			Return False
		End Try
	End Function

	Public Shared Function SendMail(ByVal mTo As String, _
							ByVal mCC As String, _
							ByVal mBCC As String, _
							ByVal mSubj As String, _
							ByVal mBody As String, _
							ByVal priority As Integer) As Boolean

		'Dim bodyFormat As String = System.Net.Mail.MailMessage.IsBodyHtml()
		Dim smtpClient As New SmtpClient	'("smtp.gmail.com", 465) '587)
		'smtpClient.Credentials = New System.Net.NetworkCredential("christinesantos03", "@im4C#3F!!!")
		'smtpClient.UseDefaultCredentials = False
		'smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network
		'smtpClient.EnableSsl = True

		Dim objEmail As New System.Net.Mail.MailMessage()

		Dim myMail As New System.Net.Mail.MailMessage()

		'Setting From , To and CC
		myMail.From = New MailAddress("ronaldo@sona-systems.com", "MyWeb Site")
		myMail.To.Add(New MailAddress(mTo))
		'myMail.CC.Add(New MailAddress(mCC))
		myMail.Bcc.Add(New MailAddress(mBCC))
		myMail.Subject = mSubj
		myMail.Body = mBody
		myMail.Priority = MailPriority.High




		'Mail.SmtpMail.SmtpServer = "mail.abs-cbn.com"
		' Mail.SmtpMail.SmtpServer = "smtp.live.com"
		'objEmail.From = "property@abs-cbn.com"
		'objEmail.To = mTo

		''cc
		'If Trim(mCC) <> "" Then
		'    objEmail.Cc = mCC
		'End If

		''bcc
		'If Trim(mBCC) <> "" Then
		'    objEmail.Bcc = mBCC
		'End If

		'objEmail.Subject = mSubj
		'objEmail.Body = mBody

		'Select Case priority
		'    Case 1  'Normal
		'        objEmail.Priority = MailPriority.Normal

		'    Case 2  'Low
		'        objEmail.Priority = MailPriority.Low

		'    Case 3  'High
		'        objEmail.Priority = MailPriority.High
		'End Select

		Try
			smtpClient.Send(objEmail)
			'Dim oSmtpClient As New SmtpClient("smtp.gmail.com", 465)
			Dim oSmtpClient As New SmtpClient("mailout.internal.sona-systems.com", 587)
			oSmtpClient.EnableSsl = True
			'oSmtpClient.Credentials = New Net.NetworkCredential("bonpublic", "papasukinm0ak0")
			oSmtpClient.Credentials = New Net.NetworkCredential("ronaldo@sona-systems.com", "scoville97")
			oSmtpClient.Send(myMail)
			'Mail.SmtpMail.Send(objEmail)
			Return True

		Catch exc As Exception
			'MsgBox("An error occurred while sending your e-mail. Please try again.")
			Return False
		End Try
	End Function

	Public Shared Function PleaseSend(ByVal mTo As String, _
							ByVal mCC As String, _
							ByVal mBCC As String, _
							ByVal mSubj As String, _
							ByVal mBody As String, _
							ByVal priority As Integer, _
							ByVal eFrom As String, _
							ByVal eName As String, _
							ByVal smtpAdd As String, _
							ByVal smtpPort As Integer, _
							ByVal ePwd As String) As Boolean

		Dim bodyFormat As String = Mail.MailFormat.Text
		Dim myMail As New MailMessage()

		'Setting From , To and CC
		myMail.From = New MailAddress("jaceatwork@hotmail.com", "My Hotmail")
		myMail.From = New MailAddress(eFrom, eName)

		If Trim(mTo) <> "" Then
			myMail.To.Add(New MailAddress(mTo))
		End If

		If Trim(mCC) <> "" Then
			myMail.CC.Add(New MailAddress(mCC))
		End If

		If Trim(mBCC) <> "" Then
			myMail.Bcc.Add(New MailAddress(mBCC))
		End If

		myMail.Subject = mSubj
		myMail.Body = mBody

'		Dim att() As String = Split(mAtt, "/")
'		Dim cnt, counter As Integer
'		cnt = 1
'		counter = 0

'		Do While cnt <= UBound(att) + 1
'			myMail.Attachments.Add(New Net.Mail.Attachment(att(counter)))
'			cnt += 1
'			counter += 1
'		Loop

		Try
			'Dim oSmtpClient As New SmtpClient("smtp.gmail.com", 587)
			Dim oSmtpClient As New SmtpClient(smtpAdd, smtpPort)
			'oSmtpClient.Credentials = New Net.NetworkCredential("christinesantos03@gmail.com", "W@k0W@k0!")
			oSmtpClient.Credentials = New Net.NetworkCredential(eFrom, ePwd)
			oSmtpClient.EnableSsl = False

			oSmtpClient.Send(myMail)
			Return True

		Catch exc As Exception
			Return False
		End Try
	End Function
End Class
