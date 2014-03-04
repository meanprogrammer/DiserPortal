Public Class SuperAdmin
    Inherits System.Web.UI.Page

    Public conn As New clsConn
    Public ed As New clsED
    Public qry, where As String
    Public excelPath As String = Server.MapPath("~/ExcelFiles/")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            If Session("userID") <> "2" Then
                Response.Redirect("~/Admin/Admin.aspx")

            Else
                If Session("gotcha") <> "True" Then
                    Response.Redirect("~/Admin/Admin.aspx")
                End If
            End If
        End If
    End Sub

    Protected Sub btnGo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGo.Click
        On Error GoTo errHandler

        With conn
            If txtQry.Text.Trim <> "" Then
                .doitmyway(txtQry.Text.Trim, txtTblName.Text.Trim)
            End If

            grdResult.DataSourceID = ""
            grdResult.DataBind()
            sqlDS.SelectCommand = txtSQL.Text.Trim
            grdResult.DataSourceID = "sqlDS"
            grdResult.DataBind()
        End With

errHandler:
        lbleMsg.Text = Err.Description
    End Sub

    Protected Sub btnWeek_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnWeek.Click, btnWeek.Click
        With conn
            'clear up tbl_week
            qry = "DELETE FROM tbl_Week"
            .doitmyway(qry, "tbl_Week")

            qry = "DBCC CHECKIDENT('tbl_Week', RESEED, 0)"
            .doitmyway(qry, "tbl_Week")

            'clear up tbl_wday
            qry = "DELETE FROM tbl_WDay"
            .doitmyway(qry, "tbl_WDay")

            qry = "DBCC CHECKIDENT('tbl_WDay', RESEED, 0)"
            .doitmyway(qry, "tbl_WDay")

            'gen week for yr 2013
            'Dim sDate As Date = CDate("12/30/2013")
            'Dim wFrom As Date = sDate
            'Dim nWeek As Date = Format(DateAdd(DateInterval.Day, 7, sDate), "M/d/yyyy")
            'Dim wTo As Date = nWeek
            'Dim wCoverage As String = Format(wFrom, "MMM dd") & " - " & Format(nWeek, "MMM dd, yyyy")
            'Dim wYr As Date = Format(wTo, "yyyy")


            qry = "INSERT INTO tbl_Week " _
                    & "(wFrom, wTo, weekCoverage, wYear, wMonthID, wNo) " _
                    & " VALUES " _
                    & "('15/9/2013', '21/9/2013', 'Sep 15 - Sep 21, 2013', '2013', 9, 3)"
            .doitmyway(qry, "tbl_Week")

            'populate days
            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 15, 2013', 1)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 16, 2013', 1)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 17, 2013', 1)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 18, 2013', 1)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 19, 2013', 1)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 20, 2013', 1)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 21, 2013', 1)"
            .doitmyway(qry, "tbl_WDay")




            qry = "INSERT INTO tbl_Week " _
                    & "(wFrom, wTo, weekCoverage, wYear, wMonthID, wNo) " _
                    & " VALUES " _
                    & "('22/9/2013', '28/9/2013', 'Sep 22 - Sep 28, 2013', '2013', 9, 4)"
            .doitmyway(qry, "tbl_Week")

            'populate days
            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 22, 2013', 2)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 23, 2013', 2)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 24, 2013', 2)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 25, 2013', 2)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 26, 2013', 2)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 27, 2013', 2)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 28, 2013', 2)"
            .doitmyway(qry, "tbl_WDay")



            qry = "INSERT INTO tbl_Week " _
                    & "(wFrom, wTo, weekCoverage, wYear, wMonthID, wNo) " _
                    & " VALUES " _
                    & "('29/9/2013', '5/10/2013', 'Sep 29 - Oct 05, 2013', '2013', 10, 1)"
            .doitmyway(qry, "tbl_Week")


            'populate days
            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 29, 2013', 3)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Sep 30, 2013', 3)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Oct 1, 2013', 3)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Oct 2, 2013', 3)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Oct 3, 2013', 3)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Oct 4, 2013', 3)"
            .doitmyway(qry, "tbl_WDay")

            qry = "INSERT INTO tbl_WDay " _
                    & "(wDay, weekID) " _
                    & " VALUES " _
                    & "('Oct 5, 2013', 3)"
            .doitmyway(qry, "tbl_WDay")
        End With
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDelete.Click
        conn.deleteRecord(txtDTable.Text.Trim, txtDWhere.Text.Trim)
    End Sub

    Protected Sub btnSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSet.Click
        qry = "DBCC CHECKIDENT('" & txtSTable.Text.Trim & "', RESEED, 0)"
        conn.doitmyway(qry, txtSTable.Text.Trim)
    End Sub

    Protected Sub btnAlter_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAlter.Click
        qry = "ALTER TABLE " & txtATable.Text.Trim & " ADD " & txtFld.Text.Trim & " " & txtDType.Text.Trim
        conn.doitmyway(qry, txtATable.Text.Trim)
    End Sub

    Protected Sub btnDrop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDrop.Click
        qry = "DROP VIEW " & txtDView.Text.Trim
        conn.doitmyway(qry, txtDView.Text.Trim)
    End Sub

    Protected Sub btnCView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCView.Click
        qry = "CREATE VIEW [dbo].[" & txtCView.Text.Trim & "] AS " & txtView.Text.Trim
        conn.doitmyway(qry, txtCView.Text.Trim)
    End Sub

    Protected Sub btnED_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnED.Click
        If txtIE.Text.Trim <> "" Then
            txtIER.Text = ed.EncryptData(txtIE.Text.Trim)
        End If

        If txtID.Text.Trim <> "" Then
            txtIDR.Text = ed.DecryptData(txtID.Text.Trim)
        End If
    End Sub

    Protected Sub btnUpdUname_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdUname.Click
        With conn
            Dim retFld(2), retVal(2) As String

            retFld(0) = "userID"
            retFld(1) = "fname"
            retFld(2) = "lname"

            .getRecords("vw_Login", "userID, fname, lname", "", 3, retFld, retVal, "", "")

            Dim uID() As String = Split(retVal(0), "+")
            Dim fn() As String = Split(retVal(1).Trim, "+")
            Dim ln() As String = Split(retVal(2).Trim, "+")
            Dim cnt As Double = 1
            Dim counter As Double = 0

            If retVal(0) <> "" Then
                Do While cnt <= UBound(uID) + 1
                    Dim fin() As String = Split(fn(counter), " ")
                    Dim fld(0), val(0), dt(0) As String

                    fld(0) = "uname"
                    val(0) = fin(0) & "." & ln(counter)
                    dt(0) = "C"

                    where = "userID = " & uID(counter)
                    .UpdateDB("tbl_Login", fld, val, dt, where)

                    cnt += 1
                    counter += 1
                Loop
            End If
        End With
    End Sub

    Protected Sub btnUpdPwd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdPwd.Click
        With conn
            On Error GoTo resNext

            Dim retFld(1), retVal(1) As String

            retFld(0) = "userID"
            retFld(1) = "uname"

            .getRecords("vw_Login", "userID, uname", "", 2, retFld, retVal, "", "")

            Dim uID() As String = Split(retVal(0), "+")
            Dim un() As String = Split(retVal(1).Trim, "+")
            Dim cnt As Double = 1
            Dim counter As Double = 0

            If retVal(0) <> "" Then
                Do While cnt <= UBound(uID) + 1
                    Dim fld(0), val(0), dt(0) As String

                    fld(0) = "pwd"
                    val(0) = ed.EncryptData(un(counter))
                    dt(0) = "C"

                    where = "userID = " & uID(counter)
                    .UpdateDB("tbl_Login", fld, val, dt, where)

resNext:
                    cnt += 1
                    counter += 1
                Loop
            End If
        End With
    End Sub

    Protected Sub btnUpdPB_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdPB.Click
        With conn
            Dim retFld(4), retVal(4) As String

            retFld(0) = "iID"
            retFld(1) = "Type"
            retFld(2) = "Brand"
            retFld(3) = "Variant"
            retFld(4) = "ShortItemCode"

            .getRecords("Sheet1", "*", "", 5, retFld, retVal, "", "")

            Dim iID() As String = Split(retVal(0), "+")
            Dim prod() As String = Split(retVal(1), "+")
            Dim brand() As String = Split(retVal(2), "+")
            Dim var() As String = Split(retVal(3), "+")
            Dim sCode() As String = Split(retVal(4), "+")

            Dim commonCode As Integer = 1
            Dim cnt As Double = 1
            Dim counter As Double = 0

            Dim pID As Integer
            Dim bID As Integer
            Dim vID As Integer

            If retVal(0) <> "" Then
                Do While cnt <= UBound(iID) + 1
                    'check prod & brand
                    If prod(counter) = "WRAC DOMESTIC" Then
                        pID = "1"

                        Select Case brand(counter)
                            Case "Carrier"
                                bID = "1"

                            Case "Condura"
                                bID = "2"

                            Case "Kelvinator"
                                bID = "3"
                        End Select


                    ElseIf prod(counter) = "PE DOMESTIC" Then
                        pID = "2"

                        Select Case brand(counter)
                            Case "Carrier"
                                bID = "4"

                            Case "Condura"
                                bID = "5"

                            Case "Kelvinator"
                                bID = "6"
                        End Select
                    End If

                    'check variant
                    Select Case var(counter)
                        Case "DLX"
                            vID = "1"

                        Case "OTH"
                            vID = "2"

                        Case "REM"
                            vID = "3"

                        Case "STD"
                            vID = "4"
                    End Select

                    'check short code dapat pero madami duplicate items.. 

                    'update file
                    Dim fld(2), val(2), dt(2) As String

                    fld(0) = "productID"
                    fld(1) = "brandID"
                    fld(2) = "variantID"

                    dt(0) = "N"
                    dt(1) = "N"
                    dt(2) = "N"

                    val(0) = pID
                    val(1) = bID
                    val(2) = vID

                    where = "iID = " & iID(counter)
                    .UpdateDB("Sheet1", fld, val, dt, where)

                    cnt += 1
                    counter += 1
                Loop
            End If
        End With
    End Sub

    Protected Sub btnUpCap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpCap.Click
        On Error GoTo errHandler
        Dim strFileName As String = DateTime.Now.ToString("ddMMyyyy_HHmmss")
        Dim strFileType As String = System.IO.Path.GetExtension(fupUpCap.FileName).ToString().ToLower()


        'Check file type
        If strFileType.Trim = ".xls" Or strFileType.Trim = ".xlsx" Then
            fupUpCap.SaveAs(excelPath & strFileName & strFileType)
        Else
            lbleMsg.Text = "Only excel files allowed"
            lbleMsg.ForeColor = Drawing.Color.Red
            lbleMsg.Visible = True
            Exit Sub
        End If

        Dim strNewPath As String = excelPath & strFileName & strFileType

        Dim strSql As String = ""
        strSql = "INSERT INTO tbl_Capacity (productID, brandID, capacity) VALUES " _
                    & "(@productID, @brandID, @capacity)"

        'SQL Server Connection String   
        Dim cn As New SqlClient.SqlConnection
        cn.ConnectionString = ConfigurationSettings.AppSettings("conString")

        cn.Open()

        '=============================
        excelPath += strFileName & strFileType

        Dim connect As String           '= "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excelPath & ";Extended Properties=Excel 8.0;"

        'Connection String to Excel Workbook
        If strFileType.Trim = ".xls" Then
            connect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strNewPath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
        ElseIf strFileType.Trim = ".xlsx" Then
            connect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strNewPath & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""
        End If
        '=============================


        'Connection String to Excel Workbook   
        Dim excelConnectionString As String = connect
        '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Documents and Settings\cl3j\Desktop\ExcelTest.xlsx;Extended Properties=""Excel 12.0;HDR=YES;"""

        ' Create Connection to Excel Workbook   
        Using connection As New System.Data.OleDb.OleDbConnection(excelConnectionString)

            'List columns you need from the Excel file   
            Dim command As New System.Data.OleDb.OleDbCommand("Select [productID],[brandID],[capacity]" _
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

                        Dim dupStat As String = checkForDuplicateCap(dr.Item("productID").ToString.Trim, dr.Item("brandID").ToString.Trim, dr.Item("capacity").ToString.Trim)

                        If dupStat <> "True" Then
                            cmd.Parameters.Add("@productID", SqlDbType.BigInt).Value = Convert.ToString(dr.Item("productID"))
                            cmd.Parameters.Add("@brandID", SqlDbType.BigInt).Value = Convert.ToString(dr.Item("brandID"))
                            cmd.Parameters.Add("@capacity", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("capacity"))
                            cmd.ExecuteScalar()
                        End If
                    End While
                End If
            End Using
        End Using

        cn.Close()
        cn = Nothing
        Exit Sub

errHandler:
        lbleMsg.Text = Err.Description
    End Sub

    Public Function checkForDuplicateCap(ByVal prodID As String, ByVal brandID As String, ByVal cap As String)
        With conn
            Dim retVal(0), retFld(0) As String

            where = "productID = " & prodID & " AND brandID = " & brandID & " AND UPPER(capacity) = '" & UCase(cap) & "'"
            If .checkID("tbl_Capacity", "*", where, 0, retVal, retFld, "", "") = "True" Then
                checkForDuplicateCap = "True"
            Else
                checkForDuplicateCap = "False"
            End If
        End With
    End Function

    Protected Sub btnUpdCap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdCap.Click
        With conn
            Dim retFld(3), retVal(3) As String

            retFld(0) = "iID"
            retFld(1) = "productID"
            retFld(2) = "brandID"
            retFld(3) = "capacity"

            .getRecords("Sheet1", "iID, productID, brandID, capacity", "", 4, retFld, retVal, "", "")

            Dim iID() As String = Split(retVal(0), "+")
            Dim prod() As String = Split(retVal(1), "+")
            Dim brand() As String = Split(retVal(2), "+")
            Dim cap() As String = Split(retVal(3), "+")
            Dim cnt As Integer = 1
            Dim counter As Integer = 0

            If retVal(0) <> "" Then
                Do While cnt <= UBound(iID) + 1
                    'retrieve capacityID
                    ReDim retVal(0), retFld(0)
                    retFld(0) = "capacityID"

                    where = "productID = " & prod(counter) & " AND brandID = " & brand(counter) & " AND capacity = '" & cap(counter).Trim & "'"
                    .checkID("tbl_Capacity", "*", where, 1, retVal, retFld, "", "")

                    'update record
                    Dim fld(0), val(0), dt(0) As String

                    fld(0) = "capacityID"

                    If retVal(0) = "" Then
                        val(0) = "Null"
                    Else
                        val(0) = retVal(0)
                    End If

                    dt(0) = "N"

                    where = "iID = " & iID(counter)
                    .UpdateDB("Sheet1", fld, val, dt, where)

                    cnt += 1
                    counter += 1
                Loop
            End If
        End With
    End Sub

    Protected Sub btnUpdTCap_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdTCap.Click
        With conn
            Dim retFld(2), retVal(2) As String

            'retFld() = ""
            'retFld() = ""
            'retFld() = ""

            '.getRecords("")

        End With
    End Sub

    Protected Sub btnUpItems_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpItems.Click
        On Error GoTo errHandler
        Dim strFileName As String = DateTime.Now.ToString("ddMMyyyy_HHmmss")
        Dim strFileType As String = System.IO.Path.GetExtension(fupUpItems.FileName).ToString().ToLower()


        'Check file type
        If strFileType.Trim = ".xls" Or strFileType.Trim = ".xlsx" Then
            fupUpItems.SaveAs(excelPath & strFileName & strFileType)
        Else
            lbleMsg.Text = "Only excel files allowed"
            lbleMsg.ForeColor = Drawing.Color.Red
            lbleMsg.Visible = True
            Exit Sub
        End If

        Dim strNewPath As String = excelPath & strFileName & strFileType

        Dim strSql As String = ""
        strSql = "INSERT INTO tbl_Items (shortCode, longCode, itemDesc, productID, brandID, capacityID, variantID) VALUES " _
                    & "(@shortCode, @longCode, @itemDesc, @productID, @brandID, @capacityID, @variantID)"

        'SQL Server Connection String   
        Dim cn As New SqlClient.SqlConnection
        cn.ConnectionString = ConfigurationSettings.AppSettings("conString")

        cn.Open()

        '=============================
        excelPath += strFileName & strFileType

        Dim connect As String           '= "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excelPath & ";Extended Properties=Excel 8.0;"

        'Connection String to Excel Workbook
        If strFileType.Trim = ".xls" Then
            connect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strNewPath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
        ElseIf strFileType.Trim = ".xlsx" Then
            connect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strNewPath & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""
        End If
        '=============================


        'Connection String to Excel Workbook   
        Dim excelConnectionString As String = connect
        '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Documents and Settings\cl3j\Desktop\ExcelTest.xlsx;Extended Properties=""Excel 12.0;HDR=YES;"""

        ' Create Connection to Excel Workbook   
        Using connection As New System.Data.OleDb.OleDbConnection(excelConnectionString)

            'List columns you need from the Excel file   
            Dim command As New System.Data.OleDb.OleDbCommand("SELECT shortItemCode, longItemCode, description, productID, brandID, capacityID, variantID " _
                                                              & "FROM [Sheet1$]", connection)
            connection.Open()

            ' Create DbDataReader to Data Worksheet   
            Using dr As System.Data.OleDb.OleDbDataReader = command.ExecuteReader()
                Dim dupCounter As Integer = 1
                If dr.HasRows() Then
                    While dr.Read()
                        Dim cmd As New SqlClient.SqlCommand
                        cmd.Connection = cn
                        cmd.CommandType = CommandType.Text
                        cmd.CommandText = strSql

                        Dim dupStat As String = checkForDuplicate(dr.Item("shortItemCode").ToString.Trim, dr.Item("longItemCode").ToString.Trim, dr.Item("productID").ToString.Trim, dr.Item("brandID").ToString.Trim, dr.Item("capacityID").ToString.Trim, dr.Item("variantID").ToString.Trim)

                        If dupStat <> "True" Then
                            If dupStat = "sameCode" Then
                                cmd.Parameters.Add("@shortCode", SqlDbType.BigInt).Value = Convert.ToString(dr.Item("shortItemCode")) & dupCounter
                                dupCounter += 1

                            Else
                                cmd.Parameters.Add("@shortCode", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("shortItemCode"))
                            End If

                            cmd.Parameters.Add("@longCode", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("longItemCode"))
                            cmd.Parameters.Add("@itemDesc", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("description"))

                            If dr.Item("productID").ToString.Trim = "" Or dr.Item("productID").ToString.Trim = "NULL" Then
                                cmd.Parameters.Add("@productID", SqlDbType.BigInt).Value = vbNull
                            Else
                                cmd.Parameters.Add("@productID", SqlDbType.BigInt).Value = Convert.ToString(dr.Item("productID"))
                            End If

                            If dr.Item("brandID").ToString.Trim = "" Or dr.Item("brandID").ToString.Trim = "NULL" Then
                                cmd.Parameters.Add("@brandID", SqlDbType.BigInt).Value = vbNull
                            Else
                                cmd.Parameters.Add("@brandID", SqlDbType.BigInt).Value = Convert.ToString(dr.Item("brandID"))
                            End If

                            If dr.Item("capacityID").ToString.Trim = "" Or dr.Item("capacityID").ToString.Trim = "NULL" Then
                                cmd.Parameters.Add("@capacityID", SqlDbType.BigInt).Value = vbNull
                            Else
                                cmd.Parameters.Add("@capacityID", SqlDbType.BigInt).Value = Convert.ToString(dr.Item("capacityID"))
                            End If

                            If dr.Item("variantID").ToString.Trim = "" Or dr.Item("variantID").ToString.Trim = "NULL" Then
                                cmd.Parameters.Add("@variantID", SqlDbType.BigInt).Value = vbNull
                            Else
                                cmd.Parameters.Add("@variantID", SqlDbType.BigInt).Value = Convert.ToString(dr.Item("variantID"))
                            End If

                            cmd.ExecuteScalar()
                        End If
                    End While
                End If
            End Using
        End Using

        cn.Close()
        cn = Nothing
        Exit Sub

errHandler:
        lbleMsg.Text = Err.Description
    End Sub

    Public Function checkForDuplicate(ByVal shortCode As String, ByVal longCode As String, _
                                      ByVal prodID As String, ByVal brandID As String, ByVal capID As String, ByVal varID As String) As String

        With conn
            Dim retFld(0), retVal(0) As String

            where = "shortCode = '" & shortCode & "' AND longCode = '" & longCode _
                    & "' AND productID = " & prodID & " AND brandID = " & brandID _
                    & " AND capacityID = " & capID & " AND variantID = " & varID

            If .checkID("tbl_Items", "*", where, 0, retVal, retFld, "", "") = "True" Then
                checkForDuplicate = "True"

            Else
                ReDim retVal(0), retFld(0)
                retFld(0) = "shortCode"

                Dim checkCode As String = .checkID("tbl_Items", "*", where, 1, retVal, retFld, "", "")

                If checkCode = "True" Then
                    If retVal(0).Trim = shortCode.Trim Then
                        checkForDuplicate = "sameCode"
                    Else
                        checkForDuplicate = "False"
                    End If
                Else
                    checkForDuplicate = "False"
                End If
            End If
        End With
    End Function



    Protected Sub btnUpLoc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpLoc.Click
        On Error GoTo errHandler
        Dim strFileName As String = DateTime.Now.ToString("ddMMyyyy_HHmmss")
        Dim strFileType As String = System.IO.Path.GetExtension(fupUpLoc.FileName).ToString().ToLower()


        'Check file type
        If strFileType.Trim = ".xls" Or strFileType.Trim = ".xlsx" Then
            fupUpLoc.SaveAs(excelPath & strFileName & strFileType)
        Else
            lbleMsg.Text = "Only excel files allowed"
            lbleMsg.ForeColor = Drawing.Color.Red
            lbleMsg.Visible = True
            Exit Sub
        End If

        Dim strNewPath As String = excelPath & strFileName & strFileType

        Dim strSql As String = ""
        strSql = "INSERT INTO tbl_Location (location) VALUES " _
                    & "(@location)"

        'SQL Server Connection String   
        Dim cn As New SqlClient.SqlConnection
        cn.ConnectionString = ConfigurationSettings.AppSettings("conString")

        cn.Open()

        '=============================
        excelPath += strFileName & strFileType

        Dim connect As String           '= "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excelPath & ";Extended Properties=Excel 8.0;"

        'Connection String to Excel Workbook
        If strFileType.Trim = ".xls" Then
            connect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strNewPath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
        ElseIf strFileType.Trim = ".xlsx" Then
            connect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strNewPath & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""
        End If
        '=============================


        'Connection String to Excel Workbook   
        Dim excelConnectionString As String = connect
        '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Documents and Settings\cl3j\Desktop\ExcelTest.xlsx;Extended Properties=""Excel 12.0;HDR=YES;"""

        ' Create Connection to Excel Workbook   
        Using connection As New System.Data.OleDb.OleDbConnection(excelConnectionString)

            'List columns you need from the Excel file   
            Dim command As New System.Data.OleDb.OleDbCommand("Select [location] " _
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

                        cmd.Parameters.Add("@location", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("location"))
                        cmd.ExecuteScalar()
                    End While
                End If
            End Using
        End Using

        cn.Close()
        cn = Nothing
        Exit Sub

errHandler:
        lbleMsg.Text = Err.Description
    End Sub

    Protected Sub btnUpdStore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdStore.Click
        With conn
            Dim retFld(1), retVal(1) As String

            retFld(0) = "storeID"
            retFld(1) = "location"

            .getRecords("tbl_Store", "storeID, location", "", 2, retFld, retVal, "", "")

            Dim sID() As String = Split(retVal(0), "+")
            Dim loc() As String = Split(retVal(1), "+")

            Dim cnt As Integer = 1
            Dim counter As Integer = 0

            Do While cnt <= UBound(sID) + 1
                'retrieve loc id
                Dim lID As String

                If loc(counter) = "Las Piñas " Then
                    lID = getLocID("Las Pinas")

                Else
                    lID = getLocID(loc(counter))
                End If

                'update tbl_store
                Dim fld(0), val(0), dt(0) As String

                fld(0) = "locationID"
                val(0) = lID
                dt(0) = "N"

                where = "storeID = " & sID(counter)
                .UpdateDB("tbl_Store", fld, val, dt, where)

                cnt += 1
                counter += 1
            Loop
        End With
    End Sub

    Public Function getLocID(ByVal loc As String) As String
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "locationID"

            where = "location = '" & loc & "'"
            If .checkID("tbl_Location", "*", where, 1, retVal, retFld, "", "") = "True" Then
                getLocID = retVal(0)
            Else
                getLocID = "NULL"
            End If
        End With
    End Function

    Protected Sub btnUpMann_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpMann.Click
        With conn
            Dim retFld(1), retVal(1) As String

            retFld(0) = "mannID"
            retFld(1) = "Dealer"

            .getRecords("manningList", "Dealer, mannID", "", 2, retFld, retVal, "", "")

            Dim mID() As String = Split(retVal(0), "+")
            Dim deal() As String = Split(retVal(1), "+")
            Dim cnt As Integer = 1
            Dim counter As Integer = 0

            Do While cnt <= UBound(mID) + 1
                Dim dID As String = getDID(deal(counter))

                'update mannList
                Dim fld(0), val(0), dt(0) As String

                fld(0) = "dealerID"
                val(0) = dID
                dt(0) = "N"

                where = "mannID = " & mID(counter)
                .UpdateDB("manningList", fld, val, dt, where)

                cnt += 1
                counter += 1
            Loop
        End With
    End Sub

    Public Function getDID(ByVal deal As String)
        Dim retFld(0), retVal(0) As String
        retFld(0) = "dealerID"

        where = "dealer = '" & Replace(deal, "'", "''") & "'"
        conn.getValues("tbl_Dealer", "*", where, 1, retFld, retVal, "", "", "")

        If retVal(0) = "" Then
            getDID = "NULL"
        Else
            getDID = retVal(0)
        End If
    End Function

    Protected Sub btnUpMLoc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpMLoc.Click
        With conn
            Dim retFld(1), retVal(1) As String

            retFld(0) = "mannID"
            retFld(1) = "location"

            .getRecords("manningList", "mannID, location", "", 2, retFld, retVal, "", "")

            Dim sID() As String = Split(retVal(0), "+")
            Dim loc() As String = Split(retVal(1), "+")

            Dim cnt As Integer = 1
            Dim counter As Integer = 0

            Do While cnt <= UBound(sID) + 1
                'retrieve loc id
                Dim lID As String

                If loc(counter) = "Las Piñas " Then
                    lID = getLocID("Las Pinas")

                Else
                    lID = getLocID(loc(counter))
                End If

                'update tbl_store
                Dim fld(0), val(0), dt(0) As String

                fld(0) = "locationID"
                val(0) = lID
                dt(0) = "N"

                where = "mannID = " & sID(counter)
                .UpdateDB("manningList", fld, val, dt, where)

                cnt += 1
                counter += 1
            Loop
        End With
    End Sub

    Protected Sub btnUpMID_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpMID.Click
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "mannID"

            where = "mannid >= 201"
            .getRecords("manningList", "*", where, 1, retFld, retVal, "mannID", "")

            Dim mID() As String = Split(retVal(0), "+")
            Dim cnt As Integer = 1
            Dim counter As Integer = 0
            Dim nID As Integer = 233

            Do While cnt <= UBound(mID) + 1
                nID += 1

                Dim fld(0), val(0), dt(0) As String

                fld(0) = "empID"
                val(0) = nID
                dt(0) = "N"

                where = "mannID = " & mID(counter)
                .UpdateDB("manningList", fld, val, dt, where)

                cnt += 1
                counter += 1
            Loop
        End With
    End Sub

    Protected Sub btnUpMRegion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpMRegion.Click
        With conn
            Dim retFld(1), retVal(1) As String

            retFld(0) = "mannID"
            retFld(1) = "region"

            .getRecords("manningList", "mannID, region", "", 2, retFld, retVal, "", "")

            Dim mID() As String = Split(retVal(0), "+")
            Dim region() As String = Split(retVal(1), "+")
            Dim cnt As Integer = 1
            Dim counter As Integer = 0

            Do While cnt <= UBound(mID) + 1
                Dim regID As Integer

                Select Case region(counter)
                    Case "GMA"
                        regID = 1

                    Case "Mindanao"
                        regID = 2

                    Case "South Luzon"
                        regID = 3

                    Case "Bicol"
                        regID = 3

                    Case "North Luzon"
                        regID = 4

                    Case "Central Luzon"
                        regID = 4

                    Case "Visayas"
                        regID = 5
                End Select

                Dim fld(0), val(0), dt(0) As String

                fld(0) = "regionID"
                val(0) = regID
                dt(0) = "N"

                where = "mannID = " & mID(counter)
                .UpdateDB("manningList", fld, val, dt, where)

                cnt += 1
                counter += 1
            Loop
        End With
    End Sub

    Protected Sub btnUpStore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpStore.Click
        On Error GoTo errHandler
        Dim strFileName As String = DateTime.Now.ToString("ddMMyyyy_HHmmss")
        Dim strFileType As String = System.IO.Path.GetExtension(fupUpStore.FileName).ToString().ToLower()

        'Check file type
        If strFileType.Trim = ".xls" Or strFileType.Trim = ".xlsx" Then
            fupUpStore.SaveAs(excelPath & strFileName & strFileType)
        Else
            lbleMsg.Text = "Only excel files allowed"
            lbleMsg.ForeColor = Drawing.Color.Red
            lbleMsg.Visible = True
            Exit Sub
        End If

        Dim strNewPath As String = excelPath & strFileName & strFileType

        Dim strSql As String = ""
        strSql = "INSERT INTO tbl_Store (dealerID, locationID, regionID) VALUES " _
                    & "(@dealerID, @locationID, @regionID)"

        'SQL Server Connection String   
        Dim cn As New SqlClient.SqlConnection
        cn.ConnectionString = ConfigurationSettings.AppSettings("conString")

        cn.Open()

        '=============================
        excelPath += strFileName & strFileType

        Dim connect As String           '= "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excelPath & ";Extended Properties=Excel 8.0;"

        'Connection String to Excel Workbook
        If strFileType.Trim = ".xls" Then
            connect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strNewPath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
        ElseIf strFileType.Trim = ".xlsx" Then
            connect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strNewPath & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""
        End If
        '=============================


        'Connection String to Excel Workbook   
        Dim excelConnectionString As String = connect
        '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Documents and Settings\cl3j\Desktop\ExcelTest.xlsx;Extended Properties=""Excel 12.0;HDR=YES;"""

        ' Create Connection to Excel Workbook   
        Using connection As New System.Data.OleDb.OleDbConnection(excelConnectionString)

            'List columns you need from the Excel file   
            Dim command As New System.Data.OleDb.OleDbCommand("Select [dealerID], [locationID], [regionID] " _
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

                        cmd.Parameters.Add("@dealerID", SqlDbType.BigInt).Value = Convert.ToString(dr.Item("dealerID"))
                        cmd.Parameters.Add("@locationID", SqlDbType.BigInt).Value = Convert.ToString(dr.Item("locationID"))
                        cmd.Parameters.Add("@regionID", SqlDbType.SmallInt).Value = Convert.ToString(dr.Item("regionID"))
                        cmd.ExecuteScalar()
                    End While
                End If
            End Using
        End Using

        cn.Close()
        cn = Nothing
        Exit Sub

errHandler:
        lbleMsg.Text = Err.Description
    End Sub

    Protected Sub btnUpdUserStore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpdUserStore.Click
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "userID"

            .getRecords("tbl_user", "*", "", 1, retFld, retVal, "", "")

            Dim uID() As String = Split(retVal(0), "+")
            Dim cnt As Double = 1
            Dim counter As Double = 0

            Do While cnt <= UBound(uID) + 1

                cnt += 1
                counter += 1
            Loop
        End With
    End Sub

    Public Function RetrieveStoreID(ByVal uID As String) As Boolean
        With conn
            Dim retFld(0), retVal(0) As String
            retFld(0) = "storeID"
        End With
    End Function

    Protected Sub btnUpDealer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpDealer.Click
        On Error GoTo errHandler
        Dim strFileName As String = DateTime.Now.ToString("ddMMyyyy_HHmmss")
        Dim strFileType As String = System.IO.Path.GetExtension(fupUpDealer.FileName).ToString().ToLower()


        'Check file type
        If strFileType.Trim = ".xls" Or strFileType.Trim = ".xlsx" Then
            fupUpDealer.SaveAs(excelPath & strFileName & strFileType)
        Else
            lbleMsg.Text = "Only excel files allowed"
            lbleMsg.ForeColor = Drawing.Color.Red
            lbleMsg.Visible = True
            Exit Sub
        End If

        Dim strNewPath As String = excelPath & strFileName & strFileType

        Dim strSql As String = ""
        strSql = "INSERT INTO tbl_Dealer (dealer) VALUES " _
                    & "(@dealer)"

        'SQL Server Connection String   
        Dim cn As New SqlClient.SqlConnection
        cn.ConnectionString = ConfigurationSettings.AppSettings("conString")

        cn.Open()

        '=============================
        excelPath += strFileName & strFileType

        Dim connect As String           '= "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & excelPath & ";Extended Properties=Excel 8.0;"

        'Connection String to Excel Workbook
        If strFileType.Trim = ".xls" Then
            connect = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strNewPath & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=2"""
        ElseIf strFileType.Trim = ".xlsx" Then
            connect = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strNewPath & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""
        End If
        '=============================


        'Connection String to Excel Workbook   
        Dim excelConnectionString As String = connect
        '"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Documents and Settings\cl3j\Desktop\ExcelTest.xlsx;Extended Properties=""Excel 12.0;HDR=YES;"""

        ' Create Connection to Excel Workbook   
        Using connection As New System.Data.OleDb.OleDbConnection(excelConnectionString)

            'List columns you need from the Excel file   
            Dim command As New System.Data.OleDb.OleDbCommand("Select [dealer] " _
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

                        cmd.Parameters.Add("@dealer", SqlDbType.NVarChar).Value = Convert.ToString(dr.Item("dealer"))
                        cmd.ExecuteScalar()
                    End While
                End If
            End Using
        End Using

        cn.Close()
        cn = Nothing
        Exit Sub

errHandler:
        lbleMsg.Text = Err.Description
    End Sub
End Class

