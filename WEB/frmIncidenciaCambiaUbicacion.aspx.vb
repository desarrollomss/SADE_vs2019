Imports System.Data
Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Collections.Generic

Partial Class frmIncidenciaCambiaUbicacion
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

        btnGrabar.Attributes.Add("onclick", "javascript:return ValidarFinalAtencion();")

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



    End Sub

    Public Sub CargaDatosControl(ByVal oINC As CCOINCIDENCIA_BE)

        txtNumeroInc.Text = oINC.PropINCCODIGO

        ddlOrigenInc.SelectedValue = oINC.PropORICODIGO

        If oINC.PropTINCODIGO Is Nothing Then
            oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = 0
        Else
            oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = oINC.PropTINCODIGO
        End If
        ddlTipoPersona.SelectedValue = IIf(oINC.PropTPECODIGO Is Nothing, 0, oINC.PropTPECODIGO)

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

        'txtRelato.Text = oINC.PropINCRELATO





    End Sub


    Protected Sub cargaDatos()

        oCCOINCIDENCIA_BE.PropINCCODIGO = CType(ViewState("pID"), Integer)

        oCCOINCIDENCIA_BE.PropINCESTADO = Estado.Atencion


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




    Public Sub ActivaControles(ByVal pboolEstado As Boolean)
        '-- Botonera
        btnGrabar.Visible = pboolEstado

    End Sub


    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

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


End Class
