Public Class DownloadedFile
    Inherits System.Web.UI.Page

    Public conn As New clsConn

    Public mstr As New MasterPage
    Public qry, where As String

    Protected Sub btnLoadFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoadFile.Click
        System.Threading.Thread.Sleep(500)

        Select Case Session("uploadType")
            Case "Sales"
                LoadSales()

            Case "Compete"
                LoadCompete()

            Case "Stocks"
                LoadStocks()

            Case "Inventory"
                LoadInventory()
        End Select
    End Sub

    Public Sub LoadStocks()
        checkSValidity()
        If Session("uStatCheck") = "Invalid" Then
            lbleMsg.Text = "There are still invalid records. Please validate data first."
            Exit Sub

        Else
            'get data and transfer it to sales
            With conn
                Dim retFld(5), retVal(5) As String

                retFld(0) = "itemID"
                retFld(1) = "dOut"
                retFld(2) = "actionID"
                retFld(3) = "others"
                retFld(4) = "promo"
                retFld(5) = "eSID"

                where = "userID = " & Session("userID") & " AND uploadDate = '" & Session("uploadDate") & "'"
                .getRecords("tbl_SExcelUpload", "*", where, 6, retFld, retVal, "", "")

                Dim itemID() As String = Split(retVal(0).Trim, "+")
                Dim dOut() As String = Split(retVal(1).Trim, "+")
                Dim actionID() As String = Split(retVal(2).Trim, "+")
                Dim others() As String = Split(retVal(3).Trim, "+")
                Dim promo() As String = Split(retVal(4).Trim, "+")
                Dim eID() As String = Split(retVal(5).Trim, "+")
                
                where = "userID = " & Session("userID") & " AND uploadDate = '" & Session("uploadDate") & "'"
                Dim recCount As Integer = .GetRecordCount("tbl_SExcelUpload", "eSID", where)
                Dim cnt As Double = 1
                Dim counter As Double = 0

                If retVal(5) <> "" Then
                    Do While cnt <= recCount
                        With conn
                            Dim retFld1(0), retVal1(0) As String
                            retFld1(0) = "stocksID"

                            where = "userID = " & Session("userID") & " AND itemID IS NULL"
                            If .checkID("tbl_Stocks", "TOP 1 stocksID, itemID, userID", where, 1, retVal1, retFld1, "stocksID", "") = "True" Then
                                updateSRecord(retVal1(0), itemID(counter), actionID(counter), others(counter), dOut(counter), promo(counter))
                            Else
                                saveSRecord(itemID(counter), actionID(counter), others(counter), promo(counter), dOut(counter))
                            End If
                        End With

                        'delete data on tbl_excelupload
                        where = "eSID = " & eID(counter)
                        .deleteRecord("tbl_SExcelUpload", where)

                        cnt += 1
                        counter += 1
                    Loop
                End If
            End With
        End If

        Session("startupTab") = "Stocks"
        Response.Redirect("~/Sales/Sales.aspx")
    End Sub

    Public Sub updateSRecord(ByVal stocksID As String, ByVal itemID As String,
                             ByVal actionID As String, ByVal others As String,
                             ByVal dOut As String, ByVal promo As String)

        With conn
            Dim fld(6), val(6), dt(6) As String

            fld(0) = "itemID"
            fld(1) = "actionID"
            fld(2) = "otherAct"
            fld(3) = "dWhen"
            fld(4) = "promo"
            fld(5) = "weekID"
            fld(6) = "userID"

            dt(0) = "N"
            dt(1) = "N"
            dt(2) = "C"
            dt(3) = "C"
            dt(4) = "C"
            dt(5) = "N"
            dt(6) = "N"

            val(0) = itemID
            val(1) = actionID
            val(2) = others
            val(3) = dOut
            val(4) = promo
            val(5) = Session("weekID")
            val(6) = Session("userID")

            where = "stocksID = " & stocksID
            .UpdateDB("tbl_Stocks", fld, val, dt, where)
        End With
    End Sub

    Public Sub saveSRecord(ByVal itemID As String, ByVal actionID As String, ByVal others As String,
                           ByVal promo As String, ByVal dOut As String)

        With conn
            Dim field, values As String

            field = "itemID, actionID, otherAct, dWhen, promo, weekID, userID"
            values = itemID & ", " _
                        & actionID & ", '" _
                        & others & "', '" _
                        & promo & "', '" _
                        & dOut & "', " _
                        & Session("weekID") & ", " _
                        & Session("userID")

            .saveInfo("tbl_Stocks", field, values)
        End With
    End Sub

    Public Sub checkSValidity()
        With conn
            Dim retFld(0), retVal(0) As String

            where = "userID = " & Session("userID") & " AND uploadDate = '" & Session("uploadDate") & "' AND upStat = 'INVALID'"
            If .checkID("tbl_SExcelUpload", "*", where, 0, retVal, retFld, "", "") = "True" Then
                Session("uStatCheck") = "Invalid"
            Else
                Session("uStatCheck") = "Valid"
            End If
        End With
    End Sub

    Public Sub LoadCompete()
        checkCValidity()
        If Session("uStatCheck") = "Invalid" Then
            lbleMsg.Text = "There are still invalid records. Please validate data first."
            Exit Sub

        Else
            'get data and transfer it to sales
            With conn
                Dim retFld(6), retVal(6) As String

                retFld(0) = "cBrandID"
                retFld(1) = "cCapacityID"
                retFld(2) = "qty"
                retFld(3) = "factors"
                retFld(4) = "dPurchased"
                retFld(5) = "weekID"
                retFld(6) = "eCID"

                where = "userID = " & Session("userID") & " AND uploadDate = '" & Session("uploadDate") & "'"
                .getRecords("tbl_CExcelUpload", "*", where, 7, retFld, retVal, "", "")

                Dim cBrand() As String = Split(retVal(0).Trim, "+")
                Dim cCap() As String = Split(retVal(1).Trim, "+")
                Dim qty() As String = Split(retVal(2).Trim, "+")
                Dim factors() As String = Split(retVal(3).Trim, "+")
                Dim dp() As String = Split(retVal(4).Trim, "+")
                Dim wk() As String = Split(retVal(5).Trim, "+")
                Dim eCID() As String = Split(retVal(6).Trim, "+")
                
                where = "userID = " & Session("userID") & " AND uploadDate = '" & Session("uploadDate") & "'"
                Dim recCount As Integer = .GetRecordCount("tbl_CExcelUpload", "eCID", where)
                Dim cnt As Double = 1
                Dim counter As Double = 0

                If retVal(6) <> "" Then
                    Do While cnt <= recCount
                        With conn
                            Dim retFld1(0), retVal1(0) As String
                            retFld1(0) = "competeID"

                            where = "userID = " & Session("userID") & " AND cBrandID IS NULL"
                            If .checkID("tbl_Competitor", "TOP 1 competeID, cBrandID, userID", where, 1, retVal1, retFld1, "competeID", "") = "True" Then
                                updateCRecord(retVal1(0), cBrand(counter), cCap(counter), qty(counter), factors(counter), dp(counter))
                            Else
                                saveCRecord(cBrand(counter), cCap(counter), qty(counter), factors(counter), dp(counter))
                            End If
                        End With

                        'delete data on tbl_excelupload
                        where = "eCID = " & eCID(counter)
                        .deleteRecord("tbl_CExcelUpload", where)

                        cnt += 1
                        counter += 1
                    Loop
                End If
            End With
        End If

        Session("startupTab") = "Compete"
        Response.Redirect("~/Sales/Sales.aspx")
    End Sub

    Public Sub checkCValidity()
        With conn
            Dim retFld(0), retVal(0) As String

            where = "userID = " & Session("userID") & " AND uploadDate = '" & Session("uploadDate") & "' AND upStat = 'INVALID'"
            If .checkID("tbl_CExcelUpload", "*", where, 0, retVal, retFld, "", "") = "True" Then
                Session("uStatCheck") = "Invalid"
            Else
                Session("uStatCheck") = "Valid"
            End If
        End With
    End Sub

    Public Sub updateCRecord(ByVal competeID As String, ByVal cBrandID As String, ByVal cCapID As String,
                           ByVal cQty As String, ByVal factors As String, ByVal dp As String)

        With conn
            Dim fld(5), val(5), dt(5) As String

            fld(0) = "cBrandID"
            fld(1) = "cCapacityID"
            fld(2) = "qty"
            fld(3) = "factor"
            fld(4) = "csDate"
            fld(5) = "weekID"

            dt(0) = "N"
            dt(1) = "N"
            dt(2) = "N"
            dt(3) = "C"
            dt(4) = "C"
            dt(5) = "N"

            val(0) = cBrandID
            val(1) = cCapID
            val(2) = cQty
            val(3) = factors
            val(4) = dp
            val(5) = Session("weekID")
            
            where = "competeID = " & competeID
            .UpdateDB("tbl_Competitor", fld, val, dt, where)
        End With
    End Sub

    Public Sub saveCRecord(ByVal cBrandID As String, ByVal cCapID As String,
                          ByVal cQty As String, ByVal factors As String, ByVal dp As String)

        With conn
            Dim field, values As String

            field = "cBrandID, cCapacityID, qty, factor, csDate, userID, weekID"
            values = cBrandID & ", " _
                        & cCapID & ", " _
                        & cQty & ", '" _
                        & Replace(factors, "'", "''") & "', '" _
                        & dp & "', " _
                        & Session("userID") & ", " _
                        & Session("weekID")

            .saveInfo("tbl_Competitor", field, values)
        End With
    End Sub


    Public Sub LoadInventory()
        checkIValidity()
        If Session("uStatCheck") = "Invalid" Then
            lbleMsg.Text = "There are still invalid records. Please validate data first."
            Exit Sub

        Else
            'get data and transfer it to sales
            With conn
                Dim retFld(6), retVal(6) As String

                retFld(0) = "weekID"
                retFld(1) = "itemID"
                retFld(2) = "qty"
                retFld(3) = "comments"
                retFld(4) = "productID"
                retFld(5) = "brandID"
                retFld(6) = "eIID"

                where = "userID = " & Session("userID") & " AND uploadDate = '" & Session("uploadDate") & "'"
                .getRecords("tbl_IExcelUpload", "*", where, 7, retFld, retVal, "", "")

                Dim wk() As String = Split(retVal(0).Trim, "+")
                Dim itemID() As String = Split(retVal(1).Trim, "+")
                Dim qty() As String = Split(retVal(2).Trim, "+")
                Dim comments() As String = Split(retVal(3).Trim, "+")
                Dim prodID() As String = Split(retVal(4).Trim, "+")
                Dim brandID() As String = Split(retVal(5).Trim, "+")
                Dim eID() As String = Split(retVal(6).Trim, "+")
                
                where = "userID = " & Session("userID") & " AND uploadDate = '" & Session("uploadDate") & "'"
                Dim recCount As Integer = .GetRecordCount("tbl_IExcelUpload", "eIID", where)
                Dim cnt As Double = 1
                Dim counter As Double = 0

                If retVal(6) <> "" Then
                    Do While cnt <= recCount
                        With conn
                            Dim retFld1(0), retVal1(0) As String
                            retFld1(0) = "inventoryID"

                            where = "userID = " & Session("userID") & " AND itemID IS NULL"
                            If .checkID("tbl_Inventory", "TOP 1 inventoryID, itemID, userID", where, 1, retVal1, retFld1, "inventoryID", "") = "True" Then
                                updateIRecord(retVal1(0), itemID(counter), qty(counter), comments(counter))
                            Else
                                saveIRecord(itemID(counter), qty(counter), comments(counter))
                            End If
                        End With

                        'delete data on tbl_excelupload
                        where = "eIID = " & eID(counter)
                        .deleteRecord("tbl_IExcelUpload", where)

                        cnt += 1
                        counter += 1
                    Loop
                End If
            End With
        End If

        Session("startupTab") = "Inventory"
        Response.Redirect("~/Sales/Sales.aspx")
    End Sub

    Public Sub updateIRecord(ByVal inventoryID As String, ByVal itemID As String, ByVal qty As String, ByVal comments As String)

        With conn
            Dim fld(3), val(3), dt(3) As String

            fld(0) = "itemID"
            fld(1) = "qty"
            fld(2) = "comments"
            fld(3) = "weekID"

            dt(0) = "N"
            dt(1) = "N"
            dt(2) = "C"
            dt(3) = "N"
            
            val(0) = itemID
            val(1) = qty
            val(2) = comments
            val(3) = Session("weekID")

            where = "inventoryID = " & inventoryID
            .UpdateDB("tbl_Inventory", fld, val, dt, where)
        End With
    End Sub

    Public Sub saveIRecord(ByVal qty As Integer, ByVal itemID As String, ByVal comments As String)

        With conn
            Dim field, values As String


            field = "itemID, qty, comments, weekID, userID"
            values = itemID & ", " _
                        & qty & ", '" _
                        & comments & "', " _
                        & Session("weekID") & ", " _
                        & Session("userID")

            .saveInfo("tbl_Inventory", field, values)
        End With
    End Sub





    Public Sub LoadSales()
        checkValidity()
        If Session("uStatCheck") = "Invalid" Then
            lbleMsg.Text = "There are still invalid records. Please validate data first."
            Exit Sub

        Else
            'get data and transfer it to sales
            With conn
                Dim retFld(13), retVal(13) As String

                retFld(0) = "fname"
                retFld(1) = "lname"
                retFld(2) = "cAdd"
                retFld(3) = "cityID"
                retFld(4) = "contact"
                retFld(5) = "productID"
                retFld(6) = "brandID"
                retFld(7) = "itemID"
                retFld(8) = "dpurchased"
                retFld(9) = "serialNo"
                retFld(10) = "invoice"
                retFld(11) = "qty"
                retFld(12) = "weekID"
                retFld(13) = "eID"

                where = "userID = " & Session("userID") & " AND uploadDate = '" & Session("uploadDate") & "'"
                .getRecords("tbl_ExcelUpload", "*", where, 14, retFld, retVal, "", "")

                Dim fn() As String = Split(retVal(0).Trim, "+")
                Dim ln() As String = Split(retVal(1).Trim, "+")
                Dim cAdd() As String = Split(retVal(2).Trim, "+")
                Dim city() As String = Split(retVal(3).Trim, "+")
                Dim contact() As String = Split(retVal(4).Trim, "+")
                Dim prodID() As String = Split(retVal(5).Trim, "+")
                Dim brandID() As String = Split(retVal(6).Trim, "+")
                Dim itemID() As String = Split(retVal(7).Trim, "+")
                Dim dp() As String = Split(retVal(8).Trim, "+")
                Dim serial() As String = Split(retVal(9).Trim, "+")
                Dim inv() As String = Split(retVal(10).Trim, "+")
                Dim qty() As String = Split(retVal(11).Trim, "+")
                Dim wk() As String = Split(retVal(12).Trim, "+")
                Dim eID() As String = Split(retVal(13).Trim, "+")

                where = "userID = " & Session("userID") & " AND uploadDate = '" & Session("uploadDate") & "'"
                Dim recCount As Integer = .GetRecordCount("tbl_ExcelUpload", "eID", where)
                Dim cnt As Double = 1
                Dim counter As Double = 0

                If retVal(13) <> "" Then
                    Do While cnt <= recCount
                        With conn
                            Dim recStatus As String = cRStat(fn(counter), ln(counter), cAdd(counter), city(counter), contact(counter), serial(counter))

                            Dim retFld1(0), retVal1(0) As String
                            retFld1(0) = "salesID"

                            where = "userID = " & Session("userID") & " AND itemID IS NULL"
                            If .checkID("tbl_Sales", "TOP 1 salesID, itemID, userID", where, 1, retVal1, retFld1, "salesID", "") = "True" Then
                                updateRecord(retVal1(0), fn(counter), ln(counter), cAdd(counter), city(counter), contact(counter), qty(counter), itemID(counter), dp(counter), serial(counter), inv(counter), recStatus)
                            Else
                                saveRecord(fn(counter), ln(counter), cAdd(counter), city(counter), contact(counter), qty(counter), itemID(counter), dp(counter), serial(counter), inv(counter), recStatus)
                            End If
                        End With

                        'delete data on tbl_excelupload
                        where = "eID = " & eID(counter)
                        .deleteRecord("tbl_ExcelUpload", where)

                        cnt += 1
                        counter += 1
                    Loop
                End If
            End With
        End If

        Session("startupTab") = "Sales"
        Response.Redirect("~/Sales/Sales.aspx")
    End Sub

    Public Sub updateRecord(ByVal salesID As String, ByVal fn As String, ByVal ln As String,
                            ByVal cAdd As String, ByVal city As String, ByVal contact As String,
                            ByVal qty As Integer, ByVal itemID As String, ByVal dp As String,
                            ByVal serial As String, ByVal inv As String, ByVal recStat As String)

        With conn
            Dim fld(12), val(12), dt(12) As String

            fld(0) = "fname"
            fld(1) = "lname"
            fld(2) = "cAdd"
            fld(3) = "contact"
            fld(4) = "qty"
            fld(5) = "dPurchased"
            fld(6) = "serial"
            fld(7) = "invoice"
            fld(8) = "weekID"
            fld(9) = "userID"
            fld(10) = "recStatusID"
            fld(11) = "cityID"
            fld(12) = "itemID"

            dt(0) = "C"
            dt(1) = "C"
            dt(2) = "C"
            dt(3) = "C"
            dt(4) = "N"
            dt(5) = "C"
            dt(6) = "C"
            dt(7) = "C"
            dt(8) = "N"
            dt(9) = "N"
            dt(10) = "N"
            dt(11) = "N"
            dt(12) = "N"

            val(0) = fn
            val(1) = ln
            val(2) = cAdd
            val(3) = contact
            val(4) = qty
            val(5) = dp
            val(6) = serial
            val(7) = inv
            val(8) = Session("weekID")
            val(9) = Session("userID")
            val(10) = recStat
            val(11) = city
            val(12) = itemID

            where = "salesID = " & salesID
            .UpdateDB("tbl_Sales", fld, val, dt, where)
        End With
    End Sub

    Public Sub saveRecord(ByVal fn As String, ByVal ln As String,
                          ByVal cAdd As String, ByVal city As Integer, ByVal contact As String,
                          ByVal qty As Integer, ByVal itemID As String, ByVal dp As String,
                          ByVal serial As String, ByVal inv As String, ByVal recStatus As String)

        With conn
            Dim field, values As String


            field = "fname, lname, cAdd, cityID, contact, qty, itemID, dPurchased, serial, invoice, weekID, userID, recStatusID"
            values = "'" & fn & "', '" _
                        & ln & "', '" _
                        & cAdd & "', " _
                        & city & ", '" _
                        & contact & "', " _
                        & qty & ", " _
                        & itemID & ", '" _
                        & dp & "', '" _
                        & serial & "', '" _
                        & inv & "', " _
                        & Session("weekID") & ", " _
                        & Session("userID") & ", " _
                        & recStatus

            .saveInfo("tbl_Sales", field, values)
        End With
    End Sub

    Public Function cRStat(ByVal fn As String, ByVal ln As String,
                           ByVal cAdd As String, ByVal cityID As String,
                           ByVal contact As String, ByVal serial As String) As String


        If fn = "" Or ln = "" Or cAdd = "" Or cityID = 0 Or contact = "" Or serial = "" Then
            cRStat = "2"

        ElseIf fn <> "" And ln <> "" And cAdd <> "" And cityID <> 0 And contact <> "" And serial <> "" Then
            cRStat = "1"
        End If
    End Function

    Public Sub checkValidity()
        With conn
            Dim retFld(0), retVal(0) As String

            where = "userID = " & Session("userID") & " AND uploadDate = '" & Session("uploadDate") & "' AND upStat = 'INVALID'"
            If .checkID("tbl_ExcelUpload", "*", where, 0, retVal, retFld, "", "") = "True" Then
                Session("uStatCheck") = "Invalid"
            Else
                Session("uStatCheck") = "Valid"
            End If
        End With
    End Sub

    Public Sub checkIValidity()
        With conn
            Dim retFld(0), retVal(0) As String

            where = "userID = " & Session("userID") & " AND uploadDate = '" & Session("uploadDate") & "' AND upStat = 'INVALID'"
            If .checkID("tbl_IExcelUpload", "*", where, 0, retVal, retFld, "", "") = "True" Then
                Session("uStatCheck") = "Invalid"
            Else
                Session("uStatCheck") = "Valid"
            End If
        End With
    End Sub

    Protected Sub grdUpload_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdUpload.SelectedIndexChanged
        System.Threading.Thread.Sleep(500)
        Session("eID") = grdUpload.DataKeys(grdUpload.SelectedIndex).Values(0).ToString()
        LoadDetails()
        panData.Visible = True
        grdUpload.Enabled = False
    End Sub

    Public Sub LoadIDetails()
        With conn
            Dim retFld(8), retVal(8) As String

            retFld(0) = "product"
            retFld(1) = "brand"
            retFld(2) = "sCode"
            retFld(3) = "qty"
            retFld(4) = "comments"
            retFld(5) = "upStat"
            retFld(6) = "productID"
            retFld(7) = "brandID"
            retFld(8) = "itemID"

            where = "eIID = " & Session("eID")
            .getValues("tbl_IExcelUpload", "*", where, 9, retFld, retVal, "", "", "")

            lblIProd.Text = retVal(0)
            lblIBrand.Text = retVal(1)
            lblISCode.Text = retVal(2)

            If retVal(3) = "" Or retVal(3) = "0" Then
                lblIQty.Text = ""
                ddlIQty.SelectedIndex = -1

            ElseIf IsNumeric(retVal(3)) = False Then
                lblIQty.Text = retVal(3)
                ddlIQty.SelectedIndex = -1

            Else
                lblIQty.Text = retVal(3)
                ddlIQty.SelectedValue = retVal(3)
            End If

            txtComments.Text = retVal(4)
            lblIStatus.Text = retVal(5)

            If retVal(6) = "0" Or retVal(6) = "" Then
                ddlIProd.SelectedIndex = -1
            Else
                ddlIProd.SelectedValue = retVal(6)

                'load brand
                where = "productID = " & retVal(6)
                conn.loadToDropDownList("tbl_Brand", ddlIBrand, False, "*", where, "brandID", "brand", "brand", "")
            End If

            If retVal(7) = "0" Or retVal(7) = "" Then
                ddlIBrand.SelectedIndex = -1
            Else
                ddlIBrand.SelectedValue = retVal(7)

                'load short code
                where = "productID = " & retVal(6) & " AND brandID = " & retVal(7)
                conn.loadToDropDownList("tbl_Items", ddlISCode, False, "*", where, "itemID", "shortCode", "shortCode", "")
            End If

            If retVal(8) = "0" Or retVal(8) = "" Then
                ddlISCode.SelectedIndex = -1
            Else
                ddlISCode.SelectedValue = retVal(8)
            End If
        End With
    End Sub

    Public Sub LoadDetails()
        With conn
            Dim retFld(17), retVal(17) As String

            retFld(0) = "fname"
            retFld(1) = "lname"
            retFld(2) = "cAdd"
            retFld(3) = "city"
            retFld(4) = "contact"
            retFld(5) = "product"
            retFld(6) = "brand"
            retFld(7) = "sCode"
            retFld(8) = "dpurchased"
            retFld(9) = "serialNo"
            retFld(10) = "invoice"
            retFld(11) = "qty"
            retFld(12) = "upStat"
            retFld(13) = "productID"
            retFld(14) = "brandID"
            retFld(15) = "itemID"
            retFld(16) = "cityID"

            where = "eID = " & Session("eID")
            .getValues("tbl_ExcelUpload", "*", where, 17, retFld, retVal, "", "", "")

            txtFname.Text = retVal(0)
            txtLname.Text = retVal(1)
            txtAdd.Text = retVal(2)
            ddlCity.SelectedItem.Text = retVal(3)
            txtContact.Text = retVal(4)

            lblProd.Text = retVal(5)
            lblBrand.Text = retVal(6)
            lblSCode.Text = retVal(7)
            lblDP.Text = retVal(8)
            txtSerial.Text = retVal(9)
            txtInvoice.Text = retVal(10)

            lblQty.Text = retVal(11)
            If retVal(11) = "0" Or retVal(11) = "" Then
                ddlQty.SelectedIndex = -1
            Else
                ddlQty.SelectedValue = retVal(11)
            End If

            lblStatus.Text = retVal(12)

            If retVal(13) = "0" Or retVal(13) = "" Then
                ddlProd.SelectedIndex = -1
            Else
                ddlProd.SelectedValue = retVal(13)

                'load brand
                where = "productID = " & retVal(13)
                conn.loadToDropDownList("tbl_Brand", ddlBrand, False, "*", where, "brandID", "brand", "brand", "")
            End If

            If retVal(14) = "0" Or retVal(14) = "" Then
                ddlBrand.SelectedIndex = -1
            Else
                ddlBrand.SelectedValue = retVal(14)

                'load short code
                where = "productID = " & retVal(13) & " AND brandID = " & retVal(14)
                conn.loadToDropDownList("tbl_Items", ddlSCode, False, "*", where, "itemID", "shortCode", "shortCode", "")
            End If

            If retVal(15) = "0" Or retVal(15) = "" Then
                ddlSCode.SelectedIndex = -1
            Else
                ddlSCode.SelectedValue = retVal(15)
            End If

            If retVal(16) = "0" Or retVal(16) = "" Then
                ddlCity.SelectedIndex = -1
            Else
                ddlCity.SelectedValue = retVal(16)
            End If
        End With
    End Sub

    Private Sub DownloadedFile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            With conn
                Dim retFld(0), retVal(0) As String
                retFld(0) = "weekCoverage"

                where = "weekID = " & Session("weekID")
                .getValues("tbl_Week", "*", where, 1, retFld, retVal, "", "", "")
                lblWeek.Text = retVal(0)


                Select Case Session("uploadType")
                    Case "Sales"
                        btnLoadFile.Text = "Load Sales Form"

                        .loadToDropDownList("tbl_Product", ddlProd, False, "*", "", "productID", "product", "", "")

                        where = "weekID = " & Session("weekID")
                        .loadToDropDownList("tbl_WDay", ddlDP, False, "*", where, "wDay", "wDay", "", "")

                        .loadToDropDownList("tbl_City", ddlCity, False, "*", "", "cityID", "city", "city", "")

                        grdUpload.Visible = True
                        grdCUpload.Visible = False
                        grdSUpload.Visible = False
                        grdIUpload.Visible = False


                    Case "Compete"
                        btnLoadFile.Text = "Load Competitors Sales"

                        .loadToDropDownList("tbl_CBrand", ddlCBrand, False, "*", "", "cBrandID", "cBrand", "cBrand", "")
                        .loadToDropDownList("tbl_CCapacity", ddlCCap, False, "*", "", "cCapacityID", "cCapacity", "cCapacity", "")

                        where = "weekID = " & Session("weekID")
                        .loadToDropDownList("tbl_WDay", ddlCDP, False, "*", where, "wDay", "wDay", "", "")

                        grdUpload.Visible = False
                        grdCUpload.Visible = True
                        grdSUpload.Visible = False
                        grdIUpload.Visible = False


                    Case "Stocks"
                        btnLoadFile.Text = "Load Stocks Run Out"

                        .loadToDropDownList("tbl_Product", ddlSProd, False, "*", "", "productID", "product", "", "")

                        where = "weekID = " & Session("weekID")
                        .loadToDropDownList("tbl_WDay", ddlSDP, False, "*", where, "wDay", "wDay", "", "")

                        .loadToDropDownList("tbl_Action", ddlAction, False, "*", "", "actionID", "actionTaken", "actionTaken", "")

                        grdUpload.Visible = False
                        grdCUpload.Visible = False
                        grdSUpload.Visible = True
                        grdIUpload.Visible = False


                    Case "Inventory"
                        btnLoadFile.Text = "Load Stocks Inventory"

                        .loadToDropDownList("tbl_Product", ddlIProd, False, "*", "", "productID", "product", "", "")

                        grdUpload.Visible = False
                        grdCUpload.Visible = False
                        grdSUpload.Visible = False
                        grdIUpload.Visible = True
                End Select
            End With
        End If
    End Sub

    Protected Sub btnModify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModify.Click
        lbleMsg.Text = ""

        If btnModify.Text = "Update" Then
            System.Threading.Thread.Sleep(500)

            'check if valid
            Dim recValid As Boolean = checkRecord()
            If recValid = True Then
                'update record
                Dim fld(16), val(16), dt(16) As String

                fld(0) = "fname"
                fld(1) = "lname"
                fld(2) = "cAdd"
                fld(3) = "city"
                fld(4) = "contact"
                fld(5) = "product"
                fld(6) = "brand"
                fld(7) = "sCode"
                fld(8) = "dpurchased"
                fld(9) = "serialNo"
                fld(10) = "invoice"
                fld(11) = "qty"
                fld(12) = "upStat"

                fld(13) = "productID"
                fld(14) = "brandID"
                fld(15) = "itemID"
                fld(16) = "cityID"

                dt(0) = "C"
                dt(1) = "C"
                dt(2) = "C"
                dt(3) = "C"
                dt(4) = "C"
                dt(5) = "C"
                dt(6) = "C"
                dt(7) = "C"
                dt(8) = "C"
                dt(9) = "C"
                dt(10) = "C"
                dt(11) = "C"
                dt(12) = "C"
                dt(13) = "N"
                dt(14) = "N"
                dt(15) = "N"
                dt(16) = "N"

                val(0) = txtFname.Text.Trim
                val(1) = txtLname.Text.Trim
                val(2) = txtAdd.Text.Trim

                If ddlCity.SelectedValue.Trim = "" Then
                    val(3) = ""
                    val(16) = "0"
                Else
                    val(3) = ddlCity.SelectedItem.Text.Trim
                    val(16) = ddlCity.SelectedValue.Trim
                End If

                val(4) = txtContact.Text.Trim

                If ddlProd.SelectedValue.Trim = "" Then
                    val(5) = ""
                    val(13) = "0"
                Else
                    val(5) = ddlProd.SelectedItem.Text.Trim
                    val(13) = ddlProd.SelectedValue.Trim
                End If

                If ddlBrand.SelectedValue.Trim = "" Then
                    val(6) = ""
                    val(14) = "0"
                Else
                    val(6) = ddlBrand.SelectedItem.Text.Trim
                    val(14) = ddlBrand.SelectedValue.Trim
                End If

                If ddlSCode.SelectedValue.Trim = "" Then
                    val(7) = ""
                    val(15) = "0"
                Else
                    val(7) = ddlSCode.SelectedItem.Text.Trim
                    val(15) = ddlSCode.SelectedValue.Trim
                End If

                val(8) = ddlDP.SelectedValue.Trim
                val(9) = txtSerial.Text.Trim
                val(10) = txtInvoice.Text.Trim
                val(11) = ddlQty.SelectedValue.Trim

                If recValid = True Then
                    val(12) = "Valid"
                Else
                    val(12) = "Invalid"
                End If

                where = "eID = " & Session("eID")
                conn.UpdateDB("tbl_ExcelUpload", fld, val, dt, where)

                emptyData()
                panData.Visible = False
                grdUpload.Enabled = True
                grdUpload.DataBind()
                grdUpload.SelectedIndex = -1
            End If
        End If
    End Sub

    Public Sub emptyData()
        txtFname.Text = ""
        txtLname.Text = ""
        txtAdd.Text = ""
        ddlCity.SelectedIndex = -1
        txtContact.Text = ""

        lblQty.Text = ""
        ddlQty.SelectedIndex = -1

        lblProd.Text = ""
        ddlProd.SelectedIndex = -1

        lblBrand.Text = ""
        ddlBrand.Items.Clear()

        lblSCode.Text = ""
        ddlSCode.Items.Clear()

        lblDP.Text = ""
        ddlDP.SelectedIndex = -1

        txtSerial.Text = ""
        txtInvoice.Text = ""

        lblStatus.Text = ""
    End Sub

    Public Sub emptyIData()
        lblIProd.Text = ""
        ddlIProd.SelectedIndex = -1

        lblIBrand.Text = ""
        ddlIBrand.Items.Clear()

        lblISCode.Text = ""
        ddlISCode.Items.Clear()

        lblIQty.Text = ""
        ddlIQty.SelectedIndex = -1

        txtComments.Text = ""
        lblIStatus.Text = ""
    End Sub

    Public Sub emptySData()
        lblSProd.Text = ""
        ddlSProd.SelectedIndex = -1

        lblSBrand.Text = ""
        ddlSBrand.Items.Clear()

        lblSSCode.Text = ""
        ddlSSCode.Items.Clear()

        lblSDP.Text = ""
        ddlSDP.SelectedIndex = -1

        lblAction.Text = ""
        ddlAction.SelectedIndex = -1
        txtOthers.Text = ""

        txtPromo.Text = ""
        lblSStatus.Text = ""
    End Sub

    Public Function checkSRecord() As String
        checkSRecord = True
        lbleMsg.Text = ""

        If ddlSProd.SelectedValue.Trim = "" Then
            checkSRecord = False
            lbleMsg.Text = "Product is required."
            Exit Function
        End If

        If ddlSBrand.SelectedValue.Trim = "" Then
            checkSRecord = False
            lbleMsg.Text = "Brand is required."
            Exit Function
        End If

        If ddlSSCode.SelectedValue.Trim = "" Then
            checkSRecord = False
            lbleMsg.Text = "Short Code is required."
            Exit Function
        End If

        If ddlSDP.SelectedValue.Trim = "" Then
            checkSRecord = False
            lbleMsg.Text = "Date Runs Out is required."
            Exit Function
        End If

        If ddlAction.SelectedValue.Trim = "" Then
            checkSRecord = False
            lbleMsg.Text = "Action Taken is required."
            Exit Function

        ElseIf ddlAction.SelectedItem.Text.Trim = "Others" And txtOthers.Text.Trim = "" Then
            checkSRecord = False
            lbleMsg.Text = "Please specify the action taken."
            Exit Function
        End If

        If txtPromo.Text.Trim = "" Then
            checkSRecord = False
            lbleMsg.Text = "Competitor Promo Activities is required."
            Exit Function
        End If
    End Function

    Public Function checkRecord() As String
        checkRecord = True
        lbleMsg.Text = ""

        If txtContact.Text.Trim <> "" Then
            If Len(txtContact.Text.Trim) < 7 Then
                checkRecord = False
                lbleMsg.Text = "Please enter a valid contact no."
                Exit Function
            End If
        End If

        If ddlQty.SelectedValue.Trim = "" Or ddlQty.SelectedValue.Trim = "Select the Quantity" Then
            checkRecord = False
            lbleMsg.Text = "Qty is required."
            Exit Function
        End If

        If ddlProd.SelectedValue.Trim = "" Then
            checkRecord = False
            lbleMsg.Text = "Product is required."
            Exit Function
        End If

        If ddlBrand.SelectedValue.Trim = "" Then
            checkRecord = False
            lbleMsg.Text = "Brand is required."
            Exit Function
        End If

        If ddlSCode.SelectedValue.Trim = "" Then
            checkRecord = False
            lbleMsg.Text = "Short Code is required."
            Exit Function
        End If

        If ddlDP.SelectedValue.Trim = "" Then
            checkRecord = False
            lbleMsg.Text = "Date Purchased is required."
            Exit Function
        End If

        If txtInvoice.Text.Trim = "" Then
            checkRecord = False
            lbleMsg.Text = "Invoice No is required."
            Exit Function

            'Else
            '    'check if unique
            '    With conn
            '        Dim retFld(0), retVal(0) As String

            '        'check if unique in tbl_sales
            '        where = "invoice = '" & txtInvoice.Text.Trim & "' AND dPurchased <> '" & ddlDP.SelectedValue.Trim & "'"
            '        Dim checkTblSales As String = .checkID("tbl_Sales", "*", where, 0, retVal, retFld, "", "")

            '        'check if unique in tbl_ExcelUpload
            '        where = "invoice = '" & txtInvoice.Text.Trim & "' AND eID <> " & Session("eID") & " AND dPurchased <> '" & ddlDP.SelectedValue.Trim & "'"
            '        Dim checkTblExcelUpload As String = .checkID("tbl_ExcelUpload", "*", where, 0, retVal, retFld, "", "")

            '        'check if unique in tbl_SalesSub
            '        where = "invoice = '" & txtInvoice.Text.Trim & "' AND dPurchased <> '" & ddlDP.SelectedValue.Trim & "'"
            '        Dim checkTblSalesSub As String = .checkID("tbl_SalesSub", "*", where, 0, retVal, retFld, "", "")

            '        If checkTblSales = "True" Or checkTblExcelUpload = "True" Or checkTblSalesSub = "True" Then
            '            checkRecord = False
            '            lbleMsg.Text = "Invoice No has a duplicate. Sales must be entered only once"
            '            Exit Function
            '        End If
            '    End With
        End If
    End Function

    Public Function checkIRecord() As String
        checkIRecord = True
        lbleMsg.Text = ""

        If ddlIProd.SelectedValue.Trim = "" Then
            checkIRecord = False
            lbleMsg.Text = "Product is required."
            Exit Function
        End If

        If ddlIBrand.SelectedValue.Trim = "" Then
            checkIRecord = False
            lbleMsg.Text = "Brand is required."
            Exit Function
        End If

        If ddlISCode.SelectedValue.Trim = "" Then
            checkIRecord = False
            lbleMsg.Text = "Short Code is required."
            Exit Function
        End If

        If ddlIQty.SelectedValue.Trim = "" Or ddlIQty.SelectedValue.Trim = "Select the Quantity" Then
            checkIRecord = False
            lbleMsg.Text = "Qty is required."
            Exit Function
        End If
    End Function

    Public Sub enablePage()
        txtFname.ReadOnly = False
        txtLname.ReadOnly = False
        txtAdd.ReadOnly = False
        ddlCity.Enabled = True
        ddlQty.Enabled = True
        ddlProd.Enabled = True
        ddlBrand.Enabled = True
        ddlSCode.Enabled = True
        ddlDP.Enabled = True
        txtSerial.ReadOnly = False
        txtInvoice.ReadOnly = False
    End Sub

    Public Sub disablePage()
        txtFname.ReadOnly = True
        txtLname.ReadOnly = True
        txtAdd.ReadOnly = True

        ddlCity.Enabled = False
        ddlQty.Enabled = False
        ddlProd.Enabled = False
        ddlBrand.Enabled = False
        ddlSCode.Enabled = False
        ddlDP.Enabled = False

        txtSerial.ReadOnly = True
        txtInvoice.ReadOnly = True
    End Sub

    Protected Sub ddlProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlProd.SelectedIndexChanged
        System.Threading.Thread.Sleep(500)
        If ddlProd.SelectedValue.Trim = "" Then
            ddlBrand.Items.Clear()
            ddlSCode.Items.Clear()

        Else
            ddlBrand.Items.Clear()
            ddlSCode.Items.Clear()

            where = "productID = " & ddlProd.SelectedValue.Trim
            conn.loadToDropDownList("tbl_Brand", ddlBrand, False, "*", where, "brandID", "brand", "brand", "")
        End If
    End Sub

    Protected Sub ddlBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlBrand.SelectedIndexChanged
        System.Threading.Thread.Sleep(500)
        If ddlBrand.SelectedValue.Trim = "" Then
            ddlSCode.Items.Clear()

        Else
            ddlSCode.Items.Clear()

            where = "productID = " & ddlProd.SelectedValue.Trim & " AND brandID = " & ddlBrand.SelectedValue.Trim
            conn.loadToDropDownList("tbl_Items", ddlSCode, False, "*", where, "itemID", "shortCode", "shortCode", "")
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        emptyData()

        panData.Visible = False
        grdUpload.Enabled = True
        grdUpload.SelectedIndex = -1
    End Sub


    Protected Sub btnCModify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCModify.Click
        lbleMsg.Text = ""

        If btnCModify.Text = "Update" Then
            System.Threading.Thread.Sleep(500)

            'check if valid
            Dim recValid As Boolean = checkCRecord()
            If recValid = True Then
                'update record
                Dim fld(7), val(7), dt(7) As String

                fld(0) = "cBrand"
                fld(1) = "cCapacity"
                fld(2) = "qty"
                fld(3) = "factors"
                fld(4) = "dPurchased"
                fld(5) = "upStat"

                fld(6) = "cBrandID"
                fld(7) = "cCapacityID"

                dt(0) = "C"
                dt(1) = "C"
                dt(2) = "C"
                dt(3) = "C"
                dt(4) = "C"
                dt(5) = "C"

                dt(6) = "C"
                dt(7) = "C"

                If ddlCBrand.SelectedValue.Trim = "" Then
                    val(0) = ""
                    val(6) = "0"
                Else
                    val(0) = ddlCBrand.SelectedItem.Text.Trim
                    val(6) = ddlCBrand.SelectedValue.Trim
                End If

                If ddlCCap.SelectedValue.Trim = "" Then
                    val(1) = ""
                    val(7) = "0"
                Else
                    val(1) = ddlCCap.SelectedItem.Text.Trim
                    val(7) = ddlCCap.SelectedValue.Trim
                End If

                If ddlCQty.SelectedValue.Trim = "" Then
                    val(2) = "0"
                Else
                    val(2) = ddlCCap.SelectedValue.Trim
                End If

                val(3) = txtFactors.Text.Trim

                If ddlCDP.SelectedValue.Trim = "" Then
                    val(4) = "0"
                Else
                    val(4) = ddlCDP.SelectedValue.Trim
                End If

                If recValid = True Then
                    val(5) = "Valid"
                Else
                    val(5) = "Invalid"
                End If

                where = "eCID = " & Session("eID")
                conn.UpdateDB("tbl_CExcelUpload", fld, val, dt, where)

                panCData.Visible = False
                grdCUpload.Enabled = True
                grdCUpload.DataBind()
                grdCUpload.SelectedIndex = -1
            End If
        End If
    End Sub

    Protected Sub btnCCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCCancel.Click
        ddlCBrand.SelectedIndex = -1
        ddlCCap.SelectedIndex = -1
        ddlCQty.SelectedIndex = -1
        txtFactors.Text = ""
        ddlCDP.SelectedIndex = -1
        lblCStatus.Text = ""

        panCData.Visible = False
        grdCUpload.Enabled = True
        grdCUpload.SelectedIndex = -1
    End Sub

    Protected Sub grdCUpload_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdCUpload.SelectedIndexChanged
        System.Threading.Thread.Sleep(500)
        Session("eID") = grdCUpload.DataKeys(grdCUpload.SelectedIndex).Values(0).ToString()
        LoadCDetails()
        panCData.Visible = True
        grdCUpload.Enabled = False
    End Sub

    Public Function checkCRecord() As String
        checkCRecord = True
        lbleMsg.Text = ""

        If ddlCBrand.SelectedValue.Trim = "" Then
            checkCRecord = False
            lbleMsg.Text = "Brand is required."
            Exit Function
        End If

        If ddlCCap.SelectedValue.Trim = "" Then
            checkCRecord = False
            lbleMsg.Text = "Capacity is required."
            Exit Function
        End If

        If ddlCQty.SelectedValue.Trim = "" Or ddlCQty.SelectedValue.Trim = "Select the Quantity" Then
            checkCRecord = False
            lbleMsg.Text = "Quantity is required."
            Exit Function
        End If

        If ddlCDP.SelectedValue.Trim = "" Then
            checkCRecord = False
            lbleMsg.Text = "Date Purchased is required."
            Exit Function
        End If

        If txtFactors.Text.Trim = "" Then
            checkCRecord = False
            lbleMsg.Text = "Factors Affecting Sell Out is required."
            Exit Function
        End If
    End Function

    Public Sub LoadCDetails()
        With conn
            Dim retFld(7), retVal(7) As String

            retFld(0) = "cBrand"
            retFld(1) = "cCapacity"
            retFld(2) = "qty"
            retFld(3) = "factors"
            retFld(4) = "dPurchased"
            retFld(5) = "upStat"

            retFld(6) = "cBrandID"
            retFld(7) = "cCapacityID"

            where = "eCID = " & Session("eID")
            .getValues("tbl_CExcelUpload", "*", where, 8, retFld, retVal, "", "", "")

            lblCBrand.Text = retVal(0)
            If retVal(6) = "0" Or retVal(6) = "" Then
                ddlCBrand.SelectedIndex = -1
            Else
                ddlCBrand.SelectedValue = retVal(6)
            End If

            lblCCap.Text = retVal(1)
            If retVal(7) = "0" Or retVal(7) = "" Then
                ddlCCap.SelectedIndex = -1
            Else
                ddlCCap.SelectedValue = retVal(7)
            End If

            lblQty.Text = retVal(2)
            If retVal(2) = "0" Or retVal(2) = "" Then
                ddlQty.SelectedIndex = -1
            Else
                ddlQty.SelectedValue = retVal(2)
            End If

            txtFactors.Text = retVal(3)

            lblCDP.Text = retVal(4)
            If retVal(4) = "" Then
                ddlCDP.SelectedIndex = -1

            Else
                If IsDate(retVal(4)) = False Then
                    ddlCDP.SelectedIndex = -1
                Else
                    ddlCDP.Items.FindByText(retVal(4))
                End If
            End If

            lblCStatus.Text = retVal(5)
        End With
    End Sub

    Protected Sub grdSUpload_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles grdSUpload.SelectedIndexChanged
        System.Threading.Thread.Sleep(500)
        Session("eID") = grdSUpload.DataKeys(grdSUpload.SelectedIndex).Values(0).ToString()
        LoadSDetails()
        panSData.Visible = True
        grdSUpload.Enabled = False
    End Sub

    Public Sub LoadSDetails()
        With conn
            Dim retFld(11), retVal(11) As String

            retFld(0) = "product"
            retFld(1) = "brand"
            retFld(2) = "sCode"
            retFld(3) = "dOut"
            retFld(4) = "actionTaken"
            retFld(5) = "others"
            retFld(6) = "promo"
            retFld(7) = "upStat"
            retFld(8) = "productID"
            retFld(9) = "brandID"
            retFld(10) = "itemID"
            retFld(11) = "actionID"
            
            where = "eSID = " & Session("eID")
            .getValues("tbl_SExcelUpload", "*", where, 12, retFld, retVal, "", "", "")

            lblSProd.Text = retVal(0)
            lblSBrand.Text = retVal(1)
            lblSSCode.Text = retVal(2)

            lblSDP.Text = retVal(3)
            ddlSDP.Items.FindByText(retVal(3))

            If retVal(5) = "" Then
                lblAction.Text = retVal(4)
                txtOthers.Text = ""
                txtOthers.Visible = False
            Else
                lblAction.Text = retVal(4) & " - " & retVal(5)
                txtOthers.Text = retVal(5)
                txtOthers.Visible = True
            End If

            txtPromo.Text = retVal(6)
            lblSStatus.Text = retVal(7)

            If retVal(8) = "0" Or retVal(8) = "" Then
                ddlSProd.SelectedIndex = -1
            Else
                ddlSProd.SelectedValue = retVal(8)

                'load brand
                where = "productID = " & retVal(8)
                conn.loadToDropDownList("tbl_Brand", ddlSBrand, False, "*", where, "brandID", "brand", "brand", "")
            End If

            If retVal(9) = "0" Or retVal(9) = "" Then
                ddlSBrand.SelectedIndex = -1
            Else
                ddlSBrand.SelectedValue = retVal(9)

                'load short code
                where = "productID = " & retVal(8) & " AND brandID = " & retVal(9)
                conn.loadToDropDownList("tbl_Items", ddlSSCode, False, "*", where, "itemID", "shortCode", "shortCode", "")
            End If

            If retVal(10) = "0" Or retVal(10) = "" Then
                ddlSSCode.SelectedIndex = -1
            Else
                ddlSSCode.SelectedValue = retVal(10)
            End If

            If retVal(11) = "0" Or retVal(11) = "" Then
                ddlAction.SelectedIndex = -1
            Else
                ddlAction.SelectedValue = retVal(11)
            End If
        End With
    End Sub

    

    Protected Sub ddlAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlAction.SelectedIndexChanged
        If ddlAction.SelectedValue.Trim = "" Then
            txtOthers.Visible = False

        ElseIf ddlAction.SelectedItem.Text.Trim = "Others" Then
            txtOthers.Visible = True

        Else
            txtOthers.Visible = False
        End If
    End Sub

    Public Sub checkSession()
        mstr = Page.Master
        Dim lblUserID As Label = mstr.FindControl("lblUserID")

        If Session("userID") Is Nothing Then
            Session.Clear()
            Response.Redirect("~/Default.aspx")
        End If
    End Sub

    Protected Sub btnSModify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSModify.Click
        checksession()
        lbleMsg.Text = ""

        If btnSModify.Text = "Update" Then
            System.Threading.Thread.Sleep(500)

            'check if valid
            Dim recValid As Boolean = checkSRecord()
            If recValid = True Then
                'update record
                Dim fld(11), val(11), dt(11) As String

                fld(0) = "product"
                fld(1) = "brand"
                fld(2) = "sCode"
                fld(3) = "dOut"
                fld(4) = "actionTaken"
                fld(5) = "others"
                fld(6) = "promo"
                fld(7) = "upStat"

                fld(8) = "productID"
                fld(9) = "brandID"
                fld(10) = "itemID"
                fld(11) = "actionID"

                dt(0) = "C"
                dt(1) = "C"
                dt(2) = "C"
                dt(3) = "C"
                dt(4) = "C"
                dt(5) = "C"
                dt(6) = "C"
                dt(7) = "C"
                dt(8) = "N"
                dt(9) = "N"
                dt(10) = "N"
                dt(11) = "N"

                If ddlSProd.SelectedValue.Trim = "" Then
                    val(0) = ""
                    val(8) = "0"
                Else
                    val(0) = ddlSProd.SelectedItem.Text.Trim
                    val(8) = ddlSProd.SelectedValue.Trim
                End If

                If ddlSBrand.SelectedValue.Trim = "" Then
                    val(1) = ""
                    val(9) = "0"
                Else
                    val(1) = ddlSBrand.SelectedItem.Text.Trim
                    val(9) = ddlSBrand.SelectedValue.Trim
                End If

                If ddlSSCode.SelectedValue.Trim = "" Then
                    val(2) = ""
                    val(10) = "0"
                Else
                    val(2) = ddlSSCode.SelectedItem.Text.Trim
                    val(10) = ddlSSCode.SelectedValue.Trim
                End If

                val(3) = ddlSDP.SelectedValue.Trim

                If ddlAction.SelectedValue.Trim = "" Then
                    val(4) = ""
                    val(5) = ""
                    val(11) = "0"

                ElseIf ddlAction.SelectedItem.Text.Trim = "Others" Then
                    val(4) = ddlAction.SelectedItem.Text.Trim
                    val(5) = txtOthers.Text.Trim
                    val(11) = ddlAction.SelectedValue.Trim

                Else
                    val(4) = ddlAction.SelectedItem.Text.Trim
                    val(5) = ""
                    val(11) = ddlAction.SelectedValue.Trim
                End If

                val(6) = txtPromo.Text.Trim

                If recValid = True Then
                    val(7) = "Valid"
                Else
                    val(7) = "Invalid"
                End If

                where = "eSID = " & Session("eID")
                conn.UpdateDB("tbl_SExcelUpload", fld, val, dt, where)

                emptyData()
                panSData.Visible = False
                grdSUpload.Enabled = True
                grdSUpload.DataBind()
                grdSUpload.SelectedIndex = -1
            End If
        End If
    End Sub

    Protected Sub btnSCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSCancel.Click
        emptySData()

        panSData.Visible = False
        grdSUpload.Enabled = True
        grdSUpload.SelectedIndex = -1
    End Sub

    Private Sub grdIUpload_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdIUpload.SelectedIndexChanged
        System.Threading.Thread.Sleep(500)
        Session("eID") = grdIUpload.DataKeys(grdIUpload.SelectedIndex).Values(0).ToString()
        LoadIDetails()
        panIData.Visible = True
        grdIUpload.Enabled = False
    End Sub

    Protected Sub btnIModify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnIModify.Click
        lbleMsg.Text = ""

        If btnIModify.Text = "Update" Then
            System.Threading.Thread.Sleep(500)

            'check if valid
            Dim recValid As Boolean = checkIRecord()
            If recValid = True Then
                'update record
                Dim fld(8), val(8), dt(8) As String

                fld(0) = "product"
                fld(1) = "brand"
                fld(2) = "sCode"
                fld(3) = "qty"
                fld(4) = "comments"
                fld(5) = "upStat"
                fld(6) = "productID"
                fld(7) = "brandID"
                fld(8) = "itemID"

                dt(0) = "C"
                dt(1) = "C"
                dt(2) = "C"
                dt(3) = "N"
                dt(4) = "C"
                dt(5) = "C"
                dt(6) = "N"
                dt(7) = "N"
                dt(8) = "N"

                If ddlIProd.SelectedValue.Trim = "" Then
                    val(0) = ""
                    val(6) = "0"
                Else
                    val(0) = ddlIProd.SelectedItem.Text.Trim
                    val(6) = ddlIProd.SelectedValue.Trim
                End If

                If ddlIBrand.SelectedValue.Trim = "" Then
                    val(1) = ""
                    val(7) = "0"
                Else
                    val(1) = ddlIBrand.SelectedItem.Text.Trim
                    val(7) = ddlIBrand.SelectedValue.Trim
                End If

                If ddlISCode.SelectedValue.Trim = "" Then
                    val(2) = ""
                    val(8) = "0"
                Else
                    val(2) = ddlISCode.SelectedItem.Text.Trim
                    val(8) = ddlISCode.SelectedValue.Trim
                End If

                If ddlIQty.SelectedValue.Trim = "" Then
                    val(3) = "0"
                Else
                    val(3) = ddlIQty.SelectedValue.Trim
                End If

                val(4) = txtComments.Text.Trim

                If recValid = True Then
                    val(5) = "Valid"
                Else
                    val(5) = "Invalid"
                End If

                where = "eIID = " & Session("eID")
                conn.UpdateDB("tbl_IExcelUpload", fld, val, dt, where)

                emptyIData()
                panIData.Visible = False
                grdIUpload.Enabled = True
                grdIUpload.DataBind()
                grdIUpload.SelectedIndex = -1
            End If
        End If
    End Sub

    Protected Sub btnICancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnICancel.Click
        emptyIData()

        panIData.Visible = False
        grdIUpload.Enabled = True
        grdIUpload.SelectedIndex = -1
    End Sub

    Protected Sub ddlSProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSProd.SelectedIndexChanged
        System.Threading.Thread.Sleep(500)
        If ddlSProd.SelectedValue.Trim = "" Then
            ddlSBrand.Items.Clear()
            ddlSSCode.Items.Clear()

        Else
            ddlSBrand.Items.Clear()
            ddlSSCode.Items.Clear()

            where = "productID = " & ddlSProd.SelectedValue.Trim
            conn.loadToDropDownList("tbl_Brand", ddlSBrand, False, "*", where, "brandID", "brand", "brand", "")
        End If
    End Sub

    Protected Sub ddlIProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlIProd.SelectedIndexChanged
        System.Threading.Thread.Sleep(500)
        If ddlIProd.SelectedValue.Trim = "" Then
            ddlIBrand.Items.Clear()
            ddlISCode.Items.Clear()

        Else
            ddlIBrand.Items.Clear()
            ddlISCode.Items.Clear()

            where = "productID = " & ddlIProd.SelectedValue.Trim
            conn.loadToDropDownList("tbl_Brand", ddlIBrand, False, "*", where, "brandID", "brand", "brand", "")
        End If
    End Sub

    Protected Sub ddlSBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlSBrand.SelectedIndexChanged
        System.Threading.Thread.Sleep(500)
        If ddlSBrand.SelectedValue.Trim = "" Then
            ddlSSCode.Items.Clear()

        Else
            ddlSSCode.Items.Clear()

            where = "productID = " & ddlSProd.SelectedValue.Trim & " AND brandID = " & ddlSBrand.SelectedValue.Trim
            conn.loadToDropDownList("tbl_Items", ddlSSCode, False, "*", where, "itemID", "shortCode", "shortCode", "")
        End If
    End Sub

    Protected Sub ddlIBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlIBrand.SelectedIndexChanged
        System.Threading.Thread.Sleep(500)
        If ddlIBrand.SelectedValue.Trim = "" Then
            ddlISCode.Items.Clear()

        Else
            ddlISCode.Items.Clear()

            where = "productID = " & ddlIProd.SelectedValue.Trim & " AND brandID = " & ddlIBrand.SelectedValue.Trim
            conn.loadToDropDownList("tbl_Items", ddlISCode, False, "*", where, "itemID", "shortCode", "shortCode", "")
        End If
    End Sub
End Class