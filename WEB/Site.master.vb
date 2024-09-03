Imports System.Web.UI.WebControls
Imports System.Data
Imports System.Collections.Generic
Imports SISSADE.BL
Imports Entidades.SISCAS
Imports Datos.SISCAS

Partial Class Site
    Inherits System.Web.UI.MasterPage
    
    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If Session("DatosUsuarioActivo") Is Nothing Then
            Session.Clear()
            Session.Abandon()
            Response.Redirect(Request.ApplicationPath & "/frmLogin.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargarMenu()
            lblUsuario.Text = Session("USUARIO").ToString + " " + Session("ROLSADE").ToString
            lblAnexo.Text = Session("ANEXO").ToString
            lblAnexo.Text = Session("CARGO").ToString
            ' ---- Acciones de la pagina
            Dim objcod As String = ""
            Dim objcodigo As Integer = 0
            Dim id As String = ""

            If Request.QueryString("rqobjcodigo") IsNot Nothing Then
                objcod = Request.QueryString("rqobjcodigo")
                objcodigo = Integer.Parse(objcod)
            End If

            'Dim objS As ws_seguridad.SEGUSUARIOEntidad = CType(Session("datosusuario"), ws_seguridad.SEGUSUARIOEntidad)
            'Dim objP As ws_seguridad.SEGPERFILEntidad = objS.Perfilesxusuario(0)

            Dim objS As SEGUSUARIOEntidad = CType(Session("datosusuario"), SEGUSUARIOEntidad)
            Dim objP As SEGPERFILEntidad = objS.Perfilesxusuario(0)

            Session("PERCODIGO") = objP.Percodigo
            Dim cpage As Web.UI.Page = Me.Controls(0).Page

            For Each objO As SEGOBJETOEntidad In objP.ListadoObjetos
                If (objO.Objcodigo = objcodigo) Then
                    For Each objAcc As SEGACCIONEntidad In objO.ListadoAciones
                        Dim Acccodigo As String = objAcc.Acccodigo.ToString()
                        Dim Accnombrectrol As String = objAcc.Accnombrectrol
                        id = "ctl00$MainContent$" & Accnombrectrol.Trim
                        If Accnombrectrol <> "" And Not Accnombrectrol Is Nothing Then
                            If cpage.HasControls = True Then
                                Dim dbt As New Button
                                Dim ctrHtml As New HtmlImage
                                Dim ctrChk As New CheckBox
                                Dim vtipo As Integer = 0

                                Dim tipo As System.Type
                                tipo = ctrChk.GetType()

                                If Accnombrectrol.Trim.Substring(Accnombrectrol.Trim.Length - 1) = "H" Then
                                    vtipo = 1
                                    ctrHtml = cpage.FindControl(id)
                                Else
                                    If Accnombrectrol = "chkProcesado" Then
                                        ctrChk = cpage.FindControl(id)
                                    Else
                                        dbt = cpage.FindControl(id)
                                    End If
                                End If
                                If vtipo = 0 Then
                                    If Accnombrectrol = "chkProcesado" Then
                                        ctrChk.Visible = True
                                    Else
                                        If Not dbt Is Nothing Then
                                            dbt.Visible = True
                                        End If
                                    End If
                                Else
                                    If Not ctrHtml Is Nothing Then
                                        ctrHtml.Visible = True
                                    End If
                                End If
                            End If
                        End If
                    Next
                End If
            Next


            ' ----



        End If
        Dim sb As New StringBuilder
        sb.AppendLine("$(""#accordion"").accordion({ collapsible: false });")
        'sb.AppendLine("$(""#accordion"").accordion({ active: " & Session("activo") & " });")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub
    Public Sub CargarMenu()
        Dim sb As New StringBuilder
        If Session("datosusuario") IsNot Nothing Then
            Dim objS As SEGUSUARIOEntidad = CType(Session("datosusuario"), SEGUSUARIOEntidad)
            Dim objP As SEGPERFILEntidad = objS.Perfilesxusuario(0)

            Dim oItem01 As New MenuItem
            Dim sKey As String = ""
            Dim lNuevo As Boolean = True
            Dim nnodo As New MenuItem
            nnodo.Text = "|"
            Dim flag As Int16 = 0
            For Each objO As SEGOBJETOEntidad In objP.ListadoObjetos
                If (objO.Objpadrecodigo = 0) Then
                    If flag = 1 Then
                        sb.AppendLine("         </ul>		")
                        sb.AppendLine("		</p>")
                        sb.AppendLine("	</div>")
                    End If
                    sb.AppendLine("<h3>" & objO.Objdescripcion & "</h3>")
                    sb.AppendLine("	<div>")
                    sb.AppendLine("		<p>")
                    sb.AppendLine("         <ul class =""ul"">  ")
                Else
                    Dim Opcion1 As String = objO.Objcodigo
                    Dim NombreOpcion1 As String = objO.Objdescripcion
                    Dim RutaOpcion1 As String = objO.Objurl
                    sb.AppendLine("             <li><a href='" & RutaOpcion1 & "&rqobjcodigo=" & objO.Objcodigo.ToString & "' onClick='cambiarvalor()'>" & NombreOpcion1 & "</a></li>")
                    flag = 1
                End If
            Next
            sb.AppendLine("         </ul>		")
            sb.AppendLine("		</p>")
            sb.AppendLine("	</div>")
        End If
        ltrMenu.Text = sb.ToString
    End Sub
    Private Sub CerrarSesion()
        Dim oSYSBL As SYSESTACION_BL = New SYSESTACION_BL
        oSYSBL.LiberarAlerta(0, Session("USUARIO").ToString)
        oSYSBL.ActivaSesion(Session("USUARIO").ToString, 0)
        FormsAuthentication.SignOut()
        Request.Cookies.Clear()
        Dim usucookie As HttpCookie = New HttpCookie(".pol", String.Empty)
        Response.Cookies.Add(usucookie)
        Session.Clear()
        Session.RemoveAll()
        Session.Abandon()
        Response.Redirect(Request.ApplicationPath & "/frmlogin.aspx")
    End Sub

    'Protected Sub lnkCerrarSesion_Click(sender As Object, e As System.EventArgs) Handles lnkCerrarSesion.Click
    '    CerrarSesion()
    'End Sub

    Protected Sub lnkCerrarSesion_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles lnkCerrarSesion.Click
        CerrarSesion()
    End Sub
End Class

