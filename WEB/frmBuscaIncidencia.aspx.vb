Imports System.Data.SqlClient
Imports System.Data
Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Configuration

Enum BuscaEstado
    Abierto = 7
    ParaDespacho = 8
    Despachado = 9
    Descartado = 10
    Atendido = 11
    Cerrado = 12
End Enum

Partial Class frmBuscaIncidencia
    Inherits System.Web.UI.Page
    Dim oINC As New CCOINCIDENCIA_BE
    Dim oINC_BL As New CCOINCIDENCIA_BL
    Dim oPAR As New CCOPARAMETRO_BE
    Dim oPAR_BL As New CCOPARAMETRO_BL
    Dim servidor As String = ConfigurationManager.AppSettings("SERVIDOR")
    Dim oSYSESTACION_BL As New SYSESTACION_BL
    Dim oCCORECURSO_BL As New CCORECURSO_BL


    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

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
        If Not IsPostBack() Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: BUSQUEDA INCIDENCIAS"
            Session("activo") = "1"
            Session("opcion") = "1.2"

            LlenarCombos()

            '-- Cargar datos Grilla
            '-- CargarBuscarIncidencia()


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

        ''Try
        ''    ddlUsuarioInc.SelectedValue = CType(Session("Usuario"), String).ToUpper
        ''Catch ex As Exception
        ''    ddlUsuarioInc.SelectedIndex = -1
        ''End Try


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

        With ddlRol
            .DataSource = oSCUROL_BL.ListarCombo()
            .DataTextField = "VCHROLDESCRIP"
            .DataValueField = "INTROLCODIGO"
        End With
        ddlRol.DataBind()
        ddlRol.Items.Insert(0, New ListItem("(Todos)", "0"))


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

    Protected Sub gvDatos_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "javascript: this.style.cursor='pointer';"
            e.Row.Attributes("onmouseout") = "javascript: this.style.cursor='normal';"
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvDatos, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub


    Protected Sub gvDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim _lnbDerivar As LinkButton = e.Row.FindControl("lnbDeriva")
            Dim _lnbCancelDerivar As LinkButton = e.Row.FindControl("lnbCancelDeriva")
            Dim _lblDerivado As Label = e.Row.FindControl("lblDerivado")
            Dim _imgSIAVE As Image = e.Row.FindControl("imgSIAVE")
            Dim _lblSIAVE As Label = e.Row.FindControl("lblSIAVE")

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


            If _lblSIAVE.Text = "" Then
                _imgSIAVE.Visible = False
            Else
                _imgSIAVE.Visible = True
                _imgSIAVE.ImageUrl = "img/Origen/derivaSIAVE.png"
            End If

            Dim IDinci As DataControlFieldCell = CType(e.Row.Controls(1), DataControlFieldCell)

            If IDinci.Text = ViewState("dkincidencia") Then
                ViewState("oRowIndex") = e.Row.RowIndex
                For i = 0 To e.Row.Cells.Count - 1
                    Dim dcfc2 As DataControlFieldCell = CType(e.Row.Controls(i), DataControlFieldCell)
                    dcfc2.BackColor = Drawing.Color.FromName("#FFA500")
                    dcfc2.ForeColor = Drawing.Color.FromName("#F0F0F0")

                Next
            End If

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
            '-- responsable de recurso
            oINC.PropINCLLAVIANOMBRE = txtResponsableRecurso.Text.ToUpper.Trim




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

            gvDatos.DataSource = oINC_BL.BusquedaGeneral(oINC, pBuscaTodo)
            gvDatos.DataBind()
            gvDatos.SelectedIndex = -1
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub

    'Protected Sub gvDatos_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowCreated
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        e.Row.Attributes("onmouseover") = "javascript: this.style.cursor='pointer';"
    '        e.Row.Attributes("onmouseout") = "javascript: this.style.cursor='normal';"
    '        e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvDatos, "Select$" + e.Row.RowIndex.ToString)
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

    Protected Sub btnDefault_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDefault.Click
        'Try
        '    ddlRol.SelectedValue = CType(Session("ROL"), Integer)
        '    ddlUsuarioInc.SelectedValue = CType(Session("Usuario"), String).ToUpper
        'Catch ex As Exception
        ddlUsuarioInc.SelectedIndex = -1
        ddlRol.SelectedIndex = -1
        'End Try

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
        txtResponsableRecurso.Text = ""
        rbtUtlimaSemana.Checked = True
        rbtTodo.Checked = False
        mostrarRangoFecha(False)
    End Sub

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
                lblMensaje.Text = ex.Message.ToString
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

    Protected Sub btnReporte_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReporte.Click
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

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click

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
            '-- responsable de recurso
            oINC.PropINCLLAVIANOMBRE = txtResponsableRecurso.Text.ToUpper.Trim




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

            gvEstadistica.DataSource = oINC_BL.BusquedaGeneral(oINC, pBuscaTodo)
            gvEstadistica.DataBind()
            GridViewExportUtil.Export("Export Data SADE.xls", gvEstadistica)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub




End Class
