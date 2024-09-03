Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports SISSADE.BE
Imports SISSADE.BL
Imports System.IO

Partial Class RecibeUploapPersonal
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Dim uploadFiles As HttpFileCollection = Request.Files

        ' Build HTML listing the files received.
        Dim summary As String = "<p>Files Uploaded:</p><ol>"

        ' Loop over the uploaded files and save to disk.
        Dim i As Integer
        For i = 0 To uploadFiles.Count - 1
            Dim postedFile As HttpPostedFile = uploadFiles(i)

            ' Access the uploaded file's content in-memory:
            Dim inStream As System.IO.Stream = postedFile.InputStream
            Dim fileData As Byte() = New Byte(postedFile.ContentLength - 1) {}
            inStream.Read(fileData, 0, postedFile.ContentLength)

            'Save the posted file in our "data" virtual directory.

            Dim extension As String = Path.GetExtension(postedFile.FileName)
            postedFile.SaveAs(System.Configuration.ConfigurationManager.AppSettings("RUTA_IMAGEN") & Request.Form("codigo").Trim & extension)

            'postedFile.SaveAs(Server.MapPath("~/fotos/") & Request.Form("codigo").Trim & extension)

            ' Also, get the file size and filename (as specified in
            ' the HTML form) for each file:
            summary += "<li>" & postedFile.FileName & ": " & postedFile.ContentLength.ToString() & " bytes</li>"

            summary += "</ol>"

            ' If there are any form variables, get them here:
            summary += "<p>Form Variables:</p><ol>"

            'Load Form variables into NameValueCollection variable.
            Dim coll As NameValueCollection = Request.Form

            ' Get names of all forms into a string array.
            Dim arr1 As [String]() = coll.AllKeys
            For j = 0 To arr1.Length - 1
                summary += "<li>" & arr1(j) & "</li>"
            Next
            summary += "</ol>"
        Next
        divContent.InnerHtml = summary
    End Sub


End Class

