
Partial Class geolocalRegistro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If (Request.QueryString.Count > 0) Then
                hdfLat.Value = Request.QueryString("pLat")
                hdfLon.Value = Request.QueryString("pLon")
            Else
                hdfLat.Value = "-12.138206845042884"
                hdfLon.Value = "-76.98716361667175"

            End If
        End If
    End Sub
End Class
