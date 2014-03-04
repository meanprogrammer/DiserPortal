Public Class Sales
    Inherits System.Web.UI.Page

    Public conn As New clsConn
    Public qry, selFld, where, field, values As String
    Public cnt, counter As Integer
    Public mstr As New MasterPage
    Public bgEColor = Drawing.Color.Gold
    Public bgVColor = Drawing.Color.White
    Public formatToSave As String = "d/M/yyyy"
    Public formatToShow As String = "MMM dd, yyyy"

    Protected Sub imbASave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        checkSession()
        lbleMsg.Text = ""

        With sender.namingcontainer
            Dim imbSave As ImageButton = sender
            Dim txtFname As TextBox = .FindControl("txtAFName")
            Dim txtLname As TextBox = .FindControl("txtALName")
            Dim txtAdd As TextBox = .FindControl("txtAAdd")
            Dim ddlCity As DropDownList = .FindControl("ddlACity")
            Dim txtContact As TextBox = .FindControl("txtAContact")
            Dim ddlQty As TextBox = .FindControl("ddlAQty")
            Dim ddlProd As DropDownList = .FindControl("ddlAProd")
            Dim ddlBrand As DropDownList = .FindControl("ddlABrand")
            Dim ddlSCode As DropDownList = .FindControl("ddlaSCode")
            'Dim ddlCap As DropDownList = .FindControl("ddlACap")
            'Dim ddlVariant As DropDownList = .FindControl("ddlAVariant")
            Dim ddlDP As DropDownList = .FindControl("ddlADP")
			Dim txtSerial As TextBox = .FindControl("txtASerial")
			Dim txtInvoice As TextBox = .FindControl("txtAInvoice")
            Dim lblStatus As Label = .findcontrol("lblaStatus")

            If checkRequiredFld(ddlProd, ddlBrand, ddlSCode, txtInvoice, ddlDP, ddlQty, txtContact) = False Then
                Exit Sub

            Else
				System.Threading.Thread.Sleep(500)

                'check if complete
                Dim stat As Boolean = checkSalesIfComplete(txtFname, txtLname, txtAdd, ddlCity, txtContact, txtSerial)

                If stat = False Then
                    lbleMsg.Text = "Data is incomplete. Do you still want to save it?"
                    imbYes.Visible = True
                    imbNo.Visible = True
                    Session("salesAct") = "header"
                    Exit Sub
                End If

                saveSales(txtFname, txtLname, txtAdd, ddlCity, txtContact, ddlQty, ddlSCode, ddlDP, txtSerial, txtInvoice, stat)
            End If
        End With
    End Sub

    Public Sub saveSales(ByVal txtFName As TextBox, ByVal txtLName As TextBox, _
                         ByVal txtAdd As TextBox, ByVal ddlCity As DropDownList, _
                         ByVal txtContact As TextBox, ByVal ddlQty As TextBox, _
                         ByVal ddlSCode As DropDownList, _
                         ByVal ddlDP As DropDownList, ByVal txtSerial As TextBox, ByVal txtInvoice As TextBox, ByVal stat As Boolean)

        With conn
            Dim retFld(1), retVal(1) As String
            retFld(0) = "salesID"
            retFld(1) = "itemID"

            where = "userID = " & Session("userID")
            .getRecords("tbl_Sales", "*", where, 2, retFld, retVal, "salesID", "")

            Dim num() As String = Split(retVal(0), "+")
            Dim item() As String = Split(retVal(1), "+")
            Dim saveStat As Boolean = False
            cnt = 1
            counter = 0

            If retVal(0) = "" Then
                saveRecord(txtFName, txtLName, txtAdd, ddlCity, txtContact, ddlQty, ddlSCode, ddlDP, txtSerial, txtInvoice, stat)

            Else
                Do While cnt <= UBound(num) + 1
                    If item(counter) = "" Then
                        updateRecord(num(counter), txtFName, txtLName, txtAdd, ddlCity, txtContact, ddlQty, ddlSCode, ddlDP, txtSerial, txtInvoice, stat)
                        saveStat = True

                        'where = "userID = " & Session("userID")
                        'conn.LoadToGrid("vw_Sales", grdSales, "*", where, "salesID", "")
						grdSales.DataBind()
						Exit Sub
                    End If
                    cnt += 1
                    counter += 1
                Loop

                If saveStat = False Then
                    saveRecord(txtFName, txtLName, txtAdd, ddlCity, txtContact, ddlQty, ddlSCode, ddlDP, txtSerial, txtInvoice, stat)

                    'where = "userID = " & Session("userID")
                    'conn.LoadToGrid("vw_Sales", grdSales, "*", where, "salesID", "")
                    grdSales.DataBind()
                End If
            End If
        End With
    End Sub

    Public Function checkSalesIfComplete(ByVal txtFName As TextBox, ByVal txtLName As TextBox, _
                                         ByVal txtAdd As TextBox, ByVal ddlCity As DropDownList, _
                                         ByVal txtContact As TextBox, ByVal txtSerial As TextBox) As Boolean

        checkSalesIfComplete = True

        If txtFName.Text.Trim = "" Then
            txtFName.BackColor = bgEColor
            checkSalesIfComplete = False
        Else
            txtFName.BackColor = bgVColor
        End If

        If txtLName.Text.Trim.Trim = "" Then
            txtLName.BackColor = bgEColor
            checkSalesIfComplete = False
        Else
            txtLName.BackColor = bgVColor
        End If

        If txtAdd.Text.Trim = "" Then
            txtAdd.BackColor = bgEColor
            checkSalesIfComplete = False
        Else
            txtAdd.BackColor = bgVColor
        End If

        If ddlCity.SelectedValue.Trim = "" Then
            ddlCity.BackColor = bgEColor
            checkSalesIfComplete = False
        Else
            ddlCity.BackColor = bgVColor
        End If

        If txtContact.Text.Trim = "" Then
            txtContact.BackColor = bgEColor
            checkSalesIfComplete = False
        Else
            txtContact.BackColor = bgVColor
        End If

        If txtSerial.Text.Trim = "" Then
            txtSerial.BackColor = bgEColor
            checkSalesIfComplete = False
        Else
            txtSerial.BackColor = bgVColor
        End If

        Return checkSalesIfComplete
    End Function

    Public Sub updateRecord(ByVal recNo As String, ByVal txtFName As TextBox, ByVal txtLName As TextBox, _
                            ByVal txtAdd As TextBox, ByVal ddlCity As DropDownList, _
                            ByVal txtContact As TextBox, ByVal ddlQty As TextBox, _
                            ByVal ddlSCode As DropDownList, _
                            ByVal ddlDP As DropDownList, ByVal txtSerial As TextBox, ByVal txtInvoice As TextBox, ByVal stat As Boolean)

        With conn
            Dim fld(12), val(12), dt(12) As String

            fld(0) = "fname"
            fld(1) = "cAdd"
            fld(2) = "qty"
            fld(3) = "itemID"
            fld(4) = "dpurchased"
            fld(5) = "serial"
            fld(6) = "invoice"
            fld(7) = "contact"
            fld(8) = "userID"
            fld(9) = "weekID"
            fld(10) = "recStatusID"
            fld(11) = "lname"
            fld(12) = "cityID"

            dt(0) = "C"
            dt(1) = "C"
            dt(2) = "N"
            dt(3) = "N"
            dt(4) = "C"
            dt(5) = "C"
            dt(6) = "C"
            dt(7) = "C"
            dt(8) = "N"
            dt(9) = "N"
            dt(10) = "N"
            dt(11) = "C"
            dt(12) = "N"

            val(0) = Replace(txtFName.Text.Trim, "'", "''")
            val(1) = Replace(txtAdd.Text.Trim, "'", "''")

            If ddlQty.Text.Trim = "" Or IsNumeric(ddlQty.Text.Trim) = False Then
                val(2) = "0"
            Else
                val(2) = ddlQty.Text.Trim
            End If

            'If ddlProd.SelectedValue.Trim = "" Then
            '    val(3) = "0"
            'Else
            '    val(3) = ddlProd.SelectedValue.Trim
            'End If

            'If ddlBrand.SelectedValue.Trim = "" Then
            '    val(4) = "0"
            'Else
            '    val(4) = ddlBrand.SelectedValue.Trim
            'End If

            If ddlSCode.SelectedValue.Trim = "" Then
                val(3) = "0"
            Else
                val(3) = ddlSCode.SelectedValue.Trim
            End If

            'If ddlCap.SelectedValue.Trim = "" Then
            '    val(6) = "0"
            'Else
            '    val(6) = ddlCap.SelectedValue.Trim
            'End If

            'If ddlVariant.SelectedValue.Trim = "" Then
            '    val(7) = "0"
            'Else
            '    val(7) = ddlVariant.SelectedValue.Trim
            'End If

            If ddlDP.SelectedValue.Trim = "" Then
                val(4) = ""
            Else
                If IsDate(ddlDP.SelectedValue.Trim) = False Then
                    val(4) = ""
                Else
                    val(4) = ddlDP.SelectedValue.Trim
                End If
            End If

			val(5) = Replace(Replace(Replace(Replace(Replace(Replace(txtSerial.Text.Trim, "'", "''"), " ", ""), ",", ", "), "/", ", "), ".", ", "), ", ", "<br>")
            val(6) = Replace(txtInvoice.Text.Trim, "'", "''")
            val(7) = Replace(txtContact.Text.Trim, "'", "''")
            val(8) = Session("userID")
            val(9) = ddlWeek.SelectedValue.Trim

            If stat = True Then
                val(10) = "1"
            Else
                val(10) = "2"
            End If

            val(11) = Replace(txtLName.Text.Trim, "'", "''")

            If ddlCity.SelectedValue.Trim = "" Then
                val(12) = "0"
            Else
                val(12) = ddlCity.SelectedValue.Trim
            End If

            where = "salesID = " & recNo
            .UpdateDB("tbl_Sales", fld, val, dt, where)
        End With
    End Sub

    Public Function getStatus(ByVal txtCust As TextBox, ByVal txtAdd As TextBox, ByVal ddlQty As TextBox, _
                            ByVal ddlDP As DropDownList, ByVal txtSerial As TextBox, ByVal txtContact As TextBox) As Boolean

        Dim stat As Boolean = True

        If txtCust.Text.Trim = "" Then
            stat = False
        End If

        If txtAdd.Text.Trim = "" Then
            stat = False
        End If

        If txtContact.Text.Trim = "" Then
            stat = False
        End If

        If txtSerial.Text.Trim = "" Then
            stat = False
        End If

        If ddlQty.Text.Trim = "" Or IsNumeric(ddlQty.Text.Trim) = False Then
            stat = False
        End If

        If ddlDP.SelectedValue.Trim = "" Then
            stat = False
        End If

        Return stat
    End Function

    Public Sub saveRecord(ByVal txtFName As TextBox, ByVal txtLName As TextBox, _
                            ByVal txtAdd As TextBox, ByVal ddlCity As DropDownList, _
                            ByVal txtContact As TextBox, ByVal ddlQty As TextBox, _
                            ByVal ddlSCode As DropDownList, _
                            ByVal ddlDP As DropDownList, ByVal txtSerial As TextBox, ByVal txtInvoice As TextBox, ByVal stat As Boolean)

        With conn
            field = "fname, lname, cAdd, cityID, qty, itemID, " _
                        & "dpurchased, serial, invoice, contact, userID, weekID, recStatusID"

            values = "'" & Replace(txtFName.Text.Trim, "'", "''") & "', '" _
                        & Replace(txtLName.Text.Trim, "'", "''") & "', '" _
                        & Replace(txtAdd.Text.Trim, "'", "''") & "', "

            If ddlCity.SelectedValue.Trim = "" Then
                values += "0, "
            Else
                values += ddlCity.SelectedValue.Trim & ", "
            End If

            If ddlQty.Text.Trim = "" Or IsNumeric(ddlQty.Text.Trim) = False Then
                values += "0, "
            Else
                values += ddlQty.Text.Trim & ", "
            End If

            'If ddlProd.SelectedValue.Trim = "" Then
            '    values += "0, "
            'Else
            '    values += ddlProd.SelectedValue.Trim & ", "
            'End If

            'If ddlBrand.SelectedValue.Trim = "" Then
            '    values += "0, "
            'Else
            '    values += ddlBrand.SelectedValue.Trim & ", "
            'End If

            If ddlSCode.SelectedValue.Trim = "" Then
                values += "0, '"
            Else
                values += ddlSCode.SelectedValue.Trim & ", '"
            End If

            'If ddlCap.SelectedValue = "" Then
            '    values += "0, "
            'Else
            '    values += ddlCap.SelectedValue.Trim & ", "
            'End If

            'If ddlVariant.SelectedValue.Trim = "" Then
            '    values += "0, '"
            'Else
            '    values += ddlQty.SelectedValue.Trim & ", '"
            'End If

            If ddlDP.SelectedValue.Trim = "" Then
                values += "', '"
            Else
                If IsDate(ddlDP.SelectedValue.Trim) = False Then
                    values += "', '"
                Else
                    values += ddlDP.SelectedValue.Trim & "', '"
                End If
            End If

			values += Replace(txtSerial.Text.Trim, "'", "''") & "', '" _
						& Replace(txtInvoice.Text.Trim, "'", "''") & "', " _
						& Session("userID") & ", " _
						& ddlWeek.SelectedValue.Trim & ", "

            If stat = True Then
                values += "1"
            Else
                values += "2"
            End If

            .saveInfo("tbl_Sales", field, values)
        End With
    End Sub

    Public Function checkRequiredFld(ByVal ddlProd As DropDownList, _
                                        ByVal ddlBrand As DropDownList, _
                                        ByVal ddlSCode As DropDownList, _
                                        ByVal txtInvoice As TextBox, _
                                        ByVal ddlDP As DropDownList, _
                                        ByVal ddlQty As TextBox, _
                                        ByVal txtContact As TextBox) As Boolean

        checkRequiredFld = True
        lbleMsg.Text = ""

        If txtContact.Text.Trim <> "" Then
            If Len(txtContact.Text.Trim) <= 6 Then
                lbleMsg.Text = "Kindly enter a valid contact number."
                checkRequiredFld = False
                Exit Function
            End If
        End If

        If ddlQty.Text.Trim = "" Then
            lbleMsg.Text = "Quantity is a required field."
            checkRequiredFld = False
            Exit Function

        ElseIf IsNumeric(ddlQty.Text.Trim) = False Then
            lbleMsg.Text = "Quantity should be numeric."
            checkRequiredFld = False
            Exit Function
        End If

        If ddlProd.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Product is a required field."
            checkRequiredFld = False
            Exit Function
        End If

        If ddlBrand.Items.Count <> 0 Then
            If ddlBrand.Items.Count = 1 And ddlBrand.Items(0).Text.Trim = "" Then
                checkRequiredFld = True

            ElseIf ddlBrand.Items.Count > 1 And ddlBrand.SelectedValue.Trim = "" Then
                lbleMsg.Text = "Brand is a required field."
                checkRequiredFld = False
                Exit Function
            End If
        End If

        If ddlSCode.Items.Count <> 0 Then
            If ddlSCode.Items.Count = 1 And ddlSCode.Items(0).Text.Trim = "" Then
                checkRequiredFld = True

            ElseIf ddlSCode.Items.Count > 1 And ddlSCode.SelectedValue.Trim = "" Then
                lbleMsg.Text = "Short Code is a required field."
                checkRequiredFld = False
                Exit Function
            End If
        End If

        'If ddlCap.Items.Count <> 0 Then
        '    If ddlCap.Items.Count = 1 And ddlCap.Items(0).Text.Trim = "" Then
        '        checkRequiredFld = True

        '    ElseIf ddlCap.Items.Count > 1 And ddlCap.SelectedValue.Trim = "" Then
        '        lbleMsg.Text = "Capacity is a required field."
        '        checkRequiredFld = False
        '        Exit Function
        '    End If
        'End If

        'If ddlVariant.Items.Count <> 0 Then
        '    If ddlVariant.Items.Count = 1 And ddlVariant.Items(0).Text.Trim = "" Then
        '        checkRequiredFld = True

        '    ElseIf ddlVariant.Items.Count > 1 And ddlVariant.SelectedValue.Trim = "" Then
        '        lbleMsg.Text = "Variant is a required field."
        '        checkRequiredFld = False
        '        Exit Function
        '    End If
        'End If

        If txtInvoice.Text.Trim = "" Then
            lbleMsg.Text = "Invoice number is a required field."
            checkRequiredFld = False
            Exit Function
        End If

        If ddlDP.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Date Purchased is a required field."
            checkRequiredFld = False
            Exit Function
        End If

        Return checkRequiredFld
    End Function

    Protected Sub ddlAProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
		System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        Dim ddlProd As DropDownList = sender
        Dim ddlBrand As DropDownList = sender.namingcontainer.FindControl("ddlABrand")
        Dim ddlSCode As DropDownList = sender.namingcontainer.FindControl("ddlaSCode")
        'Dim lblCap As Label = sender.namingcontainer.FindControl("lblaCap")
        'Dim ddlCap As DropDownList = sender.namingcontainer.FindControl("ddACap")
        'Dim ddlVariant As DropDownList = sender.namingcontainer.FindControl("ddlAVariant")

        With conn
            If ddlProd.SelectedValue = "" Then
                ddlBrand.Items.Clear()
                ddlSCode.Items.Clear()
                'ddlVariant.SelectedIndex = -1
                'lblCap.Text = ""
                'ddlVariant.Items.Clear()

            Else
                'load brand
                where = "productID = " & ddlProd.SelectedValue
                .loadToDropDownList("tbl_Brand", ddlBrand, False, "*", where, "brandID", "brand", "", "")

                ddlSCode.Items.Clear()
                'ddlVariant.SelectedIndex = -1
                'lblCap.Text = ""

                'load capacity
                '.loadToDropDownList("tbl_Capacity", ddlCap, False, "*", where, "capacityID", "capacity", "", "")

                'load variant
                '.loadToDropDownList("tbl_Variant", ddlVariant, False, "*", where, "variantID", "variant", "", "")
            End If
        End With
    End Sub

    Protected Sub ddlEProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
		System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        Dim ddlProd As DropDownList = sender
        Dim ddlBrand As DropDownList = sender.namingcontainer.FindControl("ddlEBrand")
        Dim ddlSCode As DropDownList = sender.namingcontainer.FindControl("ddleSCode")
        'Dim lblCap As Label = sender.namingcontainer.findcontrol("lbleCap")
        'Dim ddlCap As DropDownList = sender.namingcontainer.FindControl("ddlECap")
        'Dim ddlVariant As DropDownList = sender.namingcontainer.FindControl("ddlEVariant")

        With conn
            If ddlProd.SelectedValue = "" Then
                ddlBrand.Items.Clear()
                ddlSCode.Items.Clear()
                'ddlVariant.SelectedIndex = -1
                'lblCap.Text = ""
                'ddlCap.Items.Clear()
                'ddlVariant.Items.Clear()

            Else
                'load brand
                where = "productID = " & ddlProd.SelectedValue
                .loadToDropDownList("tbl_Brand", ddlBrand, False, "*", where, "brandID", "brand", "", "")

                ddlSCode.Items.Clear()
                'ddlVariant.SelectedIndex = -1
                'lblCap.Text = ""
                'load variant
                '.loadToDropDownList("tbl_Variant", ddlVariant, False, "*", where, "variantID", "variant", "", "")
            End If
        End With
    End Sub

    Protected Sub ddlABrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
		System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        Dim ddlBrand As DropDownList = sender
        Dim ddlProd As DropDownList = sender.namingcontainer.FindControl("ddlaProd")
        Dim ddlSCode As DropDownList = sender.namingcontainer.FindControl("ddlaSCode")
        'Dim ddlVariant As DropDownList = sender.namingcontainer.FindControl("ddlaVariant")
        'Dim lblCap As Label = sender.namingcontainer.FindControl("lblaCap")
        'Dim ddlCap As DropDownList = sender.namingcontainer.FindControl("ddlaCap")

        With conn
            If ddlBrand.SelectedValue = "" Then
                ddlSCode.Items.Clear()
                'ddlVariant.SelectedIndex = -1
                'lblCap.Text = ""


            Else
                'load short code
                where = "productID = " & ddlProd.SelectedValue.Trim & " AND brandID = " & ddlBrand.SelectedValue.Trim
                .loadToDropDownList("tbl_Items", ddlSCode, False, "*", where, "itemID", "shortCode", "shortCode", "")

                'ddlVariant.SelectedIndex = -1
                'lblCap.Text = ""
                ''load capacity
                'where = "productID = " & ddlProd.SelectedValue.Trim & " AND brandID = " & ddlBrand.SelectedValue.Trim
                '.loadToDropDownList("tbl_Items", ddlSCode, False, "*", where, "itemID", "shortCode", "", "")
            End If
        End With
    End Sub

    Protected Sub ddlEBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
		System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        Dim ddlBrand As DropDownList = sender
        Dim ddlProd As DropDownList = sender.namingcontainer.FindControl("ddlEProd")
        'Dim ddlVariant As DropDownList = sender.namingcontainer.FindControl("ddlEVariant")
        'Dim lblCap As Label = sender.namingcontainer.findcontrol("lbleCap")
        'Dim ddlCap As DropDownList = sender.namingcontainer.FindControl("ddlECap")
        Dim ddlSCode As DropDownList = sender.namingcontainer.FindControl("ddleSCode")

        With conn
            If ddlBrand.SelectedValue.Trim = "" Then
                ddlSCode.Items.Clear()
                'ddlVariant.SelectedIndex = -1
                'lblCap.Text = ""

            Else
                'load short code
                where = "productID = " & ddlProd.SelectedValue.Trim & " AND brandID = " & ddlBrand.SelectedValue.Trim
                .loadToDropDownList("tbl_Items", ddlSCode, False, "*", where, "itemID", "shortCode", "shortCode", "")

                'ddlVariant.SelectedIndex = -1
                'lblCap.Text = ""
                ''load capacity
                'where = "productID = " & ddlProd.SelectedValue.Trim & " AND brandID = " & ddlBrand.SelectedValue.Trim
                '.loadToDropDownList("tbl_Capacity", ddlCap, False, "*", where, "capacityID", "capacity", "", "")
            End If
        End With
    End Sub

    Protected Sub grdSales_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdSales.RowCancelingEdit
		System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        grdSales.EditIndex = -1
        'where = "userID = " & Session("userID")
        'conn.LoadToGrid("vw_Sales", grdSales, "*", where, "salesID", "")
        grdSales.DataBind()
    End Sub

    Protected Sub grdSales_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdSales.RowDataBound
		System.Threading.Thread.Sleep(500)

        If e.Row.RowType = DataControlRowType.Header Then
            With e.Row
                Dim ddlACity As DropDownList = .FindControl("ddlACity")
                Dim ddlAProd As DropDownList = .FindControl("ddlAProd")
                Dim ddlADP As DropDownList = .FindControl("ddlADP")
                'Dim ddlAVariant As DropDownList = .FindControl("ddlAVariant")

                If ddlAProd IsNot Nothing Then
                    conn.loadToDropDownList("tbl_Product", ddlAProd, False, "*", "", "productID", "product", "product", "")

                    If ddlAProd.Items.Item(0).Text.Trim <> "" Then
                        ddlAProd.Items.Insert(0, "")
                    End If
                End If

                'If ddlAVariant IsNot Nothing Then
                '    conn.loadToDropDownList("tbl_Variant", ddlAVariant, False, "*", "", "variantID", "variant", "variant", "")

                '    If ddlAVariant.Items.Item(0).Text.Trim <> "" Then
                '        ddlAVariant.Items.Insert(0, "")
                '    End If
                'End If

                If ddlACity IsNot Nothing Then
                    conn.loadToDropDownList("tbl_City", ddlACity, False, "*", "", "cityID", "city", "city", "")

                    If ddlACity.Items.Item(0).Text.Trim <> "" Then
                        ddlACity.Items.Insert(0, "")
                    End If
                End If

                If ddlADP IsNot Nothing Then
                    ddlADP.Items.Clear()
					'generateDate(.FindControl("ddlaDP"))
					If Session("weekID") IsNot Nothing Then
						where = "weekID = " & Session("weekID")
						conn.loadToDropDownList("tbl_WDay", ddlADP, False, "*", where, "wDay", "wDay", "", "")

						If ddlADP.Items.Item(0).Text.Trim <> "" Then
							ddlADP.Items.Insert(0, "")
						End If
					End If
                End If
            End With

        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            With e.Row
                Dim lblDP As Label = .FindControl("lbliDP")
                Dim lblEDP As Label = .FindControl("lblEDP")
                Dim txtEDP As TextBox = .FindControl("txtEDP")
                Dim ddlEProd As DropDownList = .FindControl("ddlEProd")
                Dim ddlECity As DropDownList = .FindControl("ddlECity")
                Dim ddlEDP As DropDownList = .FindControl("ddlEDP")
                'Dim ddleVariant As DropDownList = .FindControl("ddleVariant")

                If ddlEProd IsNot Nothing Then
                    conn.loadToDropDownList("tbl_Product", ddlEProd, False, "*", "", "productID", "product", "product", "")

                    If ddlEProd.Items.Item(0).Text.Trim <> "" Then
                        ddlEProd.Items.Insert(0, "")
                    End If
                End If

                'If ddleVariant IsNot Nothing Then
                '    conn.loadToDropDownList("tbl_Variant", ddleVariant, False, "*", "", "variantID", "variant", "variant", "")

                '    If ddleVariant.Items.Item(0).Text.Trim <> "" Then
                '        ddleVariant.Items.Insert(0, "")
                '    End If
                'End If

                If ddlECity IsNot Nothing Then
                    conn.loadToDropDownList("tbl_City", ddlECity, False, "*", "", "cityID", "city", "city", "")

                    If ddlECity.Items.Item(0).Text.Trim <> "" Then
                        ddlECity.Items.Insert(0, "")
                    End If
                End If

                'If lblDP IsNot Nothing Then
                '    If lblDP.Text.Trim <> "" Then
                '        If IsDate(lblDP.Text.Trim) = True Then
                '            lblDP.Text = Format(CDate(lblDP.Text.Trim), formatToShow)
                '        End If
                '    End If
                'End If

                'If lblEDP IsNot Nothing Then
                '    If lblEDP.Text.Trim <> "" Then
                '        If IsDate(lblEDP.Text.Trim) = True Then
                '            lblEDP.Text = Format(CDate(lblEDP.Text.Trim), formatToShow)
                '        End If
                '    End If
                'End If

                If ddlEDP IsNot Nothing Then
                    ddlEDP.Items.Clear()
                    'generateDate(ddlEDP)

					If Session("weekID") IsNot Nothing Then
						where = "weekID = " & Session("weekID")
						conn.loadToDropDownList("tbl_WDay", ddlEDP, False, "*", where, "wDay", "wDay", "", "")

						If ddlEDP.Items.Item(0).Text.Trim <> "" Then
							ddlEDP.Items.Insert(0, "")
						End If
					End If
                End If
            End With
        End If
    End Sub

    Public Function generateDate(ByVal ddlDate As DropDownList) As String
        'On Error Resume Next

        If ddlWeek.SelectedItem.Text <> "" Then
            Dim dWeek() As String = Split(Replace(ddlWeek.SelectedItem.Text.Trim, " ", ""), "-")
            Dim fDate As String = Format(CDate(dWeek(0)), formatToSave)   'format(Convert.ToDateTime(dWeek(0)), formatToSave)
            Dim tDate As String = Format(CDate(dWeek(1)), formatToSave)     'Format(Convert.ToDateTime(dWeek(1)), formatToSave)
            Dim cnt As Integer = 1
            Dim counter As Integer = 0
            Dim nDate As String = fDate       'Format(Convert.ToDateTime(fDate), formatToSave)

            ddlDate.Items.Add("")
            ddlDate.Items.Add(Format(Convert.ToDateTime(nDate), formatToShow))
            Do While nDate <> tDate              'Format(Convert.ToDateTime(tDate), formatToSave)
                'nDate = Format(Convert.ToDateTime(nDate), formatToSave)
                nDate = Format(DateAdd(DateInterval.Day, 1, Convert.ToDateTime(nDate)), formatToSave)    'Format(DateAdd(DateInterval.Day, 1, nDate), formatToSave)
                ddlDate.Items.Add(Format(Convert.ToDateTime(nDate), formatToShow))
                If nDate = tDate Then
                    Exit Do
                End If
            Loop
        End If
    End Function

    Protected Sub lnkCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        grdSales.Enabled = True
        grdCompetitor.Enabled = True
        grdStocks.Enabled = True
        grdInventory.Enabled = True
    End Sub

    Public Sub fetchSales()
        'check if user already has report
        Dim retFld(0), retVal(0) As String
        retFld(0) = "weekID"

        where = "userID = " & Session("userID") & " AND weekID IS NOT NULL"
        If conn.checkID("tbl_Sales", "userID, weekID", where, 1, retVal, retFld, "", "") = "False" Then
            'Session("weekID") = Nothing
            'ddlWeek.SelectedIndex = -1
            'ddlWeek.Enabled = True
            'btnCreate.Text = "Create Report"

            'grdSales.Enabled = False
            'grdCompetitor.Enabled = False
            'grdStocks.Enabled = False
            'grdInventory.Enabled = False

        Else
            Session("weekID") = retVal(0)
            ddlWeek.SelectedValue = retVal(0)
            ddlWeek.Enabled = False
            btnCreate.Text = "Cancel Report"

            grdSales.Enabled = True
            grdCompetitor.Enabled = True
            grdStocks.Enabled = True
            grdInventory.Enabled = True
        End If

        'fetch record
        If grdSales.Rows.Count < 10 Then
            'create first 10 rec
            Dim recCount As Integer = grdSales.Rows.Count
            recCount = 10 - recCount
            cnt = 1
            counter = 0

            Do While cnt <= recCount
                field = "userID"
                values = Session("userID")

                conn.saveInfo("tbl_Sales", field, values)

                cnt += 1
                counter += 1
            Loop

            'where = "userID = " & Session("userID")
            'conn.LoadToGrid("vw_Sales", grdSales, "*", where, "salesID", "")
			grdSales.DataBind()
		End If


    End Sub

    Public Sub fetchCompete()
        'check if user already has report
        Dim retFld(0), retVal(0) As String
        retFld(0) = "weekID"

        where = "userID = " & Session("userID") & " AND weekID IS NOT NULL"
        If conn.checkID("tbl_Sales", "userID, weekID", where, 1, retVal, retFld, "", "") = "False" Then
            'ddlWeek.SelectedIndex = -1
            'ddlWeek.Enabled = True
            'btnCreate.Text = "Create Report"

            'grdSales.Enabled = False
            'grdCompetitor.Enabled = False
            'grdStocks.Enabled = False
            'grdInventory.Enabled = False

        Else
            ddlWeek.SelectedValue = retVal(0)
            ddlWeek.Enabled = False
            btnCreate.Text = "Cancel Report"

            grdSales.Enabled = True
            grdCompetitor.Enabled = True
            grdStocks.Enabled = True
            grdInventory.Enabled = True
        End If

        'fetch record
		If grdCompetitor.Rows.Count < 10 Then
			'create first 10 rec
			Dim recCount As Integer = grdCompetitor.Rows.Count
			recCount = 10 - recCount
			cnt = 1
			counter = 0

			Do While cnt <= recCount
				field = "userID"
				values = Session("userID")

				conn.saveInfo("tbl_Competitor", field, values)

				cnt += 1
				counter += 1
			Loop

			grdCompetitor.DataBind()
		End If
    End Sub

    Public Sub fetchStocks()
        'check if user already has report
        Dim retFld(0), retVal(0) As String
        retFld(0) = "weekID"

        where = "userID = " & Session("userID") & " AND weekID IS NOT NULL"
        If conn.checkID("tbl_Sales", "userID, weekID", where, 1, retVal, retFld, "", "") = "False" Then
            'ddlWeek.SelectedIndex = -1
            'ddlWeek.Enabled = True
            'btnCreate.Text = "Create Report"

            'grdSales.Enabled = False
            'grdCompetitor.Enabled = False
            'grdStocks.Enabled = False
            'grdInventory.Enabled = False

        Else
            ddlWeek.SelectedValue = retVal(0)
            ddlWeek.Enabled = False
            btnCreate.Text = "Cancel Report"

            grdSales.Enabled = True
            grdCompetitor.Enabled = True
            grdStocks.Enabled = True
            grdInventory.Enabled = True
        End If

        'fetch record
        If grdStocks.Rows.Count < 10 Then
            'create first 10 rec
            Dim recCount As Integer = grdStocks.Rows.Count
            recCount = 10 - recCount
            cnt = 1
            counter = 0

            Do While cnt <= recCount
                field = "userID"
                values = Session("userID")

                conn.saveInfo("tbl_Stocks", field, values)

                cnt += 1
                counter += 1
            Loop

            grdStocks.DataBind()
        End If
    End Sub

    Public Sub fetchInventory()
        'check if user already has report
        Dim retFld(0), retVal(0) As String
        retFld(0) = "weekID"

        where = "userID = " & Session("userID") & " AND weekID IS NOT NULL"
        If conn.checkID("tbl_Sales", "userID, weekID", where, 1, retVal, retFld, "", "") = "False" Then
            'ddlWeek.SelectedIndex = -1
            'ddlWeek.Enabled = True
            'btnCreate.Text = "Create Report"

            'grdSales.Enabled = False
            'grdCompetitor.Enabled = False
            'grdStocks.Enabled = False
            'grdInventory.Enabled = False

        Else
            ddlWeek.SelectedValue = retVal(0)
            ddlWeek.Enabled = False
            btnCreate.Text = "Cancel Report"

            grdSales.Enabled = True
            grdCompetitor.Enabled = True
            grdStocks.Enabled = True
            grdInventory.Enabled = True
        End If

        'fetch record
        If grdInventory.Rows.Count < 10 Then
            'create first 10 rec
            Dim recCount As Integer = grdInventory.Rows.Count
            recCount = 10 - recCount
            cnt = 1
            counter = 0

            Do While cnt <= recCount
                field = "userID"
                values = Session("userID")

                conn.saveInfo("tbl_Inventory", field, values)

                cnt += 1
                counter += 1
            Loop

            grdInventory.DataBind()
        End If
    End Sub

    Public Sub checkWeekToday()
        With conn
            Dim dtNow As Date = Format(Now, formatToSave)

        End With
    End Sub

    Public Sub checkRights()
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
                    lProd.Visible = True
                    lnkProd.CssClass = "tabprop-Selected"
                    panSales.Visible = True
                    sCount += 1

                    fetchSales()
                End If

                If aRyt(counter) = "SCF" Then
                    lCompete.Visible = True

                    If lProd.Visible = True Then
                        panCompete.Visible = False
                    Else
                        lnkCompete.CssClass = "tabprop-Selected"
                        panCompete.Visible = True

                        fetchCompete()
                    End If

                    sCount += 1
                End If

                If aRyt(counter) = "SSF" Then
                    lStocks.Visible = True

                    If lProd.Visible = True Or
                        lCompete.Visible = True Then

                        panStocks.Visible = False

                    Else
                        lnkStocks.CssClass = "tabprop-Selected"
                        panStocks.Visible = True

                        fetchStocks()
                    End If

                    sCount += 1
                End If

                If aRyt(counter) = "SIF" Then
                    lInventory.Visible = True

                    If lProd.Visible = True Or
                        lCompete.Visible = True Or
                        lStocks.Visible = True Then

                        panInventory.Visible = False

                    Else
                        lnkInventory.CssClass = "tabprop-Selected"
                        panInventory.Visible = True

                        fetchInventory()
                    End If

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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'System.Threading.Thread.Sleep(500)
        'On Error Resume Next

        If Page.IsPostBack = False Then
            checkSession()
            lbleMsg.Text = ""

            checkRights()

            Select Case Session("startupTab")
                Case "Sales"
                    If lProd IsNot Nothing Then lnkProd.CssClass = "tabprop-Selected"
                    If lCompete IsNot Nothing Then lnkCompete.CssClass = "tabprop"
                    If lStocks IsNot Nothing Then lnkStocks.CssClass = "tabprop"
                    If lInventory IsNot Nothing Then lnkInventory.CssClass = "tabprop"

                    panSales.Visible = True
                    panCompete.Visible = False
                    panStocks.Visible = False
                    panInventory.Visible = False


                Case "Compete"
                    If lProd IsNot Nothing Then lnkProd.CssClass = "tabprop"
                    If lCompete IsNot Nothing Then lnkCompete.CssClass = "tabprop-Selected"
                    If lStocks IsNot Nothing Then lnkStocks.CssClass = "tabprop"
                    If lInventory IsNot Nothing Then lnkInventory.CssClass = "tabprop"

                    panSales.Visible = False
                    panCompete.Visible = True
                    panStocks.Visible = False
                    panInventory.Visible = False


                Case "Stocks"
                    If lProd IsNot Nothing Then lnkProd.CssClass = "tabprop"
                    If lCompete IsNot Nothing Then lnkCompete.CssClass = "tabprop"
                    If lStocks IsNot Nothing Then lnkStocks.CssClass = "tabprop-Selected"
                    If lInventory IsNot Nothing Then lnkInventory.CssClass = "tabprop"

                    panSales.Visible = False
                    panCompete.Visible = False
                    panStocks.Visible = True
                    panInventory.Visible = False


                Case "Inventory"
                    If lProd IsNot Nothing Then lnkProd.CssClass = "tabprop"
                    If lCompete IsNot Nothing Then lnkCompete.CssClass = "tabprop"
                    If lStocks IsNot Nothing Then lnkStocks.CssClass = "tabprop"
                    If lInventory IsNot Nothing Then lnkInventory.CssClass = "tabprop-Selected"

                    panSales.Visible = False
                    panCompete.Visible = False
                    panStocks.Visible = False
                    panInventory.Visible = True
            End Select

			' add filter here
			' if accntTypeID = 6 or 7, show current week only, everyone else show 3 weeks
			Dim l_select As String = "*"
			Dim l_flow As String = ""
			If Session("accntTypeID") = "6" Or Session("accntTypeID") = "7" Then
				l_select = "TOP 1 *"
				l_flow = "DESC"
			Else
				l_select = "TOP 3 *"
				l_flow = "DESC"
			End If
			conn.loadToDropDownList("vw_Week", ddlWeek, False, l_select, "", "weekID", "weekCoverage", "weekID", l_flow)

            ''fetchCompete()
            ''fetchStocks()
            ''fetchInventory()

			'set date
			If Session("weekID") IsNot Nothing Then
				Dim ddlaDP As DropDownList = grdSales.HeaderRow.FindControl("ddlaDP")
				'Dim ddlaDate As DropDownList = grdCompetitor.HeaderRow.FindControl("ddlaCDate")
				'Dim ddlaWhen As DropDownList = grdStocks.HeaderRow.FindControl("ddlaWhen")

				With conn
					where = "weekID = " & Session("weekID")

					ddlaDP.Items.Clear()
					'generateDate(ddlaDP)
					.loadToDropDownList("tbl_WDay", ddlaDP, False, "*", where, "wDay", "wDay", "", "")

					'ddlaDate.Items.Clear()
					'generateDate(ddlaDate)
					'.loadToDropDownList("tbl_WDay", ddlaDate, False, "*", where, "wDay", "wDay", "", "")

					'ddlaWhen.Items.Clear()
					'generateDate(ddlaWhen)
					'.loadToDropDownList("tbl_WDay", ddlaWhen, False, "*", where, "wDay", "wDay", "", "")
				End With
			End If
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

    Protected Sub btnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        checkSession()
        lbleMsg.Text = ""

        If btnCreate.Text = "Create Report" Then
            If ddlWeek.SelectedValue.Trim = "" Then
                lbleMsg.Text = "Please select the week coverage first."
                Exit Sub

            Else
				System.Threading.Thread.Sleep(500)
                ddlWeek.Enabled = False
                Session("weekID") = ddlWeek.SelectedValue.Trim
                btnCreate.Text = "Cancel Report"

                With conn
                    fetchSales()
                    fetchCompete()
                    fetchStocks()
                    fetchInventory()
                    'update sales
                    'createReport("tbl_Sales")
                    'update competitor
                    'createReport("tbl_Competitor")
                    'update stocks
                    'createReport("tbl_Stocks")
                    'update inventory
                    'createReport("tbl_Inventory")
                End With

                grdSales.Enabled = True
                grdCompetitor.Enabled = True
                grdStocks.Enabled = True
                grdInventory.Enabled = True

				'generateDate(grdSales.HeaderRow.FindControl("ddlaDP"))

                'load dates
                Dim ddlDate As DropDownList = grdSales.HeaderRow.FindControl("ddlADP")
                Dim ddlCDate As DropDownList = grdCompetitor.HeaderRow.FindControl("ddlACDate")
                Dim ddlSDate As DropDownList = grdStocks.HeaderRow.FindControl("ddlAWhen")

                where = "weekID = " & ddlWeek.SelectedValue.Trim
                conn.loadToDropDownList("tbl_WDay", ddlDate, False, "*", where, "wDay", "wDay", "", "")
                conn.loadToDropDownList("tbl_WDay", ddlCDate, False, "*", where, "wDay", "wDay", "", "")
                conn.loadToDropDownList("tbl_WDay", ddlSDate, False, "*", where, "wDay", "wDay", "", "")


            End If

        ElseIf btnCreate.Text = "Cancel Report" Then
            lbleMsg.Text = "This would delete your current data. Are you sure?"
            imbYes.Visible = True
            imbNo.Visible = True
        End If
    End Sub

    Public Sub createReport(ByVal tblName As String)
        With conn
            Dim fld(0), val(0), dt(0) As String

            fld(0) = "weekID"
            val(0) = ddlWeek.SelectedValue.Trim
            dt(0) = "N"

            where = "userID = " & Session("userID")
            .UpdateDB(tblName, fld, val, dt, where)
        End With
    End Sub

    Protected Sub imbYes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbYes.Click
		System.Threading.Thread.Sleep(500)
        checkSession()

        'incomplete data
        If lbleMsg.Text = "Data is incomplete. Do you still want to save it?" Then
            If Session("salesAct") = "header" Then
                With grdSales.HeaderRow
                    Dim txtFname As TextBox = .FindControl("txtAFName")
                    Dim txtLname As TextBox = .FindControl("txtALName")
                    Dim txtAdd As TextBox = .FindControl("txtAAdd")
                    Dim ddlCity As DropDownList = .FindControl("ddlACity")
                    Dim txtContact As TextBox = .FindControl("txtAContact")
                    Dim ddlQty As TextBox = .FindControl("ddlAQty")
                    Dim ddlProd As DropDownList = .FindControl("ddlAProd")
                    Dim ddlBrand As DropDownList = .FindControl("ddlABrand")
                    Dim ddlSCode As DropDownList = .FindControl("ddlaSCode")
                    'Dim ddlCap As DropDownList = .FindControl("ddlACap")
                    'Dim ddlVariant As DropDownList = .FindControl("ddlAVariant")
                    Dim ddlDP As DropDownList = .FindControl("ddlADP")
                    Dim txtSerial As TextBox = .FindControl("txtASerial")
                    Dim txtInvoice As TextBox = .FindControl("txtAInvoice")
                    Dim lblStatus As Label = .FindControl("lblaStatus")

                    saveSales(txtFname, txtLname, txtAdd, ddlCity, txtContact, ddlQty, ddlSCode, ddlDP, txtSerial, txtInvoice, False)

                    lbleMsg.Text = ""
                    imbYes.Visible = False
                    imbNo.Visible = False
                End With

                'edit
            Else
                With grdSales.Rows(Session("salesEditIndex"))
                    Dim txtFName As TextBox = .FindControl("txteFName")
                    Dim txtLName As TextBox = .FindControl("txteLName")
                    Dim txtAdd As TextBox = .FindControl("txteAdd")
                    Dim ddlCity As DropDownList = .FindControl("ddleCity")
                    Dim txtContact As TextBox = .FindControl("txtEContact")
                    Dim ddlQty As TextBox = .FindControl("ddlEQty")
                    Dim ddlProd As DropDownList = .FindControl("ddlEProd")
                    Dim ddlBrand As DropDownList = .FindControl("ddlEBrand")
                    Dim ddlSCode As DropDownList = .FindControl("ddleSCode")
                    'Dim ddlCap As DropDownList = .FindControl("ddlECap")
                    'Dim ddlVariant As DropDownList = .FindControl("ddlEVariant")
                    Dim ddlDP As DropDownList = .FindControl("ddlEDP")
					Dim txtSerial As TextBox = .FindControl("txtESerial")
                    Dim txtInvoice As TextBox = .FindControl("txtEInvoice")

                    Dim salesID As String = grdSales.DataKeys.Item(Session("salesEditIndex")).Value

                    updateRecord(salesID, txtFName, txtLName, txtAdd, ddlCity, txtContact, ddlQty, ddlSCode, ddlDP, txtSerial, txtInvoice, False)

                    Session("salesEditIndex") = ""
                End With
            End If

            'create report
        ElseIf lbleMsg.Text = "Are you sure to submit the report? Data will no longer be available for editing." Then
            With conn
                'check if there are records to save
                where = "userID = " & Session("userID") & " AND invoice <> ''"
                Dim salesCount As Integer = .GetRecordCount("tbl_Sales", "salesID", where)

                where = "userID = " & Session("userID") & " AND csDate <> ''"
                Dim competeCount As Integer = .GetRecordCount("tbl_Competitor", "competeID", where)

                where = "userID = " & Session("userID") & " AND dWhen <> ''"
                Dim stocksCount As Integer = .GetRecordCount("tbl_Stocks", "stocksID", where)

                where = "(userID = " & Session("userID") & " AND qty <> 0) OR (userID = " & Session("userID") & " AND qty IS NOT NULL)"
                Dim inventoryCount As Integer = .GetRecordCount("tbl_Inventory", "inventoryID", where)

                If salesCount <> 0 Then
                    transferSales()
                End If

                If competeCount <> 0 Then
                    transferCompetitor()
                End If

                If stocksCount <> 0 Then
                    transferStocks()
                End If

                If inventoryCount <> 0 Then
                    transferInventory()
                End If

                grdSales.DataBind()
                grdSales.Enabled = False

                grdCompetitor.DataBind()
                grdCompetitor.Enabled = False

                grdStocks.DataBind()
                grdStocks.Enabled = False

                grdInventory.DataBind()
                grdInventory.Enabled = False

                fetchSales()
                fetchCompete()
                fetchStocks()
                fetchInventory()

                lbleMsg.Text = "Report has been submitted."
                ddlWeek.Enabled = True
                ddlWeek.SelectedIndex = -1
                btnCreate.Text = "Create Report"

                imbYes.Visible = False
				imbNo.Visible = False

				Response.Redirect("~/Feedback.aspx") ' redirect to feedback page
            End With
            Exit Sub

            'cancel report
        Else
            lbleMsg.Text = ""
            imbYes.Visible = False
            imbNo.Visible = False
            Session("weekID") = Nothing

            With conn
                'clear 
                where = "userID = " & Session("userID")
                .deleteRecord("tbl_Sales", where)

                where = "userID = " & Session("userID")
                .deleteRecord("tbl_Competitor", where)

                where = "userID = " & Session("userID")
                .deleteRecord("tbl_Stocks", where)

                where = "userID = " & Session("userID")
                .deleteRecord("tbl_Inventory", where)

                grdSales.DataBind()
                grdSales.Enabled = False

                grdCompetitor.DataBind()
                grdCompetitor.Enabled = False

                grdStocks.DataBind()
                grdStocks.Enabled = False

                grdInventory.DataBind()
                grdInventory.Enabled = False

                'fetch data
                fetchSales()
                fetchCompete()
                fetchStocks()
                fetchInventory()


                btnCreate.Text = "Create Report"
                ddlWeek.SelectedIndex = -1
                ddlWeek.Enabled = True
            End With
        End If

        lbleMsg.Text = ""
    End Sub

    Protected Sub imbNo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)
        checkSession()

        'cancel saving
        If lbleMsg.Text = "Data is incomplete. Do you still want to save it?" Then
            lbleMsg.Text = ""
            imbYes.Visible = False
            imbNo.Visible = False

            'continue with report
        Else
            lbleMsg.Text = ""

			ddlWeek.Enabled = False
            imbYes.Visible = False
            imbNo.Visible = False
            grdSales.Enabled = True
            btnCreate.Text = "Cancel Report"
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
		System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        With conn
            'check if there are records to save
            where = "userID = " & Session("userID") & " AND invoice <> ''"
            Dim salesCount As Integer = .GetRecordCount("tbl_Sales", "salesID", where)

            where = "userID = " & Session("userID") & " AND csDate <> ''"
            Dim competeCount As Integer = .GetRecordCount("tbl_Competitor", "competeID", where)

            where = "userID = " & Session("userID") & " AND dWhen <> ''"
            Dim stocksCount As Integer = .GetRecordCount("tbl_Stocks", "stocksID", where)

            where = "(userID = " & Session("userID") & " AND qty <> 0) OR (userID = " & Session("userID") & " AND qty IS NOT NULL)"
            Dim inventoryCount As Integer = .GetRecordCount("tbl_Inventory", "inventoryID", where)


            If salesCount = 0 And competeCount = 0 And stocksCount = 0 And inventoryCount = 0 Then
                lbleMsg.Text = "No record has been added yet. Report will not be submitted."
                imbYes.Visible = False
                imbNo.Visible = False
                Exit Sub

            Else
                lbleMsg.Text = "Are you sure to submit the report? Data will no longer be available for editing."
                imbYes.Visible = True
                imbNo.Visible = True
            End If
        End With
    End Sub

    Public Sub transferSales()
        With conn
            'get records
            Dim retFld(10), retVal(10) As String

            retFld(0) = "fname"
            retFld(1) = "lname"
            retFld(2) = "cAdd"
            retFld(3) = "cityID"
            retFld(4) = "contact"
            retFld(5) = "qty"
            retFld(6) = "itemID"
            retFld(7) = "dPurchased"
            retFld(8) = "serial"
            retFld(9) = "invoice"
            retFld(10) = "recStatusID"

            where = "userID = " & Session("userID") & " AND invoice <> ''"
            .getRecords("tbl_Sales", "*", where, 11, retFld, retVal, "", "")

            Dim fname() As String = Split(retVal(0), "+")
            Dim lname() As String = Split(retVal(1), "+")
            Dim cAdd() As String = Split(retVal(2), "+")
            Dim city() As String = Split(retVal(3), "+")
            Dim contact() As String = Split(retVal(4), "+")
            Dim qty() As String = Split(retVal(5), "+")
            Dim item() As String = Split(retVal(6), "+")
            Dim dp() As String = Split(retVal(7), "+")
            Dim serial() As String = Split(retVal(8), "+")
            Dim inv() As String = Split(retVal(9), "+")
            Dim stat() As String = Split(retVal(10), "+")

            cnt = 1
            counter = 0

            If retVal(0) <> "" Then
                Do While cnt <= UBound(item) + 1
                    appendReport(fname(counter), cAdd(counter), contact(counter), qty(counter), item(counter), dp(counter), serial(counter), inv(counter), lname(counter), city(counter), stat(counter))
                    cnt += 1
                    counter += 1
                Loop
            End If

            where = "userID = " & Session("userID")
            .deleteRecord("tbl_Sales", where)

            fetchSales()
            grdSales.DataBind()
        End With
    End Sub

    Public Sub transferCompetitor()
        With conn
            'get records
            Dim retFld(4), retVal(4) As String

            retFld(0) = "cBrandID"
            retFld(1) = "qty"
            retFld(2) = "csDate"
            retFld(3) = "factor"
			retFld(4) = "cCapacityID"

            where = "userID = " & Session("userID") & " AND csDate <> ''"
            .getRecords("tbl_Competitor", "*", where, 5, retFld, retVal, "", "")

            Dim cBrand() As String = Split(retVal(0), "+")
            Dim qty() As String = Split(retVal(1), "+")
            Dim csDate() As String = Split(retVal(2), "+")
            Dim factor() As String = Split(retVal(3), "+")
			Dim cCap() As String = Split(retVal(4), "+")

            cnt = 1
            counter = 0

            If retVal(0) <> "" Then
                Do While cnt <= UBound(csDate) + 1
                    appendCompetitor(cBrand(counter), qty(counter), csDate(counter), factor(counter), cCap(counter))
                    cnt += 1
                    counter += 1
                Loop
            End If

            where = "userID = " & Session("userID")
            .deleteRecord("tbl_Competitor", where)

            fetchCompete()
            grdCompetitor.DataBind()
        End With
    End Sub

    Public Sub transferStocks()
        With conn
            'get records
            Dim retFld(4), retVal(4) As String

            retFld(0) = "dWhen"
            retFld(1) = "promo"
            retFld(2) = "actionID"
            retFld(3) = "otherAct"
            retFld(4) = "itemID"

            where = "userID = " & Session("userID") & " AND dWhen <> ''"
            .getRecords("tbl_Stocks", "*", where, 5, retFld, retVal, "", "")

            Dim dWhen() As String = Split(retVal(0), "+")
            Dim promo() As String = Split(retVal(1), "+")
            Dim actionID() As String = Split(retVal(2), "+")
            Dim otherAct() As String = Split(retVal(3), "+")
            Dim item() As String = Split(retVal(4), "+")

            cnt = 1
            counter = 0

            If retVal(0) <> "" Then
                Do While cnt <= UBound(item) + 1
                    appendStocks(dWhen(counter), promo(counter), actionID(counter), otherAct(counter), item(counter))
                    cnt += 1
                    counter += 1
                Loop
            End If

            where = "userID = " & Session("userID")
            .deleteRecord("tbl_Stocks", where)

            fetchStocks()
            grdStocks.DataBind()
        End With
    End Sub

    Public Sub transferInventory()
        With conn
            'get records
            Dim retFld(2), retVal(2) As String

            retFld(0) = "qty"
            retFld(1) = "comments"
            retFld(2) = "itemID"

            where = "(userID = " & Session("userID") & " AND qty <> '0') OR (userID = " & Session("userID") & " AND qty IS NOT NULL)"
            .getRecords("tbl_Inventory", "*", where, 3, retFld, retVal, "", "")

            Dim qty() As String = Split(retVal(0), "+")
            Dim comments() As String = Split(retVal(1), "+")
            Dim item() As String = Split(retVal(2), "+")

            cnt = 1
            counter = 0

            If retVal(0) <> "" Then
                Do While cnt <= UBound(item) + 1
                    appendInventory(qty(counter), comments(counter), item(counter))
                    cnt += 1
                    counter += 1
                Loop
            End If

            where = "userID = " & Session("userID")
            .deleteRecord("tbl_Inventory", where)

            fetchInventory()
            grdInventory.DataBind()
        End With
    End Sub

    Public Sub appendReport(ByVal fname As String, ByVal cAdd As String, ByVal contact As String, _
                            ByVal qty As Integer, ByVal item As String, _
                            ByVal dPurchased As String, ByVal serial As String, ByVal invoice As String, _
                            ByVal lname As String, ByVal city As String, ByVal stat As String)

        With conn
            field = "userID, weekID, dSubmitted, " _
                        & "fname, lname, " _
                        & "cAdd, cityID, contact, " _
                        & "qty, itemID, " _
                        & "dPurchased, serial, invoice, recStatusID"

            values = Session("userID") & ", " _
                        & ddlWeek.SelectedValue.Trim & ", '" _
                        & Format(Now, formatToShow) & "', '" _
                        & fname & "', '" & lname & "', '" _
                        & cAdd & "', " & city & ", '" & contact & "', " _
                        & qty & ", " & item & ", '" _
                        & dPurchased & "', '" & serial & "', '" & invoice & "', " & stat

            .saveInfo("tbl_SalesSub", field, values)
        End With
    End Sub

	Public Sub appendCompetitor(ByVal cBrand As String, ByVal qty As Integer, _
                            ByVal csDate As String, ByVal factor As String, ByVal cCap As String)

		With conn
			field = "userID, weekID, dSubmitted, " _
						& "cBrandID, qty, " _
                        & "csDate, factor, cCapacityID"

			values = Session("userID") & ", " _
						& ddlWeek.SelectedValue.Trim & ", '" _
						& Format(Now, formatToShow) & "', " _
						& cBrand & ", " & qty & ", '" _
                        & csDate & "', '" & factor & "', " & cCap

			.saveInfo("tbl_CompeteSub", field, values)
		End With
	End Sub

    Public Sub appendStocks(ByVal dWhen As String, ByVal promo As String, ByVal actionID As String, _
                            ByVal otherAct As String, ByVal item As String)

        With conn
            field = "userID, weekID, dSubmitted, " _
                        & "dWhen, promo, " _
                        & "actionID, otherAct, itemID"

            values = Session("userID") & ", " _
                        & ddlWeek.SelectedValue.Trim & ", '" _
                        & Format(Now, formatToShow) & "', '" _
                        & dWhen & "', '" & promo & "', " _
                        & actionID & ", '" & otherAct & "', " & item

            .saveInfo("tbl_StocksSub", field, values)
        End With
    End Sub

    Public Sub appendInventory(ByVal qty As String, ByVal comments As String, ByVal item As String)

        With conn
            field = "userID, weekID, dSubmitted, " _
                        & "qty, comments, itemID"

            values = Session("userID") & ", " _
                        & ddlWeek.SelectedValue.Trim & ", '" _
                        & Format(Now, formatToShow) & "', " _
                        & qty & ", '" & comments & "', " & item

            .saveInfo("tbl_InventorySub", field, values)
        End With
    End Sub

    Protected Sub grdSales_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdSales.RowEditing
		System.Threading.Thread.Sleep(500)
        grdSales.EditIndex = e.NewEditIndex
    End Sub

    Protected Sub grdSales_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdSales.RowUpdating
		System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        With grdSales.Rows(e.RowIndex)
            Dim txtFName As TextBox = .FindControl("txteFName")
            Dim txtLName As TextBox = .FindControl("txteLName")
            Dim txtAdd As TextBox = .FindControl("txteAdd")
            Dim ddlCity As DropDownList = .FindControl("ddleCity")
            Dim txtContact As TextBox = .FindControl("txtEContact")
            Dim ddlQty As TextBox = .FindControl("ddlEQty")
            Dim ddlProd As DropDownList = .FindControl("ddlEProd")
            Dim ddlBrand As DropDownList = .FindControl("ddlEBrand")
            Dim ddlSCode As DropDownList = .FindControl("ddleSCode")
            'Dim ddlCap As DropDownList = .FindControl("ddlECap")
            'Dim ddlVariant As DropDownList = .FindControl("ddlEVariant")
            Dim ddlDP As DropDownList = .FindControl("ddlEDP")
            Dim txtSerial As TextBox = .FindControl("txtESerial")
            Dim txtInvoice As TextBox = .FindControl("txtEInvoice")
            Dim imbAUpdate As ImageButton = .FindControl("imbAUpdate")
            Dim imbACancel As ImageButton = .FindControl("imbACancel")

            If checkRequiredFld(ddlProd, ddlBrand, ddlSCode, txtInvoice, ddlDP, ddlQty, txtContact) = False Then
                Exit Sub

            Else
                Dim salesID As String = grdSales.DataKeys.Item(e.RowIndex).Value
                Session("salesEditIndex") = e.RowIndex

                Dim stat As Boolean = checkSalesIfComplete(txtFName, txtLName, txtAdd, ddlCity, txtContact, txtSerial)

                'If stat = False Then
                '    lbleMsg.Text = "Data is incomplete. Do you still want to save it?"
                '    imbYes.Visible = True
                '    imbNo.Visible = True
                '    Session("salesAct") = "edit"
                '    Exit Sub
                'End If

                updateRecord(salesID, txtFName, txtLName, txtAdd, ddlCity, txtContact, ddlQty, ddlSCode, ddlDP, txtSerial, txtInvoice, stat)
            End If

            'where = "userID = " & Session("userID")
            'conn.LoadToGrid("vw_Sales", grdSales, "*", where, "salesID", "")
            grdSales.DataBind()
        End With
    End Sub

    Protected Sub lnkCompete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkCompete.Click
		System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        panInfo.Visible = False
        panSales.Visible = False
        panCompete.Visible = True
        panStocks.Visible = False
        panInventory.Visible = False

        lnkProd.CssClass = "tabprop"
        lnkCompete.CssClass = "tabprop-Selected"
        lnkStocks.CssClass = "tabprop"
        lnkInventory.CssClass = "tabprop"

        'fetchSales()
        fetchCompete()
        'fetchStocks()
        'fetchInventory()

        'set date
        If Session("weekID") IsNot Nothing Then
            'Dim ddlaDP As DropDownList = grdSales.HeaderRow.FindControl("ddlaDP")
            Dim ddlaDate As DropDownList = grdCompetitor.HeaderRow.FindControl("ddlaCDate")
            'Dim ddlaWhen As DropDownList = grdStocks.HeaderRow.FindControl("ddlaWhen")

            With conn
                where = "weekID = " & Session("weekID")

                'ddlaDP.Items.Clear()
                'generateDate(ddlaDP)
                '.loadToDropDownList("tbl_WDay", ddlaDP, False, "*", where, "wDay", "wDay", "", "")

                ddlaDate.Items.Clear()
                'generateDate(ddlaDate)
                .loadToDropDownList("tbl_WDay", ddlaDate, False, "*", where, "wDay", "wDay", "", "")

                'ddlaWhen.Items.Clear()
                'generateDate(ddlaWhen)
                '.loadToDropDownList("tbl_WDay", ddlaWhen, False, "*", where, "wDay", "wDay", "", "")
            End With
        End If
    End Sub

    Protected Sub lnkProd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkProd.Click
		System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        panInfo.Visible = False
        panSales.Visible = True
        panCompete.Visible = False
        panStocks.Visible = False
        panInventory.Visible = False

        lnkProd.CssClass = "tabprop-Selected"
        lnkCompete.CssClass = "tabprop"
        lnkStocks.CssClass = "tabprop"
        lnkInventory.CssClass = "tabprop"

        fetchSales()
        'fetchCompete()
        'fetchStocks()
        'fetchInventory()

        'set date
        If Session("weekID") IsNot Nothing Then
            Dim ddlaDP As DropDownList = grdSales.HeaderRow.FindControl("ddlaDP")
            'Dim ddlaDate As DropDownList = grdCompetitor.HeaderRow.FindControl("ddlaCDate")
            'Dim ddlaWhen As DropDownList = grdStocks.HeaderRow.FindControl("ddlaWhen")

            With conn
                where = "weekID = " & Session("weekID")

                ddlaDP.Items.Clear()
                'generateDate(ddlaDP)
                .loadToDropDownList("tbl_WDay", ddlaDP, False, "*", where, "wDay", "wDay", "", "")

                'ddlaDate.Items.Clear()
                'generateDate(ddlaDate)
                '.loadToDropDownList("tbl_WDay", ddlaDate, False, "*", where, "wDay", "wDay", "", "")

                'ddlaWhen.Items.Clear()
                'generateDate(ddlaWhen)
                '.loadToDropDownList("tbl_WDay", ddlaWhen, False, "*", where, "wDay", "wDay", "", "")
            End With
        End If
    End Sub

    Private Sub grdCompetitor_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdCompetitor.RowCancelingEdit
		System.Threading.Thread.Sleep(500)
        grdCompetitor.EditIndex = -1
        grdCompetitor.DataBind()
    End Sub

	Protected Sub grdCompetitor_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdCompetitor.RowDataBound
		System.Threading.Thread.Sleep(500)

        If e.Row.RowType = DataControlRowType.Header Then
            Dim ddlACProduct As DropDownList = e.Row.FindControl("ddlACProduct")
            'Dim ddlABrand As DropDownList = e.Row.FindControl("ddlACBrand")
            Dim ddlACap As DropDownList = e.Row.FindControl("ddlACCap")
            Dim ddlADate As DropDownList = e.Row.FindControl("ddlACDate")

            If ddlACProduct IsNot Nothing Then
                conn.loadToDropDownList("tbl_CProduct", ddlACProduct, False, "*", "", "productID", "product", "productID", "")

                If ddlACProduct.Items.Item(0).Text.Trim <> "" Then
                    ddlACProduct.Items.Insert(0, "")
                End If
            End If

            'If ddlABrand IsNot Nothing Then
            '    conn.loadToDropDownList("tbl_CBrand", ddlABrand, False, "*", "", "cBrandID", "cBrand", "cBrand", "")

            '    If ddlABrand.Items.Item(0).Text.Trim <> "" Then
            '        ddlABrand.Items.Insert(0, "")
            '    End If
            'End If

            If ddlACap IsNot Nothing Then
                conn.loadToDropDownList("tbl_CCapacity", ddlACap, False, "*", "", "cCapacityID", "cCapacity", "cCapacityID", "")

                If ddlACap.Items.Item(0).Text.Trim <> "" Then
                    ddlACap.Items.Insert(0, "")
                End If
            End If

            If ddlADate IsNot Nothing Then
                ddlADate.Items.Clear()
                'generateDate(ddlADate)

                If Session("weekID") IsNot Nothing Then
                    where = "weekID = " & Session("weekID")
                    conn.loadToDropDownList("tbl_WDay", ddlADate, False, "*", where, "wDay", "wDay", "", "")

                    If ddlADate.Items.Item(0).Text.Trim <> "" Then
                        ddlADate.Items.Insert(0, "")
                    End If
                End If
            End If


        ElseIf e.Row.RowType = DataControlRowType.DataRow Then
            Dim ddlEBrand As DropDownList = e.Row.FindControl("ddlECBrand")
            Dim ddlECap As DropDownList = e.Row.FindControl("ddlECCap")
            Dim ddlEDate As DropDownList = e.Row.FindControl("ddlECDate")
            Dim lbleDate As Label = e.Row.FindControl("lbleCDate")
            Dim lbliDate As Label = e.Row.FindControl("lbliCDate")

            If ddlEBrand IsNot Nothing Then
                conn.loadToDropDownList("tbl_CBrand", ddlEBrand, False, "*", "", "cBrandID", "cBrand", "cBrand", "")

                If ddlEBrand.Items.Item(0).Text.Trim <> "" Then
                    ddlEBrand.Items.Insert(0, "")
                End If
            End If

            If ddlECap IsNot Nothing Then
                conn.loadToDropDownList("tbl_CCapacity", ddlECap, False, "*", "", "cCapacityID", "cCapacity", "cCapacityID", "")

                If ddlECap.Items.Item(0).Text.Trim <> "" Then
                    ddlECap.Items.Insert(0, "")
                End If
            End If

            If ddlEDate IsNot Nothing Then
                ddlEDate.Items.Clear()
                'generateDate(ddlEDate)

                If Session("weekID") IsNot Nothing Then
                    where = "weekID = " & Session("weekID")
                    conn.loadToDropDownList("tbl_WDay", ddlEDate, False, "*", where, "wDay", "wDay", "", "")

                    If ddlEDate.Items.Item(0).Text.Trim <> "" Then
                        ddlEDate.Items.Insert(0, "")
                    End If
                End If
            End If

            'If lbleDate IsNot Nothing Then
            '    If lbleDate.Text.Trim <> "" Then
            '        If IsDate(lbleDate.Text.Trim) = True Then
            '            lbleDate.Text = Format(CDate(lbleDate.Text.Trim), formatToShow)
            '        End If
            '    End If
            'End If

            'If lbliDate IsNot Nothing Then
            '    If lbliDate.Text.Trim <> "" Then
            '        If IsDate(lbliDate.Text.Trim) = True Then
            '            lbliDate.Text = Format(CDate(lbliDate.Text.Trim), formatToShow)
            '        End If
            '    End If
            'End If
        End If
    End Sub

    Protected Sub grdCompetitor_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdCompetitor.RowEditing
		System.Threading.Thread.Sleep(500)
        grdCompetitor.EditIndex = e.NewEditIndex
    End Sub

    Protected Sub grdCompetitor_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdCompetitor.RowUpdating
		System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        With grdCompetitor.Rows(e.RowIndex)
            Dim ddlCProduct As DropDownList = .FindControl("ddlACProduct")
            Dim ddlBrand As DropDownList = .FindControl("ddlECBrand")
            Dim ddlCap As DropDownList = .FindControl("ddlECCap")
            Dim ddlQty As TextBox = .FindControl("ddlECQty")
            Dim ddlDate As DropDownList = .FindControl("ddlECDate")
            Dim txtFactor As TextBox = .FindControl("txtEFactor")

            If checkCompete(ddlBrand, ddlCap, ddlQty, ddlDate, txtFactor) = False Then
                Exit Sub

            Else
                Dim competeID As String = grdCompetitor.DataKeys.Item(e.RowIndex).Value

                updateCompetitor(competeID, ddlCProduct, ddlBrand, ddlCap, ddlQty, ddlDate, txtFactor)
            End If

            grdCompetitor.DataBind()
        End With
    End Sub

    Protected Sub lnkSDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        With sender.namingcontainer
            Dim lnkDelete As LinkButton = sender
            Dim lblConfirm As Label = .findcontrol("lblSConfirm")
            Dim imbYes As ImageButton = .findcontrol("imbSYes")
            Dim imbNo As ImageButton = .findcontrol("imbSNo")
            Dim imbModify As ImageButton = .findcontrol("imbSModify")

            imbModify.ImageUrl = "~/images/icons/modify1.gif"
            imbModify.Enabled = False
            lnkDelete.CssClass = "deleteBtn1"
            lnkDelete.Enabled = False

            lblConfirm.Visible = True
            imbYes.Visible = True
            imbNo.Visible = True
        End With
    End Sub

    Protected Sub lnkIDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        With sender.namingcontainer
            Dim lnkDelete As LinkButton = sender
            Dim lblConfirm As Label = .findcontrol("lblIConfirm")
            Dim imbYes As ImageButton = .findcontrol("imbIYes")
            Dim imbNo As ImageButton = .findcontrol("imbINo")
            Dim imbModify As ImageButton = .findcontrol("imbIModify")

            imbModify.ImageUrl = "~/images/icons/modify1.gif"
            imbModify.Enabled = False
            lnkDelete.CssClass = "deleteBtn1"
            lnkDelete.Enabled = False

            lblConfirm.Visible = True
            imbYes.Visible = True
            imbNo.Visible = True
        End With
    End Sub

    Protected Sub lnkCDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
		System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        With sender.namingcontainer
            Dim lnkDelete As LinkButton = sender
            Dim lblConfirm As Label = .findcontrol("lblCConfirm")
            Dim imbYes As ImageButton = .findcontrol("imbCYes")
            Dim imbNo As ImageButton = .findcontrol("imbCNo")
            Dim imbModify As ImageButton = .findcontrol("imbCModify")

            imbModify.ImageUrl = "~/images/icons/modify1.gif"
            imbModify.Enabled = False
            lnkDelete.CssClass = "deleteBtn1"
            lnkDelete.Enabled = False

            lblConfirm.Visible = True
            imbYes.Visible = True
            imbNo.Visible = True
        End With
    End Sub

	Public Function checkCompete(ByVal ddlBrand As DropDownList, _
									ByVal ddlCap As DropDownList, _
									ByVal ddlQty As TextBox, _
									ByVal ddlDate As DropDownList, _
                                    ByVal txtFactor As TextBox) As Boolean

		checkCompete = True

		If ddlBrand.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Brand is a required field."
			checkCompete = False
			Exit Function
		End If

		If ddlCap.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Capacity is a required field."
			checkCompete = False
			Exit Function
		End If

		If ddlQty.Text.Trim = "" Then
			lbleMsg.Text = "Quantity is a required field."
			checkCompete = False
			Exit Function

		ElseIf IsNumeric(ddlQty.Text.Trim) = False Then
			lbleMsg.Text = "Quantity should be numeric."
			checkCompete = False
			Exit Function
		End If

		If ddlDate.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Date is a required field."
			checkCompete = False
			Exit Function
		End If

		If txtFactor.Text.Trim = "" Then
			lbleMsg.Text = "Factors affecting sell out is a required field."
			checkCompete = False
			Exit Function
		End If
	End Function

	Public Function checkStocks(ByVal ddlProd As DropDownList, _
									ByVal ddlBrand As DropDownList, _
									ByVal ddlSCode As DropDownList, _
									ByVal ddlAction As DropDownList, _
									ByVal txtOthers As TextBox, _
									ByVal txtPromo As TextBox, _
									ByVal ddlDate As DropDownList) As Boolean

		checkStocks = True

		If ddlProd.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Product is a required field."
			checkStocks = False
			Exit Function
		End If

		If ddlBrand.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Brand is a required field."
			checkStocks = False
			Exit Function
		End If

		If ddlSCode.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Short Code is required."
			checkStocks = False
			Exit Function
		End If

		'If ddlCap.SelectedValue.Trim = "" Then
		'    lbleMsg.Text = "Capacity is a required field."
		'    checkStocks = False
		'    Exit Function
		'End If

		'If ddlVariant.SelectedValue.Trim = "" Then
		'    lbleMsg.Text = "Variant is a required field."
		'    checkStocks = False
		'    Exit Function
		'End If

		If ddlDate.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Date is a required field."
			checkStocks = False
			Exit Function
		End If

		If ddlAction.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Action Taken is a required field."
			checkStocks = False
			Exit Function

		ElseIf ddlAction.SelectedItem.Text.Trim = "Others" Then
			If txtOthers.Text.Trim = "" Then
				lbleMsg.Text = "Kindly type the action taken."
				checkStocks = False
				Exit Function
			End If
		End If

		If txtPromo.Text.Trim = "" Then
			lbleMsg.Text = "Competitor Promo Activites is a required field."
			checkStocks = False
			Exit Function
		End If
	End Function

	Public Function checkInventory(ByVal ddlProd As DropDownList, _
									ByVal ddlBrand As DropDownList, _
									ByVal ddlSCode As DropDownList, _
									ByVal ddlQty As TextBox) As Boolean

		checkInventory = True

		If ddlProd.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Product is a required field."
			checkInventory = False
			Exit Function
		End If

		If ddlBrand.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Brand is a required field."
			checkInventory = False
			Exit Function
		End If

		If ddlSCode.SelectedValue.Trim = "" Then
			lbleMsg.Text = "Short Code is required."
			checkInventory = False
			Exit Function
		End If

		'If ddlCap.SelectedValue.Trim = "" Then
		'    lbleMsg.Text = "Capacity is a required field."
		'    checkInventory = False
		'    Exit Function
		'End If

		'If ddlVariant.SelectedValue.Trim = "" Then
		'    lbleMsg.Text = "Variant is a required field."
		'    checkInventory = False
		'    Exit Function
		'End If

		If ddlQty.Text.Trim = "" Then
			lbleMsg.Text = "Qty is a required field."
			checkInventory = False
			Exit Function

		ElseIf IsNumeric(ddlQty.Text.Trim) = False Then
			lbleMsg.Text = "Qty should be numeric."
			checkInventory = False
			Exit Function
		End If

		'If ddlLoc.SelectedValue.Trim = "" Then
		'    lbleMsg.Text = "Location is a required field."
		'    checkInventory = False
		'    Exit Function
		'End If
	End Function

    Public Sub updateCompetitor(ByVal recNo As String, _
                                    ByVal ddlCProduct As DropDownList, _
                                    ByVal ddlBrand As DropDownList, _
                                    ByVal ddlCap As DropDownList, _
                                    ByVal ddlQty As TextBox, _
                                    ByVal ddlDate As DropDownList, _
                                       ByVal txtFactor As TextBox)

        With conn
            Dim fld(5), val(5), dt(5) As String

            fld(0) = "cBrandID"
            fld(1) = "qty"
            fld(2) = "csDate"
            fld(3) = "factor"
            fld(4) = "cCapacityID"
            fld(5) = "cProductID"

            dt(0) = "N"
            dt(1) = "N"
            dt(2) = "C"
            dt(3) = "C"
            dt(4) = "N"
            dt(5) = "N"

            val(0) = ddlBrand.SelectedValue.Trim

            If ddlQty.Text.Trim = "" Or IsNumeric(ddlQty.Text.Trim) = False Then
                val(1) = "0"
            Else
                val(1) = ddlQty.Text.Trim
            End If

            If ddlDate.SelectedValue.Trim = "" Then
                val(2) = ""
            Else
                val(2) = ddlDate.SelectedValue.Trim
            End If

            val(3) = Replace(txtFactor.Text.Trim, "'", "''")

            If ddlCap.SelectedValue.Trim = "" Then
                val(4) = ""
            Else
                val(4) = ddlCap.SelectedValue.Trim
            End If

            If ddlCProduct.SelectedValue.Trim = "" Then
                val(5) = ""
            Else
                val(5) = ddlCProduct.SelectedValue.Trim
            End If

            where = "competeID = " & recNo
            .UpdateDB("tbl_Competitor", fld, val, dt, where)
        End With
    End Sub

	Public Sub saveCompetitor(ByVal ddlBrand As DropDownList, ByVal ddlCap As DropDownList, ByVal ddlQty As TextBox, _
                                ByVal ddlDate As DropDownList, ByVal txtFactor As TextBox)

		With conn
            field = "cBrandID, qty, csDate, factor, userID, weekID, cCapacityID"
			values = ddlBrand.SelectedValue.Trim & ", "

			If ddlQty.Text.Trim = "" Or IsNumeric(ddlQty.Text.Trim) = False Then
				values += "0, '"
			Else
				values += ddlQty.Text.Trim & ", '"
			End If

			If ddlDate.SelectedValue.Trim = "" Then
				values += "', '"
			Else
				values += ddlDate.SelectedValue.Trim & "', '"
			End If

			values += Replace(txtFactor.Text.Trim, "'", "''") & "', " & Session("userID") & ", " _
						& ddlWeek.SelectedValue.Trim & ", "

			If ddlCap.SelectedValue.Trim = "" Then
                values += "0"
			Else
                values += ddlCap.SelectedValue.Trim
			End If

			.saveInfo("tbl_Competitor", field, values)
		End With
	End Sub

	Protected Sub lnkStocks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkStocks.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		panInfo.Visible = False
		panSales.Visible = False
		panCompete.Visible = False
		panStocks.Visible = True
		panInventory.Visible = False

		lnkProd.CssClass = "tabprop"
		lnkCompete.CssClass = "tabprop"
		lnkStocks.CssClass = "tabprop-Selected"
		lnkInventory.CssClass = "tabprop"

		'fetchSales()
		'fetchCompete()
		fetchStocks()
		'fetchInventory()

		'set date
		If Session("weekID") IsNot Nothing Then
			'Dim ddlaDP As DropDownList = grdSales.HeaderRow.FindControl("ddlaDP")
			'Dim ddlaDate As DropDownList = grdCompetitor.HeaderRow.FindControl("ddlaCDate")
			Dim ddlaWhen As DropDownList = grdStocks.HeaderRow.FindControl("ddlaWhen")

			With conn
				where = "weekID = " & Session("weekID")

				'ddlaDP.Items.Clear()
				'generateDate(ddlaDP)
				'.loadToDropDownList("tbl_WDay", ddlaDP, False, "*", where, "wDay", "wDay", "", "")

				'ddlaDate.Items.Clear()
				'generateDate(ddlaDate)
				'.loadToDropDownList("tbl_WDay", ddlaDate, False, "*", where, "wDay", "wDay", "", "")

				ddlaWhen.Items.Clear()
				'generateDate(ddlaWhen)
				.loadToDropDownList("tbl_WDay", ddlaWhen, False, "*", where, "wDay", "wDay", "", "")
			End With
		End If
	End Sub

	Protected Sub lnkInventory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkInventory.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		panInfo.Visible = False
		panSales.Visible = False
		panCompete.Visible = False
		panStocks.Visible = False
		panInventory.Visible = True

		lnkProd.CssClass = "tabprop"
		lnkCompete.CssClass = "tabprop"
		lnkStocks.CssClass = "tabprop"
		lnkInventory.CssClass = "tabprop-Selected"

		'fetchSales()
		'fetchCompete()
		'fetchStocks()
		fetchInventory()
	End Sub

	Private Sub grdStocks_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdStocks.RowCancelingEdit
		System.Threading.Thread.Sleep(500)
		grdStocks.EditIndex = -1
		grdStocks.DataBind()
	End Sub

	Protected Sub grdStocks_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdStocks.RowDataBound
		System.Threading.Thread.Sleep(500)

		If e.Row.RowType = DataControlRowType.Header Then
			Dim ddlAProd As DropDownList = e.Row.FindControl("ddlASProd")
			Dim ddlAWhen As DropDownList = e.Row.FindControl("ddlAWhen")
			Dim ddlAAction As DropDownList = e.Row.FindControl("ddlAAction")

			If ddlAProd IsNot Nothing Then
				conn.loadToDropDownList("tbl_Product", ddlAProd, False, "*", "", "productID", "product", "product", "")

				If ddlAProd.Items.Item(0).Text.Trim <> "" Then
					ddlAProd.Items.Insert(0, "")
				End If
			End If

			If ddlAWhen IsNot Nothing Then
				ddlAWhen.Items.Clear()
				'generateDate(ddlAWhen)

				If Session("weekID") IsNot Nothing Then
					where = "weekID = " & Session("weekID")
					conn.loadToDropDownList("tbl_WDay", ddlAWhen, False, "*", where, "wDay", "wDay", "", "")

					If ddlAWhen.Items.Item(0).Text.Trim <> "" Then
						ddlAWhen.Items.Insert(0, "")
					End If
				End If
			End If

			If ddlAAction IsNot Nothing Then
				conn.loadToDropDownList("tbl_Action", ddlAAction, False, "*", "", "actionID", "actionTaken", "actionTaken", "")

				If ddlAAction.Items.Item(0).Text.Trim <> "" Then
					ddlAAction.Items.Insert(0, "")
				End If
			End If


		ElseIf e.Row.RowType = DataControlRowType.DataRow Then
			Dim ddlEProd As DropDownList = e.Row.FindControl("ddlESProd")
			Dim ddleWhen As DropDownList = e.Row.FindControl("ddleWhen")
			Dim ddleAction As DropDownList = e.Row.FindControl("ddleAction")
			Dim lbleWhen As Label = e.Row.FindControl("lbleWhen")
			Dim lbliWhen As Label = e.Row.FindControl("lbliWhen")

			If ddlEProd IsNot Nothing Then
				conn.loadToDropDownList("tbl_Product", ddlEProd, False, "*", "", "productID", "product", "product", "")

				If ddlEProd.Items.Item(0).Text.Trim <> "" Then
					ddlEProd.Items.Insert(0, "")
				End If
			End If

			If ddleWhen IsNot Nothing Then
				ddleWhen.Items.Clear()
				'generateDate(ddleWhen)

				If Session("weekID") IsNot Nothing Then
					where = "weekID = " & Session("weekID")
					conn.loadToDropDownList("tbl_WDay", ddleWhen, False, "*", where, "wDay", "wDay", "", "")

					If ddleWhen.Items.Item(0).Text.Trim <> "" Then
						ddleWhen.Items.Insert(0, "")
					End If
				End If
			End If

			If ddleAction IsNot Nothing Then
				conn.loadToDropDownList("tbl_Action", ddleAction, False, "*", "", "actionID", "actionTaken", "actionTaken", "")

				If ddleAction.Items.Item(0).Text.Trim <> "" Then
					ddleAction.Items.Insert(0, "")
				End If
			End If

			'If lbleWhen IsNot Nothing Then
			'    If lbleWhen.Text.Trim <> "" Then
			'        If IsDate(lbleWhen.Text.Trim) = True Then
			'            lbleWhen.Text = Format(CDate(lbleWhen.Text.Trim), formatToShow)
			'        End If
			'    End If
			'End If

			'If lbliWhen IsNot Nothing Then
			'    If lbliWhen.Text.Trim <> "" Then
			'        If IsDate(lbliWhen.Text.Trim) = True Then
			'            lbliWhen.Text = Format(CDate(lbliWhen.Text.Trim), formatToShow)
			'        End If
			'    End If
			'End If
		End If
	End Sub

	Private Sub grdInventory_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles grdInventory.RowCancelingEdit
		System.Threading.Thread.Sleep(500)
		grdInventory.EditIndex = -1
		grdInventory.DataBind()
	End Sub

	Protected Sub grdInventory_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdInventory.RowDataBound
		System.Threading.Thread.Sleep(500)

		If e.Row.RowType = DataControlRowType.Header Then
			Dim ddlAProd As DropDownList = e.Row.FindControl("ddlaIProd")
			Dim ddlALocation As DropDownList = e.Row.FindControl("ddlaLoc")

			If ddlAProd IsNot Nothing Then
				conn.loadToDropDownList("tbl_Product", ddlAProd, False, "*", "", "productID", "product", "product", "")

				If ddlAProd.Items.Item(0).Text.Trim <> "" Then
					ddlAProd.Items.Insert(0, "")
				End If
			End If

			If ddlALocation IsNot Nothing Then
				conn.loadToDropDownList("tbl_Location", ddlALocation, False, "*", "", "locationID", "location", "location", "")

				If ddlALocation.Items.Item(0).Text.Trim <> "" Then
					ddlALocation.Items.Insert(0, "")
				End If
			End If

		ElseIf e.Row.RowType = DataControlRowType.DataRow Then
			Dim ddlEProd As DropDownList = e.Row.FindControl("ddleIProd")
			Dim ddlELocation As DropDownList = e.Row.FindControl("ddleLoc")

			If ddlEProd IsNot Nothing Then
				conn.loadToDropDownList("tbl_Product", ddlEProd, False, "*", "", "productID", "product", "product", "")

				If ddlEProd.Items.Item(0).Text.Trim <> "" Then
					ddlEProd.Items.Insert(0, "")
				End If
			End If

			If ddlELocation IsNot Nothing Then
				conn.loadToDropDownList("tbl_Location", ddlELocation, False, "*", "", "locationID", "location", "location", "")

				If ddlELocation.Items.Item(0).Text.Trim <> "" Then
					ddlELocation.Items.Insert(0, "")
				End If
			End If
		End If
	End Sub

	Protected Sub imbISave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim imbSave As ImageButton = sender
		Dim ddlProd As DropDownList = sender.namingcontainer.FindControl("ddlaIProd")
		Dim ddlBrand As DropDownList = sender.namingcontainer.FindControl("ddlaIBrand")
		Dim ddlSCode As DropDownList = sender.namingcontainer.FindControl("ddlaISCode")
		'Dim ddlCap As DropDownList = sender.namingcontainer.FindControl("ddlaICap")
		'Dim ddlVariant As DropDownList = sender.namingcontainer.FindControl("ddlaIVariant")
		Dim ddlQty As TextBox = sender.namingcontainer.FindControl("ddlaIQty")
		'Dim ddlLoc As DropDownList = sender.namingcontainer.FindControl("ddlaLoc")
		Dim txtComments As TextBox = sender.namingcontainer.FindControl("txtaComments")

		If checkInventory(ddlProd, ddlBrand, ddlSCode, ddlQty) = False Then
			Exit Sub

		Else
			With conn
				Dim retFld(1), retVal(1) As String
				retFld(0) = "inventoryID"
				retFld(1) = "itemID"

				where = "userID = " & Session("userID")
				.getRecords("tbl_Inventory", "*", where, 2, retFld, retVal, "inventoryID", "")

				Dim num() As String = Split(retVal(0), "+")
				Dim item() As String = Split(retVal(1), "+")
				Dim saveStat As Boolean = False
				cnt = 1
				counter = 0

				If retVal(0) = "" Then
					saveInventory(ddlSCode, ddlQty, txtComments)

				Else
					Do While cnt <= UBound(num) + 1
						If item(counter) = "" Then
							updateInventory(num(counter), ddlSCode, ddlQty, txtComments)
							saveStat = True

							grdInventory.DataBind()
							Exit Sub
						End If
						cnt += 1
						counter += 1
					Loop

					If saveStat = False Then
						saveInventory(ddlSCode, ddlQty, txtComments)

						grdInventory.DataBind()
					End If
				End If
			End With
		End If
	End Sub

	Public Sub updateStocks(ByVal recNo As String, ByVal ddlSCode As DropDownList, _
									ByVal ddlWhen As DropDownList, ByVal txtPromo As TextBox, _
									ByVal ddlAction As DropDownList, ByVal txtOthers As TextBox)

		With conn
			Dim fld(4), val(4), dt(4) As String

			fld(0) = "itemID"
			fld(1) = "dWhen"
			fld(2) = "actionID"
			fld(3) = "promo"
			fld(4) = "otherAct"

			dt(0) = "N"
			dt(1) = "C"
			dt(2) = "C"
			dt(3) = "C"
			dt(4) = "C"

			val(0) = ddlSCode.SelectedValue.Trim

			If ddlWhen.SelectedValue.Trim = "" Then
				val(1) = ""
			Else
				val(1) = ddlWhen.Text.Trim
			End If

			If ddlAction.SelectedValue.Trim = "" Then
				val(2) = ""
				val(4) = ""

			ElseIf ddlAction.SelectedItem.Text.Trim = "Others" Then
				val(2) = ddlAction.SelectedValue.Trim
				val(4) = Replace(txtOthers.Text, "'", "''")

			Else
				val(2) = ddlAction.SelectedValue.Trim
				val(4) = ""
			End If

			val(3) = Replace(txtPromo.Text.Trim, "'", "''")

			where = "stocksID = " & recNo
			.UpdateDB("tbl_Stocks", fld, val, dt, where)
		End With
	End Sub

	Public Sub updateInventory(ByVal recNo As String, ByVal ddlSCode As DropDownList, _
									ByVal ddlQty As TextBox, ByVal txtComments As TextBox)

		With conn
			Dim fld(2), val(2), dt(2) As String

			fld(0) = "itemID"
			fld(1) = "qty"
			fld(2) = "comments"

			dt(0) = "N"
			dt(1) = "N"
			dt(2) = "C"

			If ddlSCode.SelectedValue.Trim = "" Then
				val(0) = ddlSCode.SelectedValue.Trim
			Else
				val(0) = ddlSCode.SelectedValue.Trim
			End If

			If ddlQty.Text.Trim = "" Or IsNumeric(ddlQty.Text.Trim) = False Then
				val(1) = "0"
			Else
				val(1) = ddlQty.Text.Trim
			End If

			val(2) = Replace(txtComments.Text.Trim, "'", "''")

			where = "inventoryID = " & recNo
			.UpdateDB("tbl_Inventory", fld, val, dt, where)
		End With
	End Sub

	Public Sub saveStocks(ByVal ddlSCode As DropDownList, _
							ByVal ddlAction As DropDownList, ByVal txtOthers As TextBox, _
							ByVal ddlWhen As DropDownList, ByVal txtPromo As TextBox)
		With conn
			field = "itemID, dWhen, actionID, otherAct, promo, userID, weekID"
			values = ddlSCode.SelectedValue.Trim & ", '"

			If ddlWhen.SelectedValue.Trim = "" Then
				values += "', "
			Else
				values += ddlWhen.SelectedValue.Trim & "', "
			End If

			If ddlAction.SelectedValue.Trim = "" Then
				values += "0, '', '"
			ElseIf ddlAction.SelectedItem.Text = "Others" Then
				values += ddlAction.SelectedValue.Trim & ", '" & Replace(txtOthers.Text.Trim, "'", "''") & "', '"
			Else
				values += ddlAction.SelectedValue.Trim & ", '', '"
			End If

			values += Replace(txtPromo.Text.Trim, "'", "''") & "', " & Session("userID") & ", " _
						& ddlWeek.SelectedValue.Trim

			.saveInfo("tbl_Stocks", field, values)
		End With
	End Sub

	Public Sub saveInventory(ByVal ddlSCode As DropDownList, ByVal ddlQty As TextBox, ByVal txtComments As TextBox)

		With conn
			field = "itemID, qty, comments, " _
						& "userID, weekID"

			If ddlSCode.SelectedValue.Trim = "" Then
				values = "0, "
			Else
				values = ddlSCode.SelectedValue.Trim & ", "
			End If

			If ddlQty.Text.Trim = "" Or IsNumeric(ddlQty.Text.Trim) = False Then
				values += "0, "
			Else
				values += ddlQty.Text.Trim & ", "
			End If

			values += Replace(txtComments.Text.Trim, "'", "''") & "', " _
						& Session("userID") & ", " _
						& ddlWeek.SelectedValue.Trim

			.saveInfo("tbl_Inventory", field, values)
		End With
	End Sub

	Protected Sub imbSSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim imbSave As ImageButton = sender
		Dim ddlProd As DropDownList = sender.namingcontainer.FindControl("ddlaSProd")
		Dim ddlBrand As DropDownList = sender.namingcontainer.FindControl("ddlaSBrand")
		Dim ddlSCode As DropDownList = sender.namingcontainer.FindControl("ddlaSSCode")
		'Dim ddlCap As DropDownList = sender.namingcontainer.FindControl("ddlaSCap")
		'Dim ddlVariant As DropDownList = sender.namingcontainer.FindControl("ddlaSVariant")
		Dim ddlWhen As DropDownList = sender.namingcontainer.FindControl("ddlAWhen")
		Dim ddlAction As DropDownList = sender.namingcontainer.FindControl("ddlAAction")
		Dim txtOthers As TextBox = sender.namingcontainer.FindControl("txtaAction")
		Dim txtPromo As TextBox = sender.namingcontainer.FindControl("txtAPromo")

		If checkStocks(ddlProd, ddlBrand, ddlSCode, ddlAction, txtOthers, txtPromo, ddlWhen) = False Then
			Exit Sub
			'
		Else
			With conn
				Dim retFld(1), retVal(1) As String
				retFld(0) = "stocksID"
				retFld(1) = "itemID"

				where = "userID = " & Session("userID")
				.getRecords("tbl_Stocks", "*", where, 2, retFld, retVal, "stocksID", "")

				Dim num() As String = Split(retVal(0), "+")
				Dim item() As String = Split(retVal(1), "+")
				Dim saveStat As Boolean = False
				cnt = 1
				counter = 0

				If retVal(0) = "" Then
					saveStocks(ddlSCode, ddlAction, txtOthers, ddlWhen, txtPromo)

				Else
					Do While cnt <= UBound(num) + 1
						If item(counter) = "" Then
							updateStocks(num(counter), ddlSCode, ddlWhen, txtPromo, ddlAction, txtOthers)
							saveStat = True

							grdStocks.DataBind()
							Exit Sub
						End If
						cnt += 1
						counter += 1
					Loop

					If saveStat = False Then
						saveStocks(ddlSCode, ddlAction, txtOthers, ddlWhen, txtPromo)

						grdStocks.DataBind()
					End If
				End If
			End With
		End If
	End Sub

	Protected Sub imbCSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

        Dim imbSave As ImageButton = sender
        Dim ddlACProduct As DropDownList = sender.namingcontainer.FindControl("ddlACProduct")
		Dim ddlBrand As DropDownList = sender.namingcontainer.FindControl("ddlaCBrand")
		Dim ddlCap As DropDownList = sender.namingcontainer.FindControl("ddlaCCap")
		Dim ddlQty As TextBox = sender.namingcontainer.FindControl("ddlACQty")
		Dim ddlDate As DropDownList = sender.namingcontainer.FindControl("ddlACDate")
		Dim txtFactor As TextBox = sender.namingcontainer.FindControl("txtAFactor")

        If checkCompete(ddlBrand, ddlCap, ddlQty, ddlDate, txtFactor) = False Then
			Exit Sub

		Else
			With conn
				Dim retFld(1), retVal(1) As String
				retFld(0) = "competeID"
				retFld(1) = "cBrandID"

				where = "userID = " & Session("userID")
				.getRecords("tbl_Competitor", "*", where, 2, retFld, retVal, "competeID", "")

				Dim num() As String = Split(retVal(0), "+")
				Dim brand() As String = Split(retVal(1), "+")
				Dim saveStat As Boolean = False
				cnt = 1
				counter = 0

				If retVal(0) = "" Then
                    saveCompetitor(ddlBrand, ddlCap, ddlQty, ddlDate, txtFactor)

				Else
					Do While cnt <= UBound(num) + 1
						If brand(counter) = "" Then
                            updateCompetitor(num(counter), ddlACProduct, ddlBrand, ddlCap, ddlQty, ddlDate, txtFactor)
							saveStat = True

							grdCompetitor.DataBind()
							Exit Sub
						End If
						cnt += 1
						counter += 1
					Loop

					If saveStat = False Then
                        saveCompetitor(ddlBrand, ddlCap, ddlQty, ddlDate, txtFactor)

						grdCompetitor.DataBind()
					End If
				End If
			End With
		End If
	End Sub

	Protected Sub imbCNo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)

		With sender.namingcontainer
			Dim imbNo As ImageButton = sender
			Dim lblConfirm As Label = .findcontrol("lblCConfirm")
			Dim imbYes As ImageButton = .findcontrol("imbCYes")
			Dim lnkDelete As LinkButton = .findcontrol("lnkCDelete")
			Dim imbModify As ImageButton = .findcontrol("imbCModify")

			lblConfirm.Visible = False
			imbYes.Visible = False
			imbNo.Visible = False

			lnkDelete.CssClass = "deleteBtn"
			imbModify.ImageUrl = "~/images/icons/modify.png"
			lnkDelete.Enabled = True
			imbModify.Enabled = True
		End With
	End Sub

	Protected Sub imbCYes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim lnkDelete As LinkButton = sender.namingcontainer.findcontrol("lnkCDelete")

		conn.deleteRecord("tbl_Competitor", "competeID = " & Convert.ToInt32(lnkDelete.CommandArgument))
		grdCompetitor.DataBind()

		'check if rec < 10
		If grdCompetitor.Rows.Count < 10 Then
			fetchCompete()
		End If
	End Sub

	Protected Sub imbSYes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim lnkDelete As LinkButton = sender.namingcontainer.findcontrol("lnkSDelete")

		conn.deleteRecord("tbl_Stocks", "stocksID = " & Convert.ToInt32(lnkDelete.CommandArgument))
		grdStocks.DataBind()

		'check if rec < 10
		If grdStocks.Rows.Count < 10 Then
			fetchStocks()
		End If
	End Sub

	Protected Sub imbSNo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		With sender.namingcontainer
			Dim imbNo As ImageButton = sender
			Dim lblConfirm As Label = .findcontrol("lblSConfirm")
			Dim imbYes As ImageButton = .findcontrol("imbSYes")
			Dim lnkDelete As LinkButton = .findcontrol("lnkSDelete")
			Dim imbModify As ImageButton = .findcontrol("imbSModify")

			lblConfirm.Visible = False
			imbYes.Visible = False
			imbNo.Visible = False

			lnkDelete.CssClass = "deleteBtn"
			imbModify.ImageUrl = "~/images/icons/modify.png"
			lnkDelete.Enabled = True
			imbModify.Enabled = True
		End With
	End Sub

	Protected Sub imbIYes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim lnkDelete As LinkButton = sender.namingcontainer.findcontrol("lnkIDelete")

		conn.deleteRecord("tbl_Inventory", "inventoryID = " & Convert.ToInt32(lnkDelete.CommandArgument))
		grdInventory.DataBind()

		'check if rec < 10
		If grdInventory.Rows.Count < 10 Then
			fetchInventory()
		End If
	End Sub

	Protected Sub imbINo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		With sender.namingcontainer
			Dim imbNo As ImageButton = sender
			Dim lblConfirm As Label = .findcontrol("lblIConfirm")
			Dim imbYes As ImageButton = .findcontrol("imbIYes")
			Dim lnkDelete As LinkButton = .findcontrol("lnkIDelete")
			Dim imbModify As ImageButton = .findcontrol("imbIModify")

			lblConfirm.Visible = False
			imbYes.Visible = False
			imbNo.Visible = False

			lnkDelete.CssClass = "deleteBtn"
			imbModify.ImageUrl = "~/images/icons/modify.png"
			lnkDelete.Enabled = True
			imbModify.Enabled = True
		End With
	End Sub

	Protected Sub imbAYes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim lnkDelete As LinkButton = sender.namingcontainer.findcontrol("lnkADelete")

		conn.deleteRecord("tbl_Sales", "salesID = " & Convert.ToInt32(lnkDelete.CommandArgument))

		'where = "userID = " & Session("userID")
		'conn.LoadToGrid("vw_Sales", grdSales, "*", where, "salesID", "")
		grdSales.DataBind()

		'check if rec < 10
		If grdSales.Rows.Count < 10 Then
			fetchSales()
		End If
	End Sub

	Protected Sub imbANo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		With sender.namingcontainer
			Dim imbNo As ImageButton = sender
			Dim lblConfirm As Label = .findcontrol("lblAConfirm")
			Dim imbYes As ImageButton = .findcontrol("imbAYes")
			Dim lnkDelete As LinkButton = .findcontrol("lnkADelete")
			Dim imbModify As ImageButton = .findcontrol("imbAModify")

			lblConfirm.Visible = False
			imbYes.Visible = False
			imbNo.Visible = False

			lnkDelete.CssClass = "deleteBtn"
			imbModify.ImageUrl = "~/images/icons/modify.png"
			lnkDelete.Enabled = True
			imbModify.Enabled = True
		End With
	End Sub

	Protected Sub lnkADelete_Click(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		With sender.namingcontainer
			Dim lnkDelete As LinkButton = sender
			Dim lblConfirm As Label = .findcontrol("lblAConfirm")
			Dim imbYes As ImageButton = .findcontrol("imbAYes")
			Dim imbNo As ImageButton = .findcontrol("imbANo")
			Dim imbModify As ImageButton = .findcontrol("imbAModify")

			imbModify.ImageUrl = "~/images/icons/modify1.gif"
			imbModify.Enabled = False
			lnkDelete.CssClass = "deleteBtn1"
			lnkDelete.Enabled = False

			lblConfirm.Visible = True
			imbYes.Visible = True
			imbNo.Visible = True
		End With
	End Sub

	Private Sub grdStocks_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdStocks.RowEditing
		System.Threading.Thread.Sleep(500)
		grdStocks.EditIndex = e.NewEditIndex
	End Sub

	Private Sub grdStocks_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdStocks.RowUpdating
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		With grdStocks.Rows(e.RowIndex)
			Dim ddlProd As DropDownList = .FindControl("ddlESProd")
			Dim ddlBrand As DropDownList = .FindControl("ddlESBrand")
			Dim ddlSCode As DropDownList = .FindControl("ddlESSCode")
			Dim ddlCap As DropDownList = .FindControl("ddlESCap")
			Dim ddlVariant As DropDownList = .FindControl("ddlESVariant")
			Dim ddlAction As DropDownList = .FindControl("ddlEAction")
			Dim txtOthers As TextBox = .FindControl("txteAction")
			Dim ddlDate As DropDownList = .FindControl("ddlEWhen")
			Dim txtPromo As TextBox = .FindControl("txtEPromo")

			If checkStocks(ddlProd, ddlBrand, ddlSCode, ddlAction, txtOthers, txtPromo, ddlDate) = False Then
				Exit Sub

			Else
				Dim stocksID As String = grdStocks.DataKeys.Item(e.RowIndex).Value

				updateStocks(stocksID, ddlSCode, ddlDate, txtPromo, ddlAction, txtOthers)
			End If

			grdStocks.DataBind()
		End With
	End Sub

	Private Sub grdInventory_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdInventory.RowEditing
		System.Threading.Thread.Sleep(500)
		grdInventory.EditIndex = e.NewEditIndex
	End Sub

	Private Sub grdInventory_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles grdInventory.RowUpdating
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		With grdInventory.Rows(e.RowIndex)
			Dim ddlProd As DropDownList = .FindControl("ddleIProd")
			Dim ddlBrand As DropDownList = .FindControl("ddleIBrand")
			Dim ddlSCode As DropDownList = .FindControl("ddleISCode")
			Dim ddlCap As DropDownList = .FindControl("ddleICap")
			Dim ddlVariant As DropDownList = .FindControl("ddleIVariant")
			Dim ddlQty As TextBox = .FindControl("ddleIQty")
			Dim ddlLoc As DropDownList = .FindControl("ddleLoc")
			Dim txtComments As TextBox = .FindControl("txteComments")

			If checkInventory(ddlProd, ddlBrand, ddlSCode, ddlQty) = False Then
				Exit Sub

			Else
				Dim inventoryID As String = grdInventory.DataKeys.Item(e.RowIndex).Value

				updateInventory(inventoryID, ddlSCode, ddlQty, txtComments)
			End If

			grdInventory.DataBind()
		End With
	End Sub

	Protected Sub txtECust_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
		With sender.namingcontainer
			Dim oTxt As TextBox = sender
			Dim lblStatus As Label = .findcontrol("lbleStatus")

			If oTxt.Text = "" Then
				oTxt.BackColor = bgEColor
				lblStatus.Text = "Incomplete"
			Else
				oTxt.BackColor = bgVColor
			End If
		End With
	End Sub

	Protected Sub txtACustomer_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim oTxt As TextBox = sender
		Dim lblStatus As Label = sender.namingcontainer.findcontrol("lblaStatus")

		If oTxt.Text = "" Then
			oTxt.BackColor = bgEColor
			lblStatus.Text = "Incomplete"
		Else
			oTxt.BackColor = bgVColor
		End If
	End Sub

	Protected Sub txtEAdd_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim oTxt As TextBox = sender
		Dim lblStatus As Label = sender.namingcontainer.findcontrol("lbleStatus")

		If oTxt.Text = "" Then
			oTxt.BackColor = bgEColor
			lblStatus.Text = "Incomplete"
		Else
			oTxt.BackColor = bgVColor
		End If
	End Sub

	Protected Sub txtAAdd_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim oTxt As TextBox = sender
		Dim lblStatus As Label = sender.namingcontainer.findcontrol("lblaStatus")

		If oTxt.Text = "" Then
			oTxt.BackColor = bgEColor
			lblStatus.Text = "Incomplete"
		Else
			oTxt.BackColor = bgVColor
		End If
	End Sub

	Protected Sub txtEContact_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim oTxt As TextBox = sender
		Dim lblStatus As Label = sender.namingcontainer.findcontrol("lbleStatus")

		If oTxt.Text = "" Then
			oTxt.BackColor = bgEColor
			lblStatus.Text = "Incomplete"
		Else
			oTxt.BackColor = bgVColor
		End If
	End Sub

	Protected Sub txtAContact_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim oTxt As TextBox = sender
		Dim lblStatus As Label = sender.namingcontainer.findcontrol("lblaStatus")

		If oTxt.Text = "" Then
			oTxt.BackColor = bgEColor
			lblStatus.Text = "Incomplete"
		Else
			oTxt.BackColor = bgVColor
		End If
	End Sub

	Protected Sub txtASerial_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim oTxt As TextBox = sender
		Dim lblStatus As Label = sender.namingcontainer.findcontrol("lblaStatus")

		If oTxt.Text = "" Then
			oTxt.BackColor = bgEColor
			lblStatus.Text = "Incomplete"
		Else
			oTxt.BackColor = bgVColor
		End If
	End Sub

	Protected Sub txtESerial_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim oTxt As TextBox = sender
		Dim lblStatus As Label = sender.namingcontainer.findcontrol("lbleStatus")

		If oTxt.Text = "" Then
			oTxt.BackColor = bgEColor
			lblStatus.Text = "Incomplete"
		Else
			oTxt.BackColor = bgVColor
		End If
	End Sub

	Protected Sub ddlESProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim ddlProd As DropDownList = sender
		Dim ddlBrand As DropDownList = sender.namingcontainer.FindControl("ddlESBrand")
		Dim ddlSCode As DropDownList = sender.namingcontainer.FindControl("ddlESSCode")
		'Dim ddlCap As DropDownList = sender.namingcontainer.FindControl("ddlESCap")
		'Dim ddlVariant As DropDownList = sender.namingcontainer.FindControl("ddlESVariant")

		With conn
			If ddlProd.SelectedValue = "" Then
				ddlBrand.Items.Clear()
				ddlSCode.Items.Clear()
				'ddlCap.Items.Clear()
				'ddlVariant.Items.Clear()

			Else
				'load brand
				where = "productID = " & ddlProd.SelectedValue
				.loadToDropDownList("tbl_Brand", ddlBrand, False, "*", where, "brandID", "brand", "", "")

				'load capacity
				'.loadToDropDownList("tbl_Capacity", ddlCap, False, "*", where, "capacityID", "capacity", "", "")

				'load variant
				'.loadToDropDownList("tbl_Variant", ddlVariant, False, "*", where, "variantID", "variant", "", "")
			End If
		End With
	End Sub

	Protected Sub ddlASProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim ddlProd As DropDownList = sender
		Dim ddlBrand As DropDownList = sender.namingcontainer.FindControl("ddlASBrand")
		Dim ddlSCode As DropDownList = sender.namingcontainer.FindControl("ddlASSCode")
		'Dim ddlCap As DropDownList = sender.namingcontainer.FindControl("ddlASCap")
		'Dim ddlVariant As DropDownList = sender.namingcontainer.FindControl("ddlASVariant")

		With conn
			If ddlProd.SelectedValue = "" Then
				ddlBrand.Items.Clear()
				ddlSCode.Items.Clear()
				'ddlCap.Items.Clear()
				'ddlVariant.Items.Clear()

			Else
				'load brand
				where = "productID = " & ddlProd.SelectedValue
				.loadToDropDownList("tbl_Brand", ddlBrand, False, "*", where, "brandID", "brand", "", "")

				'Loadload capacity
				'.loadToDropDownList("tbl_Capacity", ddlCap, False, "*", where, "capacityID", "capacity", "", "")

				'load variant
				'.loadToDropDownList("tbl_Variant", ddlVariant, False, "*", where, "variantID", "variant", "", "")
			End If
		End With
	End Sub

	Protected Sub ddlESBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim ddlBrand As DropDownList = sender
		Dim ddlProd As DropDownList = sender.namingcontainer.FindControl("ddlESProd")
		Dim ddlSCode As DropDownList = sender.namingcontainer.FindControl("ddlESSCode")

		With conn
			If ddlBrand.SelectedValue = "" Then
				ddlSCode.Items.Clear()

			Else
				'load short code
				where = "productID = " & ddlProd.SelectedValue & " AND brandID = " & ddlBrand.SelectedValue
				.loadToDropDownList("tbl_Items", ddlSCode, False, "*", where, "itemID", "shortCode", "shortCode", "")
			End If
		End With
	End Sub

	Protected Sub ddlASBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim ddlBrand As DropDownList = sender
		Dim ddlProd As DropDownList = sender.namingcontainer.FindControl("ddlASProd")
		Dim ddlSCode As DropDownList = sender.namingcontainer.FindControl("ddlASSCode")

		With conn
			If ddlBrand.SelectedValue = "" Then
				ddlSCode.Items.Clear()

			Else
				'load brand
				where = "productID = " & ddlProd.SelectedValue & " AND brandID = " & ddlBrand.SelectedValue
				.loadToDropDownList("tbl_Items", ddlSCode, False, "*", where, "itemID", "shortCode", "shortCode", "")
			End If
		End With
	End Sub

	Protected Sub ddleIProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim ddlProd As DropDownList = sender
		Dim ddlBrand As DropDownList = sender.namingcontainer.FindControl("ddlEIBrand")
		Dim ddlSCode As DropDownList = sender.namingcontainer.FindControl("ddlEISCode")
		'Dim ddlCap As DropDownList = sender.namingcontainer.FindControl("ddlEICap")
		'Dim ddlVariant As DropDownList = sender.namingcontainer.FindControl("ddlEIVariant")

		With conn
			If ddlProd.SelectedValue = "" Then
				ddlBrand.Items.Clear()
				ddlSCode.Items.Clear()
				'ddlCap.Items.Clear()
				'ddlVariant.Items.Clear()

			Else
				'load brand
				where = "productID = " & ddlProd.SelectedValue
				.loadToDropDownList("tbl_Brand", ddlBrand, False, "*", where, "brandID", "brand", "", "")

				'load capacity
				'.loadToDropDownList("tbl_Capacity", ddlCap, False, "*", where, "capacityID", "capacity", "", "")

				'load variant
				'.loadToDropDownList("tbl_Variant", ddlVariant, False, "*", where, "variantID", "variant", "", "")
			End If
		End With
	End Sub

	Protected Sub ddlaIProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim ddlProd As DropDownList = sender
		Dim ddlBrand As DropDownList = sender.namingcontainer.FindControl("ddlaIBrand")
		Dim ddlSCode As DropDownList = sender.namingcontainer.FindControl("ddlaISCode")
		'Dim ddlCap As DropDownList = sender.namingcontainer.FindControl("ddlaICap")
		'Dim ddlVariant As DropDownList = sender.namingcontainer.FindControl("ddlaIVariant")

		With conn
			If ddlProd.SelectedValue = "" Then
				ddlBrand.Items.Clear()
				ddlSCode.Items.Clear()
				'ddlCap.Items.Clear()
				'ddlVariant.Items.Clear()

			Else
				'load brand
				where = "productID = " & ddlProd.SelectedValue
				.loadToDropDownList("tbl_Brand", ddlBrand, False, "*", where, "brandID", "brand", "", "")

				'load capacity
				'.loadToDropDownList("tbl_Capacity", ddlCap, False, "*", where, "capacityID", "capacity", "", "")

				'load variant
				'.loadToDropDownList("tbl_Variant", ddlVariant, False, "*", where, "variantID", "variant", "", "")
			End If
		End With
	End Sub

	Protected Sub ddleIBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim ddlBrand As DropDownList = sender
		Dim ddlProd As DropDownList = sender.namingcontainer.FindControl("ddleIProd")
		Dim ddlSCode As DropDownList = sender.namingcontainer.FindControl("ddleISCode")

		With conn
			If ddlBrand.SelectedValue = "" Then
				ddlSCode.Items.Clear()

			Else
				'load brand
				where = "productID = " & ddlProd.SelectedValue & " AND brandID = " & ddlBrand.SelectedValue
				.loadToDropDownList("tbl_Items", ddlSCode, False, "*", where, "itemID", "shortCode", "shortCode", "")
			End If
		End With
	End Sub

	Protected Sub ddlaIBrand_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim ddlBrand As DropDownList = sender
		Dim ddlProd As DropDownList = sender.namingcontainer.FindControl("ddlaIProd")
		Dim ddlSCode As DropDownList = sender.namingcontainer.FindControl("ddlaISCode")

		With conn
			If ddlBrand.SelectedValue = "" Then
				ddlSCode.Items.Clear()

			Else
				'load brand
				where = "productID = " & ddlProd.SelectedValue & " AND brandID = " & ddlBrand.SelectedValue
				.loadToDropDownList("tbl_Items", ddlSCode, False, "*", where, "itemID", "shortCode", "shortCode", "")
			End If
		End With
	End Sub

	Protected Sub imbClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbClose.Click
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		panInfo.Visible = False
		Session("prodID") = Nothing
		Session("brandID") = Nothing
	End Sub

	Protected Sub imbeRef_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		checkSession()
		lbleMsg.Text = ""

		panInfo.Visible = False

		Dim imbRef As ImageButton = sender
		Dim ddlProd As DropDownList = sender.namingcontainer.findcontrol("ddleProd")
		Dim ddlBrand As DropDownList = sender.namingcontainer.findcontrol("ddleBrand")

		If ddlProd.SelectedValue.Trim = "" Or ddlBrand.SelectedValue.Trim = "" Then
			lbleMsg.Text = "You must select the product and brand first to view the Reference List"
			Exit Sub

		Else
			Session("prodID") = ddlProd.SelectedValue.Trim
			lblifProd.Text = ddlProd.SelectedItem.Text
			Session("brandID") = ddlBrand.SelectedValue.Trim
			lblifBrand.Text = ddlBrand.SelectedItem.Text

			lblifProd.Text = ddlProd.SelectedItem.Text
			lblifBrand.Text = ddlBrand.SelectedItem.Text
			panInfo.Visible = True
		End If
	End Sub

	Protected Sub imbaRef_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		checkSession()
		lbleMsg.Text = ""
		panInfo.Visible = False

		Dim imbRef As ImageButton = sender
		Dim ddlProd As DropDownList = sender.namingcontainer.findcontrol("ddlaProd")
		Dim ddlBrand As DropDownList = sender.namingcontainer.findcontrol("ddlaBrand")

		If ddlProd.SelectedValue.Trim = "" Or ddlBrand.SelectedValue.Trim = "" Then
			Session("prodID") = Nothing
			Session("brandID") = Nothing
			lbleMsg.Text = "You must select the product and brand first to view the Reference List"
			Exit Sub


		Else
			System.Threading.Thread.Sleep(500)
			Session("prodID") = ddlProd.SelectedValue.Trim
			lblifProd.Text = ddlProd.SelectedItem.Text
			Session("brandID") = ddlBrand.SelectedValue.Trim
			lblifBrand.Text = ddlBrand.SelectedItem.Text

			panInfo.Visible = True
		End If
	End Sub

	Protected Sub imbeSRef_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		checkSession()
		lbleMsg.Text = ""

		checkSession()
		lbleMsg.Text = ""

		panInfo.Visible = False

		Dim imbRef As ImageButton = sender
		Dim ddlProd As DropDownList = sender.namingcontainer.findcontrol("ddleSProd")
		Dim ddlBrand As DropDownList = sender.namingcontainer.findcontrol("ddleSBrand")

		If ddlProd.SelectedValue.Trim = "" Or ddlBrand.SelectedValue.Trim = "" Then
			Session("prodID") = Nothing
			Session("brandID") = Nothing
			lbleMsg.Text = "You must select the product and brand first to view the Reference List"
			Exit Sub

		Else
			System.Threading.Thread.Sleep(500)
			Session("prodID") = ddlProd.SelectedValue.Trim
			lblifProd.Text = ddlProd.SelectedItem.Text
			Session("brandID") = ddlBrand.SelectedValue.Trim
			lblifBrand.Text = ddlBrand.SelectedItem.Text

			lblifProd.Text = ddlProd.SelectedItem.Text
			lblifBrand.Text = ddlBrand.SelectedItem.Text
			panInfo.Visible = True
		End If
	End Sub

	Protected Sub imbaSRef_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		checkSession()
		lbleMsg.Text = ""

		checkSession()
		lbleMsg.Text = ""

		panInfo.Visible = False

		Dim imbRef As ImageButton = sender
		Dim ddlProd As DropDownList = sender.namingcontainer.findcontrol("ddlaSProd")
		Dim ddlBrand As DropDownList = sender.namingcontainer.findcontrol("ddlaSBrand")

		If ddlProd.SelectedValue.Trim = "" Or ddlBrand.SelectedValue.Trim = "" Then
			Session("prodID") = Nothing
			Session("brandID") = Nothing
			lbleMsg.Text = "You must select the product and brand first to view the Reference List"
			Exit Sub

		Else
			System.Threading.Thread.Sleep(500)
			Session("prodID") = ddlProd.SelectedValue.Trim
			lblifProd.Text = ddlProd.SelectedItem.Text
			Session("brandID") = ddlBrand.SelectedValue.Trim
			lblifBrand.Text = ddlBrand.SelectedItem.Text

			panInfo.Visible = True
		End If
	End Sub

	Protected Sub imbeIRef_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		checkSession()
		lbleMsg.Text = ""

		panInfo.Visible = False

		Dim imbRef As ImageButton = sender
		Dim ddlProd As DropDownList = sender.namingcontainer.findcontrol("ddleIProd")
		Dim ddlBrand As DropDownList = sender.namingcontainer.findcontrol("ddleIBrand")

		If ddlProd.SelectedValue.Trim = "" Or ddlBrand.SelectedValue.Trim = "" Then
			Session("prodID") = Nothing
			Session("brandID") = Nothing
			lbleMsg.Text = "You must select the product and brand first to view the Reference List"
			Exit Sub

		Else
			System.Threading.Thread.Sleep(500)
			Session("prodID") = ddlProd.SelectedValue.Trim
			lblifProd.Text = ddlProd.SelectedItem.Text
			Session("brandID") = ddlBrand.SelectedValue.Trim
			lblifBrand.Text = ddlBrand.SelectedItem.Text

			lblifProd.Text = ddlProd.SelectedItem.Text
			lblifBrand.Text = ddlBrand.SelectedItem.Text
			panInfo.Visible = True
		End If
	End Sub

	Protected Sub imbaIRef_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
		checkSession()
		lbleMsg.Text = ""

		panInfo.Visible = False

		Dim imbRef As ImageButton = sender
		Dim ddlProd As DropDownList = sender.namingcontainer.findcontrol("ddlaIProd")
		Dim ddlBrand As DropDownList = sender.namingcontainer.findcontrol("ddlaIBrand")

		If ddlProd.SelectedValue.Trim = "" Or ddlBrand.SelectedValue.Trim = "" Then
			Session("prodID") = Nothing
			Session("brandID") = Nothing
			lbleMsg.Text = "You must select the product and brand first to view the Reference List"
			Exit Sub

		Else
			System.Threading.Thread.Sleep(500)
			Session("prodID") = ddlProd.SelectedValue.Trim
			lblifProd.Text = ddlProd.SelectedItem.Text
			Session("brandID") = ddlBrand.SelectedValue.Trim
			lblifBrand.Text = ddlBrand.SelectedItem.Text

			panInfo.Visible = True
		End If
	End Sub

	Protected Sub ddleAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim ddlAction As DropDownList = sender
		Dim txtOthers As TextBox = sender.namingcontainer.findcontrol("txteAction")

		If ddlAction.SelectedItem.Text = "Others" Then
			txtOthers.Text = ""
			txtOthers.Visible = True
		Else
			txtOthers.Text = ""
			txtOthers.Visible = False
		End If
	End Sub

	Protected Sub ddlaAction_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""

		Dim ddlAction As DropDownList = sender
		Dim txtOthers As TextBox = sender.namingcontainer.findcontrol("txtaAction")

		If ddlAction.SelectedItem.Text = "Others" Then
			txtOthers.Text = ""
			txtOthers.Visible = True
		Else
			txtOthers.Text = ""
			txtOthers.Visible = False
		End If
	End Sub

	Private Sub ddlWeek_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlWeek.SelectedIndexChanged
		System.Threading.Thread.Sleep(500)
		checkSession()
		lbleMsg.Text = ""
	End Sub

	Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpload.Click
		checkSession()
		Response.Redirect("~/Sales/SalesUpload.aspx")
    End Sub

    Protected Sub ddlACProdProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        System.Threading.Thread.Sleep(500)
        checkSession()
        lbleMsg.Text = ""

        Dim ddlProd As DropDownList = sender
        Dim ddlACBrand As DropDownList = sender.namingcontainer.FindControl("ddlACBrand")

        With conn
            If ddlProd.SelectedValue = "" Then
                ddlACBrand.Items.Clear()
            Else
                'load brand
                .loadToDropDownList("tbl_CBrand", ddlACBrand, False, "*", String.Empty, "cBrandID", "cBrand", "", "")
            End If
        End With
    End Sub

End Class