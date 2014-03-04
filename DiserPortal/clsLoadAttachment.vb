Imports Microsoft.VisualBasic

Public Class clsLoadAttachment
    Inherits System.Web.UI.Page

    Public Function GetContentType(ByVal ext As String) As String
        Select Case UCase(ext)
            Case "TXT", "TEXT", "JS", "VBS", "ASP", "CGI", "PL", "NFO", "ME", "DTD"
                GetContentType = "text/plain"
            Case "HTM", "HTML", "HTA", "HTX", "MHT"
                GetContentType = "text/html"
            Case "CSV"
                GetContentType = "text/comma-separated-values"
            Case "JS"
                GetContentType = "text/javascript"
            Case "CSS"
                GetContentType = "text/css"
            Case "PDF"
                GetContentType = "application/pdf"
            Case "RTF"
                GetContentType = "application/rtf"
            Case "XML", "XSL", "XSLT"
                GetContentType = "text/xml"
            Case "WPD"
                GetContentType = "application/wordperfect"
                'Case "XLSX"
                '    GetContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"""
            Case "WRI"
                GetContentType = "application/mswrite"
            Case "XLS", "XLS3", "XLS4", "XLS5", "XLW", "XLSM", "XLSX"
                GetContentType = "application/vnd.ms-excel"
            Case "DOC"
                GetContentType = "application/msword"
            Case "PPT", "PPS"
                GetContentType = "application/mspowerpoint"

                'WAP/WML files  
            Case "WML"
                GetContentType = "text/vnd.wap.wml"
            Case "WMLS"
                GetContentType = "text/vnd.wap.wmlscript"
            Case "WBMP"
                GetContentType = "image/vnd.wap.wbmp"
            Case "WMLC"
                GetContentType = "application/vnd.wap.wmlc"
            Case "WMLSC"
                GetContentType = "application/vnd.wap.wmlscriptc"

                'Images
            Case "GIF"
                GetContentType = "image/gif"
            Case "JPG", "JPE", "JPEG"
                GetContentType = "image/jpeg"
            Case "PNG"
                GetContentType = "image/png"
            Case "BMP"
                GetContentType = "image/bmp"
            Case "TIF", "TIFF"
                GetContentType = "image/tiff"
            Case "AI", "EPS", "PS"
                GetContentType = "application/postscript"

                'Sound files
            Case "AU", "SND"
                GetContentType = "audio/basic"
            Case "WAV"
                GetContentType = "audio/wav"
            Case "RA", "RM", "RAM"
                GetContentType = "audio/x-pn-realaudio"
            Case "MID", "MIDI"
                GetContentType = "audio/x-midi"
            Case "MP3"
                GetContentType = "audio/mp3"
            Case "M3U"
                GetContentType = "audio/m3u"

                'Video/Multimedia files
            Case "ASF"
                GetContentType = "video/x-ms-asf"
            Case "AVI"
                GetContentType = "video/avi"
            Case "MPG", "MPEG"
                GetContentType = "video/mpeg"
            Case "QT", "MOV", "QTVR"
                GetContentType = "video/quicktime"
            Case "SWA"
                GetContentType = "application/x-director"
            Case "SWF"
                GetContentType = "application/x-shockwave-flash"
                'Compressed/archives
            Case "ZIP"
                GetContentType = "application/x-zip-compressed"
            Case "GZ"
                GetContentType = "application/x-gzip"
            Case "RAR"
                GetContentType = "application/x-rar-compressed"

                'Miscellaneous
            Case "COM", "EXE", "DLL", "OCX"
                GetContentType = "application/octet-stream"

                'Unknown (send as binary stream)
            Case Else
                GetContentType = "application/octet-stream"
        End Select
    End Function
End Class
