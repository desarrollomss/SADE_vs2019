Imports System.Data
Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Collections.Generic

Partial Class frmIncidenciaAtender
    Inherits System.Web.UI.Page

    Enum Estado
        Abierto = 7
        Derivado = 8
        Recepcionado = 9
        Despachado = 10
        Atencion = 11
        Cerrado = 12
    End Enum


    Dim oCCOTIPOINCIDENCIA_BE As New CCOTIPOINCIDENCIA_BE
    Dim oCCOTIPOINCIDENCIA_BL As New CCOTIPOINCIDENCIA_BL
    Dim oCCOSUBTIPOINCIDENCIA_BE As New CCOSUBTIPOINCIDENCIA_BE
    Dim oCCOSUBTIPOINCIDENCIA_BL As New CCOSUBTIPOINCIDENCIA_BL
    Dim oCCOINCIDENCIAPAQUETE_BL As New CCOINCIDENCIAPAQUETE_BL
    Dim oCCORECURSO_BL As New CCORECURSO_BL
    Dim oCCORECURSO_BE As New CCORECURSO_BE
    Dim oCCOINCIDENCIARECURSO_BE As New CCOINCIDENCIARECURSO_BE
    Dim oCCOINCIDENCIARECURSO_BL As New CCOINCIDENCIARECURSO_BL
    Dim oCCOINCIDENCIAINTERACCION_BE As New CCOINCIDENCIAINTERACCION_BE
    Dim oCCOINCIDENCIAINTERACCION_BL As New CCOINCIDENCIAINTERACCION_BL
    Dim oCCOINCIDENCIA_BE As New CCOINCIDENCIA_BE
    Dim oCCOINCIDENCIA_BL As New CCOINCIDENCIA_BL
    Dim intRecursoLLega As Integer = 0


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        btnAsignaRec.Attributes.Add("onclick", "javascript:return ValidarRecurso();")
        btnRecursoDice.Attributes.Add("onclick", "javascript:return ValidarInteraccion();")

        btnGrabar.Attributes.Add("onclick", "javascript:return ValidarFinalAtencion();")

        txtCantInterviene.Attributes.Add("onkeypress", "javascript:return solonumeros(event);")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            Dim mp As MasterPage = Me.Master
            'Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            'tit.Text = "Atención de Incidencia"
            Session("activo") = "1"
            Session("opcion") = "1.2"
            LlenarCombos()

            ViewState("pID") = Request.QueryString("pID")
            'ViewState("pID") = 10
            ViewState("pModo") = Request.QueryString("pModo")
            ViewState("pAnexo") = "510"

            If CType(ViewState("pID"), Integer) > 0 Then
                Dim oINC As New CCOINCIDENCIA_BE
                Dim oINC_BL As New CCOINCIDENCIA_BL
                oINC.PropINCCODIGO = CType(ViewState("pID"), Integer)
                oINC = oINC_BL.ListarKey(oINC)
                CargaDatosControl(oINC)
                CargaGrillaRecursoAsignado()
                CargaGrillaInteraccion()
                iniAsignaRecurso()
                iniInteraccion()
            End If

            If ViewState("pModo") = "VISUALIZAR" Then
                ActivaControles(False)
            End If
            If ViewState("pModo") = "NUEVO" Then
                ActivaControles(True)
            End If

            If ViewState("pModo") = "MODIFICAR" Then
                ActivaControles(True)
            End If


        End If
    End Sub

    Public Sub iniAsignaRecurso()
        'txtHorAsigna.Text = String.Format("{0:G}", DateTime.Now)
        ddlTipoRecurso.SelectedIndex = -1
        ddlRecurso.SelectedIndex = -1
        txtRespRecurso.Text = ""
    End Sub

    Public Sub LlenarCombos()
        Dim lstOrigenIncidencia As New List(Of CCOORIGENINCIDENCIA_BE)

        Dim oCCOSUBTIPOINCIDENCIA_BE As New CCOSUBTIPOINCIDENCIA_BE
        Dim oCCOORIGENINCIDENCIA_BL As New CCOORIGENINCIDENCIA_BL
        Dim oCCOTIPOINCIDENCIA_BL As New CCOTIPOINCIDENCIA_BL
        Dim oCCOTIPOPERSONA_BL As New CCOTIPOPERSONA_BL
        Dim oCCOSUBTIPOINCIDENCIA_BL As New CCOSUBTIPOINCIDENCIA_BL
        Dim oCCOPRIORIDADINCIDENCIA_BL As New CCOPRIORIDADINCIDENCIA_BL
        Dim oCCOTIPORECURSO_BL As New CCOTIPORECURSO_BL
        Dim oSYSCATASTRO_BL As New SYSCATASTRO_BL
        Dim oCCOTABLA_BE As New CCOTABLA_BE
        Dim oCCOTABLA_BL As New CCOTABLA_BL

        With ddlOrigenInc
            .DataSource = oCCOORIGENINCIDENCIA_BL.ListarCombo
            .DataTextField = "PropORIDESCRIPCION"
            .DataValueField = "PropORICODIGO"
        End With
        ddlOrigenInc.DataBind()
        ddlOrigenInc.Items.Insert(0, New ListItem("(Seleccionar)", ""))

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

        oCCOTABLA_BE.PropTTACODIGO = "ESTADOINCIDENCIA"

        'With ddlEstadoInc
        '    .DataSource = oCCOTABLA_BL.Listar(oCCOTABLA_BE)
        '    .DataTextField = "DESCRIPCION"
        '    .DataValueField = "ID"
        'End With
        'ddlEstadoInc.DataBind()
        'ddlEstadoInc.Items.Insert(0, New ListItem("(Todos)", "0"))

        '-- TIPO RECURSO
        With ddlTipoRecurso
            .DataSource = oCCOTIPORECURSO_BL.ListarCombo
            .DataTextField = "PropTREDESCRIPCION"
            .DataValueField = "PropTRECODIGO"
        End With
        ddlTipoRecurso.DataBind()
        ddlTipoRecurso.Items.Insert(0, New ListItem("(Seleccionar)", "0"))
        '-- RECURSO
        oCCORECURSO_BE.PropRECCODIGO = 0
        oCCORECURSO_BE.PropTRECODIGO = 0
        oCCORECURSO_BE.PropRECMODELO = ""
        With ddlRecurso
            .DataSource = oCCORECURSO_BL.ListarxTipo(oCCORECURSO_BE)
            .DataTextField = "VCHRECCODIGOALTERNO"
            .DataValueField = "INTRECCODIGO"
        End With
        ddlRecurso.DataBind()
        ddlRecurso.Items.Insert(0, New ListItem("(Seleccionar)", ""))

    End Sub

    Public Sub CargaDatosControl(ByVal oINC As CCOINCIDENCIA_BE)

        txtNumeroInc.Text = oINC.PropINCCODIGO

        ddlOrigenInc.SelectedValue = oINC.PropORICODIGO
        If oINC.PropTINCODIGO Is Nothing Then
            ddlTipoInc.SelectedValue = 0
        Else
            ddlTipoInc.SelectedValue = oINC.PropTINCODIGO
        End If
        'carga subtipo segun tipo
        oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = 0

        If oINC.PropTINCODIGO Is Nothing Then
            oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = 0
        Else
            oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = oINC.PropTINCODIGO
        End If
        With ddlSubTipoInc
            .DataSource = oCCOSUBTIPOINCIDENCIA_BL.ListarCombo(oCCOSUBTIPOINCIDENCIA_BE)
            .DataTextField = "PropSTIDESCRIPCION"
            .DataValueField = "PropSTICODIGO"
        End With
        ddlSubTipoInc.DataBind()
        ddlSubTipoInc.Items.Insert(0, New ListItem("(Seleccionar)", "0"))

        ddlTipoPersona.SelectedValue = IIf(oINC.PropTPECODIGO Is Nothing, 0, oINC.PropTPECODIGO)
        ddlSubTipoInc.SelectedValue = IIf(oINC.PropSTICODIGO Is Nothing, 0, oINC.PropSTICODIGO)
        ddlPrioridad.SelectedValue = IIf(oINC.PropPRICODIGO Is Nothing, 0, oINC.PropPRICODIGO)

        If Not (oINC.PropINCACODIGO Is Nothing) Then
            txtIncAsociados.Text = oINC.PropINCACODIGO
        End If

        txtFechaInc.Text = String.Format("{0:G}", oINC.PropINCFECHA)
        ''oINC.PropINCFECHA.ToShortDateString(+" " + oINC.PropINCFECHA.ToShortTimeString)
        hfGeoX.Value = oINC.PropINCLOCXGEO
        hfGeoY.Value = oINC.PropINCLOCYGEO

        txtNombre.Text = oINC.PropINCNOMBRECOMP
        txtNumero.Text = oINC.PropINCNUMEROORIGEN

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

        txtRelato.Text = oINC.PropINCRELATO

        txtResultadoINC.Text = oINC.PropINCRESULTADO

        'tiene parte policial
        If oINC.PropINCPARTEPOLICIAL Is Nothing Then
            chkPartePolicial.Checked = False
        Else
            chkPartePolicial.Checked = oINC.PropINCPARTEPOLICIAL
        End If

        'tiene parte interno
        If oINC.PropPINCODIGO Is Nothing Then
            chkParteInterno.Checked = False
        Else
            chkParteInterno.Checked = oINC.PropPINCODIGO
        End If

        'numero de intervenidos
        If oINC.PropINCINTERVENIDOS Is Nothing Then
            txtCantInterviene.Text = ""
        Else
            txtCantInterviene.Text = oINC.PropINCINTERVENIDOS
        End If

    End Sub


    Protected Sub cargaDatos()

        oCCOINCIDENCIA_BE.PropINCCODIGO = CType(ViewState("pID"), Integer)
        oCCOINCIDENCIA_BE.PropINCRESULTADO = txtResultadoINC.Text.ToUpper

        If txtCantInterviene.Text <> "" Then
            oCCOINCIDENCIA_BE.PropINCINTERVENIDOS = txtCantInterviene.Text
        Else
            oCCOINCIDENCIA_BE.PropINCINTERVENIDOS = Nothing
        End If

        If chkPartePolicial.Checked Then
            oCCOINCIDENCIA_BE.PropINCPARTEPOLICIAL = 1
        Else
            oCCOINCIDENCIA_BE.PropINCPARTEPOLICIAL = 0
        End If

        If chkParteInterno.Checked Then
            oCCOINCIDENCIA_BE.PropPINCODIGO = 1
        Else
            oCCOINCIDENCIA_BE.PropPINCODIGO = Nothing
        End If

        oCCOINCIDENCIA_BE.PropINCESTADO = Estado.Atencion

        oCCOINCIDENCIA_BE.PropTINCODIGO = ddlTipoInc.SelectedValue
        oCCOINCIDENCIA_BE.PropSTICODIGO = ddlSubTipoInc.SelectedValue
        oCCOINCIDENCIA_BE.PropPRICODIGO = ddlPrioridad.SelectedValue
        '-- agregado y modificado
        oCCOINCIDENCIA_BE.PropORICODIGO = ddlOrigenInc.SelectedValue

        '-- historial incidencia
        oCCOINCIDENCIA_BE.PropAUDROLCREACION = CType(Session("Rol"), Integer)
        oCCOINCIDENCIA_BE.PropAUDROLMODIF = CType(Session("Rol"), Integer)
        '-- creacion incidencia
        oCCOINCIDENCIA_BE.PropAUDPRGCREACION = CType(Session("proyecto"), String)
        oCCOINCIDENCIA_BE.PropAUDEQPCREACION = CType(Session("equipo"), String)
        oCCOINCIDENCIA_BE.PropAUDFECCREACION = Now.Date
        oCCOINCIDENCIA_BE.PropAUDUSUCREACION = CType(Session("Usuario"), String)   '--Session("user")
        '=-- modificacion incidencia
        oCCOINCIDENCIA_BE.PropAUDPRGMODIF = CType(Session("proyecto"), String)
        oCCOINCIDENCIA_BE.PropAUDEQPMODIF = CType(Session("equipo"), String)
        oCCOINCIDENCIA_BE.PropAUDFECMODIF = Now.Date
        oCCOINCIDENCIA_BE.PropAUDUSUMODIF = CType(Session("Usuario"), String)   '--Session("user")

    End Sub

    Protected Sub ddlTipoRecurso_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipoRecurso.SelectedIndexChanged
        oCCORECURSO_BE.PropRECCODIGO = 0
        oCCORECURSO_BE.PropTRECODIGO = ddlTipoRecurso.SelectedValue
        oCCORECURSO_BE.PropRECMODELO = ""
        With ddlRecurso
            .DataSource = oCCORECURSO_BL.ListarxTipo(oCCORECURSO_BE)
            .DataTextField = "VCHRECCODIGOALTERNO"
            .DataValueField = "INTRECCODIGO"
        End With
        ddlRecurso.DataBind()
        ddlRecurso.Items.Insert(0, New ListItem("(Seleccionar)", ""))
    End Sub

    Protected Sub btnHoraLlegada_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim grdrow As GridViewRow = CType((CType(sender, Button)).NamingContainer, GridViewRow)
        Dim rowNumber As String = grdrow.Cells(0).Text

        Try
            oCCOINCIDENCIARECURSO_BE.PropINCRCODIGO = rowNumber
            oCCOINCIDENCIARECURSO_BE.PropAUDPRGMODIF = CType(Session("proyecto"), String)
            oCCOINCIDENCIARECURSO_BE.PropAUDEQPMODIF = CType(Session("equipo"), String)
            oCCOINCIDENCIARECURSO_BE.PropAUDFECMODIF = Now.Date
            oCCOINCIDENCIARECURSO_BE.PropAUDUSUMODIF = CType(Session("Usuario"), String)   '--Session("user")
            oCCOINCIDENCIARECURSO_BE.PropAUDROLMODIF = CType(Session("Rol"), Integer)
            oCCOINCIDENCIARECURSO_BL.ActualizaLlegada(oCCOINCIDENCIARECURSO_BE)
            CargaGrillaRecursoAsignado()
            iniAsignaRecurso()
        Catch ex As Exception
            lblMensaje.Text = ex.Message.ToString
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub btnAsignaRec_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAsignaRec.Click
        Dim txtHorAsigna As String = String.Format("{0:G}", DateTime.Now)
        Try
            oCCOINCIDENCIARECURSO_BE.PropINCCODIGO = txtNumeroInc.Text
            oCCOINCIDENCIARECURSO_BE.PropINCRASIGNA = DateTime.Parse(txtHorAsigna)
            oCCOINCIDENCIARECURSO_BE.PropTRECODIGO = ddlTipoRecurso.SelectedValue
            oCCOINCIDENCIARECURSO_BE.PropRECCODIGO = ddlRecurso.SelectedValue
            oCCOINCIDENCIARECURSO_BE.PropRECPERSONAL = txtRespRecurso.Text.ToUpper
            oCCOINCIDENCIARECURSO_BE.PropAUDPRGCREACION = CType(Session("proyecto"), String)
            oCCOINCIDENCIARECURSO_BE.PropAUDEQPCREACION = CType(Session("equipo"), String)
            oCCOINCIDENCIARECURSO_BE.PropAUDFECCREACION = Now.Date
            oCCOINCIDENCIARECURSO_BE.PropAUDUSUCREACION = CType(Session("Usuario"), String)   '--Session("user")
            oCCOINCIDENCIARECURSO_BE.PropAUDROLCREACION = CType(Session("Rol"), Integer)
            oCCOINCIDENCIARECURSO_BL.Insertar(oCCOINCIDENCIARECURSO_BE)
            CargaGrillaRecursoAsignado()
            iniAsignaRecurso()
        Catch ex As Exception
            lblMensaje.Text = ex.Message.ToString
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try


    End Sub

    Public Sub CargaGrillaRecursoAsignado()

        Dim intIncNumero As Integer = CType(txtNumeroInc.Text, Integer)
        gvRecursos.DataSource = oCCOINCIDENCIARECURSO_BL.Listar(intIncNumero)
        gvRecursos.DataBind()

    End Sub

    Protected Sub gvRecursos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvRecursos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dk As System.Web.UI.WebControls.DataKey = gvRecursos.DataKeys(e.Row.RowIndex)
            Dim estado As String = dk.Item("DTMINCRLLEGA")
            Dim btnBorraRecurso As Button = CType(e.Row.FindControl("btnBorraRecurso"), Button)
            Dim btnHoraLlegada As Button = CType(e.Row.FindControl("btnHoraLlegada"), Button)
            Dim lblHoraLlegada As Label = CType(e.Row.FindControl("lblHoraLlegada"), Label)

            If estado = "" Then
                btnHoraLlegada.Visible = True
                lblHoraLlegada.Visible = False
                btnBorraRecurso.Visible = True
            Else
                btnHoraLlegada.Visible = False
                lblHoraLlegada.Visible = True
                btnBorraRecurso.Visible = False
            End If
        End If

    End Sub

    Protected Sub btnRecursoDice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecursoDice.Click
        Dim txtHorAsigna As String = String.Format("{0:G}", DateTime.Now)
        Try
            oCCOINCIDENCIAINTERACCION_BE.PropINCCODIGO = txtNumeroInc.Text
            oCCOINCIDENCIAINTERACCION_BE.PropINCIHORA = DateTime.Parse(txtHorAsigna)
            oCCOINCIDENCIAINTERACCION_BE.PropINCIRELATO = txtRelatoInt.Text.ToUpper
            oCCOINCIDENCIAINTERACCION_BE.PropAUDPRGCREACION = CType(Session("proyecto"), String)
            oCCOINCIDENCIAINTERACCION_BE.PropAUDEQPCREACION = CType(Session("equipo"), String)
            oCCOINCIDENCIAINTERACCION_BE.PropAUDFECCREACION = Now.Date
            oCCOINCIDENCIAINTERACCION_BE.PropAUDUSUCREACION = CType(Session("Usuario"), String)   '--Session("user")
            oCCOINCIDENCIAINTERACCION_BE.PropAUDROLCREACION = CType(Session("Rol"), Integer)
            oCCOINCIDENCIAINTERACCION_BL.Insertar(oCCOINCIDENCIAINTERACCION_BE)
            CargaGrillaInteraccion()
            iniInteraccion()
        Catch ex As Exception
            lblMensaje.Text = ex.Message.ToString
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Public Sub CargaGrillaInteraccion()

        Dim intIncNumero As Integer = CType(txtNumeroInc.Text, Integer)
        gvInteractua.DataSource = oCCOINCIDENCIAINTERACCION_BL.Listar(intIncNumero)
        gvInteractua.DataBind()

    End Sub

    Public Sub iniInteraccion()
        'txtHorAsigna.Text = String.Format("{0:G}", DateTime.Now)
        txtRelatoInt.Text = ""
    End Sub

    Public Sub ActivaControles(ByVal pboolEstado As Boolean)
        '-- Botonera
        btnGrabar.Visible = pboolEstado
        btnAsignaRec.Visible = pboolEstado
        btnRecursoDice.Visible = pboolEstado
        gvRecursos.Enabled = pboolEstado
        chkParteInterno.Enabled = pboolEstado
        chkPartePolicial.Enabled = pboolEstado
        txtResultadoINC.Enabled = pboolEstado
        txtCantInterviene.Enabled = pboolEstado
        ddlTipoInc.Enabled = pboolEstado
        ddlSubTipoInc.Enabled = pboolEstado
        ddlPrioridad.Enabled = pboolEstado

    End Sub

    Protected Function valLlegadaRecurso() As Boolean
        Dim intIncNumero As Integer = CType(txtNumeroInc.Text, Integer)
        Dim bolLlego As Boolean = False
        Dim dt As New DataTable
        dt = oCCOINCIDENCIARECURSO_BL.Listar(intIncNumero)
        For Each r As DataRow In dt.Rows
            If r("DTMINCRLLEGA") <> "" Then
                bolLlego = True
            End If
        Next
        Return bolLlego
    End Function

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        If gvRecursos.Rows.Count <= 0 Then
            Util.MSG_ALERTA("No tiene recursos asignados a INCIDENCIA. Por lo tanto no puede Finalizar Atención!!!", Me)
            Exit Sub
        End If

        If Not valLlegadaRecurso() Then
            Util.MSG_ALERTA("Recursos asignados a INCIDENCIA no tienen Hora de Llegada. Por lo tanto no puede Finalizar Atención!!!", Me)
            Exit Sub

        End If
        Try
            lblMensaje.Text = ""
            cargaDatos()
            oCCOINCIDENCIA_BL.Finalizar_Atencion_Nuevo(oCCOINCIDENCIA_BE)
            ActivaControles(False)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            'Throw ex
        End Try

    End Sub

    Protected Sub ddlTipoInc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipoInc.SelectedIndexChanged
        CargaTipoInc()
    End Sub

    Protected Sub ddlPrioridad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPrioridad.SelectedIndexChanged
        CargaSubTipoInc()
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

    Protected Sub btnBorraRecurso_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim grdrow As GridViewRow = CType((CType(sender, Button)).NamingContainer, GridViewRow)
        Dim rowNumber As String = grdrow.Cells(0).Text

        Try
            oCCOINCIDENCIARECURSO_BE.PropINCRCODIGO = rowNumber
            oCCOINCIDENCIARECURSO_BE.PropAUDPRGMODIF = CType(Session("proyecto"), String)
            oCCOINCIDENCIARECURSO_BE.PropAUDEQPMODIF = CType(Session("equipo"), String)
            oCCOINCIDENCIARECURSO_BE.PropAUDFECMODIF = Now.Date
            oCCOINCIDENCIARECURSO_BE.PropAUDUSUMODIF = CType(Session("Usuario"), String)   '--Session("user")
            oCCOINCIDENCIARECURSO_BE.PropAUDROLMODIF = CType(Session("Rol"), Integer)
            oCCOINCIDENCIARECURSO_BL.Eliminar(oCCOINCIDENCIARECURSO_BE)
            CargaGrillaRecursoAsignado()
            iniAsignaRecurso()
        Catch ex As Exception
            lblMensaje.Text = ex.Message.ToString
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub


End Class
