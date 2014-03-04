Imports Microsoft.VisualBasic
Imports System.Text

Public Class clsED

    Public Function EncryptData(ByVal strPwd As String) As String
        Dim strMsg As String = ""
        Dim encode As Byte() = New Byte(strPwd.Length - 1) {}

        encode = Encoding.UTF8.GetBytes(strPwd)
        strMsg = Convert.ToBase64String(encode)

        Return strMsg
    End Function

    Public Function DecryptData(ByVal encryptPwd As String) As String
        On Error GoTo errHandler
        Dim decryptPwd As String = ""
        Dim encodePwd As New UTF8Encoding
        Dim decode As Decoder = encodePwd.GetDecoder

        'Dim c1 As String = Replace(encryptPwd, "-", "+")
        'Dim c2 As String = Replace(c1, "_", "/")
        'Dim toDecode_Byte As Byte() = Convert.FromBase64String(c2)

        Dim toDecode_Byte As Byte() = Convert.FromBase64String(encryptPwd)
        Dim charCount As Integer = decode.GetCharCount(toDecode_Byte, 0, toDecode_Byte.Length)
        Dim decoded_Char As Char() = New Char(charCount - 1) {}

        decode.GetChars(toDecode_Byte, 0, toDecode_Byte.Length, decoded_Char, 0)
        decryptPwd = New String(decoded_Char)
        Return decryptPwd

errHandler:
        Return "error!!!" & Err.Description
    End Function

    Public Function GeneratePassword(ByVal len As Integer) As String
        Dim str As String =
        "23456789qwertyuiopasdfghjkzxcvbnmQWERTYUOPASDFGHJKLZXCVBNM"
        Dim N As Integer = str.Length
        Dim rnd As New Random((Now.Hour * 3600 + Now.Minute * 60 +
        Now.Second) * 1000 + Now.Millisecond)
        Dim sb As New StringBuilder

        For l As Integer = 1 To len
            sb.Append(str.Substring(rnd.Next(0, N), 1))
        Next
        Return sb.ToString
    End Function
End Class
