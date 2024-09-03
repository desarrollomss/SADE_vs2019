Imports System.Data
Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Collections.Generic

Partial Class frmIncidenciaManual
    Inherits System.Web.UI.Page
    'Estado de Incidencia: A=Abierto, D=Derivado (a OT, OD, S, E), R=Recepcionado, P=Despachado (con recurso asignado), T=En Atención, C=Cerrado
    Enum Estado
        Abierto = 7
        ParaDespacho = 8
        Despachado = 9
        Descartado = 10
        Atendido = 11
        Cerrado = 12
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

    Dim oINC As New CCOINCIDENCIA_BE
    Dim oINC_BL As New CCOINCIDENCIA_BL
    'Dim olstENC As New List(Of CCOENCUESTAINCIDENCIA_BE)
    Dim oENC_BL As New CCOENCUESTAINCIDENCIA_BL
    Dim oSCUROL_BL As New SCUROL_BL

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'txtFechaInc.Text = Now.ToShortDateString
        'txtHoraInc.Text = Now.ToShortTimeString
        btnGrabar.Attributes.Add("onclick", "javascript:return ValidarGrabar();")

        If Not IsPostBack() Then
            LlenarCombos()
            ViewState("pID") = Request.QueryString("pID")
            ViewState("pModo") = Request.QueryString("pModo")
            ViewState("pAnexo") = Session("USUARIO")


            '--> txtFechaInc.Text = String.Format("{0:G}", DateTime.Now)
            '--> obtener fecha y hora de servidor
            txtFechaInc.Text = String.Format("{0:G}", oINC_BL.getFechaHoraServer())


            If CType(ViewState("pID"), Integer) > 0 Then
                oINC.PropINCCODIGO = CType(ViewState("pID"), Integer)
                oINC = oINC_BL.ListarKey(oINC)
                CargaDatosControl()
            End If

            If ViewState("pModo") = "VISUALIZAR" Then
                ActivaControles(False)
            End If
            If ViewState("pModo") = "NUEVO" Then
                ActivaControles(True)
                'ddlOrigen.Items(4).Enabled = False
                'ddlOrigen.Items(5).Enabled = False
            End If

            If ViewState("pModo") = "MODIFICAR" Then
                ActivaControles(True)
                ddlOrigen.Enabled = False
                txtNumero.Enabled = False
            End If

            lblUsuario.Text = CType(Session("Usuario"), String)
            lblEquipo.Text = CType(Session("equipo"), String)

        End If
        If ViewState("pID") IsNot Nothing Then
            txtNroIncidente.Text = ViewState("pID")
        End If
    End Sub
    Public Sub LlenarCombos()
        Dim lstOrigenIncidencia As New List(Of CCOORIGENINCIDENCIA_BE)
        Dim lstTipoPersona As New List(Of CCOTIPOPERSONA_BE)

        Dim oCCOSUBTIPOINCIDENCIA_BE As New CCOSUBTIPOINCIDENCIA_BE

        Dim oCCOORIGENINCIDENCIA_BL As New CCOORIGENINCIDENCIA_BL
        Dim oCCOTIPOPERSONA_BL As New CCOTIPOPERSONA_BL
        Dim oCCOTIPODOCUMENTO_BL As New CCOTIPODOCUMENTO_BL
        Dim oCCOTIPOINCIDENCIA_BL As New CCOTIPOINCIDENCIA_BL
        Dim oCCOSUBTIPOINCIDENCIA_BL As New CCOSUBTIPOINCIDENCIA_BL
        Dim oCCOPRIORIDADINCIDENCIA_BL As New CCOPRIORIDADINCIDENCIA_BL
        Dim oSYSCATASTRO_BL As New SYSCATASTRO_BL
        Dim oCCOTABLA_BE As New CCOTABLA_BE
        Dim oCCOTABLA_BL As New CCOTABLA_BL

        With ddlOrigen
            .DataSource = oCCOORIGENINCIDENCIA_BL.ListarCombo
            .DataTextField = "PropORIDESCRIPCION"
            .DataValueField = "PropORICODIGO"
        End With
        ddlOrigen.DataBind()
        ddlOrigen.Items.Insert(0, New ListItem("(Seleccionar)", ""))


        With ddlTipoPersona
            .DataSource = oCCOTIPOPERSONA_BL.ListarCombo
            .DataTextField = "PropTPEDESCRIPCION"
            .DataValueField = "PropTPECODIGO"
        End With
        ddlTipoPersona.DataBind()
        ddlTipoPersona.Items.Insert(0, New ListItem("(Seleccionar)", "0"))

        With ddlTipoInc
            .DataSource = oCCOTIPOINCIDENCIA_BL.ListarCombo
            .DataTextField = "PropTINDESCRIPCION"
            .DataValueField = "PropTINCODIGO"
        End With
        ddlTipoInc.DataBind()
        ddlTipoInc.Items.Insert(0, New ListItem("(Seleccionar)", "0"))


        oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = -1
        oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = 0
        With ddlSubTipoInc
            .DataSource = oCCOSUBTIPOINCIDENCIA_BL.ListarCombo(oCCOSUBTIPOINCIDENCIA_BE)
            .DataTextField = "PropSTIDESCRIPCION"
            .DataValueField = "PropSTICODIGO"
        End With
        ddlSubTipoInc.DataBind()
        ddlSubTipoInc.Items.Insert(0, New ListItem("(Seleccionar)", "0"))


        With ddlPrioridad
            .DataSource = oCCOPRIORIDADINCIDENCIA_BL.ListarCombo()
            .DataTextField = "PropPRIDESCRIPCION"
            .DataValueField = "PropPRICODIGO"
        End With
        ddlPrioridad.DataBind()
        ddlPrioridad.Items.Insert(0, New ListItem("(Seleccionar)", "0"))



        oCCOTABLA_BE.PropTTACODIGO = "TIPDOCIDENT"

        With ddlTipoDocInf
            .DataSource = oCCOTABLA_BL.Listar(oCCOTABLA_BE)
            .DataTextField = "DESCRIPCION"
            .DataValueField = "ID"
        End With
        ddlTipoDocInf.DataBind()
        ddlTipoDocInf.Items.Insert(0, New ListItem("(Todos)", "0"))

        oCCOTABLA_BE = New CCOTABLA_BE
        oCCOTABLA_BE.PropTTACODIGO = "ACCION_OPERADOR"
        With ddlAccionOperador
            .DataSource = oCCOTABLA_BL.Listar(oCCOTABLA_BE)
            .DataTextField = "DESCRIPCION"
            .DataValueField = "ID"
        End With
        ddlAccionOperador.DataBind()
        ddlAccionOperador.Items.Insert(0, New ListItem("(Seleccionar)", "0"))

        With ddlDerivarGrupo
            .DataSource = oSCUROL_BL.ListarComboDeriva(0)
            .DataTextField = "VCHROLDESCRIP"
            .DataValueField = "INTROLCODIGO"
        End With
        ddlDerivarGrupo.DataBind()
        ddlDerivarGrupo.Items.Insert(0, New ListItem("(Ninguno)", "0"))




        'Dim lstSYSCATASTRO_BE As New List(Of SYSCATASTRO_BE)
        'lstSYSCATASTRO_BE = oSYSCATASTRO_BL.consultComboVias()

    End Sub
    Protected Sub ddlTipoInc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipoInc.SelectedIndexChanged
        CargaTipoInc()
    End Sub
    Protected Sub ddlSubTipoInc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubTipoInc.SelectedIndexChanged
        CargaSubTipoInc()
    End Sub
    Protected Sub chkAnonimo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAnonimo.CheckedChanged
        'ddlTipoPersona.Visible = Not chkAnonimo.Checked
        txtNombre.Visible = Not chkAnonimo.Checked
        ddlTipoDocInf.Visible = Not chkAnonimo.Checked
        txtNumDocInf.Visible = Not chkAnonimo.Checked

        'lblPersona.Visible = Not chkAnonimo.Checked
        lblNombre.Visible = Not chkAnonimo.Checked
        lblTipoDoc.Visible = Not chkAnonimo.Checked
        lblNroDoc.Visible = Not chkAnonimo.Checked
        'pnlPersonas.Visible = Not chkAnonimo.Checked
    End Sub

    Public Sub ActivaControles(ByVal pboolEstado As Boolean)

        '--Origen
        ddlOrigen.Enabled = pboolEstado
        txtNumero.Enabled = pboolEstado
        txtPrevias.Enabled = pboolEstado
        txtFechaInc.Enabled = False

        '--Incidente
        txtViaInc.Enabled = pboolEstado
        txtNroInc.Enabled = pboolEstado
        'txtUrbInc.Enabled = pboolEstado
        txtIntInc.Enabled = pboolEstado
        txtComInc.Enabled = pboolEstado
        txtDptoInc.Enabled = pboolEstado
        'txtSector.Enabled = pboolEstado
        'txtCuadrante.Enabled = pboolEstado

        '--Informante
        ddlTipoPersona.Enabled = pboolEstado
        chkAnonimo.Enabled = pboolEstado
        txtNombre.Enabled = pboolEstado
        ddlTipoDocInf.Enabled = pboolEstado
        txtNumDocInf.Enabled = pboolEstado

        '--Relato
        txtRelato.Enabled = pboolEstado

        '--Tipificación
        ddlTipoInc.Enabled = pboolEstado
        ddlSubTipoInc.Enabled = pboolEstado
        ddlPrioridad.Enabled = pboolEstado

        '----------Derivacion
        ddlDerivarGrupo.Enabled = pboolEstado
        ddlAccionOperador.Enabled = pboolEstado
        '--Botonera
        'btnMap.Visible = pboolEstado
        'btnLlam.Visible = pboolEstado
        btnGrabar.Enabled = pboolEstado
        btnGrabar.Visible = pboolEstado
    End Sub
    Protected Sub cargaDatos()



        '-- Datos Incidencia
        oINC = New CCOINCIDENCIA_BE
        oINC.PropINCCODIGO = CType(ViewState("pID"), Integer)
        oINC.PropINCNUMEROORIGEN = txtNumero.Text
        oINC.PropINCLOCVIACODIGO1 = hfViaInc.Value.ToString.Trim.ToUpper
        oINC.PropINCLOCVIANOMBRE1 = txtViaInc.Text.ToString.Trim.ToUpper
        oINC.PropINCLOCVIACODIGO2 = hfIntInc.Value.ToString.Trim.ToUpper
        oINC.PropINCLOCVIANOMBRE2 = txtIntInc.Text.ToString.Trim.ToUpper

        oINC.PropINCLOCNUMERO = txtNroInc.Text.ToString.Trim.ToUpper
        oINC.PropINCLOCCUADRA = txtCdraInc.Text.ToString.Trim.ToUpper
        oINC.PropINCLOCMANZANA = txtMzaInc.Text.ToString.Trim.ToUpper
        oINC.PropINCLOCLOTE = txtLteInc.Text.ToString.Trim.ToUpper
        oINC.PropINCLOCDPTO = txtDptoInc.Text.ToString.Trim.ToUpper
        oINC.PropINCLOCHABCODIGO = hfUrbInc.Value.ToString.Trim.ToUpper
        oINC.PropINCLOCHABNOMBRE = txtUrbInc.Text.ToString.Trim.ToUpper
        oINC.PropINCLOCCOMENTARIO = txtComInc.Text.ToString.Trim.ToUpper


        oINC.PropINCFECHA = DateTime.Parse(txtFechaInc.Text)

        If chkAnonimo.Checked Then
            oINC.PropINCANONIMO = 1
            oINC.PropADMCODIGO = Nothing
            oINC.PropINCNOMBRECOMP = Nothing
            oINC.PropTIDCODIGO = Nothing
            oINC.PropINCDOCUMENTO = Nothing
        Else
            oINC.PropINCANONIMO = 0
            If hfNombreLlam.Value IsNot Nothing AndAlso hfNombreLlam.Value <> "" Then
                oINC.PropADMCODIGO = Integer.Parse(hfNombreLlam.Value)
            End If
            oINC.PropINCNOMBRECOMP = txtNombre.Text.ToString.Trim.ToUpper
            oINC.PropTIDCODIGO = ddlTipoDocInf.SelectedValue.ToUpper
            oINC.PropINCDOCUMENTO = txtNumDocInf.Text.ToString.Trim.ToUpper
        End If

        oINC.PropPRECODIGO = Nothing
        oINC.PropINCIDLATITUDE = hfGeoLat.Value.ToString.Trim
        oINC.PropINCIDLONGITUDE = hfGeoLon.Value.ToString.Trim

        oINC.PropCATCODIGO = txtCodCat.Text
        oINC.PropVCHINCLOCCUADRANTE = txtCuadrante.Text.Trim
        oINC.PropVCHINCLOCSECTOR = txtSector.Text.Trim
        oINC.PropINCLOCXGEO = hfGeoX.Value.ToString.Trim
        oINC.PropINCLOCYGEO = hfGeoY.Value.ToString.Trim

        '--- Datos Georeferencia Inversa
        'oINC.PropVCHINCLOCCUADRANTE = oL_BE.nCuadrante
        'oINC.PropVCHINCLOCSECTOR = oL_BE.nSector
        'oINC.PropINCLOCVIANOMBRE1 = oL_BE.nVia
        'oINC.PropINCLOCHABNOMBRE = oL_BE.nHabilita
        'oINC.PropINCLOCXGEO = oL_BE.xGeo
        'oINC.PropINCLOCYGEO = oL_BE.yGeo

        oINC.PropORICODIGO = ddlOrigen.SelectedValue
        oINC.PropTINCODIGO = ddlTipoInc.SelectedValue
        oINC.PropSTICODIGO = ddlSubTipoInc.SelectedValue
        oINC.PropPRICODIGO = ddlPrioridad.SelectedValue
        oINC.PropTPECODIGO = ddlTipoPersona.SelectedValue

        '-- asociacion de incidencia
        oINC.PropINCACODIGO = Nothing
        oINC.PropINCANUMERO = Nothing
        oINC.PropINCRELATO = txtRelato.Text.ToString.Trim.ToUpper

        If txtRelato.Text.ToString.Trim.ToUpper.Length > 300 Then
            oINC.PropINCRELATO = txtRelato.Text.ToString.Trim.ToUpper.Substring(1, 300)
        End If

        'oINC.PropAUDROLCREACION = CType(Session("Rol"), Integer)
        oINC.PropAUDROLCREACION = RolSADE.TELEFONISTA
        oINC.PropINCESTADO = ddlAccionOperador.SelectedValue

        If ddlAccionOperador.SelectedValue = 150 Then   '--TERMINAR ATECION
            oINC.PropINCESTADO = Estado.Atendido
            oINC.PropAUDROLMODIF = RolSADE.SUPERVISOR_CCO
        ElseIf ddlAccionOperador.SelectedValue = 151 Then   '--DERIVAR ATENCION
            oINC.PropINCESTADO = Estado.ParaDespacho
            oINC.PropAUDROLMODIF = ddlDerivarGrupo.SelectedValue
        ElseIf ddlAccionOperador.SelectedValue = 152 Then   '--DESCARTAR INCIDENCIA 
            oINC.PropINCESTADO = Estado.Descartado
            oINC.PropAUDROLMODIF = RolSADE.SUPERVISOR_CCO
        End If
        oINC.PropRESCODIGO = ddlDerivarGrupo.SelectedValue  '-- resultado incidencia

        oINC.PropINCRESULTADO = Nothing '-- resultado atencion


        '-- creacion incidencia
        oINC.PropAUDPRGCREACION = CType(Session("proyecto"), String)
        oINC.PropAUDEQPCREACION = CType(Session("equipo"), String)
        oINC.PropAUDFECCREACION = Now.Date
        oINC.PropAUDUSUCREACION = CType(Session("Usuario"), String)   '--Session("user")
        '=-- modificacion incidencia
        oINC.PropAUDPRGMODIF = CType(Session("proyecto"), String)
        oINC.PropAUDEQPMODIF = CType(Session("equipo"), String)
        oINC.PropAUDFECMODIF = Now.Date
        oINC.PropAUDUSUMODIF = CType(Session("Usuario"), String)   '--Session("user")

    End Sub
    Public Sub CargaDatosControl()

        txtNroIncidente.Text = oINC.PropINCCODIGO
        'lblAnexo.Text = CType(ViewState("pAnexo"), String)


        ddlOrigen.SelectedValue = oINC.PropORICODIGO
        txtNumero.Text = oINC.PropINCNUMEROORIGEN

        txtFechaInc.Text = String.Format("{0:G}", oINC.PropINCFECHA)

        hfViaInc.Value = oINC.PropINCLOCVIACODIGO1
        txtViaInc.Text = oINC.PropINCLOCVIANOMBRE1
        hfIntInc.Value = oINC.PropINCLOCVIACODIGO2
        txtIntInc.Text = oINC.PropINCLOCVIANOMBRE2

        txtNroInc.Text = oINC.PropINCLOCNUMERO
        txtCdraInc.Text = oINC.PropINCLOCCUADRA
        txtLteInc.Text = oINC.PropINCLOCLOTE
        txtMzaInc.Text = oINC.PropINCLOCMANZANA
        txtDptoInc.Text = oINC.PropINCLOCDPTO

        hfUrbInc.Value = oINC.PropINCLOCHABCODIGO
        txtUrbInc.Text = oINC.PropINCLOCHABNOMBRE
        txtComInc.Text = oINC.PropINCLOCCOMENTARIO
        txtSector.Text = oINC.PropVCHINCLOCSECTOR
        txtCuadrante.Text = oINC.PropVCHINCLOCCUADRANTE

        hfGeoX.Value = oINC.PropINCLOCXGEO
        hfGeoY.Value = oINC.PropINCLOCYGEO



        '--oINC.PropINCLOCSECTOR = Nothing
        '--oINC.PropINCLOCCUADRANTE = Nothing
        If Not (oINC.PropTPECODIGO Is Nothing) Then
            ddlTipoPersona.SelectedValue = oINC.PropTPECODIGO
        End If
        If oINC.PropINCANONIMO = 1 Then
            hfNombreLlam.Value = 0
            txtNombre.Text = ""
            ddlTipoDocInf.SelectedValue = 0
            txtNumDocInf.Text = ""
            chkAnonimo.Checked = True
        Else
            hfNombreLlam.Value = IIf(oINC.PropADMCODIGO Is Nothing, "", oINC.PropADMCODIGO)
            txtNombre.Text = IIf(oINC.PropINCNOMBRECOMP Is Nothing, "", oINC.PropINCNOMBRECOMP)
            ddlTipoDocInf.SelectedValue = IIf(oINC.PropTIDCODIGO Is Nothing, -1, oINC.PropTIDCODIGO)
            txtNumDocInf.Text = IIf(oINC.PropINCDOCUMENTO Is Nothing, "", oINC.PropINCDOCUMENTO)
            chkAnonimo.Checked = False
        End If
        txtRelato.Text = oINC.PropINCRELATO
        ddlTipoInc.SelectedValue = IIf(oINC.PropTINCODIGO Is Nothing, -1, oINC.PropTINCODIGO)
        CargaTipoInc()
        ddlSubTipoInc.SelectedValue = IIf(oINC.PropSTICODIGO Is Nothing, -1, oINC.PropSTICODIGO)
        ddlPrioridad.SelectedValue = IIf(oINC.PropPRICODIGO Is Nothing, -1, oINC.PropPRICODIGO)
        CargaSubTipoInc()

        If oINC.PropINCESTADO IsNot Nothing Then
            ddlAccionOperador.SelectedValue = oINC.PropINCESTADO
        End If
        If oINC.PropAUDROLMODIF IsNot Nothing Then
            ddlDerivarGrupo.SelectedValue = oINC.PropAUDROLMODIF
        End If

        chkAnonimo_CheckedChanged(chkAnonimo, Nothing)

    End Sub

    Protected Sub CargaTipoInc()
        Dim oCCOTIPOINCIDENCIA_BE As New CCOTIPOINCIDENCIA_BE
        Dim oCCOTIPOINCIDENCIA_BL As New CCOTIPOINCIDENCIA_BL
        Dim oCCOSUBTIPOINCIDENCIA_BE As New CCOSUBTIPOINCIDENCIA_BE
        Dim oCCOSUBTIPOINCIDENCIA_BL As New CCOSUBTIPOINCIDENCIA_BL
        oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = 0
        oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = ddlTipoInc.SelectedValue
        With ddlSubTipoInc
            .DataSource = oCCOSUBTIPOINCIDENCIA_BL.ListarCombo(oCCOSUBTIPOINCIDENCIA_BE)
            .DataTextField = "PropSTIDESCRIPCION"
            .DataValueField = "PropSTICODIGO"
        End With
        ddlSubTipoInc.DataBind()
        ddlSubTipoInc.Items.Insert(0, New ListItem("(Seleccionar)", "0"))
    End Sub

    Protected Sub CargaSubTipoInc()
        If ddlSubTipoInc.SelectedValue > 0 Then
            Dim oCCOSUBTIPOINCIDENCIA_BE As New CCOSUBTIPOINCIDENCIA_BE
            Dim oCCOSUBTIPOINCIDENCIA_BL As New CCOSUBTIPOINCIDENCIA_BL
            oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = ddlSubTipoInc.SelectedValue
            oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = ddlTipoInc.SelectedValue
            oCCOSUBTIPOINCIDENCIA_BE = oCCOSUBTIPOINCIDENCIA_BL.Listarkey(oCCOSUBTIPOINCIDENCIA_BE)
            'txtConsejo.Text = oCCOSUBTIPOINCIDENCIA_BE.PropSTICONSEJO
            If oCCOSUBTIPOINCIDENCIA_BE.PropPRICODIGO IsNot Nothing Then
                ddlPrioridad.SelectedValue = oCCOSUBTIPOINCIDENCIA_BE.PropPRICODIGO
            End If
        End If
    End Sub

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Try
            lblMensaje.Text = ""
            oINC_BL = New CCOINCIDENCIA_BL
            cargaDatos()
            If oINC.PropINCCODIGO > 0 Then
                oINC_BL.ActualizarOperador(oINC)
                ActivaControles(False)
            Else
                Dim result As Integer = oINC_BL.InsertarOperador(oINC)
                ViewState("pID") = result
                txtNroIncidente.Text = result
                ActivaControles(False)
            End If

            'Dim sb As New StringBuilder
            'sb.AppendLine("window.close();")
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Private Sub MostrarPopup(ByVal pdiv As String)
        Dim sb As New StringBuilder

        sb.AppendLine("javascript:void(0);")
        sb.AppendLine("document.getElementById('" & pdiv & "').style.display='block';document.getElementById('fade').style.display='block';")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub

    Private Sub MostrarMapa(ByVal pdiv As String)
        Dim sb As New StringBuilder

        sb.AppendLine("javascript:void(0); initialize(); ")
        sb.AppendLine("document.getElementById('" & pdiv & "').style.display='block';document.getElementById('fade').style.display='block';")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub

    Private Sub CerrarPopup(ByVal pdiv As String)
        Dim sb As New StringBuilder
        sb.AppendLine("javascript:void(0);")
        sb.AppendLine("document.getElementById('" & pdiv & "').style.display='none';document.getElementById('fade').style.display='none';")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub

    'Protected Sub btnCancelar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar2.Click
    '    Dim oSYS_BL As SYSESTACION_BL = New SYSESTACION_BL
    '    Dim sb As New StringBuilder
    '    sb.AppendLine("window.close();")
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    'End Sub

    Protected Sub ddlAccionOperador_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAccionOperador.SelectedIndexChanged
        If ddlAccionOperador.SelectedValue = 150 Or ddlAccionOperador.SelectedValue = 152 Then
            With ddlDerivarGrupo
                .DataSource = oSCUROL_BL.ListarComboDeriva(0)
                .DataTextField = "VCHROLDESCRIP"
                .DataValueField = "INTROLCODIGO"
            End With
            ddlDerivarGrupo.DataBind()
            ddlDerivarGrupo.Items.Insert(0, New ListItem("(Ninguno)", "0"))
            ddlDerivarGrupo.SelectedValue = RolSADE.SUPERVISOR_CCO
            ddlDerivarGrupo.Enabled = False
        Else

            With ddlDerivarGrupo
                .DataSource = oSCUROL_BL.ListarComboDeriva(1)
                .DataTextField = "VCHROLDESCRIP"
                .DataValueField = "INTROLCODIGO"
            End With
            ddlDerivarGrupo.DataBind()
            ddlDerivarGrupo.Items.Insert(0, New ListItem("(Ninguno)", "0"))
            ddlDerivarGrupo.SelectedIndex = -1
            ddlDerivarGrupo.Enabled = True
        End If
    End Sub

End Class
