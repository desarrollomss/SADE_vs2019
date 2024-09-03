Imports System.Data.SqlClient
Imports System.Data
Imports SISSADE.BE
Imports SISSADE.BL

Partial Class frmRecursosGPS
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack() Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = "Monitoreo de Recursos GPS"
            Session("activo") = "1"
            Session("opcion") = "1.2"

            Dim txtIP As String = Session("EQUIPO")
            Dim pHOST As String = "PRI"

            'If (txtIP.Substring(0, 3).Equals("192") Or txtIP.Substring(0, 3).Equals("194") Or txtIP.Substring(0, 6).Equals("172.16") Or _
            '    txtIP.Substring(0, 4).Equals("10.1") Or txtIP.Substring(0, 9).Equals("127.0.0.1")) Then
            '    pHOST = "PRI"
            '    'NatMapa = "http://192.0.0.130:70"
            '    'NatFoto = "http://192.0.0.102"
            '    'NatCode = "http://192.0.0.7/cartografia/cgi-bin/mgaxctrl.cab"
            'Else
            '    pHOST = "PUB"
            '    'NatMapa = "http://190.116.44.5:70"
            '    'NatFoto = "http://190.116.44.5"
            '    'NatCode = "http://200.48.28.204/cartografia/cgi-bin/mgaxctrl.cab"
            'End If
            Dim pURL As String = "MapaTematico/MapaMonitoreo.htm?pHOST=" + pHOST
            Dim sb As New StringBuilder
            sb.AppendLine("javascript:popupMostrarGPS('" + pURL + "');")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)


        End If

    End Sub
End Class
