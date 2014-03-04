Public Class ReportUpdate
    Inherits System.Web.UI.Page

    Public conn As New clsConn
    Public mstr As New MasterPage

    Public where, qry As String
    Public formatToSave As String = "d/M/yyyy"
    Public formatToShow As String = "MMM dd, yyyy"

    Public Sub checkRights()
        On Error Resume Next

        lProd.Visible = False
        panSales.Visible = False

        lCompete.Visible = False
        panCompete.Visible = False

        lStocks.Visible = False
        panStocks.Visible = False

        lInventory.Visible = False
		panInventory.Visible = False

		lTMSales.Visible = False
		panTMSales.Visible = False

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
                    lProd.Visible = True
                    lnkProd.CssClass = "tabprop-Selected"
                    panSales.Visible = True
                    rCount += 1
                End If

                If aRyt(counter) = "SCR" Then
                    lCompete.Visible = True

                    If lProd.Visible = True Then
                        panCompete.Visible = False
                    Else
                        lnkCompete.CssClass = "tabprop-Selected"
                        panCompete.Visible = True
                    End If

                    rCount += 1
                End If

                If aRyt(counter) = "SSR" Then
                    lStocks.Visible = True

                    If lProd.Visible = True Or
                        lCompete.Visible = True Then

                        panStocks.Visible = False

                    Else
                        lnkStocks.CssClass = "tabprop-Selected"
                        panStocks.Visible = True
                    End If

                    rCount += 1
                End If

                If aRyt(counter) = "SIR" Then
                    lInventory.Visible = True

                    If lProd.Visible = True Or
                        lCompete.Visible = True Or
                        lStocks.Visible = True Then

                        panInventory.Visible = False

                    Else
                        lnkInventory.CssClass = "tabprop-Selected"
                        panInventory.Visible = True
                    End If

                    rCount += 1
				End If

				If aRyt(counter) = "TMS" Then
					lTMSales.Visible = True

					If lProd.Visible = True Or
						lCompete.Visible = True Or
						lStocks.Visible = True Or
						lInventory.Visible = True Then

						panTMSales.Visible = False
					Else
						lnkTMSales.CssClass = "tabprop-Selected"
						panTMSales.Visible = True
					End If

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            checkRights()
            checkUType()

            conn.loadToDropDownList("tbl_Product", ddlProd, False, "*", "", "productID", "product", "product", "")
			'conn.loadToDropDownList("tbl_CBrand", ddlBrand, False, "*", "", "cBrandID", "cBrand", "cBrand", "")
			
			conn.loadToDropDownList("vw_Week", ddlWeek, False, "*", "", "weekID", "weekCoverage", "weekCoverage", "")
            conn.loadToDropDownList("tbl_City", ddlCity, False, "*", "", "cityID", "city", "city", "")
        End If
    End Sub

    Public Sub checkUType()
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "accntTypeID"

            where = "userID = " & Session("userID")
            .getValues("tbl_Login", "userID, accntTypeID", where, 1, retFld, retVal, "", "", "")

			Dim qSales, qCompete, qStocks, qInventory, qTM As String

			If retVal(0) = "1" Then		'super admin
				pnlFC.Visible = True
				pnlSFC.Visible = True
				pnlIFC.Visible = True
				pnlTFC.Visible = True

				.loadToDropDownList("vw_Users", ddlEmp, False, "*", "", "userID", "empName", "empName", "")
				.loadToDropDownList("vw_Users", ddlSEmp, False, "*", "", "userID", "empName", "empName", "")
				.loadToDropDownList("vw_Users", ddlIEmp, False, "*", "", "userID", "empName", "empName", "")
				.loadToDropDownList("vw_Users", ddlTEmp, False, "*", "", "userID", "empName", "empName", "")

				.loadToDropDownList("vw_FC", ddlFC, False, "*", "", "userID", "FCName", "FCName", "")
				.loadToDropDownList("vw_FC", ddlSFC, False, "*", "", "userID", "FCName", "FCName", "")
				.loadToDropDownList("vw_FC", ddlIFC, False, "*", "", "userID", "FCName", "FCName", "")
				.loadToDropDownList("vw_FC", ddlTFC, False, "*", "", "userID", "FCName", "FCName", "")

				qSales = "SELECT * FROM vw_SalesReport"
				qCompete = "SELECT * FROM vw_CompeteReport"
				qStocks = "SELECT * FROM vw_StocksReport"
				qInventory = "SELECT * FROM vw_InventoryReport"
				qTM = "SELECT * FROM vw_SalesReport"

			ElseIf retVal(0) = "5" Or retVal(0) = "6" Then	   'fc
				'retrieve disers assigned to them
				'where = "(accntTypeID = 6 AND fcID = " & Session("userID") & ") OR (accntTypeID = 7 AND fcID = " & Session("userID") & ")"
				where = "fcID = " & Session("userID") & " OR userID = " & Session("userID")

				.loadToDropDownList("vw_Users", ddlEmp, False, "*", where, "userID", "empName", "empName", "")
				.loadToDropDownList("vw_Users", ddlSEmp, False, "*", where, "userID", "empName", "empName", "")
				.loadToDropDownList("vw_Users", ddlIEmp, False, "*", where, "userID", "empName", "empName", "")
				.loadToDropDownList("vw_Users", ddlTEmp, False, "*", where, "userID", "empName", "empName", "")

				qSales = "SELECT * FROM vw_SalesReport WHERE " & where
				qCompete = "SELECT * FROM vw_CompeteReport WHERE " & where
				qStocks = "SELECT * FROM vw_StocksReport WHERE " & where
				qInventory = "SELECT * FROM vw_InventoryReport WHERE " & where
				qTM = "SELECT * FROM vw_SalesReport WHERE " & where

			ElseIf retVal(0) = "9" Then		'sfc
				'retrieve fcs
				Dim retFld1(0), retVal1(0) As String
				Dim where1 As String = ""
				retFld1(0) = "userID"

				where1 = "accntTypeID = 5 AND sFCID = " & Session("userID")
				.getRecords("vw_Users", "accntTypeID, sFCID, userID", where1, 1, retFld1, retVal1, "", "")

				Dim fcID() As String = Split(retVal1(0), "+")
				Dim cnt As Double = 1
				Dim counter As Double = 0
				Dim where2 As String = ""

				Do While cnt <= UBound(fcID) + 1
					If where2 = "" Then
						where2 = "userID = " & fcID(counter) & " OR fcID = " & fcID(counter)
					Else
						where2 += " OR userID = " & fcID(counter) & " OR fcID = " & fcID(counter)
					End If
					cnt += 1
					counter += 1
				Loop

				where = where2

				.loadToDropDownList("vw_Users", ddlEmp, False, "*", "", "userID", "empName", "empName", "")
				.loadToDropDownList("vw_Users", ddlSEmp, False, "*", "", "userID", "empName", "empName", "")
				.loadToDropDownList("vw_Users", ddlIEmp, False, "*", "", "userID", "empName", "empName", "")
				.loadToDropDownList("vw_Users", ddlTEmp, False, "*", "", "userID", "empName", "empName", "")

				qSales = "SELECT * FROM vw_SalesReport WHERE " & where
				qCompete = "SELECT * FROM vw_CompeteReport WHERE " & where
				qStocks = "SELECT * FROM vw_StocksReport WHERE " & where
				qInventory = "SELECT * FROM vw_InventoryReport WHERE " & where
				qTM = "SELECT * FROM vw_SalesReport WHERE " & where
			End If

            grdSales.DataSourceID = ""
            grdSales.DataBind()
            sqlDS_Sales.SelectCommand = qSales
            grdSales.DataSourceID = "sqlDS_Sales"
            grdSales.DataBind()

            grdCompete.DataSourceID = ""
            grdCompete.DataBind()
            sqlDS_Compete.SelectCommand = qCompete
            grdCompete.DataSourceID = "sqlDS_Compete"
            grdCompete.DataBind()

            grdStocks.DataSourceID = ""
            grdStocks.DataBind()
            sqlDS_Stocks.SelectCommand = qStocks
            grdStocks.DataSourceID = "sqlDS_Stocks"
            grdStocks.DataBind()

            grdInventory.DataSourceID = ""
            grdInventory.DataBind()
            sqlDS_Inventory.SelectCommand = qInventory
            grdInventory.DataSourceID = "sqlDS_Inventory"
			grdInventory.DataBind()

			grdTM.DataSourceID = ""
			grdTM.DataBind()
			sqlDS_TMSales.SelectCommand = qTM
			grdTM.DataSourceID = "sqlDS_TMSales"
			grdTM.DataBind()
        End With
    End Sub

    Protected Sub ddlFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlFilter.SelectedIndexChanged
        If ddlFilter.SelectedValue.Trim = "" Then
			lblDate.Visible = False
            ddlDate.Visible = False

            qry = "SELECT * FROM vw_SalesReport ORDER BY subID DESC"

            If ddlEmp.SelectedValue.Trim <> "" Then
                where = "userID = " & ddlEmp.SelectedValue.Trim
                qry = "SELECT * FROM vw_SalesReport WHERE " & where _
                    & " ORDER BY subID DESC"
			End If

			If ddlFC.SelectedValue.Trim <> "" Then
				where = "userID = " & ddlFC.SelectedValue.Trim
				qry = "SELECT * FROM vw_SalesReport WHERE " & where _
					& " ORDER BY subID DESC"
			End If

			grdSales.DataSourceID = ""
            grdSales.DataBind()
            sqlDS_Sales.SelectCommand = qry
            grdSales.DataSourceID = "sqlDS_Sales"
            grdSales.DataBind()

        Else
            lblDate.Visible = True
            ddlDate.Visible = True

            With conn
                Select Case ddlFilter.SelectedValue.Trim
                    'Case 1      'Daily

                    Case 2      'Weekly
						ddlDate.Items.Clear()
						Dim l_select As String = "*"
                        Dim l_flow As String = "DESC"
                        .loadToDropDownList("tbl_Week", ddlDate, False, l_select, "", "weekID", "weekCoverage", "weekID", l_flow)

                    Case 3      'Monthly
                        ddlDate.Items.Clear()
                        ddlDate.Items.Add("")
                        ddlDate.Items.Add("January")
                        ddlDate.Items.Add("February")
                        ddlDate.Items.Add("March")
                        ddlDate.Items.Add("April")
                        ddlDate.Items.Add("May")
                        ddlDate.Items.Add("June")
                        ddlDate.Items.Add("July")
                        ddlDate.Items.Add("August")
                        ddlDate.Items.Add("September")
                        ddlDate.Items.Add("October")
                        ddlDate.Items.Add("November")
                        ddlDate.Items.Add("December")

                    Case 4      'Yearly
                        ddlDate.Items.Clear()
                        .loadToDropDownList("tbl_Week", ddlDate, True, "", "wYear IS NOT NULL", "wYear", "wYear", "wYear", "DESC")
                End Select
            End With
        End If
    End Sub

	Protected Sub ddlTFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlTFilter.SelectedIndexChanged
		If ddlTFilter.SelectedValue.Trim = "" Then
			lblTDate.Visible = False
			ddlTDate.Visible = False

			qry = "SELECT * FROM vw_SalesReport ORDER BY subID DESC"

			If ddlTEmp.SelectedValue.Trim <> "" Then
				where = "userID = " & ddlTEmp.SelectedValue.Trim
				qry = "SELECT * FROM vw_SalesReport WHERE " & where _
					& " ORDER BY subID DESC"
			End If

			If ddlTFC.SelectedValue.Trim <> "" Then
				where = "userID = " & ddlTFC.SelectedValue.Trim
				qry = "SELECT * FROM vw_SalesReport WHERE " & where _
					& " ORDER BY subID DESC"
			End If

			grdTM.DataSourceID = ""
			grdTM.DataBind()
			sqlDS_TMSales.SelectCommand = qry
			grdTM.DataSourceID = "sqlDS_TMSales"
			grdTM.DataBind()

		Else
			lblTDate.Visible = True
			ddlTDate.Visible = True

			With conn
				Select Case ddlTFilter.SelectedValue.Trim
					'Case 1      'Daily

					Case 2		'Weekly
						ddlTDate.Items.Clear()
						Dim l_select As String = "*"
                        Dim l_flow As String = "DESC"
                        .loadToDropDownList("tbl_Week", ddlTDate, False, l_select, "", "weekID", "weekCoverage", "weekID", l_flow)

					Case 3		'Monthly
						ddlTDate.Items.Clear()
						ddlTDate.Items.Add("")
						ddlTDate.Items.Add("January")
						ddlTDate.Items.Add("February")
						ddlTDate.Items.Add("March")
						ddlTDate.Items.Add("April")
						ddlTDate.Items.Add("May")
						ddlTDate.Items.Add("June")
						ddlTDate.Items.Add("July")
						ddlTDate.Items.Add("August")
						ddlTDate.Items.Add("September")
						ddlTDate.Items.Add("October")
						ddlTDate.Items.Add("November")
						ddlTDate.Items.Add("December")

					Case 4		'Yearly
						ddlTDate.Items.Clear()
						.loadToDropDownList("tbl_Week", ddlTDate, True, "", "wYear IS NOT NULL", "wYear", "wYear", "wYear", "DESC")
				End Select
			End With
		End If
	End Sub

    Protected Sub ddlDate_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlDate.SelectedIndexChanged
        searchSales()
    End Sub

    Public Sub searchSales()
        Select Case ddlFilter.SelectedValue.Trim
            Case 2      'weekly
                If ddlDate.SelectedValue.Trim = "" Then
					If ddlEmp.SelectedValue.Trim = "" And ddlFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_SalesReport ORDER BY subID DESC"
					ElseIf ddlEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlEmp.SelectedValue.Trim _
								 & " ORDER BY subID DESC"
					Else
						qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlFC.SelectedValue.Trim _
								 & " ORDER BY subID DESC"
					End If
				Else
					If ddlEmp.SelectedValue.Trim = "" And ddlFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE weekID = " & ddlDate.SelectedValue.Trim _
								& " ORDER BY subID DESC"
					ElseIf ddlEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE weekID = " & ddlDate.SelectedValue.Trim _
								& " AND userID = " & ddlEmp.SelectedValue.Trim _
								& " ORDER BY subID DESC"
					Else
						qry = "SELECT * FROM vw_SalesReport WHERE weekID = " & ddlDate.SelectedValue.Trim _
								& " AND userID = " & ddlFC.SelectedValue.Trim _
								& " ORDER BY subID DESC"
					End If
				End If

            Case 3
                If ddlDate.SelectedValue.Trim = "" Then
					If ddlEmp.SelectedValue.Trim = "" And ddlFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_SalesReport ORDER BY subID DESC"

					ElseIf ddlEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlEmp.SelectedValue.Trim _
								 & " ORDER BY subID DESC"
					Else
						qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlFC.SelectedValue.Trim _
								 & " ORDER BY subID DESC"
					End If

                Else
                    Dim mNo As Integer
                    If ddlDate.SelectedValue.Trim = "January" Then mNo = 1
                    If ddlDate.SelectedValue.Trim = "February" Then mNo = 2
                    If ddlDate.SelectedValue.Trim = "March" Then mNo = 3
                    If ddlDate.SelectedValue.Trim = "April" Then mNo = 4
                    If ddlDate.SelectedValue.Trim = "May" Then mNo = 5
                    If ddlDate.SelectedValue.Trim = "June" Then mNo = 6
                    If ddlDate.SelectedValue.Trim = "July" Then mNo = 7
                    If ddlDate.SelectedValue.Trim = "August" Then mNo = 8
                    If ddlDate.SelectedValue.Trim = "September" Then mNo = 9
                    If ddlDate.SelectedValue.Trim = "October" Then mNo = 10
                    If ddlDate.SelectedValue.Trim = "November" Then mNo = 11
                    If ddlDate.SelectedValue.Trim = "December" Then mNo = 12

					If ddlEmp.SelectedValue.Trim = "" And ddlFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE wMonthID = " & mNo _
								& " ORDER BY subID DESC"

					ElseIf ddlEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE wMonthID = " & mNo _
								& " AND userID = " & ddlEmp.SelectedValue.Trim _
								& " ORDER BY subID DESC"
					Else
						qry = "SELECT * FROM vw_SalesReport WHERE wMonthID = " & mNo _
								& " AND userID = " & ddlFC.SelectedValue.Trim _
								& " ORDER BY subID DESC"
					End If
                End If

            Case 4
                If ddlDate.SelectedValue.Trim = "" Then
					If ddlEmp.SelectedValue.Trim = "" And ddlFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_SalesReport ORDER BY subID DESC"

					ElseIf ddlEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlEmp.SelectedValue.Trim _
								 & " ORDER BY subID DESC"
					Else
						qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlFC.SelectedValue.Trim _
								 & " ORDER BY subID DESC"
					End If
				Else
					If ddlEmp.SelectedValue.Trim = "" And ddlFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE wYear = '" & ddlDate.SelectedValue.Trim _
								& "' ORDER BY subID DESC"

					ElseIf ddlEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE wYear = '" & ddlDate.SelectedValue.Trim _
								& "' AND userID = " & ddlEmp.SelectedValue.Trim _
								& " ORDER BY subID DESC"
					Else
						qry = "SELECT * FROM vw_SalesReport WHERE wYear = '" & ddlDate.SelectedValue.Trim _
								& "' AND userID = " & ddlFC.SelectedValue.Trim _
								& " ORDER BY subID DESC"
					End If
                End If
        End Select

        grdSales.DataSourceID = ""
        grdSales.DataBind()
        sqlDS_Sales.SelectCommand = qry
        grdSales.DataSourceID = "sqlDS_Sales"
        grdSales.DataBind()
    End Sub

    Public Sub searchCompete()
        Select Case ddlCFilter.SelectedValue.Trim
            Case 2      'weekly
                If ddlCDate.SelectedValue.Trim = "" Then
                    If ddlBrand.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_CompeteReport ORDER BY cSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_CompeteReport WHERE userID = " & ddlBrand.SelectedValue.Trim _
                                 & " ORDER BY cSubID DESC"
                    End If

                Else
                    If ddlBrand.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_CompeteReport WHERE weekID = " & ddlCDate.SelectedValue.Trim _
                                & " ORDER BY cSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_CompeteReport WHERE weekID = " & ddlCDate.SelectedValue.Trim _
                                & " AND cBrandID = " & ddlBrand.SelectedValue.Trim _
                                & " ORDER BY cSubID DESC"
                    End If
                End If

            Case 3
                If ddlCDate.SelectedValue.Trim = "" Then
                    If ddlBrand.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_CompeteReport ORDER BY cSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_CompeteReport WHERE cBrandID = " & ddlBrand.SelectedValue.Trim _
                                 & " ORDER BY cSubID DESC"
                    End If

                Else
                    Dim mNo As Integer
                    If ddlCDate.SelectedValue.Trim = "January" Then mNo = 1
                    If ddlCDate.SelectedValue.Trim = "February" Then mNo = 2
                    If ddlCDate.SelectedValue.Trim = "March" Then mNo = 3
                    If ddlCDate.SelectedValue.Trim = "April" Then mNo = 4
                    If ddlCDate.SelectedValue.Trim = "May" Then mNo = 5
                    If ddlCDate.SelectedValue.Trim = "June" Then mNo = 6
                    If ddlCDate.SelectedValue.Trim = "July" Then mNo = 7
                    If ddlCDate.SelectedValue.Trim = "August" Then mNo = 8
                    If ddlCDate.SelectedValue.Trim = "September" Then mNo = 9
                    If ddlCDate.SelectedValue.Trim = "October" Then mNo = 10
                    If ddlCDate.SelectedValue.Trim = "November" Then mNo = 11
                    If ddlCDate.SelectedValue.Trim = "December" Then mNo = 12

                    If ddlBrand.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_CompeteReport WHERE wMonthID = " & mNo _
                                & " ORDER BY cSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_CompeteReport WHERE wMonthID = " & mNo _
                                & " AND cBrandID = " & ddlBrand.SelectedValue.Trim _
                                & " ORDER BY cSubID DESC"
                    End If
                End If

            Case 4
                If ddlCDate.SelectedValue.Trim = "" Then
                    If ddlBrand.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_CompeteReport ORDER BY cSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_CompeteReport WHERE cBrandID = " & ddlBrand.SelectedValue.Trim _
                                 & " ORDER BY cSubID DESC"
                    End If

                Else
                    If ddlBrand.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_CompeteReport WHERE wYear= '" & ddlCDate.SelectedValue.Trim _
                                & "' ORDER BY cSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_CompeteReport WHERE wYear = '" & ddlCDate.SelectedValue.Trim _
                                & "' AND cBrandID = " & ddlBrand.SelectedValue.Trim _
                                & " ORDER BY cSubID DESC"
                    End If
                End If
        End Select

        grdCompete.DataSourceID = ""
        grdCompete.DataBind()
        sqlDS_Compete.SelectCommand = qry
        grdCompete.DataSourceID = "sqlDS_Compete"
        grdCompete.DataBind()
    End Sub

    Public Sub searchStocks()
        Select Case ddlSFilter.SelectedValue.Trim
            Case 2      'weekly
                If ddlSDate.SelectedValue.Trim = "" Then
					If ddlSEmp.SelectedValue.Trim = "" And ddlSFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_StocksReport ORDER BY sSubID DESC"

					ElseIf ddlSEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_StocksReport WHERE userID = " & ddlSEmp.SelectedValue.Trim _
								 & " ORDER BY sSubID DESC"
					Else
						qry = "SELECT * FROM vw_StocksReport WHERE userID = " & ddlSFC.SelectedValue.Trim _
								 & " ORDER BY sSubID DESC"
					End If

                Else
					If ddlSEmp.SelectedValue.Trim = "" And ddlSFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_StocksReport WHERE weekID = " & ddlSDate.SelectedValue.Trim _
								& " ORDER BY sSubID DESC"

					ElseIf ddlSEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_StocksReport WHERE weekID = " & ddlSDate.SelectedValue.Trim _
								& " AND userID = " & ddlSEmp.SelectedValue.Trim _
								& " ORDER BY sSubID DESC"
					Else
						qry = "SELECT * FROM vw_StocksReport WHERE weekID = " & ddlSDate.SelectedValue.Trim _
								& " AND userID = " & ddlSFC.SelectedValue.Trim _
								& " ORDER BY sSubID DESC"
					End If
                End If

            Case 3
                If ddlSDate.SelectedValue.Trim = "" Then
					If ddlSEmp.SelectedValue.Trim = "" And ddlSFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_StocksReport ORDER BY sSubID DESC"

					ElseIf ddlSEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_StocksReport WHERE userID = " & ddlSEmp.SelectedValue.Trim _
								 & " ORDER BY sSubID DESC"
					Else
						qry = "SELECT * FROM vw_StocksReport WHERE userID = " & ddlSFC.SelectedValue.Trim _
								 & " ORDER BY sSubID DESC"
					End If

                Else
                    Dim mNo As Integer
                    If ddlSDate.SelectedValue.Trim = "January" Then mNo = 1
                    If ddlSDate.SelectedValue.Trim = "February" Then mNo = 2
                    If ddlSDate.SelectedValue.Trim = "March" Then mNo = 3
                    If ddlSDate.SelectedValue.Trim = "April" Then mNo = 4
                    If ddlSDate.SelectedValue.Trim = "May" Then mNo = 5
                    If ddlSDate.SelectedValue.Trim = "June" Then mNo = 6
                    If ddlSDate.SelectedValue.Trim = "July" Then mNo = 7
                    If ddlSDate.SelectedValue.Trim = "August" Then mNo = 8
                    If ddlSDate.SelectedValue.Trim = "September" Then mNo = 9
                    If ddlSDate.SelectedValue.Trim = "October" Then mNo = 10
                    If ddlSDate.SelectedValue.Trim = "November" Then mNo = 11
                    If ddlSDate.SelectedValue.Trim = "December" Then mNo = 12

					If ddlSEmp.SelectedValue.Trim = "" And ddlSFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_StocksReport WHERE wMonthID = " & mNo _
								& " ORDER BY sSubID DESC"

					ElseIf ddlSEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_StocksReport WHERE wMonthID = " & mNo _
								& " AND userID = " & ddlSEmp.SelectedValue.Trim _
								& " ORDER BY sSubID DESC"
					Else
						qry = "SELECT * FROM vw_StocksReport WHERE wMonthID = " & mNo _
								& " AND userID = " & ddlSFC.SelectedValue.Trim _
								& " ORDER BY sSubID DESC"
					End If
                End If

            Case 4
                If ddlSDate.SelectedValue.Trim = "" Then
					If ddlSEmp.SelectedValue.Trim = "" And ddlSFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_StocksReport ORDER BY sSubID DESC"

					ElseIf ddlSEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_StocksReport WHERE userID = " & ddlSEmp.SelectedValue.Trim _
								 & " ORDER BY sSubID DESC"
					Else
						qry = "SELECT * FROM vw_StocksReport WHERE userID = " & ddlSFC.SelectedValue.Trim _
								 & " ORDER BY sSubID DESC"
					End If

                Else
					If ddlSEmp.SelectedValue.Trim = "" And ddlSFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_StocksReport WHERE wYear = '" & ddlSDate.SelectedValue.Trim _
								& "' ORDER BY sSubID DESC"

					ElseIf ddlSEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_StocksReport WHERE wYear = '" & ddlSDate.SelectedValue.Trim _
								& "' AND userID = " & ddlSEmp.SelectedValue.Trim _
								& " ORDER BY sSubID DESC"
					Else
						qry = "SELECT * FROM vw_StocksReport WHERE wYear = '" & ddlSDate.SelectedValue.Trim _
								& "' AND userID = " & ddlSFC.SelectedValue.Trim _
								& " ORDER BY sSubID DESC"
					End If
                End If
        End Select

        grdStocks.DataSourceID = ""
        grdStocks.DataBind()
        sqlDS_Stocks.SelectCommand = qry
        grdStocks.DataSourceID = "sqlDS_Stocks"
        grdStocks.DataBind()
    End Sub

    Public Sub searchInventory()
        Select Case ddlIFilter.SelectedValue.Trim
            Case 2      'weekly
                If ddlIDate.SelectedValue.Trim = "" Then
					If ddlIEmp.SelectedValue.Trim = "" And ddlIFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_InventoryReport ORDER BY iSubID DESC"

					ElseIf ddlIEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_InventoryReport WHERE userID = " & ddlIEmp.SelectedValue.Trim _
								 & " ORDER BY iSubID DESC"
					Else
						qry = "SELECT * FROM vw_InventoryReport WHERE userID = " & ddlIFC.SelectedValue.Trim _
								 & " ORDER BY iSubID DESC"
					End If

                Else
					If ddlIEmp.SelectedValue.Trim = "" And ddlIFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_InventoryReport WHERE weekID = " & ddlIDate.SelectedValue.Trim _
								& " ORDER BY iSubID DESC"

					ElseIf ddlIEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_InventoryReport WHERE weekID = " & ddlIDate.SelectedValue.Trim _
								& " AND userID = " & ddlIEmp.SelectedValue.Trim _
								& " ORDER BY iSubID DESC"
					Else
						qry = "SELECT * FROM vw_InventoryReport WHERE weekID = " & ddlIDate.SelectedValue.Trim _
								& " AND userID = " & ddlIFC.SelectedValue.Trim _
								& " ORDER BY iSubID DESC"
					End If
                End If

            Case 3
                If ddlIDate.SelectedValue.Trim = "" Then
					If ddlIEmp.SelectedValue.Trim = "" And ddlIFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_InventoryReport ORDER BY iSubID DESC"

					ElseIf ddlIEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_InventoryReport WHERE userID = " & ddlIEmp.SelectedValue.Trim _
								 & " ORDER BY iSubID DESC"
					Else
						qry = "SELECT * FROM vw_InventoryReport WHERE userID = " & ddlIFC.SelectedValue.Trim _
								 & " ORDER BY iSubID DESC"
					End If

                Else
                    Dim mNo As Integer
                    If ddlIDate.SelectedValue.Trim = "January" Then mNo = 1
                    If ddlIDate.SelectedValue.Trim = "February" Then mNo = 2
                    If ddlIDate.SelectedValue.Trim = "March" Then mNo = 3
                    If ddlIDate.SelectedValue.Trim = "April" Then mNo = 4
                    If ddlIDate.SelectedValue.Trim = "May" Then mNo = 5
                    If ddlIDate.SelectedValue.Trim = "June" Then mNo = 6
                    If ddlIDate.SelectedValue.Trim = "July" Then mNo = 7
                    If ddlIDate.SelectedValue.Trim = "August" Then mNo = 8
                    If ddlIDate.SelectedValue.Trim = "September" Then mNo = 9
                    If ddlIDate.SelectedValue.Trim = "October" Then mNo = 10
                    If ddlIDate.SelectedValue.Trim = "November" Then mNo = 11
                    If ddlIDate.SelectedValue.Trim = "December" Then mNo = 12

					If ddlIEmp.SelectedValue.Trim = "" And ddlIFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_InventoryReport WHERE wMonthID = " & mNo _
								& " ORDER BY iSubID DESC"

					ElseIf ddlIEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_InventoryReport WHERE wMonthID = " & mNo _
								& " AND userID = " & ddlIEmp.SelectedValue.Trim _
								& " ORDER BY iSubID DESC"
					Else
						qry = "SELECT * FROM vw_InventoryReport WHERE wMonthID = " & mNo _
								& " AND userID = " & ddlIFC.SelectedValue.Trim _
								& " ORDER BY iSubID DESC"
					End If
                End If

            Case 4
                If ddlIDate.SelectedValue.Trim = "" Then
					If ddlIEmp.SelectedValue.Trim = "" And ddlIFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_InventoryReport ORDER BY iSubID DESC"

					ElseIf ddlIEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_InventoryReport WHERE userID = " & ddlIEmp.SelectedValue.Trim _
								 & " ORDER BY iSubID DESC"
					Else
						qry = "SELECT * FROM vw_InventoryReport WHERE userID = " & ddlIFC.SelectedValue.Trim _
								 & " ORDER BY iSubID DESC"
					End If

                Else
					If ddlIEmp.SelectedValue.Trim = "" And ddlIFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_InventoryReport WHERE wYear = '" & ddlIDate.SelectedValue.Trim _
								& "' ORDER BY iSubID DESC"

					ElseIf ddlIEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_InventoryReport WHERE wYear = '" & ddlIDate.SelectedValue.Trim _
								& "' AND userID = " & ddlIEmp.SelectedValue.Trim _
								& " ORDER BY iSubID DESC"
					Else
						qry = "SELECT * FROM vw_InventoryReport WHERE wYear = '" & ddlIDate.SelectedValue.Trim _
								& "' AND userID = " & ddlIFC.SelectedValue.Trim _
								& " ORDER BY iSubID DESC"
					End If
                End If
        End Select

        grdInventory.DataSourceID = ""
        grdInventory.DataBind()
        sqlDS_Inventory.SelectCommand = qry
        grdInventory.DataSourceID = "sqlDS_Inventory"
        grdInventory.DataBind()
    End Sub

	Public Sub searchTM()
		Select Case ddlTFilter.SelectedValue.Trim
			Case 2		'weekly
				If ddlTDate.SelectedValue.Trim = "" Then
					If ddlTEmp.SelectedValue.Trim = "" And ddlTFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_SalesReport ORDER BY subID DESC"

					ElseIf ddlTEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlTEmp.SelectedValue.Trim _
								 & " ORDER BY subID DESC"
					Else
						qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlTFC.SelectedValue.Trim _
								 & " ORDER BY subID DESC"
					End If

				Else
					If ddlTEmp.SelectedValue.Trim = "" And ddlTFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE weekID = " & ddlTDate.SelectedValue.Trim _
								& " ORDER BY subID DESC"

					ElseIf ddlTEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE weekID = " & ddlTDate.SelectedValue.Trim _
								& " AND userID = " & ddlTEmp.SelectedValue.Trim _
								& " ORDER BY subID DESC"
					Else
						qry = "SELECT * FROM vw_SalesReport WHERE weekID = " & ddlTDate.SelectedValue.Trim _
								& " AND userID = " & ddlTFC.SelectedValue.Trim _
								& " ORDER BY subID DESC"
					End If
				End If

			Case 3
				If ddlTDate.SelectedValue.Trim = "" Then
					If ddlTEmp.SelectedValue.Trim = "" And ddlTFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_SalesReport ORDER BY subID DESC"

					ElseIf ddlTEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlTEmp.SelectedValue.Trim _
								 & " ORDER BY subID DESC"
					Else
						qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlTFC.SelectedValue.Trim _
								 & " ORDER BY subID DESC"
					End If

				Else
					Dim mNo As Integer
					If ddlTDate.SelectedValue.Trim = "January" Then mNo = 1
					If ddlTDate.SelectedValue.Trim = "February" Then mNo = 2
					If ddlTDate.SelectedValue.Trim = "March" Then mNo = 3
					If ddlTDate.SelectedValue.Trim = "April" Then mNo = 4
					If ddlTDate.SelectedValue.Trim = "May" Then mNo = 5
					If ddlTDate.SelectedValue.Trim = "June" Then mNo = 6
					If ddlTDate.SelectedValue.Trim = "July" Then mNo = 7
					If ddlTDate.SelectedValue.Trim = "August" Then mNo = 8
					If ddlTDate.SelectedValue.Trim = "September" Then mNo = 9
					If ddlTDate.SelectedValue.Trim = "October" Then mNo = 10
					If ddlTDate.SelectedValue.Trim = "November" Then mNo = 11
					If ddlTDate.SelectedValue.Trim = "December" Then mNo = 12

					If ddlTEmp.SelectedValue.Trim = "" And ddlTFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE wMonthID = " & mNo _
								& " ORDER BY subID DESC"

					ElseIf ddlTEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE wMonthID = " & mNo _
								& " AND userID = " & ddlTEmp.SelectedValue.Trim _
								& " ORDER BY subID DESC"
					Else
						qry = "SELECT * FROM vw_SalesReport WHERE wMonthID = " & mNo _
								& " AND userID = " & ddlTFC.SelectedValue.Trim _
								& " ORDER BY subID DESC"
					End If
				End If

			Case 4
				If ddlTDate.SelectedValue.Trim = "" Then
					If ddlTEmp.SelectedValue.Trim = "" And ddlTFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_SalesReport ORDER BY subID DESC"

					ElseIf ddlTEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlTEmp.SelectedValue.Trim _
								 & " ORDER BY subID DESC"
					Else
						qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlTFC.SelectedValue.Trim _
								 & " ORDER BY subID DESC"
					End If

				Else
					If ddlTEmp.SelectedValue.Trim = "" And ddlTFC.SelectedValue.Trim = "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE wYear = '" & ddlTDate.SelectedValue.Trim _
								& "' ORDER BY subID DESC"

					ElseIf ddlTEmp.SelectedValue.Trim <> "" Then
						qry = "SELECT * FROM vw_SalesReport WHERE wYear = '" & ddlTDate.SelectedValue.Trim _
								& "' AND userID = " & ddlTEmp.SelectedValue.Trim _
								& " ORDER BY subID DESC"
					Else
						qry = "SELECT * FROM vw_SalesReport WHERE wYear = '" & ddlTDate.SelectedValue.Trim _
								& "' AND userID = " & ddlTFC.SelectedValue.Trim _
								& " ORDER BY subID DESC"
					End If
				End If
		End Select

		grdTM.DataSourceID = ""
		grdTM.DataBind()
		sqlDS_TMSales.SelectCommand = qry
		grdTM.DataSourceID = "sqlDS_TMSales"
		grdTM.DataBind()
	End Sub

    Protected Sub ddlEmp_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlEmp.SelectedIndexChanged
        If ddlFilter.SelectedValue.Trim = "" Then
            qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlEmp.SelectedValue.Trim _
                                 & " ORDER BY subID DESC"
        Else
            searchSales()
            Exit Sub
        End If

        grdSales.DataSourceID = ""
        grdSales.DataBind()
        sqlDS_Sales.SelectCommand = qry
        grdSales.DataSourceID = "sqlDS_Sales"
        grdSales.DataBind()
	End Sub

	Protected Sub ddlFC_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlFC.SelectedIndexChanged
		If ddlFilter.SelectedValue.Trim = "" Then
			qry = "SELECT * FROM tbl_User u, vw_SalesReport s WHERE u.empID=s.userID AND u.fcID=" & ddlFC.SelectedValue.Trim _
								 & " ORDER BY subID DESC"
		Else
			searchSales()
			Exit Sub
		End If

		grdSales.DataSourceID = ""
		grdSales.DataBind()
		sqlDS_Sales.SelectCommand = qry
		grdSales.DataSourceID = "sqlDS_Sales"
		grdSales.DataBind()
	End Sub

    Protected Sub lnkCompete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkCompete.Click
        checkSession()
        lbleMsg.Text = ""

        panSales.Visible = False
        panCompete.Visible = True
        panStocks.Visible = False
		panInventory.Visible = False
		panTMSales.Visible = False

        lnkProd.CssClass = "tabprop"
        lnkCompete.CssClass = "tabprop-Selected"
        lnkStocks.CssClass = "tabprop"
		lnkInventory.CssClass = "tabprop"
		lnkTMSales.CssClass = "tabprop"

        Session("rType") = "Compete"
        conn.loadToDropDownList("tbl_CBrand", ddlBrand, False, "*", "", "cBrandID", "cBrand", "cBrand", "")
        conn.loadToDropDownList("tbl_CBrand", ddlCDBrand, False, "*", "", "cBrandID", "cBrand", "cBrand", "")
        conn.loadToDropDownList("vw_Week", ddlCWeek, False, "*", "", "weekID", "weekCoverage", "weekCoverage", "")
        conn.loadToDropDownList("tbl_CCapacity", ddlCCap, False, "*", "", "cCapacityID", "cCapacity", "cCapacity", "")
    End Sub

    Protected Sub lnkProd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkProd.Click
        checkSession()
        lbleMsg.Text = ""

        panSales.Visible = True
        panCompete.Visible = False
        panStocks.Visible = False
		panInventory.Visible = False
		panTMSales.Visible = False

        lnkProd.CssClass = "tabprop-Selected"
        lnkCompete.CssClass = "tabprop"
        lnkStocks.CssClass = "tabprop"
		lnkInventory.CssClass = "tabprop"
		lnkTMSales.CssClass = "tabprop"

        Session("rType") = "Sales"
        conn.loadToDropDownList("tbl_Product", ddlProd, False, "*", "", "productID", "product", "product", "")
		conn.loadToDropDownList("tbl_City", ddlCity, False, "*", "", "cityID", "city", "city", "")
		conn.loadToDropDownList("vw_Week", ddlWeek, False, "*", "", "weekID", "weekCoverage", "weekCoverage", "")
	End Sub

	Protected Sub lnkTMSales_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkTMSales.Click
		checkSession()
		lbleMsg.Text = ""

		panSales.Visible = False
		panCompete.Visible = False
		panStocks.Visible = False
		panInventory.Visible = False
		panTMSales.Visible = True

		lnkProd.CssClass = "tabprop"
		lnkCompete.CssClass = "tabprop"
		lnkStocks.CssClass = "tabprop"
		lnkInventory.CssClass = "tabprop"
		lnkTMSales.CssClass = "tabprop-Selected"

		Session("rType") = "TMSales"
		conn.loadToDropDownList("tbl_Product", ddlTProd, False, "*", "", "productID", "product", "product", "")
		conn.loadToDropDownList("tbl_City", ddlTCity, False, "*", "", "cityID", "city", "city", "")
		conn.loadToDropDownList("vw_Week", ddlTWeek, False, "*", "", "weekID", "weekCoverage", "weekCoverage", "")
		conn.loadToDropDownList("tbl_WDay", ddlTDP, False, "*", where, "wDay", "wDay", "wDay", "")
	End Sub

    Public Sub checkSession()
        mstr = Page.Master
        Dim lblUserID As Label = mstr.FindControl("lblUserID")

        If Session("userID") Is Nothing Then
            Session.Clear()
            Response.Redirect("~/Default.aspx")
        End If
    End Sub

    Protected Sub lnkStocks_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkStocks.Click
        checkSession()
        lbleMsg.Text = ""

        panSales.Visible = False
        panCompete.Visible = False
        panStocks.Visible = True
		panInventory.Visible = False
		panTMSales.Visible = False

        lnkProd.CssClass = "tabprop"
        lnkCompete.CssClass = "tabprop"
        lnkStocks.CssClass = "tabprop-Selected"
		lnkInventory.CssClass = "tabprop"
		lnkTMSales.CssClass = "tabprop"

        Session("rType") = "Stocks"
        conn.loadToDropDownList("tbl_Product", ddlSProd, False, "*", "", "productID", "product", "product", "")
        conn.loadToDropDownList("tbl_Action", ddlAction, False, "*", "", "actionID", "actionTaken", "actionTaken", "")
        conn.loadToDropDownList("vw_Week", ddlSWeek, False, "*", "", "weekID", "weekCoverage", "weekCoverage", "")
    End Sub

    Protected Sub lnkInventory_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkInventory.Click
        checkSession()
        lbleMsg.Text = ""

        panSales.Visible = False
        panCompete.Visible = False
        panStocks.Visible = False
		panInventory.Visible = True
		panTMSales.Visible = False

        lnkProd.CssClass = "tabprop"
        lnkCompete.CssClass = "tabprop"
        lnkStocks.CssClass = "tabprop"
		lnkInventory.CssClass = "tabprop-Selected"
		lnkTMSales.CssClass = "tabprop"

        Session("rType") = "Inventory"
        conn.loadToDropDownList("tbl_Product", ddlIProd, False, "*", "", "productID", "product", "product", "")
    End Sub

    Protected Sub ddlCFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCFilter.SelectedIndexChanged
        If ddlCFilter.SelectedValue.Trim = "" Then
            lblCDate.Visible = False
            ddlCDate.Visible = False

            qry = "SELECT * FROM vw_CompeteReport ORDER BY cSubID DESC"

            If ddlBrand.SelectedValue.Trim <> "" Then
                where = "cBrandID = " & ddlBrand.SelectedValue.Trim
                qry = "SELECT * FROM vw_CompeteReport WHERE " & where _
                    & " ORDER BY cSubID DESC"
            End If

            grdCompete.DataSourceID = ""
            grdCompete.DataBind()
            sqlDS_Compete.SelectCommand = qry
            grdCompete.DataSourceID = "sqlDS_Compete"
            grdCompete.DataBind()

        Else
            lblCDate.Visible = True
            ddlCDate.Visible = True

            With conn
                Select Case ddlCFilter.SelectedValue.Trim
                    'Case 1      'Daily

                    Case 2      'Weekly
						ddlCDate.Items.Clear()
						Dim l_select As String = "*"
                        Dim l_flow As String = "DESC"
                        .loadToDropDownList("tbl_Week", ddlCDate, False, l_select, "", "weekID", "weekCoverage", "weekID", l_flow)

                    Case 3      'Monthly
                        ddlCDate.Items.Clear()
                        ddlCDate.Items.Add("")
                        ddlCDate.Items.Add("January")
                        ddlCDate.Items.Add("February")
                        ddlCDate.Items.Add("March")
                        ddlCDate.Items.Add("April")
                        ddlCDate.Items.Add("May")
                        ddlCDate.Items.Add("June")
                        ddlCDate.Items.Add("July")
                        ddlCDate.Items.Add("August")
                        ddlCDate.Items.Add("September")
                        ddlCDate.Items.Add("October")
                        ddlCDate.Items.Add("November")
                        ddlCDate.Items.Add("December")

                    Case 4      'Yearly
                        ddlCDate.Items.Clear()
                        .loadToDropDownList("tbl_Week", ddlCDate, True, "", "wYear IS NOT NULL", "wYear", "wYear", "wYear", "DESC")
                End Select
            End With
        End If
    End Sub

    Protected Sub ddlSFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSFilter.SelectedIndexChanged
        If ddlSFilter.SelectedValue.Trim = "" Then
            lblSDate.Visible = False
            ddlSDate.Visible = False

            qry = "SELECT * FROM vw_StocksReport ORDER BY subID DESC"

            If ddlSEmp.SelectedValue.Trim <> "" Then
                where = "userID = " & ddlSEmp.SelectedValue.Trim
                qry = "SELECT * FROM vw_StocksReport WHERE " & where _
                    & " ORDER BY sSubID DESC"
			End If

			If ddlSFC.SelectedValue.Trim <> "" Then
				where = "userID = " & ddlSFC.SelectedValue.Trim
				qry = "SELECT * FROM vw_StocksReport WHERE " & where _
					& " ORDER BY sSubID DESC"
			End If

            grdStocks.DataSourceID = ""
            grdStocks.DataBind()
            sqlDS_Stocks.SelectCommand = qry
            grdStocks.DataSourceID = "sqlDS_Stocks"
            grdStocks.DataBind()

        Else
            lblSDate.Visible = True
            ddlSDate.Visible = True

            With conn
                Select Case ddlSFilter.SelectedValue.Trim
                    'Case 1      'Daily

                    Case 2      'Weekly
						ddlSDate.Items.Clear()
						Dim l_select As String = "*"
                        Dim l_flow As String = "DESC"
                        .loadToDropDownList("tbl_Week", ddlSDate, False, l_select, "", "weekID", "weekCoverage", "weekID", l_flow)

                    Case 3      'Monthly
                        ddlSDate.Items.Clear()
                        ddlSDate.Items.Add("")
                        ddlSDate.Items.Add("January")
                        ddlSDate.Items.Add("February")
                        ddlSDate.Items.Add("March")
                        ddlSDate.Items.Add("April")
                        ddlSDate.Items.Add("May")
                        ddlSDate.Items.Add("June")
                        ddlSDate.Items.Add("July")
                        ddlSDate.Items.Add("August")
                        ddlSDate.Items.Add("September")
                        ddlSDate.Items.Add("October")
                        ddlSDate.Items.Add("November")
                        ddlSDate.Items.Add("December")

                    Case 4      'Yearly
                        ddlSDate.Items.Clear()
                        .loadToDropDownList("tbl_Week", ddlSDate, True, "", "wYear IS NOT NULL", "wYear", "wYear", "wYear", "DESC")
                End Select
            End With
        End If
    End Sub

    Protected Sub ddlIFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlIFilter.SelectedIndexChanged
        If ddlIFilter.SelectedValue.Trim = "" Then
            lblIDate.Visible = False
            ddlIDate.Visible = False

            qry = "SELECT * FROM vw_InventoryReport ORDER BY iSubID DESC"

            If ddlIEmp.SelectedValue.Trim <> "" Then
                where = "userID = " & ddlIEmp.SelectedValue.Trim
                qry = "SELECT * FROM vw_InventoryReport WHERE " & where _
                    & " ORDER BY iSubID DESC"
			End If

			If ddlIFC.SelectedValue.Trim <> "" Then
				where = "userID = " & ddlIFC.SelectedValue.Trim
				qry = "SELECT * FROM vw_InventoryReport WHERE " & where _
					& " ORDER BY iSubID DESC"
			End If

            grdInventory.DataSourceID = ""
            grdInventory.DataBind()
            sqlDS_Inventory.SelectCommand = qry
            grdInventory.DataSourceID = "sqlDS_Inventory"
            grdInventory.DataBind()

        Else
            lblIDate.Visible = True
            ddlIDate.Visible = True

            With conn
                Select Case ddlIFilter.SelectedValue.Trim
                    'Case 1      'Daily

                    Case 2      'Weekly
						ddlIDate.Items.Clear()
						Dim l_select As String = "*"
                        Dim l_flow As String = "DESC"
                        .loadToDropDownList("tbl_Week", ddlIDate, False, l_select, "", "weekID", "weekCoverage", "weekID", l_flow)

                    Case 3      'Monthly
                        ddlIDate.Items.Clear()
                        ddlIDate.Items.Add("")
                        ddlIDate.Items.Add("January")
                        ddlIDate.Items.Add("February")
                        ddlIDate.Items.Add("March")
                        ddlIDate.Items.Add("April")
                        ddlIDate.Items.Add("May")
                        ddlIDate.Items.Add("June")
                        ddlIDate.Items.Add("July")
                        ddlIDate.Items.Add("August")
                        ddlIDate.Items.Add("September")
                        ddlIDate.Items.Add("October")
                        ddlIDate.Items.Add("November")
                        ddlIDate.Items.Add("December")

                    Case 4      'Yearly
                        ddlIDate.Items.Clear()
                        .loadToDropDownList("tbl_Week", ddlIDate, True, "", "wYear IS NOT NULL", "wYear", "wYear", "wYear", "DESC")
                End Select
            End With
        End If
    End Sub

    Protected Sub ddlCDate_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlCDate.SelectedIndexChanged
        searchCompete()
    End Sub

    Protected Sub ddlSDate_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSDate.SelectedIndexChanged
        searchStocks()
    End Sub

    Protected Sub ddlIDate_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlIDate.SelectedIndexChanged
        searchInventory()
	End Sub

	Protected Sub ddlTDate_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlTDate.SelectedIndexChanged
		searchTM()
	End Sub

    Protected Sub ddlBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlBrand.SelectedIndexChanged
        If ddlCFilter.SelectedValue.Trim = "" Then
            qry = "SELECT * FROM vw_CompeteReport WHERE cBrandID = " & ddlBrand.SelectedValue.Trim _
                                 & " ORDER BY cBrand"
        Else
            searchCompete()
            Exit Sub
        End If

        grdCompete.DataSourceID = ""
        grdCompete.DataBind()
        sqlDS_Compete.SelectCommand = qry
        grdCompete.DataSourceID = "sqlDS_Compete"
        grdCompete.DataBind()
    End Sub

    Protected Sub ddlSEmp_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSEmp.SelectedIndexChanged
        If ddlSFilter.SelectedValue.Trim = "" Then
            qry = "SELECT * FROM vw_StocksReport WHERE userID = " & ddlSEmp.SelectedValue.Trim _
                                 & " ORDER BY sSubID DESC"
        Else
            searchStocks()
            Exit Sub
        End If

        grdStocks.DataSourceID = ""
        grdStocks.DataBind()
        sqlDS_Stocks.SelectCommand = qry
        grdStocks.DataSourceID = "sqlDS_Stocks"
        grdStocks.DataBind()
    End Sub

	Protected Sub ddlSFC_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSFC.SelectedIndexChanged
		If ddlSFilter.SelectedValue.Trim = "" Then
			qry = "SELECT * FROM tbl_User u, vw_StocksReport s WHERE u.empID=s.userID AND u.fcID=" & ddlSFC.SelectedValue.Trim _
								 & " ORDER BY sSubID DESC"
		Else
			searchStocks()
			Exit Sub
		End If

		grdStocks.DataSourceID = ""
		grdStocks.DataBind()
		sqlDS_Stocks.SelectCommand = qry
		grdStocks.DataSourceID = "sqlDS_Stocks"
		grdStocks.DataBind()
	End Sub

    Protected Sub ddlIEmp_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlIEmp.SelectedIndexChanged
        If ddlIFilter.SelectedValue.Trim = "" Then
            qry = "SELECT * FROM vw_InventoryReport WHERE userID = " & ddlIEmp.SelectedValue.Trim _
                                 & " ORDER BY iSubID DESC"
        Else
            searchInventory()
            Exit Sub
        End If

        grdInventory.DataSourceID = ""
        grdInventory.DataBind()
        sqlDS_Inventory.SelectCommand = qry
        grdInventory.DataSourceID = "sqlDS_Inventory"
        grdInventory.DataBind()
	End Sub

	Protected Sub ddlIFC_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlIFC.SelectedIndexChanged
		If ddlIFilter.SelectedValue.Trim = "" Then
			qry = "SELECT * FROM tbl_User u, vw_InventoryReport s WHERE u.empID=s.userID AND u.fcID=" & ddlIFC.SelectedValue.Trim _
								 & " ORDER BY iSubID DESC"
		Else
			searchInventory()
			Exit Sub
		End If

		grdInventory.DataSourceID = ""
		grdInventory.DataBind()
		sqlDS_Inventory.SelectCommand = qry
		grdInventory.DataSourceID = "sqlDS_Inventory"
		grdInventory.DataBind()
	End Sub

	Protected Sub ddlTEmp_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlTEmp.SelectedIndexChanged
		If ddlTFilter.SelectedValue.Trim = "" Then
			qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlTEmp.SelectedValue.Trim _
								 & " ORDER BY subID DESC"
		Else
			searchTM()
			Exit Sub
		End If

		grdTM.DataSourceID = ""
		grdTM.DataBind()
		sqlDS_TMSales.SelectCommand = qry
		grdTM.DataSourceID = "sqlDS_TMSales"
		grdTM.DataBind()
	End Sub

	Protected Sub ddlTFC_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlTFC.SelectedIndexChanged
		If ddlTFilter.SelectedValue.Trim = "" Then
            qry = "SELECT * FROM tbl_User u, vw_SalesReport s WHERE u.empID=s.userID AND s.fcID = " & ddlTFC.SelectedValue.Trim & " ORDER BY subID DESC"
        Else
            searchTM()
            Exit Sub
		End If

		grdTM.DataSourceID = ""
		grdTM.DataBind()
		sqlDS_TMSales.SelectCommand = qry
		grdTM.DataSourceID = "sqlDS_TMSales"
		grdTM.DataBind()
	End Sub

	Protected Sub ddlPageNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)

		Dim ddlPageNo As DropDownList = sender

		If ddlPageNo IsNot Nothing Then
			If grdSales.Rows.Count > 0 Then
				If ddlPageNo.SelectedIndex < grdSales.PageCount Or _
					ddlPageNo.SelectedIndex >= 0 Then

					grdSales.PageIndex = ddlPageNo.SelectedIndex
				End If
			End If
		End If
	End Sub

	' use tooltop on GridView
	Protected Sub grdSales_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdSales.RowDataBound
		Try
			If e.Row.RowType = DataControlRowType.DataRow Then
				e.Row.Cells(0).ToolTip = "Edit"
			End If
		Catch _e As Exception
		End Try
	End Sub

	Private Sub grdSales_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSales.DataBound
		With conn
			.Page_Setup(grdSales.TopPagerRow, grdSales, "ddlPageNo", "imbFirst", "imbPrev", "imbNext", "imbLast", "lblPageCount")
			.Page_Setup(grdSales.BottomPagerRow, grdSales, "ddlPageNo", "imbFirst", "imbPrev", "imbNext", "imbLast", "lblPageCount")
		End With
	End Sub

    Protected Sub ddlCPageNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        System.Threading.Thread.Sleep(500)

        Dim ddlPageNo As DropDownList = sender

        If ddlPageNo IsNot Nothing Then
            If grdCompete.Rows.Count > 0 Then
                If ddlPageNo.SelectedIndex < grdCompete.PageCount Or _
                    ddlPageNo.SelectedIndex >= 0 Then

                    grdCompete.PageIndex = ddlPageNo.SelectedIndex
                End If
            End If
        End If
    End Sub

	' use tooltop on GridView
	Protected Sub grdCompete_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdCompete.RowDataBound
		Try
			If e.Row.RowType = DataControlRowType.DataRow Then
				e.Row.Cells(0).ToolTip = "Edit"
			End If
		Catch _e As Exception
		End Try
	End Sub

    Private Sub grdCompete_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCompete.DataBound
        With conn
            .Page_Setup(grdCompete.TopPagerRow, grdCompete, "ddlCPageNo", "imbCFirst", "imbCPrev", "imbCNext", "imbCLast", "lblCPageCount")
            .Page_Setup(grdCompete.BottomPagerRow, grdCompete, "ddlCPageNo", "imbCFirst", "imbCPrev", "imbCNext", "imbCLast", "lblCPageCount")
        End With
    End Sub

    Protected Sub ddlSPageNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        System.Threading.Thread.Sleep(500)

        Dim ddlPageNo As DropDownList = sender

        If ddlPageNo IsNot Nothing Then
            If grdStocks.Rows.Count > 0 Then
                If ddlPageNo.SelectedIndex < grdStocks.PageCount Or _
                    ddlPageNo.SelectedIndex >= 0 Then

                    grdStocks.PageIndex = ddlPageNo.SelectedIndex
                End If
            End If
        End If
    End Sub

	' use tooltop on GridView
	Protected Sub grdStocks_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdStocks.RowDataBound
		Try
			If e.Row.RowType = DataControlRowType.DataRow Then
				e.Row.Cells(0).ToolTip = "Edit"
			End If
		Catch _e As Exception
		End Try
	End Sub

    Private Sub grdStocks_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdStocks.DataBound
        With conn
            .Page_Setup(grdStocks.TopPagerRow, grdStocks, "ddlSPageNo", "imbSFirst", "imbSPrev", "imbSNext", "imbSLast", "lblSPageCount")
            .Page_Setup(grdStocks.BottomPagerRow, grdStocks, "ddlSPageNo", "imbSFirst", "imbSPrev", "imbSNext", "imbSLast", "lblSPageCount")
        End With
    End Sub

    Protected Sub ddlIPageNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        System.Threading.Thread.Sleep(500)

        Dim ddlPageNo As DropDownList = sender

        If ddlPageNo IsNot Nothing Then
            If grdInventory.Rows.Count > 0 Then
                If ddlPageNo.SelectedIndex < grdInventory.PageCount Or _
                    ddlPageNo.SelectedIndex >= 0 Then

                    grdInventory.PageIndex = ddlPageNo.SelectedIndex
                End If
            End If
        End If
    End Sub

	' use tooltop on GridView
	Protected Sub grdInventory_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdInventory.RowDataBound
		Try
			If e.Row.RowType = DataControlRowType.DataRow Then
				e.Row.Cells(0).ToolTip = "Edit"
			End If
		Catch _e As Exception
		End Try
	End Sub

    Private Sub grdInventory_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdInventory.DataBound
        With conn
            .Page_Setup(grdInventory.TopPagerRow, grdInventory, "ddlIPageNo", "imbIFirst", "imbIPrev", "imbINext", "imbILast", "lblIPageCount")
            .Page_Setup(grdInventory.BottomPagerRow, grdInventory, "ddlIPageNo", "imbIFirst", "imbIPrev", "imbINext", "imbILast", "lblIPageCount")
        End With
    End Sub

	Protected Sub ddlTPageNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)

		Dim ddlPageNo As DropDownList = sender

		If ddlPageNo IsNot Nothing Then
			If grdTM.Rows.Count > 0 Then
				If ddlPageNo.SelectedIndex < grdTM.PageCount Or _
					ddlPageNo.SelectedIndex >= 0 Then

					grdTM.PageIndex = ddlPageNo.SelectedIndex
				End If
			End If
		End If
	End Sub

	' use tooltop on GridView
	Protected Sub grdTM_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles grdTM.RowDataBound
		Try
			If e.Row.RowType = DataControlRowType.DataRow Then
				e.Row.Cells(0).ToolTip = "Edit"
			End If
		Catch _e As Exception
		End Try
	End Sub

	Private Sub grdTM_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdTM.DataBound
		With conn
			.Page_Setup(grdTM.TopPagerRow, grdTM, "ddlTPageNo", "imbTFirst", "imbTPrev", "imbTNext", "imbTLast", "lblTPageCount")
			.Page_Setup(grdTM.BottomPagerRow, grdTM, "ddlTPageNo", "imbTFirst", "imbTPrev", "imbTNext", "imbTLast", "lblTPageCount")
		End With
	End Sub

	Protected Sub grdSales_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdSales.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		Dim sID As Double
		Dim qry As String

		sID = grdSales.DataKeys(grdSales.SelectedIndex).Values(0).ToString()
		Session("salesID") = sID
		qry = "SELECT * FROM vw_SalesReport WHERE subID = " & sID

		grdSales.DataSourceID = ""
		grdSales.DataBind()
		sqlDS_Sales.SelectCommand = qry
		grdSales.DataSourceID = "sqlDS_Sales"
		grdSales.DataBind()
		grdSales.Enabled = False

		panData.Visible = True
		panFilter.Visible = False
		enableSales()

		With conn
			'get details
			Dim retFld(12), retVal(12) As String

			retFld(0) = "fname"
			retFld(1) = "lname"
			retFld(2) = "cAdd"
			retFld(3) = "cityID"
			retFld(4) = "contact"
			retFld(5) = "productID"
			retFld(6) = "brandID"
			retFld(7) = "itemID"
			retFld(8) = "qty"
			retFld(9) = "dPurchased"
			retFld(10) = "serial"
			retFld(11) = "invoice"
			retFld(12) = "weekID"

			where = "subID = " & sID
			.getValues("vw_SalesReport", "*", where, 13, retFld, retVal, "", "", "")

			txtFname.Text = retVal(0)
			txtLname.Text = retVal(1)
			txtAdd.Text = retVal(2)

			If retVal(3) = "" Or retVal(3) = "0" Then
				ddlCity.SelectedIndex = -1
			Else
				ddlCity.SelectedValue = retVal(3)
			End If

			txtContact.Text = retVal(4)

			If retVal(5) = "" Or retVal(5) = "0" Then
				ddlDBrand.Items.Clear()
				ddlSCode.Items.Clear()
				ddlProd.SelectedIndex = -1

			Else
				ddlProd.SelectedValue = retVal(5)

				'load brand
				ddlDBrand.Items.Clear()
				where = "productID = " & retVal(5)
				.loadToDropDownList("tbl_Brand", ddlDBrand, False, "*", where, "brandID", "brand", "brand", "")
			End If

			If retVal(6) = "" Or retVal(6) = "0" Then
				ddlSCode.Items.Clear()
				ddlDBrand.SelectedIndex = -1

			Else
				ddlSCode.Items.Clear()
				where = "productID = " & retVal(5) & " AND brandID = " & retVal(6)
				.loadToDropDownList("tbl_Items", ddlSCode, False, "*", where, "itemID", "shortCode", "shortCode", "")

				ddlDBrand.SelectedValue = retVal(6)
			End If

			If retVal(7) = "" Or retVal(7) = "0" Then
				ddlSCode.SelectedIndex = -1
			Else
				ddlSCode.SelectedValue = retVal(7)
			End If

			txtQty.Text = retVal(8)

			ddlWeek.SelectedValue = retVal(12)
			ddlDP.Items.Clear()
			where = "weekID = " & retVal(12)
			.loadToDropDownList("tbl_WDay", ddlDP, False, "*", where, "wDay", "wDay", "wDay", "")

			ddlDP.SelectedValue = retVal(9)

			txtSerial.Text = retVal(10)
			txtInvoice.Text = retVal(11)

			btnModify.Text = "Update"
			btnCancel.Text = "Cancel"
		End With
	End Sub

    Public Sub enableSales()
        txtFname.ReadOnly = False
        txtLname.ReadOnly = False
        txtAdd.ReadOnly = False
        ddlCity.Enabled = True
        txtContact.ReadOnly = False

        ddlProd.Enabled = True
        ddlDBrand.Enabled = True
        ddlSCode.Enabled = True
        txtQty.ReadOnly = False
        ddlWeek.Enabled = True
        ddlDP.Enabled = True
        txtSerial.ReadOnly = False
        txtInvoice.ReadOnly = False

        imbShow.Visible = True
    End Sub

    Public Sub disableSales()
        txtFname.ReadOnly = True
        txtLname.ReadOnly = True
        txtAdd.ReadOnly = True
        ddlCity.Enabled = False
        txtContact.ReadOnly = True

        ddlProd.Enabled = False
        ddlDBrand.Enabled = False
        ddlSCode.Enabled = False
        txtQty.ReadOnly = True
        ddlWeek.Enabled = False
        ddlDP.Enabled = False
        txtSerial.ReadOnly = True
        txtInvoice.ReadOnly = True

        imbShow.Visible = False
    End Sub

    Protected Sub imbShow_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbShow.Click
        System.Threading.Thread.Sleep(500)

        If imbShow.ToolTip = "Search Short Code" Then
            If ddlProd.SelectedValue.Trim = "" Then
                lbleMsg.Text = "Select a product first."
                Exit Sub
            Else
                Session("prodID") = ddlProd.SelectedValue.Trim
                lblifProd.Text = ddlProd.SelectedItem.Text
            End If

            If ddlDBrand.SelectedValue.Trim = "" Then
                lbleMsg.Text = "Select a brand first."
                Exit Sub
            Else
                Session("brandID") = ddlDBrand.SelectedValue.Trim
                lblifBrand.Text = ddlDBrand.SelectedItem.Text
            End If

            panInfo.Visible = True
			imbShow.ImageUrl = "~/images/icons/cancel.png"
            imbShow.ToolTip = "Close Search"

        ElseIf imbShow.ToolTip = "Close Search" Then
            panInfo.Visible = False
			imbShow.ImageUrl = "~/images/icons/search.png"
            imbShow.ToolTip = "Search Short Code"
        End If
    End Sub

    Protected Sub imbClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbClose.Click
        panInfo.Visible = False
		imbShow.ImageUrl = "~/images/icons/search.png"
        imbShow.ToolTip = "Search Short Code"

		imbSShow.ImageUrl = "~/images/icons/search.png"
        imbSShow.ToolTip = "Search Short Code"

		imbIShow.ImageUrl = "~/images/icons/search.png"
        imbIShow.ToolTip = "Search Short Code"
    End Sub

    Public Function validateSales() As Boolean
        validateSales = True

        If ddlProd.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Product is required."
            validateSales = False
            Exit Function
        End If

        If ddlDBrand.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Brand is required."
            validateSales = False
            Exit Function
        End If

        If ddlSCode.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Short Code is required."
            validateSales = False
            Exit Function
        End If

        If txtQty.Text.Trim = "" Then
            lbleMsg.Text = "Qty is required."
            validateSales = False
            Exit Function

        Else
            If IsNumeric(txtQty.Text.Trim) = False Then
                lbleMsg.Text = "Qty should be numeric."
                validateSales = False
                Exit Function
            End If
        End If

        If ddlWeek.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Week is required."
            validateSales = False
            Exit Function
        End If

        If ddlDP.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Date Purchased is required."
            validateSales = False
            Exit Function
        End If

        If txtInvoice.Text.Trim = "" Then
            lbleMsg.Text = "Invoice Number is required."
            validateSales = False
            Exit Function
        End If
    End Function

    Public Sub updateSales()
        With conn
            Dim fld(10), val(10), dt(10) As String

            fld(0) = "fname"
            fld(1) = "lname"
            fld(2) = "cAdd"
            fld(3) = "cityID"
            fld(4) = "contact"
            fld(5) = "qty"
            fld(6) = "dPurchased"
            fld(7) = "serial"
            fld(8) = "invoice"
            fld(9) = "recStatusID"
            fld(10) = "itemID"

            val(0) = Replace(txtFname.Text.Trim, "'", "''")
            val(1) = Replace(txtLname.Text.Trim, "'", "''")
            val(2) = Replace(txtAdd.Text.Trim, "'", "''")

            If ddlCity.SelectedValue.Trim = "" Then
                val(3) = "0"
            Else
                val(3) = ddlCity.SelectedValue.Trim
            End If

            val(4) = Replace(txtContact.Text.Trim, "'", "''")
            val(5) = txtQty.Text.Trim
            val(6) = ddlDP.SelectedValue.Trim
            val(7) = Replace(txtSerial.Text.Trim, "'", "''")
            val(8) = Replace(txtInvoice.Text.Trim, "'", "''")

            If getStatus() = True Then
                val(9) = "1"
            Else
                val(9) = "2"
            End If

            val(10) = ddlSCode.SelectedValue.Trim

            dt(0) = "C"
            dt(1) = "C"
            dt(2) = "C"
            dt(3) = "N"
            dt(4) = "C"
            dt(5) = "N"
            dt(6) = "C"
            dt(7) = "C"
            dt(8) = "C"
            dt(9) = "N"
            dt(10) = "N"

            where = "subID = " & Session("salesID")
			.UpdateDB("tbl_SalesSub", fld, val, dt, where)
		End With
    End Sub

    Public Function getStatus() As Boolean

        Dim stat As Boolean = True

        If txtFname.Text.Trim = "" Then
            stat = False
        End If

        If txtLname.Text.Trim = "" Then
            stat = False
        End If

        If txtAdd.Text.Trim = "" Then
            stat = False
        End If

        If ddlCity.SelectedValue.Trim = "" Then
            stat = False
        End If

        If txtContact.Text.Trim = "" Then
            stat = False
        End If

        If txtSerial.Text.Trim = "" Then
            stat = False
        End If

        Return stat
    End Function

    Public Sub emptySales()
        txtFname.Text = ""
        txtLname.Text = ""
        txtAdd.Text = ""
        ddlCity.SelectedIndex = -1
        txtContact.Text = ""

        ddlProd.SelectedIndex = -1
        ddlDBrand.Items.Clear()
        ddlSCode.Items.Clear()
        txtQty.Text = ""
        ddlWeek.SelectedIndex = -1
        ddlDP.Items.Clear()
        txtSerial.Text = ""
        txtInvoice.Text = ""
    End Sub

    Protected Sub btnModify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModify.Click
        checkSession()
        lbleMsg.Text = ""
        System.Threading.Thread.Sleep(500)

        If btnModify.Text = "Modify" Then
            enableSales()
            grdSales.Enabled = False
            btnModify.Text = "Update"

        ElseIf btnModify.Text = "Update" Then
            If validateSales() = False Then
                Exit Sub

            Else
                'update record
                updateSales()

                emptySales()
                disableSales()

                grdSales.DataBind()
                grdSales.Enabled = True
                grdSales.SelectedIndex = -1

                panData.Visible = False
                panFilter.Visible = True

                btnModify.Text = "Modify"
            End If

        ElseIf btnModify.Text = "Save" Then
            'If validateSales() = False Then
            '    Exit Sub

            'Else
            '    'save record
            '    saveSales()
            '    saveUser()

            '    emptyAData()
            '    disableAcData()

            '    btnAEmp.Enabled = True
            '    btnUnlock.Enabled = True

            '    Session("sortBy") = "userID"
            '    searchLike(txtSearch.Text.Trim)
            '    grdAccount.Enabled = True
            '    grdAccount.SelectedIndex = -1

            '    btnAEmp.Visible = True
            '    btnUnlock.Visible = True
            '    btnReactivate.Visible = True

            '    btnAcModify.Text = "Modify"
            '    btnAcReset.Visible = False
            '    btnDeactivate.Visible = False

            '    panAEmp.Visible = False
            '    panUsers.Visible = True
            '    panUSearch.Visible = True
            'End If
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        emptySales()

        panData.Visible = False
        panFilter.Visible = True

        grdSales.DataBind()
        grdSales.Enabled = True
        grdSales.SelectedIndex = -1
    End Sub

    Protected Sub ddlProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlProd.SelectedIndexChanged
        If ddlProd.SelectedValue.Trim = "" Then
            ddlDBrand.Items.Clear()
            ddlSCode.Items.Clear()

        Else
            ddlDBrand.Items.Clear()
            where = "productID = " & ddlProd.SelectedValue.Trim
            conn.loadToDropDownList("tbl_Brand", ddlDBrand, False, "*", where, "brandID", "brand", "brand", "")

            ddlSCode.Items.Clear()
        End If
    End Sub

    Protected Sub ddlDBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlDBrand.SelectedIndexChanged
        If ddlProd.SelectedValue.Trim = "" Then
            ddlDBrand.Items.Clear()
            ddlSCode.Items.Clear()
            Exit Sub

        ElseIf ddlDBrand.SelectedValue.Trim = "" Then
            ddlSCode.Items.Clear()

        Else
            ddlSCode.Items.Clear()
            where = "productID = " & ddlProd.SelectedValue.Trim & " AND brandID = " & ddlDBrand.SelectedValue.Trim
            conn.loadToDropDownList("tbl_Items", ddlSCode, False, "*", where, "itemID", "shortCode", "shortCode", "")
        End If
    End Sub

    Protected Sub btnCModify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCModify.Click
        checkSession()
        lbleMsg.Text = ""
        System.Threading.Thread.Sleep(500)

        If btnCModify.Text = "Modify" Then
            enableCompete()
            grdCompete.Enabled = False
            btnCModify.Text = "Update"

        ElseIf btnCModify.Text = "Update" Then
            If validateCompete() = False Then
                Exit Sub

            Else
                'update record
                updateCompete()

                emptyCompete()
                disableCompete()

                grdCompete.DataBind()
                grdCompete.Enabled = True
                grdCompete.SelectedIndex = -1

                panCData.Visible = False
                pancFilter.Visible = True

                btnCModify.Text = "Modify"
            End If

        ElseIf btnCModify.Text = "Save" Then
            'If validateSales() = False Then
            '    Exit Sub

            'Else
            '    'save record
            '    saveSales()
            '    saveUser()

            '    emptyAData()
            '    disableAcData()

            '    btnAEmp.Enabled = True
            '    btnUnlock.Enabled = True

            '    Session("sortBy") = "userID"
            '    searchLike(txtSearch.Text.Trim)
            '    grdAccount.Enabled = True
            '    grdAccount.SelectedIndex = -1

            '    btnAEmp.Visible = True
            '    btnUnlock.Visible = True
            '    btnReactivate.Visible = True

            '    btnAcModify.Text = "Modify"
            '    btnAcReset.Visible = False
            '    btnDeactivate.Visible = False

            '    panAEmp.Visible = False
            '    panUsers.Visible = True
            '    panUSearch.Visible = True
            'End If
        End If
    End Sub

    Public Sub enableCompete()
        ddlCDBrand.Enabled = True
        ddlCCap.Enabled = True
        txtCQty.ReadOnly = False
        ddlCWeek.Enabled = True
        ddlCDP.Enabled = True
        txtFactor.ReadOnly = False
    End Sub

    Public Sub disableCompete()
        ddlCDBrand.Enabled = False
        ddlCCap.Enabled = False
        txtCQty.ReadOnly = True
        ddlCWeek.Enabled = False
        ddlCDP.Enabled = False
        txtFactor.ReadOnly = True
    End Sub

    Public Function validateCompete() As Boolean
        validateCompete = True

        If ddlCDBrand.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Brand is required."
            validateCompete = False
            Exit Function
        End If

        If ddlCCap.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Capacity is required."
            validateCompete = False
            Exit Function
        End If

        If txtCQty.Text.Trim = "" Then
            lbleMsg.Text = "Qty is required."
            validateCompete = False
            Exit Function

        Else
            If IsNumeric(txtCQty.Text.Trim) = False Then
                lbleMsg.Text = "Qty should be numeric."
                validateCompete = False
                Exit Function
            End If
        End If

        If ddlCWeek.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Week is required."
            validateCompete = False
            Exit Function
        End If

        If ddlCDP.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Date Purchased is required."
            validateCompete = False
            Exit Function
        End If

        If txtFactor.Text.Trim = "" Then
            lbleMsg.Text = "Factor affecting sell out is required."
            validateCompete = False
            Exit Function
        End If
    End Function

    Public Sub updateCompete()
        With conn
            Dim fld(10), val(10), dt(10) As String

            fld(0) = "cBrandID"
            fld(1) = "cCapacityID"
            fld(2) = "qty"
            fld(3) = "csDate"
            fld(4) = "factor"
            fld(5) = "weekID"

            If ddlCDBrand.SelectedValue.Trim = "" Then
                val(0) = "0"
            Else
                val(0) = ddlCDBrand.SelectedValue.Trim
            End If

            If ddlCCap.SelectedValue.Trim = "" Then
                val(1) = "0"
            Else
                val(1) = ddlCCap.SelectedValue.Trim
            End If

            val(2) = txtCQty.Text.Trim

            val(3) = ddlCDP.SelectedValue.Trim
            val(4) = Replace(txtFactor.Text.Trim, "'", "''")

            val(5) = ddlCWeek.SelectedValue.Trim

            dt(0) = "N"
            dt(1) = "N"
            dt(2) = "N"
            dt(3) = "C"
            dt(4) = "C"
            dt(5) = "N"

            where = "cSubID = " & Session("competeID")
            .UpdateDB("tbl_CompeteSub", fld, val, dt, where)
        End With
    End Sub

    Public Sub emptyCompete()
        ddlCDBrand.SelectedIndex = -1
        ddlCCap.SelectedIndex = -1
        txtQty.Text = ""
        ddlCWeek.SelectedIndex = -1
        ddlCDP.Items.Clear()
        txtFactor.Text = ""
    End Sub

    Protected Sub grdCompete_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdCompete.SelectedIndexChanged
        System.Threading.Thread.Sleep(500)

        Dim sID As Double
        Dim qry As String

        sID = grdCompete.DataKeys(grdCompete.SelectedIndex).Values(0).ToString()
        Session("competeID") = sID
        qry = "SELECT * FROM vw_CompeteReport WHERE cSubID = " & sID

        grdCompete.DataSourceID = ""
        grdCompete.DataBind()
        sqlDS_Compete.SelectCommand = qry
        grdCompete.DataSourceID = "sqlDS_Compete"
        grdCompete.DataBind()
        grdCompete.Enabled = False

        panCData.Visible = True
        panCFilter.Visible = False
        enableCompete()

        With conn
            'get details
            Dim retFld(5), retVal(5) As String

            retFld(0) = "cBrandID"
            retFld(1) = "cCapacityID"
            retFld(2) = "qty"
            retFld(3) = "csDate"
            retFld(4) = "factor"
            retFld(5) = "weekID"

            where = "cSubID = " & sID
            .getValues("vw_CompeteReport", "*", where, 6, retFld, retVal, "", "", "")

            If retVal(0) = "" Or retVal(0) = "0" Then
                ddlCDBrand.SelectedIndex = -1
            Else
                ddlCDBrand.SelectedValue = retVal(0)
            End If

            If retVal(1) = "" Or retVal(1) = "0" Then
                ddlCCap.SelectedIndex = -1
            Else
                ddlCCap.SelectedValue = retVal(1)
            End If

            txtCQty.Text = retVal(2)

            If retVal(5) = "" Or retVal(5) = "0" Then
                ddlCDP.Items.Clear()
                ddlCWeek.SelectedIndex = -1

            Else
                ddlCWeek.SelectedValue = retVal(5)

                'load brand
                ddlCDP.Items.Clear()
                where = "weekID = " & retVal(5)
                .loadToDropDownList("tbl_WDay", ddlCDP, False, "*", where, "wDay", "wDay", "wDay", "")

                If retVal(3) = "" Or retVal(3) = "0" Then
                    ddlCDP.SelectedIndex = -1
                Else
                    ddlCDP.SelectedValue = retVal(3)
                End If
            End If

            txtFactor.Text = retVal(4)
            
            btnCModify.Text = "Update"
            btnCCancel.Text = "Cancel"
        End With
    End Sub

    Protected Sub grdStocks_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdStocks.SelectedIndexChanged
        System.Threading.Thread.Sleep(500)

        Dim sID As Double
        Dim qry As String

        sID = grdStocks.DataKeys(grdStocks.SelectedIndex).Values(0).ToString()
        Session("stocksID") = sID
        qry = "SELECT * FROM vw_StocksReport WHERE sSubID = " & sID

        grdStocks.DataSourceID = ""
        grdStocks.DataBind()
        sqlDS_Stocks.SelectCommand = qry
        grdStocks.DataSourceID = "sqlDS_Stocks"
        grdStocks.DataBind()
        grdStocks.Enabled = False

        panSData.Visible = True
        panSFilter.Visible = False
        enableStocks()

        With conn
            'get details
            Dim retFld(7), retVal(7) As String

            retFld(0) = "productID"
            retFld(1) = "brandID"
            retFld(2) = "itemID"
            retFld(3) = "dWhen"
            retFld(4) = "actionID"
            retFld(5) = "otherAct"
            retFld(6) = "weekID"
            retFld(7) = "promo"

            where = "sSubID = " & sID
            .getValues("vw_StocksReport", "*", where, 8, retFld, retVal, "", "", "")

            If retVal(0) = "" Or retVal(0) = "0" Then
                ddlSProd.SelectedIndex = -1
                ddlSDBrand.Items.Clear()
                ddlSSCode.Items.Clear()

            Else
                ddlSProd.SelectedValue = retVal(0)
                ddlSDBrand.Items.Clear()
                where = "productID = " & retVal(0)
                .loadToDropDownList("tbl_Brand", ddlSDBrand, False, "*", where, "brandID", "brand", "brand", "")
            End If

            If retVal(1) = "" Or retVal(1) = "0" Then
                ddlSDBrand.SelectedIndex = -1
                ddlSSCode.Items.Clear()

            Else
                ddlSDBrand.SelectedValue = retVal(1)
                ddlSSCode.Items.Clear()
                where = "productID = " & retVal(0) & " AND brandID = " & retVal(1)
                .loadToDropDownList("tbl_Items", ddlSSCode, False, "*", where, "itemID", "shortCode", "shortCode", "")

                If retVal(2) = "" Or retVal(2) = "0" Then
                    ddlSSCode.SelectedIndex = -1
                Else
                    ddlSSCode.SelectedValue = retVal(2)
                End If
            End If

            ddlSWeek.SelectedValue = retVal(6)
            ddlSDP.Items.Clear()
            where = "weekID = " & retVal(6)
            .loadToDropDownList("tbl_WDay", ddlSDP, False, "*", where, "wDay", "wDay", "wDay", "")

            If retVal(3) = "" Or retVal(3) = "0" Then
                ddlSDP.SelectedIndex = -1
            Else
                ddlSDP.SelectedValue = retVal(3)
            End If

            If retVal(4) = "" Or retVal(4) = "0" Then
                ddlAction.SelectedIndex = -1
                txtOthers.Visible = False
                txtOthers.Text = ""

            Else
                ddlAction.SelectedValue = retVal(4)
                If retVal(4) = "3" Then
                    txtOthers.Visible = True
                    txtOthers.Text = retVal(5)
                Else
                    txtOthers.Visible = False
                    txtOthers.Text = ""
                End If
            End If

            btnSModify.Text = "Update"
            btnSCancel.Text = "Cancel"
        End With
    End Sub

    Public Sub emptyStocks()
        ddlSProd.SelectedIndex = -1
        ddlSDBrand.Items.Clear()
        ddlSSCode.Items.Clear()
        ddlAction.SelectedIndex = -1
        txtOthers.Text = ""
        ddlSWeek.SelectedIndex = -1
        ddlSDP.Items.Clear()
        txtPromo.Text = ""
    End Sub

    Public Sub updateStocks()
        With conn
            Dim fld(10), val(10), dt(10) As String

            fld(0) = "itemID"
            fld(1) = "dWhen"
            fld(2) = "actionID"
            fld(3) = "otherAct"
            fld(4) = "promo"
            fld(5) = "weekID"

            val(0) = ddlSSCode.SelectedValue.Trim
            val(1) = ddlSDP.SelectedValue.Trim

            If ddlAction.SelectedValue.Trim = "3" Then
                val(2) = ddlAction.SelectedValue.Trim
                val(3) = Replace(txtOthers.Text.Trim, "'", "''")

            Else
                val(2) = ddlAction.SelectedValue.Trim
                val(3) = ""
            End If

            val(4) = Replace(txtPromo.Text.Trim, "'", "''")
            val(5) = ddlSWeek.SelectedValue.Trim

            dt(0) = "N"
            dt(1) = "C"
            dt(2) = "N"
            dt(3) = "C"
            dt(4) = "C"
            dt(5) = "N"

            where = "ssubID = " & Session("stocksID")
            .UpdateDB("tbl_StocksSub", fld, val, dt, where)
        End With
    End Sub

    Public Function validateStocks() As Boolean
        validateStocks = True

        If ddlSProd.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Product is required."
            validateStocks = False
            Exit Function
        End If

        If ddlSDBrand.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Brand is required."
            validateStocks = False
            Exit Function
        End If

        If ddlSSCode.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Short Code is required."
            validateStocks = False
            Exit Function
        End If

        If ddlAction.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Action Taken is required."
            validateStocks = False
            Exit Function

        Else
            If ddlAction.SelectedValue.Trim = "3" Then
                If txtOthers.Text.Trim = "" Then
                    lbleMsg.Text = "Please state the action taken."
                    validateStocks = False
                    Exit Function
                End If
            End If
        End If

        If ddlSWeek.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Week is required."
            validateStocks = False
            Exit Function
        End If

        If ddlSDP.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Date is required."
            validateStocks = False
            Exit Function
        End If

        If txtPromo.Text.Trim = "" Then
            lbleMsg.Text = "Competitor Promo Activities is required."
            validateStocks = False
            Exit Function
        End If
    End Function

    Protected Sub imbSShow_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbSShow.Click
        System.Threading.Thread.Sleep(500)

        If imbSShow.ToolTip = "Search Short Code" Then
            If ddlSProd.SelectedValue.Trim = "" Then
                lbleMsg.Text = "Select a product first."
                Exit Sub
            Else
                Session("prodID") = ddlSProd.SelectedValue.Trim
                lblifProd.Text = ddlSProd.SelectedItem.Text
            End If

            If ddlSDBrand.SelectedValue.Trim = "" Then
                lbleMsg.Text = "Select a brand first."
                Exit Sub
            Else
                Session("brandID") = ddlSDBrand.SelectedValue.Trim
                lblifBrand.Text = ddlSDBrand.SelectedItem.Text
            End If

            panInfo.Visible = True
			imbSShow.ImageUrl = "~/images/icons/cancel.png"
            imbSShow.ToolTip = "Close Search"

        ElseIf imbSShow.ToolTip = "Close Search" Then
            panInfo.Visible = False
			imbSShow.ImageUrl = "~/images/icons/search.png"
            imbSShow.ToolTip = "Search Short Code"
        End If
    End Sub

    Public Sub disableStocks()
        ddlSProd.Enabled = False
        ddlSDBrand.Enabled = False
        ddlSSCode.Enabled = False
        ddlAction.Enabled = False
        txtOthers.ReadOnly = True
        ddlSWeek.Enabled = False
        ddlSDP.Enabled = False
        txtPromo.ReadOnly = True

        imbSShow.Visible = False
    End Sub

    Public Sub enableStocks()
        ddlSProd.Enabled = True
        ddlSDBrand.Enabled = True
        ddlSSCode.Enabled = True
        ddlAction.Enabled = True
        txtOthers.ReadOnly = False
        ddlSWeek.Enabled = True
        ddlSDP.Enabled = True
        txtPromo.ReadOnly = False

        imbSShow.Visible = True
    End Sub

    Protected Sub btnSModify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSModify.Click
        checkSession()
        lbleMsg.Text = ""
        System.Threading.Thread.Sleep(500)

        If btnSModify.Text = "Modify" Then
            enableStocks()
            grdStocks.Enabled = False
            btnSModify.Text = "Update"

        ElseIf btnSModify.Text = "Update" Then
            If validateStocks() = False Then
                Exit Sub

            Else
                'update record
                updateStocks()

                emptyStocks()
                disableStocks()

                grdStocks.DataBind()
                grdStocks.Enabled = True
                grdStocks.SelectedIndex = -1

                panSData.Visible = False
                panSFilter.Visible = True

                btnSModify.Text = "Modify"
            End If

        ElseIf btnSModify.Text = "Save" Then
            'If validateSales() = False Then
            '    Exit Sub

            'Else
            '    'save record
            '    saveSales()
            '    saveUser()

            '    emptyAData()
            '    disableAcData()

            '    btnAEmp.Enabled = True
            '    btnUnlock.Enabled = True

            '    Session("sortBy") = "userID"
            '    searchLike(txtSearch.Text.Trim)
            '    grdAccount.Enabled = True
            '    grdAccount.SelectedIndex = -1

            '    btnAEmp.Visible = True
            '    btnUnlock.Visible = True
            '    btnReactivate.Visible = True

            '    btnAcModify.Text = "Modify"
            '    btnAcReset.Visible = False
            '    btnDeactivate.Visible = False

            '    panAEmp.Visible = False
            '    panUsers.Visible = True
            '    panUSearch.Visible = True
            'End If
        End If
    End Sub

    Protected Sub btnSCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSCancel.Click
        emptyStocks()

        panSData.Visible = False
        panSFilter.Visible = True

        grdStocks.DataBind()
        grdStocks.Enabled = True
        grdStocks.SelectedIndex = -1
    End Sub

    Protected Sub grdInventory_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdInventory.SelectedIndexChanged
        System.Threading.Thread.Sleep(500)

        Dim sID As Double
        Dim qry As String

        sID = grdInventory.DataKeys(grdInventory.SelectedIndex).Values(0).ToString()
        Session("inventoryID") = sID
        qry = "SELECT * FROM vw_InventoryReport WHERE iSubID = " & sID

        grdInventory.DataSourceID = ""
        grdInventory.DataBind()
        sqlDS_Inventory.SelectCommand = qry
        grdInventory.DataSourceID = "sqlDS_Inventory"
        grdInventory.DataBind()
        grdInventory.Enabled = False

        panIData.Visible = True
        panIFilter.Visible = False
        enableInventory()

        With conn
            'get details
            Dim retFld(4), retVal(4) As String

            retFld(0) = "productID"
            retFld(1) = "brandID"
            retFld(2) = "itemID"
            retFld(3) = "qty"
            retFld(4) = "comments"

            where = "iSubID = " & sID
            .getValues("vw_InventoryReport", "*", where, 5, retFld, retVal, "", "", "")

           If retVal(0) = "" Or retVal(0) = "0" Then
                ddlIProd.SelectedIndex = -1
                ddlIDBrand.Items.Clear()
                ddlISCode.Items.Clear()

            Else
                ddlIProd.SelectedValue = retVal(0)
                ddlIDBrand.Items.Clear()
                where = "productID = " & retVal(0)
                .loadToDropDownList("tbl_Brand", ddlIDBrand, False, "*", where, "brandID", "brand", "brand", "")
            End If

            If retVal(1) = "" Or retVal(1) = "0" Then
                ddlIDBrand.SelectedIndex = -1
                ddlISCode.Items.Clear()

            Else
                ddlIDBrand.SelectedValue = retVal(1)
                ddlISCode.Items.Clear()
                where = "productID = " & retVal(0) & " AND brandID = " & retVal(1)
                .loadToDropDownList("tbl_Items", ddlISCode, False, "*", where, "itemID", "shortCode", "shortCode", "")

                If retVal(2) = "" Or retVal(2) = "0" Then
                    ddlISCode.SelectedIndex = -1
                Else
                    ddlISCode.SelectedValue = retVal(2)
                End If
            End If

            txtIQty.Text = retVal(3)
            txtComments.Text = retVal(4)

            btnIModify.Text = "Update"
            btnICancel.Text = "Cancel"
        End With
    End Sub

    Public Sub emptyInventory()
        ddlIProd.SelectedIndex = -1
        ddlIDBrand.Items.Clear()
        ddlISCode.Items.Clear()
        txtIQty.Text = ""
        txtComments.Text = ""
    End Sub

    Public Sub updateInventory()
        With conn
            Dim fld(2), val(2), dt(2) As String

            fld(0) = "itemID"
            fld(1) = "qty"
            fld(2) = "comments"

            val(0) = ddlISCode.SelectedValue.Trim
            val(1) = txtIQty.Text.Trim
            val(2) = Replace(txtComments.Text.Trim, "'", "''")

            dt(0) = "C"
            dt(1) = "C"
            dt(2) = "C"

            where = "iSubID = " & Session("inventoryID")
            .UpdateDB("tbl_InventorySub", fld, val, dt, where)
        End With
    End Sub

    Public Function validateInventory() As Boolean
        validateInventory = True

        If ddlIProd.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Product is required."
            validateInventory = False
            Exit Function
        End If

        If ddlIDBrand.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Brand is required."
            validateInventory = False
            Exit Function
        End If

        If ddlISCode.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Short Code is required."
            validateInventory = False
            Exit Function
        End If

        If txtIQty.Text.Trim = "" Then
            lbleMsg.Text = "Qty is required."
            validateInventory = False
            Exit Function

        Else
            If IsNumeric(txtIQty.Text.Trim) = False Then
                lbleMsg.Text = "Qty should be numeric."
                validateInventory = False
                Exit Function
            End If
        End If
    End Function

    Public Sub disableInventory()
        ddlIProd.Enabled = False
        ddlIDBrand.Enabled = False
        ddlISCode.Enabled = False
        txtIQty.ReadOnly = True
        txtComments.ReadOnly = True

        imbIShow.Visible = False
    End Sub

    Public Sub enableInventory()
        ddlIProd.Enabled = True
        ddlIDBrand.Enabled = True
        ddlISCode.Enabled = True
        txtIQty.ReadOnly = False
        txtComments.ReadOnly = False

        imbIShow.Visible = True
	End Sub

	Protected Sub imbIShow_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbIShow.Click
		System.Threading.Thread.Sleep(500)

		If imbIShow.ToolTip = "Search Short Code" Then
			If ddlIProd.SelectedValue.Trim = "" Then
				lbleMsg.Text = "Select a product first."
				Exit Sub
			Else
				Session("prodID") = ddlIProd.SelectedValue.Trim
				lblifProd.Text = ddlIProd.SelectedItem.Text
			End If

			If ddlIDBrand.SelectedValue.Trim = "" Then
				lbleMsg.Text = "Select a brand first."
				Exit Sub
			Else
				Session("brandID") = ddlIDBrand.SelectedValue.Trim
				lblifBrand.Text = ddlIDBrand.SelectedItem.Text
			End If

			panInfo.Visible = True
			imbIShow.ImageUrl = "~/images/icons/cancel.png"
			imbIShow.ToolTip = "Close Search"

		ElseIf imbIShow.ToolTip = "Close Search" Then
			panInfo.Visible = False
			imbIShow.ImageUrl = "~/images/icons/search.png"
			imbIShow.ToolTip = "Search Short Code"
		End If
	End Sub

	Protected Sub btnIModify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnIModify.Click
		checkSession()
		lbleMsg.Text = ""
		System.Threading.Thread.Sleep(500)

		If btnIModify.Text = "Modify" Then
			enableInventory()
			grdInventory.Enabled = False
			btnIModify.Text = "Update"

		ElseIf btnIModify.Text = "Update" Then
			If validateInventory() = False Then
				Exit Sub

			Else
				'update record
				updateInventory()

				emptyInventory()
				disableInventory()

				grdInventory.DataBind()
				grdInventory.Enabled = True
				grdInventory.SelectedIndex = -1

				panIData.Visible = False
				panIFilter.Visible = True

				btnIModify.Text = "Modify"
			End If

		ElseIf btnIModify.Text = "Save" Then
			'If validateSales() = False Then
			'    Exit Sub

			'Else
			'    'save record
			'    saveSales()
			'    saveUser()

			'    emptyAData()
			'    disableAcData()

			'    btnAEmp.Enabled = True
			'    btnUnlock.Enabled = True

			'    Session("sortBy") = "userID"
			'    searchLike(txtSearch.Text.Trim)
			'    grdAccount.Enabled = True
			'    grdAccount.SelectedIndex = -1

			'    btnAEmp.Visible = True
			'    btnUnlock.Visible = True
			'    btnReactivate.Visible = True

			'    btnAcModify.Text = "Modify"
			'    btnAcReset.Visible = False
			'    btnDeactivate.Visible = False

			'    panAEmp.Visible = False
			'    panUsers.Visible = True
			'    panUSearch.Visible = True
			'End If
		End If
	End Sub

	Protected Sub grdTM_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdTM.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)

		Dim sID As Double
		Dim qry As String

		sID = grdTM.DataKeys(grdTM.SelectedIndex).Values(0).ToString()
		Session("TMSalesID") = sID
		qry = "SELECT * FROM vw_SalesReport WHERE subID = " & sID

		grdTM.DataSourceID = ""
		grdTM.DataBind()
		sqlDS_TMSales.SelectCommand = qry
		grdTM.DataSourceID = "sqlDS_TMSales"
		grdTM.DataBind()
		grdTM.Enabled = False

		panTData.Visible = True
		panTFilter.Visible = False
		enableTM()

		With conn
			'get details
			Dim retFld(12), retVal(12) As String

			retFld(0) = "fname"
			retFld(1) = "lname"
			retFld(2) = "cAdd"
			retFld(3) = "cityID"
			retFld(4) = "contact"
			retFld(5) = "productID"
			retFld(6) = "brandID"
			retFld(7) = "itemID"
			retFld(8) = "qty"
			retFld(9) = "dPurchased"
			retFld(10) = "serial"
			retFld(11) = "invoice"
			retFld(12) = "weekID"

			where = "subID = " & sID
			.getValues("vw_SalesReport", "*", where, 13, retFld, retVal, "", "", "")

			txtTFname.Text = retVal(0)
			txtTLname.Text = retVal(1)
			txtTAdd.Text = retVal(2)

			If retVal(3) = "" Or retVal(3) = "0" Then
				ddlTCity.SelectedIndex = -1
			Else
				ddlTCity.SelectedValue = retVal(3)
			End If

			txtTContact.Text = retVal(4)

			If retVal(5) = "" Or retVal(5) = "0" Then
				ddlTDBrand.Items.Clear()
				ddlTSCode.Items.Clear()
				ddlTProd.SelectedIndex = -1

			Else
				ddlTProd.SelectedValue = retVal(5)

				'load brand
				ddlTDBrand.Items.Clear()
				where = "productID = " & retVal(5)
				.loadToDropDownList("tbl_Brand", ddlTDBrand, False, "*", where, "brandID", "brand", "brand", "")
			End If

			If retVal(6) = "" Or retVal(6) = "0" Then
				ddlTSCode.Items.Clear()
				ddlTDBrand.SelectedIndex = -1

			Else
				ddlTSCode.Items.Clear()
				where = "productID = " & retVal(5) & " AND brandID = " & retVal(6)
				.loadToDropDownList("tbl_Items", ddlTSCode, False, "*", where, "itemID", "shortCode", "shortCode", "")

				ddlTDBrand.SelectedValue = retVal(6)
			End If

			If retVal(7) = "" Or retVal(7) = "0" Then
				ddlTSCode.SelectedIndex = -1
			Else
				ddlTSCode.SelectedValue = retVal(7)
			End If

			txtTQty.Text = retVal(8)

			ddlTWeek.SelectedValue = retVal(12)
			ddlTDP.Items.Clear()
			where = "weekID = " & retVal(12)
			.loadToDropDownList("tbl_WDay", ddlTDP, False, "*", where, "wDay", "wDay", "wDay", "")

			ddlTDP.SelectedValue = retVal(9)

			txtTSerial.Text = retVal(10)
			txtTInvoice.Text = retVal(11)

			btnTModify.Text = "Update"
			btnTCancel.Text = "Cancel"
		End With
	End Sub

	Public Sub emptyTM()
		ddlTProd.SelectedIndex = -1
		ddlTDBrand.Items.Clear()
		ddlTSCode.Items.Clear()
		txtTQty.Text = ""
	End Sub

	Public Sub updateTM()
		With conn
			Dim fld(10), val(10), dt(10) As String
			Dim fld2(1), val2(1), dt2(1) As String

			fld(0) = "fname"
			fld(1) = "lname"
			fld(2) = "cAdd"
			fld(3) = "cityID"
			fld(4) = "contact"
			fld(5) = "qty"
			fld(6) = "dPurchased"
			fld(7) = "serial"
			fld(8) = "invoice"
			fld(9) = "recStatusID"
			fld(10) = "itemID"

			val(0) = Replace(txtTFname.Text.Trim, "'", "''")
			val(1) = Replace(txtTLname.Text.Trim, "'", "''")
			val(2) = Replace(txtTAdd.Text.Trim, "'", "''")

			If ddlTCity.SelectedValue.Trim = "" Then
				val(3) = "0"
			Else
				val(3) = ddlTCity.SelectedValue.Trim
			End If

			val(4) = Replace(txtTContact.Text.Trim, "'", "''")
			val(5) = txtTQty.Text.Trim
			val(6) = ddlTDP.SelectedValue.Trim
			val(7) = Replace(txtTSerial.Text.Trim, "'", "''")
			val(8) = Replace(txtTInvoice.Text.Trim, "'", "''")

			If getStatus() = True Then
				val(9) = "1"
			Else
				val(9) = "2"
			End If

			val(10) = ddlTSCode.SelectedValue.Trim

			dt(0) = "C"
			dt(1) = "C"
			dt(2) = "C"
			dt(3) = "N"
			dt(4) = "C"
			dt(5) = "N"
			dt(6) = "C"
			dt(7) = "C"
			dt(8) = "C"
			dt(9) = "N"
			dt(10) = "N"

			where = "subID = " & Session("TMSalesID")
			.UpdateDB("tbl_SalesSub", fld, val, dt, where)

			' next update tbl_Items
			fld2(0) = "productID"
			fld2(1) = "brandID"

			val2(0) = ddlTProd.SelectedValue.Trim
			val2(1) = ddlTDBrand.SelectedValue.Trim

			dt2(0) = "N"
			dt2(1) = "N"

			Dim l_where As String = "itemID = " & val(10)
			.UpdateDB("tbl_Items", fld2, val2, dt2, l_where)
		End With
	End Sub

	Public Function validateTM() As Boolean
		validateTM = True

		If ddlTProd.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Product is required."
			validateTM = False
			Exit Function
		End If

		If ddlTDBrand.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Brand is required."
			validateTM = False
			Exit Function
		End If

		If ddlTSCode.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Short Code is required."
			validateTM = False
			Exit Function
		End If

		If txtTQty.Text.Trim = "" Then
			lbleMsg.Text = "Qty is required."
			validateTM = False
			Exit Function

		Else
			If IsNumeric(txtTQty.Text.Trim) = False Then
				lbleMsg.Text = "Qty should be numeric."
				validateTM = False
				Exit Function
			End If
		End If
	End Function

	Public Sub disableTM()
		ddlTProd.Enabled = False
		ddlTDBrand.Enabled = False
		ddlTSCode.Enabled = False
		txtTQty.ReadOnly = True
		'txtComments.ReadOnly = True

		'imbIShow.Visible = False
	End Sub

	Public Sub enableTM()
		ddlTProd.Enabled = True
		ddlTDBrand.Enabled = True
		ddlTSCode.Enabled = True
		txtTQty.ReadOnly = False
		'txtComments.ReadOnly = False

		'imbIShow.Visible = True
	End Sub

	Protected Sub btnTModify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTModify.Click
		checkSession()
		lbleMsg.Text = ""
		System.Threading.Thread.Sleep(500)

		If btnTModify.Text = "Modify" Then
			enableTM()
			grdTM.Enabled = False
			btnTModify.Text = "Update"

		ElseIf btnTModify.Text = "Update" Then
			If validateTM() = False Then
				Exit Sub

			Else
				'update record
				updateTM()

				emptyTM()
				disableTM()

				grdTM.DataBind()
				grdTM.Enabled = True
				grdTM.SelectedIndex = -1

				panTData.Visible = False
				panTFilter.Visible = True

				btnTModify.Text = "Modify"
			End If

		ElseIf btnTModify.Text = "Save" Then
			'If validateSales() = False Then
			'    Exit Sub

			'Else
			'    'save record
			'    saveSales()
			'    saveUser()

			'    emptyAData()
			'    disableAcData()

			'    btnAEmp.Enabled = True
			'    btnUnlock.Enabled = True

			'    Session("sortBy") = "userID"
			'    searchLike(txtSearch.Text.Trim)
			'    grdAccount.Enabled = True
			'    grdAccount.SelectedIndex = -1

			'    btnAEmp.Visible = True
			'    btnUnlock.Visible = True
			'    btnReactivate.Visible = True

			'    btnAcModify.Text = "Modify"
			'    btnAcReset.Visible = False
			'    btnDeactivate.Visible = False

			'    panAEmp.Visible = False
			'    panUsers.Visible = True
			'    panUSearch.Visible = True
			'End If
		End If
	End Sub
End Class