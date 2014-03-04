Imports System.IO
Imports System.Data
Imports System.Data.OleDb

Public Class SalesUpload
    Inherits System.Web.UI.Page

    Public conn As New clsConn
    Public LoadAtt As New clsLoadAttachment

    Public excelPath As String = Server.MapPath("~/ExcelFiles/")
    Public DLPath As String = Server.MapPath("~/Admin/")

    Public mstr As New MasterPage
    Public where, qry As String

    '    Protected Sub btnUpload1_Click(ByVal sender As Object, ByVal e As EventArgs)
    '        lbleMsg.Text = ""
    '        On Error GoTo esc

    '        If (fupUpload.HasFile) Then
    '            Dim conn As OleDbConnection
    '            Dim cmd As OleDbCommand
    '            Dim da As OleDbDataAdapter
    '            Dim ds As DataSet
    '            Dim query As String
    '            Dim connString As String = ""
    '            Dim strFileName As String = DateTime.Now.ToString("ddMMyyyy_HHmmss")
    '            Dim strFileType As String = System.IO.Path.GetExtension(fupUpload.FileName).ToString().ToLower()


    '            'Check file type
    '            If strFileType.Trim = ".xls" Or strFileType.Trim = ".xlsx" Then
    '                fupUpload.SaveAs(excelPath & strFileName & strFileType)
    '            Else
    '                lbleMsg.Text = "Only excel files allowed"
    '                lbleMsg.ForeColor = Drawing.Color.Red
    '                lbleMsg.Visible = True
    '                Exit Sub
    '            End If

    '            Dim strNewPath As String = excelPath & strFileName & strFileType

    '            'Connection String to Excel Workbook
    '            If strFileType.Trim = ".xls" Then
    '                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strNewPath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
    '            ElseIf strFileType.Trim = ".xlsx" Then
    '                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strNewPath & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""
    '            End If

    '            '===========================================================

    '            '' ''Dim excelConnection As System.Data.OleDb.OleDbConnection = New System.Data.OleDb.OleDbConnection(connString)
    '            '' ''excelConnection.Open()

    '            '' ''Dim excelCommand As New System.Data.OleDb.OleDbCommand("INSERT INTO [OBDC; Driver={SQL Server};Server=CIELO;Database=db_CCAC;Trusted_Connection=yes].[tbl_ExcelData] SELECT * FROM [Sheet1$];", excelConnection)
    '            ' '' ''Dim ExcelCommand As New System.Data.OleDb.OleDbCommand("SELECT INTO [ODBC;Driver={SQL Server};Server=(local);Database=FullDate;Trusted_ConnectionÂ*=yes].[Population] FROM [Population$];", excelConnection)

    '            '' ''excelCommand.ExecuteNonQuery()
    '            '' ''excelConnection.Close()



    '            '============================================================


    '            '' ''-----------------------------------------------------------
    '            ' ''Dim oCon As New OleDbConnection(connString)
    '            ' ''Dim ocmd As New OleDbCommand("select * from [Sheet1$]", oCon)
    '            ' ''conn.Open()         'Here [Sheet1$] is the name of the sheet in the Excel file where the data is present
    '            ' ''Dim odr As OleDbDataReader = ocmd.ExecuteReader()
    '            ' ''Dim fn, ln, cAdd, city, contact As String
    '            ' ''Dim qty As Integer = 0
    '            ' ''Dim prod, brand, sCode As String
    '            ' ''Dim dp, serial, inv As String

    '            ' ''Do While odr.Read()
    '            ' ''    fn = odr(0)

    '            ' ''    Dim field, values As String

    '            ' ''    field = "userID, fname"
    '            ' ''    values = Session("userID") & ", '" & fn & "'"
    '            ' ''    cN.saveInfo("tbl_ExcelData", field, values)
    '            ' ''Loop

    '            ' ''conn.Close()

    '            '' ''---------------------------------------





    '            'Dim Access As String = Server.MapPath("DBCoh.mdb")
    '            'Dim Access As String = "C:\MemberSites\MemberSites_AspSpider_Ws\chefjace03\database\DBcoh.mdb"
    '            'Dim Excel As String = Server.MapPath("~/UploadedExcel/" & strFileName & strFileType)
    '            excelPath += strFileName & strFileType
    '            Dim connect As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excelPath & _
    '                ";Extended Properties=Excel 8.0;"
    '            Using con As New OleDbConnection(connect)
    '                Using cmd1 As New OleDbCommand()
    '                    cmd1.Connection = con
    '                    cmd1.CommandText = "INSERT INTO [" & cN & "].[tbl_ExcelData] SELECT * FROM [Sheet1$]"
    '                    'cmd1.CommandText = "INSERT INTO [MS Access;Database=" & accessPath & "].[Persons] SELECT * FROM [Sheet1$]"
    '                    'cmd1.CommandText = "INSERT INTO [MS Access;Database=" & accessPath & "].[Persons] SELECT * FROM [Sheet1$]"
    '                    con.Open()
    '                    cmd1.ExecuteNonQuery()
    '                End Using
    '            End Using
    '            GoTo ok

    'esc:
    '            lbleMsg.Text = "Error uploading excel file. Please try again."

    'ok:
    '            query = "SELECT * FROM [Sheet1$]"
    '            'query = "SELECT [Country],[Capital] FROM [Sheet1$] WHERE [Currency]='Rupee'"
    '            'query = "SELECT [Country],[Capital] FROM [Sheet1$]"

    '            'Create the connection object 
    '            conn = New OleDbConnection(connString)
    '            'Open connection
    '            If conn.State = ConnectionState.Closed Then conn.Open()
    '            'Create the command object
    '            cmd = New OleDbCommand(query, conn)
    '            da = New OleDbDataAdapter(cmd)
    '            ds = New DataSet()
    '            da.Fill(ds)

    '            grdSales.DataSource = ds.Tables(0)
    '            grdSales.DataBind()

    '            lbleMsg.Text = "Data retrieved successfully! Total Recodes:" & ds.Tables(0).Rows.Count
    '            lbleMsg.ForeColor = Drawing.Color.Green
    '            lbleMsg.Visible = True

    '            da.Dispose()
    '            conn.Close()
    '            conn.Dispose()
    '        Else
    '            lbleMsg.Text = "Please select an excel file first"
    '            lbleMsg.ForeColor = Drawing.Color.Red
    '            lbleMsg.Visible = True
    '        End If
    '    End Sub

    Public Sub checkSession()
        mstr = Page.Master
        Dim lblUserID As Label = mstr.FindControl("lblUserID")

        If Session("userID") Is Nothing Then
            Session.Clear()
            Response.Redirect("~/Default.aspx")
        End If
    End Sub

    Public Function validateCRecord(ByVal cBrand As String, ByVal cCap As String, ByVal qty As String,
                                    ByVal dpMonth As String, ByVal dpDay As String, ByVal dpYear As String,
                                    ByVal factors As String) As String

        validateCRecord = "Valid"

        If cBrand = "" Then
            validateCRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        End If

        If cCap = "" Then
            validateCRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        End If

        If qty = "" Then
            validateCRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        End If

        If dpMonth = "" Then
            validateCRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        End If

        If dpMonth = "" And dpDay = "" And dpYear = "" Then
            validateCRecord = "Invalid"
            Session("uStatCheck") = "Invalid"

        ElseIf dpMonth = "" Or dpDay = "" Or dpYear = "" Then
            validateCRecord = "Invalid"
            Session("uStatCheck") = "Invalid"

        ElseIf dpMonth <> "" And dpDay <> "" And dpYear <> "" Then
            Dim dp As String = dpMonth & " " & dpDay & ", " & dpYear

            If IsDate(dp) = False Then
                validateCRecord = "Invalid"
                Session("uStatCheck") = "Invalid"

            Else
                With conn
                    Dim retFld(0), retVal(0) As String

                    where = "wDay = '" & dp & "' AND weekID = " & ddlWeek.SelectedValue.Trim
                    If .checkID("tbl_WDay", "*", where, 0, retVal, retFld, "", "") = "False" Then
                        validateCRecord = "Invalid"
                        Session("uStatCheck") = "Invalid"
                    End If
                End With
            End If
        End If

        If factors = "" Then
            validateCRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        End If
    End Function

    Public Function validateIRecord(ByVal qty As String,
                                   ByVal prod As String, ByVal brand As String, ByVal sCode As String) As String

        validateIRecord = "Valid"

        If qty = "" Then
            validateIRecord = "Invalid"
            Session("uStatCheck") = "Invalid"

        ElseIf IsNumeric(qty) = False Then
            validateIRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        End If

        If prod = "" Then
            validateIRecord = "Invalid"
            Session("uStatCheck") = "Invalid"

        Else
            If getProd(prod) = "0" Then
                validateIRecord = "Invalid"
                Session("uStatCheck") = "Invalid"
            End If
        End If

        If brand = "" Then
            validateIRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        Else
            If getBrand(getProd(prod), brand) = "0" Then
                validateIRecord = "Invalid"
                Session("uStatCheck") = "Invalid"
            End If
        End If

        If sCode = "" Then
            validateIRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        Else
            If getItem(getProd(prod), getBrand(getProd(prod), brand), sCode) = "0" Then
                validateIRecord = "Invalid"
                Session("uStatCheck") = "Invalid"
            End If
        End If
    End Function

    Public Function validateSRecord(ByVal prod As String, ByVal brand As String, ByVal sCode As String,
                                   ByVal dpMonth As String, ByVal dpDay As String, ByVal dpYear As String,
                                   ByVal actionTaken As String, ByVal others As String, ByVal promo As String) As String

        validateSRecord = "Valid"

        If prod = "" Then
            validateSRecord = "Invalid"
            Session("uStatCheck") = "Invalid"

        Else
            If getProd(prod) = "0" Then
                validateSRecord = "Invalid"
                Session("uStatCheck") = "Invalid"
            End If
        End If

        If brand = "" Then
            validateSRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        Else
            If getBrand(getProd(prod), brand) = "0" Then
                validateSRecord = "Invalid"
                Session("uStatCheck") = "Invalid"
            End If
        End If

        If sCode = "" Then
            validateSRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        Else
            If getItem(getProd(prod), getBrand(getProd(prod), brand), sCode) = "0" Then
                validateSRecord = "Invalid"
                Session("uStatCheck") = "Invalid"
            End If
        End If

        If dpMonth = "" And dpDay = "" And dpYear = "" Then
            validateSRecord = "Invalid"
            Session("uStatCheck") = "Invalid"

        ElseIf dpMonth = "" Or dpDay = "" Or dpYear = "" Then
            validateSRecord = "Invalid"
            Session("uStatCheck") = "Invalid"

        ElseIf dpMonth <> "" And dpDay <> "" And dpYear <> "" Then
            Dim dp As String = dpMonth & " " & dpDay & ", " & dpYear

            If IsDate(dp) = False Then
                validateSRecord = "Invalid"
                Session("uStatCheck") = "Invalid"

            Else
                With conn
                    Dim retFld(0), retVal(0) As String

                    where = "wDay = '" & dp & "' AND weekID = " & ddlWeek.SelectedValue.Trim
                    If .checkID("tbl_WDay", "*", where, 0, retVal, retFld, "", "") = "False" Then
                        validateSRecord = "Invalid"
                        Session("uStatCheck") = "Invalid"
                    End If
                End With
            End If
        End If

        If actionTaken = "" Then
            validateSRecord = "Invalid"
            Session("uStatCheck") = "Invalid"

        Else
            If getAction(actionTaken) = "0" Then
                validateSRecord = "Invalid"
                Session("uStatCheck") = "Invalid"

            ElseIf actionTaken = "Others" And others = "" Then
                validateSRecord = "Invalid"
                Session("uStatCheck") = "Invalid"
            End If
        End If

        If promo = "" Then
            validateSRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        End If
    End Function

    Public Function validateRecord(ByVal contact As String, ByVal qty As String,
                                   ByVal prod As String, ByVal brand As String, ByVal sCode As String,
                                   ByVal dpMonth As String, ByVal dpDay As String, ByVal dpYear As String,
                                   ByVal invNo As String) As String

        validateRecord = "Valid"

        If contact <> "" Then
            'If IsNumeric(contact) = False Then
            '    validateRecord = "Invalid"
            '    Session("uStatCheck") = "Invalid"

            'Else
            If Len(contact) < 7 Then
                validateRecord = "Invalid"
                Session("uStatCheck") = "Invalid"
            End If
        End If

        If qty = "" Then
            validateRecord = "Invalid"
            Session("uStatCheck") = "Invalid"

        ElseIf IsNumeric(qty) = False Then
            validateRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        End If

        If prod = "" Then
            validateRecord = "Invalid"
            Session("uStatCheck") = "Invalid"

        Else
            If getProd(prod) = "0" Then
                validateRecord = "Invalid"
                Session("uStatCheck") = "Invalid"
            End If
        End If

        If brand = "" Then
            validateRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        Else
            If getBrand(getProd(prod), brand) = "0" Then
                validateRecord = "Invalid"
                Session("uStatCheck") = "Invalid"
            End If
        End If

        If sCode = "" Then
            validateRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        Else
            If getItem(getProd(prod), getBrand(getProd(prod), brand), sCode) = "0" Then
                validateRecord = "Invalid"
                Session("uStatCheck") = "Invalid"
            End If
        End If

        If dpMonth = "" And dpDay = "" And dpYear = "" Then
            validateRecord = "Invalid"
            Session("uStatCheck") = "Invalid"

        ElseIf dpMonth = "" Or dpDay = "" Or dpYear = "" Then
            validateRecord = "Invalid"
            Session("uStatCheck") = "Invalid"

        ElseIf dpMonth <> "" And dpDay <> "" And dpYear <> "" Then
            Dim dp As String = dpMonth & " " & dpDay & ", " & dpYear

            If IsDate(dp) = False Then
                validateRecord = "Invalid"
                Session("uStatCheck") = "Invalid"

                If invNo = "" Then
                    validateRecord = "Invalid"
                    Session("uStatCheck") = "Invalid"
                End If

            Else
                With conn
                    Dim retFld(0), retVal(0) As String

                    where = "wDay = '" & dp & "' AND weekID = " & ddlWeek.SelectedValue.Trim
                    If .checkID("tbl_WDay", "*", where, 0, retVal, retFld, "", "") = "False" Then
                        validateRecord = "Invalid"
                        Session("uStatCheck") = "Invalid"

                    Else
                        If invNo = "" Then
                            validateRecord = "Invalid"
                            Session("uStatCheck") = "Invalid"

                        Else
                            With conn
                                Dim retFld1(0), retVal1(0) As String

                                'check if unique in tbl_sales
                                where = "invoice = '" & invNo & "' AND dPurchased <> '" & dp & "'"
                                Dim checkTblSales As String = .checkID("tbl_Sales", "*", where, 0, retVal1, retFld1, "", "")

                                'check if unique in tbl_ExcelUpload
                                where = "invoice = '" & invNo & "' AND eID <> " & Session("eID") & " AND dPurchased <> '" & dp & "'"
                                Dim checkTblExcelUpload As String = .checkID("tbl_ExcelUpload", "*", where, 0, retVal1, retFld1, "", "")

                                'check if unique in tbl_SalesSub
                                where = "invoice = '" & invNo & "' AND dPurchased <> '" & dp & "'"
                                Dim checkTblSalesSub As String = .checkID("tbl_SalesSub", "*", where, 0, retVal1, retFld1, "", "")

                                If checkTblSales = "True" Or checkTblExcelUpload = "True" Or checkTblSalesSub = "True" Then
                                    validateRecord = "Invalid"
                                    Session("uStatCheck") = "Invalid"
                                End If
                            End With
                        End If
                    End If
                End With
            End If
        End If

        If invNo = "" Then
            validateRecord = "Invalid"
            Session("uStatCheck") = "Invalid"
        End If
    End Function

    Private Sub SalesUpload_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            'check if there's an active file on sales form
			With conn
				Dim l_select As String = "*"
				Dim l_flow As String = ""
				If Session("accntTypeID") = "6" Or Session("accntTypeID") = "7" Then
					l_select = "TOP 1 *"
					l_flow = "DESC"
				Else
					l_select = "TOP 3 *"
					l_flow = "DESC"
				End If
				.loadToDropDownList("vw_Week", ddlWeek, False, l_select, "", "weekID", "weekCoverage", "weekID", l_flow)

				Dim retFld(0), retVal(0) As String
				retFld(0) = "weekID"

				where = "userID = " & Session("userID") & " AND weekID IS NOT NULL"
				If .checkID("tbl_Sales", "userID, weekID", where, 1, retVal, retFld, "", "") = "True" Then
					'check if week is active
					Dim retFld1(0), retVal1(0) As String
					retFld1(0) = "wStatus"

					where = "weekID = " & retVal(0)
					.getValues("tbl_Week", "weekID, wStatus", where, 1, retFld1, retVal1, "", "", "")

					If retVal1(0) = 1 Then
						ddlWeek.SelectedValue = retVal(0)
						ddlWeek.Enabled = False
						fupUpload.Enabled = True
						btnUpload.Enabled = True

					Else
						ddlWeek.Enabled = True
						fupUpload.Enabled = False
						btnUpload.Enabled = False
					End If

				Else
					ddlWeek.Enabled = True
					fupUpload.Enabled = False
					btnUpload.Enabled = False
				End If
			End With
        End If
    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpload.Click
        checkSession()
        lbleMsg.Text = ""

        If ddlWeek.SelectedValue.Trim = "" Then
            lbleMsg.Text = "Select the week coverage first."
            Exit Sub
        End If

        If ddlUForm.SelectedValue.Trim = "" Or ddlForm.SelectedValue.Trim = "Please select the form to upload" Then
            lbleMsg.Text = "Select the type of form first."
            Exit Sub
        End If

        Select Case ddlUForm.SelectedValue.Trim
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
        On Error GoTo errHandler

        Dim strFileName As String = "S-" & Session("userID") & "-" & DateTime.Now.ToString("ddMMMyy HHmm")
        Dim strFileType As String = System.IO.Path.GetExtension(fupUpload.FileName).ToString().ToLower()
        Dim uploadDate As String = Format(Now, "MMM dd, yyyy HH:mm")
        Dim upstat As String = "Valid"
        Dim uStatCheck As String = "Valid"
        Dim prodID, brandID, itemID, actionID As String

        'Check file type
        If strFileType.Trim = ".xls" Then
            System.Threading.Thread.Sleep(500)
            fupUpload.SaveAs(excelPath & strFileName & strFileType)
        Else
            lbleMsg.Text = "Please use the template. Only xls file will be accepted."
            lbleMsg.ForeColor = Drawing.Color.Red
            lbleMsg.Visible = True
            Exit Sub
        End If

        'Dim strNewPath As String = excelPath & strFileName & strFileType


        Dim strSql As String = ""
        strSql = "INSERT INTO tbl_SExcelUpload (userID, product, brand, sCode, dOut, actionTaken, others, promo, upStat, uploadDate, weekID, productID, brandID, itemID, actionID) VALUES " _
                    & "(" & Session("userID") & ", @product, @brand, @sCode, @dOut, @actionTaken, @others, @promo, @upStat, '" & uploadDate & "', " & ddlWeek.SelectedValue.Trim & ", @prodID, @brandID, @itemID, @actionID)"

        'SQL Server Connection String   
        Dim cn As New SqlClient.SqlConnection
        cn.ConnectionString = ConfigurationSettings.AppSettings("conString")

        cn.Open()

        '=============================
        excelPath += strFileName & strFileType
        Dim connect As String           '= "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excelPath & ";Extended Properties=Excel 8.0;"

        'Connection String to Excel Workbook
        If strFileType.Trim = ".xls" Then
            connect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excelPath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
        ElseIf strFileType.Trim = ".xlsx" Then
            connect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelPath & ";Extended Properties=""Excel 12.0;HDR=No;IMEX=1"""
        End If

        '=============================


        'Connection String to Excel Workbook   
        Dim excelConnectionString As String = connect
        '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Documents and Settings\cl3j\Desktop\ExcelTest.xlsx;Extended Properties=""Excel 12.0;HDR=YES;"""

        ' Create Connection to Excel Workbook   
        Using connection As New System.Data.OleDb.OleDbConnection(excelConnectionString)

            'List columns you need from the Excel file   
            Dim command As New System.Data.OleDb.OleDbCommand("Select [Product],[Brand],[Short Code],[Month Runs Out],[Day Runs Out],[Year Runs Out],[Action Taken],[Action Taken Others],[Competitor Promo Activities]" _
                                                              & " FROM [Sheet1$]", connection)
            connection.Open()

            ' Create DbDataReader to Data Worksheet   
            Using dr As System.Data.OleDb.OleDbDataReader = command.ExecuteReader()

                If dr.HasRows() Then
                    While dr.Read()
                        Dim cmd As New SqlClient.SqlCommand
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = strSql

                        If dr.Item("Product").ToString.Trim = "" And dr.Item("Brand").ToString.Trim = "" And _
                            dr.Item("Short Code").ToString.Trim = "" And dr.Item("Month Runs Out").ToString.Trim = "" And _
                            dr.Item("Day Runs Out").ToString.Trim = "" And dr.Item("Year Runs Out").ToString.Trim = "" And _
                            dr.Item("Action Taken").ToString.Trim = "" And dr.Item("Action Taken Others").ToString.Trim = "" And _
                            dr.Item("Competitor Promo Activities").ToString.Trim = "" Then

                        Else
                            'validate if record is valid
                            upstat = validateSRecord(dr.Item("Product").ToString.Trim, dr.Item("Brand").ToString.Trim, dr.Item("Short Code").ToString.Trim, dr.Item("Month Runs Out").ToString.Trim, dr.Item("Day Runs Out").ToString.Trim, dr.Item("Year Runs Out").ToString.Trim, dr.Item("Action Taken").ToString.Trim, dr.Item("Action Taken Others").ToString.Trim, dr.Item("Competitor Promo Activities").ToString.Trim)

                            cmd.Parameters.Add("@product", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Product"))
                            cmd.Parameters.Add("@brand", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Brand"))
                            cmd.Parameters.Add("@sCode", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Short Code"))

                            Dim dpMonth As String = Convert.ToString(dr.Item("Month Runs Out")).Trim
                            Dim dpDay As String = Convert.ToString(dr.Item("Day Runs Out")).Trim
                            Dim dpYear As String = Convert.ToString(dr.Item("Year Runs Out")).Trim
                            Dim dp As String = dpMonth & " " & dpDay & ", " & dpYear

                            cmd.Parameters.Add("@dOut", SqlDbType.NVarChar).Value = dp
                            cmd.Parameters.Add("@actionTaken", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Action Taken"))
                            cmd.Parameters.Add("@others", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Action Taken Others"))
                            cmd.Parameters.Add("@promo", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Competitor Promo Activities"))
                            cmd.Parameters.Add("@upStat", SqlDbType.NVarChar).Value = upstat

                            prodID = getProd(dr.Item("Product").ToString.Trim)
                            brandID = getBrand(prodID, dr.Item("Brand").ToString.Trim)
                            itemID = getItem(prodID, brandID, dr.Item("Short Code").ToString.Trim)
                            actionID = getAction(dr.Item("Action Taken").ToString.Trim)

                            cmd.Parameters.Add("@prodID", SqlDbType.BigInt).Value = prodID
                            cmd.Parameters.Add("@brandID", SqlDbType.BigInt).Value = brandID
                            cmd.Parameters.Add("@itemID", SqlDbType.BigInt).Value = itemID
                            cmd.Parameters.Add("@actionID", SqlDbType.SmallInt).Value = actionID
                            cmd.ExecuteScalar()
                        End If
                    End While
                End If
            End Using
        End Using

        cn.Close()
        cn = Nothing

        Session("uploadDate") = uploadDate
        Session("weekID") = ddlWeek.SelectedValue.Trim
        Session("uploadType") = "Stocks"
        'grdUpload.DataBind()

        If File.Exists(excelPath) Then
            File.Delete(excelPath)
        End If

        Response.Redirect("~/Sales/DownloadedFile.aspx")
        Exit Sub

errHandler:
        lbleMsg.Text = Err.Description
        If File.Exists(excelPath) Then
            File.Delete(excelPath)
        End If
    End Sub




    Public Sub LoadInventory()
        On Error GoTo errHandler

        Dim strFileName As String = "I-" & Session("userID") & "-" & DateTime.Now.ToString("ddMMMyy HHmm")
        Dim strFileType As String = System.IO.Path.GetExtension(fupUpload.FileName).ToString().ToLower()
        Dim uploadDate As String = Format(Now, "MMM dd, yyyy HH:mm")
        Dim upstat As String = "Valid"
        Dim uStatCheck As String = "Valid"
        Dim prodID, brandID, itemID, cityID As String

        'Check file type
        If strFileType.Trim = ".xls" Then
            System.Threading.Thread.Sleep(500)
            fupUpload.SaveAs(excelPath & strFileName & strFileType)
        Else
            lbleMsg.Text = "Please use the template. Only xls file will be accepted."
            lbleMsg.ForeColor = Drawing.Color.Red
            lbleMsg.Visible = True
            Exit Sub
        End If

        'Dim strNewPath As String = excelPath & strFileName & strFileType


        Dim strSql As String = ""
        strSql = "INSERT INTO tbl_IExcelUpload (userID, qty, product, brand, sCode, comments, upStat, uploadDate, weekID, productID, brandID, itemID) VALUES " _
                    & "(" & Session("userID") & ", @qty, @product, @brand, @sCode, @comments, @upStat, '" & uploadDate & "', " & ddlWeek.SelectedValue.Trim & ", @prodID, @brandID, @itemID)"

        'SQL Server Connection String   
        Dim cn As New SqlClient.SqlConnection
        cn.ConnectionString = ConfigurationSettings.AppSettings("conString")

        cn.Open()

        '=============================
        excelPath += strFileName & strFileType
        Dim connect As String           '= "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excelPath & ";Extended Properties=Excel 8.0;"

        'Connection String to Excel Workbook
        If strFileType.Trim = ".xls" Then
            connect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excelPath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
        ElseIf strFileType.Trim = ".xlsx" Then
            connect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelPath & ";Extended Properties=""Excel 12.0;HDR=No;IMEX=1"""
        End If

        '=============================


        'Connection String to Excel Workbook   
        Dim excelConnectionString As String = connect
        '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Documents and Settings\cl3j\Desktop\ExcelTest.xlsx;Extended Properties=""Excel 12.0;HDR=YES;"""

        ' Create Connection to Excel Workbook   
        Using connection As New System.Data.OleDb.OleDbConnection(excelConnectionString)

            'List columns you need from the Excel file   
            Dim command As New System.Data.OleDb.OleDbCommand("SELECT [Qty],[Product],[Brand],[Short Code],[Comments & Suggestions]" _
                                                              & "FROM [Sheet1$]", connection)
            connection.Open()

            ' Create DbDataReader to Data Worksheet   
            Using dr As System.Data.OleDb.OleDbDataReader = command.ExecuteReader()

                If dr.HasRows() Then
                    While dr.Read()
                        Dim cmd As New SqlClient.SqlCommand
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = strSql

                        If dr.Item("Qty").ToString.Trim = "" And dr.Item("Comments & Suggestions").ToString.Trim = "" And _
                            dr.Item("Product").ToString.Trim = "" And dr.Item("Brand").ToString.Trim = "" And _
                            dr.Item("Short Code").ToString.Trim = "" Then

                        Else
                            'validate if record is valid
                            upstat = validateIRecord(dr.Item("Qty").ToString.Trim, dr.Item("Product").ToString.Trim, dr.Item("Brand").ToString.Trim, dr.Item("Short Code").ToString.Trim)

                            cmd.Parameters.Add("@qty", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Qty"))
                            cmd.Parameters.Add("@product", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Product"))
                            cmd.Parameters.Add("@brand", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Brand"))
                            cmd.Parameters.Add("@sCode", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Short Code"))
                            cmd.Parameters.Add("@comments", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Comments & Suggestions"))
                            cmd.Parameters.Add("@upStat", SqlDbType.NVarChar).Value = upstat

                            prodID = getProd(dr.Item("Product").ToString.Trim)
                            brandID = getBrand(prodID, dr.Item("Brand").ToString.Trim)
                            itemID = getItem(prodID, brandID, dr.Item("Short Code").ToString.Trim)

                            cmd.Parameters.Add("@prodID", SqlDbType.BigInt).Value = prodID
                            cmd.Parameters.Add("@brandID", SqlDbType.BigInt).Value = brandID
                            cmd.Parameters.Add("@itemID", SqlDbType.BigInt).Value = itemID
                            cmd.ExecuteScalar()
                        End If
                    End While
                End If
            End Using
        End Using

        cn.Close()
        cn = Nothing

        Session("uploadDate") = uploadDate
        Session("weekID") = ddlWeek.SelectedValue.Trim
        Session("uploadType") = "Inventory"
        'grdUpload.DataBind()

        If File.Exists(excelPath) Then
            File.Delete(excelPath)
        End If

        Response.Redirect("~/Sales/DownloadedFile.aspx")
        Exit Sub

errHandler:
        lbleMsg.Text = Err.Description
        If File.Exists(excelPath) Then
            File.Delete(excelPath)
        End If
    End Sub

    Public Sub LoadSales()
        On Error GoTo errHandler

        Dim strFileName As String = Session("userID") & "-" & DateTime.Now.ToString("ddMMMyy HHmm")
        Dim strFileType As String = System.IO.Path.GetExtension(fupUpload.FileName).ToString().ToLower()
        Dim uploadDate As String = Format(Now, "MMM dd, yyyy HH:mm")
        Dim upstat As String = "Valid"
        Dim uStatCheck As String = "Valid"
        Dim prodID, brandID, itemID, cityID As String

        'Check file type
        If strFileType.Trim = ".xls" Then
            System.Threading.Thread.Sleep(500)
            fupUpload.SaveAs(excelPath & strFileName & strFileType)
        Else
            lbleMsg.Text = "Please use the template. Only xls file will be accepted."
            lbleMsg.ForeColor = Drawing.Color.Red
            lbleMsg.Visible = True
            Exit Sub
        End If

        'Dim strNewPath As String = excelPath & strFileName & strFileType


        Dim strSql As String = ""
        strSql = "INSERT INTO tbl_ExcelUpload (userID, fname, lname, cAdd, city, contact, qty, product, brand, sCode, dpurchased, serialNo, invoice, upStat, uploadDate, weekID, productID, brandID, itemID, cityID) VALUES " _
                    & "(" & Session("userID") & ", @fname, @lname, @cAdd, @city, @contact, @qty, @product, @brand, @sCode, @dpurchased, @serialNo, @invoice, @upStat, '" & uploadDate & "', " & ddlWeek.SelectedValue.Trim & ", @prodID, @brandID, @itemID, @cityID)"

        'SQL Server Connection String   
        Dim cn As New SqlClient.SqlConnection
        cn.ConnectionString = ConfigurationSettings.AppSettings("conString")

        cn.Open()

        '=============================
        excelPath += strFileName & strFileType
        Dim connect As String           '= "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excelPath & ";Extended Properties=Excel 8.0;"

        'Connection String to Excel Workbook
        If strFileType.Trim = ".xls" Then
            connect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excelPath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
        ElseIf strFileType.Trim = ".xlsx" Then
            connect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelPath & ";Extended Properties=""Excel 12.0;HDR=No;IMEX=1"""
        End If

        '=============================


        'Connection String to Excel Workbook   
        Dim excelConnectionString As String = connect
        '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Documents and Settings\cl3j\Desktop\ExcelTest.xlsx;Extended Properties=""Excel 12.0;HDR=YES;"""

        ' Create Connection to Excel Workbook   
        Using connection As New System.Data.OleDb.OleDbConnection(excelConnectionString)

            'List columns you need from the Excel file   
            Dim command As New System.Data.OleDb.OleDbCommand("Select [First Name],[Last Name],[Address],[City],[Tel No],[Qty],[Product],[Brand],[Short Code],[Month Purchased],[Day Purchased],[Year Purchased],[Serial No],[Invoice No]" _
                                                              & "FROM [Sheet1$]", connection)
            connection.Open()

            ' Create DbDataReader to Data Worksheet   
            Using dr As System.Data.OleDb.OleDbDataReader = command.ExecuteReader()

                If dr.HasRows() Then
                    While dr.Read()
                        Dim cmd As New SqlClient.SqlCommand
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = strSql

                        If dr.Item("First Name").ToString.Trim = "" And dr.Item("Last Name").ToString.Trim = "" And _
                            dr.Item("Address").ToString.Trim = "" And dr.Item("City").ToString.Trim = "" And _
                            dr.Item("Tel No").ToString.Trim = "" And dr.Item("Qty").ToString.Trim = "" And _
                            dr.Item("Product").ToString.Trim = "" And dr.Item("Brand").ToString.Trim = "" And _
                            dr.Item("Short Code").ToString.Trim = "" And dr.Item("Month Purchased").ToString.Trim = "" And _
                            dr.Item("Day Purchased").ToString.Trim = "" And dr.Item("Year Purchased").ToString.Trim = "" And _
                            dr.Item("Serial No").ToString.Trim = "" And dr.Item("Invoice No").ToString.Trim = "" Then

                        Else
                            'validate if record is valid
                            upstat = validateRecord(dr.Item("Tel No").ToString.Trim, dr.Item("Qty").ToString.Trim, dr.Item("Product").ToString.Trim, dr.Item("Brand").ToString.Trim, dr.Item("Short Code").ToString.Trim, dr.Item("Month Purchased").ToString.Trim, dr.Item("Day Purchased").ToString.Trim, dr.Item("Year Purchased").ToString.Trim, dr.Item("Invoice No").ToString.Trim)

                            cmd.Parameters.Add("@fname", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("First Name"))
                            cmd.Parameters.Add("@lname", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Last Name"))
                            cmd.Parameters.Add("@cAdd", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Address"))
                            cmd.Parameters.Add("@city", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("City"))
                            cmd.Parameters.Add("@contact", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Tel No"))
                            cmd.Parameters.Add("@qty", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Qty"))
                            cmd.Parameters.Add("@product", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Product"))
                            cmd.Parameters.Add("@brand", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Brand"))
                            cmd.Parameters.Add("@sCode", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Short Code"))

                            Dim dpMonth As String = Convert.ToString(dr.Item("Month Purchased")).Trim
                            Dim dpDay As String = Convert.ToString(dr.Item("Day Purchased")).Trim
                            Dim dpYear As String = Convert.ToString(dr.Item("Year Purchased")).Trim
                            Dim dp As String = dpMonth & " " & dpDay & ", " & dpYear

                            cmd.Parameters.Add("@dpurchased", SqlDbType.NVarChar).Value = dp
                            cmd.Parameters.Add("@serialNo", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Serial No"))
                            cmd.Parameters.Add("@invoice", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Invoice No"))
                            cmd.Parameters.Add("@upStat", SqlDbType.NVarChar).Value = upstat

                            prodID = getProd(dr.Item("Product").ToString.Trim)
                            brandID = getBrand(prodID, dr.Item("Brand").ToString.Trim)
                            itemID = getItem(prodID, brandID, dr.Item("Short Code").ToString.Trim)
                            cityID = getCity(dr.Item("City").ToString.Trim)

                            cmd.Parameters.Add("@prodID", SqlDbType.BigInt).Value = prodID
                            cmd.Parameters.Add("@brandID", SqlDbType.BigInt).Value = brandID
                            cmd.Parameters.Add("@itemID", SqlDbType.BigInt).Value = itemID
                            cmd.Parameters.Add("@cityID", SqlDbType.SmallInt).Value = cityID
                            cmd.ExecuteScalar()
                        End If
                    End While
                End If
            End Using
        End Using

        cn.Close()
        cn = Nothing

        Session("uploadDate") = uploadDate
        Session("weekID") = ddlWeek.SelectedValue.Trim
        Session("uploadType") = "Sales"
        'grdUpload.DataBind()

        If File.Exists(excelPath) Then
            File.Delete(excelPath)
        End If

        Response.Redirect("~/Sales/DownloadedFile.aspx")
        Exit Sub

errHandler:
        lbleMsg.Text = Err.Description
        If File.Exists(excelPath) Then
            File.Delete(excelPath)
        End If
    End Sub

    Public Sub LoadCompete()
        On Error GoTo errHandler

        Dim strFileName As String = "C-" & Session("userID") & "-" & DateTime.Now.ToString("ddMMMyy HHmm")
        Dim strFileType As String = System.IO.Path.GetExtension(fupUpload.FileName).ToString().ToLower()
        Dim uploadDate As String = Format(Now, "MMM dd, yyyy HH:mm")
        Dim upstat As String = "Valid"
        Dim uStatCheck As String = "Valid"
        Dim cBrandID, cCapID As String

        'Check file type
        If strFileType.Trim = ".xls" Then
            System.Threading.Thread.Sleep(500)
            fupUpload.SaveAs(excelPath & strFileName & strFileType)

        Else
            lbleMsg.Text = "Please use the template. Only xls file will be accepted."
            lbleMsg.ForeColor = Drawing.Color.Red
            lbleMsg.Visible = True
            Exit Sub
        End If

        'Dim strNewPath As String = excelPath & strFileName & strFileType

        Dim strSql As String = ""
        strSql = "INSERT INTO tbl_CExcelUpload (userID, cBrand, cCapacity, qty, dpurchased, factors, upStat, uploadDate, weekID, cBrandID, cCapacityID) VALUES " _
                    & "(" & Session("userID") & ", @cBrand, @cCap, @qty, @dp, @factors, @upStat, '" & uploadDate & "', " & ddlWeek.SelectedValue.Trim & ", @cBrandID, @cCapID)"

        'SQL Server Connection String   
        Dim cn As New SqlClient.SqlConnection
        cn.ConnectionString = ConfigurationSettings.AppSettings("conString")

        cn.Open()

        '=============================
        excelPath += strFileName & strFileType
        Dim connect As String           '= "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excelPath & ";Extended Properties=Excel 8.0;"

        'Connection String to Excel Workbook
        If strFileType.Trim = ".xls" Then
            connect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excelPath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
        ElseIf strFileType.Trim = ".xlsx" Then
            connect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & excelPath & ";Extended Properties=""Excel 12.0;HDR=No;IMEX=1"""
        End If

        '=============================


        'Connection String to Excel Workbook   
        Dim excelConnectionString As String = connect
        '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Documents and Settings\cl3j\Desktop\ExcelTest.xlsx;Extended Properties=""Excel 12.0;HDR=YES;"""

        ' Create Connection to Excel Workbook   
        Using connection As New System.Data.OleDb.OleDbConnection(excelConnectionString)

            'List columns you need from the Excel file   
            Dim command As New System.Data.OleDb.OleDbCommand("Select [Brand],[Capacity],[Qty],[Month Purchased],[Day Purchased],[Year Purchased],[Factors Affecting Sell Out]" _
                                                              & "FROM [Sheet1$]", connection)
            connection.Open()

            ' Create DbDataReader to Data Worksheet   
            Using dr As System.Data.OleDb.OleDbDataReader = command.ExecuteReader()

                If dr.HasRows() Then
                    While dr.Read()
                        Dim cmd As New SqlClient.SqlCommand
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = strSql

                        If dr.Item("Brand").ToString.Trim = "" And dr.Item("Capacity").ToString.Trim = "" And _
                            dr.Item("Qty").ToString.Trim = "" And dr.Item("Month Purchased").ToString.Trim = "" And _
                            dr.Item("Day Purchased").ToString.Trim = "" And dr.Item("Year Purchased").ToString.Trim = "" And _
                            dr.Item("Factors Affecting Sell Out").ToString.Trim = ""  Then

                        Else
                            'validate if record is valid
                            upstat = validateCRecord(dr.Item("Brand").ToString.Trim, dr.Item("Capacity").ToString.Trim, dr.Item("Qty").ToString.Trim, dr.Item("Month Purchased").ToString.Trim, dr.Item("Day Purchased").ToString.Trim, dr.Item("Year Purchased").ToString.Trim, dr.Item("Factors Affecting Sell Out").ToString.Trim)

                            cmd.Parameters.Add("@cBrand", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Brand"))
                            cmd.Parameters.Add("@cCap", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Capacity"))
                            cmd.Parameters.Add("@qty", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Qty"))

                            Dim dpMonth As String = Convert.ToString(dr.Item("Month Purchased")).Trim
                            Dim dpDay As String = Convert.ToString(dr.Item("Day Purchased")).Trim
                            Dim dpYear As String = Convert.ToString(dr.Item("Year Purchased")).Trim
                            Dim dp As String = dpMonth & " " & dpDay & ", " & dpYear

                            cmd.Parameters.Add("@dp", SqlDbType.NVarChar).Value = dp
                            cmd.Parameters.Add("@factors", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("Factors Affecting Sell Out"))
                            cmd.Parameters.Add("@upStat", SqlDbType.NVarChar).Value = upstat

                            cBrandID = getCBrand(dr.Item("Brand").ToString.Trim)
                            cCapID = getCCap(dr.Item("Capacity").ToString.Trim)

                            cmd.Parameters.Add("@cBrandID", SqlDbType.BigInt).Value = cBrandID
                            cmd.Parameters.Add("@cCapID", SqlDbType.BigInt).Value = cCapID
                            cmd.ExecuteScalar()
                        End If
                    End While
                End If
            End Using
        End Using

        cn.Close()
        cn = Nothing

        Session("uploadDate") = uploadDate
        Session("weekID") = ddlWeek.SelectedValue.Trim
        Session("uploadType") = "Compete"
        'grdUpload.DataBind()

        If File.Exists(excelPath) Then
            File.Delete(excelPath)
        End If

        Response.Redirect("~/Sales/DownloadedFile.aspx")
        Exit Sub

errHandler:
        lbleMsg.Text = Err.Description
        If File.Exists(excelPath) Then
            File.Delete(excelPath)
        End If
    End Sub

    Public Function getCBrand(ByVal cBrand As String) As String
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "cBrandID"

            where = "cBrand = '" & cBrand & "'"
            If .checkID("tbl_CBrand", "*", where, 1, retVal, retFld, "", "") = "True" Then
                getCBrand = retVal(0)
            Else
                getCBrand = "0"
            End If
        End With
    End Function

    Public Function getCCap(ByVal cCap As String) As String
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "cCapacityID"

            where = "cCapacity = '" & cCap & "'"
            If .checkID("tbl_CCapacity", "*", where, 1, retVal, retFld, "", "") = "True" Then
                getCCap = retVal(0)
            Else
                getCCap = "0"
            End If
        End With
    End Function

    Public Function getCity(ByVal city As String) As String
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "cityID"

            where = "city = '" & city & "'"
            If .checkID("tbl_City", "*", where, 1, retVal, retFld, "", "") = "True" Then
                getCity = retVal(0)
            Else
                getCity = "0"
            End If
        End With
    End Function

    Public Function getAction(ByVal actTaken As String) As String
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "actionID"

            where = "actionTaken = '" & actTaken & "'"
            If .checkID("tbl_Action", "*", where, 1, retVal, retFld, "", "") = "True" Then
                getAction = retVal(0)
            Else
                getAction = "0"
            End If
        End With
    End Function

    Public Function getProd(ByVal prod As String) As String
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "productID"

            where = "product = '" & prod & "'"
            If .checkID("tbl_Product", "*", where, 1, retVal, retFld, "", "") = "True" Then
                getProd = retVal(0)
            Else
                getProd = "0"
            End If
        End With
    End Function

    Public Function getBrand(ByVal prodID As String, ByVal brand As String) As String
        With conn
            If prodID = "" Then
                getBrand = "0"

            Else
                Dim retFld(0), retVal(0) As String
                retFld(0) = "brandID"

                where = "productID = " & prodID & " AND brand = '" & brand & "'"
                If .checkID("tbl_Brand", "*", where, 1, retVal, retFld, "", "") = "True" Then
                    getBrand = retVal(0)
                Else
                    getBrand = "0"
                End If
            End If
        End With
    End Function

    Public Function getItem(ByVal prodID As String, ByVal brandID As String, ByVal item As String) As String
        With conn
            If prodID = "" Or brandID = "" Then
                getItem = "0"

            Else
                Dim retFld(0), retVal(0) As String
                retFld(0) = "itemID"

                where = "productID = " & prodID & " AND brandID = " & brandID & " AND shortCode = '" & item & "'"
                If .checkID("tbl_Items", "TOP 1 *", where, 1, retVal, retFld, "itemID", "") = "True" Then
                    getItem = retVal(0)
                Else
                    getItem = "0"
                End If
            End If
        End With
    End Function

    Protected Sub ddlWeek_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlWeek.SelectedIndexChanged
        If ddlWeek.SelectedValue.Trim = "" Then
            fupUpload.Enabled = False
            btnUpload.Enabled = False

        Else
            fupUpload.Enabled = True
            btnUpload.Enabled = True
        End If
    End Sub

    Protected Sub btnDload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDload.Click
        System.Threading.Thread.Sleep(500)
        If ddlForm.SelectedValue.Trim = "" Or ddlForm.SelectedValue.Trim = "Please select template to download" Then
            lbleMsg.Text = "Please select the template you want to use."
            Exit Sub

        Else
            System.Threading.Thread.Sleep(500)
            Dim FTemp As String

            Select Case ddlForm.SelectedValue.Trim
                Case "Sales"
                    FTemp = "salesUploader.xls"

                Case "Compete"
                    FTemp = "competitorUploader.xls"

                Case "Stocks"
                    FTemp = "stocksUploader.xls"

                Case "Inventory"
                    FTemp = "inventoryUploader.xls"
            End Select

            LoadAttachment("attachment", DLPath, FTemp)
        End If
    End Sub

    Public Sub LoadAttachment(ByVal fileContentDispo As String, ByVal filePath As String, ByVal FilenameDotExtension As String)
        'get content type
        Dim fileParse() As String = Split(FilenameDotExtension, ".")

        'Clear buffer	
        Response.Clear()

        With loadAtt
            Response.ContentType = .GetContentType(fileParse(fileParse.Length - 1))

            'get content disposition
            Select Case fileContentDispo
                Case "attachment"
                    Response.AddHeader("Content-Disposition", "attachment; filename=" & FilenameDotExtension)
                Case "inline"
                    Response.AddHeader("Content-Disposition", "inline: filename=" & FilenameDotExtension)
            End Select

            Response.WriteFile(filePath & FilenameDotExtension)
            Response.End()
        End With
    End Sub
End Class