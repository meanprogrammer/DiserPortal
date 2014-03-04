Public Class Report
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

            'conn.loadToDropDownList("vw_Users", ddlEmp, False, "*", "", "userID", "empName", "empName", "")
            conn.loadToDropDownList("tbl_CBrand", ddlBrand, False, "*", "", "cBrandID", "cBrand", "cBrand", "")
            'conn.loadToDropDownList("vw_Users", ddlSEmp, False, "*", "", "userID", "empName", "empName", "")
            'conn.loadToDropDownList("vw_Users", ddlIEmp, False, "*", "", "userID", "empName", "empName", "")
        End If
    End Sub

    Public Sub checkUType()
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "accntTypeID"

            where = "userID = " & Session("userID")
            .getValues("tbl_Login", "userID, accntTypeID", where, 1, retFld, retVal, "", "", "")

            Dim qSales, qCompete, qStocks, qInventory As String

            If retVal(0) = "1" Or retVal(0) = "5" Or retVal(0) = "6" Or retVal(0) = "9" Then
                Response.Redirect("~/Report/ReportUpdate.aspx")
            End If

            'If retVal(0) = "1" Then     'super admin
            '    .loadToDropDownList("vw_Users", ddlEmp, False, "*", "", "userID", "empName", "empName", "")
            '    .loadToDropDownList("vw_Users", ddlSEmp, False, "*", "", "userID", "empName", "empName", "")
            '    .loadToDropDownList("vw_Users", ddlIEmp, False, "*", "", "userID", "empName", "empName", "")

            '    qSales = "SELECT * FROM vw_SalesReport"
            '    qCompete = "SELECT * FROM vw_CompeteReport"
            '    qStocks = "SELECT * FROM vw_StocksReport"
            '    qInventory = "SELECT * FROM vw_InventoryReport"

            '    setBtnMod()

            'ElseIf retVal(0) = "5" Then     'fc
            '    where = "(accntTypeID = 6 AND fcID = " & Session("userID") & ") OR (accntTypeID = 7 AND fcID = " & Session("userID") & ")"

            '    .loadToDropDownList("vw_Users", ddlEmp, False, "*", where, "userID", "empName", "empName", "")
            '    .loadToDropDownList("vw_Users", ddlSEmp, False, "*", where, "userID", "empName", "empName", "")
            '    .loadToDropDownList("vw_Users", ddlIEmp, False, "*", where, "userID", "empName", "empName", "")

            '    qSales = "SELECT * FROM vw_SalesReport WHERE " & where
            '    qCompete = "SELECT * FROM vw_CompeteReport WHERE " & where
            '    qStocks = "SELECT * FROM vw_StocksReport WHERE " & where
            '    qInventory = "SELECT * FROM vw_InventoryReport WHERE " & where

            '    setBtnMod()

            'ElseIf retVal(0) = "9" Then     'sfc
            '    where = "accntTypeID = 5 AND sFCID = " & Session("userID")

            '    .loadToDropDownList("vw_Users", ddlEmp, False, "*", "", "userID", "empName", "empName", "")
            '    .loadToDropDownList("vw_Users", ddlSEmp, False, "*", "", "userID", "empName", "empName", "")
            '    .loadToDropDownList("vw_Users", ddlIEmp, False, "*", "", "userID", "empName", "empName", "")

            '    qSales = "SELECT * FROM vw_SalesReport WHERE " & where
            '    qCompete = "SELECT * FROM vw_CompeteReport WHERE " & where
            '    qStocks = "SELECT * FROM vw_StocksReport WHERE " & where
            '    qInventory = "SELECT * FROM vw_InventoryReport WHERE " & where

            '    setBtnMod()
            'End If

            'grdSales.DataSourceID = ""
            'grdSales.DataBind()
            'sqlDS_Sales.SelectCommand = qSales
            'grdSales.DataSourceID = "sqlDS_Sales"
            'grdSales.DataBind()

            'grdCompete.DataSourceID = ""
            'grdCompete.DataBind()
            'sqlDS_Compete.SelectCommand = qCompete
            'grdCompete.DataSourceID = "sqlDS_Compete"
            'grdCompete.DataBind()

            'grdStocks.DataSourceID = ""
            'grdStocks.DataBind()
            'sqlDS_Stocks.SelectCommand = qStocks
            'grdStocks.DataSourceID = "sqlDS_Stocks"
            'grdStocks.DataBind()

            'grdInventory.DataSourceID = ""
            'grdInventory.DataBind()
            'sqlDS_Inventory.SelectCommand = qInventory
            'grdInventory.DataSourceID = "sqlDS_Inventory"
            'grdInventory.DataBind()
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

    Protected Sub ddlDate_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlDate.SelectedIndexChanged
        searchSales()
    End Sub

    Public Sub searchSales()
        Select Case ddlFilter.SelectedValue.Trim
            Case 2      'weekly
                If ddlDate.SelectedValue.Trim = "" Then
                    If ddlEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_SalesReport ORDER BY subID DESC"

                    Else
                        qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlEmp.SelectedValue.Trim _
                                 & " ORDER BY subID DESC"
                    End If

                Else
                    If ddlEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_SalesReport WHERE weekID = " & ddlDate.SelectedValue.Trim _
                                & " ORDER BY subID DESC"

                    Else
                        qry = "SELECT * FROM vw_SalesReport WHERE weekID = " & ddlDate.SelectedValue.Trim _
                                & " AND userID = " & ddlEmp.SelectedValue.Trim _
                                & " ORDER BY subID DESC"
                    End If
                End If

            Case 3
                If ddlDate.SelectedValue.Trim = "" Then
                    If ddlEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_SalesReport ORDER BY subID DESC"

                    Else
                        qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlEmp.SelectedValue.Trim _
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

                    If ddlEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_SalesReport WHERE wMonthID = " & mNo _
                                & " ORDER BY subID DESC"

                    Else
                        qry = "SELECT * FROM vw_SalesReport WHERE wMonthID = " & mNo _
                                & " AND userID = " & ddlEmp.SelectedValue.Trim _
                                & " ORDER BY subID DESC"
                    End If
                End If

            Case 4
                If ddlDate.SelectedValue.Trim = "" Then
                    If ddlEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_SalesReport ORDER BY subID DESC"

                    Else
                        qry = "SELECT * FROM vw_SalesReport WHERE userID = " & ddlEmp.SelectedValue.Trim _
                                 & " ORDER BY subID DESC"
                    End If

                Else
                    If ddlEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_SalesReport WHERE wYear = '" & ddlDate.SelectedValue.Trim _
                                & "' ORDER BY subID DESC"

                    Else
                        qry = "SELECT * FROM vw_SalesReport WHERE wYear = '" & ddlDate.SelectedValue.Trim _
                                & "' AND userID = " & ddlEmp.SelectedValue.Trim _
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
                    If ddlSEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_StocksReport ORDER BY sSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_StocksReport WHERE userID = " & ddlSEmp.SelectedValue.Trim _
                                 & " ORDER BY sSubID DESC"
                    End If

                Else
                    If ddlSEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_StocksReport WHERE weekID = " & ddlSDate.SelectedValue.Trim _
                                & " ORDER BY sSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_StocksReport WHERE weekID = " & ddlSDate.SelectedValue.Trim _
                                & " AND userID = " & ddlSEmp.SelectedValue.Trim _
                                & " ORDER BY sSubID DESC"
                    End If
                End If

            Case 3
                If ddlSDate.SelectedValue.Trim = "" Then
                    If ddlSEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_StocksReport ORDER BY sSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_StocksReport WHERE userID = " & ddlSEmp.SelectedValue.Trim _
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

                    If ddlSEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_StocksReport WHERE wMonthID = " & mNo _
                                & " ORDER BY sSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_StocksReport WHERE wMonthID = " & mNo _
                                & " AND userID = " & ddlSEmp.SelectedValue.Trim _
                                & " ORDER BY sSubID DESC"
                    End If
                End If

            Case 4
                If ddlSDate.SelectedValue.Trim = "" Then
                    If ddlSEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_StocksReport ORDER BY sSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_StocksReport WHERE userID = " & ddlSEmp.SelectedValue.Trim _
                                 & " ORDER BY sSubID DESC"
                    End If

                Else
                    If ddlSEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_StocksReport WHERE wYear = '" & ddlSDate.SelectedValue.Trim _
                                & "' ORDER BY sSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_StocksReport WHERE wYear = '" & ddlSDate.SelectedValue.Trim _
                                & "' AND userID = " & ddlSEmp.SelectedValue.Trim _
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
                    If ddlIEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_InventoryReport ORDER BY iSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_InventoryReport WHERE userID = " & ddlIEmp.SelectedValue.Trim _
                                 & " ORDER BY iSubID DESC"
                    End If

                Else
                    If ddlIEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_InventoryReport WHERE weekID = " & ddlIDate.SelectedValue.Trim _
                                & " ORDER BY iSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_InventoryReport WHERE weekID = " & ddlIDate.SelectedValue.Trim _
                                & " AND userID = " & ddlIEmp.SelectedValue.Trim _
                                & " ORDER BY iSubID DESC"
                    End If
                End If

            Case 3
                If ddlIDate.SelectedValue.Trim = "" Then
                    If ddlIEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_InventoryReport ORDER BY iSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_InventoryReport WHERE userID = " & ddlIEmp.SelectedValue.Trim _
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

                    If ddlIEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_InventoryReport WHERE wMonthID = " & mNo _
                                & " ORDER BY iSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_InventoryReport WHERE wMonthID = " & mNo _
                                & " AND userID = " & ddlIEmp.SelectedValue.Trim _
                                & " ORDER BY iSubID DESC"
                    End If
                End If

            Case 4
                If ddlIDate.SelectedValue.Trim = "" Then
                    If ddlIEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_InventoryReport ORDER BY iSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_InventoryReport WHERE userID = " & ddlIEmp.SelectedValue.Trim _
                                 & " ORDER BY iSubID DESC"
                    End If

                Else
                    If ddlIEmp.SelectedValue.Trim = "" Then
                        qry = "SELECT * FROM vw_InventoryReport WHERE wYear = '" & ddlIDate.SelectedValue.Trim _
                                & "' ORDER BY iSubID DESC"

                    Else
                        qry = "SELECT * FROM vw_InventoryReport WHERE wYear = '" & ddlIDate.SelectedValue.Trim _
                                & "' AND userID = " & ddlIEmp.SelectedValue.Trim _
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

    Protected Sub lnkCompete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkCompete.Click
        checkSession()
        lbleMsg.Text = ""

        panSales.Visible = False
        panCompete.Visible = True
        panStocks.Visible = False
        panInventory.Visible = False

        lnkProd.CssClass = "tabprop"
        lnkCompete.CssClass = "tabprop-Selected"
        lnkStocks.CssClass = "tabprop"
        lnkInventory.CssClass = "tabprop"

        Session("rType") = "Compete"
    End Sub

    Protected Sub lnkProd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkProd.Click
        checkSession()
        lbleMsg.Text = ""

        panSales.Visible = True
        panCompete.Visible = False
        panStocks.Visible = False
        panInventory.Visible = False

        lnkProd.CssClass = "tabprop-Selected"
        lnkCompete.CssClass = "tabprop"
        lnkStocks.CssClass = "tabprop"
        lnkInventory.CssClass = "tabprop"

        Session("rType") = "Sales"
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

        lnkProd.CssClass = "tabprop"
        lnkCompete.CssClass = "tabprop"
        lnkStocks.CssClass = "tabprop-Selected"
        lnkInventory.CssClass = "tabprop"

        Session("rType") = "Stocks"
    End Sub

    Protected Sub lnkInventory_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkInventory.Click
        checkSession()
        lbleMsg.Text = ""

        panSales.Visible = False
        panCompete.Visible = False
        panStocks.Visible = False
        panInventory.Visible = True

        lnkProd.CssClass = "tabprop"
        lnkCompete.CssClass = "tabprop"
        lnkStocks.CssClass = "tabprop"
        lnkInventory.CssClass = "tabprop-Selected"

        Session("rType") = "Inventory"
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

    Protected Sub btnModify_Click(ByVal sender As Object, ByVal e As EventArgs)
        checkSession()
        Response.Redirect("~/Report/ReportUpdate.aspx")
    End Sub
End Class