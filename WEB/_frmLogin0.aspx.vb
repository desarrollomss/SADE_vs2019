Imports System.ServiceModel
Imports System.Net
Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data
Imports Entidades.SISCAS
Imports Datos.SISCAS
Imports Recurso.Encriptador



Partial Class _frmLogin0
    Inherits System.Web.UI.Page

    'Private oUsuario_BL As New Usuario_BL
    'Private oUsuario As New Usuario
    'Private oUsuarioLIST As UsuarioLIST
    Dim oSYSESTACION_BL As New SYSESTACION_BL
    Dim oSCUESTACION_BE As New SCUESTACION_BE
    Dim oSCUESTACION_BL As New SCUESTACION_BL

    Private dtUsuario As SYSUSUARIOACTIVO = New SYSUSUARIOACTIVO

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Label6.Text = Request.UserHostAddress
        'Label7.Text = Request.ServerVariables("REMOTE_ADDR")
        'Label8.Text = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        'MensajeModal(HttpContext.Current.Request.UserHostName.ToString().Trim(), Me)
        'System.Net.Dns.BeginGetHostEntry(Request.UserHostAddress, AddressOf GetHostNameCallBack, Request.UserHostAddress)

        If Not Page.IsPostBack Then
            Session.Clear()
            Session.RemoveAll()
            Session.Abandon()
        End If
        txtUser.Focus()
    End Sub

    'Public Sub GetHostNameCallBack(ByVal asyncResult As IAsyncResult)
    '    Try
    '        ' Label6.Text = "Entro"
    '        Dim userHostAddress As String = asyncResult.AsyncState.ToString
    '        Dim hostEntry As System.Net.IPHostEntry = System.Net.Dns.EndGetHostByName(asyncResult)
    '        Label9.Text = hostEntry.HostName

    '        ViewState("nombre_equipo") = hostEntry.HostName.ToString

    '        MensajeModal(hostEntry.HostName.ToString, Me)
    '    Catch ex As Exception
    '        Label9.Text = ex.Message
    '    End Try
    'End Sub


    Protected Sub btnIngresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        Try
            'Dim oSEGUSUARIO As New ws_seguridad.SEGUSUARIOEntidad
            Dim oSEGUSUARIO As New Entidades.SISCAS.SEGUSUARIOEntidad
            Dim objLog As New SEGUSUARIODAO


            Dim msg = ""
            Dim msg1 = ""
            Dim exito As Boolean = False
            Dim activo As Boolean = False


            exito = objLog.LogeoUsuario(11, txtUser.Text.Trim.ToUpper, txtPassword.Text.Trim, oSEGUSUARIO, msg)





            If exito Then
                'If Seguridad.LogeoUsuario(1, "WMAMANI", "456", oSEGUSUARIO, msg) Then
                dtUsuario.p_intusuidentificador = oSEGUSUARIO.Usuidentificador
                dtUsuario.p_vchusucodigo = oSEGUSUARIO.Usucodigo
                Session("USUARIO") = oSEGUSUARIO.Usucodigo
                Session("NOMBREUSUARIO") = oSEGUSUARIO.Usunombre
                Session("FIRMA") = ViewState("FIRMA")
                Session("APP") = "SADE"
                dtUsuario.p_programaauditoria = "SADE"
                Session("PROGRAMA") = "SADE"
                dtUsuario.p_equipoauditoria = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
                Session("EQUIPO") = HttpContext.Current.Request.UserHostAddress.ToString().Trim()

                '-- Para validar ingreso al SADE por USUARIO o IP
                oSCUESTACION_BE.PropESTCNUMIP = txtUser.Text.Trim.ToUpper
                oSCUESTACION_BE.PropAUDEQPCREACION = HttpContext.Current.Request.UserHostAddress.ToString().Trim()

                oSCUESTACION_BE = oSCUESTACION_BL.ValidarLogon(oSCUESTACION_BE)

                If oSCUESTACION_BE.PropESTCNUMIP Is Nothing Then
                    Throw New Exception(HttpContext.Current.Request.UserHostAddress.ToString().Trim() + "Usuario o Estacion NO HABILITADO!!!")
                Else
                    Session("ROL") = 0
                    Session("ROLSADE") = ""
                    Session("UESTADO") = 0
                    Dim dtROL As New DataTable
                    dtROL = oSYSESTACION_BL.ListarUsuario(dtUsuario.p_vchusucodigo)
                    If dtROL.Rows.Count > 0 Then
                        Session("ROL") = dtROL.Rows(0)("INTROLCODIGO")
                        Session("ROLSADE") = dtROL.Rows(0)("VCHROLDESCRIP")
                        Session("UESTADO") = dtROL.Rows(0)("SMLESTADOSESION")
                    Else
                        lblMensaje.Text = "Verifique, Usuario no tiene Perfil o Rol asignado!!!"

                    End If
                    ''Dim oSEGPERFIL As New ws_seguridad.SEGPERFILEntidad
                    exito = True
                    Dim local As String = Server.MapPath("")
                    Dim inicio As Integer
                    inicio = local.LastIndexOf("\"c)
                    Session("SITOWEB") = local.Substring(inicio, local.Length - inicio)
                    Session("DatosUsuarioActivo") = dtUsuario
                    Session("datosusuario") = oSEGUSUARIO

                    Dim oSYSBL As SYSESTACION_BL = New SYSESTACION_BL
                    oSYSBL.ActivaSesion(Session("USUARIO").ToString, 1)
                    'MensajeModal(ViewState("nombre_equipo").ToString, Me)
                    Bitacora.Escribir("Logeo Exitoso", LogMsg.INFO)

                    Response.Redirect("frmPrincipal.aspx", False)
                    'MensajeModal(Session("EQUIPO"), Me)

                End If

            Else
                lblMensaje.Text = "Usuario o Constraseña incorrecta!!!"
                'Response.Redirect("frmLogin.aspx", False)
            End If
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        Finally
        End Try
    End Sub

    Protected Sub likCambiarPwd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles likCambiarPwd.Click
        txtUser2.Text = txtUser.Text
        txtPass2.Text = String.Empty
        txtNPass2.Text = String.Empty
        txtCNPass2.Text = String.Empty
        MostrarPopup("cambioclave")
    End Sub
    Private Sub MostrarPopup(ByVal pdiv As String)
        Dim sb As New StringBuilder
        sb.AppendLine("javascript:void(0);")
        sb.AppendLine("document.getElementById('" & pdiv & "').style.display='block';document.getElementById('fade').style.display='block';")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub
    Private Sub CerrarPopup(ByVal pdiv As String)
        Dim sb As New StringBuilder
        sb.AppendLine("javascript:void(0);")
        sb.AppendLine("document.getElementById('" & pdiv & "').style.display='none';document.getElementById('fade').style.display='none';")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub

    Protected Sub btnCambiarContraseña_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCambiarContraseña.Click
        Try
            Dim oSEGUSUARIO As New SEGUSUARIOEntidad
            Dim objLog As New SEGUSUARIODAO
            Dim msg1 = ""
            Dim exito As Boolean = False

            Dim nombreDeUsuario As String = Me.txtUser2.Text.Trim()
            Dim passAnterior As String = Me.txtPass2.Text
            Dim passNuevo As String = Me.txtNPass2.Text.Trim
            Dim opcion As Integer = 0
            Dim msg As String = ""
            If nombreDeUsuario.Trim().Length > 50 Then
                nombreDeUsuario = nombreDeUsuario.Trim().Substring(0, 50)
            End If
            If passAnterior.Trim().Length > 20 Then
                passAnterior = passAnterior.Trim().Substring(0, 20)
            End If
            '-----

            Dim pcodusuario As Integer = 0, passbd As String = ""
            If (objLog.VerificarUsuario(nombreDeUsuario, pcodusuario, passbd) = True AndAlso pcodusuario > 0) Then
                Dim passbddesc As String = SecurityEncryptor.Desencriptar(passbd, "")
                If passbddesc = "" OrElse passAnterior <> passbddesc Then
                    msg = "Al parecer su usuario no existe en el sistema. Ingrese los datos de forma correcta"
                    exito = False
                Else

                    If (objLog.CambiarPassword(pcodusuario, passNuevo, msg1) = True) Then
                        msg = "Su nuevo password ha sido registrado satisfactoriamente"
                        exito = True
                    Else
                        msg = "Se ha producido problemas en el sistema al momento de actualizar la información de su password"
                        exito = False
                    End If
                End If
            Else
                msg = "Al parecer su usuario no existe en el sistema. Ingrese los datos de forma correcta"
                exito = False
            End If


            If (exito = False) Then
                If msg = "" Then
                    lblMensaje.Text = "Se ha producido un error al momento de cambiar su contraseña inténtelo de nuevo"
                    MensajeModal("Se ha producido un error al momento de cambiar su contraseña inténtelo de nuevo", Me)

                Else
                    lblMensaje.Text = msg
                    MensajeModal(msg, Me)

                End If
                Me.lblMensaje.ForeColor = Drawing.Color.Red
            Else
                lblMensaje.Text = "Se ha cambiado satisfactoriamente su contraseña"
                MensajeModal("Se ha cambiado satisfactoriamente su contraseña", Me)

                Me.lblMensaje.ForeColor = Drawing.Color.Blue
                txtUser.Text = txtUser2.Text
                txtPassword.Text = txtNPass2.Text
                CerrarPopup("cambioclave")
                'Me.LOGEOUSUARIO(usu, pass)
            End If
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub MensajeModal(ByVal pstMensaje As String, ByVal ppgPagina As System.Web.UI.Page)
        pstMensaje = pstMensaje.Replace("" & Chr(10) & "", "\n")
        pstMensaje = pstMensaje.Replace("" & Chr(13) & "" & Chr(10) & "", "\n")
        pstMensaje = pstMensaje.Replace("'", "'")

        If (pstMensaje <> [String].Empty) Then
            Dim scriptString As String = "<script type='text/javascript'>"
            scriptString = (scriptString + ("alert('" + (pstMensaje + "');<")))
            scriptString += "/"
            scriptString += "script>"

            ScriptManager.RegisterStartupScript(ppgPagina, GetType(Page), "MensajeExcepcion", scriptString, False)

            'If Not ppgPagina.IsStartupScriptRegistered("alert") Then
            'ppgPagina.RegisterStartupScript("alert", scriptString)
            'End If
        End If
    End Sub


End Class
