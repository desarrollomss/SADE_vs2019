Imports System.Data.SqlClient
Imports System.Data
Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Configuration

Public Enum VerRecursos
    TODOS = -1
    NOTIENE = 0
    SITIENE = 1
End Enum

Enum RolSADE
    SUPERVISOR_CCO = 1
    TELEFONISTA = 2
    DESPACHADOR_SERENAZGO = 3
    OPERADOR_CAMARAS = 4
    OPERADOR_BOTON_ALERTA = 5
    DESPACHADOR_TRANSITO = 6
    DESPACHADOR_FISCALIZACION = 7
    DESPACHADOR_DEFENSA_CIVIL = 8
End Enum

'--  7	A	NUEVO
'--  8	P	PARA DESPACHO
'--  9	D	DESPACHADO (CON RECURSO ASIGNADO)
'--  10	X	DESCARTADO
'--  11	F	ATENDIDO
'--  12	C	CERRADO

Enum Estado
    Abierto = 7
    ParaDespacho = 8
    Despachado = 9
    Descartado = 10
    Atendido = 11
    Cerrado = 12
End Enum

Partial Class frmGestionaIncidencia
    Inherits System.Web.UI.Page
    Dim oINC As New CCOINCIDENCIA_BE
    Dim oINC_BL As New CCOINCIDENCIA_BL
    Dim oPAR As New CCOPARAMETRO_BE
    Dim oPAR_BL As New CCOPARAMETRO_BL
    Dim servidor As String = ConfigurationManager.AppSettings("SERVIDOR")
    Dim oSYSESTACION_BL As New SYSESTACION_BL
    Dim oCCORECURSO_BL As New CCORECURSO_BL


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Me.btnAtender.Attributes.Add("onclick", "javascript:return ValidarAtencion();")
        Me.btnDespacho.Attributes.Add("onclick", "javascript:return ValidarDespacho();")
        Me.btnCerrar.Attributes.Add("onclick", "javascript:return ValidarCierre();")


        Me.txtNumeroInc.Attributes.Add("onkeypress", "javascript:return solonumeros(event);")
        Me.txtNumeroInc.MaxLength = 10
        Me.txtTelefonoInc.MaxLength = 15
        ViewState("dkincidencia") = 0
        ViewState("oRowIndex") = -1
        ViewState("flag") = 0
        ViewState("cant") = 0
        ViewState("flag1") = 0
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '-- solo mientras se termina CONTROL DE ACCESOS
        'Session("Usuario") = "Testing"
        'Session("Rol") = 1 '1-Operador Telefonico / 2-Operador Despachador / 3-Operador de Reporte / 4-Supervisor

        '--txtHoraInicio.Text = "00:00"
        '--txtHoraFinal.Text = "23:59"

        If Not IsPostBack() Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: GESTION DE LA INCIDENCIA"
            Session("activo") = "1"
            Session("opcion") = "1.2"

            Dim oCCOUS_BE As New CCOUSUARIOSESION_BE
            Dim oCCOUSUARIOSESION_BL As New CCOUSUARIOSESION_BL

            oCCOUS_BE.PropUSUARIO = CType(Session("Usuario"), String)

            oCCOUS_BE = oCCOUSUARIOSESION_BL.ListarKey(oCCOUS_BE)

            If oCCOUS_BE.PropESTADOSESION Is Nothing Then
                '-- redirecciona y muestra error 
                Response.Redirect("frmPrincipal.aspx?pERROR=9999", False)
            ElseIf oCCOUS_BE.PropESTADOSESION = 0 Then
                '-- redirecciona y muestra error 
                Response.Redirect("frmPrincipal.aspx?pERROR=1000", False)
            ElseIf oCCOUS_BE.PropROLCODIGO = 0 Then
                Response.Redirect("frmPrincipal.aspx?pERROR=2000", False)
            Else
                Dim dtROL As New DataTable
                dtROL = oSYSESTACION_BL.ListarUsuario(CType(Session("Usuario"), String))
                If dtROL.Rows.Count > 0 Then
                    Session("ROL") = dtROL.Rows(0)("INTROLCODIGO")
                    Session("ROLSADE") = dtROL.Rows(0)("VCHROLDESCRIP")
                    Session("UESTADO") = dtROL.Rows(0)("SMLESTADOSESION")
                End If

            End If


            LlenarCombos()
            '-- Solo el rol que corresponda
            ddlRol.SelectedValue = CType(Session("ROL"), Integer)
            ddlAnexoInc.SelectedValue = CType(Session("ANEXO"), String)

            '-- ConfiguraBotonera x Rol
            BotoneraXRol()

            '-- Cargar datos Grilla
            CargarBuscarIncidencia()


        End If
        '-- Estado Cerrado
        oPAR.PropPARCODIGO = "INCCERRADO"
        oPAR = oPAR_BL.ListarKey(oPAR)
        ViewState("incEstCerrado") = oPAR.PropPARRELACION
        '-- Estado Abierto
        oPAR.PropPARCODIGO = "INCABIERTO"
        oPAR = oPAR_BL.ListarKey(oPAR)
        ViewState("incEstAbierto") = oPAR.PropPARRELACION

    End Sub
    Public Sub BotoneraXRol()
        Dim intRol As Integer = CType(Session("ROL"), Integer)
        btnNuevo.Visible = False
        btnAtender.Visible = False
        btnDespacho.Visible = False
        btnVisualizar.Visible = False
        btnHistorial.Visible = False
        btnCerrar.Visible = False
        btnRevertir.Visible = False
        btnFormatoSADE.Visible = False
        btnCambiaUbica.Visible = False
        Select Case intRol
            Case 1      '--SUPERVISOR_CCO
                btnNuevo.Visible = True
                btnAtender.Visible = True
                btnDespacho.Visible = True
                btnVisualizar.Visible = True
                btnHistorial.Visible = True
                btnCerrar.Visible = True
                btnRevertir.Visible = True
                btnFormatoSADE.Visible = True
                btnCambiaUbica.Visible = True
            Case 2      '--TELEFONISTA
                btnNuevo.Visible = True
                btnVisualizar.Visible = True
                btnHistorial.Visible = True
                btnAtender.Visible = True
            Case 4      '--OPERADOR_CAMARAS
                btnNuevo.Visible = True
                btnDespacho.Visible = True
                btnVisualizar.Visible = True
                btnHistorial.Visible = True
                btnRevertir.Visible = True
            Case 5      '--OPERADOR_BOTON_ALERTA 
                btnNuevo.Visible = True
                btnAtender.Visible = True
                btnDespacho.Visible = True
                btnVisualizar.Visible = True
                btnHistorial.Visible = True
                btnRevertir.Visible = True
            Case 3, 6, 7, 8  '--DESPACHADOR_SERENAZGO / DESPACHADOR_TRANSITO / DESPACHADOR_FISCALIZACION / DESPACHADOR_DEFENSA_CIVIL
                btnNuevo.Visible = True
                btnDespacho.Visible = True
                btnVisualizar.Visible = True
                btnHistorial.Visible = True
                btnRevertir.Visible = True
                btnCambiaUbica.Visible = True
            Case Else       '--SOLO CONSULTA
                btnVisualizar.Visible = True
                btnHistorial.Visible = True
        End Select


    End Sub

    Public Sub LlenarCombos()
        Dim lstOrigenIncidencia As New List(Of CCOORIGENINCIDENCIA_BE)
        Dim oCCOTABLA_BE As New CCOTABLA_BE
        Dim oCCOSUBTIPOINCIDENCIA_BE As New CCOSUBTIPOINCIDENCIA_BE

        Dim oCCOORIGENINCIDENCIA_BL As New CCOORIGENINCIDENCIA_BL
        Dim oCCOTIPOINCIDENCIA_BL As New CCOTIPOINCIDENCIA_BL
        Dim oCCOSUBTIPOINCIDENCIA_BL As New CCOSUBTIPOINCIDENCIA_BL
        Dim oCCOPRIORIDADINCIDENCIA_BL As New CCOPRIORIDADINCIDENCIA_BL
        Dim oCCOSECTOR_BL As New CCOSECTOR_BL
        Dim oCCOTABLA_BL As New CCOTABLA_BL
        Dim oSYSCATASTRO_BL As New SYSCATASTRO_BL
        Dim oSCUROL_BL As New SCUROL_BL
        Dim oCCORECURSO_BE As New CCORECURSO_BE
        Dim oSYS_BL As SYSESTACION_BL = New SYSESTACION_BL

        txtFechaInicio.Text = Date.Now
        txtFechaFinal.Text = Date.Now

        txtHoraInicio.Text = "00:00"
        txtHoraFinal.Text = "23:59"

        With ddlUsuarioInc
            .DataSource = oSYS_BL.ListarUsuario("")
            .DataTextField = "USUARIO"
            .DataValueField = "USUARIO"
        End With
        ddlUsuarioInc.DataBind()
        ddlUsuarioInc.Items.Insert(0, New ListItem("(Todos)", ""))

        Try
            ddlUsuarioInc.SelectedValue = CType(Session("Usuario"), String).ToUpper
        Catch ex As Exception
            ddlUsuarioInc.SelectedIndex = -1
        End Try


        oCCORECURSO_BE.PropRECCODIGO = 0
        oCCORECURSO_BE.PropTRECODIGO = 0
        oCCORECURSO_BE.PropRECMODELO = ""

        With ddlRecursoInc
            .DataSource = oCCORECURSO_BL.ListarxTipo(oCCORECURSO_BE)
            .DataTextField = "VCHRECCODIGOALTERNO"
            .DataValueField = "INTRECCODIGO"
        End With
        ddlRecursoInc.DataBind()
        ddlRecursoInc.Items.Insert(0, New ListItem("(Todos)", 0))
        ddlRecursoInc.Items.Insert(1, New ListItem("(Sin Recurso)", -1))

        With ddlSectorInc
            .DataSource = oCCOSECTOR_BL.ListarCombo2
            .DataTextField = "PropSECDESCRIPCION"
            .DataValueField = "PropCSECCODIGO"
        End With
        ddlSectorInc.DataBind()
        ddlSectorInc.Items.Insert(0, New ListItem("(Todos)", ""))


        With ddlOrigenInc
            .DataSource = oCCOORIGENINCIDENCIA_BL.ListarCombo
            .DataTextField = "PropORIDESCRIPCION"
            .DataValueField = "PropORICODIGO"
        End With
        ddlOrigenInc.DataBind()
        ddlOrigenInc.Items.Insert(0, New ListItem("(Todos)", "0"))


        With ddlTipoInc
            .DataSource = oCCOTIPOINCIDENCIA_BL.ListarCombo
            .DataTextField = "PropTINDESCRIPCION"
            .DataValueField = "PropTINCODIGO"
        End With
        ddlTipoInc.DataBind()
        ddlTipoInc.Items.Insert(0, New ListItem("(Todos)", "0"))


        oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = -1
        oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = 0
        With ddlSubtipoInc
            .DataSource = oCCOSUBTIPOINCIDENCIA_BL.ListarCombo(oCCOSUBTIPOINCIDENCIA_BE)
            .DataTextField = "PropSTIDESCRIPCION"
            .DataValueField = "PropSTICODIGO"
        End With
        ddlSubtipoInc.DataBind()
        ddlSubtipoInc.Items.Insert(0, New ListItem("(Todos)", "0"))


        With ddlPrioridadInc
            .DataSource = oCCOPRIORIDADINCIDENCIA_BL.ListarCombo()
            .DataTextField = "PropPRIDESCRIPCION"
            .DataValueField = "PropPRICODIGO"
        End With
        ddlPrioridadInc.DataBind()
        ddlPrioridadInc.Items.Insert(0, New ListItem("(Todos)", "0"))

        oCCOTABLA_BE.PropTTACODIGO = "ESTADOINCIDENCIA"

        With ddlEstadoInc
            .DataSource = oCCOTABLA_BL.Listar(oCCOTABLA_BE)
            .DataTextField = "DESCRIPCION2"
            .DataValueField = "ID"
        End With
        ddlEstadoInc.DataBind()
        ddlEstadoInc.Items.Insert(0, New ListItem("(Todos)", "0"))

        With ddlAnexoInc
            .DataSource = oSYSESTACION_BL.Listar()
            .DataTextField = "VCHEXTNOMBRE"
            .DataValueField = "VCHEXTENSION"
        End With
        ddlAnexoInc.DataBind()
        ddlAnexoInc.Items.Insert(0, New ListItem("(Todos)", ""))




        'oCCOTABLA_BE.PropTTACODIGO = "TIPODERIVACION"
        'With ddlTipoDerivacion
        '    .DataSource = oCCOTABLA_BL.Listar(oCCOTABLA_BE)
        '    .DataTextField = "DESCRIPCION"
        '    .DataValueField = "ID"
        'End With
        'ddlTipoDerivacion.DataBind()
        'ddlTipoDerivacion.Items.Insert(0, New ListItem("(Todos)", "0"))

        With ddlRol
            .DataSource = oSCUROL_BL.ListarCombo()
            .DataTextField = "VCHROLDESCRIP"
            .DataValueField = "INTROLCODIGO"
        End With
        ddlRol.DataBind()
        ddlRol.Items.Insert(0, New ListItem("(Todos)", "0"))

        With ddlDerivarGrupo
            .DataSource = oSCUROL_BL.ListarCombo()
            .DataTextField = "VCHROLDESCRIP"
            .DataValueField = "INTROLCODIGO"
        End With
        ddlDerivarGrupo.DataBind()
        ddlDerivarGrupo.Items.Insert(0, New ListItem("(Ninguno)", "0"))

    End Sub

    Protected Sub gvDatos_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatos.PageIndexChanging
        gvDatos.PageIndex = e.NewPageIndex
        CargarBuscarIncidencia()
    End Sub

    Protected Sub ddlTipoInc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipoInc.SelectedIndexChanged
        Dim oCCOTIPOINCIDENCIA_BE As New CCOTIPOINCIDENCIA_BE
        Dim oCCOTIPOINCIDENCIA_BL As New CCOTIPOINCIDENCIA_BL
        Dim oCCOSUBTIPOINCIDENCIA_BE As New CCOSUBTIPOINCIDENCIA_BE
        Dim oCCOSUBTIPOINCIDENCIA_BL As New CCOSUBTIPOINCIDENCIA_BL

        oCCOTIPOINCIDENCIA_BE.PropTINCODIGO = ddlTipoInc.SelectedValue
        oCCOTIPOINCIDENCIA_BE = oCCOTIPOINCIDENCIA_BL.ListarKey(oCCOTIPOINCIDENCIA_BE)

        oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = 0
        oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = ddlTipoInc.SelectedValue
        With ddlSubtipoInc
            .DataSource = oCCOSUBTIPOINCIDENCIA_BL.ListarCombo(oCCOSUBTIPOINCIDENCIA_BE)
            .DataTextField = "PropSTIDESCRIPCION"
            .DataValueField = "PropSTICODIGO"
        End With
        ddlSubtipoInc.DataBind()
        ddlSubtipoInc.Items.Insert(0, New ListItem("(Todos)", "0"))

    End Sub


    Private Sub MostrarPopup(ByVal pdiv As String)
        Dim sb As New StringBuilder
        sb.AppendLine("javascript:void(0);")
        sb.AppendLine("document.getElementById('" & pdiv & "').style.display='block';document.getElementById('fade').style.display='block';")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub

    Private Sub MostrarPopupDerivar(ByVal pdiv As String)
        Dim sb As New StringBuilder
        sb.AppendLine("javascript:void(0);")
        sb.AppendLine("document.getElementById('alertaspendientes').style.display='none';document.getElementById('fade').style.display='none';")
        sb.AppendLine("document.getElementById('" & pdiv & "').style.display='block';document.getElementById('fade').style.display='block';")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub


    Private Sub CerrarPopup(ByVal pdiv As String)
        Dim sb As New StringBuilder
        sb.AppendLine("javascript:void(0);")
        sb.AppendLine("document.getElementById('" & pdiv & "').style.display='none';document.getElementById('fade').style.display='none';")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub


    Protected Sub gvDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowDataBound



        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim _lnbDerivar As LinkButton = e.Row.FindControl("lnbDeriva")
            Dim _lnbCancelDerivar As LinkButton = e.Row.FindControl("lnbCancelDeriva")
            Dim _lblDerivado As Label = e.Row.FindControl("lblDerivado")

            Dim _lblPrioridad As Label = e.Row.FindControl("lblPrioridad")
            Dim _imgPrioridad As Image = e.Row.FindControl("imgPrioridad")
            Select Case _lblPrioridad.Text
                Case "3"
                    _imgPrioridad.ImageUrl = "img/Prioridad/BAJA.png"
                Case "2"
                    _imgPrioridad.ImageUrl = "img/Prioridad/MEDIA.png"
                Case "1"
                    _imgPrioridad.ImageUrl = "img/Prioridad/ALTA.png"
                Case Else
                    _imgPrioridad.ImageUrl = "img/Prioridad/NADA.png"
            End Select

            Dim IDinci As DataControlFieldCell = CType(e.Row.Controls(1), DataControlFieldCell)
            'If (DateTime.Parse(dcfc.Text).Hour = DateTime.Now.Hour And DateTime.Parse(dcfc.Text).Minute = DateTime.Now.Minute) Then


            If IDinci.Text = ViewState("dkincidencia") Then
                ViewState("oRowIndex") = e.Row.RowIndex
                For i = 0 To e.Row.Cells.Count - 1
                    Dim dcfc2 As DataControlFieldCell = CType(e.Row.Controls(i), DataControlFieldCell)
                    dcfc2.BackColor = Drawing.Color.FromName("#FFA500")
                    dcfc2.ForeColor = Drawing.Color.FromName("#F0F0F0")

                    'dcfc2.BackColor = Drawing.Color.FromName("#a3a2a7")
                    'dcfc2.ForeColor = Drawing.Color.FromName("#F0F0F0")
                Next
            End If

            'e.Row.Attributes.Add("OnMouseOut", "this.className = this.orignalclassName;")
            'e.Row.Attributes.Add("OnMouseOver", "this.orignalclassName = this.className;this.className = Resaltar_On(this);")

        End If
    End Sub


    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargarBuscarIncidencia()
    End Sub


    Private Sub CargarBuscarIncidencia()
        oINC = New CCOINCIDENCIA_BE
        oINC_BL = New CCOINCIDENCIA_BL
        Dim pTieneRecurso As Integer = 0
        '--0 - TODOS / 1 - CON PARTE / 2 - SIN PARTE
        Dim pTieneParte As Integer = 0
        Dim pRecursoCodigo As Integer = 0
        Dim pBuscaTodo As Integer = 0
        Dim pDesde As String = ""
        Dim pHasta As String = ""


        Try
            If txtNumeroInc.Text.Trim = "" Then
                oINC.PropINCCODIGO = 0
            Else
                oINC.PropINCCODIGO = txtNumeroInc.Text.Trim
            End If
            oINC.PropINCNUMEROORIGEN = txtTelefonoInc.Text.ToString.Trim
            oINC.PropINCLOCVIANOMBRE1 = txtViaInc.Text.ToUpper
            oINC.PropINCRELATO = txtRelatoInc.Text.ToUpper
            oINC.PropINCNOMBRECOMP = txtInformanteInc.Text.ToUpper


            oINC.PropINCESTADO = ddlEstadoInc.SelectedValue


            oINC.PropORICODIGO = ddlOrigenInc.SelectedValue
            oINC.PropTINCODIGO = ddlTipoInc.SelectedValue
            oINC.PropSTICODIGO = ddlSubtipoInc.SelectedValue
            oINC.PropPRICODIGO = ddlPrioridadInc.SelectedValue
            oINC.PropAUDROLMODIF = ddlRol.SelectedValue
            oINC.PropVCHINCLOCSECTOR = ddlSectorInc.SelectedValue
            oINC.PropPAQCODIGO = ddlRecursoInc.SelectedValue
            oINC.PropAUDUSUCREACION = ddlUsuarioInc.SelectedValue
            oINC.PropINCNOMBRE = txtRecursoInc.Text.ToUpper.Trim
            oINC.PropVCHINCLOCCUADRANTE = txtCuadrante.Text.ToUpper.Trim
            oINC.PropINCIDANEXO = ddlAnexoInc.SelectedValue

            If txtHoraFinal.Text = "" Or txtHoraInicio.Text = "" Then
                oINC.PropAUDPRGCREACION = "00:00"
                oINC.PropAUDPRGMODIF = "23:59"
            Else
                oINC.PropAUDPRGCREACION = txtHoraInicio.Text
                oINC.PropAUDPRGMODIF = txtHoraFinal.Text
            End If


            If txtFechaFinal.Text = "" Or txtFechaInicio.Text = "" Then
                oINC.PropAUDFECCREACION = Date.Now
                oINC.PropAUDFECMODIF = Date.Now
            Else
                oINC.PropAUDFECCREACION = txtFechaInicio.Text
                oINC.PropAUDFECMODIF = txtFechaFinal.Text
            End If

            '--- Busqueda segun criterios
            If rbtUtlimaSemana.Checked Then
                pBuscaTodo = 0
            End If

            If rbtTodo.Checked Then
                pBuscaTodo = 1
            End If

            gvDatos.DataSource = oINC_BL.Busqueda(oINC, pBuscaTodo)
            gvDatos.DataBind()
            gvDatos.SelectedIndex = -1
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub

    Protected Sub gvDatos_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "javascript: this.style.cursor='pointer';"
            e.Row.Attributes("onmouseout") = "javascript: this.style.cursor='normal';"
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvDatos, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '-- DESHABILITADO TEMPORALMENT
        VerificaLlamadaEntrante()
        CargarBuscarIncidencia()
    End Sub

    Private Sub VerificaLlamadaEntrante()
        Try
            Dim oSYS_BE As New SYSESTACION_BE
            Dim oSYS_BL As New SYSESTACION_BL
            Dim oINCI_BE As New CCOINCIDENCIA_BE
            Dim oINCI_BL As New CCOINCIDENCIA_BL

            lblHorario.Text = DateTime.Now
            oSYS_BE.PropEXTENSION = Session("ANEXO").ToString

            oSYS_BE = oSYS_BL.ListarKey(oSYS_BE)

            If oSYS_BE.PropINCCODIGO > 0 Then
                Dim sb As New StringBuilder

                '--- Actualiza status
                oSYS_BE.PropCONECTADO = 2
                oSYS_BL.Atencion_SIP(oSYS_BE, Session("Usuario"), CType(Session("Rol"), Integer))
                '-- obtiene informacion de incidente
                oINCI_BE.PropINCCODIGO = oSYS_BE.PropINCCODIGO
                oINCI_BE = oINC_BL.ListarKey(oINCI_BE)

                sb.Append("<script>")

                sb.Append("var url = 'frmIncidenciaManual.aspx?pModo=MODIFICAR&pID=" + oINCI_BE.PropINCCODIGO.ToString + "&pLAT=" + oINCI_BE.PropINCIDLATITUDE + "&pLON=" + oINCI_BE.PropINCIDLONGITUDE + "';")
                sb.Append("var setting = 'directories=no,height=750,left=20,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=20,width=1300';")

                sb.Append("jBeep('jBeep/JBeep2.wav');")
                sb.Append("window.open(url, 'ALERTASURCO', setting);")
                sb.Append("</script>")

                ScriptManager.RegisterStartupScript(Me, Me.GetType, "Incidencia", sb.ToString, False)
            End If

        Catch ex As Exception
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            Throw ex
        End Try

    End Sub

    Protected Sub btnVisualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        gvDatos.SelectedIndex = ViewState("oRowIndex")
        If gvDatos.SelectedIndex >= 0 Then
            Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex) '-- es la fila de la grilla 
            Dim intID As Integer = dk.Item("INTINCCODIGO")  ' se pone el nombre de la llave 
            Dim strLat As String = dk.Item("VCHINCIDLATITUDE")  ' se pone el nombre de la llave 
            Dim strLon As String = dk.Item("VCHINCIDLONGITUDE")  ' se pone el nombre de la llave 
            Dim intOI As String = dk.Item("SMLORICODIGO")  ' se pone el nombre de la llave 
            Dim strMA As String = dk.Item("VCHMOTIVOALERTA")  ' se pone el nombre de la llave 
            Dim strDI As String = dk.Item("VCHINCDOCUMENTO")  ' se pone el nombre de la llave 
            Dim strEstado As String = dk.Item("VCHINCESTADO")

            Dim sb As New StringBuilder

            If Not IsNothing(intID) Then
                Dim nomVentana As String = "VentanaVisualizar" + intID.ToString
                sb.Append("<script>")
                sb.Append("var url = 'frmIncidenciaAtender.aspx?pModo=VISUALIZAR&pID=" + intID.ToString + "';")
                sb.Append("var setting = 'directories=no,height=750,left=20,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=20,width=1400';")
                sb.Append("window.open(url, '" + nomVentana + "', setting);")
                sb.Append("</script>")
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "Incidencia", sb.ToString, False)
            End If
        End If

    End Sub

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim nomVentana As String = "frmIncidencia" + DateTime.Now.ToString("yyyyMMddhhmmss")
        Dim sb As New StringBuilder
        sb.Append("<script>")
        'sb.Append("var url = 'frmIncidencia.aspx?pModo=NUEVO&pID=0';")
        sb.Append("var url = 'frmIncidenciaManual.aspx?pModo=NUEVO&pID=0';")
        'sb.Append("var setting = 'directories=no,height=750,left=20,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=20,width=1300';")
        sb.Append("var setting = 'directories=no,height=860,left=20,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=20,width=1400';")
        sb.Append("window.open(url, '" + nomVentana + "', setting);")
        sb.Append("</script>")
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "Incidencia", sb.ToString, False)


    End Sub



#Region "DERIVAR INCIDENTE"

    Protected Sub btnRevertir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRevertir.Click
        gvDatos.SelectedIndex = ViewState("oRowIndex")
        If gvDatos.SelectedIndex >= 0 Then
            Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex) '-- es la fila de la grilla 
            Dim intID As Integer = dk.Item("INTINCCODIGO")  ' ID de Incidente
            Dim intRD As Integer = dk.Item("INTINCROLDERIVADO")  ' ROL DE DERIVACION
            Dim intOI As Integer = dk.Item("SMLORICODIGO")  ' Origen incidencia
            Dim strMA As String = dk.Item("VCHMOTIVOALERTA")  ' MOTIVO ALERTA
            Dim strDI As String = dk.Item("VCHINCDOCUMENTO")  ' DOCUMENTO IDENTIDAD

            Dim intE As Integer = dk.Item("SMLINCESTADO")  ' ESTADO de Incidente
            Dim strORI As String = dk.Item("VCHORIDESCRIPCION")  ' ORIGEN INCIDENCIA
            Dim strTI As String = dk.Item("VCHTINDESCRIPCION")  ' TIPO INCIDENCIA
            Dim strSTI As String = dk.Item("VCHSTIDESCRIPCION")  ' SUBTIPO INCIDENCIA

            hfIncidente.Value = intID
            Me.ddlDerivarGrupo.SelectedValue = 0
            Me.txtDerivarComentario.Text = ""
            Me.txtDerIncNumero.Text = intID
            Me.txtDerIncFecha.Text = gvDatos.Rows(gvDatos.SelectedIndex).Cells(2).Text()  'DTMINCFECHA
            Me.txtDerIncOrigen.Text = strORI 'VCHORIDESCRIPCION
            Me.txtDerIncNumTel.Text = gvDatos.Rows(gvDatos.SelectedIndex).Cells(5).Text() 'VCHINCNUMEROORIGEN
            Me.txtDerIncTipo.Text = strTI
            Me.txtDerIncSubtipo.Text = strSTI
            MostrarPopup("derivar")
        Else
            Util.MSG_ALERTA("Seleccione item para Derivar", Me)
        End If
    End Sub

    Protected Sub btnDerivarAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDerivarAceptar.Click
        If ddlDerivarGrupo.SelectedValue = 0 Then
            Util.MSG_ALERTA("Seleccione ROL para Derivar", Me)
            Exit Sub
        End If

        If txtDerivarComentario.Text.Length > 250 Then
            Util.MSG_ALERTA("ERROR : COMENTARIO excede el número de caracteres permitido!!!", Me)
            Exit Sub
        End If

        Try
            DerivarIncidente()
            CerrarPopup("derivar")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Private Sub DerivarIncidente()
        Try
            Dim oINC_BE As New CCOINCIDENCIA_BE
            Dim oINC_BL As New CCOINCIDENCIA_BL
            oINC_BE.PropINCCODIGO = CType(hfIncidente.Value, Int32)
            oINC_BE.PropINCUSUDERIVADO = CType(Session("Usuario"), String)
            oINC_BE.PropINCROLDERIVADO = ddlDerivarGrupo.SelectedValue
            oINC_BE.PropINCCOMENTARIO = txtDerivarComentario.Text
            oINC_BE.PropAUDUSUMODIF = CType(Session("Usuario"), String)
            oINC_BE.PropAUDFECMODIF = Now.Date
            oINC_BE.PropAUDEQPMODIF = CType(Session("equipo"), String)
            oINC_BE.PropAUDPRGMODIF = CType(Session("proyecto"), String)
            oINC_BE.PropINCESTADO = 65  '--Derivado
            oINC_BL.DerivarIncidencia(oINC_BE)

            '--- Elimina de la bandeja notificaciones
            Dim oSYS_BL As SYSESTACION_BL = New SYSESTACION_BL
            Dim incidencia As Int32
            If hfIncidente.Value <> String.Empty Then
                incidencia = Int32.Parse(hfIncidente.Value)
                oSYS_BL.EliminarAlerta(incidencia)
            End If
            '-- actualizo la bandeja de notificaciones
            VerificaLlamadaEntrante()
            '-- acyualiza grilla
            CargarBuscarIncidencia()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

#End Region

#Region "CANCELAR DERIVAR INCIDENTE"
    'Protected Sub btnRevDerivar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRevDerivar.Click
    '    gvDatos.SelectedIndex = ViewState("oRowIndex")
    '    If gvDatos.SelectedIndex >= 0 Then
    '        Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex) '-- es la fila de la grilla 
    '        Dim intID As Integer = dk.Item("INTINCCODIGO")  ' ID de Incidente
    '        Dim intRD As Integer = dk.Item("INTINCROLDERIVADO")  ' ROL DE DERIVACION
    '        hfIncidente.Value = intID
    '        '-- verifica si esta derivado?
    '        If intRD = 0 Then
    '            Util.MSG_ALERTA("ERROR : Imposible CANCELAR DERIVACION, Incidente no esta Derivado!!!", Me)
    '        Else
    '            CancelarDerivarIncidente()
    '        End If
    '    Else
    '        Util.MSG_ALERTA("Seleccione item para Cancelar Derivar", Me)
    '    End If

    'End Sub

    'Private Sub CancelarDerivarIncidente()
    '    Try
    '        Dim oINC_BE As New CCOINCIDENCIA_BE
    '        Dim oINC_BL As New CCOINCIDENCIA_BL
    '        oINC_BE.PropINCCODIGO = CType(hfIncidente.Value, Integer)
    '        oINC_BE.PropINCUSUDERIVADO = CType(Session("Usuario"), String)
    '        oINC_BE.PropINCROLDERIVADO = ddlDerivarGrupo.SelectedValue
    '        oINC_BE.PropINCCOMENTARIO = txtDerivarComentario.Text
    '        oINC_BE.PropAUDUSUMODIF = CType(Session("Usuario"), String)
    '        oINC_BE.PropAUDFECMODIF = Now.Date
    '        oINC_BE.PropAUDEQPMODIF = CType(Session("equipo"), String)
    '        oINC_BE.PropAUDPRGMODIF = CType(Session("proyecto"), String)
    '        oINC_BE.PropINCESTADO = 66  '--Cancelar Derivación
    '        oINC_BL.CancelarDerivarIncidencia(oINC_BE)
    '        CargarBuscarIncidencia()
    '    Catch ex As Exception
    '        lblMensaje.Text = ex.Message
    '    End Try
    'End Sub
#End Region

#Region "HISTORIAL INCIDENTE"
    Protected Sub btnHistorial_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnHistorial.Click
        gvDatos.SelectedIndex = ViewState("oRowIndex")
        If gvDatos.SelectedIndex >= 0 Then
            Dim oHIS_BE As New CCOINCIDENCIAHISTORIAL_BE
            Dim oHIS_BL As New CCOINCIDENCIAHISTORIAL_BL
            Dim oINC_BL As New CCOINCIDENCIA_BL
            Dim dtINC As New DataTable
            Dim dt As New DataTable
            Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex) '-- es la fila de la grilla 
            Dim intID As Integer = dk.Item("INTINCCODIGO")  ' se pone el nombre de la llave 
            '-- obtiene info de Incidente
            Try
                dtINC = oINC_BL.ListarDatos(intID)
                txtNumeroIncHis.Text = dtINC.Rows(0).Item("INTINCCODIGO")
                txtTipoIncHis.Text = dtINC.Rows(0).Item("VCHTINDESCRIPCION")
                txtSubtipoIncHis.Text = dtINC.Rows(0).Item("VCHSTIDESCRIPCION")
                txtPrioridadIncHis.Text = dtINC.Rows(0).Item("VCHPRIDESCRIPCION")
                '-- obtiene info de Historial
                oHIS_BE.PropINCCODIGO = intID
                dt = oHIS_BL.Listar(oHIS_BE)
                ViewState("dtH") = dt
                '--If dt.Rows.Count > 0 Then
                gvHistorial.DataSource = dt
                gvHistorial.DataBind()
                MostrarPopup("historial")
            Catch ex As Exception
                lblMensajeSistema.Text = ex.Message.ToString
                Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            End Try
            '--End If
        End If
    End Sub

    Protected Sub gvHistorial_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvHistorial.PageIndexChanging
        gvHistorial.PageIndex = e.NewPageIndex
        MostrarPopup("historial")
    End Sub
#End Region

#Region "CERRAR INCIDENTE"
    Protected Sub btnCierreAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCierreAceptar.Click

        If TxtCierreComentario.Text = "" Then
            Util.MSG_ALERTA("Ingrese COMENTARIO para Cerrar", Me)
            Exit Sub
        End If

        If TxtCierreComentario.Text.Length > 250 Then
            Util.MSG_ALERTA("ERROR : COMENTARIO excede el número de caracteres permitido!!!", Me)
            Exit Sub
        End If

        Try
            CerrarIncidente()
            CerrarPopup("cerrarincidente")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub

    Private Sub CerrarIncidente()
        Try
            Dim oINC_BE As New CCOINCIDENCIA_BE
            Dim oINC_BL As New CCOINCIDENCIA_BL
            oINC_BE.PropINCCODIGO = CType(hfIncidente.Value, Integer)
            oINC_BE.PropINCUSUDERIVADO = CType(Session("Usuario"), String)
            oINC_BE.PropINCROLDERIVADO = CType(Session("Rol"), Integer)
            oINC_BE.PropINCCOMENTARIO = TxtCierreComentario.Text
            oINC_BE.PropAUDUSUMODIF = CType(Session("Usuario"), String)
            oINC_BE.PropAUDFECMODIF = Now.Date
            oINC_BE.PropAUDEQPMODIF = CType(Session("equipo"), String)
            oINC_BE.PropAUDPRGMODIF = CType(Session("proyecto"), String)
            oINC_BE.PropINCESTADO = 65  '--Derivado
            oINC_BL.CerrarIncidencia(oINC_BE)
            CargarBuscarIncidencia()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub btnCierreCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCierreCancelar.Click
        Try
            CerrarPopup("cerrarincidente")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        gvDatos.SelectedIndex = ViewState("oRowIndex")
        If gvDatos.SelectedIndex >= 0 Then
            Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex) '-- es la fila de la grilla 
            Dim intID As Integer = dk.Item("INTINCCODIGO")  ' ID de Incidente
            Dim intRD As Integer = dk.Item("INTINCROLDERIVADO")  ' ROL DE DERIVACION
            Dim intE As Integer = dk.Item("SMLINCESTADO")  ' ESTADO de Incidente
            Dim strORI As String = dk.Item("VCHORIDESCRIPCION")  ' ORIGEN INCIDENCIA
            Dim strTI As String = dk.Item("VCHTINDESCRIPCION")  ' TIPO INCIDENCIA
            Dim strSTI As String = dk.Item("VCHSTIDESCRIPCION")  ' SUBTIPO INCIDENCIA

            hfIncidente.Value = intID
            Me.TxtCierreComentario.Text = ""
            Me.txtCerrIncNumero.Text = intID
            Me.txtCerrIncFecha.Text = gvDatos.Rows(gvDatos.SelectedIndex).Cells(2).Text()  'DTMINCFECHA
            Me.txtCerrIncOrigen.Text = strORI
            Me.txtCerrIncNumTel.Text = gvDatos.Rows(gvDatos.SelectedIndex).Cells(5).Text() 'VCHINCNUMEROORIGEN
            Me.txtCierreTI.Text = strTI
            Me.txtCierreSTI.Text = strSTI

            '-- verifica si esta derivado?
            If intE <> CType(ViewState("incEstCerrado"), Integer) Then
                MostrarPopup("cerrarincidente")
            Else
                Util.MSG_ALERTA("ERROR : Imposible Cerrar, Incidente ya fue Cerrado!!!", Me)
            End If
        Else
            Util.MSG_ALERTA("Seleccione item para Cerrar", Me)
        End If
    End Sub
#End Region

#Region "DEVOLVER ABIERTA INCIDENTE"
    'Protected Sub btnRevCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRevCerrar.Click
    '    gvDatos.SelectedIndex = ViewState("oRowIndex")
    '    If gvDatos.SelectedIndex >= 0 Then
    '        Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex) '-- es la fila de la grilla 
    '        Dim intID As Integer = dk.Item("INTINCCODIGO")  ' ID de Incidente
    '        Dim intRD As Integer = dk.Item("INTINCROLDERIVADO")  ' ROL DE DERIVACION
    '        Dim intE As Integer = dk.Item("SMLINCESTADO")  ' ESTADO de Incidente
    '        hfIncidente.Value = intID
    '        '-- verifica si esta derivado?
    '        If intE = CType(ViewState("incEstCerrado"), Integer) Then
    '            DevolverAbiertaIncidente()
    '        Else
    '            Util.MSG_ALERTA("ERROR : Imposible DEVOLVER CERRAR, Incidente no esta Cerrado!!!", Me)
    '        End If
    '    Else
    '        Util.MSG_ALERTA("Seleccione item para Cancelar Derivar", Me)
    '    End If
    'End Sub

    'Private Sub DevolverAbiertaIncidente()
    '    Try
    '        Dim oINC_BE As New CCOINCIDENCIA_BE
    '        Dim oINC_BL As New CCOINCIDENCIA_BL
    '        oINC_BE.PropINCCODIGO = CType(hfIncidente.Value, Integer)
    '        oINC_BE.PropINCUSUDERIVADO = CType(Session("Usuario"), String)
    '        oINC_BE.PropINCROLDERIVADO = CType(Session("Rol"), Integer)
    '        oINC_BE.PropINCCOMENTARIO = txtDerivarComentario.Text
    '        oINC_BE.PropAUDUSUMODIF = CType(Session("Usuario"), String)
    '        oINC_BE.PropAUDFECMODIF = Now.Date
    '        oINC_BE.PropAUDEQPMODIF = CType(Session("equipo"), String)
    '        oINC_BE.PropAUDPRGMODIF = CType(Session("proyecto"), String)
    '        oINC_BE.PropINCESTADO = 66  '--Cancelar Derivación
    '        oINC_BL.DevolerAbiertaIncidencia(oINC_BE)
    '        CargarBuscarIncidencia()
    '    Catch ex As Exception
    '        lblMensaje.Text = ex.Message
    '    End Try
    'End Sub
#End Region



    'Protected Sub ddlRecursoTiene_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRecursoTiene.SelectedIndexChanged
    '    Me.txtCodigoRec.Text = ""
    '    If ddlRecursoTiene.SelectedValue = 1 Then
    '        Me.txtCodigoRec.Visible = True
    '        Me.lblCodigoRec.Visible = True
    '        Me.btnBuscarRecurso.Visible = True
    '    Else
    '        Me.txtCodigoRec.Visible = False
    '        Me.lblCodigoRec.Visible = False
    '        Me.btnBuscarRecurso.Visible = False
    '    End If
    'End Sub

    Protected Sub rbtTodo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtTodo.CheckedChanged
        If rbtTodo.Checked Then
            mostrarRangoFecha(True)
        Else
            mostrarRangoFecha(False)
        End If
    End Sub

    Protected Sub rbtUtlimaSemana_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtUtlimaSemana.CheckedChanged
        If rbtUtlimaSemana.Checked Then
            mostrarRangoFecha(False)
        Else
            mostrarRangoFecha(True)
        End If

    End Sub

    Private Sub mostrarRangoFecha(ByVal habilita As Boolean)
        txtFechaInicio.Visible = habilita
        Image1.Visible = habilita
        lblFecInicio.Visible = habilita
        txtFechaFinal.Visible = habilita
        Image2.Visible = habilita
        lblFecFinal.Visible = habilita
        txtHoraInicio.Visible = habilita
        txtHoraFinal.Visible = habilita

    End Sub


#Region "Gestion de alertas"
    Protected Sub btnAlertasPendientes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAlertasPendientes.Click
        CargaAlertasPendientes()
        MostrarPopup("alertaspendientes")
    End Sub

    Private Sub CargaAlertasPendientes()
        'Dim dt As DataTable = CType(ViewState("ds"), DataSet).Tables(2)
        Dim dt As DataTable = CType(ViewState("ds"), DataSet).Tables(0)
        gvAlertasPendientes.DataSource = dt
        gvAlertasPendientes.DataBind()
    End Sub
#End Region

    Protected Sub btnAtenderAlerta_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tabla As Tabla = New Tabla
        'tabla.Datos = CType(ViewState("ds"), DataSet).Tables(2)
        tabla.Datos = CType(ViewState("ds"), DataSet).Tables(0)
        Try
            Dim gwrow As GridViewRow = CType(CType(sender, Button).NamingContainer, GridViewRow)
            Dim oSYS_BE As SYSESTACION_BE = New SYSESTACION_BE
            Dim oSYS_BL As SYSESTACION_BL = New SYSESTACION_BL
            Dim oINCI_BE As CCOINCIDENCIA_BE = New CCOINCIDENCIA_BE
            Dim oINCI_BL As CCOINCIDENCIA_BL = New CCOINCIDENCIA_BL
            oSYS_BE.PropEXTENSION = "911"

            oSYS_BE = oSYS_BL.ListarKey(oSYS_BE)

            oSYS_BE.PropCONECTADO = 2
            oSYS_BL.Atencion_SIP(oSYS_BE, Session("Usuario"), CType(Session("Rol"), Integer))

            Dim sb As New StringBuilder
            oINCI_BE.PropINCCODIGO = tabla.Datos.Rows(gwrow.DataItemIndex).Item("INCIDENCIA")
            oINCI_BE = oINC_BL.ListarKey(oINCI_BE)

            sb.Append("<script>")
            sb.Append("var url = 'frmIncidenciaManual.aspx?pModo=MODIFICAR&pID=" + oINCI_BE.PropINCCODIGO.ToString + "&pLAT=" + oINCI_BE.PropINCIDLATITUDE + "&pLON=" + oINCI_BE.PropINCIDLONGITUDE + "';")
            sb.Append("var setting = 'directories=no,height=750,left=20,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=20,width=1300';")
            sb.Append("window.open(url, 'frmIncidenciaM', setting);")
            sb.Append("</script>")

            CargaAlertasPendientes()
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "Incidencia", sb.ToString, False)
            CerrarPopup("alertaspendientes")
        Catch ex As Exception
            lblMensajeSistema.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub btnLibertarAlerta_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tabla As Tabla = New Tabla
        tabla.Datos = CType(ViewState("ds"), DataSet).Tables(2)
        Try
            Dim gwrow As GridViewRow = CType(CType(sender, Button).NamingContainer, GridViewRow)
            Dim oSYS_BE As SYSESTACION_BE = New SYSESTACION_BE
            Dim oSYS_BL As SYSESTACION_BL = New SYSESTACION_BL
            Dim oINCI_BE As CCOINCIDENCIA_BE = New CCOINCIDENCIA_BE
            oINCI_BE.PropINCCODIGO = tabla.Datos.Rows(gwrow.DataItemIndex).Item("INCIDENCIA")

            oSYS_BL.LiberarAlerta(oINCI_BE.PropINCCODIGO, Session("Usuario").ToString)
            CargaAlertasPendientes()
            CerrarPopup("alertaspendientes")
        Catch ex As Exception
            lblMensajeSistema.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub gvDatos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDatos.SelectedIndexChanged
        Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex) '-- es la fila de la grilla 
        Dim intID As Integer = dk.Item("INTINCCODIGO")  ' se pone el nombre de la llave 
        Dim intROL As Integer = dk.Item("INTINCROLDERIVADO")  ' se pone el nombre de la llave 
        Dim intESTADO As Integer = dk.Item("SMLINCESTADO")  ' se pone el nombre de la llave 
        hfIncidente.Value = intID
        hfINCESTADO.Value = intESTADO
        hfINCROL.Value = intROL
        hfUSUROL.Value = CType(Session("ROL"), Integer)
        ViewState("dkincidencia") = intID
        ViewState("oRowIndex") = gvDatos.SelectedIndex
    End Sub


    Protected Sub btnDerivarAlerta_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tabla As Tabla = New Tabla
        tabla.Datos = CType(ViewState("ds"), DataSet).Tables(0)
        Try
            Dim gwrow As GridViewRow = CType(CType(sender, Button).NamingContainer, GridViewRow)
            Dim oSYS_BE As SYSESTACION_BE = New SYSESTACION_BE
            Dim oSYS_BL As SYSESTACION_BL = New SYSESTACION_BL
            Dim oINCI_BE As CCOINCIDENCIA_BE = New CCOINCIDENCIA_BE
            Dim oINCI_BL As CCOINCIDENCIA_BL = New CCOINCIDENCIA_BL
            Dim intRD As Integer = 0
            Dim intOI As Integer
            oINCI_BE.PropINCCODIGO = tabla.Datos.Rows(gwrow.DataItemIndex).Item("INCIDENCIA")

            oINCI_BE = oINCI_BL.ListarKey(oINCI_BE)

            Dim intID As Integer = oINCI_BE.PropINCCODIGO  ' ID de Incidente
            If Not oINCI_BE.PropINCROLDERIVADO Is Nothing Then
                intRD = oINCI_BE.PropINCROLDERIVADO  ' ROL DE DERIVACION
            End If
            If Not oINCI_BE.PropORICODIGO Is Nothing Then
                intOI = oINCI_BE.PropORICODIGO  ' Origen incidencia
            End If

            Dim strMA As String = oINCI_BE.PropVCHMOTIVOALERTA   ' MOTIVO ALERTA
            Dim strDI As String = oINCI_BE.PropINCDOCUMENTO  ' DOCUMENTO IDENTIDAD

            hfIncidente.Value = intID
            Me.ddlDerivarGrupo.SelectedValue = 0
            Me.txtDerivarComentario.Text = ""
            Me.txtDerIncNumero.Text = intID
            Me.txtDerIncFecha.Text = oINCI_BE.PropINCFECHA   'DTMINCFECHA
            Me.txtDerIncOrigen.Text = oINCI_BE.PropORICODIGO
            Me.txtDerIncNumTel.Text = oINCI_BE.PropINCNUMEROORIGEN

            '-- verifica si esta derivado?

            If intRD = 0 Then
                MostrarPopupDerivar("derivar")
            Else
                Util.MSG_ALERTA("Imposible DERIVAR, Incidente ya fue Derivado!!!", Me)
            End If
            CargaAlertasPendientes()


        Catch ex As Exception
            lblMensajeSistema.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub


    Protected Sub btnDespacho_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDespacho.Click
        gvDatos.SelectedIndex = ViewState("oRowIndex")
        If gvDatos.SelectedIndex >= 0 Then

            Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex) '-- es la fila de la grilla 
            Dim intID As Integer = dk.Item("INTINCCODIGO")  ' ID de incidencia 
            Dim intEST As Integer = dk.Item("SMLINCESTADO")  ' ESTADO de incidencia 
            Dim intROL As Integer = dk.Item("INTINCROLDERIVADO")  'ROL derivado

            If Not IsNothing(intID) Then
                Dim sb As New StringBuilder
                Dim nomVentana As String = "frmIncidenciaAtender" + intID.ToString
                If intEST = 11 Then
                    sb.Append("<script>")
                    sb.Append("var url = 'frmIncidenciaAtender.aspx?pModo=VISUALIZAR&pID=" + intID.ToString + "';")
                    sb.Append("var setting = 'directories=no,height=750,left=20,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=20,width=1400';")
                    sb.Append("window.open(url, 'frmIncidenciaAtender', setting);")
                    sb.Append("</script>")
                Else
                    sb.Append("<script>")
                    sb.Append("var url = 'frmIncidenciaAtender.aspx?pModo=MODIFICAR&pID=" + intID.ToString + "';")
                    sb.Append("var setting = 'directories=no,height=750,left=20,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=20,width=1400';")
                    sb.Append("window.open(url, '" + nomVentana + "', setting);")
                    sb.Append("</script>")
                End If
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "Incidencia", sb.ToString, False)
                'Response.Redirect("frmAtenderIncidencia.aspx?pID=" + intID.ToString)
            End If
        End If

    End Sub

    Protected Sub btnAtender_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAtender.Click
        gvDatos.SelectedIndex = ViewState("oRowIndex")
        If gvDatos.SelectedIndex >= 0 Then
            Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex) '-- es la fila de la grilla 
            Dim intID As Integer = dk.Item("INTINCCODIGO")  ' se pone el nombre de la llave 
            Dim strLat As String = dk.Item("VCHINCIDLATITUDE")  ' se pone el nombre de la llave 
            Dim strLon As String = dk.Item("VCHINCIDLONGITUDE")  ' se pone el nombre de la llave 
            Dim intOI As String = dk.Item("SMLORICODIGO")  ' se pone el nombre de la llave 
            Dim strMA As String = dk.Item("VCHMOTIVOALERTA")  ' se pone el nombre de la llave 
            Dim strDI As String = dk.Item("VCHINCDOCUMENTO")  ' se pone el nombre de la llave 
            Dim strEstado As String = dk.Item("VCHINCESTADO")
            Dim intRolDeriva As Integer = dk.Item("INTINCROLDERIVADO")

            Dim sb As New StringBuilder

            sb.Append("<script>")
            sb.Append("var url = 'frmIncidenciaManual.aspx?pModo=MODIFICAR&pID=" + intID.ToString + "&pLAT=" + strLat + "&pLON=" + strLon + "';")
            sb.Append("var setting = 'directories=no,height=750,left=20,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=20,width=1300';")
            sb.Append("window.open(url, 'frmIncidencia', setting);")
            sb.Append("</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "Incidencia", sb.ToString, False)

        End If

    End Sub

    Protected Sub btnDefault_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDefault.Click
        Try
            ddlRol.SelectedValue = CType(Session("ROL"), Integer)
            ddlUsuarioInc.SelectedValue = CType(Session("Usuario"), String).ToUpper
            ddlAnexoInc.SelectedValue = CType(Session("ANEXO"), String)
        Catch ex As Exception
            ddlUsuarioInc.SelectedIndex = -1
            ddlRol.SelectedIndex = -1
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

        ddlOrigenInc.SelectedIndex = -1
        txtNumeroInc.Text = ""
        ddlTipoInc.SelectedIndex = -1
        ddlSubtipoInc.SelectedIndex = -1
        ddlPrioridadInc.SelectedIndex = -1
        ddlEstadoInc.SelectedIndex = -1
        txtTelefonoInc.Text = ""
        ddlSectorInc.SelectedIndex = -1
        ddlRecursoInc.SelectedIndex = -1
        txtRecursoInc.Text = ""
        txtInformanteInc.Text = ""
        txtViaInc.Text = ""
        txtRelatoInc.Text = ""
        txtFechaInicio.Text = ""
        txtFechaFinal.Text = ""
        txtHoraInicio.Text = ""
        txtHoraFinal.Text = ""
        txtCuadrante.Text = ""
        rbtUtlimaSemana.Checked = True
        rbtTodo.Checked = False
        mostrarRangoFecha(False)


    End Sub

    Protected Sub btnFormatoSADE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFormatoSADE.Click
        gvDatos.SelectedIndex = ViewState("oRowIndex")
        If gvDatos.SelectedIndex >= 0 Then
            Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex) '-- es la fila de la grilla 
            Dim intID As Integer = dk.Item("INTINCCODIGO")  ' se pone el nombre de la llave 
            Dim sb As New StringBuilder
            sb.Append("<script>")
            sb.Append("var url = 'Reportes/rpt/ReporteGenerico.aspx?pReporte=ReporteFormatoSADE&pINCCODIGO=" + intID.ToString + "';")
            sb.Append("var setting = 'directories=no,height=750,left=20,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=20,width=800';")
            sb.Append("window.open(url, 'frmIncidencia', setting);")
            sb.Append("</script>")
            ScriptManager.RegisterStartupScript(Me, Me.GetType, "Formato SADE", sb.ToString, False)
        End If

    End Sub

    'Protected Sub btnDerivarSIAVE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDerivarSIAVE.Click
    '    gvDatos.SelectedIndex = ViewState("oRowIndex")
    '    If gvDatos.SelectedIndex >= 0 Then
    '        Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex) '-- es la fila de la grilla 
    '        Dim intID As Integer = dk.Item("INTINCCODIGO")  ' se pone el nombre de la llave 
    '        Dim strLat As String = dk.Item("VCHINCIDLATITUDE")  ' se pone el nombre de la llave 
    '        Dim strLon As String = dk.Item("VCHINCIDLONGITUDE")  ' se pone el nombre de la llave 
    '        Dim intOI As String = dk.Item("SMLORICODIGO")  ' se pone el nombre de la llave 
    '        Dim strMA As String = dk.Item("VCHMOTIVOALERTA")  ' se pone el nombre de la llave 
    '        Dim strDI As String = dk.Item("VCHINCDOCUMENTO")  ' se pone el nombre de la llave 
    '        Dim strEstado As String = dk.Item("VCHINCESTADO")
    '        Dim intE As Integer = dk.Item("SMLINCESTADO")  ' ESTADO de Incidente
    '        Dim intRolDeriva As Integer = dk.Item("INTINCROLDERIVADO")
    '        //--  11	F	ATENDIDO
    '        //--  12	C	CERRADO
    '        If (intE.Equals(11) Or intE.Equals(12)) Then
    '            Dim sb As New StringBuilder
    '            Dim pURL As String = servidor & "regweb/SIAVE_Interfaz.aspx?dni=" + strDI + "&tipale=" + strMA + "&codinc=" + intID.ToString + "&codusu=" + Session("Usuario").ToString
    '            sb.Append("<script>")
    '            sb.Append("var url = '" + pURL + "';")
    '            sb.Append("var setting = 'directories=no,height=640,left=20,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=20,width=900';")
    '            sb.Append("window.open(url, 'SIAVE', setting);")
    '            sb.Append("</script>")
    '            ScriptManager.RegisterStartupScript(Me, Me.GetType, "Incidencia", sb.ToString, False)
    '        Else
    '            Util.MSG_ALERTA("Imposible DERIVAR A SIAVE, Verifique Estado!!!", Me)
    '        End If
    '    End If
    'End Sub

    Protected Sub btnCambiaUbica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCambiaUbica.Click

        gvDatos.SelectedIndex = ViewState("oRowIndex")
        If gvDatos.SelectedIndex >= 0 Then

            Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex) '-- es la fila de la grilla 
            Dim intID As Integer = dk.Item("INTINCCODIGO")  ' ID de incidencia 
            Dim intEST As Integer = dk.Item("SMLINCESTADO")  ' ESTADO de incidencia 
            Dim intROL As Integer = dk.Item("INTINCROLDERIVADO")  'ROL derivado

            If Not IsNothing(intID) Then
                Dim sb As New StringBuilder
                Dim nomVentana As String = "frmIncidenciaCambiaUbicacion" + intID.ToString
                If intEST = 11 Then
                    sb.Append("<script>")
                    sb.Append("var url = 'frmIncidenciaCambiaUbicacion.aspx?pModo=VISUALIZAR&pID=" + intID.ToString + "';")
                    sb.Append("var setting = 'directories=no,height=750,left=20,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=20,width=1400';")
                    sb.Append("window.open(url, 'frmIncidenciaAtender', setting);")
                    sb.Append("</script>")
                Else
                    sb.Append("<script>")
                    sb.Append("var url = 'frmIncidenciaCambiaUbicacion.aspx?pModo=MODIFICAR&pID=" + intID.ToString + "';")
                    sb.Append("var setting = 'directories=no,height=750,left=20,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=20,width=1400';")
                    sb.Append("window.open(url, '" + nomVentana + "', setting);")
                    sb.Append("</script>")
                End If
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "Incidencia", sb.ToString, False)
                'Response.Redirect("frmAtenderIncidencia.aspx?pID=" + intID.ToString)
            End If
        End If

    End Sub


End Class
