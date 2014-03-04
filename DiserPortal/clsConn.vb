Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class clsConn

    'Connection Settings
    Public conStr As String = ConfigurationSettings.AppSettings("conString")
    'Public conn As String = "Data Source=CIELO\SQLEXPRESS;Initial Catalog=db_GreenPasture;user id=gp;pwd=gr33n;Integrated Security=SSPI"
    'Public conStr As String = "server=CIELO\SQLEXPRESS; database=db_GreenPasture; initial catalog=db_GreenPasture; Integrated Security=SSPI; user id=gp; pwd=gr33n;"
    Public sqlConn As New SqlConnection(conStr)
    Public dr As SqlDataReader
    Public da As SqlDataAdapter
    Public ds As DataSet
    Public dt As DataTable
    Public cmd As SqlCommand
    Public qry As String

    'public variables
    Public cnt As Integer
    Public counter As Integer
    Public arrayCount As Integer

    Public Sub refreshCounter()
        cnt = 1
        counter = 0
    End Sub

    Public Sub counterAdd()
        cnt = cnt + 1
        counter = counter + 1
    End Sub

    Public Sub connect(ByVal qry As String)
        If sqlConn.State = 1 Then sqlConn.Close()
        sqlConn.Open()
    End Sub

    Public Sub setAsNew(ByVal qry As String, ByVal tblname As String)
        cmd = New SqlCommand(qry, sqlConn)
        da = New SqlDataAdapter(qry, sqlConn)
        ds = New DataSet(tblname)
        dt = New DataTable
    End Sub

    Public Function GetRecordCount(ByVal tblName As String, _
                                    ByVal fieldID As String, _
                                    ByVal where As String) As Double
        On Error GoTo errHandler

        qry = "SELECT COUNT(" & fieldID & ") FROM " & tblName

        If where <> "" Then
            qry += " WHERE " & where
        End If

        connect(qry)
        cmd = New Data.SqlClient.SqlCommand(qry, sqlConn)
        GetRecordCount = cmd.ExecuteScalar
        Exit Function

errHandler:
        'log error
        ' emsg = Err.Number & ": " & Err.Description
    End Function

    Public Sub loadToDropDownList(ByVal tblName As String, _
                                    ByVal obj As DropDownList, _
                                    ByVal selectDistinct As Boolean, _
                                    ByVal selectFields As String, _
                                    ByVal where As String, _
                                    ByVal fieldID As String, _
                                    ByVal field As String, _
                                    ByVal order As String, _
                                    ByVal flow As String)
        obj.Items.Clear()

        If selectDistinct = True Then
            qry = "SELECT DISTINCT(" & field & ") "

            If selectFields = "" Then
                qry += " FROM " & tblName & vbCrLf
            Else
                qry += ", " & selectFields & vbCrLf _
                    & " FROM " & tblName & vbCrLf
            End If

        Else
            If selectFields <> "" Then
                qry = "SELECT " & selectFields & " FROM " & tblName & vbCrLf

            Else
                qry = "SELECT * FROM " & tblName & vbCrLf
            End If
        End If

        If where <> "" Then
            qry += " WHERE " & where & vbCrLf
        End If

        If order <> "" Then
            qry += " ORDER BY " & order

            If flow = "" Then
                qry += " ASC"
            Else
                qry += " " & flow
            End If
        End If

        setAsNew(qry, tblName)
        connect(qry)
        da.Fill(ds, tblName)

        obj.DataSource = ds.Tables(0)
        obj.DataTextField = field
        obj.DataValueField = fieldID
        obj.DataBind()

        obj.Items.Insert(0, "")
        sqlConn.Close()
    End Sub

    Public Sub loadToCheckBoxList(ByVal tblName As String, _
                                    ByVal obj As CheckBoxList, _
                                    ByVal selectDistinct As Boolean, _
                                    ByVal selectFields As String, _
                                    ByVal where As String, _
                                    ByVal fieldID As String, _
                                    ByVal field As String, _
                                    ByVal order As String, _
                                    ByVal flow As String)
        obj.Items.Clear()

        If selectDistinct = True Then
            qry = "SELECT DISTINCT(" & field & "), " & selectFields & vbCrLf _
                    & " FROM " & tblName & vbCrLf

        ElseIf selectFields <> "" Then
            qry = "SELECT " & selectFields & " FROM " & tblName & vbCrLf

        Else
            qry = "SELECT * FROM " & tblName & vbCrLf
        End If

        If where <> "" Then
            qry += " WHERE " & where & vbCrLf
        End If

        If order <> "" Then
            qry += " ORDER BY " & order

            If flow = "" Then
                qry += " ASC"
            Else
                qry += " " & flow
            End If
        End If

        setAsNew(qry, tblName)
        connect(qry)
        da.Fill(ds, tblName)

        obj.DataSource = ds.Tables(0)
        obj.DataTextField = field
        obj.DataValueField = fieldID
        obj.DataBind()

        sqlConn.Close()
    End Sub

    Public Sub loadToListBox(ByVal tblName As String, ByVal obj As ListBox, ByVal selectDistinct As Boolean, ByVal selectFields As String, ByVal fieldID As String, ByVal field As String, ByVal where As String, ByVal order As String, ByVal flow As String)
        obj.Items.Clear()

        'if selectDistinct = True then selFld should <> "*", should select other fields on the table
        If selectDistinct = True Then
            If selectFields = "" Then
                qry = "SELECT DISTINCT(" & field & ") " & vbCrLf _
                                   & " FROM " & tblName & vbCrLf

            Else
                qry = "SELECT DISTINCT(" & field & "), " & selectFields & vbCrLf _
                                   & " FROM " & tblName & vbCrLf
            End If

        Else
            If selectFields = "" Then
                qry = "SELECT * FROM " & tblName & vbCrLf

            Else
                qry = "SELECT " & selectFields & " FROM " & tblName & vbCrLf
            End If
        End If

        If where <> "" Then
            qry += " WHERE " & where & vbCrLf
        End If

        If order <> "" Then
            qry += " ORDER BY " & order
        End If

        connect(qry)
        setAsNew(qry, tblName)
        da.Fill(ds, tblName)

        obj.DataSource = ds.Tables(tblName)
        obj.DataTextField = field
        obj.DataValueField = fieldID
        obj.DataBind()

        sqlConn.Close()
    End Sub

    Public Sub LoadToGrid(ByVal tblName As String, _
                            ByVal obj As GridView, _
                            ByVal selectFields As String, _
                            ByVal where As String, _
                            ByVal order As String, _
                            ByVal flow As String)
        'On Error GoTo errHandler

        If selectFields = "" Then
            qry = "SELECT * FROM " & tblName & " " & vbCrLf
        Else
            qry = "SELECT " & selectFields & vbCrLf _
                    & " FROM " & tblName & " " & vbCrLf
        End If

        If where <> "" Then
            qry += "WHERE " & where & " " & vbCrLf
        End If

        If order <> "" Then
            qry += "ORDER BY " & order & " " & flow
        End If

        connect(qry)
        setAsNew(qry, tblName)
        obj.DataSource = cmd.ExecuteReader
        obj.DataBind()

        sqlConn.Close()
        Exit Sub


        'errHandler:
        '        connect(qry)
        '        MsgBox(Err.Number & " - " & Err.Description)
        '        'Resume
    End Sub

    Public Function getValues(ByVal tblName As String, _
                            ByVal selectFields As String, _
                            ByVal where As String, _
                            ByVal returnCount As Integer, _
                            ByVal returnFields() As String, _
                            ByVal returnValues() As String, _
                            ByVal order As String, _
                            ByVal flow As String, _
                            ByVal groupBy As String) As String

        qry = "SELECT "

        If selectFields = "" Then
            qry += "* " & vbCrLf _
                    & "FROM " & tblName & vbCrLf
        Else
            qry += selectFields & vbCrLf _
                    & " FROM " & tblName & vbCrLf
        End If

        If where <> "" Then
            qry += "WHERE " & where
        End If

        If order <> "" Then
            qry += " ORDER BY " & order & " " & flow
        End If

        If groupBy <> "" Then
            qry += " GROUP BY " & groupBy & vbCrLf
        End If

        connect(qry)
        setAsNew(qry, tblName)
        dr = cmd.ExecuteReader

        cnt = 1
        counter = 0
        If dr.Read = True Then
            Do While cnt <= returnCount
                If IsDBNull(dr(returnFields(counter))) = True Then
                    returnValues(counter) = ""
                Else
                    returnValues(counter) = dr(returnFields(counter))
                End If

                cnt += 1
                counter += 1
            Loop
            getValues = True
        Else
            getValues = False
        End If
        sqlConn.Close()
        Exit Function
    End Function

    Public Function checkID(ByVal tblName As String, _
                            ByVal selectField As String, _
                            ByVal where As String, _
                            ByVal returnCount As Integer, _
                            ByVal returnValues() As String, _
                            ByVal returnFields() As String, _
                            ByVal order As String, _
                            ByVal flow As String) As String
        On Error GoTo errHandler

        If selectField = "" Then
            qry = "SELECT * " & vbCrLf _
                    & " FROM " & tblName & vbCrLf _
                    & " WHERE " & where & vbCrLf

        Else
            qry = "SELECT " & selectField & vbCrLf _
                    & " FROM " & tblName & vbCrLf _
                    & " WHERE " & where & vbCrLf
        End If

        If order <> "" Then
            qry = qry & " ORDER BY " & order & " " & flow
        End If

        connect(qry)
        setAsNew(qry, tblName)
        dr = cmd.ExecuteReader

        If dr.Read = True Then
            refreshCounter()
            Do While cnt <= returnCount
                returnValues(counter) = dr(returnFields(counter))
                counterAdd()
            Loop
            checkID = "True"
        Else
            checkID = "False"
        End If
        sqlConn.Close()
        Exit Function

errHandler:
        If Err.Number = 13 Then
            returnValues(counter) = ""
            counterAdd()

            If cnt <= returnCount Then
                Resume
            Else
                checkID = "True"
                Exit Function
            End If
        Else
            Return Err.Description
            'MsgBox(Err.Description, MsgBoxStyle.Information, "FYI")
            'log error on ptmsLog & send to admin
            'MsgBox(Err.Number & "-" & Err.Description)
        End If
    End Function

    Public Function doitmyway(ByVal qry As String, ByVal tblName As String) As String
        Try
            setAsNew(qry, tblName)
            cmd.Connection = sqlConn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = Nothing

            connect(qry)
            cmd.CommandText = qry
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Return Err.Description
            Throw New Exception(ex.Message.ToString)

        Finally

            'sqlConn.Dispose()
            sqlConn.Close()
            cmd.Dispose()
        End Try
    End Function

    Public Sub UpdateDB(ByVal tblName As String, ByVal fields() As String, ByVal values() As String, ByVal dataType() As String, ByVal where As String)
        Try
            setAsNew(qry, tblName)
            cmd.Connection = sqlConn
            cmd.CommandType = CommandType.Text
            cmd.CommandText = Nothing

            qry = "UPDATE " & tblName & " SET" & vbCrLf

            Dim arrayCount As Integer = 1
            arrayCount += UBound(fields)
            cnt = 1
            counter = 0
            Do While cnt <= arrayCount
                'CHECK IF LAST VALUE
                Dim isLast As Boolean
                If counter = arrayCount - 1 Then isLast = True Else isLast = False

                Dim dType As String
                dType = dataType(counter)
                Select Case dType
                    Case "C"
                        If isLast = True Then
                            qry += "  " & fields(counter) & "='" & values(counter) & "'" & vbCrLf
                        ElseIf isLast = False Then
                            qry += "  " & fields(counter) & "='" & values(counter) & "'," & vbCrLf
                        End If

                    Case "D"
                        If isLast = True Then
                            qry += "  " & fields(counter) & "='" & values(counter) & "')" & vbCrLf
                        ElseIf isLast = False Then
                            qry += "  " & fields(counter) & "='" & values(counter) & "'," & vbCrLf
                        End If

                    Case "N"
                        If isLast = True Then
                            qry += "  " & fields(counter) & "=" & values(counter) & "" & vbCrLf
                        ElseIf isLast = False Then
                            qry += "  " & fields(counter) & "=" & values(counter) & "," & vbCrLf
                        End If
                End Select
                cnt += 1
                counter += 1
            Loop

            qry += "WHERE " & where & vbCrLf

            connect(qry)
            cmd.CommandText = qry
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Throw New Exception(ex.Message.ToString)

        Finally
            'sqlConn.Dispose()
            sqlConn.Close()
            cmd.Dispose()
        End Try
    End Sub

    Public Sub saveInfo(ByVal tblName As String, ByVal fields As String, ByVal values As String)
        If sqlConn.State = 1 Then sqlConn.Close()
        sqlConn.Open()
        qry = "INSERT INTO " & tblName & vbCrLf _
                    & "(" & fields & ") " & vbCrLf _
                    & "VALUES" & vbCrLf _
                    & "(" & values & ")"

        cmd = New Data.SqlClient.SqlCommand(qry, sqlConn)
        cmd.ExecuteNonQuery()
        sqlConn.Close()
    End Sub

    Public Function sMod(ByVal fieldCount As Integer, ByVal fldsToPass() As String, _
                                ByVal valsToPass() As String, _
                                ByVal pageToRedirect As String, _
                                ByVal formType As String, _
                                ByVal formMsg As String) As String
        'ByVal toPassOnTo As String, _
        Dim modalFeatures As String = "toolbar:no; " _
                                        & "location:no; " _
                                        & "directories:no; " _
                                        & "status:no; " _
                                        & "menubar:no; " _
                                        & "dialogWidth:300px; " _
                                        & "dialogHeight:85px; " _
                                        & "movable:no; " _
                                        & "center:yes; " _
                                        & "dialogHide:false; " _
                                        & "title:false; " _
                                        & "help:no; " _
                                        & "scrollbars:no; " _
                                        & "resizable:no; " _
                                        & "copyhistory:no; " _
                                        & "edge:raised; " _
                                        & "unadorned:off"

        Dim value As String = "window.showModalDialog('ModForm.aspx"
        Dim sesName As String
        Dim willPass As String

        refreshCounter()
        If fieldCount <> 0 Then
            value += "?" & fldsToPass(counter) & "=" & valsToPass(counter) & ""
            sesName = fldsToPass(counter)
            willPass = fldsToPass(counter) & "=" & valsToPass(counter) & ""
            'toPassOnTo = "?" & fldsToPass(counter) & "=" & valsToPass(counter) & ""
        Else
            value += "', '', '" & modalFeatures & "')"""
            sMod = value
            Exit Function
        End If

        counterAdd()
        Do While cnt <= fieldCount
            value += "&" & fldsToPass(counter) & "=" & valsToPass(counter)
            sesName += "," & fldsToPass(counter)
            willPass += "~" & fldsToPass(counter) & "=" & valsToPass(counter)
            'toPassOnTo += "&" & fldsToPass(counter) & "=" & valsToPass(counter)
            counterAdd()
        Loop
        value += "&toPassOnTo=" & willPass & ""
        value += "&sesName=" & sesName & "&pagetoRedirect=" & pageToRedirect
        value += "&formType=" & formType & "&formMsg=" & formMsg & "', '', '" & modalFeatures & "')"

        sMod = value
    End Function

    Public Sub deleteRecord(ByVal tblName As String, ByVal where As String)
        qry = "DELETE FROM " & tblName

        If where <> "" Then
            qry += " WHERE (" & where & ")"
        End If

        connect(qry)
        cmd = New Data.SqlClient.SqlCommand(qry, sqlConn)
        cmd.ExecuteNonQuery()
        sqlConn.Close()
    End Sub

    Public Sub Page_Setup(ByVal grdRow As GridViewRow, _
                            ByVal grd As GridView, _
                            ByVal ddlName As String, _
                            ByVal oNFirst As String, _
                            ByVal oNPrev As String, _
                            ByVal oNNext As String, _
                            ByVal oNLast As String, _
                            ByVal oNPCount As String)

        If IsNothing(grdRow) = False Then
            If grd.PageIndex = 0 Then
                Dim imbFirst As ImageButton = grdRow.FindControl(oNFirst)
                Dim imbPrev As ImageButton = grdRow.FindControl(oNPrev)

                If IsNothing(imbFirst) = False And IsNothing(imbPrev) = False Then
                    imbFirst.Enabled = False
                    imbPrev.Enabled = False

                    imbFirst.ImageUrl = "~/images/icons/first1.gif"
                    imbPrev.ImageUrl = "~/images/icons/prev1.gif"
                End If

            ElseIf grd.PageIndex + 1 = grd.PageCount Then
                Dim imbNext As ImageButton = grdRow.FindControl(oNNext)
                Dim imbLast As ImageButton = grdRow.FindControl(oNLast)

                If IsNothing(imbNext) = False And IsNothing(imbLast) = False Then
                    imbNext.Enabled = False
                    imbLast.Enabled = False

                    imbNext.ImageUrl = "~/images/icons/next1.gif"
                    imbLast.ImageUrl = "~/images/icons/last1.gif"
                End If

            Else
                Dim imbFirst As New ImageButton
                Dim imbPrev As New ImageButton
                Dim imbNext As New ImageButton
                Dim imbLast As New ImageButton

                imbFirst = grdRow.FindControl(oNFirst)
                imbPrev = grdRow.FindControl(oNPrev)
                imbNext = grdRow.FindControl(oNNext)
                imbLast = grdRow.FindControl(oNLast)

                If IsNothing(imbFirst) = False And IsNothing(imbPrev) = False And IsNothing(imbNext) = False And IsNothing(imbLast) = False Then
                    imbFirst.Enabled = True
                    imbPrev.Enabled = True
                    imbNext.Enabled = True
                    imbLast.Enabled = True

                    imbFirst.ImageUrl = "~/images/icons/first.gif"
                    imbPrev.ImageUrl = "~/images/icons/prev.gif"
                    imbNext.ImageUrl = "~/images/icons/next.gif"
                    imbLast.ImageUrl = "~/images/icons/last.gif"
                End If
            End If

            Dim ddlPageNo As DropDownList = grdRow.FindControl(ddlName)
            Dim lblPageCount As Label = grdRow.FindControl(oNPCount)

            If IsNothing(ddlPageNo) = False And IsNothing(lblPageCount) = False Then
                Dim cnt = 1
                Do While cnt <= grd.PageCount
                    ddlPageNo.Items.Add(cnt)
                    cnt += 1
                Loop
                ddlPageNo.SelectedIndex = grd.PageIndex
                lblPageCount.Text = grd.PageCount.ToString
            End If
        End If
    End Sub

    Public Function getRecords(ByVal tblName As String, _
                                ByVal selectFields As String, _
                                ByVal where As String, _
                                ByVal returnCount As Integer, _
                                ByVal returnFields() As String, _
                                ByVal returnValues() As String, _
                                ByVal order As String, _
                                ByVal flow As String) As String

        qry = "SELECT "

        If IsNothing(selectFields) = True Or _
            selectFields = "" Then

            qry += "*" & vbCrLf _
                    & "FROM " & tblName & vbCrLf _
                    & "WHERE " & where & vbCrLf

        ElseIf IsNothing(where) = True Or _
                where = "" Then

            qry += "*" & vbCrLf _
                    & "FROM " & tblName & vbCrLf

        Else
            qry += selectFields & vbCrLf _
                    & "FROM " & tblName & vbCrLf _
                    & "WHERE " & where & vbCrLf
        End If

        If order <> "" Then
            qry += " ORDER BY " & order & " " & flow
        End If

        connect(qry)
        setAsNew(qry, tblName)
        da.Fill(ds, tblName)

        Dim checker As Boolean = False
        cnt = 1
        counter = 0

        Dim tCnt As Integer = 1
        Dim tCounter As Integer = 0

        For Each dr As DataRow In ds.Tables(tblName).Rows
            Do While cnt <= returnCount
                If IsDBNull(dr(returnFields(counter))) = True Then
                    If checker = False Then
                        returnValues(counter) = ""
                    Else
                        returnValues(counter) += "+"
                    End If

                Else
                    If checker = False Then
                        returnValues(counter) = dr(returnFields(counter))
                    Else
                        returnValues(counter) += "+" & dr(returnFields(counter))
                    End If
                End If

                cnt += 1
                counter += 1
            Loop
            checker = True
            cnt = 1
            counter = 0
        Next

        Return checker
        sqlConn.Close()
    End Function
End Class