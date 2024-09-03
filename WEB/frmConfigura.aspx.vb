Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Class frmConfigura
    Inherits System.Web.UI.Page




    Private Sub fm()
        lblBrowserAgente.Text = Request.ServerVariables("http_user_agent")  ' //AUTH_USER LOGON_USER


        Dim ClientIP, Forwaded, RealIP As String

        RealIP = ""


        ClientIP = Request.ServerVariables("HTTP_CLIENT-IP")
        If ClientIP <> "" Then
            RealIP = ClientIP
        Else
            Forwaded = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
            If Forwaded <> "" Then RealIP = Forwaded
        End If


        lblDireccionIPx.Text = RealIP
        lblDireccionIP.Text = Request.ServerVariables("remote_addr")
        lblDireccionIPDNS.Text = Request.ServerVariables("remote_host")
        'lblMetodoPagina.Text = Request.ServerVariables("request_method")
        lblServidorDominio.Text = Request.ServerVariables("server_name")
        lblPuertoServidor.Text = Request.ServerVariables("server_port")
        lblSoftwareServidor.Text = Request.ServerVariables("server_software")

        Dim objCurrentBrowser As HttpBrowserCapabilities = Request.Browser

        lblBrowser.Text = objCurrentBrowser.Browser + " " + objCurrentBrowser.Version
        lblPlataforma.Text = objCurrentBrowser.Platform
        lblSoportaTablas.Text = objCurrentBrowser.Cookies.ToString()
        lblSoportaVisualBasicScript.Text = objCurrentBrowser.VBScript.ToString()
        lblSoportaJavaScript.Text = objCurrentBrowser.EcmaScriptVersion.ToString()  ' objCurrentBrowser.JavaScript.ToString() '
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        fm()
    End Sub
End Class
