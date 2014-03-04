Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class Forgot_Password
	Inherits System.Web.UI.Page

	Public conn As New clsConn
	Public ed As New clsED
	Public conStr As String = ConfigurationSettings.AppSettings("conString")
	Public sqlConn As New SqlConnection(conStr)
	Public cmd As SqlCommand
	Public dr As SqlDataReader
	Public ds As DataSet
	Public da As SqlDataAdapter
	Public dt As DataTable
	Public qry As String

	Public Sub connect(ByVal qry As String)
		If sqlConn.State = 1 Then sqlConn.Close()
		sqlConn.Open()
	End Sub

	Public Sub setAsNew(ByVal qry As String, ByVal tblname As String)
		cmd = New SqlCommand(qry, sqlConn)
	End Sub

	Protected Sub send_email_Click(ByVal sender As Object, ByVal e As EventArgs) Handles send_email.Click

		Dim l_email As String = Trim(liame.Text)
		Dim l_pwd As String = ""
		Dim l_uname As String = ""
		Dim l_userID As String = ""
		Dim l_where As String = ""
		Dim tblName As String = "tbl_Week"
		setAsNew(qry, tblName)

		cmd.Connection = sqlConn
		sqlConn.Open()

		qry = "SELECT l.pwd, l.uname, l.userID FROM CarrierDiserPortal.dbo.tbl_Login l, CarrierDiserPortal.dbo.tbl_User u WHERE l.userID=u.userID AND u.email='" & l_email & "'"

		connect(qry)
		setAsNew(qry, tblName)
		Dim RS = cmd.ExecuteReader
		Do While RS.Read()
			l_pwd = Trim(RS("pwd"))
			l_uname = Trim(RS("uname"))
			l_userID = CInt(RS("userID"))
		Loop
		RS.Close()
		RS = Nothing

		With conn
			Dim fld(3), val(3), dt(3) As String

			fld(0) = "pwd"
			fld(1) = "loginStatusID"
			fld(2) = "lockedCount"
			fld(3) = "lockedDate"

			dt(0) = "C"
			dt(1) = "N"
			dt(2) = "N"
			dt(3) = "C"

			val(0) = Admin.validatePWD(l_uname)
			val(1) = "5"
			val(2) = "0"
			val(3) = ""

			l_where = "userID = " & l_userID
			.UpdateDB("tbl_Login", fld, val, dt, l_where)
			lbleMsg.Text = "Password has been reset. Default password is the user's username.<br />If username is less than 8 characters, please affix '0' before typing the username to make an 8-digit password.<br />Also, please be reminded that password is case sensitive. Click <a href='default.aspx'>here</a> to continue."
		End With

	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

	End Sub

End Class