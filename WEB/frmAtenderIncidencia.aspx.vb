Imports System.Data
Imports SISSADE.BE
Imports SISSADE.BL


Partial Class frmAtenderIncidencia
    Inherits System.Web.UI.Page
    'Estado de Incidencia: A=Abierto, D=Derivado (a OT, OD, S, E), R=Recepcionado, P=Despachado (con recurso asignado), T=En Atención, C=Cerrado
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

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        txtCantInterviene.Attributes.Add("onkeypress", "javascript:return solonumeros(event);")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = "Atención de Incidencia"
            Session("activo") = "1"
            Session("opcion") = "1.2"
            LlenarCombos()
            btnGrabar.Attributes.Add("onclick", "javascript:return ValidarGrabar();")
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

        End If
    End Sub

    Public Sub LlenarCombos()
        Dim lstOrigenIncidencia As New List(Of CCOORIGENINCIDENCIA_BE)

        Dim oCCOSUBTIPOINCIDENCIA_BE As New CCOSUBTIPOINCIDENCIA_BE
        Dim oCCOORIGENINCIDENCIA_BL As New CCOORIGENINCIDENCIA_BL
        Dim oCCOTIPOINCIDENCIA_BL As New CCOTIPOINCIDENCIA_BL
        Dim oCCOSUBTIPOINCIDENCIA_BL As New CCOSUBTIPOINCIDENCIA_BL
        Dim oCCOPRIORIDADINCIDENCIA_BL As New CCOPRIORIDADINCIDENCIA_BL
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


        With ddlPrioridadInc
            .DataSource = oCCOPRIORIDADINCIDENCIA_BL.ListarCombo()
            .DataTextField = "PropPRIDESCRIPCION"
            .DataValueField = "PropPRICODIGO"
        End With
        ddlPrioridadInc.DataBind()
        ddlPrioridadInc.Items.Insert(0, New ListItem("(Seleccionar)", "0"))

        oCCOTABLA_BE.PropTTACODIGO = "ESTADOINCIDENCIA"

        With ddlEstadoInc
            .DataSource = oCCOTABLA_BL.Listar(oCCOTABLA_BE)
            .DataTextField = "DESCRIPCION"
            .DataValueField = "ID"
        End With
        ddlEstadoInc.DataBind()
        ddlEstadoInc.Items.Insert(0, New ListItem("(Todos)", "0"))

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
        With ddlSubtipoInc
            .DataSource = oCCOSUBTIPOINCIDENCIA_BL.ListarCombo(oCCOSUBTIPOINCIDENCIA_BE)
            .DataTextField = "PropSTIDESCRIPCION"
            .DataValueField = "PropSTICODIGO"
        End With
        ddlSubtipoInc.DataBind()
        ddlSubtipoInc.Items.Insert(0, New ListItem("(Seleccionar)", "0"))

        ddlSubtipoInc.SelectedValue = IIf(oINC.PropSTICODIGO Is Nothing, 0, oINC.PropSTICODIGO)
        ddlPrioridadInc.SelectedValue = IIf(oINC.PropPRICODIGO Is Nothing, 0, oINC.PropPRICODIGO)

        If Not (oINC.PropINCACODIGO Is Nothing) Then
            txtIncAsociados.Text = oINC.PropINCACODIGO
        End If

        txtFechaInc.Text = oINC.PropINCFECHA.ToShortDateString + " " + oINC.PropINCFECHA.ToShortTimeString
        hfGeoX.Value = oINC.PropINCLOCXGEO
        hfGeoY.Value = oINC.PropINCLOCYGEO


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

        txtComentarioAte.Text = oINC.PropINCCOMENTARIO
        'txtRelatoAte.Text = oINC.PropINCRESULTADO
        'tiene parte policial
        If oINC.PropINCPARTEPOLICIAL Is Nothing Then
            chkPartePolicial.Checked = False
        Else
            chkPartePolicial.Checked = IIf(oINC.PropINCPARTEPOLICIAL = 1, True, False)
        End If
        'numero de intervenidos
        If oINC.PropINCINTERVENIDOS Is Nothing Then
            txtCantInterviene.Text = ""
        Else
            txtCantInterviene.Text = oINC.PropINCINTERVENIDOS
        End If

        If oINC.PropRESCODIGO Is Nothing Then
            ddlEstadoInc.SelectedValue = 0
        Else
            ddlEstadoInc.SelectedValue = oINC.PropRESCODIGO
        End If

        gvRecursos.DataSource = oCCOINCIDENCIAPAQUETE_BL.Listar(oINC.PropINCCODIGO)
        gvRecursos.DataBind()

    End Sub

    Protected Sub btnRetorno_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRetorno.Click
        Response.Redirect("frmGestionaIncidencia.aspx")
    End Sub

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        Dim olstINCPAQ As New List(Of CCOINCIDENCIAPAQUETE_BE)
        Dim oINC As New CCOINCIDENCIA_BE
        Dim oINC_BL As New CCOINCIDENCIA_BL
        Dim oINCPAQ As New CCOINCIDENCIAPAQUETE_BE
        Dim oINCPAQ_BL As New CCOINCIDENCIAPAQUETE_BL

        Try
            cargaDatos(oINC, olstINCPAQ)
            oINC_BL.AtenderIncidencia(oINC)
            For Each obj As CCOINCIDENCIAPAQUETE_BE In olstINCPAQ
                oINCPAQ = New CCOINCIDENCIAPAQUETE_BE
                oINCPAQ.PropINPINICIOATENCION = obj.PropINPINICIOATENCION
                oINCPAQ.PropINPFINATENCION = obj.PropINPFINATENCION
                oINCPAQ.PropINCCODIGO = obj.PropINCCODIGO
                oINCPAQ.PropPAQCODIGO = obj.PropPAQCODIGO
                oINCPAQ.PropPINCODIGO = obj.PropPINCODIGO
                oINCPAQ.PropINPTIPO = obj.PropINPTIPO
                oINCPAQ.PropAUDPRGMODIF = CType(Session("proyecto"), String)
                oINCPAQ.PropAUDEQPMODIF = CType(Session("equipo"), String)
                oINCPAQ.PropAUDFECMODIF = Now.Date
                oINCPAQ.PropAUDUSUMODIF = Nothing
                oINCPAQ.PropAUDROLMODIF = CType(Session("Rol"), Integer)   '--Session("userROL")

                oINCPAQ_BL.ActualizarAtencion(oINCPAQ)
            Next
            Util.MSG_ALERTA("Datos grabados satisfactoriamente.", Me)
        Catch ex As Exception
            Throw ex
        End Try



    End Sub

    Protected Sub cargaDatos(ByRef oINC_BE As CCOINCIDENCIA_BE, ByRef olstINCPAQ As List(Of CCOINCIDENCIAPAQUETE_BE))
        oINC_BE.PropINCCODIGO = CType(ViewState("pID"), Integer)
        'oINC_BE.PropINCRELATO = txtRelatoAte.Text
        oINC_BE.PropINCCOMENTARIO = txtComentarioAte.Text
        oINC_BE.PropINCINTERVENIDOS = txtCantInterviene.Text
        'oINC_BE.PropINCRESULTADO = txtRelatoAte.Text
        oINC_BE.PropPINCODIGO = Nothing
        oINC_BE.PropRESCODIGO = Int16.Parse(ddlEstadoInc.SelectedValue)

        If chkPartePolicial.Checked Then
            oINC_BE.PropINCPARTEPOLICIAL = 1
        Else
            oINC_BE.PropINCPARTEPOLICIAL = 0
        End If

        If chkFinAtencion.Checked Then
            oINC_BE.PropINCESTADO = Estado.Cerrado
        Else
            oINC_BE.PropINCESTADO = Estado.Atencion
        End If


        '-- historial incidencia
        oINC_BE.PropAUDROLCREACION = CType(Session("Rol"), Integer)
        oINC_BE.PropAUDROLMODIF = CType(Session("Rol"), Integer)
        '-- creacion incidencia
        oINC_BE.PropAUDPRGCREACION = CType(Session("proyecto"), String)
        oINC_BE.PropAUDEQPCREACION = CType(Session("equipo"), String)
        oINC_BE.PropAUDFECCREACION = Now.Date
        oINC_BE.PropAUDUSUCREACION = CType(Session("Usuario"), String)   '--Session("user")
        '=-- modificacion incidencia
        oINC_BE.PropAUDPRGMODIF = CType(Session("proyecto"), String)
        oINC_BE.PropAUDEQPMODIF = CType(Session("equipo"), String)
        oINC_BE.PropAUDFECMODIF = Now.Date
        oINC_BE.PropAUDUSUMODIF = CType(Session("Usuario"), String)   '--Session("user")

        Dim oIncPaq As New CCOINCIDENCIAPAQUETE_BE


        For Each row As GridViewRow In gvRecursos.Rows

            Dim pInicio As String = ""
            Dim pFinal As String = ""

            Dim _LBLINTPAQCODIGO As Label = row.FindControl("lblINTPAQCODIGO")
            Dim _TXTFECINIATE As TextBox = row.FindControl("txtFECINIATE")
            Dim _TXTHORINIATE As TextBox = row.FindControl("txtHORINIATE")
            Dim _TXTFECFINATE As TextBox = row.FindControl("txtFECFINATE")
            Dim _TXTHORFINATE As TextBox = row.FindControl("txtHORFINATE")
            Dim _TXTINTPINCODIGO As TextBox = row.FindControl("txtINTPINCODIGO")


            If _TXTFECINIATE.Text = "" Or _TXTFECFINATE.Text = "" Or _TXTFECFINATE.Text = "__/__/____" Or _TXTFECINIATE.Text = "__/__/____" Then
                _TXTFECINIATE.Text = ""
                _TXTFECFINATE.Text = ""
                _TXTHORINIATE.Text = ""
                _TXTHORFINATE.Text = ""
            Else
                If _TXTHORINIATE.Text = "__:__:__" Or _TXTHORFINATE.Text = "__:__:__" Or _TXTHORINIATE.Text = "" Or _TXTHORFINATE.Text = "" Then
                    _TXTHORINIATE.Text = "00:00:00"
                    _TXTHORFINATE.Text = "00:00:00"
                End If
                '((I.DTMINCFECHA  BETWEEN '2014-03-19 00:00:00.0' AND '2014-03-21 23:59:59.999999'))
                pInicio = Format(CDate(_TXTFECINIATE.Text), "yyyy-MM-dd") & " " & _TXTHORINIATE.Text & ".0"
                pFinal = Format(CDate(_TXTFECFINATE.Text), "yyyy-MM-dd") & " " & _TXTHORFINATE.Text & ".0"
            End If

            oIncPaq = New CCOINCIDENCIAPAQUETE_BE
            oIncPaq.PropINCCODIGO = CType(ViewState("pID"), Integer)
            oIncPaq.PropPAQCODIGO = CType(_LBLINTPAQCODIGO.Text, Integer)

            If pInicio <> "" Then
                oIncPaq.PropINPINICIOATENCION = pInicio
            End If
            If pFinal <> "" Then
                oIncPaq.PropINPFINATENCION = pFinal
            End If
            If _TXTINTPINCODIGO.Text.Trim = "" Then
                oIncPaq.PropPINCODIGO = Nothing
            Else
                oIncPaq.PropPINCODIGO = CType(_TXTINTPINCODIGO.Text, Integer)
            End If

            oIncPaq.PropINPTIPO = Nothing
            oIncPaq.PropAUDPRGMODIF = CType(Session("proyecto"), String)
            oIncPaq.PropAUDEQPMODIF = CType(Session("equipo"), String)
            oIncPaq.PropAUDFECMODIF = Now.Date
            oIncPaq.PropAUDUSUMODIF = CType(Session("Usuario"), String)
            oIncPaq.PropAUDROLMODIF = CType(Session("Rol"), Integer)
            olstINCPAQ.Add(oIncPaq)
        Next
    End Sub

End Class
