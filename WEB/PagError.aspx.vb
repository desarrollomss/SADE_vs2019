Imports SISSADE.BL
Partial Class PagError
    Inherits System.Web.UI.Page

    Protected Sub btnCargar_Click(sender As Object, e As System.EventArgs) Handles btnCargar.Click
        If Not Session("USUARIO") Is Nothing Then
            Dim oSYSBL As SYSESTACION_BL = New SYSESTACION_BL
            oSYSBL.LiberarAlerta(0, Session("USUARIO").ToString)
            oSYSBL.ActivaSesion(Session("USUARIO").ToString, 0)
        End If
        FormsAuthentication.SignOut()
        Request.Cookies.Clear()
        Dim usucookie As HttpCookie = New HttpCookie(".pol", String.Empty)
        Response.Cookies.Add(usucookie)
        Session.Clear()
        Session.RemoveAll()
        Session.Abandon()
        Response.Redirect(Request.ApplicationPath & "/frmlogin.aspx")
    End Sub
End Class
