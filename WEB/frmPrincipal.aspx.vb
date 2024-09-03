Imports System.Data
Imports SISSADE.BE
Partial Class frmPrincipal
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If Session("DatosUsuarioActivo") Is Nothing Then
            Session.Clear()
            Session.Abandon()
            Response.Redirect(Request.ApplicationPath & "/frmLogin.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not IsPostBack() Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: SISTEMA DE ATENCION DE DENUNCIAS Y EMERGENCIAS"

            '-- obtiene el codigo de mensaje de error a mostrar
            Dim strERROR As String = Request.QueryString("pERROR")

            Select Case strERROR
                Case "1000"
                    lblMensaje.Text = "Verifique con Supervisor : Usuario no esta HABILITADO para atención de incidencias!!!"
                    lblMensaje.Visible = True
                    imgAcceso.Visible = True
                Case "2000"
                    lblMensaje.Text = "Verifique con Supervisor : Usuario no tiene asignado ROL para atención de incidencias!!!"
                    lblMensaje.Visible = True
                    imgAcceso.Visible = True
                Case "9999"
                    lblMensaje.Text = "Verifique con Supervisor : Usuario no esta registrado como OPERADOR para atención de incidencias!!!"
                    lblMensaje.Visible = True
                    imgAcceso.Visible = True
                Case Else
                    lblMensaje.Text = ""
                    lblMensaje.Visible = False

            End Select



        End If



    End Sub
End Class
