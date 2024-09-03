Imports System
Imports SISSADE.BL
Imports SISSADE.BE

Partial Class confirmaRegistro
    Inherits System.Web.UI.Page
    Dim oGPSPOSITION_BL As New GPSPOSITION_BL
    Dim oGPSREGISTRO_BL As New GPSREGISTRO_BL

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        lblResultado.Text = ""
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
        Dim oCadena As String
        If Not Page.IsPostBack Then
            If (Request.QueryString.Count > 0) Then
                oCadena = Request.QueryString("pId")
                lblResultado.Text = oGPSREGISTRO_BL.Validar(oCadena)
                Bitacora.Escribir("Registro Exitoso", LogMsg.INFO)
            Else
                lblResultado.Text = "No hay datos para activar!!!!"
                Bitacora.Escribir("No hay datos para activar", LogMsg.INFO)
            End If

        End If

    End Sub
End Class
