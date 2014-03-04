Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class Admin
	Inherits System.Web.UI.Page

	Public conn As New clsConn
	Public ed As New clsED
	Public jc As New clsObject

	Public where As String
	Public mstr As New MasterPage

	Public formatToSave As String = "d/M/yyyy"
	Public formatToShow As String = "MMM dd, yyyy"

	Public sBtn = Drawing.Color.Yellow

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

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
		System.Threading.Thread.Sleep(500)

		If Page.IsPostBack = False Then
			With conn
				checkSession()
				checkRights()
			End With
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

			Dim navMenu As Menu = mstr.FindControl("NavigationMenu")

			If sCount = 0 Then
				navMenu.Items.Remove(navMenu.Items(1))
			End If

			If rCount = 0 Then
				navMenu.Items.Remove(navMenu.Items(2))
			End If

			If aCount = 0 Then
				navMenu.Items.Remove(navMenu.Items(3))
			End If
		End If
	End Sub

	Protected Sub ddlAType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlAType.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		If ddlAType.SelectedValue.Trim = "" Then
			ddlAType.Enabled = True
			btnCreate.Text = "Create"
			btnCancel.Visible = False

			clearItems()
			disablePage()

		Else
			btnCreate.Text = "Modify"
			btnCancel.Visible = False
			ddlAType.Enabled = True
			disablePage()

			'retrieve designation's rights
			clearItems()
			SetRights()
		End If
	End Sub

	Public Sub SetRights()
		With conn
			Dim retFld(0), retVal(0) As String
			retFld(0) = "accessRights"

			where = "accntTypeID = " & ddlAType.SelectedValue.Trim
			.getValues("tbl_AccntType", "*", where, 1, retFld, retVal, "", "", "")

			Dim ryt() As String = Split(retVal(0), "+")
			Dim cnt As Integer = 1
			Dim counter As Integer = 0

			Do While cnt <= UBound(ryt) + 1
				'form
				If ryt(counter) = "SPF" Then
					chkFProd.Checked = True
				End If

				If ryt(counter) = "SCF" Then
					chkFCompete.Checked = True
				End If

				If ryt(counter) = "SSF" Then
					chkFStocks.Checked = True
				End If

				If ryt(counter) = "SIF" Then
					chkFInventory.Checked = True
				End If

				If ryt(counter) = "VMF" Then
					chkFVisual.Checked = True
				End If

				If ryt(counter) = "THF" Then
					chkFTrade.Checked = True
				End If

				If ryt(counter) = "SF" Then
					chkFSupport.Checked = True
				End If


				'report
				If ryt(counter) = "SPR" Then
					chkRProd.Checked = True
				End If

				If ryt(counter) = "SCR" Then
					chkRCompete.Checked = True
				End If

				If ryt(counter) = "SSR" Then
					chkRStocks.Checked = True
				End If

				If ryt(counter) = "SIR" Then
					chkRInventory.Checked = True
				End If

				If ryt(counter) = "TMS" Then
					chkRTM.Checked = True
				End If

				If ryt(counter) = "VMR" Then
					chkRVisual.Checked = True
				End If

				If ryt(counter) = "THR" Then
					chkRTrade.Checked = True
				End If

				If ryt(counter) = "SR" Then
					chkRSupport.Checked = True
				End If


				'admin
				If ryt(counter) = "AD" Then
					chkData.Checked = True
				End If

				If ryt(counter) = "AA" Then
					chkAnnounce.Checked = True
				End If

				If ryt(counter) = "AC" Then
					chkContent.Checked = True
				End If

				cnt += 1
				counter += 1
			Loop

			'check if all sub cat are selected
			'form
			If chkFProd.Checked = True _
				And chkFCompete.Checked = True _
				And chkFStocks.Checked = True _
				And chkFInventory.Checked = True Then

				chkFSales.Checked = True

			Else
				chkFSales.Checked = False
			End If

			'report
			If chkRProd.Checked = True _
				And chkRCompete.Checked = True _
				And chkRStocks.Checked = True _
				And chkRInventory.Checked = True _
				And chkRTM.Checked = True Then

				chkRSales.Checked = True

			Else
				chkRSales.Checked = False
			End If
		End With
	End Sub

	Public Sub clearItems()
		'form
		chkFSales.Checked = False
		chkFProd.Checked = False
		chkFCompete.Checked = False
		chkFStocks.Checked = False
		chkFInventory.Checked = False

		chkFVisual.Checked = False
		chkFTrade.Checked = False
		chkFSupport.Checked = False

		'report
		chkRSales.Checked = False
		chkRProd.Checked = False
		chkRCompete.Checked = False
		chkRStocks.Checked = False
		chkRInventory.Checked = False
		chkRTM.Checked = False

		chkRVisual.Checked = False
		chkRTrade.Checked = False
		chkRSupport.Checked = False

		'account
		chkData.Checked = False
		chkAnnounce.Checked = False
		chkContent.Checked = False
	End Sub

	Public Sub disablePage()
		'form
		chkFSales.Enabled = False
		chkFProd.Enabled = False
		chkFCompete.Enabled = False
		chkFStocks.Enabled = False
		chkFInventory.Enabled = False

		chkFVisual.Enabled = False
		chkFTrade.Enabled = False
		chkFSupport.Enabled = False

		'report
		chkRSales.Enabled = False
		chkRProd.Enabled = False
		chkRCompete.Enabled = False
		chkRStocks.Enabled = False
		chkRInventory.Enabled = False
		chkRTM.Enabled = False

		chkRVisual.Enabled = False
		chkRTrade.Enabled = False
		chkRSupport.Enabled = False

		'account
		chkData.Enabled = False
		chkAnnounce.Enabled = False
		chkContent.Enabled = False
	End Sub

	Public Sub enablePage()
		'form
		chkFSales.Enabled = True
		chkFProd.Enabled = True
		chkFCompete.Enabled = True
		chkFStocks.Enabled = True
		chkFInventory.Enabled = True

		chkFVisual.Enabled = True
		chkFTrade.Enabled = True
		chkFSupport.Enabled = True

		'report
		chkRSales.Enabled = True
		chkRProd.Enabled = True
		chkRCompete.Enabled = True
		chkRStocks.Enabled = True
		chkRInventory.Enabled = True
		chkRTM.Enabled = True

		chkRVisual.Enabled = True
		chkRTrade.Enabled = True
		chkRSupport.Enabled = True

		'account
		chkData.Enabled = True
		chkAnnounce.Enabled = True
		chkContent.Enabled = True
	End Sub

	Protected Sub lnkAType_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAType.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		panAType.Visible = True
		panData.Visible = False
		panAnnounce.Visible = False
		panAccount.Visible = False
		panSupport.Visible = False

		lnkAType.CssClass = "tabprop-Selected"
		lnkData.CssClass = "tabprop"
		lnkAnnounce.CssClass = "tabprop"
		lnkAccnt.CssClass = "tabprop"
		lnkSupport.CssClass = "tabprop"

		conn.loadToDropDownList("tbl_AccntType", ddlAType, False, "*", "", "accntTypeID", "accntType", "accntType", "")
	End Sub

	Protected Sub lnkData_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkData.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		If Session("userID") = "2" Then
			btnHSA.Visible = True
			txtSA.Visible = True
		Else
			btnHSA.Visible = False
			txtSA.Visible = False
		End If

		panAType.Visible = False
		panData.Visible = True
		panAnnounce.Visible = False
		panAccount.Visible = False
		panSupport.Visible = False

		lnkAType.CssClass = "tabprop"
		lnkData.CssClass = "tabprop-Selected"
		lnkAnnounce.CssClass = "tabprop"
		lnkAccnt.CssClass = "tabprop"
		lnkSupport.CssClass = "tabprop"

		With conn
			'product
			.loadToDropDownList("tbl_AccntType", ddlAType, False, "*", "", "accntTypeID", "accntType", "accntType", "")
			.loadToListBox("tbl_Product", lstProd, False, "*", "productID", "product", "", "product", "")

			'brand
			.loadToDropDownList("tbl_Product", ddlBProd, False, "*", "", "productID", "product", "product", "")

			'item
			.loadToDropDownList("tbl_Product", ddliProd, False, "*", "", "productID", "product", "product", "")
			.loadToDropDownList("tbl_Variant", ddliVariant, False, "*", "", "variantID", "variant", "variant", "")

			'model
			.loadToDropDownList("tbl_Brand", ddlMBrand, False, "*", "", "brandID", "brand", "brand", "")
			'.loadToListBox("vw_Model", lstModel, False, "*", "modelID", "pbModel", "", "pbModel", "")

			'region
			.loadToDropDownList("tbl_Region", ddlCRegion, False, "*", "", "regionID", "region", "region", "")
		End With

		btnHGeneral.BackColor = sBtn
		btnHGeneral.Font.Bold = True

		btnCity.BackColor = sBtn
		btnCity.Font.Bold = True

		Session("cityID") = Nothing
	End Sub

	Protected Sub btnCreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreate.Click
		System.Threading.Thread.Sleep(500)

		If btnCreate.Text = "Create" Then
			btnCreate.Text = "Save"
			btnCancel.Visible = True
			ddlAType.Visible = False
			txtAType.Visible = True
			txtAType.Text = ""

			enablePage()
			clearItems()

		ElseIf btnCreate.Text = "Modify" Then
			btnCreate.Text = "Update"
			btnCancel.Visible = True
			ddlAType.Visible = False
			txtAType.Text = ddlAType.SelectedItem.Text
			txtAType.Visible = True

			enablePage()
			SetRights()

		ElseIf btnCreate.Text = "Save" Then
			If txtAType.Text.Trim = "" Then
				lbleMsg.Text = "Kindly enter the User Account Name."
				Exit Sub

			Else
				'check for duplicate
				With conn
					Dim retVal(0), retFld(0) As String

					where = "accntType = '" & txtAType.Text.Trim & "'"
					If .checkID("tbl_AccntType", "accntType", where, 0, retVal, retFld, "", "") = "True" Then
						lbleMsg.Text = "Account Type already exist."
						Exit Sub

					Else
						saveAccount()
						disablePage()

						'retrieve accntTypeID
						ReDim retFld(0), retVal(0)
						retFld(0) = "accntTypeID"

						where = "accntType = '" & txtAType.Text.Trim & "'"
						.getValues("tbl_AccntType", "*", where, 1, retFld, retVal, "", "", "")

						ddlAType.Items.Clear()
						.loadToDropDownList("tbl_AccntType", ddlAType, False, "*", where, "accntTypeID", "accntType", "accntType", "")
						ddlAType.SelectedValue = retVal(0)
						ddlAType.Visible = True

						txtAType.Text = ""
						txtAType.Visible = False

						btnCreate.Text = "Modify"
						btnCancel.Visible = False
					End If
				End With
			End If

		ElseIf btnCreate.Text = "Update" Then
			If txtAType.Text.Trim = "" Then
				lbleMsg.Text = "Kindly enter the User Account Name."
				Exit Sub

			Else
				With conn
					'check for duplicate
					Dim retVal(0), retFld(0) As String

					where = "accntTypeID <> " & ddlAType.SelectedValue.Trim & " AND accntType = '" & txtAType.Text.Trim & "'"
					If .checkID("tbl_AccntType", "accntTypeID, accntType", where, 1, retVal, retFld, "", "") = "True" Then
						lbleMsg.Text = "A duplicate has been identified. Kindly change the User Account Name."
						Exit Sub

					Else
						updateAccount()
						disablePage()

						Dim id As Integer = ddlAType.SelectedValue.Trim
						ddlAType.Items.Clear()
						.loadToDropDownList("tbl_AccntType", ddlAType, False, "*", "", "accntTypeID", "accntType", "accntType", "")
						ddlAType.SelectedValue = id
						ddlAType.Visible = True

						txtAType.Text = ""
						txtAType.Visible = False

						btnCreate.Text = "Modify"
						btnCancel.Visible = False
					End If
				End With
			End If
		End If
	End Sub

	Public Sub updateAccount()
		With conn
			Dim fld(1), val(1), dt(1) As String

			fld(0) = "accntType"
			fld(1) = "accessRights"

			dt(0) = "C"
			dt(1) = "C"

			val(0) = Replace(txtAType.Text.Trim, "'", "")
			val(1) = retrieveCheckedItems()

			where = "accntTypeID = " & ddlAType.SelectedValue.Trim
			.UpdateDB("tbl_AccntType", fld, val, dt, where)
		End With
	End Sub

	Public Sub saveAccount()
		With conn
			Dim field, values As String

			field = "accountType, accessRights"
			values = retrieveCheckedItems()

			.saveInfo("tbl_AccntType", field, values)
		End With
	End Sub

	Public Function retrieveCheckedItems() As String
		Dim values As String = ""

		'FORMS
		If chkFProd.Checked = True Then
			If values = "" Then
				values += "SPF"
			Else
				values += "+SPF"
			End If
		End If

		If chkFCompete.Checked = True Then
			If values = "" Then
				values += "SCF"
			Else
				values += "+SCF"
			End If
		End If

		If chkFStocks.Checked = True Then
			If values = "" Then
				values += "SSF"
			Else
				values += "+SSF"
			End If
		End If

		If chkFInventory.Checked = True Then
			If values = "" Then
				values += "SIF"
			Else
				values += "+SIF"
			End If
		End If

		If chkFVisual.Checked = True Then
			If values = "" Then
				values += "VMF"
			Else
				values += "+VMF"
			End If
		End If

		If chkFTrade.Checked = True Then
			If values = "" Then
				values += "THF"
			Else
				values += "+THF"
			End If
		End If

		If chkFSupport.Checked = True Then
			If values = "" Then
				values += "SF"
			Else
				values += "+SF"
			End If
		End If


		'REPORT
		If chkRProd.Checked = True Then
			If values = "" Then
				values += "SPR"
			Else
				values += "+SPR"
			End If
		End If

		If chkRCompete.Checked = True Then
			If values = "" Then
				values += "SCR"
			Else
				values += "+SCR"
			End If
		End If

		If chkRStocks.Checked = True Then
			If values = "" Then
				values += "SSR"
			Else
				values += "+SSR"
			End If
		End If

		If chkRInventory.Checked = True Then
			If values = "" Then
				values += "SIR"
			Else
				values += "+SIR"
			End If
		End If

		If chkRTM.Checked = True Then
			If values = "" Then
				values += "TMS"
			Else
				values += "+TMS"
			End If
		End If

		If chkRVisual.Checked = True Then
			If values = "" Then
				values += "VMR"
			Else
				values += "+VMR"
			End If
		End If

		If chkRTrade.Checked = True Then
			If values = "" Then
				values += "THR"
			Else
				values += "+THR"
			End If
		End If

		If chkRSupport.Checked = True Then
			If values = "" Then
				values += "SR"
			Else
				values += "+SR"
			End If
		End If


		'ADMIN
		If chkData.Checked = True Then
			If values = "" Then
				values += "AD"
			Else
				values += "+AD"
			End If
		End If

		If chkAnnounce.Checked = True Then
			If values = "" Then
				values += "AA"
			Else
				values += "+AA"
			End If
		End If

		If chkContent.Checked = True Then
			If values = "" Then
				values += "AC"
			Else
				values += "+AC"
			End If
		End If

		retrieveCheckedItems = values
	End Function

	Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
		System.Threading.Thread.Sleep(500)

		If ddlAType.SelectedValue.Trim = "" Then
			clearItems()
			disablePage()

			ddlAType.Visible = True
			txtAType.Visible = False

			btnCancel.Visible = False
			btnCreate.Text = "Create"

		Else
			SetRights()
			disablePage()
			txtAType.Text = ""
			txtAType.Visible = False

			ddlAType.Visible = True
			btnCancel.Visible = True
			btnCreate.Text = "Modify"
		End If
	End Sub

	Protected Sub chkFSales_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkFSales.CheckedChanged
		System.Threading.Thread.Sleep(500)

		If chkFSales.Checked = False Then
			chkFSales.Checked = False
			chkFProd.Checked = False
			chkFCompete.Checked = False
			chkFStocks.Checked = False
			chkFInventory.Checked = False

		Else
			chkFSales.Checked = True
			chkFProd.Checked = True
			chkFCompete.Checked = True
			chkFStocks.Checked = True
			chkFInventory.Checked = True
		End If
	End Sub

	Protected Sub chkRSales_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkRSales.CheckedChanged
		System.Threading.Thread.Sleep(500)

		If chkRSales.Checked = False Then
			chkRSales.Checked = False
			chkRProd.Checked = False
			chkRCompete.Checked = False
			chkRStocks.Checked = False
			chkRInventory.Checked = False
			chkRTM.Checked = False
		Else
			chkRSales.Checked = True
			chkRProd.Checked = True
			chkRCompete.Checked = True
			chkRStocks.Checked = True
			chkRInventory.Checked = True
			chkRTM.Checked = True
		End If
	End Sub

	Protected Sub chkFProd_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkFProd.CheckedChanged
		System.Threading.Thread.Sleep(500)

		If chkFProd.Checked = True _
			And chkFCompete.Checked = True _
			And chkFStocks.Checked = True _
			And chkFInventory.Checked = True Then

			chkFSales.Checked = True

		Else
			chkFSales.Checked = False
		End If
	End Sub

	Protected Sub chkFCompete_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkFCompete.CheckedChanged
		System.Threading.Thread.Sleep(500)

		If chkFProd.Checked = True _
			And chkFCompete.Checked = True _
			And chkFStocks.Checked = True _
			And chkFInventory.Checked = True Then

			chkFSales.Checked = True

		Else
			chkFSales.Checked = False
		End If
	End Sub

	Protected Sub chkFStocks_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkFStocks.CheckedChanged
		System.Threading.Thread.Sleep(500)

		If chkFProd.Checked = True _
			And chkFCompete.Checked = True _
			And chkFStocks.Checked = True _
			And chkFInventory.Checked = True Then

			chkFSales.Checked = True

		Else
			chkFSales.Checked = False
		End If
	End Sub

	Protected Sub chkFInventory_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkFInventory.CheckedChanged
		System.Threading.Thread.Sleep(500)

		If chkFProd.Checked = True _
			And chkFCompete.Checked = True _
			And chkFStocks.Checked = True _
			And chkFInventory.Checked = True Then

			chkFSales.Checked = True

		Else
			chkFSales.Checked = False
		End If
	End Sub

	Protected Sub chkRProd_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkRProd.CheckedChanged
		System.Threading.Thread.Sleep(500)

		If chkRProd.Checked = True _
		   And chkRCompete.Checked = True _
		   And chkRStocks.Checked = True _
		   And chkRInventory.Checked = True _
		   And chkRTM.Checked = True Then

			chkRSales.Checked = True

		Else
			chkRSales.Checked = False
		End If
	End Sub

	Protected Sub chkRCompete_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkRCompete.CheckedChanged
		System.Threading.Thread.Sleep(500)

		If chkRProd.Checked = True _
		   And chkRCompete.Checked = True _
		   And chkRStocks.Checked = True _
		   And chkRInventory.Checked = True _
		   And chkRTM.Checked = True Then

			chkRSales.Checked = True

		Else
			chkRSales.Checked = False
		End If
	End Sub

	Protected Sub chkRStocks_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkRStocks.CheckedChanged
		System.Threading.Thread.Sleep(500)

		If chkRProd.Checked = True _
		   And chkRCompete.Checked = True _
		   And chkRStocks.Checked = True _
		   And chkRInventory.Checked = True _
		   And chkRTM.Checked = True Then

			chkRSales.Checked = True

		Else
			chkRSales.Checked = False
		End If
	End Sub

	Protected Sub chkRInventory_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkRInventory.CheckedChanged
		System.Threading.Thread.Sleep(500)

		If chkRProd.Checked = True _
		   And chkRCompete.Checked = True _
		   And chkRStocks.Checked = True _
		   And chkRInventory.Checked = True _
		   And chkRTM.Checked = True Then

			chkRSales.Checked = True

		Else
			chkRSales.Checked = False
		End If
	End Sub

	Protected Sub chkRTM_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkRTM.CheckedChanged
		System.Threading.Thread.Sleep(500)

		If chkRProd.Checked = True _
		   And chkRCompete.Checked = True _
		   And chkRStocks.Checked = True _
		   And chkRInventory.Checked = True _
		   And chkRTM.Checked = True Then

			chkRSales.Checked = True

		Else
			chkRSales.Checked = False
		End If
	End Sub

	Public Sub checkSession()
		If Session("userID") Is Nothing Then
			Session.Clear()
			Response.Redirect("~/Default.aspx")
		End If
	End Sub

	Protected Sub imbAProd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAProd.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If txtProd.Text.Trim = "" Then
			lbleMsg.Text = "No item to save."
			Exit Sub

		ElseIf imbAProd.AlternateText = "Save" Then
			With conn
				'check for duplicate
				where = "product = '" & txtProd.Text.Trim & "'"

				If checkForDuplicate("tbl_Product", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					.saveInfo("tbl_Product", "product", "'" & Replace(txtProd.Text.Trim, "'", "''") & "'")

					lstProd.Items.Clear()
					.loadToListBox("tbl_Product", lstProd, False, "*", "productID", "product", "", "product", "")
				End If
			End With

			txtProd.Text = ""
			lstProd.Enabled = True

			imbAProd.AlternateText = "Save"

			imbMProd.AlternateText = "Modify"
			imbMProd.ImageUrl = "~/images/icons/modify.png"

		ElseIf imbAProd.AlternateText = "Update" Then
			With conn
				'check for duplicate
				where = "product = '" & txtProd.Text.Trim & "' AND productID <> " & lstProd.SelectedValue
				If checkForDuplicate("tbl_Product", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					Dim fld(0), val(0), dt(0) As String

					fld(0) = "product"
					val(0) = Replace(txtProd.Text.Trim, "'", "''")
					dt(0) = "C"

					where = "productID = " & lstProd.SelectedValue.Trim
					.UpdateDB("tbl_Product", fld, val, dt, where)

					lstProd.Items.Clear()
					.loadToListBox("tbl_Product", lstProd, True, "productID", "productID", "product", "", "product", "")
				End If
			End With

			txtProd.Text = ""

			lstProd.DataBind()
			lstProd.Enabled = True

			imbAProd.AlternateText = "Save"

			imbMProd.AlternateText = "Modify"
			imbMProd.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Public Function checkForDuplicate(ByVal tblName As String, ByVal where As String) As Boolean
		With conn
			'check for duplicate
			Dim retVal(0), retFld(0) As String

			If .checkID(tblName, "*", where, 0, retVal, retFld, "", "") = "True" Then
				checkForDuplicate = True

			Else
				checkForDuplicate = False
			End If
		End With
	End Function

	Protected Sub imbMProd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbMProd.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If lstProd.SelectedIndex = -1 Then
			txtAType.Text = ""
			lbleMsg.Text = "Please select an item to modify."
			Exit Sub

		ElseIf imbMProd.AlternateText = "Modify" Then
			txtProd.Text = lstProd.SelectedItem.Text
			lstProd.Enabled = False

			imbAProd.Enabled = True
			imbAProd.AlternateText = "Update"

			imbMProd.AlternateText = "Cancel"
			imbMProd.ImageUrl = "~/images/icons/cancel.png"


		ElseIf imbMProd.AlternateText = "Cancel" Then
			txtProd.Text = ""
			lstProd.Enabled = True

			imbAProd.Enabled = True
			imbAProd.AlternateText = "Save"

			imbMProd.AlternateText = "Modify"
			imbMProd.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub btnProd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnProd.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnProd.BackColor = sBtn
		btnProd.Font.Bold = True

		hidePanels()
		panProd.Visible = True
	End Sub

	Protected Sub btnBrand_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBrand.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnBrand.BackColor = sBtn
		btnBrand.Font.Bold = True

		hidePanels()
		panBrand.Visible = True
	End Sub

	Protected Sub btnModel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModel.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnModel.BackColor = sBtn
		btnModel.Font.Bold = True

		hidePanels()

		panModel.Visible = True
		Session("modelID") = Nothing

		conn.loadToDropDownList("tbl_Product", ddlMProd, False, "*", "", "productID", "product", "product", "")
		ddlMBrand.Items.Clear()
	End Sub

	Protected Sub btnItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnItem.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnItem.BackColor = sBtn
		btnItem.Font.Bold = True

		hidePanels()
		panItem.Visible = True
	End Sub

	Protected Sub btnCap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCap.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnCap.BackColor = sBtn
		btnCap.Font.Bold = True

		hidePanels()
		panCap.Visible = True

		Session("capID") = Nothing
		conn.loadToDropDownList("tbl_Product", ddlCProd, False, "*", "", "productID", "product", "product", "")
	End Sub

	Protected Sub btnVariant_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVariant.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnVariant.BackColor = sBtn
		btnVariant.Font.Bold = True

		hidePanels()
		panVariant.Visible = True

		conn.loadToListBox("tbl_Variant", lstVariant, False, "*", "variantID", "variant", "", "variant", "")
	End Sub

	Protected Sub btnDealer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDealer.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnDealer.BackColor = sBtn
		btnDealer.Font.Bold = True

		hidePanels()
		panDealer.Visible = True

		conn.loadToListBox("tbl_Dealer", lstDealer, False, "*", "dealerID", "dealer", "", "dealer", "")
	End Sub

	Protected Sub btnStore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStore.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnStore.BackColor = sBtn
		btnStore.Font.Bold = True

		hidePanels()
		panStore.Visible = True

		ddlSCDealer.Items.Clear()
		conn.loadToDropDownList("tbl_Dealer", ddlSCDealer, False, "*", "", "dealerID", "dealer", "dealer", "")

		ddlSCLoc.Items.Clear()

		ddlSCRegion.Items.Clear()
		conn.loadToDropDownList("tbl_Region", ddlSCRegion, False, "*", "", "regionID", "region", "region", "")

		Session("storeID") = Nothing
	End Sub

	Protected Sub btnCity_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCity.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnCity.BackColor = sBtn
		btnCity.Font.Bold = True

		hidePanels()
		panCity.Visible = True

		Session("cityID") = Nothing
	End Sub

	Protected Sub btnRegion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRegion.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnRegion.BackColor = sBtn
		btnRegion.Font.Bold = True

		hidePanels()
		panRegion.Visible = True

		Session("regionID") = Nothing
		conn.loadToListBox("tbl_Region", lstRegion, False, "*", "regionID", "region", "", "region", "")
	End Sub

	Protected Sub lnkAnnounce_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAnnounce.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		panAType.Visible = False
		panData.Visible = False
		panAnnounce.Visible = True
		panAccount.Visible = False
		panSupport.Visible = False

		lnkAType.CssClass = "tabprop"
		lnkData.CssClass = "tabprop"
		lnkAnnounce.CssClass = "tabprop-Selected"
		lnkAccnt.CssClass = "tabprop"
		lnkSupport.CssClass = "tabprop"
	End Sub

	Protected Sub ddlMBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlMBrand.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		If ddlMBrand.SelectedValue.Trim = "" Then
			ddlMProd.SelectedIndex = -1

		Else
			Dim retFld(0), retVal(0) As String
			retFld(0) = "product"

			where = "brandID = " & ddlBProd.SelectedValue.Trim
			conn.getValues("vw_Model", "*", where, 1, retFld, retVal, "", "", "")

			ddlMProd.SelectedItem.Text = retVal(0)
		End If
	End Sub

	Protected Sub imbPicAdd_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)

		checkSession()
		Response.Redirect("~/Admin/AFileUpload.aspx")
	End Sub

	Protected Sub grdAnnounce_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdAnnounce.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		Session("announceID") = grdAnnounce.DataKeys(grdAnnounce.SelectedIndex).Values(0).ToString()
		LoadDetails()
		retrievePic()

		panAData.Visible = True
	End Sub

	Public Sub enableAData()
		txtTitle.ReadOnly = False
		txtIntro.ReadOnly = False
		txtStory.ReadOnly = False
		rblPublish.Enabled = True
	End Sub

	Public Sub disableAData()
		txtTitle.ReadOnly = True
		txtIntro.ReadOnly = True
		txtStory.ReadOnly = True
		rblPublish.Enabled = False
	End Sub

	Public Sub retrievePic()
		With conn
			Dim retFld(0), retVal(0) As String
			retFld(0) = "thumbnail"

			where = "announceID = " & Session("announceID")
			.getValues("tbl_Announce", "", where, 1, retFld, retVal, "", "", "")

			Dim picPath = getPicPath()

			If retVal(0) = "" Then
				imgPic.ImageUrl = picPath & "announce.jpg"
				imbPicRemove.Visible = False
			Else
				imgPic.ImageUrl = picPath & retVal(0)
				imbPicRemove.Visible = True
			End If
		End With
	End Sub

	Public Function getPicPath() As String
		With conn
			'get storage path
			Dim retFld(0), retVal(0) As String

			retFld(0) = "announcePicPath"

			.getValues("tbl_Storage", "", "storageID = 1", 1, retFld, retVal, "", "", "")

			getPicPath = retVal(0)
		End With
	End Function

	Public Sub LoadDetails()
		With conn
			Dim retFld(7), retVal(7) As String

			retFld(0) = "aTitle"
			retFld(1) = "intro"
			retFld(2) = "story"

			retFld(3) = "dateCreated"
			retFld(4) = "cBy"
			retFld(5) = "lastUpdate"
			retFld(6) = "mBy"

			retFld(7) = "aStatusID"

			where = "announceID = " & Session("announceID")
			.getValues("vw_Announce", "*", where, 8, retFld, retVal, "", "", "")

			txtTitle.Text = retVal(0)
			txtIntro.Text = retVal(1)
			txtStory.Text = retVal(2)

			If retVal(3) <> "" Then
				If IsDate(retVal(3)) = True Then
					lblCDate.Text = Format(CDate(retVal(3)), formatToShow)
				Else
					lblCDate.Text = retVal(3)
				End If

			Else
				lblCDate.Text = ""
			End If

			lblCBy.Text = retVal(4)

			If retVal(5) <> "" Then
				iMDate.Visible = True
				If IsDate(retVal(5)) = True Then
					lblMDate.Text = Format(CDate(retVal(5)), formatToShow)
				Else
					lblMDate.Text = retVal(5)
				End If

			Else
				iMDate.Visible = False
				lblMDate.Text = ""
			End If

			If retVal(6) = "" Then
				lblMBy.Text = ""
				iMBy.Visible = False
			Else
				lblMBy.Text = retVal(6)
				iMBy.Visible = True
			End If

			If retVal(7) = "1" Then
				rblPublish.Items(0).Selected = True
				rblPublish.Items(1).Selected = False
			Else
				rblPublish.Items(1).Selected = True
				rblPublish.Items(0).Selected = False
			End If
		End With
	End Sub

	Protected Sub btnModify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModify.Click
		If btnModify.Text = "Modify" Then
			grdAnnounce.Enabled = False
			enableAData()

			btnModify.Text = "Update"
			btnACancel.Visible = True

		ElseIf btnModify.Text = "Update" Then
			If checkAData() = False Then
				Exit Sub

			Else
				System.Threading.Thread.Sleep(500)
				updateAnnounce()

				LoadDetails()
				grdAnnounce.DataBind()
				disableAData()

				grdAnnounce.Enabled = True
				btnModify.Text = "Modify"
				btnCancel.Visible = False
			End If

		ElseIf btnModify.Text = "Save" Then
			If checkAData() = False Then
				Exit Sub

			Else
				System.Threading.Thread.Sleep(500)
				saveAnnounce()

				LoadDetails()
				grdAnnounce.DataBind()
				disableAData()

				grdAnnounce.Enabled = True
				btnModify.Text = "Modify"
				btnCancel.Visible = False
				btnAddPic.Visible = True
			End If
		End If
	End Sub

	Public Sub saveAnnounce()
		With conn
			Dim field, values As String

			field = "aTitle, intro, story, userID, lastUpdate, dateCreated, mByID, aStatusID"
			values = "'" & Replace(txtTitle.Text.Trim, "'", "''") & "', '"

			If txtIntro.Text.Trim = "" Then
				values += Replace(Left(txtStory.Text.Trim, 200), "'", "''") & "', '"
			Else
				values += Replace(txtIntro.Text.Trim, "'", "''") & "', '"
			End If

			values += Replace(txtStory.Text.Trim, "'", "''") & "', " _
						& Session("userID") & ", '" _
						& Format(Now, formatToSave) & "', '" _
						& Format(Now, formatToSave) & "', " _
						& Session("userID") & ", "

			If rblPublish.Items(0).Selected = True Then
				values += "1"
			Else
				values += "2"
			End If

			.saveInfo("tbl_Announce", field, values)

			Dim retFld(0), retVal(0) As String
			retFld(0) = "announceID"

			where = "aTitle = '" & Replace(txtTitle.Text.Trim, "'", "''") & "' AND " _
						& "mByID = " & Session("userID")
			.getValues("tbl_Announce", "TOP 1 *", where, 1, retFld, retVal, "announceID", "DESC", "")

			Session("announceID") = retVal(0)
		End With
	End Sub

	Public Sub updateAnnounce()
		With conn
			Dim fld(5), val(5), dt(5) As String

			fld(0) = "aTitle"
			fld(1) = "intro"
			fld(2) = "story"
			fld(3) = "lastUpdate"
			fld(4) = "mByID"
			fld(5) = "aStatusID"

			dt(0) = "C"
			dt(1) = "C"
			dt(2) = "C"
			dt(3) = "C"
			dt(4) = "N"
			dt(5) = "N"

			val(0) = Replace(txtTitle.Text.Trim, "'", "''")

			If txtIntro.Text.Trim = "" Then
				val(1) = Left(txtStory.Text.Trim, 200)
			Else
				val(1) = txtIntro.Text.Trim
			End If

			val(2) = Replace(txtStory.Text.Trim, "'", "''")
			val(3) = Format(Now, formatToSave)
			val(4) = Session("userID")

			If rblPublish.Items(0).Selected = True Then
				val(5) = "1"
			Else
				val(5) = "2"
			End If

			where = "announceID = " & Session("announceID")
			.UpdateDB("tbl_Announce", fld, val, dt, where)
		End With
	End Sub

	Public Function checkAData() As Boolean
		checkAData = True

		If txtTitle.Text.Trim = "" Then
			lbleMsg.Text = "Title is required."
			checkAData = False
			Exit Function
		End If

		If txtIntro.Text.Trim = "" Then
			txtIntro.Text = Left(Replace(txtStory.Text, "'", "''"), 200)
		End If

		If txtStory.Text.Trim = "" Then
			lbleMsg.Text = "Story is required."
			checkAData = False
			Exit Function
		End If
	End Function

	Protected Sub btnACreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnACreate.Click
		System.Threading.Thread.Sleep(500)

		Session("announce") = Nothing
		grdAnnounce.Enabled = False

		btnACreate.Enabled = False
		btnModify.Text = "Save"
		btnACancel.Visible = True
		panAData.Visible = True

		enableAData()
	End Sub

	Protected Sub imbPicRemove_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbPicRemove.Click
		System.Threading.Thread.Sleep(500)

		With conn
			Dim fld(0), val(0), dt(0) As String

			fld(0) = "thumbnail"
			val(0) = ""
			dt(0) = "C"

			where = "announceID = " & Session("announceID")
			.UpdateDB("tbl_Announce", fld, val, dt, where)

			retrievePic()
		End With
	End Sub

	Protected Sub grdAnnounce_DataBound(ByVal sender As Object, ByVal e As EventArgs) Handles grdAnnounce.DataBound
		With conn
			.Page_Setup(grdAnnounce.TopPagerRow, grdAnnounce, "ddlPageNo", "imbFirst", "imbPrev", "imbNext", "imbLast", "lblPageCount")
			.Page_Setup(grdAnnounce.BottomPagerRow, grdAnnounce, "ddlPageNo", "imbFirst", "imbPrev", "imbNext", "imbLast", "lblPageCount")
		End With
	End Sub

	Public Sub ddlPageNo_OnSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)

		Dim ddlPageNo As DropDownList = sender

		If ddlPageNo IsNot Nothing Then
			If grdAnnounce.Rows.Count > 0 Then
				If ddlPageNo.SelectedIndex < grdAnnounce.PageCount Or _
					ddlPageNo.SelectedIndex >= 0 Then

					grdAnnounce.PageIndex = ddlPageNo.SelectedIndex
				End If
			End If
		End If
	End Sub

	Public Sub ddlAPageNo_OnSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)

		Dim ddlPageNo As DropDownList = sender

		If ddlPageNo IsNot Nothing Then
			If grdAccount.Rows.Count > 0 Then
				If ddlPageNo.SelectedIndex < grdAccount.PageCount Or _
					ddlPageNo.SelectedIndex >= 0 Then

					grdAccount.PageIndex = ddlPageNo.SelectedIndex
				End If
			End If
		End If
	End Sub

	Public Sub ddliPageNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)

		Dim ddlPageNo As DropDownList = sender

		If ddlPageNo IsNot Nothing Then
			If grdItem.Rows.Count > 0 Then
				If ddlPageNo.SelectedIndex < grdItem.PageCount Or _
					ddlPageNo.SelectedIndex >= 0 Then

					grdItem.PageIndex = ddlPageNo.SelectedIndex
				End If
			End If
		End If
	End Sub

	Protected Sub lnkAccnt_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkAccnt.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		panAType.Visible = False
		panData.Visible = False
		panAnnounce.Visible = False
		panAccount.Visible = True
		panSupport.Visible = False
		grdAccount.Visible = True

		lnkAType.CssClass = "tabprop"
		lnkData.CssClass = "tabprop"
		lnkAnnounce.CssClass = "tabprop"
		lnkAccnt.CssClass = "tabprop-Selected"
		lnkSupport.CssClass = "tabprop"

		With conn
			.loadToDropDownList("tbl_AccntType", ddlFType, False, "*", "", "accntTypeID", "accntType", "accntType", "")
			.loadToDropDownList("tbl_LoginStatus", ddlFStatus, False, "*", "", "LoginStatusID", "LoginStatus", "LoginStatus", "")
			.loadToDropDownList("tbl_AccntType", ddlAAType, False, "*", "", "accntTypeID", "accntType", "accntType", "")
			.loadToDropDownList("tbl_LoginStatus", ddlLStat, False, "*", "", "LoginStatusID", "LoginStatus", "LoginStatus", "")
			.loadToDropDownList("vw_Store", ddlStore, False, "*", "", "storeID", "sLoc", "sLoc", "")
		End With
	End Sub

	Protected Sub grdBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdBrand.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		Dim bID As Integer

		bID = grdBrand.DataKeys(grdBrand.SelectedIndex).Values(0).ToString()

		grdBrand.Enabled = False

		With conn
			'get details
			Dim retFld(1), retVal(1) As String

			retFld(0) = "productID"
			retFld(1) = "brand"

			where = "brandID = " & bID
			.getValues("vw_Brand", "*", where, 2, retFld, retVal, "", "", "")

			ddlBProd.SelectedValue = retVal(0)
			txtBrand.Text = retVal(1)

			imbABrand.AlternateText = "Update"
			imbABrand.ImageUrl = "~/images/icons/save.png"

			imbMBrand.AlternateText = "Cancel"
			imbMBrand.ImageUrl = "~/images/icons/cancel.png"
		End With
	End Sub

	Protected Sub imbABrand_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbABrand.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If txtBrand.Text.Trim = "" Then
			lbleMsg.Text = "No item to save."
			Exit Sub

		ElseIf ddlBProd.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Product is required."
			Exit Sub

		ElseIf imbABrand.AlternateText = "Save" Then
			With conn
				'check for duplicate
				where = "brand = '" & txtBrand.Text.Trim & "' AND productID = " & ddlBProd.SelectedValue.Trim

				If checkForDuplicate("tbl_Brand", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					Dim field, values As String

					field = "productID, brand"
					values = ddlBProd.SelectedValue.Trim & ", '" _
								& Replace(txtBrand.Text.Trim, "'", "''") & "'"

					.saveInfo("tbl_Brand", field, values)

					grdBrand.DataBind()
				End If
			End With

			txtBrand.Text = ""
			ddlBProd.SelectedIndex = -1

			grdBrand.Enabled = True

			imbABrand.AlternateText = "Save"

			imbMBrand.AlternateText = "Modify"
			imbMBrand.ImageUrl = "~/images/icons/modify.png"

		ElseIf imbABrand.AlternateText = "Update" Then
			With conn
				'check for duplicate
				where = "brand = '" & txtBrand.Text.Trim & "' AND productID = " & ddlBProd.SelectedValue.Trim _
							& " AND  brandID <> " & grdBrand.DataKeys(grdBrand.SelectedIndex).Values(0).ToString()

				If checkForDuplicate("tbl_Brand", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					Dim fld(1), val(1), dt(1) As String

					fld(0) = "productID"
					fld(1) = "brand"

					val(0) = ddlBProd.SelectedValue.Trim
					val(1) = Replace(txtBrand.Text.Trim, "'", "''")

					dt(0) = "N"
					dt(1) = "C"

					where = "brandID = " & grdBrand.DataKeys(grdBrand.SelectedIndex).Values(0).ToString()
					.UpdateDB("tbl_Brand", fld, val, dt, where)
				End If
			End With

			ddlBProd.SelectedIndex = -1
			txtBrand.Text = ""

			grdBrand.Enabled = True
			grdBrand.DataBind()

			imbAProd.AlternateText = "Save"
			imbMProd.ImageUrl = "~/images/icons/save.png"

			imbMProd.AlternateText = "Modify"
			imbMProd.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbMBrand_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbMBrand.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If grdBrand.SelectedIndex = -1 Then
			txtBrand.Text = ""
			lbleMsg.Text = "Please select an item to modify."
			Exit Sub

			'ElseIf imbMBrand.AlternateText = "Modify" Then
			'    txtBrand.Text = lstProd.SelectedItem.Text
			'    lstProd.Enabled = False

			'    imbAProd.Enabled = True
			'    imbAProd.AlternateText = "Update"

			'    imbMProd.AlternateText = "Cancel"
			'    imbMProd.ImageUrl = "~/images/icons/cancel.gif"


		ElseIf imbMBrand.AlternateText = "Cancel" Then
			txtBrand.Text = ""
			ddlBProd.SelectedIndex = -1

			grdBrand.Enabled = True
			grdBrand.SelectedIndex = -1

			imbABrand.Enabled = True
			imbABrand.AlternateText = "Save"
			imbMBrand.ImageUrl = "~/images/icons/save.png"

			imbMBrand.AlternateText = "Modify"
			imbMBrand.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Private Sub grdItem_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdItem.DataBound
		With conn
			.Page_Setup(grdItem.TopPagerRow, grdItem, "ddliPageNo", "imbiFirst", "imbiPrev", "imbiNext", "imbiLast", "lbliPageCount")
			.Page_Setup(grdItem.BottomPagerRow, grdItem, "ddliPageNo", "imbiFirst", "imbiPrev", "imbiNext", "imbiLast", "lbliPageCount")
		End With
	End Sub

	Protected Sub grdItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdItem.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		Dim iID As Integer
		Dim qry As String

		iID = grdItem.DataKeys(grdItem.SelectedIndex).Values(0).ToString()
		qry = "SELECT * FROM vw_Info WHERE itemID = " & iID

		grdItem.DataSourceID = ""
		grdItem.DataBind()
		sqlDS_Item.SelectCommand = qry
		grdItem.DataSourceID = "sqlDS_Item"
		grdItem.DataBind()
		grdItem.Enabled = False

		With conn
			'get details
			Dim retFld(7), retVal(7) As String

			retFld(0) = "productID"
			retFld(1) = "brandID"
			retFld(2) = "shortCode"
			retFld(3) = "longCode"
			retFld(4) = "itemDesc"
			retFld(5) = "modelID"
			retFld(6) = "variantID"
			retFld(7) = "capacityID"

			where = "itemID = " & iID
			.getValues("vw_Info", "*", where, 8, retFld, retVal, "", "", "")

			ddliProd.SelectedValue = retVal(0)

			'load brand
			ddliBrand.Items.Clear()
			where = "productID = " & retVal(0)
			.loadToDropDownList("tbl_Brand", ddliBrand, False, "*", where, "brandID", "brand", "brand", "")

			ddliBrand.SelectedValue = retVal(1)

			txtItem.Text = retVal(2)
			txtLCode.Text = retVal(3)
			txtDesc.Text = retVal(4)

			'load model
			ddliModel.Items.Clear()
			where = "brandID = " & retVal(1)
			.loadToDropDownList("tbl_Model", ddliModel, False, "*", where, "modelID", "model", "model", "")

			ddliModel.SelectedValue = retVal(5)
			ddliVariant.SelectedValue = retVal(6)

			'load capacity
			ddliCap.Items.Clear()
			where = "productID = " & retVal(0) & " AND brandID = " & retVal(1)
			.loadToDropDownList("tbl_Capacity", ddliCap, False, "*", where, "capacityID", "capacity", "capacity", "")

			If retVal(7) <> "" Then
				where = "capacityID = " & retVal(7) & " AND productID = " & retVal(0) & " AND brandID = " & retVal(1)
				If .checkID("tbl_Capacity", "*", where, 0, retVal, retFld, "", "") = "False" Then
					ddliCap.SelectedIndex = -1
				Else
					ddliCap.SelectedValue = retVal(7)
				End If

			Else
				ddliCap.SelectedIndex = -1
			End If

			btnICreate.Text = "Update"
			btnICancel.Text = "Cancel"
		End With
	End Sub

	Protected Sub ddliProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddliProd.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		If ddliProd.SelectedValue.Trim = "" Then
			ddliBrand.Items.Clear()
			ddliModel.Items.Clear()
			ddliCap.Items.Clear()

		Else
			ddliBrand.Items.Clear()
			ddliModel.Items.Clear()
			ddliCap.Items.Clear()

			where = "productID = " & ddliProd.SelectedValue.Trim
			conn.loadToDropDownList("tbl_Brand", ddliBrand, False, "*", where, "brandID", "brand", "brand", "")
		End If
	End Sub

	Protected Sub ddliBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddliBrand.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		If ddliBrand.SelectedValue.Trim = "" Then
			ddliModel.Items.Clear()
			ddliCap.Items.Clear()

		Else
			ddliModel.Items.Clear()
			ddliCap.Items.Clear()

			where = "brandID = " & ddliBrand.SelectedValue.Trim
			conn.loadToDropDownList("tbl_Model", ddliModel, False, "*", where, "modelID", "model", "model", "")

			where = "productID = " & ddliProd.SelectedValue.Trim & " AND brandID = " & ddliBrand.SelectedValue.Trim
			conn.loadToDropDownList("tbl_Capacity", ddliCap, False, "*", where, "capacityID", "capacity", "capacity", "")
		End If
	End Sub

	Protected Sub btnICancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnICancel.Click
		System.Threading.Thread.Sleep(500)

		If btnICancel.Text = "Cancel" Then
			btnICancel.Text = "Reset"

			Dim qry As String
			qry = "SELECT * FROM vw_Info" _
				& " WHERE ISNULL(shortCode, '') <> '' ORDER BY shortCode"

			grdItem.DataSourceID = ""
			grdItem.DataBind()
			sqlDS_Item.SelectCommand = qry
			grdItem.DataSourceID = "sqlDS_Item"
			grdItem.DataBind()

			grdItem.SelectedIndex = -1
			grdItem.Enabled = True
		End If

		resetItems()
	End Sub

	Public Sub resetItems()
		ddliProd.SelectedIndex = -1
		ddliBrand.Items.Clear()
		txtItem.Text = ""
		txtLCode.Text = ""
		txtDesc.Text = ""
		ddliModel.Items.Clear()
		ddliVariant.SelectedIndex = -1
		ddliCap.Items.Clear()
	End Sub

	Protected Sub btnICreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnICreate.Click
		System.Threading.Thread.Sleep(500)

		If btnICreate.Text = "Save" Then
			If checkItems() = False Then
				Exit Sub

			Else
				With conn
					Dim field, values As String

					field = "shortCode, longCode, itemDesc, productID, brandID, capacityID, variantID, modelID"
					values = "'" & Replace(txtItem.Text.Trim, "'", "''") & "', '" & Replace(txtLCode.Text.Trim, "'", "''") & "', '" _
								& Replace(txtDesc.Text.Trim, "'", "''") & "', " & ddliProd.SelectedValue.Trim & ", " _
								& ddliBrand.SelectedValue.Trim & ", " & ddliCap.SelectedValue.Trim & ", " _
								& ddliVariant.SelectedValue.Trim & ", " & ddliModel.SelectedValue.Trim

					.saveInfo("tbl_Items", field, values)
				End With
			End If

		ElseIf btnICreate.Text = "Update" Then
			If checkItems() = False Then
				Exit Sub

			Else
				With conn
					Dim fld(7), val(7), dt(7) As String

					fld(0) = "shortCode"
					fld(1) = "longCode"
					fld(2) = "itemDesc"
					fld(3) = "productID"
					fld(4) = "brandID"
					fld(5) = "capacityID"
					fld(6) = "variantID"
					fld(7) = "modelID"

					dt(0) = "C"
					dt(1) = "C"
					dt(2) = "C"
					dt(3) = "N"
					dt(4) = "N"
					dt(5) = "N"
					dt(6) = "N"
					dt(7) = "N"

					val(0) = Replace(txtItem.Text.Trim, "'", "''")
					val(1) = Replace(txtLCode.Text.Trim, "'", "''")
					val(2) = Replace(txtDesc.Text.Trim, "'", "''")
					val(3) = ddliProd.SelectedValue.Trim
					val(4) = ddliBrand.SelectedValue.Trim
					val(5) = ddliCap.SelectedValue.Trim
					val(6) = ddliVariant.SelectedValue.Trim
					val(7) = ddliModel.SelectedValue.Trim

					where = "itemID = " & grdItem.DataKeys(grdItem.SelectedIndex).Values(0).ToString()
					.UpdateDB("tbl_Items", fld, val, dt, where)

					clearItems()
				End With
			End If
		End If

		grdItem.DataBind()
		grdItem.Enabled = True

		resetItems()
		btnICreate.Text = "Save"
		btnICancel.Text = "Reset"
	End Sub

	Public Function checkItems() As Boolean
		checkItems = True

		If ddliProd.Items.Count <> 1 And ddliProd.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Product is required."
			checkItems = False
			Exit Function
		End If

		If ddliBrand.Items.Count <> 1 And ddliBrand.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Brand is required."
			checkItems = False
			Exit Function
		End If

		If txtItem.Text.Trim = "" Then
			lbleMsg.Text = "Short Code is required."
			checkItems = False
			Exit Function
		End If

		If txtLCode.Text.Trim = "" Then
			lbleMsg.Text = "Long Code is required."
			checkItems = False
			Exit Function
		End If

		If txtDesc.Text.Trim = "" Then
			lbleMsg.Text = "Item Description is required."
			checkItems = False
			Exit Function
		End If

		If ddliModel.Items.Count <> 1 And ddliModel.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Model is required."
			checkItems = False
			Exit Function
		End If

		If ddliVariant.Items.Count <> 1 And ddliVariant.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Variant is required."
			checkItems = False
			Exit Function
		End If

		If ddliCap.Items.Count <> 1 And ddliCap.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Capacity is required."
			checkItems = False
			Exit Function
		End If
	End Function

	Private Sub grdAccount_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAccount.DataBound
		With conn
			.Page_Setup(grdAccount.TopPagerRow, grdAccount, "ddlAPageNo", "imbaFirst", "imbaPrev", "imbaNext", "imbaLast", "lblaPageCount")
			.Page_Setup(grdAccount.BottomPagerRow, grdAccount, "ddlAPageNo", "imbaFirst", "imbaPrev", "imbaNext", "imbaLast", "lblaPageCount")
		End With
	End Sub

	Public Shared Function validatePWD(ByVal pwd As String) As String
		Dim ed As New clsED
		Dim lenUN As Integer = Len(pwd)
		Dim Lcnt As Integer = 1
		Dim Lcounter As Integer = 0
		Dim p As String = ""

		If lenUN < 8 Then
			Do While Lcnt <= (8 - lenUN)
				p += "0"
				Lcnt += 1
				Lcounter += 1
			Loop
			p += pwd
			validatePWD = ed.EncryptData(p)
		Else
			validatePWD = ed.EncryptData(pwd)
		End If
	End Function

	Protected Sub imbUnlock_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)

		Dim imbUnlock As ImageButton = sender
		Dim uid As Integer = Convert.ToInt32(imbUnlock.CommandArgument)

		With conn
			'retrieve username
			Dim retFld(0), retVal(0) As String
			retFld(0) = "uname"

			where = "userID = " & uid
			.getValues("tbl_Login", "userID, uname", where, 1, retFld, retVal, "", "", "")

			Dim fld(3), val(3), dt(3) As String

			fld(0) = "lockedCount"
			fld(1) = "loginStatusID"
			fld(2) = "lockedDate"
			fld(3) = "pwd"

			val(0) = "0"
			val(1) = "5"	'5 = New User | 3 = Locked Account
			val(2) = ""
			val(3) = validatePWD(retVal(0))

			dt(0) = "N"
			dt(1) = "N"
			dt(2) = "C"
			dt(3) = "C"

			where = "userID = " & uid
			.UpdateDB("tbl_Login", fld, val, dt, where)

			lbleMsg.Text = "Account has been unlocked! The temporary password is the user's username. Be reminded, password is case sensitive."

			grdUnlock.DataBind()
		End With
	End Sub

	Protected Sub btnAEmp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAEmp.Click
		System.Threading.Thread.Sleep(500)

		btnAEmp.Visible = False
		btnUnlock.Visible = False
		btnReactivate.Visible = False

		btnAcReset.Visible = False
		btnDeactivate.Visible = False

		emptyAData()
		enableAcData()

		btnAcModify.Text = "Save"

		panAEmp.Visible = True
		panUsers.Visible = False
		panUnlock.Visible = False
		panDeactivate.Visible = False

		With conn
			.loadToDropDownList("vw_FC", ddlFC, False, "*", "", "userID", "FCName", "FCName", "")
			.loadToDropDownList("vw_SFC", ddlSFC, False, "*", "", "userID", "SFCName", "SFCName", "")

			ddlFC.Items.Add("N/A")
			ddlSFC.Items.Add("N/A")

			ddlFC.SelectedItem.Text = "N/A"
			ddlSFC.SelectedItem.Text = "N/A"

			ddlLStat.SelectedValue = 5
		End With
	End Sub

	Protected Sub btnUnlock_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUnlock.Click
		System.Threading.Thread.Sleep(500)

		If btnUnlock.Text = "View Locked Users" Then
			btnUnlock.Text = "View Users"
			btnAEmp.Enabled = True
			btnUnlock.Enabled = True
			btnReactivate.Enabled = True

			panAEmp.Visible = False
			panUsers.Visible = False
			panUnlock.Visible = True
			panDeactivate.Visible = False

		ElseIf btnUnlock.Text = "View Users" Then
			btnUnlock.Text = "View Locked Users"
			btnAEmp.Enabled = True
			btnUnlock.Enabled = True
			btnReactivate.Enabled = True

			panAEmp.Visible = False
			panUsers.Visible = True
			panUnlock.Visible = False
			panDeactivate.Visible = False
		End If
	End Sub

	Protected Sub grdAccount_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdAccount.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		panAEmp.Visible = True
		btnAEmp.Visible = False
		btnUnlock.Visible = False
		btnReactivate.Visible = False

		panUSearch.Visible = False

		Dim uID As Integer
		Dim qry As String

		uID = grdAccount.DataKeys(grdAccount.SelectedIndex).Values(0).ToString()
		Session("uID") = uID
		qry = "SELECT * FROM vw_Users WHERE userID = " & uID

		grdAccount.DataSourceID = ""
		grdAccount.DataBind()
		sqlDS_Account.SelectCommand = qry
		grdAccount.DataSourceID = "sqlDS_Account"
		grdAccount.DataBind()
		grdAccount.Enabled = False
		disableAcData()

		With conn
			.loadToDropDownList("vw_FC", ddlFC, False, "*", "", "userID", "FCName", "FCName", "")
			.loadToDropDownList("vw_SFC", ddlSFC, False, "*", "", "userID", "SFCName", "SFCName", "")

			ddlFC.Items.Add("N/A")
			ddlSFC.Items.Add("N/A")

			'get details
			Dim retFld(14), retVal(14) As String

			retFld(0) = "fname"
			retFld(1) = "mname"
			retFld(2) = "lname"
			retFld(3) = "address"
			retFld(4) = "contact"
			retFld(5) = "email"

			retFld(6) = "uname"
			retFld(7) = "accntTypeID"
			retFld(8) = "loginStatusID"
			retFld(9) = "lockedDate"

			retFld(10) = "fcID"
			retFld(11) = "sFCID"
			retFld(12) = "minorDiser"
			retFld(13) = "dealer"
			retFld(14) = "storeID"

			where = "userID = " & uID
			.getValues("vw_Users", "*", where, 15, retFld, retVal, "", "", "")

			txtFname.Text = retVal(0)
			txtMname.Text = retVal(1)
			txtLname.Text = retVal(2)
			txtAAdd.Text = retVal(3)
			txtAContact.Text = retVal(4)
			txtAEmail.Text = retVal(5)

			txtAUname.Text = retVal(6)

			If retVal(7) = "" Or retVal(7) = 0 Then
				ddlAAType.SelectedIndex = -1
			Else
				ddlAAType.SelectedValue = retVal(7)
			End If

			If retVal(8) = "" Or retVal(8) = "0" Then
				ddlLStat.SelectedIndex = -1
			Else
				ddlLStat.SelectedValue = retVal(8)
			End If

			'lblLDate.Text = retVal(9)

			If retVal(7) = 5 Then					'fc
				'lblFC.Text = "Senior Field Coordinator"
				'ddlFC.Visible = True
				'ddlFC.Items.Clear()

				'.loadToDropDownList("vw_SFC", ddlFC, False, "*", "", "userID", "SFCName", "SFCName", "")

				'ddlFC.Enabled = False
				'ddlSFC.Enabled = True

				If retVal(11) = "" Or retVal(11) = "0" Then
					ddlSFC.SelectedIndex = -1
				Else
					If ddlSFC.Items.IndexOf(ddlSFC.Items.FindByValue(retVal(11).Trim)) <> -1 Then
						ddlSFC.SelectedValue = retVal(11)
					Else
						ddlSFC.SelectedIndex = -1
					End If
				End If
				ddlFC.SelectedItem.Text = "N/A"

			ElseIf retVal(7) = 7 Or retVal(7) = 6 Then	   'promodiser / senior promo diser
				'lblFC.Text = "Field Coordinator"
				'ddlFC.Visible = True
				'ddlFC.Items.Clear()

				'.loadToDropDownList("vw_FC", ddlFC, False, "*", "", "userID", "FCName", "FCName", "")

				'ddlSFC.Enabled = False
				'ddlFC.Enabled = True

				If retVal(10) = "" Or retVal(10) = "0" Then
					ddlFC.SelectedIndex = -1
				Else
					If ddlFC.Items.IndexOf(ddlFC.Items.FindByValue(retVal(10).Trim)) <> -1 Then
						ddlFC.SelectedValue = retVal(10)
					Else
						ddlFC.SelectedIndex = -1
					End If
				End If
				ddlSFC.SelectedItem.Text = "N/A"

			Else
				'lblFC.Text = ""
				'ddlFC.Visible = False
				'ddlFC.Items.Clear()

				'ddlFC.Enabled = False
				'ddlSFC.Enabled = False
				ddlFC.SelectedItem.Text = "N/A"
				ddlSFC.SelectedItem.Text = "N/A"
			End If

			txtADouble.Text = retVal(12)
			'lblDealer.Text = retVal(13)

			If retVal(14) = "" Or retVal(14) = "0" Then
				ddlStore.SelectedIndex = -1
			Else
				ddlStore.SelectedValue = retVal(14)
			End If

			btnAcModify.Text = "Modify"
		End With
	End Sub

	Protected Sub lnkSupport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkSupport.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		panAType.Visible = False
		panData.Visible = False
		panAnnounce.Visible = False
		panAccount.Visible = False
		panSupport.Visible = True

		lnkAType.CssClass = "tabprop"
		lnkData.CssClass = "tabprop"
		lnkAnnounce.CssClass = "tabprop"
		lnkAccnt.CssClass = "tabprop"
		lnkSupport.CssClass = "tabprop-Selected"

		panSGrid.Visible = True
		panSData.Visible = False
		grdSupport.SelectedIndex = -1
	End Sub

	Protected Sub btnHGeneral_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHGeneral.Click
		defHBtn()
		btnHGeneral.BackColor = sBtn
		btnHGeneral.Font.Bold = True

		hideBtns()
		btnCity.Visible = True
		btnRegion.Visible = True
		btnQuestion.Visible = True

		defBtn()
		btnCity.BackColor = sBtn
		btnCity.Font.Bold = True

		hidePanels()
		panCity.Visible = True


		'load region
		With conn
			.loadToDropDownList("tbl_Region", ddlCRegion, False, "*", "", "regionID", "region", "region", "")
		End With

		Session("cityID") = Nothing
	End Sub

	Public Sub defHBtn()
		btnHGeneral.BackColor = Drawing.Color.WhiteSmoke
		btnHGeneral.Font.Bold = False
		btnHSupport.BackColor = Drawing.Color.WhiteSmoke
		btnHSupport.Font.Bold = False
		btnHStore.BackColor = Drawing.Color.WhiteSmoke
		btnHStore.Font.Bold = False
		btnHCCAC.BackColor = Drawing.Color.WhiteSmoke
		btnHCCAC.Font.Bold = False
		btnHCompete.BackColor = Drawing.Color.WhiteSmoke
		btnHCompete.Font.Bold = False
		btnHReport.BackColor = Drawing.Color.WhiteSmoke
		btnHReport.Font.Bold = False
	End Sub

	Public Sub hideBtns()
		btnProd.Visible = False
		btnBrand.Visible = False
		btnItem.Visible = False
		btnModel.Visible = False
		btnCap.Visible = False
		btnVariant.Visible = False
		btnAction.Visible = False
		btnDealer.Visible = False
		btnStore.Visible = False
		btnCity.Visible = False
		btnProv.Visible = False
		btnRegion.Visible = False
		btnQuestion.Visible = False
		btnCBrand.Visible = False
		btnCCap.Visible = False
		btnSubject.Visible = False
		btnTarget.Visible = False
	End Sub

	Public Sub defBtn()
		btnProd.BackColor = Drawing.Color.WhiteSmoke
		btnBrand.BackColor = Drawing.Color.WhiteSmoke
		btnItem.BackColor = Drawing.Color.WhiteSmoke
		btnModel.BackColor = Drawing.Color.WhiteSmoke
		btnCap.BackColor = Drawing.Color.WhiteSmoke
		btnVariant.BackColor = Drawing.Color.WhiteSmoke
		btnAction.BackColor = Drawing.Color.WhiteSmoke
		btnDealer.BackColor = Drawing.Color.WhiteSmoke
		btnStore.BackColor = Drawing.Color.WhiteSmoke
		btnCity.BackColor = Drawing.Color.WhiteSmoke
		btnProv.BackColor = Drawing.Color.WhiteSmoke
		btnRegion.BackColor = Drawing.Color.WhiteSmoke
		btnQuestion.BackColor = Drawing.Color.WhiteSmoke
		btnCBrand.BackColor = Drawing.Color.WhiteSmoke
		btnCCap.BackColor = Drawing.Color.WhiteSmoke
		btnSubject.BackColor = Drawing.Color.WhiteSmoke
		btnTarget.BackColor = Drawing.Color.WhiteSmoke

		btnProd.Font.Bold = False
		btnBrand.Font.Bold = False
		btnItem.Font.Bold = False
		btnModel.Font.Bold = False
		btnCap.Font.Bold = False
		btnVariant.Font.Bold = False
		btnAction.Font.Bold = False
		btnDealer.Font.Bold = False
		btnStore.Font.Bold = False
		btnCity.Font.Bold = False
		btnProv.Font.Bold = False
		btnRegion.Font.Bold = False
		btnQuestion.Font.Bold = False
		btnCBrand.Font.Bold = False
		btnCCap.Font.Bold = False
		btnSubject.Font.Bold = False
		btnTarget.Font.Bold = False
	End Sub

	Public Sub hidePanels()
		panProd.Visible = False
		panBrand.Visible = False
		panItem.Visible = False
		panModel.Visible = False
		panCap.Visible = False
		panVariant.Visible = False
		panAction.Visible = False
		panDealer.Visible = False
		panStore.Visible = False
		panCity.Visible = False
		panProv.Visible = False
		panRegion.Visible = False
		panQuestion.Visible = False
		panCBrand.Visible = False
		panCCap.Visible = False
		panSubject.Visible = False
		panTarget.Visible = False
	End Sub

	Protected Sub btnHSupport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHSupport.Click
		defHBtn()
		btnHSupport.BackColor = sBtn
		btnHSupport.Font.Bold = True

		hideBtns()
		btnSubject.Visible = True

		defBtn()
		btnSubject.BackColor = sBtn
		btnSubject.Font.Bold = True

		hidePanels()
		panSubject.Visible = True

		conn.loadToListBox("tbl_Subject", lstSubject, False, "*", "subjID", "subject", "", "subject", "")
	End Sub

	Protected Sub btnHStore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHStore.Click
		defHBtn()
		btnHStore.BackColor = sBtn
		btnHStore.Font.Bold = True

		hideBtns()
		btnDealer.Visible = True
		btnStore.Visible = True

		defBtn()
		btnDealer.BackColor = sBtn
		btnDealer.Font.Bold = True

		hidePanels()
		panDealer.Visible = True

		conn.loadToListBox("tbl_Dealer", lstDealer, False, "*", "dealerID", "dealer", "", "dealer", "")
	End Sub

	Protected Sub btnHCCAC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHCCAC.Click
		defHBtn()
		btnHCCAC.BackColor = sBtn
		btnHCCAC.Font.Bold = True

		hideBtns()
		btnProd.Visible = True
		btnBrand.Visible = True
		btnItem.Visible = True
		btnModel.Visible = True
		btnCap.Visible = True
		btnVariant.Visible = True
		btnAction.Visible = True

		defBtn()
		btnProd.BackColor = sBtn
		btnProd.Font.Bold = True

		hidePanels()
		panProd.Visible = True
	End Sub

	Protected Sub btnHCompete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHCompete.Click
		defHBtn()
		btnHCompete.BackColor = sBtn
		btnHCompete.Font.Bold = True

		hideBtns()
		btnCBrand.Visible = True
		btnCCap.Visible = True

		defBtn()
		btnCBrand.BackColor = sBtn
		btnCBrand.Font.Bold = True

		hidePanels()
		panCBrand.Visible = True

		conn.loadToListBox("tbl_CBrand", lstCBrand, False, "*", "cBrandID", "cBrand", "", "cBrand", "")
	End Sub

	Protected Sub btnHReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHReport.Click
		defHBtn()
		btnHReport.BackColor = sBtn
		btnHReport.Font.Bold = True

		hideBtns()
		btnTarget.Visible = True

		defBtn()
		btnTarget.BackColor = sBtn
		btnTarget.Font.Bold = True

		hidePanels()
		panTarget.Visible = True

		With conn
			.loadToDropDownList("tbl_Product", ddlTProd, False, "*", "", "productID", "product", "product", "")
			.loadToDropDownList("tbl_Week", ddlTWeek, False, "*", "", "weekID", "weekCoverage", "weekID", "")
			Session("targetID") = Nothing
		End With
	End Sub

	Protected Sub btnHSA_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnHSA.Click
		If txtSA.Text.Trim <> "" Then
			With conn
				If Session("userID") = "2" Then
					Dim retFld(0), retVal(0) As String
					retFld(0) = "pwd"

					where = "userID = " & Session("userID")
					.getValues("tbl_Login", "*", where, 1, retFld, retVal, "", "", "")

					If ed.DecryptData(retVal(0)) = txtSA.Text.Trim Then
						Response.Redirect("~/Admin/Gotcha.aspx")
					End If
				End If
			End With
		End If
	End Sub

	Protected Sub ddlAPageNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim ddlPageNo As DropDownList = sender

		If ddlPageNo IsNot Nothing Then
			If grdAccount.Rows.Count > 0 Then
				If ddlPageNo.SelectedIndex < grdAccount.PageCount Or _
					ddlPageNo.SelectedIndex >= 0 Then

					grdAccount.PageIndex = ddlPageNo.SelectedIndex
				End If
			End If
		End If
	End Sub

	Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSearch.Click
		searchLike(txtSearch.Text.Trim)
		Session("sortBy") = "empName"
		'If txtSearch.Text.Trim = "" Then
		'    lbleMsg.Text = "No item to search. Kindly enter user's name."
		'    Exit Sub

		'Else
		'    searchLike(txtSearch.Text.Trim)
		'End If
	End Sub

	Public Function searchLike(ByVal item As String)
		Dim selectFlds, where As String

		selectFlds = "*"
		where = "empName LIKE '%" & item & "%' "

		If ddlFType.SelectedValue.Trim <> "" And ddlFStatus.SelectedValue.Trim = "" Then
			where += " AND AccntTypeID = " & ddlFType.SelectedValue.Trim

		ElseIf ddlFType.SelectedValue.Trim = "" And ddlFStatus.SelectedValue.Trim <> "" Then
			where += " AND LoginStatusID = " & ddlFStatus.SelectedValue.Trim

		ElseIf ddlFType.SelectedValue.Trim <> "" And ddlFStatus.SelectedValue.Trim <> "" Then
			where += " AND AccntTypeID = " & ddlFType.SelectedValue.Trim & " AND LoginStatusID = " & ddlFStatus.SelectedValue.Trim
		End If

		Dim qry As String
		qry = "SELECT " & selectFlds & " FROM vw_Users WHERE (userID <> 2 AND loginStatusID <> 6) AND " & where

		If Session("sortBy") = "empName" Then
			qry += " ORDER BY empName"
		Else
			qry += " ORDER BY userID DESC"
		End If

		grdAccount.DataSourceID = ""
		grdAccount.DataBind()
		sqlDS_Account.SelectCommand = qry
		grdAccount.DataSourceID = "sqlDS_Account"
		grdAccount.DataBind()
	End Function

	Protected Sub ddlFType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlFType.SelectedIndexChanged
		checkSession()
		lbleMsg3.Text = ""
		searchLike(txtSearch.Text.Trim)
	End Sub

	Protected Sub ddlFStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlFStatus.SelectedIndexChanged
		checkSession()
		lbleMsg3.Text = ""
		searchLike(txtSearch.Text.Trim)
	End Sub

	Protected Sub btnAcModify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAcModify.Click
		If btnAcModify.Text = "Modify" Then
			enableAcData()
			grdAccount.Enabled = False
			btnAcModify.Text = "Update"
			btnAcReset.Visible = True
			btnDeactivate.Visible = True

		ElseIf btnAcModify.Text = "Update" Then
			If validateAccount() = False Then
				Exit Sub

			Else
				'update record
				updateLogin()
				updateUser()

				emptyAData()
				disableAcData()

				Session("sortBy") = "empName"
				searchLike(txtSearch.Text.Trim)
				grdAccount.Enabled = True
				grdAccount.SelectedIndex = -1

				btnAEmp.Visible = True
				btnUnlock.Visible = True
				btnReactivate.Visible = True

				btnAcModify.Text = "Modify"
				btnAcReset.Visible = False
				btnDeactivate.Visible = False

				panAEmp.Visible = False
				panUSearch.Visible = True
			End If

		ElseIf btnAcModify.Text = "Save" Then
			If validateAccount() = False Then
				Exit Sub

			Else
				'check for duplicate username
				With conn
					Dim retVal(0), retFld(0) As String

					where = "fname='" & txtFname.Text.Trim & "' AND lname='" & txtLname.Text.Trim & "'"
					If .checkID("tbl_User", "", where, 0, retVal, retFld, "", "") = "True" Then
						lbleMsg.Text = "Username already exists."
						Exit Sub
					Else
						lbleMsg.Text = Nothing
					End If
				End With

				'save record
				saveLogin()
				saveUser()

				emptyAData()
				disableAcData()

				btnAEmp.Enabled = True
				btnUnlock.Enabled = True

				Session("sortBy") = "userID"
				searchLike(txtSearch.Text.Trim)
				grdAccount.Enabled = True
				grdAccount.SelectedIndex = -1

				btnAEmp.Visible = True
				btnUnlock.Visible = True
				btnReactivate.Visible = True

				btnAcModify.Text = "Modify"
				btnAcReset.Visible = False
				btnDeactivate.Visible = False

				panAEmp.Visible = False
				panUsers.Visible = True
				panUSearch.Visible = True
			End If
		End If
	End Sub

	Public Sub saveLogin()
		With conn
			Dim field, values As String

			field = "uname, pwd, accntTypeID, lockedCount, loginStatusID"
			values = "'" & txtAUname.Text.Trim & "', '"

			values += validatePWD(txtAUname.Text.Trim) & "', "

			values += ddlAAType.SelectedValue.Trim & ", 0, " _
						& ddlLStat.SelectedValue.Trim

			.saveInfo("tbl_Login", field, values)

			'retrieve userID
			Dim retFld(0), retVal(0) As String
			retFld(0) = "userID"

			where = "uname = '" & txtAUname.Text.Trim & "' AND accntTypeID = " & ddlAAType.SelectedValue.Trim
			.getValues("tbl_Login", "TOP 1 *", where, 1, retFld, retVal, "userID", "DESC", "")

			Session("uID") = retVal(0)
		End With
	End Sub

	Public Sub saveUser()
		With conn
			Dim field, values As String

			field = "userID, fcID, sFCID, storeID, address, contact, minorDiser, fname, mname, lname, email"
			values = Session("uID") & ", "

			If ddlAAType.SelectedValue.Trim = 6 Or ddlAAType.SelectedValue.Trim = 7 Then	'diser & senior diser
				If ddlFC.SelectedValue.Trim = "" Or ddlFC.SelectedItem.Text = "N/A" Then
					values += "0, 0, "
				Else
					values += ddlFC.SelectedValue.Trim & ", 0, "
				End If

			ElseIf ddlAAType.SelectedValue.Trim = 5 Then	'fc
				If ddlSFC.SelectedValue.Trim = "" Or ddlSFC.SelectedItem.Text = "N/A" Then
					values += "0, 0, "
				Else
					values += "0, " & ddlFC.SelectedValue.Trim & ", "
				End If

			Else
				values += "0, 0, "
			End If

			If ddlStore.SelectedValue.Trim = "" Then
				values += "0, '"
			Else
				values += ddlStore.SelectedValue.Trim & ", '"
			End If

			values += txtAAdd.Text.Trim & "', '" _
						& txtAContact.Text.Trim & "', '" _
						& txtADouble.Text.Trim & "', '" _
						& txtFname.Text.Trim & "', '" _
						& txtMname.Text.Trim & "', '" _
						& txtLname.Text.Trim & "', '" _
						& txtAEmail.Text.Trim & "'"

			.saveInfo("tbl_User", field, values)
		End With
	End Sub

	Public Sub updateLogin()
		With conn
			Dim fld(2), val(2), dt(2) As String

			fld(0) = "uname"
			fld(1) = "accntTypeID"
			fld(2) = "loginStatusID"

			dt(0) = "C"
			dt(1) = "N"
			dt(2) = "N"

			val(0) = txtAUname.Text.Trim
			val(1) = ddlAAType.SelectedValue.Trim
			val(2) = ddlLStat.SelectedValue.Trim

			where = "userID = " & Session("uID")
			.UpdateDB("tbl_Login", fld, val, dt, where)
		End With
	End Sub

	Public Sub updateUser()
		With conn
			Dim fld(9), val(9), dt(9) As String

			fld(0) = "fname"
			fld(1) = "mname"
			fld(2) = "lname"
			fld(3) = "address"
			fld(4) = "contact"
			fld(5) = "email"

			fld(6) = "fcID"
			fld(7) = "sFCID"
			fld(8) = "minorDiser"
			fld(9) = "storeID"

			dt(0) = "C"
			dt(1) = "C"
			dt(2) = "C"
			dt(3) = "C"
			dt(4) = "C"
			dt(5) = "C"
			dt(6) = "N"
			dt(7) = "N"
			dt(8) = "C"
			dt(9) = "N"

			val(0) = txtFname.Text.Trim
			val(1) = txtMname.Text.Trim
			val(2) = txtLname.Text.Trim
			val(3) = txtAAdd.Text.Trim
			val(4) = txtAContact.Text.Trim
			val(5) = txtAEmail.Text.Trim

			If ddlAAType.SelectedValue.Trim = 6 Or ddlAAType.SelectedValue.Trim = 7 Then
				If ddlFC.SelectedValue.Trim = "" Or ddlFC.SelectedItem.Text = "N/A" Then
					val(6) = "0"
				Else
					val(6) = ddlFC.SelectedValue.Trim
				End If
				val(7) = "0"

			ElseIf ddlAAType.SelectedValue.Trim = 5 Then
				val(6) = "0"
				If ddlSFC.SelectedValue.Trim = "" Or ddlSFC.SelectedItem.Text = "N/A" Then
					val(7) = "0"
				Else
					val(7) = ddlSFC.SelectedValue.Trim
				End If


			Else
				val(6) = "0"
				val(7) = "0"
			End If

			val(8) = txtADouble.Text.Trim

			If ddlStore.SelectedValue.Trim = "" Then
				val(9) = "0"
			Else
				val(9) = ddlStore.SelectedValue.Trim
			End If

			where = "userID = " & Session("uID")
			.UpdateDB("tbl_User", fld, val, dt, where)
		End With
	End Sub

	Public Function validateAccount() As Boolean
		lbleMsg3.Text = ""
		validateAccount = True

		'If txtFname.Text.Trim = "" Then
		'    validateAccount = False
		'    lbleMsg3.Text = "First Name is required."
		'    Exit Function
		'End If

		If txtLname.Text.Trim = "" Then
			validateAccount = False
			lbleMsg3.Text = "Last Name is required."
			Exit Function
		End If

		If txtAContact.Text <> "" Then
			If Len(txtAContact.Text) < 7 Then
				validateAccount = False
				lbleMsg3.Text = "Kindly enter a valid contact number."
				Exit Function

			ElseIf IsNumeric(txtAContact.Text) = False Then
				validateAccount = False
				lbleMsg3.Text = "Kindly enter a valid contact number.<br />Special characters are not accepted."
				Exit Function
			End If
		End If

		If txtAEmail.Text.Trim <> "" Then
			'    validateAccount = False
			'    lbleMsg3.Text = "Email address is required."
			'    Exit Function

			'Else
			Dim eValid As String = jc.emailValidator(txtAEmail)
			If eValid <> "" Then
				validateAccount = False
				lbleMsg3.Text = eValid
				Exit Function
			End If
		End If

		If txtAUname.Text.Trim = "" Then
			validateAccount = False
			lbleMsg3.Text = "Username is required."
			Exit Function
		End If

		If Len(txtAUname.Text.Trim) <= 7 Then
			validateAccount = False
			lbleMsg3.Text = "Username must be at least 8 characters."
			Exit Function
		End If

		If ddlAAType.SelectedValue.Trim = "" Then
			validateAccount = False
			lbleMsg3.Text = "Account Type is required"
			Exit Function
		End If

		If ddlLStat.SelectedValue.Trim = "" Then
			validateAccount = False
			lbleMsg3.Text = "Login Status is required"
			Exit Function
		End If

		If ddlAAType.SelectedValue.Trim = 7 Or ddlAAType.SelectedValue.Trim = 6 Then
			If ddlFC.Items.Count > 2 And ddlFC.SelectedValue.Trim = "" Then
				validateAccount = False
				lbleMsg3.Text = "Field Coordinator is required"
				Exit Function
			End If

		ElseIf ddlAAType.SelectedValue.Trim = 5 Then
			If ddlSFC.Items.Count > 2 And ddlSFC.SelectedValue.Trim = "" Then
				validateAccount = False
				lbleMsg3.Text = "Senior Field Coordinator is required"
				Exit Function
			End If
		End If
	End Function

	Public Sub enableAcData()
		txtFname.ReadOnly = False
		txtMname.ReadOnly = False
		txtLname.ReadOnly = False
		txtAAdd.ReadOnly = False
		txtAContact.ReadOnly = False
		txtAEmail.ReadOnly = False

		txtAUname.ReadOnly = False
		ddlAAType.Enabled = True
		ddlLStat.Enabled = True

		If ddlAAType.SelectedValue.Trim = "6" Or ddlAAType.SelectedValue.Trim = "7" Then
			ddlFC.Enabled = True
			ddlSFC.Enabled = False

		ElseIf ddlAAType.SelectedValue.Trim = "5" Then
			ddlFC.Enabled = False
			ddlSFC.Enabled = True

		Else
			ddlFC.Enabled = False
			ddlSFC.Enabled = False
		End If

		txtADouble.ReadOnly = False
		ddlStore.Enabled = True
	End Sub

	Public Sub disableAcData()
		txtFname.ReadOnly = True
		txtMname.ReadOnly = True
		txtLname.ReadOnly = True
		txtAAdd.ReadOnly = True
		txtAContact.ReadOnly = True
		txtAEmail.ReadOnly = True

		txtAUname.ReadOnly = True
		ddlAAType.Enabled = False
		ddlLStat.Enabled = False

		ddlFC.Enabled = False
		ddlSFC.Enabled = False
		txtADouble.ReadOnly = True

		ddlStore.Enabled = False
	End Sub

	Protected Sub btnAcCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAcCancel.Click
		emptyAData()

		btnAEmp.Visible = True
		btnUnlock.Visible = True
		btnUnlock.Text = "View Locked Users"
		btnReactivate.Visible = True

		btnAcReset.Visible = False
		btnDeactivate.Visible = False

		disableAcData()
		panAEmp.Visible = False
		panUsers.Visible = True
		panUSearch.Visible = True
		'Dim qry As String
		'qry = "SELECT * FROM vw_Users"
		Session("sortBy") = "empName"
		searchLike(txtSearch.Text)

		'grdAccount.DataSourceID = ""
		'grdAccount.DataBind()
		'sqlDS_Account.SelectCommand = qry
		'grdAccount.DataSourceID = "sqlDS_Account"
		'grdAccount.DataBind()
		grdAccount.Enabled = True
		grdAccount.SelectedIndex = -1
	End Sub

	Public Sub emptyAData()
		txtFname.Text = ""
		txtMname.Text = ""
		txtLname.Text = ""
		txtAAdd.Text = ""
		txtAContact.Text = ""
		txtAEmail.Text = ""

		txtAUname.Text = ""
		ddlAAType.SelectedIndex = -1
		ddlLStat.SelectedIndex = -1

		ddlFC.SelectedIndex = -1
		txtADouble.Text = ""
		ddlStore.SelectedIndex = -1
	End Sub

	Private Sub grdSupport_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSupport.DataBound
		With conn
			.Page_Setup(grdSupport.TopPagerRow, grdSupport, "ddlSPageNo", "imbSFirst", "imbSPrev", "imbSNext", "imbSLast", "lblSPageCount")
			.Page_Setup(grdSupport.BottomPagerRow, grdSupport, "ddlSPageNo", "imbSFirst", "imbSPrev", "imbSNext", "imbSLast", "lblSPageCount")
		End With
	End Sub

	Protected Sub grdSupport_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdSupport.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		'Session("supportID") = grdSupport.DataKeys(grdSupport.SelectedIndex).Values(0).ToString()
		Session("supportID") = grdSupport.DataKeys.Item(grdSupport.SelectedIndex).Value.ToString
		panSData.Visible = True
		panSGrid.Visible = False

		LoadSupportData()
		txtReply.Text = ""
		rblSStat.SelectedValue = 1
	End Sub

	Public Sub LoadSupportData()
		With conn
			Dim retFld(6), retVal(6) As String

			retFld(0) = "supportID"
			retFld(1) = "subject"
			retFld(2) = "comments"
			retFld(3) = "supportStatus"
			retFld(4) = "dateSubmitted"
			retFld(5) = "createdBy"
			retFld(6) = "supportStatusID"

			where = "supportID = " & Session("supportID")
			.getValues("vw_Support", "*", where, 7, retFld, retVal, "", "", "")

			lblTNo.Text = retVal(0)
			lblSubj.Text = retVal(1)
			lblComment.Text = retVal(2)
			lblStatus.Text = retVal(3)
			lblDCreated.Text = retVal(4)
			lblSCBy.Text = retVal(5)

			If retVal(6) = "1" Then
				panReply.Visible = True
				btnSubmit.Visible = True
			Else
				panReply.Visible = False
				btnSubmit.Visible = False
			End If

			grdSTrans.DataBind()
		End With
	End Sub

	Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubmit.Click
		If txtReply.Text.Trim = "" Then
			lbleMsg4.Text = "Your reply is required."
			Exit Sub

		Else
			With conn
				Dim field, values As String

				field = "supportID, reply, repliedByID, supportStatusID, dateReplied"
				values = Session("supportID") & ", '" _
							& Replace(txtReply.Text.Trim, "'", "''") & "', " _
							& Session("userID") & ", "

				If rblSStat.SelectedValue = 2 Then
					values += "2, '"
				Else
					values += "1, '"
				End If

				values += Format(CDate(Now), "MMM dd, yyyy HH:mm") & "'"

				.saveInfo("tbl_SupportTrans", field, values)

				'update tbl_support
				Dim fld(0), val(0), dt(0) As String

				fld(0) = "supportStatusID"
				dt(0) = "N"

				If rblSStat.SelectedValue = 2 Then
					val(0) = "2"
				Else
					val(0) = "1"
				End If

				where = "supportID = " & Session("supportID")
				.UpdateDB("tbl_Support", fld, val, dt, where)

				grdSupport.DataBind()
				grdSupport.SelectedIndex = -1
				panSData.Visible = False
				panSGrid.Visible = True
			End With
		End If
	End Sub

	Protected Sub btnAllSupport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAllSupport.Click
		panSData.Visible = False
		panSGrid.Visible = True
		grdSupport.DataBind()
		grdSupport.SelectedIndex = -1
	End Sub

	Protected Sub ddlCRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCRegion.SelectedIndexChanged
		If ddlCRegion.SelectedValue.Trim = "" Then
			ddlCProv.Items.Clear()

		Else
			ddlCProv.Items.Clear()

			where = "regionID = " & ddlCRegion.SelectedValue.Trim
			conn.loadToDropDownList("tbl_Province", ddlCProv, False, "*", where, "provinceID", "province", "province", "")
		End If
	End Sub

	Protected Sub ddlAAType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlAAType.SelectedIndexChanged
		If ddlAAType.SelectedValue.Trim = "" Then
			ddlFC.Enabled = False
			ddlSFC.Enabled = False

			ddlFC.SelectedItem.Text = "N/A"
			ddlSFC.SelectedItem.Text = "N/A"

		ElseIf ddlAAType.SelectedValue.Trim = 6 Or ddlAAType.SelectedValue = 7 Then		'diser/senior diser
			ddlFC.Enabled = True
			ddlSFC.Enabled = False

			ddlSFC.SelectedItem.Text = "N/A"
			ddlFC.Items.Clear()
			conn.loadToDropDownList("vw_FC", ddlFC, False, "*", "", "userID", "FCName", "FCName", "")

		ElseIf ddlAAType.SelectedValue.Trim = 5 Then	'fc
			ddlFC.Enabled = False
			ddlSFC.Enabled = True

			ddlFC.SelectedItem.Text = "N/A"
			ddlSFC.Items.Clear()
			conn.loadToDropDownList("vw_SFC", ddlSFC, False, "*", "", "userID", "SFCName", "SFCName", "")

		Else
			ddlFC.Enabled = False
			ddlSFC.Enabled = False

			ddlFC.SelectedItem.Text = "N/A"
			ddlSFC.SelectedItem.Text = "N/A"
		End If
	End Sub

	Private Sub grdCity_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCity.DataBound
		With conn
			.Page_Setup(grdCity.TopPagerRow, grdCity, "ddlCPageNo", "imbCFirst", "imbCPrev", "imbCNext", "imbCLast", "lblCPageCount")
			.Page_Setup(grdCity.BottomPagerRow, grdCity, "ddlCPageNo", "imbCFirst", "imbCPrev", "imbCNext", "imbCLast", "lblCPageCount")
		End With
	End Sub

	Protected Sub grdCity_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdCity.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		Dim cID As Integer
		Dim qry As String

		cID = grdCity.DataKeys(grdCity.SelectedIndex).Values(0).ToString()
		Session("cityID") = cID
		qry = "SELECT * FROM vw_City WHERE cityID = " & cID

		grdCity.DataSourceID = ""
		grdCity.DataBind()
		sqlDS_City.SelectCommand = qry
		grdCity.DataSourceID = "sqlDS_City"
		grdCity.DataBind()
		grdCity.Enabled = False

		With conn
			'get details
			Dim retFld(2), retVal(2) As String

			retFld(0) = "regionID"
			retFld(1) = "provinceID"
			retFld(2) = "city"

			where = "cityID = " & cID
			.getValues("vw_City", "*", where, 3, retFld, retVal, "", "", "")

			If retVal(0) = "" Or retVal(0) = "0" Then
				ddlCRegion.SelectedIndex = -1
				ddlCProv.Items.Clear()

			Else
				ddlCRegion.SelectedValue = retVal(0)

				'load province
				ddlCProv.Items.Clear()
				where = "regionID = " & retVal(0)
				.loadToDropDownList("tbl_Province", ddlCProv, False, "*", where, "provinceID", "province", "province", "")
			End If

			If retVal(1) = "" Or retVal(1) = "0" Then
				ddlCProv.SelectedIndex = -1
			Else
				ddlCProv.SelectedValue = retVal(1)
			End If

			txtCity.Text = retVal(2)

			btnCCreate.Text = "Update"
			btnCCancel.Text = "Cancel"
		End With
	End Sub

	Public Function checkCity() As Boolean
		checkCity = True

		If ddlCRegion.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Region is required."
			checkCity = False
			Exit Function
		End If

		If ddlCProv.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Province is required."
			checkCity = False
			Exit Function
		End If

		If txtCity.Text.Trim = "" Then
			lbleMsg.Text = "City is required."
			checkCity = False
			Exit Function

		Else
			'check for duplicate
			Dim retFld(0), retVal(0) As String

			If Session("cityID") Is Nothing Then
				where = "city = '" & txtCity.Text.Trim & "' AND provinceID = " & ddlCProv.SelectedValue.Trim
			Else
				where = "city = '" & txtCity.Text.Trim _
							& "' AND provinceID = " & ddlCProv.SelectedValue.Trim _
							& " AND cityID <> " & Session("cityID")
			End If

			If conn.checkID("tbl_City", "*", where, 0, retVal, retFld, "", "") = "True" Then
				lbleMsg.Text = "City has a duplicate."
				checkCity = False
				Exit Function
			End If
		End If
	End Function

	Protected Sub btnCCreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCCreate.Click
		System.Threading.Thread.Sleep(500)

		If btnCCreate.Text = "Save" Then
			If checkCity() = False Then
				Exit Sub

			Else
				With conn
					Dim field, values As String

					field = "city, provinceID"
					values = "'" & Replace(txtCity.Text.Trim, "'", "''") & "', " _
								& ddlCProv.SelectedValue.Trim

					.saveInfo("tbl_City", field, values)
				End With
			End If

		ElseIf btnCCreate.Text = "Update" Then
			If checkCity() = False Then
				Exit Sub

			Else
				With conn
					Dim fld(1), val(1), dt(1) As String

					fld(0) = "city"
					fld(1) = "provinceID"

					dt(0) = "C"
					dt(1) = "N"

					val(0) = Replace(txtCity.Text.Trim, "'", "''")
					val(1) = ddlCProv.SelectedValue.Trim

					where = "cityID = " & Session("cityID")
					'where = "cityID = " & grdCity.DataKeys.Item(grdCity.SelectedIndex).Value(0).ToString
					.UpdateDB("tbl_City", fld, val, dt, where)

					'clearItems()
				End With
			End If
		End If

		grdCity.DataBind()
		grdCity.Enabled = True

		ddlCRegion.SelectedIndex = -1
		ddlCProv.Items.Clear()
		txtCity.Text = ""

		btnCCreate.Text = "Save"
		btnCCancel.Text = "Reset"
	End Sub

	Protected Sub btnCCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCCancel.Click
		System.Threading.Thread.Sleep(500)

		If btnCCancel.Text = "Cancel" Then
			btnCCancel.Text = "Reset"

			Dim qry As String
			qry = "SELECT * FROM vw_City ORDER BY city"

			grdCity.DataSourceID = ""
			grdCity.DataBind()
			sqlDS_City.SelectCommand = qry
			grdCity.DataSourceID = "sqlDS_City"
			grdCity.DataBind()

			grdCity.SelectedIndex = -1
			grdCity.Enabled = True
		End If

		ddlCRegion.SelectedIndex = -1
		ddlCProv.Items.Clear()
		txtCity.Text = ""
		Session("cityID") = Nothing
	End Sub

	Protected Sub btnQuestion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnQuestion.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnQuestion.BackColor = sBtn
		btnQuestion.Font.Bold = True

		hidePanels()
		panQuestion.Visible = True

		conn.loadToListBox("tbl_Question", lstQuestion, False, "*", "questionID", "question", "", "question", "")
	End Sub

	Protected Sub btnCBrand_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCBrand.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnCBrand.BackColor = sBtn
		btnCBrand.Font.Bold = True

		hidePanels()
		panCBrand.Visible = True
	End Sub

	Protected Sub btnCCap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCCap.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnCCap.BackColor = sBtn
		btnCCap.Font.Bold = True

		hidePanels()
		panCCap.Visible = True

		conn.loadToListBox("tbl_CCapacity", lstCCap, False, "*", "cCapacityID", "cCapacity", "", "cCapacity", "")
	End Sub

	Protected Sub btnSubject_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSubject.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnSubject.BackColor = sBtn
		btnSubject.Font.Bold = True

		hidePanels()
		panSubject.Visible = True

		conn.loadToListBox("tbl_Subject", lstSubject, False, "*", "subjID", "subject", "", "subject", "")
	End Sub

	Protected Sub btnTarget_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTarget.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnTarget.BackColor = sBtn
		btnTarget.Font.Bold = True

		hidePanels()
		panTarget.Visible = True

		Session("targetID") = Nothing
		conn.loadToDropDownList("tbl_Product", ddlTProd, False, "*", "", "productID", "product", "product", "")
		conn.loadToDropDownList("tbl_Week", ddlTWeek, False, "*", "", "weekID", "weekCoverage", "weekID", "")
	End Sub

	Protected Sub btnAction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAction.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnAction.BackColor = sBtn
		btnAction.Font.Bold = True

		hidePanels()
		panAction.Visible = True

		conn.loadToListBox("tbl_Action", lstAction, False, "*", "actionID", "actionTaken", "", "actionTaken", "")
	End Sub

	Protected Sub btnProv_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnProv.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		defBtn()
		btnProv.BackColor = sBtn
		btnProv.Font.Bold = True

		hidePanels()
		panProv.Visible = True

		Session("provinceID") = Nothing
		conn.loadToDropDownList("vw_Province", ddlPRegion, False, "*", "", "regionID", "region", "region", "")
	End Sub

	Protected Sub btnPCreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPCreate.Click
		System.Threading.Thread.Sleep(500)

		If btnPCreate.Text = "Save" Then
			If checkProv() = False Then
				Exit Sub

			Else
				With conn
					Dim field, values As String

					field = "province, regionID"
					values = "'" & Replace(txtProvince.Text.Trim, "'", "''") & "', " _
								& ddlPRegion.SelectedValue.Trim

					.saveInfo("tbl_Province", field, values)
				End With
			End If

		ElseIf btnPCreate.Text = "Update" Then
			If checkProv() = False Then
				Exit Sub

			Else
				With conn
					Dim fld(1), val(1), dt(1) As String

					fld(0) = "province"
					fld(1) = "regionID"

					dt(0) = "C"
					dt(1) = "N"

					val(0) = Replace(txtProvince.Text.Trim, "'", "''")
					val(1) = ddlPRegion.SelectedValue.Trim

					where = "provinceID = " & Session("provID")
					'where = "cityID = " & grdCity.DataKeys.Item(grdCity.SelectedIndex).Value(0).ToString
					.UpdateDB("tbl_Province", fld, val, dt, where)

					'clearItems()
				End With
			End If
		End If

		grdProv.DataBind()
		grdProv.Enabled = True

		ddlPRegion.SelectedIndex = -1
		txtProvince.Text = ""

		btnPCreate.Text = "Save"
		btnPCancel.Text = "Reset"
	End Sub

	Public Function checkProv() As Boolean
		checkProv = True

		If ddlPRegion.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Region is required."
			checkProv = False
			Exit Function
		End If

		If txtProvince.Text.Trim = "" Then
			lbleMsg.Text = "Province is required."
			checkProv = False
			Exit Function

		Else
			'check for duplicate
			Dim retFld(0), retVal(0) As String

			If Session("provinceID") Is Nothing Then
				where = "province = '" & txtProvince.Text.Trim & "' AND regionID = " & ddlPRegion.SelectedValue.Trim
			Else
				where = "province = '" & txtProvince.Text.Trim _
							& "' AND regionID = " & ddlCRegion.SelectedValue.Trim _
							& " AND provinceID <> " & Session("provinceID")
			End If

			If conn.checkID("tbl_Province", "*", where, 0, retVal, retFld, "", "") = "True" Then
				lbleMsg.Text = "Province has a duplicate."
				checkProv = False
				Exit Function
			End If
		End If
	End Function

	Protected Sub btnPCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPCancel.Click
		System.Threading.Thread.Sleep(500)

		If btnPCancel.Text = "Cancel" Then
			btnPCancel.Text = "Reset"

			Dim qry As String
			qry = "SELECT * FROM vw_Province ORDER BY province"

			grdProv.DataSourceID = ""
			grdProv.DataBind()
			sqlDS_Prov.SelectCommand = qry
			grdProv.DataSourceID = "sqlDS_Prov"
			grdProv.DataBind()

			grdProv.SelectedIndex = -1
			grdProv.Enabled = True
		End If

		ddlPRegion.SelectedIndex = -1
		txtProvince.Text = ""
		Session("provinceID") = Nothing
	End Sub

	Private Sub grdProv_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProv.DataBound
		With conn
			.Page_Setup(grdProv.TopPagerRow, grdProv, "ddlPPageNo", "imbPFirst", "imbPPrev", "imbPNext", "imbPLast", "lblPPageCount")
			.Page_Setup(grdProv.BottomPagerRow, grdProv, "ddlPPageNo", "imbPFirst", "imbPPrev", "imbPNext", "imbPLast", "lblPPageCount")
		End With
	End Sub

	Protected Sub grdProv_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdProv.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		Dim cID As Integer
		Dim qry As String

		cID = grdProv.DataKeys(grdProv.SelectedIndex).Values(0).ToString()
		Session("provID") = cID
		qry = "SELECT * FROM vw_Province WHERE provinceID = " & cID

		grdProv.DataSourceID = ""
		grdProv.DataBind()
		sqlDS_Prov.SelectCommand = qry
		grdProv.DataSourceID = "sqlDS_Prov"
		grdProv.DataBind()
		grdProv.Enabled = False

		With conn
			'get details
			Dim retFld(1), retVal(1) As String

			retFld(0) = "regionID"
			retFld(1) = "province"

			where = "provinceID = " & cID
			.getValues("vw_Province", "*", where, 2, retFld, retVal, "", "", "")

			If retVal(0) = "" Or retVal(0) = "0" Then
				ddlPRegion.SelectedIndex = -1
			Else
				ddlPRegion.SelectedValue = retVal(0)
			End If

			txtCity.Text = retVal(1)

			btnPCreate.Text = "Update"
			btnPCancel.Text = "Cancel"
		End With
	End Sub

	Protected Sub imbARegion_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbARegion.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If txtRegion.Text.Trim = "" Then
			lbleMsg.Text = "No item to save."
			Exit Sub

		ElseIf imbARegion.AlternateText = "Save" Then
			With conn
				'check for duplicate
				where = "region = '" & txtRegion.Text.Trim & "'"

				If checkForDuplicate("tbl_Region", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					.saveInfo("tbl_Region", "region", "'" & Replace(txtRegion.Text.Trim, "'", "''") & "'")

					lstRegion.Items.Clear()
					.loadToListBox("tbl_Region", lstRegion, False, "*", "regionID", "region", "", "region", "")
				End If
			End With

			txtRegion.Text = ""
			lstRegion.Enabled = True

			imbARegion.AlternateText = "Save"

			imbMRegion.AlternateText = "Modify"
			imbMRegion.ImageUrl = "~/images/icons/modify.png"

		ElseIf imbARegion.AlternateText = "Update" Then
			With conn
				'check for duplicate
				where = "region = '" & txtRegion.Text.Trim & "' AND regionID <> " & lstRegion.SelectedValue
				If checkForDuplicate("tbl_Region", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					Dim fld(0), val(0), dt(0) As String

					fld(0) = "region"
					val(0) = Replace(txtRegion.Text.Trim, "'", "''")
					dt(0) = "C"

					where = "regionID = " & lstRegion.SelectedValue.Trim
					.UpdateDB("tbl_Region", fld, val, dt, where)

					lstRegion.Items.Clear()
					.loadToListBox("tbl_Region", lstRegion, False, "*", "regionID", "region", "", "region", "")
				End If
			End With

			txtRegion.Text = ""

			lstRegion.DataBind()
			lstRegion.Enabled = True

			imbARegion.AlternateText = "Save"

			imbMRegion.AlternateText = "Modify"
			imbMRegion.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbMRegion_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbMRegion.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If lstRegion.SelectedIndex = -1 Then
			txtRegion.Text = ""
			lbleMsg.Text = "Please select an item to modify."
			Exit Sub

		ElseIf imbMRegion.AlternateText = "Modify" Then
			txtRegion.Text = lstRegion.SelectedItem.Text
			lstRegion.Enabled = False

			imbARegion.Enabled = True
			imbARegion.AlternateText = "Update"

			imbMRegion.AlternateText = "Cancel"
			imbMRegion.ImageUrl = "~/images/icons/cancel.png"


		ElseIf imbMRegion.AlternateText = "Cancel" Then
			txtRegion.Text = ""
			lstRegion.Enabled = True

			imbARegion.Enabled = True
			imbARegion.AlternateText = "Save"

			imbMRegion.AlternateText = "Modify"
			imbMRegion.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbAQuestion_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAQuestion.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If txtQuestion.Text.Trim = "" Then
			lbleMsg.Text = "No item to save."
			Exit Sub

		ElseIf imbAQuestion.AlternateText = "Save" Then
			With conn
				'check for duplicate
				where = "question = '" & txtQuestion.Text.Trim & "'"

				If checkForDuplicate("tbl_Question", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					.saveInfo("tbl_Question", "question", "'" & Replace(txtQuestion.Text.Trim, "'", "''") & "'")

					lstQuestion.Items.Clear()
					.loadToListBox("tbl_Question", lstQuestion, False, "*", "questionID", "question", "", "question", "")
				End If
			End With

			txtQuestion.Text = ""
			lstQuestion.Enabled = True

			imbAQuestion.AlternateText = "Save"

			imbMQuestion.AlternateText = "Modify"
			imbMQuestion.ImageUrl = "~/images/icons/modify.png"

		ElseIf imbAQuestion.AlternateText = "Update" Then
			With conn
				'check for duplicate
				where = "question = '" & txtQuestion.Text.Trim & "' AND questionID <> " & lstQuestion.SelectedValue.Trim
				If checkForDuplicate("tbl_Question", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					Dim fld(0), val(0), dt(0) As String

					fld(0) = "question"
					val(0) = Replace(txtQuestion.Text.Trim, "'", "''")
					dt(0) = "C"

					where = "questionID = " & lstQuestion.SelectedValue.Trim
					.UpdateDB("tbl_Question", fld, val, dt, where)

					lstQuestion.Items.Clear()
					.loadToListBox("tbl_Question", lstQuestion, False, "*", "questionID", "question", "", "question", "")
				End If
			End With

			txtQuestion.Text = ""

			lstQuestion.DataBind()
			lstQuestion.Enabled = True

			imbAQuestion.AlternateText = "Save"

			imbMQuestion.AlternateText = "Modify"
			imbMQuestion.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbMQuestion_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbMQuestion.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If lstQuestion.SelectedIndex = -1 Then
			txtQuestion.Text = ""
			lbleMsg.Text = "Please select an item to modify."
			Exit Sub

		ElseIf imbMQuestion.AlternateText = "Modify" Then
			txtQuestion.Text = lstQuestion.SelectedItem.Text
			lstQuestion.Enabled = False

			imbAQuestion.Enabled = True
			imbAQuestion.AlternateText = "Update"

			imbMQuestion.AlternateText = "Cancel"
			imbMQuestion.ImageUrl = "~/images/icons/cancel.png"


		ElseIf imbMQuestion.AlternateText = "Cancel" Then
			txtQuestion.Text = ""
			lstQuestion.Enabled = True

			imbAQuestion.Enabled = True
			imbAQuestion.AlternateText = "Save"

			imbMQuestion.AlternateText = "Modify"
			imbMQuestion.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbASubject_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbASubject.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If txtSubject.Text.Trim = "" Then
			lbleMsg.Text = "No item to save."
			Exit Sub

		ElseIf imbASubject.AlternateText = "Save" Then
			With conn
				'check for duplicate
				where = "subject = '" & txtSubject.Text.Trim & "'"

				If checkForDuplicate("tbl_Subject", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					.saveInfo("tbl_Subject", "subject", "'" & Replace(txtSubject.Text.Trim, "'", "''") & "'")

					lstSubject.Items.Clear()
					.loadToListBox("tbl_Subject", lstSubject, False, "*", "subjectID", "subject", "", "subject", "")
				End If
			End With

			txtSubject.Text = ""
			lstSubject.Enabled = True

			imbASubject.AlternateText = "Save"

			imbMSubject.AlternateText = "Modify"
			imbMSubject.ImageUrl = "~/images/icons/modify.png"

		ElseIf imbASubject.AlternateText = "Update" Then
			With conn
				'check for duplicate
				where = "subject = '" & txtSubject.Text.Trim & "' AND subjID <> " & lstSubject.SelectedValue.Trim
				If checkForDuplicate("tbl_Subject", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					Dim fld(0), val(0), dt(0) As String

					fld(0) = "subject"
					val(0) = Replace(txtSubject.Text.Trim, "'", "''")
					dt(0) = "C"

					where = "subjID = " & lstSubject.SelectedValue.Trim
					.UpdateDB("tbl_Subject", fld, val, dt, where)

					lstSubject.Items.Clear()
					.loadToListBox("tbl_Subject", lstSubject, False, "*", "subjID", "subject", "", "subject", "")
				End If
			End With

			txtSubject.Text = ""

			lstSubject.DataBind()
			lstSubject.Enabled = True

			imbASubject.AlternateText = "Save"

			imbMSubject.AlternateText = "Modify"
			imbMSubject.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbMSubject_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbMSubject.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If lstSubject.SelectedIndex = -1 Then
			txtSubject.Text = ""
			lbleMsg.Text = "Please select an item to modify."
			Exit Sub

		ElseIf imbMSubject.AlternateText = "Modify" Then
			txtSubject.Text = lstSubject.SelectedItem.Text
			lstSubject.Enabled = False

			imbASubject.Enabled = True
			imbASubject.AlternateText = "Update"

			imbMSubject.AlternateText = "Cancel"
			imbMSubject.ImageUrl = "~/images/icons/cancel.png"


		ElseIf imbMSubject.AlternateText = "Cancel" Then
			txtSubject.Text = ""
			lstSubject.Enabled = True

			imbASubject.Enabled = True
			imbASubject.AlternateText = "Save"

			imbMSubject.AlternateText = "Modify"
			imbMSubject.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbADealer_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbADealer.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If txtDealer.Text.Trim = "" Then
			lbleMsg.Text = "No item to save."
			Exit Sub

		ElseIf imbADealer.AlternateText = "Save" Then
			With conn
				'check for duplicate
				where = "dealer = '" & txtDealer.Text.Trim & "'"

				If checkForDuplicate("tbl_Dealer", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					.saveInfo("tbl_Dealer", "dealer", "'" & Replace(txtDealer.Text.Trim, "'", "''") & "'")

					lstDealer.Items.Clear()
					.loadToListBox("tbl_Dealer", lstDealer, False, "*", "dealerID", "dealer", "", "dealer", "")
				End If
			End With

			txtDealer.Text = ""
			lstDealer.Enabled = True

			imbADealer.AlternateText = "Save"

			imbMDealer.AlternateText = "Modify"
			imbMDealer.ImageUrl = "~/images/icons/modify.png"

		ElseIf imbADealer.AlternateText = "Update" Then
			With conn
				'check for duplicate
				where = "dealer = '" & txtDealer.Text.Trim & "' AND dealerID <> " & lstDealer.SelectedValue.Trim
				If checkForDuplicate("tbl_Dealer", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					Dim fld(0), val(0), dt(0) As String

					fld(0) = "dealer"
					val(0) = Replace(txtDealer.Text.Trim, "'", "''")
					dt(0) = "C"

					where = "dealerID = " & lstDealer.SelectedValue.Trim
					.UpdateDB("tbl_Dealer", fld, val, dt, where)

					lstDealer.Items.Clear()
					.loadToListBox("tbl_Dealer", lstDealer, False, "*", "dealerID", "dealer", "", "dealer", "")
				End If
			End With

			txtDealer.Text = ""

			lstDealer.DataBind()
			lstDealer.Enabled = True

			imbADealer.AlternateText = "Save"

			imbMDealer.AlternateText = "Modify"
			imbMDealer.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbMDealer_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbMDealer.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If lstDealer.SelectedIndex = -1 Then
			txtDealer.Text = ""
			lbleMsg.Text = "Please select an item to modify."
			Exit Sub

		ElseIf imbMDealer.AlternateText = "Modify" Then
			txtDealer.Text = lstDealer.SelectedItem.Text
			lstDealer.Enabled = False

			imbADealer.Enabled = True
			imbADealer.AlternateText = "Update"

			imbMDealer.AlternateText = "Cancel"
			imbMDealer.ImageUrl = "~/images/icons/cancel.png"


		ElseIf imbMDealer.AlternateText = "Cancel" Then
			txtDealer.Text = ""
			lstDealer.Enabled = True

			imbADealer.Enabled = True
			imbADealer.AlternateText = "Save"

			imbMDealer.AlternateText = "Modify"
			imbMDealer.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Private Sub grdStore_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdStore.DataBound
		With conn
			.Page_Setup(grdStore.TopPagerRow, grdStore, "ddlStPageNo", "imbStFirst", "imbStPrev", "imbStNext", "imbStLast", "lblStPageCount")
			.Page_Setup(grdStore.BottomPagerRow, grdStore, "ddlStPageNo", "imbStFirst", "imbStPrev", "imbStNext", "imbStLast", "lblStPageCount")
		End With
	End Sub

	Protected Sub grdStore_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdStore.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		Dim cID As Integer
		Dim qry As String

		cID = grdStore.DataKeys(grdStore.SelectedIndex).Values(0).ToString()
		Session("storeID") = cID
		qry = "SELECT * FROM vw_Store WHERE storeID = " & cID

		grdStore.DataSourceID = ""
		grdStore.DataBind()
		sqlDS_Store.SelectCommand = qry
		grdStore.DataSourceID = "sqlDS_Store"
		grdStore.DataBind()
		grdStore.Enabled = False

		With conn
			'get details
			Dim retFld(7), retVal(7) As String

			retFld(0) = "storeCode"
			retFld(1) = "dealerID"
			retFld(2) = "locationID"
			retFld(3) = "regionID"
			retFld(4) = "parentBP"
			retFld(5) = "childBP1"
			retFld(6) = "childBP2"
			retFld(7) = "childBP3"

			where = "storeID = " & cID
			.getValues("vw_Store", "*", where, 8, retFld, retVal, "", "", "")

			txtSC.Text = retVal(0)

			If retVal(1) = "" Or retVal(1) = "0" Then
				ddlSCDealer.SelectedIndex = -1
			Else
				ddlSCDealer.SelectedValue = retVal(1)

				ddlSCLoc.Items.Clear()
				where = "dealerID = " & ddlSCDealer.SelectedValue.Trim
				conn.loadToDropDownList("vw_Location", ddlSCLoc, False, "*", where, "locationID", "location", "location", "")

				If retVal(2) = "" Or retVal(2) = "0" Then
					ddlSCLoc.SelectedIndex = -1
				Else
					ddlSCLoc.SelectedValue = retVal(2)
				End If
			End If

			If retVal(3) = "" Or retVal(3) = "0" Then
				ddlSCRegion.SelectedIndex = -1
			Else
				ddlSCRegion.SelectedValue = retVal(3)
			End If

			txtParent.Text = retVal(4)
			txtChild1.Text = retVal(5)
			txtChild2.Text = retVal(6)
			txtChild3.Text = retVal(7)

			btnSCCreate.Text = "Update"
			btnSCCancel.Text = "Cancel"
		End With
	End Sub

	Protected Sub btnSCCreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSCCreate.Click
		System.Threading.Thread.Sleep(500)

		If btnSCCreate.Text = "Save" Then
			If checkStore() = False Then
				Exit Sub

			Else
				With conn
					Dim field, values As String

					field = "storeCode, dealerID, locationID, regionID, parentBP, childBP1, childBP2, childBP3"
					values = "'" & Replace(txtSC.Text.Trim, "'", "''") & "', " _
								& ddlSCDealer.SelectedValue.Trim & ", " _
								& ddlSCLoc.SelectedValue.Trim & ", " _
								& ddlSCRegion.SelectedValue.Trim & ", '" _
								& Replace(txtParent.Text.Trim, "'", "''") & "', '" _
								& Replace(txtChild1.Text.Trim, "'", "''") & "', '" _
								& Replace(txtChild3.Text.Trim, "'", "''") & "', '" _
								& Replace(txtChild3.Text.Trim, "'", "''") & "'"

					.saveInfo("tbl_Store", field, values)
				End With
			End If

		ElseIf btnPCreate.Text = "Update" Then
			If checkProv() = False Then
				Exit Sub

			Else
				With conn
					Dim fld(7), val(7), dt(7) As String

					fld(0) = "storeCode"
					fld(1) = "dealerID"
					fld(2) = "locationID"
					fld(3) = "regionID"
					fld(4) = "parentBP"
					fld(5) = "childBP1"
					fld(6) = "childBP2"
					fld(7) = "childBP3"

					dt(0) = "C"
					dt(1) = "N"
					dt(2) = "N"
					dt(3) = "N"
					dt(4) = "C"
					dt(5) = "C"
					dt(6) = "C"
					dt(7) = "C"

					val(0) = Replace(txtSC.Text.Trim, "'", "''")
					val(1) = ddlSCDealer.SelectedValue.Trim
					val(2) = ddlSCLoc.SelectedValue.Trim
					val(3) = ddlSCRegion.SelectedValue.Trim
					val(4) = Replace(txtParent.Text.Trim, "'", "''")
					val(5) = Replace(txtChild1.Text.Trim, "'", "''")
					val(6) = Replace(txtChild2.Text.Trim, "'", "''")
					val(7) = Replace(txtChild3.Text.Trim, "'", "''")

					where = "storeID = " & Session("storeID")
					'where = "cityID = " & grdCity.DataKeys.Item(grdCity.SelectedIndex).Value(0).ToString
					.UpdateDB("tbl_Store", fld, val, dt, where)

					'clearItems()
				End With
			End If
		End If

		grdStore.DataBind()
		grdStore.Enabled = True

		ddlSCDealer.SelectedIndex = -1
		ddlSCLoc.Items.Clear()
		ddlSCRegion.SelectedIndex = -1
		txtSC.Text = ""
		txtParent.Text = ""
		txtChild1.Text = ""
		txtChild2.Text = ""
		txtChild3.Text = ""

		btnSCCreate.Text = "Save"
		btnSCCancel.Text = "Reset"
	End Sub

	Public Function checkStore() As Boolean
		checkStore = True

		If ddlSCDealer.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Dealer is required."
			checkStore = False
			Exit Function
		End If

		If ddlSCLoc.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Location is required."
			checkStore = False
			Exit Function
		End If

		If ddlSCRegion.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Region is required."
			checkStore = False
			Exit Function
		End If

		If txtProvince.Text.Trim = "" Then
			'lbleMsg.Text = "Province is required."
			'checkStore = False
			'Exit Function

		Else
			'check for duplicate
			Dim retFld(0), retVal(0) As String

			If Session("storeID") Is Nothing Then
				where = "shortCode = '" & txtSC.Text.Trim & "'"
			Else
				where = "shortCode = '" & txtSC.Text.Trim _
							& " AND storeID <> " & Session("storeID")
			End If

			If conn.checkID("tbl_Store", "*", where, 0, retVal, retFld, "", "") = "True" Then
				lbleMsg.Text = "Short Code has a duplicate."
				checkStore = False
				Exit Function
			End If
		End If
	End Function

	Protected Sub ddlSCDealer_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSCDealer.SelectedIndexChanged
		If ddlSCDealer.SelectedValue.Trim = "" Then
			ddlSCLoc.Items.Clear()

		Else
			where = "dealerID"
			ddlSCLoc.Items.Clear()
			conn.loadToDropDownList("vw_Location", ddlSCLoc, False, "*", where, "locationID", "location", "location", "")
		End If
	End Sub

	Protected Sub btnSCCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSCCancel.Click
		System.Threading.Thread.Sleep(500)

		If btnSCCancel.Text = "Cancel" Then
			btnSCCancel.Text = "Reset"

			Dim qry As String
			qry = "SELECT * FROM vw_Store ORDER BY location"

			grdStore.DataSourceID = ""
			grdStore.DataBind()
			sqlDS_Store.SelectCommand = qry
			grdStore.DataSourceID = "sqlDS_Store"
			grdStore.DataBind()

			grdStore.SelectedIndex = -1
			grdStore.Enabled = True
		End If

		ddlSCDealer.SelectedIndex = -1
		ddlSCRegion.SelectedIndex = -1
		ddlSCLoc.Items.Clear()
		txtSC.Text = ""
		txtParent.Text = ""
		txtChild1.Text = ""
		txtChild2.Text = ""
		txtChild3.Text = ""

		Session("storeID") = Nothing
	End Sub

	Protected Sub grdModel_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdModel.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		Dim cID As Integer
		Dim qry As String

		cID = grdModel.DataKeys(grdModel.SelectedIndex).Values(0).ToString()
		Session("modelID") = cID
		qry = "SELECT * FROM vw_Model WHERE modelID = " & cID

		grdModel.DataSourceID = ""
		grdModel.DataBind()
		sqlDS_Model.SelectCommand = qry
		grdModel.DataSourceID = "sqlDS_Model"
		grdModel.DataBind()
		grdModel.Enabled = False

		With conn
			'get details
			Dim retFld(2), retVal(2) As String

			retFld(0) = "brandID"
			retFld(1) = "model"
			retFld(2) = "productID"

			where = "modelID = " & cID
			.getValues("vw_Model", "*", where, 3, retFld, retVal, "", "", "")

			where = "productID = " & retVal(2)
			.loadToDropDownList("tbl_Brand", ddlMBrand, False, "*", where, "brandID", "brand", "brand", "")

			If retVal(0) = "" Or retVal(0) = "0" Then
				ddlMBrand.SelectedIndex = -1
			Else
				ddlMBrand.SelectedValue = retVal(0)
			End If

			txtModel.Text = retVal(1)
			ddlMProd.SelectedValue = retVal(2)

			btnMCreate.Text = "Update"
			btnMCancel.Text = "Cancel"
		End With
	End Sub

	Protected Sub btnMCreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMCreate.Click
		System.Threading.Thread.Sleep(500)

		If btnMCreate.Text = "Save" Then
			If checkModel() = False Then
				Exit Sub

			Else
				With conn
					Dim field, values As String

					field = "model, brandID"
					values = "'" & Replace(txtModel.Text.Trim, "'", "''") & "', " _
								& ddlMBrand.SelectedValue.Trim

					.saveInfo("tbl_Model", field, values)
				End With
			End If

		ElseIf btnMCreate.Text = "Update" Then
			If checkModel() = False Then
				Exit Sub

			Else
				With conn
					Dim fld(1), val(1), dt(1) As String

					fld(0) = "model"
					fld(1) = "brandID"

					dt(0) = "C"
					dt(1) = "N"

					val(0) = Replace(txtModel.Text.Trim, "'", "''")
					val(1) = ddlMBrand.SelectedValue.Trim

					where = "modelID = " & Session("modelID")
					'where = "cityID = " & grdCity.DataKeys.Item(grdCity.SelectedIndex).Value(0).ToString
					.UpdateDB("tbl_Model", fld, val, dt, where)

					'clearItems()
				End With
			End If
		End If

		grdModel.DataBind()
		grdModel.Enabled = True

		ddlMProd.SelectedIndex = -1
		ddlMBrand.Items.Clear()
		txtModel.Text = ""

		btnMCreate.Text = "Save"
		btnMCancel.Text = "Reset"
	End Sub

	Protected Sub btnMCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMCancel.Click
		System.Threading.Thread.Sleep(500)

		If btnMCancel.Text = "Cancel" Then
			btnMCancel.Text = "Reset"

			Dim qry As String
			qry = "SELECT * FROM vw_Model ORDER BY model"

			grdModel.DataSourceID = ""
			grdModel.DataBind()
			sqlDS_Model.SelectCommand = qry
			grdModel.DataSourceID = "sqlDS_Model"
			grdModel.DataBind()

			grdModel.SelectedIndex = -1
			grdModel.Enabled = True
		End If

		ddlMProd.SelectedIndex = -1
		ddlMBrand.Items.Clear()
		txtModel.Text = ""
		Session("modelID") = Nothing
	End Sub

	Public Function checkModel() As Boolean
		checkModel = True

		If ddlMBrand.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Brand is required."
			checkModel = False
			Exit Function
		End If

		If txtModel.Text.Trim = "" Then
			lbleMsg.Text = "Model is required."
			checkModel = False
			Exit Function

		Else
			'check for duplicate
			Dim retFld(0), retVal(0) As String

			If Session("modelID") Is Nothing Then
				where = "model = '" & txtModel.Text.Trim & "' AND brandID = " & ddlMBrand.SelectedValue.Trim
			Else
				where = "model = '" & txtModel.Text.Trim _
							& "' AND brandID = " & ddlMBrand.SelectedValue.Trim _
							& " AND modelID <> " & Session("modelID")
			End If

			If conn.checkID("tbl_Model", "*", where, 0, retVal, retFld, "", "") = "True" Then
				lbleMsg.Text = "Model has a duplicate."
				checkModel = False
				Exit Function
			End If
		End If
	End Function

	Private Sub grdCap_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCap.DataBound
		With conn
			.Page_Setup(grdCap.TopPagerRow, grdCap, "ddlCaPageNo", "imbCaFirst", "imbCaPrev", "imbCaNext", "imbCaLast", "lblCaPageCount")
			.Page_Setup(grdCap.BottomPagerRow, grdCap, "ddlCaPageNo", "imbCaFirst", "imbCaPrev", "imbCaNext", "imbCaLast", "lblCaPageCount")
		End With
	End Sub

	Protected Sub grdCap_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdCap.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		Dim cID As Integer
		Dim qry As String

		cID = grdCap.DataKeys(grdCap.SelectedIndex).Values(0).ToString()
		Session("capID") = cID
		qry = "SELECT * FROM vw_Capacity WHERE capacityID = " & cID

		grdCap.DataSourceID = ""
		grdCap.DataBind()
		sqlDS_Cap.SelectCommand = qry
		grdCap.DataSourceID = "sqlDS_Cap"
		grdCap.DataBind()
		grdCap.Enabled = False

		With conn
			'get details
			Dim retFld(2), retVal(2) As String

			retFld(0) = "productID"
			retFld(1) = "brandID"
			retFld(2) = "capacity"

			where = "capacityID = " & cID
			.getValues("vw_Capacity", "*", where, 3, retFld, retVal, "", "", "")

			ddlCBrand.Items.Clear()
			where = "productID = " & retVal(0) & " AND brandID = " & retVal(1)
			.loadToDropDownList("tbl_Brand", ddlCBrand, False, "*", where, "brandID", "brand", "brand", "")

			If retVal(0) = "" Or retVal(0) = "0" Then
				ddlCProd.SelectedIndex = -1
			Else
				ddlCProd.SelectedValue = retVal(0)
			End If

			If retVal(1) = "" Or retVal(1) = "0" Then
				ddlCBrand.SelectedIndex = -1
			Else
				ddlCBrand.SelectedValue = retVal(1)
			End If

			txtCap.Text = retVal(2)

			btnCapCreate.Text = "Update"
			btnCapCancel.Text = "Cancel"
		End With
	End Sub

	Protected Sub btnCapCreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCapCreate.Click
		System.Threading.Thread.Sleep(500)

		If btnCapCreate.Text = "Save" Then
			If checkCap() = False Then
				Exit Sub

			Else
				With conn
					Dim field, values As String

					field = "capacity, productID, brandID"
					values = "'" & Replace(txtCap.Text.Trim, "'", "''") & "', " _
								& ddlCProd.SelectedValue.Trim & ", " _
								& ddlCBrand.SelectedValue.Trim

					.saveInfo("tbl_Capacity", field, values)
				End With
			End If

		ElseIf btnCapCreate.Text = "Update" Then
			If checkCap() = False Then
				Exit Sub

			Else
				With conn
					Dim fld(2), val(2), dt(2) As String

					fld(0) = "capacity"
					fld(1) = "productID"
					fld(2) = "brandID"

					dt(0) = "C"
					dt(1) = "N"
					dt(2) = "N"

					val(0) = Replace(txtCap.Text.Trim, "'", "''")
					val(1) = ddlCProd.SelectedValue.Trim
					val(2) = ddlCBrand.SelectedValue.Trim

					where = "capacityID = " & Session("capID")
					'where = "cityID = " & grdCity.DataKeys.Item(grdCity.SelectedIndex).Value(0).ToString
					.UpdateDB("tbl_Capacity", fld, val, dt, where)

					'clearItems()
				End With
			End If
		End If

		grdCap.DataBind()
		grdCap.Enabled = True

		ddlCProd.SelectedIndex = -1
		ddlCBrand.Items.Clear()
		txtCap.Text = ""

		btnCapCreate.Text = "Save"
		btnCapCancel.Text = "Reset"
	End Sub

	Protected Sub btnCapCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCapCancel.Click
		System.Threading.Thread.Sleep(500)

		If btnCapCancel.Text = "Cancel" Then
			btnCapCancel.Text = "Reset"

			Dim qry As String
			qry = "SELECT * FROM vw_Capacity ORDER BY capacity"

			grdCap.DataSourceID = ""
			grdCap.DataBind()
			sqlDS_Cap.SelectCommand = qry
			grdCap.DataSourceID = "sqlDS_Cap"
			grdCap.DataBind()

			grdCap.SelectedIndex = -1
			grdCap.Enabled = True
		End If

		ddlCProd.SelectedIndex = -1
		ddlCBrand.Items.Clear()
		txtCap.Text = ""
		Session("capID") = Nothing
	End Sub

	Public Function checkCap() As Boolean
		checkCap = True

		If ddlCProd.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Product is required."
			checkCap = False
			Exit Function
		End If

		If ddlCBrand.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Brand is required."
			checkCap = False
			Exit Function
		End If

		If txtCap.Text.Trim = "" Then
			lbleMsg.Text = "Capacity is required."
			checkCap = False
			Exit Function

		Else
			'check for duplicate
			Dim retFld(0), retVal(0) As String

			If Session("capacityID") Is Nothing Then
				where = "capacity = '" & txtCap.Text.Trim _
						& "' AND productID = " & ddlCProd.SelectedValue.Trim _
						& " AND brandID = " & ddlCBrand.SelectedValue.Trim
			Else
				where = "capacity = '" & txtCap.Text.Trim _
							& "' AND productID = " & ddlCProd.SelectedValue.Trim _
							& "' AND brandID = " & ddlCBrand.SelectedValue.Trim _
							& " AND capacityID <> " & Session("capID")
			End If

			If conn.checkID("tbl_Capacity", "*", where, 0, retVal, retFld, "", "") = "True" Then
				lbleMsg.Text = "Capacity has a duplicate."
				checkCap = False
				Exit Function
			End If
		End If
	End Function

	Protected Sub ddlCProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCProd.SelectedIndexChanged
		If ddlCProd.SelectedValue.Trim = "" Then
			ddlCBrand.Items.Clear()

		Else
			ddlCBrand.Items.Clear()
			conn.loadToDropDownList("tbl_Brand", ddlCBrand, False, "*", where, "brandID", "brand", "brand", "")
		End If
	End Sub

	Protected Sub imbAVariant_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAVariant.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If txtVariant.Text.Trim = "" Then
			lbleMsg.Text = "No item to save."
			Exit Sub

		ElseIf imbAVariant.AlternateText = "Save" Then
			With conn
				'check for duplicate
				where = "variant = '" & txtVariant.Text.Trim & "'"

				If checkForDuplicate("tbl_Variant", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					.saveInfo("tbl_Variant", "variant", "'" & Replace(txtVariant.Text.Trim, "'", "''") & "'")

					lstVariant.Items.Clear()
					.loadToListBox("tbl_Variant", lstVariant, False, "*", "variantID", "variant", "", "variant", "")
				End If
			End With

			txtVariant.Text = ""
			lstVariant.Enabled = True

			imbAVariant.AlternateText = "Save"

			imbMVariant.AlternateText = "Modify"
			imbMVariant.ImageUrl = "~/images/icons/modify.png"

		ElseIf imbAVariant.AlternateText = "Update" Then
			With conn
				'check for duplicate
				where = "variant = '" & txtVariant.Text.Trim & "' AND variantID <> " & lstVariant.SelectedValue.Trim
				If checkForDuplicate("tbl_Variant", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					Dim fld(0), val(0), dt(0) As String

					fld(0) = "variant"
					val(0) = Replace(txtVariant.Text.Trim, "'", "''")
					dt(0) = "C"

					where = "variantID = " & lstVariant.SelectedValue.Trim
					.UpdateDB("tbl_Variant", fld, val, dt, where)

					lstVariant.Items.Clear()
					.loadToListBox("tbl_Variant", lstVariant, True, "variantID", "variantID", "variant", "", "variant", "")
				End If
			End With

			txtVariant.Text = ""

			lstVariant.DataBind()
			lstVariant.Enabled = True

			imbAVariant.AlternateText = "Save"

			imbMVariant.AlternateText = "Modify"
			imbMVariant.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbMVariant_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbMVariant.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If lstVariant.SelectedIndex = -1 Then
			txtVariant.Text = ""
			lbleMsg.Text = "Please select an item to modify."
			Exit Sub

		ElseIf imbMVariant.AlternateText = "Modify" Then
			txtVariant.Text = lstVariant.SelectedItem.Text
			lstVariant.Enabled = False

			imbAVariant.Enabled = True
			imbAVariant.AlternateText = "Update"

			imbMVariant.AlternateText = "Cancel"
			imbMVariant.ImageUrl = "~/images/icons/cancel.png"


		ElseIf imbMVariant.AlternateText = "Cancel" Then
			txtVariant.Text = ""
			lstVariant.Enabled = True

			imbAVariant.Enabled = True
			imbAVariant.AlternateText = "Save"

			imbMVariant.AlternateText = "Modify"
			imbMVariant.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbAAction_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbAAction.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If txtAction.Text.Trim = "" Then
			lbleMsg.Text = "No item to save."
			Exit Sub

		ElseIf imbAAction.AlternateText = "Save" Then
			With conn
				'check for duplicate
				where = "actionTaken = '" & txtAction.Text.Trim & "'"

				If checkForDuplicate("tbl_Action", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					.saveInfo("tbl_Action", "actionTaken", "'" & Replace(txtAction.Text.Trim, "'", "''") & "'")

					lstAction.Items.Clear()
					.loadToListBox("tbl_Action", lstAction, False, "*", "actionID", "actionTaken", "", "actionTaken", "")
				End If
			End With

			txtAction.Text = ""
			lstAction.Enabled = True

			imbAAction.AlternateText = "Save"

			imbMAction.AlternateText = "Modify"
			imbMAction.ImageUrl = "~/images/icons/modify.png"

		ElseIf imbAAction.AlternateText = "Update" Then
			With conn
				'check for duplicate
				where = "actionTaken = '" & txtAction.Text.Trim & "' AND actionID <> " & lstAction.SelectedValue
				If checkForDuplicate("tbl_Action", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					Dim fld(0), val(0), dt(0) As String

					fld(0) = "actionTaken"
					val(0) = Replace(txtAction.Text.Trim, "'", "''")
					dt(0) = "C"

					where = "actionID = " & lstAction.SelectedValue.Trim
					.UpdateDB("tbl_Action", fld, val, dt, where)

					lstAction.Items.Clear()
					.loadToListBox("tbl_Action", lstAction, True, "actionID", "actionID", "actionTaken", "", "actionTaken", "")
				End If
			End With

			txtAction.Text = ""

			lstAction.DataBind()
			lstAction.Enabled = True

			imbAAction.AlternateText = "Save"

			imbMAction.AlternateText = "Modify"
			imbMAction.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbMAction_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbMAction.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If lstAction.SelectedIndex = -1 Then
			txtAction.Text = ""
			lbleMsg.Text = "Please select an item to modify."
			Exit Sub

		ElseIf imbMAction.AlternateText = "Modify" Then
			txtAction.Text = lstAction.SelectedItem.Text
			lstAction.Enabled = False

			imbAAction.Enabled = True
			imbAAction.AlternateText = "Update"

			imbMAction.AlternateText = "Cancel"
			imbMAction.ImageUrl = "~/images/icons/cancel.png"


		ElseIf imbMAction.AlternateText = "Cancel" Then
			txtAction.Text = ""
			lstAction.Enabled = True

			imbAAction.Enabled = True
			imbAAction.AlternateText = "Save"

			imbMAction.AlternateText = "Modify"
			imbMAction.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbACBrand_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbACBrand.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If txtCBrand.Text.Trim = "" Then
			lbleMsg.Text = "No item to save."
			Exit Sub

		ElseIf imbACBrand.AlternateText = "Save" Then
			With conn
				'check for duplicate
				where = "CBrand = '" & txtCBrand.Text.Trim & "'"

				If checkForDuplicate("tbl_CBrand", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					.saveInfo("tbl_CBrand", "CBrand", "'" & Replace(txtCBrand.Text.Trim, "'", "''") & "'")

					lstCBrand.Items.Clear()
					.loadToListBox("tbl_CBrand", lstCBrand, False, "*", "CBrandID", "CBrand", "", "CBrand", "")
				End If
			End With

			txtCBrand.Text = ""
			lstCBrand.Enabled = True

			imbACBrand.AlternateText = "Save"

			imbMCBrand.AlternateText = "Modify"
			imbMCBrand.ImageUrl = "~/images/icons/modify.png"

		ElseIf imbACBrand.AlternateText = "Update" Then
			With conn
				'check for duplicate
				where = "CBrand = '" & txtCBrand.Text.Trim & "' AND CBrandID <> " & lstCBrand.SelectedValue
				If checkForDuplicate("tbl_CBrand", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					Dim fld(0), val(0), dt(0) As String

					fld(0) = "CBrand"
					val(0) = Replace(txtCBrand.Text.Trim, "'", "''")
					dt(0) = "C"

					where = "CBrandID = " & lstCBrand.SelectedValue.Trim
					.UpdateDB("tbl_CBrand", fld, val, dt, where)

					lstCBrand.Items.Clear()
					.loadToListBox("tbl_CBrand", lstCBrand, False, "*", "CBrandID", "CBrand", "", "CBrand", "")
				End If
			End With

			txtCBrand.Text = ""

			lstCBrand.DataBind()
			lstCBrand.Enabled = True

			imbACBrand.AlternateText = "Save"

			imbMCBrand.AlternateText = "Modify"
			imbMCBrand.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbMCBrand_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbMCBrand.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If lstCBrand.SelectedIndex = -1 Then
			txtCBrand.Text = ""
			lbleMsg.Text = "Please select an item to modify."
			Exit Sub

		ElseIf imbMCBrand.AlternateText = "Modify" Then
			txtCBrand.Text = lstCBrand.SelectedItem.Text
			lstCBrand.Enabled = False

			imbACBrand.Enabled = True
			imbACBrand.AlternateText = "Update"

			imbMCBrand.AlternateText = "Cancel"
			imbMCBrand.ImageUrl = "~/images/icons/cancel.png"


		ElseIf imbMCBrand.AlternateText = "Cancel" Then
			txtCBrand.Text = ""
			lstCBrand.Enabled = True

			imbACBrand.Enabled = True
			imbACBrand.AlternateText = "Save"

			imbMCBrand.AlternateText = "Modify"
			imbMCBrand.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbACCap_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbACCap.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If txtCCap.Text.Trim = "" Then
			lbleMsg.Text = "No item to save."
			Exit Sub

		ElseIf imbACCap.AlternateText = "Save" Then
			With conn
				'check for duplicate
				where = "cCapacity = '" & txtProd.Text.Trim & "'"

				If checkForDuplicate("tbl_CCapacity", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					.saveInfo("tbl_CCapacity", "CCapacity", "'" & Replace(txtCCap.Text.Trim, "'", "''") & "'")

					lstCCap.Items.Clear()
					.loadToListBox("tbl_CCapacity", lstCCap, False, "*", "CCapacityID", "CCapacity", "", "CCapacity", "")
				End If
			End With

			txtCCap.Text = ""
			lstCCap.Enabled = True

			imbACCap.AlternateText = "Save"

			imbMCCap.AlternateText = "Modify"
			imbMCCap.ImageUrl = "~/images/icons/modify.png"

		ElseIf imbACCap.AlternateText = "Update" Then
			With conn
				'check for duplicate
				where = "CCapacity = '" & txtCCap.Text.Trim & "' AND CCapacityID <> " & lstCCap.SelectedValue
				If checkForDuplicate("tbl_CCapacity", where) = True Then
					lbleMsg.Text = "Duplicate items are not allowed."
					Exit Sub

				Else
					Dim fld(0), val(0), dt(0) As String

					fld(0) = "CCapacity"
					val(0) = Replace(txtCCap.Text.Trim, "'", "''")
					dt(0) = "C"

					where = "CCapacityID = " & lstCCap.SelectedValue.Trim
					.UpdateDB("tbl_CCapacity", fld, val, dt, where)

					lstCCap.Items.Clear()
					.loadToListBox("tbl_CCapacity", lstCCap, True, "CCapacityID", "CCapacityID", "CCapacity", "", "CCapacity", "")
				End If
			End With

			txtCCap.Text = ""

			lstCCap.DataBind()
			lstCCap.Enabled = True

			imbACCap.AlternateText = "Save"

			imbMCCap.AlternateText = "Modify"
			imbMCCap.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub imbMCCap_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbMCCap.Click
		System.Threading.Thread.Sleep(500)

		checkSession()
		lbleMsg.Text = ""

		If lstCCap.SelectedIndex = -1 Then
			txtCCap.Text = ""
			lbleMsg.Text = "Please select an item to modify."
			Exit Sub

		ElseIf imbMCCap.AlternateText = "Modify" Then
			txtCCap.Text = lstCCap.SelectedItem.Text
			lstCCap.Enabled = False

			imbACCap.Enabled = True
			imbACCap.AlternateText = "Update"

			imbMCCap.AlternateText = "Cancel"
			imbMCCap.ImageUrl = "~/images/icons/cancel.png"


		ElseIf imbMCCap.AlternateText = "Cancel" Then
			txtCCap.Text = ""
			lstCCap.Enabled = True

			imbACCap.Enabled = True
			imbACCap.AlternateText = "Save"

			imbMCCap.AlternateText = "Modify"
			imbMCCap.ImageUrl = "~/images/icons/modify.png"
		End If
	End Sub

	Protected Sub btnTWCreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTWCreate.Click
		System.Threading.Thread.Sleep(500)

		If btnTWCreate.Text = "Save" Then
			If checkTW() = False Then
				Exit Sub

			Else
				With conn
					Dim field, values As String

					field = "TQWeek, weekID, targetProdID"
					values = txtWeek.Text.Trim & ", " _
								& ddlTWeek.SelectedValue.Trim & ", " _
								& ddlTProd.SelectedValue.Trim

					.saveInfo("tbl_Target", field, values)
				End With
			End If

		ElseIf btnTWCreate.Text = "Update" Then
			If checkTW() = False Then
				Exit Sub

			Else
				With conn
					Dim fld(2), val(2), dt(2) As String

					fld(0) = "TQWeek"
					fld(1) = "weekID"
					fld(2) = "targetProdID"

					dt(0) = "N"
					dt(1) = "N"
					dt(2) = "N"

					val(0) = txtWeek.Text.Trim
					val(1) = ddlTWeek.SelectedValue.Trim
					val(2) = ddlTProd.SelectedValue.Trim

					where = "targetID = " & Session("targetID")
					'where = "cityID = " & grdCity.DataKeys.Item(grdCity.SelectedIndex).Value(0).ToString
					.UpdateDB("tbl_Target", fld, val, dt, where)

					'clearItems()
				End With
			End If
		End If

		grdTarget.DataBind()
		grdTarget.Enabled = True

		ddlTProd.SelectedIndex = -1
		ddlTWeek.SelectedIndex = -1
		txtWeek.Text = ""

		btnTWCreate.Text = "Save"
		btnTWCancel.Text = "Reset"
	End Sub

	Public Function checkTW() As Boolean
		checkTW = True

		If ddlTProd.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Product is required."
			checkTW = False
			Exit Function
		End If

		If ddlTWeek.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Week Coverage is required."
			checkTW = False
			Exit Function
		End If

		If txtWeek.Text.Trim = "" Then
			lbleMsg.Text = "Week Quota is required."
			checkTW = False
			Exit Function

		ElseIf IsNumeric(txtWeek.Text.Trim) = False Then
			lbleMsg.Text = "Week Quota should be numeric."
			checkTW = False
			Exit Function

		Else
			'check for duplicate
			Dim retFld(0), retVal(0) As String

			If Session("targetID") Is Nothing Then
				where = "weekID = " & ddlTWeek.SelectedValue.Trim & " AND targetProdID = " & ddlTProd.SelectedValue.Trim
			Else
				where = "weekID = " & ddlTWeek.SelectedValue.Trim _
							& "' AND targetProdID = " & ddlTProd.SelectedValue.Trim _
							& " AND targetID <> " & Session("targetID")
			End If

			If conn.checkID("tbl_Target", "*", where, 0, retVal, retFld, "", "") = "True" Then
				lbleMsg.Text = "Quota for week " & ddlTWeek.SelectedItem.Text & " has already been set."
				checkTW = False
				Exit Function
			End If
		End If
	End Function

	Protected Sub btnTWCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTWCancel.Click
		System.Threading.Thread.Sleep(500)

		If btnTWCancel.Text = "Cancel" Then
			btnTWCancel.Text = "Reset"

			Dim qry As String
			qry = "SELECT * FROM vw_Target"

			grdTarget.DataSourceID = ""
			grdTarget.DataBind()
			sqlDS_Target.SelectCommand = qry
			grdTarget.DataSourceID = "sqlDS_Target"
			grdTarget.DataBind()

			grdTarget.SelectedIndex = -1
			grdTarget.Enabled = True
		End If

		ddlTProd.SelectedIndex = -1
		ddlTWeek.SelectedIndex = -1
		txtWeek.Text = ""
		Session("weekID") = Nothing
	End Sub

	Protected Sub btnTMCreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTMCreate.Click
		System.Threading.Thread.Sleep(500)

		If btnTMCreate.Text = "Save" Then
			If checkTM() = False Then
				Exit Sub

			Else
				With conn
					Dim field, values As String

					field = "TQMonth, monthNo, targetProdID"
					values = txtMonth.Text.Trim & ", " _
								& ddlMonth.SelectedValue.Trim & ", " _
								& ddlTProd.SelectedValue.Trim

					.saveInfo("tbl_Target", field, values)
				End With
			End If

		ElseIf btnTMCreate.Text = "Update" Then
			If checkTM() = False Then
				Exit Sub

			Else
				With conn
					Dim fld(2), val(2), dt(2) As String

					fld(0) = "TQMonth"
					fld(1) = "monthNo"
					fld(2) = "targetProdID"

					dt(0) = "N"
					dt(1) = "N"
					dt(2) = "N"

					val(0) = txtProvince.Text.Trim
					val(1) = ddlMonth.SelectedValue.Trim
					val(2) = ddlTProd.SelectedValue.Trim

					where = "targetID = " & Session("targetID")
					'where = "cityID = " & grdCity.DataKeys.Item(grdCity.SelectedIndex).Value(0).ToString
					.UpdateDB("tbl_Target", fld, val, dt, where)

					'clearItems()
				End With
			End If
		End If

		grdTarget.DataBind()
		grdTarget.Enabled = True

		ddlTProd.SelectedIndex = -1
		ddlMonth.SelectedIndex = -1
		txtMonth.Text = ""

		btnTMCreate.Text = "Save"
		btnTMCancel.Text = "Reset"
	End Sub

	Protected Sub btnTMCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTMCancel.Click
		System.Threading.Thread.Sleep(500)

		If btnTMCancel.Text = "Cancel" Then
			btnTMCancel.Text = "Reset"

			Dim qry As String
			qry = "SELECT * FROM vw_Target"

			grdTarget.DataSourceID = ""
			grdTarget.DataBind()
			sqlDS_Target.SelectCommand = qry
			grdTarget.DataSourceID = "sqlDS_Target"
			grdTarget.DataBind()

			grdTarget.SelectedIndex = -1
			grdTarget.Enabled = True
		End If

		ddlTProd.SelectedIndex = -1
		ddlMonth.SelectedIndex = -1
		txtMonth.Text = ""
		Session("targetID") = Nothing
	End Sub

	Public Function checkTM() As Boolean
		checkTM = True

		If ddlTProd.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Product is required."
			checkTM = False
			Exit Function
		End If

		If ddlMonth.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Month is required."
			checkTM = False
			Exit Function
		End If

		If ddlMYear.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Year is required."
			checkTM = False
			Exit Function
		End If

		If txtMonth.Text.Trim = "" Then
			lbleMsg.Text = "Month Quota is required."
			checkTM = False
			Exit Function

		ElseIf IsNumeric(txtMonth.Text.Trim) = False Then
			lbleMsg.Text = "Month Quota should be numeric."
			checkTM = False
			Exit Function

		Else
			'check for duplicate
			Dim retFld(0), retVal(0) As String

			If Session("targetID") Is Nothing Then
				where = "monthNo = " & ddlMonth.SelectedValue.Trim & " AND targetProdID = " & ddlTProd.SelectedValue.Trim
			Else
				where = "monthNo = " & ddlMonth.SelectedValue.Trim _
							& " AND targetProdID = " & ddlTProd.SelectedValue.Trim _
							& " AND targetID <> " & Session("targetID")
			End If

			If conn.checkID("tbl_Target", "*", where, 0, retVal, retFld, "", "") = "True" Then
				lbleMsg.Text = "Quota for " & ddlMonth.SelectedItem.Text & " " & ddlMYear.SelectedValue.Trim & " has already been set."
				checkTM = False
				Exit Function
			End If
		End If
	End Function

	Protected Sub btnTYCreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTYCreate.Click
		System.Threading.Thread.Sleep(500)

		If btnTYCreate.Text = "Save" Then
			If checkTY() = False Then
				Exit Sub

			Else
				With conn
					Dim field, values As String

					field = "TQYear, targetProdID, yr"
					values = txtYear.Text.Trim & ", " _
								& ddlTProd.SelectedValue.Trim & ", " _
								& ddlYear.SelectedValue.Trim

					.saveInfo("tbl_Target", field, values)
				End With
			End If

		ElseIf btnTYCreate.Text = "Update" Then
			If checkTY() = False Then
				Exit Sub

			Else
				With conn
					Dim fld(2), val(2), dt(2) As String

					fld(0) = "yr"
					fld(1) = "targetProdID"
					fld(2) = "TQYear"

					dt(0) = "C"
					dt(1) = "N"
					dt(2) = "N"

					val(0) = ddlYear.SelectedValue.Trim
					val(1) = ddlTProd.SelectedValue.Trim
					val(2) = txtYear.Text.Trim

					where = "targetID = " & Session("targetID")
					'where = "cityID = " & grdCity.DataKeys.Item(grdCity.SelectedIndex).Value(0).ToString
					.UpdateDB("tbl_Target", fld, val, dt, where)

					'clearItems()
				End With
			End If
		End If

		grdTarget.DataBind()
		grdTarget.Enabled = True

		ddlTProd.SelectedIndex = -1
		ddlYear.SelectedIndex = -1
		txtYear.Text = ""

		btnTYCreate.Text = "Save"
		btnTYCancel.Text = "Reset"
	End Sub

	Public Function checkTY() As Boolean
		checkTY = True

		If ddlTProd.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Product is required."
			checkTY = False
			Exit Function
		End If

		If ddlYear.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Year is required."
			checkTY = False
			Exit Function
		End If

		If txtYear.Text.Trim = "" Then
			lbleMsg.Text = "Year Quota is required."
			checkTY = False
			Exit Function

		ElseIf IsNumeric(txtYear.Text.Trim) = False Then
			lbleMsg.Text = "Year Quota should be numeric."
			checkTY = False
			Exit Function

		Else
			'check for duplicate
			Dim retFld(0), retVal(0) As String

			If Session("targetID") Is Nothing Then
				where = "yr = '" & ddlYear.SelectedValue.Trim & "' AND targetProdID = " & ddlTProd.SelectedValue.Trim
			Else
				where = "yr = '" & ddlYear.SelectedValue.Trim _
							& "' AND targetProdID = " & ddlTProd.SelectedValue.Trim _
							& " AND targetID <> " & Session("targetID")
			End If

			If conn.checkID("tbl_Target", "*", where, 0, retVal, retFld, "", "") = "True" Then
				lbleMsg.Text = "Quota for the year " & ddlYear.SelectedValue.Trim & " has already been set."
				checkTY = False
				Exit Function
			End If
		End If
	End Function

	Protected Sub btnAcReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAcReset.Click
		If txtAUname.Text = "" Then
			lbleMsg3.Text = "Kindly input your username first."
			Exit Sub

		ElseIf InStr(txtAUname.Text.Trim, "'", CompareMethod.Text) <> 0 Then
			lbleMsg3.Text = "Special characters are not allowed except for a dot/period (.)"
			Exit Sub

		Else
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

				val(0) = validatePWD(txtAUname.Text.Trim)
				val(1) = "5"
				val(2) = "0"
				val(3) = ""

				where = "userID = " & Session("uID")
				.UpdateDB("tbl_Login", fld, val, dt, where)
				lbleMsg3.Text = "Password has been reset. Default password is the user's username.<br />If username is less than 8 characters, please affix '0' before typing the username to make an 8-digit password.<br />Also, please be reminded that password is case sensitive."
			End With
		End If
	End Sub

	Protected Sub ddlPPageNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)

		Dim ddlPageNo As DropDownList = sender

		If ddlPageNo IsNot Nothing Then
			If grdProv.Rows.Count > 0 Then
				If ddlPageNo.SelectedIndex < grdProv.PageCount Or _
					ddlPageNo.SelectedIndex >= 0 Then

					grdProv.PageIndex = ddlPageNo.SelectedIndex
				End If
			End If
		End If
	End Sub

	Protected Sub ddlCPageNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)

		Dim ddlPageNo As DropDownList = sender

		If ddlPageNo IsNot Nothing Then
			If grdCity.Rows.Count > 0 Then
				If ddlPageNo.SelectedIndex < grdCity.PageCount Or _
					ddlPageNo.SelectedIndex >= 0 Then

					grdCity.PageIndex = ddlPageNo.SelectedIndex
				End If
			End If
		End If
	End Sub

	Protected Sub ddlSPageNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)

		Dim ddlPageNo As DropDownList = sender

		If ddlPageNo IsNot Nothing Then
			If grdCity.Rows.Count > 0 Then
				If ddlPageNo.SelectedIndex < grdCity.PageCount Or _
					ddlPageNo.SelectedIndex >= 0 Then

					grdCity.PageIndex = ddlPageNo.SelectedIndex
				End If
			End If
		End If
	End Sub

	Protected Sub ddlTPageNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)

		Dim ddlPageNo As DropDownList = sender

		If ddlPageNo IsNot Nothing Then
			If grdTarget.Rows.Count > 0 Then
				If ddlPageNo.SelectedIndex < grdTarget.PageCount Or _
					ddlPageNo.SelectedIndex >= 0 Then

					grdTarget.PageIndex = ddlPageNo.SelectedIndex
				End If
			End If
		End If
	End Sub

	Private Sub grdTarget_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTarget.DataBound
		With conn
			.Page_Setup(grdTarget.TopPagerRow, grdTarget, "ddlTPageNo", "imbTFirst", "imbTPrev", "imbTNext", "imbTLast", "lblTPageCount")
			.Page_Setup(grdTarget.BottomPagerRow, grdTarget, "ddlTPageNo", "imbTFirst", "imbTPrev", "imbTNext", "imbTLast", "lblTPageCount")
		End With
	End Sub

	Protected Sub ddlStPageNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)

		Dim ddlPageNo As DropDownList = sender

		If ddlPageNo IsNot Nothing Then
			If grdStore.Rows.Count > 0 Then
				If ddlPageNo.SelectedIndex < grdStore.PageCount Or _
					ddlPageNo.SelectedIndex >= 0 Then

					grdStore.PageIndex = ddlPageNo.SelectedIndex
				End If
			End If
		End If
	End Sub

	Protected Sub ddlCaPageNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)

		Dim ddlPageNo As DropDownList = sender

		If ddlPageNo IsNot Nothing Then
			If grdCap.Rows.Count > 0 Then
				If ddlPageNo.SelectedIndex < grdCap.PageCount Or _
					ddlPageNo.SelectedIndex >= 0 Then

					grdCap.PageIndex = ddlPageNo.SelectedIndex
				End If
			End If
		End If
	End Sub

	Protected Sub btnDeactivate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeactivate.Click
		With conn
			Dim fld(0), val(0), dt(0) As String

			fld(0) = "loginStatusID"
			val(0) = "6"
			dt(0) = "N"

			where = "userID = " & Session("uID")
			.UpdateDB("tbl_Login", fld, val, dt, where)

			grdAccount.DataBind()
			lbleMsg3.Text = "Account has been successfully deactivated."

			btnAEmp.Visible = True
			btnUnlock.Visible = True
			btnReactivate.Visible = True

			panUSearch.Visible = True
			panAEmp.Visible = False
		End With
	End Sub

	Protected Sub lnkReactivate_Click(ByVal sender As Object, ByVal e As EventArgs)
		With conn
			Dim lnkRe As LinkButton = sender
			Dim uID As Double = Convert.ToInt32(lnkRe.CommandArgument)

			Dim retFld(0), retVal(0) As String
			retFld(0) = "uname"

			where = "userID = " & uID
			.getValues("tbl_Login", "*", where, 1, retFld, retVal, "", "", "")

			Dim uname As String = retVal(0)
			Dim fld(3), val(3), dt(3) As String

			fld(0) = "loginStatusID"
			fld(1) = "pwd"
			fld(2) = "lockedCount"
			fld(3) = "lockedDate"

			val(0) = "5"
			val(1) = validatePWD(uname)
			val(2) = "0"
			val(3) = ""

			dt(0) = "N"
			dt(1) = "C"
			dt(2) = "N"
			dt(3) = "C"

			where = "userID = " & uID
			.UpdateDB("tbl_Login", fld, val, dt, where)

			lbleMsg.Text = "Account has been reactivated."
			grdDeactivate.DataBind()
		End With
	End Sub

	Protected Sub btnReactivate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReactivate.Click
		btnAEmp.Enabled = True
		btnUnlock.Enabled = True
		btnReactivate.Enabled = True

		panAEmp.Visible = False
		panUsers.Visible = False
		panUnlock.Visible = False
		panDeactivate.Visible = True

		grdDeactivate.DataBind()
	End Sub

	Protected Sub grdAnnounce_RowDataBound(sender As Object, e As GridViewRowEventArgs)
		If e.Row.RowType = DataControlRowType.DataRow Then
			'1. this will work:
			'e.Row.Cells(0).ToolTip = "AsdfasdfadsfA"
			e.Row.Cells(0).Attributes.Add("AlternateText", "aaaaa")
			'2. this will work too:

			'e.Row.Cells(0).Attributes.Add("ToolTip", "asdffasdfasdf")
		End If
	End Sub

	Protected Sub btnPopDay_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		hideBtns()
		defBtn()
		hidePanels()
		pnlPopDay.Visible = True
		pnlPopWeek.Visible = False
	End Sub

	Protected Sub btnPopWeek_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		hideBtns()
		defBtn()
		hidePanels()
		pnlPopDay.Visible = False
		pnlPopWeek.Visible = True
	End Sub

End Class