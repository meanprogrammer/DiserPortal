Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class populateday
	Inherits System.Web.UI.Page

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

	Private Sub submit_add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles submit_add.Click

		qry = ""
		Dim tblName As String = "tbl_WDay"
		setAsNew(qry, tblName)
		cmd.Connection = sqlConn
		cmd.CommandType = CommandType.Text
		cmd.CommandText = Nothing

		qry = "INSERT INTO " & tblName & " (wDay,weekID) VALUES ('" & a_wDay.Text & "','" & a_weekID.Text & "')"

		connect(qry)
		cmd.CommandText = qry
		cmd.ExecuteNonQuery()

		pnlAdd.Visible = False

		Response.Redirect("PopulateDay.aspx")
	End Sub

	Private Sub submit_edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles submit_edit.Click

		qry = ""
		Dim tblName As String = "tbl_WDay"
		setAsNew(qry, tblName)
		cmd.Connection = sqlConn
		cmd.CommandType = CommandType.Text
		cmd.CommandText = Nothing

		qry = "UPDATE " & tblName & " SET wDay='" & i_wDay.Text & "', weekID='" & i_weekID.Text & "' WHERE wID=" & i_hidden.Value & ""

		connect(qry)
		cmd.CommandText = qry
		cmd.ExecuteNonQuery()

		pnlEdit.Visible = False

		Response.Redirect("PopulateDay.aspx")
	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Dim l_report As String = ""
		Dim tblName As String = "tbl_WDay"
		setAsNew(qry, tblName)

		cmd.Connection = sqlConn
		sqlConn.Open()

		qry = "SELECT TOP 21 * FROM [CarrierDiserPortal].[dbo].[tbl_WDay] ORDER BY wID DESC"

		connect(qry)
		setAsNew(qry, tblName)
		Dim RS = cmd.ExecuteReader

		l_report = "<table><tr><td>#</td><td>Date</td><td>Week ID</td><td>Action</td></tr>"
		l_report = l_report & "<tr><td colspan='4' align='right'><a href='PopulateDay.aspx?action=add'>ADD</a></td></tr>"
		Do While RS.Read()
				l_report = l_report & "<tr><td>" & RS("wID") & "</td><td>" & RS("wDay") & "</td><td>" & RS("weekID") & "</td><td align='right'><a href='PopulateDay.aspx?action=edit&rec=" & RS("wID") & "'>EDIT</a></td></tr>"
		Loop
		l_report = l_report & "</table>"

		RS.Close()
		RS = Nothing

		Me.litWDTable.Text = l_report.ToString

		If Request("action") = "add" And IsPostBack = False Then
			pnlAdd.Visible = True
		End If

		If Request("action") = "edit" And IsPostBack = False Then
			qry = "SELECT * FROM [CarrierDiserPortal].[dbo].[tbl_WDay] WHERE wID=" & Request("rec")

			connect(qry)
			setAsNew(qry, tblName)
			Dim editRS = cmd.ExecuteReader

			pnlEdit.Visible = True

			Do While editRS.Read()
					Me.i_wDay.Text = editRS("wDay").ToString
					Me.i_weekID.Text = editRS("weekID").ToString
					i_hidden.Value = editRS("wID").ToString
			Loop

			editRS.Close()
			editRS = Nothing
		End If

		sqlConn.Close()

	End Sub

End Class