Public Class Site_blank
	Inherits System.Web.UI.MasterPage

	Public conn As New clsConn
	Public where As String

	Public Sub RegisterPostbackTrigger(ByVal triggerOn As Control)
		ScriptManager2.RegisterPostBackControl(triggerOn)
	End Sub

	Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		If Page.IsPostBack = False Then
			checkSession()

			' get URL reference for session extension and plug in refresh values on meta
			Dim l_refresh_url As String = HttpContext.Current.Request.Url.AbsoluteUri
			Dim metaKey As New HtmlMeta()
			metaKey.HttpEquiv = "Refresh"
			metaKey.Content = 3570 & "; url=../RefreshSession.aspx?ref=" & l_refresh_url
			Page.Header.Controls.Add(metaKey)

			'get username
			Dim fname() As String
			Dim lname As String
			Dim retFld(1), retVal(1) As String

			retFld(0) = "fname"
			retFld(1) = "lname"

			where = "userID = " & Session("userID")
			conn.getValues("tbl_User", "userID, fname, lname", where, 2, retFld, retVal, "", "", "")

			If retVal(0) <> "" Then
				fname = Split(retVal(0), " ")
'				lblName.Text = "Hi " & fname(0) & "!"

			Else
				lname = retVal(1)
'				lblName.Text = "Hi " & lname & "!"
			End If

			checkRights()
		End If
	End Sub

	Public Sub checkRights()
		Dim aRyt() As String = Split(Session("accessRights"), "+")

		Dim cnt As Integer = 1
		Dim counter As Integer = 0

		Dim sCount As Integer = 0
		Dim rCount As Integer = 0
		Dim aCount As Integer = 0

		If Session("accessRights") <> "" Then
			Do While cnt <= UBound(aRyt) + 1
				'forms
				If aRyt(counter) = "SPF" Then
					sCount += 1
				End If

				If aRyt(counter) = "SCF" Then
					sCount += 1
				End If

				If aRyt(counter) = "SSF" Then
					sCount += 1
				End If

				If aRyt(counter) = "SIF" Then
					sCount += 1
				End If

				If aRyt(counter) = "VMF" Then
					'restrict act here
				End If

				If aRyt(counter) = "THF" Then
					'restrict act here
				End If

				If aRyt(counter) = "SF" Then
					'restrict act here
				End If


				'report
				If aRyt(counter) = "SPR" Then
					rCount += 1
				End If

				If aRyt(counter) = "SCR" Then
					rCount += 1
				End If

				If aRyt(counter) = "SSR" Then
					rCount += 1
				End If

				If aRyt(counter) = "SIR" Then
					rCount += 1
				End If


				If aRyt(counter) = "VMR" Then
					'restrict act here
				End If

				If aRyt(counter) = "THR" Then
					'restrict act here
				End If

				If aRyt(counter) = "SR" Then
					'restrict act here
				End If


				'ADMIN
				If aRyt(counter) = "AD" Then
					aCount += 1
				End If

				If aRyt(counter) = "AA" Then
					aCount += 1
				End If

				If aRyt(counter) = "AC" Then
					aCount += 1
				End If

				cnt += 1
				counter += 1
			Loop

'			If NavigationMenu.Items.Count = 4 Then
				If sCount = 0 Then
'					NavigationMenu.Items.Remove(NavigationMenu.Items(1))
				End If

				If rCount = 0 Then
'					NavigationMenu.Items.Remove(NavigationMenu.Items(2))
				End If

				If aCount = 0 Then
'					NavigationMenu.Items.Remove(NavigationMenu.Items(3))
				End If
'			End If
		End If
	End Sub

	Public Sub checkSession()
		If Session("userID") Is Nothing Then
			'set logout details
			'get id from a hidden label on mstr

			Session.Clear()
			Response.Redirect("~/Default.aspx")
		End If
	End Sub

'	Protected Sub NavigationMenu_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles NavigationMenu.MenuItemClick
'		checkSession()
'	End Sub
End Class