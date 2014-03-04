Public Class clsObject

    Public cnt, counter As Integer
    Public newItem As String
    Public chkedVal As String
    Public newVal As String

    Public Const nLine As String = "<br />"

    Public Sub refreshCounter()
        counter = 0
        cnt = 1
    End Sub

    Public Sub counterAdd()
        cnt += 1
        counter += 1
    End Sub

    Public Function decimalFormat(ByVal item As String, ByVal noDecPlaces As Integer) As String
        If InStr(1, item, ".", CompareMethod.Text) = 0 Then
            newItem = item & "."

            'check for the number of decimal places
            refreshCounter()
            Do While cnt <= noDecPlaces
                newItem += "0"
                counterAdd()
            Loop
            decimalFormat = newItem

        Else
            Dim itemArr() As String = Split(item, ".")
            newItem = itemArr(0) & "."

            'check for the no of decimal places
            If Len(itemArr(1)) < noDecPlaces Then
                Dim zeroToAdd As Integer = noDecPlaces - Len(itemArr(1))

                newItem += itemArr(1)
                refreshCounter()
                Do While cnt <= zeroToAdd
                    newItem += "0"
                    counterAdd()
                Loop

            ElseIf Len(itemArr(1)) > noDecPlaces Then
                Dim neededDec As String = Left(itemArr(1), noDecPlaces)
                Dim leftMost As String = Left(itemArr(1), noDecPlaces - 1)
                Dim numBasis As String = Mid(itemArr(1), noDecPlaces + 1, 1)
                Dim numToCheck As String = Right(neededDec, 1)

                If numBasis <= 5 Then
                    newItem += leftMost & numToCheck
                Else
                    newItem += leftMost & numToCheck + 1
                End If
                decimalFormat = newItem

            ElseIf Len(itemArr(1)) = noDecPlaces Then
                newItem += itemArr(1)
                decimalFormat = newItem
            End If
        End If
    End Function

    Public Function stringFormat(ByVal item As String) As String
        If InStr(Trim(item), "'", CompareMethod.Text) <> 0 Then
            Return Replace(Trim(item), "'", "''")
        Else
            Return Trim(item)
        End If
    End Function

    Public Function revertApos(ByVal item As String) As String
        If InStr(Trim(item), "''", CompareMethod.Text) <> 0 Then
            Return Replace(Trim(item), "''", "'")
        Else
            Return Trim(item)
        End If
    End Function

    Public Function toTitleCase(ByVal item As String) As String
        If Trim(item) = "" Then
            Exit Function
        End If

        'check & replace single quote
        If InStr(Trim(item), "'", CompareMethod.Text) <> 0 Then
            item = Replace(Trim(item), "'", "''")
        Else
            item = Trim(item)
        End If

        Dim parse() As String = Split(Trim(item), " ")
        chkedVal = ""

        'check for trailing spaces in between words
        refreshCounter()
        Do While cnt <= UBound(parse) + 1
            If Len(Trim(parse(counter))) <> 0 Then
                chkedVal += parse(counter) & " "
            End If
            counterAdd()
        Loop

        Dim newParse() As String = Split(Trim(chkedVal), " ")
        newVal = ""
        refreshCounter()

        newVal = UCase(Left(newParse(counter), 1)) & LCase(Right(newParse(counter), Len(newParse(counter)) - 1))
        counterAdd()
        Do While cnt <= UBound(newParse) + 1
            newVal += " " & UCase(Left(newParse(counter), 1)) & LCase(Right(newParse(counter), Len(newParse(counter)) - 1))
            counterAdd()
        Loop
        toTitleCase = newVal
    End Function

    'Public Function toPercent(ByVal item As String) As Double
    '    If InStr(item, ".", CompareMethod.Text) = 0 Then
    '        Return CDbl(item & ".00")

    '    Else
    '        Dim itemCheck() As String = Split(item, ".")
    '        Dim decNum As String

    '        'get the decimal (rounded off to 2)
    '        If Len(itemCheck(0)) = 1 Then
    '            'check tenths place
    '            If Left(itemCheck(1), 1) >= 5 Then
    '                decNum = "0.0" & itemCheck(0) + 1
    '            Else
    '                decNum = "0.0" & itemCheck(0)
    '            End If

    '        ElseIf Len(itemCheck(0)) = 2 Then
    '            If Left(itemCheck(1), 1) >= 5 Then
    '                decNum = "0." & Left(itemCheck(0), 1) & Right(itemCheck(0), 1) + 1

    '            Else
    '                decNum = "0." & itemCheck(0)
    '            End If

    '        Else
    '            Dim exNum As String = Left(itemCheck(0), Len(itemCheck(0)) - 2)
    '            Dim checkNum As String = Right(itemCheck(0), 2)

    '            If Left(itemCheck(1), 1) >= 5 Then
    '                decNum = exNum & "." & Left(checkNum, 1) & Right(checkNum, 1) + 1
    '            Else
    '                decNum = exNum & "." & checkNum
    '            End If
    '        End If
    '        Return decNum
    '    End If
    'End Function

    Function RoundOf(ByVal x) As Double
        RoundOf = Int(x * 100 + 0.5) / 100
    End Function

    Function toDecimal(ByVal item As Double) As String
        toDecimal = String.Format("{0:#,0.00}", item)       'String.Format("{0:0,0.00}", item)
    End Function

    Function toDbl(ByVal item As String) As Double
        If item = "" Then
            toDbl = CDbl(0)
        Else
            toDbl = CDbl(item)
        End If
    End Function

    Function emailValidator(ByVal txtEmail As TextBox) As String
        emailValidator = ""
        'If Trim(txtEmail.Text) = "" Then
        '    txtEmail.CssClass = "txtError"
        '    emailValidator = "Email Address is a required field."
        '    Exit Function

        'Else
        '    txtEmail.CssClass = ""
        'End If

        If InStr(Trim(txtEmail.Text), "@", CompareMethod.Text) = 0 Then
            'txtEmail.CssClass = "txtError"
            emailValidator = "Invalid Email Address. Kindly double check." _
                                & nLine & "[username@host.com / username@host.org.ph]"
            Exit Function

            'ElseIf InStr(Trim(txtEmail.Text), "@", CompareMethod.Text) >= 2 Then
            '    txtEmail.CssClass = "txtError"
            '    emailValidator = "Invalid Email Address." _
            '                        & nLine & "Kindly double check." _
            '                        & nLine & "[username@host.com]"
            '    Exit Function

        Else        'If InStr(Trim(txtEmail.Text), "@", CompareMethod.Text) = 1 Then
            txtEmail.CssClass = ""
        End If

        Dim afterAt() As String = Split(Trim(txtEmail.Text), "@")
        Dim hostWord() As String = Split(afterAt(1), ".")

        If hostWord(0) = "" Then
            txtEmail.CssClass = "txtError"
            emailValidator = "Invalid Email Address. Kindly double check." _
                               & nLine & "[username@host.com / username@host.org.ph]"
            Exit Function
        End If
        'com|org|net|edu|gov|mil|biz

        Dim extCheck As String = Right(Trim(txtEmail.Text), 4)
        Dim arrExt(6) As String
        Dim extStat As Boolean = False

        arrExt(0) = ".com"
        arrExt(1) = ".net"
        arrExt(2) = ".org"
        arrExt(3) = ".edu"
        arrExt(4) = ".gov"
        arrExt(5) = ".mil"
        arrExt(6) = ".biz"

        cnt = 1
        counter = 0
        Do While cnt <= UBound(arrExt) + 1
            If extCheck = arrExt(counter) Then
                extStat = True
                txtEmail.CssClass = ""
                Exit Do
            End If
            cnt += 1
            counter += 1
        Loop

        If extStat = False Then
            extCheck = Right(Trim(txtEmail.Text), 3)
            If extCheck = ".ph" Then
                extCheck = Right(Left(Trim(txtEmail.Text), Len(Trim(txtEmail.Text)) - 3), 4)
                extStat = False

                cnt = 1
                counter = 0
                Do While cnt <= UBound(arrExt) + 1
                    If extCheck = arrExt(counter) Then
                        extStat = True
                        txtEmail.CssClass = ""
                        Exit Do
                    End If
                    cnt += 1
                    counter += 1
                Loop
            End If
        End If

        If extStat = False Then
            emailValidator = "Invalid Email Address. Kindly double check." _
                               & nLine & "[username@host.com / username@host.org.ph]"

        Else
            emailValidator = ""
        End If
    End Function
End Class
