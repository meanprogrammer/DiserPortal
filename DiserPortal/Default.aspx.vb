Public Class _Default
    Inherits System.Web.UI.Page

    Public conn As New clsConn
    Public ed As New clsED

    Public where As String
    Public formatToSave As String = "yyyy/MM/dd"
    Public formatToShow As String = "MMM dd, yyyy"

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
        'clear 
        lbleMsg1.Text = ""

        If Page.IsValid = True Then
            'If txtUname.Text = "admin" Then
            '    If txtPwd.Text.Trim = "12345678" Then
            '        Session("userID") = "1"
            '        Response.Redirect("~/Homepage.aspx")
            '    Else
            '        lbleMsg1.Text = "Authentication Failed."
            '        Exit Sub
            '    End If
            'Else
            '    lbleMsg1.Text = "Invalid User"
            '    Exit Sub
            'End If

            'get details
            With conn
                On Error GoTo errHandler

				Dim retVal(6), retFld(6) As String
                retFld(0) = "pwd"
                retFld(1) = "userID"
                retFld(2) = "lockedCount"
                retFld(3) = "loginStatusID"
                retFld(4) = "accessRights"
				retFld(5) = "lockedDate"
				retFld(6) = "accntTypeID"

                where = "uname = '" & txtUname.Text.Trim & "'"

				Dim checkInput As String = .checkID("vw_Login", "*", where, 7, retVal, retFld, "", "")

                Dim pword As String = ed.DecryptData(retVal(0))
                Dim lockedCount As Integer = retVal(2)
                Dim uStatID As Integer = retVal(3)
                Dim lastLogged As String = retVal(5)
                Dim accessRights As String = retVal(4)

				Session("userID") = retVal(1)
				Session("accntTypeID") = retVal(6)

                'valid user
                If checkInput = "True" Then
                    'valid pwd
                    If txtPwd.Text.Trim = pword Then
                        'check if locked_count = 3
                        If lockedCount = 5 Then
                            checkLockedCount(lockedCount, lastLogged)

                        Else
                            'check if inactive
                            If uStatID = "2" Then
                                lbleMsg1.Text = "Account is Inactive, Please contact your administrator."
                                Session.Clear()
                                Exit Sub
                            End If


                            'check if new user
                            'prompt to change password and select security question
                            If uStatID = "5" Then
                                Session("accessRights") = accessRights
                                Response.Redirect("~/NewUser.aspx")
                            End If


							' clear any un-finished reports on log-in
							'.deleteRecord("tbl_Sales", "userID=" & Session("userID"))
							'.deleteRecord("tbl_Competitor", "userID=" & Session("userID"))
							'.deleteRecord("tbl_Inventory", "userID=" & Session("userID"))
							'.deleteRecord("tbl_Stocks", "userID=" & Session("userID"))
							' allow user on system
                            updateLogin(0)
							Session("accessRights") = accessRights
							Response.Redirect("~/HomePage.aspx")
                        End If

					Else
						' invalid password
						checkLockedCount(lockedCount, lastLogged)
						txtUname.Focus()
						Exit Sub
                    End If

				Else
					'unauthorized user
					lbleMsg1.Text = "Unauthorized User!"  'checkInput
					Exit Sub
                End If
                Exit Sub

errHandler:
                If InStr(pword, "error!!!", CompareMethod.Text) <> 0 Then
                    lbleMsg1.Text = pword
                End If
            End With
        End If
    End Sub

    Public Sub checkLockedCount(ByVal lockedCount As Integer, ByVal lastLogged As String)
        If lockedCount = 5 Then
            txtPwd.CssClass = "txtError"

            If lastLogged = "" Then
                lbleMsg1.Text = "<img id='err1' style='cursor:help' " _
                            & "src='images/icons/lock.png'/> " _
                            & "Locked Account!" _
                            & "<br />Please contact your administrator."

            Else
                If IsDate(lastLogged) = True Then
                    lbleMsg1.Text = "<img id='err1' style='cursor:help' " _
                            & "src='images/icons/lock.png'/> " _
                            & "Locked Account since " & Format(CDate(lastLogged), formatToShow) _
                            & "<br />Please contact your administrator."
                Else
                    lbleMsg1.Text = "<img id='err1' style='cursor:help' " _
                            & "src='images/icons/lock.png'/> " _
                            & "Locked Account!" _
                            & "<br />Please contact your administrator."
                End If
            End If

            Session.Clear()
            Exit Sub

        Else
            updateLogin(lockedCount + 1)

            If lockedCount + 1 = 5 Then
                lbleMsg1.Text = "<img id='err1' style='cursor:help' " _
                            & "src='images/icons/lock.png'/> " _
                            & "Your account is locked!" _
                            & "<br />Please contact your administrator."
            Else
                lbleMsg1.Text = "Authentication Failed!"
            End If

            Exit Sub
        End If
    End Sub

    Public Sub updateLogin(ByVal lockedCount As Integer)
        Dim lStat As Integer
        Dim dtNow As String = ""

        If lockedCount = 5 Then
			lStat = 3
            dtNow = Format(Now, formatToSave)
        Else
            lStat = 1
            dtNow = ""
        End If

        Dim fld(2), val(2), dt(2) As String

        fld(0) = "lockedCount"
        fld(1) = "loginStatusID"
        fld(2) = "lockedDate"

        val(0) = lockedCount
        val(1) = lStat
        val(2) = dtNow

        dt(0) = "N"
        dt(1) = "N"
        dt(2) = "C"

        where = "userID = " & Session("userID")
        conn.UpdateDB("tbl_Login", fld, val, dt, where)
    End Sub

	Protected Sub lkbForgot_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lkbForgot.Click
	   If txtUname.Text.Trim = "" Then
		  lbleMsg1.Text = "Kindly input your username."
		 Exit Sub

		Else
			'check if username is valid
			With conn
				Dim retFld(4), retVal(4) As String
				retFld(0) = "userID"
				retFld(1) = "loginStatusID"
				retFld(2) = "lockedDate"
				retFld(3) = "lockedCount"
				retFld(4) = "questionID"

				where = "uname = '" & txtUname.Text & "'"

				'invalid uname
				If .checkID("vw_Login", "*", where, 5, retVal, retFld, "", "") = "False" Then
					lbleMsg1.Text = "Invalid user."
					txtUname.Focus()
					Exit Sub

					'valid uname
				Else
					If retVal(1) = "3" Then
						checkLockedCount(retVal(3), retVal(2))

					ElseIf retVal(1) = "5" Then
					   lbleMsg1.Text = "New Users should log in to update their password and security info first."
						Exit Sub

					ElseIf retVal(4).Trim = "" Then
						lbleMsg1.Text = "Security details has not been updated. Please contact your administrator."
						Exit Sub

					Else
						Session.Add("userID", retVal(0))
						Response.Redirect("~/SecurityQuestion.aspx")
					End If
				End If
			End With
		End If
	End Sub

	Private Sub _Default_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		Session.Clear()

		'If Page.IsPostBack = False Then
		'    Session.Clear()
		'End If
	End Sub

	Protected Sub btnLogin0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin0.Click
		'Enter any Date in MDY format

		Dim dtNow1 As DateTime = CDate(txtUname.Text) 'Date.Parse("10/11/2013")
		Dim nowdayofweek As Integer = dtNow1.DayOfWeek
		Dim weekStartDate, weekEndDate As DateTime

		weekStartDate = DateAdd("d", 0 - dtNow1.DayOfWeek, dtNow1)
		weekEndDate = DateAdd("d", 6 - dtNow1.DayOfWeek, dtNow1)

		'Displays first day of the week 
		lbleMsg1.Text = "Start Date: " & Format(weekStartDate, "MMM dd, yyyy") & " End Date: " & Format(weekEndDate, "MMM dd, yyyy")
	End Sub
End Class