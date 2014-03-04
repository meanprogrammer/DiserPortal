Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization

Public Class populateweek
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
		Dim tblName As String = "tbl_Week"
		setAsNew(qry, tblName)
		cmd.Connection = sqlConn
		cmd.CommandType = CommandType.Text
		cmd.CommandText = Nothing

		Dim dtFrom As DateTime = DateTime.ParseExact(a_wFrom.Text, "M/d/yyyy", CultureInfo.InvariantCulture)
		Dim dtTo As DateTime = DateTime.ParseExact(a_wTo.Text, "M/d/yyyy", CultureInfo.InvariantCulture)
		Dim newDateFrom As String = dtFrom.ToString("d/M/yyyy")
		Dim newDateTo As String = dtTo.ToString("d/M/yyyy")

		qry = "INSERT INTO " & tblName & " (wFrom,wTo,weekCoverage,wYear,wMonthID,wNo,wStatus) VALUES ('" & newDateFrom & "','" & newDateTo & "','" & a_weekCoverage.Text & "','" & a_wYear.Text & "','" & a_wMonthID.Text & "','" & a_wNo.Text & "','1')"

		connect(qry)
		cmd.CommandText = qry
		cmd.ExecuteNonQuery()

		pnlAdd.Visible = False

		Response.Redirect("PopulateWeek.aspx")
	End Sub

	Private Sub submit_edit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles submit_edit.Click

		qry = ""
		Dim tblName As String = "tbl_Week"
		setAsNew(qry, tblName)
		cmd.Connection = sqlConn
		cmd.CommandType = CommandType.Text
		cmd.CommandText = Nothing

		Dim dtFrom As DateTime = DateTime.ParseExact(i_wFrom.Text, "M/d/yyyy", CultureInfo.InvariantCulture)
		Dim dtTo As DateTime = DateTime.ParseExact(i_wTo.Text, "M/d/yyyy", CultureInfo.InvariantCulture)
		Dim newDateFrom As String = dtFrom.ToString("d/M/yyyy")
		Dim newDateTo As String = dtTo.ToString("d/M/yyyy")

		qry = "UPDATE " & tblName & " SET wFROM='" & newDateFrom & "', wTo='" & newDateTo & "', weekCoverage='" & i_weekCoverage.Text & "', wYear='" & i_wYear.Text & "', wMonthID='" & i_wMonthID.Text & "', wNo='" & i_wNo.Text & "', wStatus='1' WHERE weekID=" & i_hidden.Value & ""

		connect(qry)
		cmd.CommandText = qry
		cmd.ExecuteNonQuery()

		pnlEdit.Visible = False

		Response.Redirect("PopulateWeek.aspx")
	End Sub

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

		Dim l_report As String = ""
		Dim tblName As String = "tbl_Week"
		Dim l_counter As Int32 = 0
		setAsNew(qry, tblName)

		cmd.Connection = sqlConn
		sqlConn.Open()

		qry = "SELECT * FROM [CarrierDiserPortal].[dbo].[tbl_Week] ORDER BY weekID DESC"

		connect(qry)
		setAsNew(qry, tblName)
		Dim RS = cmd.ExecuteReader

		l_report = "<table><tr><td>#</td><td>From</td><td>To</td><td>Week Coverage</td><td>Year</td><td>Month ID</td><td>Week No.</td><td>Action</td></tr>"
		l_report = l_report & "<tr><td colspan='8' align='right'><a href='PopulateWeek.aspx?action=add'>ADD</a></td></tr>"
		Do While RS.Read() And l_counter < 15
			l_counter = l_counter + 1
			Dim dtFrom As DateTime = DateTime.ParseExact(RS("wFrom"), "d/M/yyyy", CultureInfo.InvariantCulture)
			Dim dtTo As DateTime = DateTime.ParseExact(RS("wTo"), "d/M/yyyy", CultureInfo.InvariantCulture)
			Dim newDateFrom As String = dtFrom.ToString("M/d/yyyy")
			Dim newDateTo As String = dtTo.ToString("M/d/yyyy")
			l_report = l_report & "<tr><td>" & RS("weekID") & "</td><td>" & newDateFrom & "</td><td>" & newDateTo & "</td><td>" & RS("weekCoverage") & "</td><td>" & RS("wYear") & "</td><td>" & RS("wMonthID") & "</td><td>" & RS("wNo") & "</td><td align='right'><a href='PopulateWeek.aspx?action=edit&rec=" & RS("weekID") & "'>EDIT</a></td></tr>"
		Loop
		l_report = l_report & "</table>"

		RS.Close()
		RS = Nothing

		Me.litWkTable.Text = l_report.ToString

		If Request("action") = "add" And IsPostBack = False Then
			pnlAdd.Visible = True
		End If

		If Request("action") = "edit" And IsPostBack = False Then
			qry = "SELECT * FROM [CarrierDiserPortal].[dbo].[tbl_Week] WHERE weekID=" & Request("rec")

			connect(qry)
			setAsNew(qry, tblName)
			Dim editRS = cmd.ExecuteReader

			pnlEdit.Visible = True

			Do While editRS.Read()
				Dim dtFrom As DateTime = DateTime.ParseExact(editRS("wFrom"), "d/M/yyyy", CultureInfo.InvariantCulture)
				Dim dtTo As DateTime = DateTime.ParseExact(editRS("wTo"), "d/M/yyyy", CultureInfo.InvariantCulture)
				Dim newDateFrom As String = dtFrom.ToString("M/d/yyyy")
				Dim newDateTo As String = dtTo.ToString("M/d/yyyy")

				Me.i_wFrom.Text = newDateFrom.ToString
				Me.i_wTo.Text = newDateTo.ToString
				Me.i_weekCoverage.Text = editRS("weekCoverage").ToString
				Me.i_wYear.Text = editRS("wYear").ToString
				Me.i_wMonthID.Text = editRS("wMonthID").ToString
				Me.i_wNo.Text = editRS("wNo").ToString
				i_hidden.Value = editRS("weekID").ToString
			Loop

			editRS.Close()
			editRS = Nothing
		End If


		sqlConn.Close()

	End Sub

End Class