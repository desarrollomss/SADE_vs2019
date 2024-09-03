Imports System.Data.SqlClient
Imports System.Data

Imports SISSADE.BE
Imports SISSADE.BL


Partial Class frmGestionaIncF911
    Inherits System.Web.UI.Page
    Dim oINC As New CCOINCIDENCIA_BE
    Dim oINC_BL As New CCOINCIDENCIA_BL
    Dim oPAR As New CCOPARAMETRO_BE
    Dim oPAR_BL As New CCOPARAMETRO_BL


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
        '-- solo mientras se termina CONTROL DE ACCESOS
        'Session("Usuario") = "Testing"
        Session("Rol") = 1 '1-Operador Telefonico / 2-Operador Despachador / 3-Operador de Reporte / 4-Supervisor


        If Not IsPostBack() Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: GESTION DE LA INCIDENCIAS F911"
            Session("activo") = "2"
            Session("opcion") = "2.2"
            LlenarCombos()

            '-- solo el rol que corresponda
            ''ddlRol.SelectedValue = CType(Session("Rol"), Integer)


            'ddlRol.Enabled = False
            'btnGrabar.Attributes.Add("onclick", "javascript:return ValidarGrabar();")
            'btnToInc.Attributes.Add("onclientclick", "javascript:return asignaToInc();")
            'btnToLlam.Attributes.Add("onclick", "javascript:return asignaToLlam();")
            'btnToMap.Attributes.Add("onclick", "javascript:return cargaMap();")
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

            'If _lblDerivado.Text = "" Then
            '    _lnbDerivar.Visible = True
            '    _lnbCancelDerivar.Visible = False
            'Else
            '    _lnbDerivar.Visible = False
            '    _lnbCancelDerivar.Visible = True
            'End If

            ''Dim _lblPrioridad As Label = e.Row.FindControl("lblPrioridad")
            ''Dim _imgPrioridad As Image = e.Row.FindControl("imgPrioridad")
            ''Select Case _lblPrioridad.Text
            ''    Case "3"
            ''        _imgPrioridad.ImageUrl = "img/Prioridad/BAJA.png"
            ''    Case "2"
            ''        _imgPrioridad.ImageUrl = "img/Prioridad/MEDIA.png"
            ''    Case "1"
            ''        _imgPrioridad.ImageUrl = "img/Prioridad/ALTA.png"
            ''    Case Else
            ''        _imgPrioridad.ImageUrl = "img/Prioridad/NADA.png"
            ''End Select

            '----------
            'Dim dcfc As DataControlFieldCell = CType(e.Row.Controls(2), DataControlFieldCell)
            'Dim estado As DataControlFieldCell = CType(e.Row.Controls(8), DataControlFieldCell)
            Dim IDinci As DataControlFieldCell = CType(e.Row.Controls(1), DataControlFieldCell)
            'If (DateTime.Parse(dcfc.Text).Hour = DateTime.Now.Hour And DateTime.Parse(dcfc.Text).Minute = DateTime.Now.Minute) Then

            '    For i = 0 To e.Row.Cells.Count - 1
            '        Dim dcfc1 As DataControlFieldCell = CType(e.Row.Controls(i), DataControlFieldCell)
            '        dcfc1.BackColor = Drawing.Color.FromName("#EE5948")
            '        dcfc1.ForeColor = Drawing.Color.FromName("#FFFFFF")
            '    Next

            'End If
            'Dim dcfc As DataControlFieldCell = CType(e.Row.Controls(18), DataControlFieldCell)
            'If (dcfc.Text = String.Empty Or dcfc.Text = "&nbsp;") Then
            '    For i = 0 To e.Row.Cells.Count - 1
            '        Dim dcfc1 As DataControlFieldCell = CType(e.Row.Controls(i), DataControlFieldCell)
            '        dcfc1.BackColor = Drawing.Color.FromName("#EE5948")
            '        dcfc1.ForeColor = Drawing.Color.FromName("#FFFFFF")
            '    Next
            'End If

            If IDinci.Text = ViewState("dkincidencia") Then
                ViewState("oRowIndex") = e.Row.RowIndex
                For i = 0 To e.Row.Cells.Count - 1
                    Dim dcfc2 As DataControlFieldCell = CType(e.Row.Controls(i), DataControlFieldCell)
                    dcfc2.BackColor = Drawing.Color.FromName("#a3a2a7")
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
        Dim pBuscaTodo As Integer = 0
        Dim pDesde As String = ""
        Dim pHasta As String = ""

        If txtNumeroInc.Text.Trim = "" Then
            oINC.PropINCCODIGO = 0
        Else
            oINC.PropINCCODIGO = txtNumeroInc.Text.Trim
        End If
        oINC.PropINCNUMEROORIGEN = txtTelefonoInc.Text.ToString.Trim
        oINC.PropINCLOCVIANOMBRE1 = txtViaInc.Text.ToUpper
        oINC.PropINCRELATO = txtRelatoInc.Text.ToUpper
        oINC.PropINCNOMBRE = txtInformanteInc.Text.ToUpper


        oINC.PropINCESTADO = ddlEstadoInc.SelectedValue


        If txtFechaFinal.Text = "" Or txtFechaInicio.Text = "" Or txtFechaFinal.Text = "__/__/____" Or txtFechaInicio.Text = "__/__/____" Then
            txtFechaInicio.Text = ""
            txtFechaFinal.Text = ""
        Else
            '((I.DTMINCFECHA  BETWEEN '2014-03-19 00:00:00.0' AND '2014-03-21 23:59:59.999999'))
            pDesde = Format(CDate(txtFechaInicio.Text), "yyyy-MM-dd")
            pHasta = Format(CDate(txtFechaFinal.Text), "yyyy-MM-dd")
        End If

        oINC.PropINCACODIGO = 0
        oINC.PropINCANUMERO = 0
        oINC.PropORICODIGO = ddlOrigenInc.SelectedValue
        oINC.PropTINCODIGO = ddlTipoInc.SelectedValue
        oINC.PropSTICODIGO = ddlSubtipoInc.SelectedValue
        oINC.PropPRICODIGO = ddlPrioridadInc.SelectedValue
        oINC.PropINCLOCSECTOR = 0

        '--- Busqueda segun criterios
        If rbtUtlimaSemana.Checked Then
            pBuscaTodo = 0
        End If

        If rbtTodo.Checked Then
            pBuscaTodo = 1
        End If


        gvDatos.DataSource = oINC_BL.ListarF911(oINC, pDesde, pHasta, pBuscaTodo)
        gvDatos.DataBind()
        gvDatos.SelectedIndex = -1

    End Sub

    Protected Sub gvDatos_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "javascript: this.style.cursor='pointer';"
            e.Row.Attributes("onmouseout") = "javascript: this.style.cursor='normal';"
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvDatos, "Select$" + e.Row.RowIndex.ToString)
            'Dim dcfc As DataControlFieldCell = CType(e.Row.Controls(18), DataControlFieldCell)
            'If (dcfc.Text = String.Empty) Then
            '    For i = 0 To e.Row.Cells.Count - 1
            '        Dim dcfc1 As DataControlFieldCell = CType(e.Row.Controls(i), DataControlFieldCell)
            '        dcfc1.BackColor = Drawing.Color.FromName("#EE5948")
            '        dcfc1.ForeColor = Drawing.Color.FromName("#FFFFFF")
            '    Next
            'End If
        End If
    End Sub


    Protected Sub btnVisualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        If gvDatos.SelectedIndex >= 0 Then
            ModoEdicion("V")
        End If
    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReferencia.Click
        If gvDatos.SelectedIndex >= 0 Then
            ModoEdicion("U")
        End If
    End Sub



#Region "EXPORTAR EXCEL"

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        GridViewExportUtil.Exportar("SADE-Incidentes.XLS", gvDatos)

        'Dim oBE As TB_COMPSEG_BE = New TB_COMPSEG_BE
        'Dim oBL As TB_COMPSEG_BL = New TB_COMPSEG_BL
        'Try
        '    With oBE
        '        If txtID.Text.Trim = "" Then .PropIDCS = 0 Else .PropIDCS = CType(txtID.Text, Int32)
        '        .PropDIRECCION = txtDescripcion.Text.ToUpper
        '        .PropIDCST = ddlTipoCmpnt.SelectedValue
        '        .PropIDCSE = ddlEstadoCmpnt.SelectedValue
        '    End With
        '    Dim dt As DataTable = New DataTable
        '    Dim GV As GridView = New GridView
        '    dt = oBL.Listar(oBE)
        '    GV.DataSource = dt
        '    GV.DataBind()
        '    GridViewExportUtil.ExportaUsuario("ComponenteSeguridad.xls", GV)
        'Catch ex As Exception
        '    lblMensaje.Text = ex.Message
        'End Try


    End Sub

#End Region

 

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
        lblFecInicio.Visible = habilita
        txtFechaFinal.Visible = habilita
        lblFecFinal.Visible = habilita

    End Sub

    Protected Sub gvDatos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDatos.SelectedIndexChanged
        Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex) '-- es la fila de la grilla 
        Dim intID As Integer = dk.Item("INTINCCODIGO")  ' se pone el nombre de la llave 
        ViewState("dkincidencia") = intID
        ViewState("oRowIndex") = gvDatos.SelectedIndex
    End Sub





    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        ModoBusqueda()
    End Sub


#Region "Modos"

    Private Sub ModoBusqueda()
        pnlEdicion.Visible = False
        pnlBusqueda.Visible = True
        lblMensajeReg.Text = ""
        CargarBuscarIncidencia()
    End Sub

    Private Sub ModoEdicion(ByVal accion As String)

        pnlEdicion.Visible = True
        pnlBusqueda.Visible = False
        btnGrabar.Visible = True

        txtNumeroIncEdi.Attributes.Add("onkeypress ", "javascript:return validarNum(event)")

        hdTipoAccion.Value = accion
        txtNumeroIncEdi.Text = ""
        '        CargaCombosEdicion()
        LlenarCombosEdit()

        txtNumeroIncEdi.Text = ""
        txtFechaIncEdi.Text = ""
        txtNumTelIncEdi.text = ""
        ddlOrigenIncEdi.SelectedValue = 0
        ddlTipoIncEdi.SelectedValue = 0
        'ddlSubtipoIncEdi.SelectedValue = 0
        ddlPrioridadIncEdi.SelectedValue = 0
        txtPreviasIncEdi.Text = ""
        ddlTipoDocIncEdi.SelectedValue = 0
        txtNumDocIncEdi.Text = ""
        ddlTipoPersonaIncEdi.SelectedValue = 0
        txtNombreIncEdi.Text = ""
        txtCalleIncEdi.Text = ""
        txtNroIncEdi.Text = ""
        txtCdraIncEdi.Text = ""
        txtMzaIncEdi.Text = ""
        txtLteIncEdi.Text = ""
        txtDptoIncEdi.Text = ""
        txtUrbIncEdi.Text = ""
        txtComIncEdi.Text = ""
        txtSectorIncEdi.Text = ""
        txtCuadranteIncEdi.Text = ""
        txtRelatoIncEdi.Text = ""
        ddlObjetivoIncEdi.SelectedValue = 0
        ddlModalidadIncEdi.SelectedValue = 0
        ddlDenunciaIncEdi.SelectedValue = 0
        ddlDelitoIncEdi.SelectedValue = 0
        txtConsecuenciaIncEdi.Text = ""
        txtFechaAteIncEdi.Text = ""

        hfGeoX.Value = ""
        hfGeoY.Value = ""


        txtNumeroIncEdi.Enabled = False
        txtFechaIncEdi.Enabled = False
        txtNumTelIncEdi.enabled = False
        ddlOrigenIncEdi.Enabled = False
        ddlTipoIncEdi.Enabled = True
        ddlSubtipoIncEdi.Enabled = True
        ddlPrioridadIncEdi.Enabled = True
        txtPreviasIncEdi.Enabled = False
        ddlTipoDocIncEdi.Enabled = True
        txtNumDocIncEdi.Enabled = True
        ddlTipoPersonaIncEdi.Enabled = True
        txtNombreIncEdi.Enabled = True
        txtCalleIncEdi.Enabled = True
        txtNroIncEdi.Enabled = True
        txtCdraIncEdi.Enabled = True
        txtMzaIncEdi.Enabled = True
        txtLteIncEdi.Enabled = True
        txtDptoIncEdi.Enabled = True
        txtUrbIncEdi.Enabled = True
        txtComIncEdi.Enabled = True
        txtSectorIncEdi.Enabled = True
        txtCuadranteIncEdi.Enabled = True
        txtRelatoIncEdi.Enabled = True
        ddlObjetivoIncEdi.Enabled = True
        ddlModalidadIncEdi.Enabled = True
        ddlDenunciaIncEdi.Enabled = True
        ddlDelitoIncEdi.Enabled = True
        txtConsecuenciaIncEdi.Enabled = True
        txtFechaAteIncEdi.Enabled = True


        If accion = "V" Or accion = "U" Then

            If gvDatos.SelectedIndex >= 0 Then
                Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex)
                txtNumeroIncEdi.Text = dk.Item("INTINCCODIGO")
            End If
            txtNumeroIncEdi.Enabled = False


            Dim oBE As CCOINCIDENCIA_BE = New CCOINCIDENCIA_BE
            Dim oBESel As CCOINCIDENCIA_BE = New CCOINCIDENCIA_BE
            Dim oBL As CCOINCIDENCIA_BL = New CCOINCIDENCIA_BL
            Dim oBEPOL As CCOPARTEDIARIO_BE = New CCOPARTEDIARIO_BE
            Dim oBEPOLSel As CCOPARTEDIARIO_BE = New CCOPARTEDIARIO_BE
            Dim oBLPOL As CCOPARTEDIARIO_BL = New CCOPARTEDIARIO_BL
            Try
                With oBE
                    .PropINCCODIGO = txtNumeroIncEdi.Text
                End With
                oBESel = oBL.ListarKey(oBE)

                hfGeoX.Value = oBESel.PropINCLOCXGEO
                hfGeoY.Value = oBESel.PropINCLOCYGEO
                txtNumeroIncEdi.Text = oBESel.PropINCCODIGO
                txtNumTelIncEdi.Text = oBESel.PropINCNUMEROORIGEN
                txtUsuCreaIncEdi.Text = oBESel.PropAUDUSUCREACION.ToUpper
                txtUsuModIncEdi.Text = oBESel.PropAUDUSUMODIF.ToUpper
                txtFechaIncEdi.Text = oBESel.PropINCFECHA
                If oBESel.PropINCANUMERO IsNot Nothing Then
                    txtPreviasIncEdi.Text = oBESel.PropINCANUMERO
                End If
                txtNumDocIncEdi.Text = oBESel.PropINCDOCUMENTO
                txtNombreIncEdi.Text = oBESel.PropINCNOMBRECOMP
                txtCalleIncEdi.Text = oBESel.PropINCLOCVIANOMBRE1
                txtNroIncEdi.Text = oBESel.PropINCLOCNUMERO
                txtCdraIncEdi.Text = oBESel.PropINCLOCCUADRA
                txtMzaIncEdi.Text = oBESel.PropINCLOCMANZANA
                txtLteIncEdi.Text = oBESel.PropINCLOCLOTE
                txtDptoIncEdi.Text = oBESel.PropINCLOCDPTO
                txtUrbIncEdi.Text = oBESel.PropINCLOCHABNOMBRE
                txtComIncEdi.Text = oBESel.PropINCLOCCOMENTARIO
                txtSectorIncEdi.Text = oBESel.PropVCHINCLOCSECTOR
                txtCuadranteIncEdi.Text = oBESel.PropVCHINCLOCCUADRANTE
                txtRelatoIncEdi.Text = oBESel.PropINCRELATO
                hfGeoX.Value = oBESel.PropINCLOCXGEO
                hfGeoY.Value = oBESel.PropINCLOCYGEO

                ddlOrigenIncEdi.SelectedValue = oBESel.PropORICODIGO
                ddlPrioridadIncEdi.SelectedValue = oBESel.PropPRICODIGO
                ddlTipoDocIncEdi.SelectedValue = oBESel.PropTIDCODIGO
                If oBESel.PropTPECODIGO IsNot Nothing Then
                    ddlTipoPersonaIncEdi.SelectedValue = oBESel.PropTPECODIGO
                End If
                If oBESel.PropTINCODIGO IsNot Nothing Then
                    ddlTipoIncEdi.SelectedValue = oBESel.PropTINCODIGO
                    comboSubtipoIncEdi(oBESel.PropTINCODIGO)
                    ddlSubtipoIncEdi.SelectedValue = oBESel.PropSTICODIGO
                End If
                '---PARTE DIARIO
                With oBEPOL
                    .PropINCCODIGO = txtNumeroIncEdi.Text
                End With
                oBEPOLSel = oBLPOL.ListarKey(oBEPOL)
                '-- SI EXISTEN DATOS
                If oBEPOLSel.PropINCCODIGO IsNot Nothing Then
                    ddlObjetivoIncEdi.SelectedValue = oBEPOLSel.PropOBJCODIGO
                    ddlModalidadIncEdi.SelectedValue = oBEPOLSel.PropMODCODIGO
                    txtConsecuenciaIncEdi.Text = oBEPOLSel.PropINCCONSECUENCIA
                    ddlDetenidosIncEdi.SelectedValue = oBEPOLSel.PropINCAGRESORES
                    ddlDenunciaIncEdi.SelectedValue = oBEPOLSel.PropINTCODIGO

                    ddlFugaIncEdi.SelectedValue = oBEPOLSel.PropFUGACODIGO
                    ddlTurnoIncEdi.SelectedValue = oBEPOLSel.PropTURNOCODIGO
                    hfCodPerEncEdi.Value = oBEPOLSel.PropPERCODSERENO
                    hfCodPerSupEdi.Value = oBEPOLSel.PropPERCODOPERADOR
                    txtFechaAteIncEdi.Text = oBEPOLSel.PropFINATENCION
                    ddlDelitoIncEdi.SelectedValue = oBEPOLSel.PropTIPODELITO
                End If
            Catch ex As Exception
                lblMensajeReg.Text = ex.Message
                Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            End Try

            If accion = "V" Then

                btnGrabar.Visible = False

                txtNumeroIncEdi.Enabled = False
                txtNumTelIncEdi.Enabled = False
                txtFechaIncEdi.Enabled = False
                txtUsuCreaIncEdi.Enabled = False
                txtUsuModIncEdi.Enabled = False
                ddlOrigenIncEdi.Enabled = False
                ddlTipoIncEdi.Enabled = False
                ddlSubtipoIncEdi.Enabled = False
                ddlPrioridadIncEdi.Enabled = False
                txtPreviasIncEdi.Enabled = False
                ddlTipoDocIncEdi.Enabled = False
                txtNumDocIncEdi.Enabled = False
                ddlTipoPersonaIncEdi.Enabled = False
                txtNombreIncEdi.Enabled = False
                txtCalleIncEdi.Enabled = False
                txtNroIncEdi.Enabled = False
                txtCdraIncEdi.Enabled = False
                txtMzaIncEdi.Enabled = False
                txtLteIncEdi.Enabled = False
                txtDptoIncEdi.Enabled = False
                txtUrbIncEdi.Enabled = False
                txtComIncEdi.Enabled = False
                txtSectorIncEdi.Enabled = False
                txtCuadranteIncEdi.Enabled = False
                txtRelatoIncEdi.Enabled = False
                ddlObjetivoIncEdi.Enabled = False
                ddlModalidadIncEdi.Enabled = False
                ddlDenunciaIncEdi.Enabled = False
                ddlDelitoIncEdi.Enabled = False
                txtConsecuenciaIncEdi.Enabled = False
                txtFechaAteIncEdi.Enabled = False

            End If

        End If
    End Sub

    Public Sub LlenarCombosEdit()
        Dim lstOrigenIncidencia As New List(Of CCOORIGENINCIDENCIA_BE)
        Dim oCCOTABLA_BE As New CCOTABLA_BE
        Dim oCCOSUBTIPOINCIDENCIA_BE As New CCOSUBTIPOINCIDENCIA_BE
        Dim oCCOTIPOPERSONA_BL As New CCOTIPOPERSONA_BL
        Dim oCCOORIGENINCIDENCIA_BL As New CCOORIGENINCIDENCIA_BL
        Dim oCCOTIPOINCIDENCIA_BL As New CCOTIPOINCIDENCIA_BL
        Dim oCCOSUBTIPOINCIDENCIA_BL As New CCOSUBTIPOINCIDENCIA_BL
        Dim oCCOPRIORIDADINCIDENCIA_BL As New CCOPRIORIDADINCIDENCIA_BL
        Dim oCCOSECTOR_BL As New CCOSECTOR_BL
        Dim oCCOTABLA_BL As New CCOTABLA_BL
        Dim oSYSCATASTRO_BL As New SYSCATASTRO_BL
        Dim oSCUROL_BL As New SCUROL_BL
        Dim oCCOMODALIDADFUGAINCIDENCIA_BL As New CCOMODALIDADFUGAINCIDENCIA_BL
        Dim oCCOMODALIDADINCIDENCIA_BL As New CCOMODALIDADINCIDENCIA_BL
        Dim oCCOOBJETIVOINCIDENCIA_BL As New CCOOBJETIVOINCIDENCIA_BL






        With ddlOrigenIncEdi
            .DataSource = oCCOORIGENINCIDENCIA_BL.ListarCombo
            .DataTextField = "PropORIDESCRIPCION"
            .DataValueField = "PropORICODIGO"
        End With
        ddlOrigenIncEdi.DataBind()
        ddlOrigenIncEdi.Items.Insert(0, New ListItem("(Todos)", "0"))


        With ddlTipoIncEdi
            .DataSource = oCCOTIPOINCIDENCIA_BL.ListarCombo
            .DataTextField = "PropTINDESCRIPCION"
            .DataValueField = "PropTINCODIGO"
        End With
        ddlTipoIncEdi.DataBind()
        ddlTipoIncEdi.Items.Insert(0, New ListItem("(Todos)", "0"))


        'oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = -1
        'oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = 0
        'With ddlSubtipoIncEdi
        '    .DataSource = oCCOSUBTIPOINCIDENCIA_BL.ListarCombo(oCCOSUBTIPOINCIDENCIA_BE)
        '    .DataTextField = "PropSTIDESCRIPCION"
        '    .DataValueField = "PropSTICODIGO"
        'End With
        'ddlSubtipoIncEdi.DataBind()
        'ddlSubtipoIncEdi.Items.Insert(0, New ListItem("(Todos)", "0"))


        With ddlPrioridadIncEdi
            .DataSource = oCCOPRIORIDADINCIDENCIA_BL.ListarCombo()
            .DataTextField = "PropPRIDESCRIPCION"
            .DataValueField = "PropPRICODIGO"
        End With
        ddlPrioridadIncEdi.DataBind()
        ddlPrioridadIncEdi.Items.Insert(0, New ListItem("(Todos)", "0"))

        oCCOTABLA_BE.PropTTACODIGO = "TIPDOCIDENT"

        With ddlTipoDocIncEdi
            .DataSource = oCCOTABLA_BL.Listar(oCCOTABLA_BE)
            .DataTextField = "DESCRIPCION"
            .DataValueField = "ID"
        End With
        ddlTipoDocIncEdi.DataBind()
        ddlTipoDocIncEdi.Items.Insert(0, New ListItem("(Todos)", "0"))

        With ddlTipoPersonaIncEdi
            .DataSource = oCCOTIPOPERSONA_BL.ListarCombo
            .DataTextField = "PropTPEDESCRIPCION"
            .DataValueField = "PropTPECODIGO"
        End With
        ddlTipoPersonaIncEdi.DataBind()
        ddlTipoPersonaIncEdi.Items.Insert(0, New ListItem("(Seleccionar)", "0"))



        With ddlObjetivoIncEdi
            .DataSource = oCCOOBJETIVOINCIDENCIA_BL.ListaCombo
            .DataTextField = "DESCRIPCION"
            .DataValueField = "CODIGO"
        End With
        ddlObjetivoIncEdi.DataBind()
        ddlObjetivoIncEdi.Items.Insert(0, New ListItem("(Seleccionar)", "0"))

        With ddlModalidadIncEdi
            .DataSource = oCCOMODALIDADINCIDENCIA_BL.ListaCombo
            .DataTextField = "DESCRIPCION"
            .DataValueField = "CODIGO"
        End With
        ddlModalidadIncEdi.DataBind()
        ddlModalidadIncEdi.Items.Insert(0, New ListItem("(Seleccionar)", "0"))

        With ddlFugaIncEdi
            .DataSource = oCCOMODALIDADFUGAINCIDENCIA_BL.ListaCombo
            .DataTextField = "DESCRIPCION"
            .DataValueField = "CODIGO"
        End With
        ddlFugaIncEdi.DataBind()
        ddlFugaIncEdi.Items.Insert(0, New ListItem("(Seleccionar)", "0"))


        oCCOTABLA_BE.PropTTACODIGO = "TIPOTURNO"
        With ddlTurnoIncEdi
            .DataSource = oCCOTABLA_BL.Listar(oCCOTABLA_BE)
            .DataTextField = "DESCRIPCION"
            .DataValueField = "ID"
        End With
        ddlTurnoIncEdi.DataBind()
        ddlTurnoIncEdi.Items.Insert(0, New ListItem("(Seleccionar)", "0"))

        oCCOTABLA_BE.PropTTACODIGO = "TIPODENUNCIA"
        With ddlDenunciaIncEdi
            .DataSource = oCCOTABLA_BL.Listar(oCCOTABLA_BE)
            .DataTextField = "DESCRIPCION"
            .DataValueField = "ID"
        End With
        ddlDenunciaIncEdi.DataBind()
        ddlDenunciaIncEdi.Items.Insert(0, New ListItem("(Seleccionar)", "0"))

        oCCOTABLA_BE.PropTTACODIGO = "CNTDETENIDOS"
        With ddlDetenidosIncEdi
            .DataSource = oCCOTABLA_BL.Listar(oCCOTABLA_BE)
            .DataTextField = "DESCRIPCION"
            .DataValueField = "ID"
        End With
        ddlDetenidosIncEdi.DataBind()
        ddlDetenidosIncEdi.Items.Insert(0, New ListItem("(Seleccionar)", "0"))

        oCCOTABLA_BE.PropTTACODIGO = "TIPODELITO"
        With ddlDelitoIncEdi
            .DataSource = oCCOTABLA_BL.Listar(oCCOTABLA_BE)
            .DataTextField = "DESCRIPCION"
            .DataValueField = "ID"
        End With
        ddlDelitoIncEdi.DataBind()
        ddlDelitoIncEdi.Items.Insert(0, New ListItem("(Seleccionar)", "0"))





        'oCCOTABLA_BE.PropTTACODIGO = "ESTADOINCIDENCIA"

        'With ddlEstadoInc
        '    .DataSource = oCCOTABLA_BL.Listar(oCCOTABLA_BE)
        '    .DataTextField = "DESCRIPCION2"
        '    .DataValueField = "ID"
        'End With
        'ddlEstadoInc.DataBind()
        'ddlEstadoInc.Items.Insert(0, New ListItem("(Todos)", "0"))

    End Sub


#End Region

    Protected Sub ddlTipoIncEdi_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipoIncEdi.SelectedIndexChanged
        comboSubtipoIncEdi(ddlTipoIncEdi.SelectedValue)
    End Sub

    Protected Sub comboSubtipoIncEdi(ByVal intTipoIncEdi As Integer)
        Dim oSTI_BE As New CCOSUBTIPOINCIDENCIA_BE
        Dim oSTI_BL As New CCOSUBTIPOINCIDENCIA_BL

        oSTI_BE.PropSTICODIGO = 0
        oSTI_BE.PropTINCODIGO = intTipoIncEdi
        With ddlSubtipoIncEdi
            .DataSource = oSTI_BL.ListarCombo(oSTI_BE)
            .DataTextField = "PropSTIDESCRIPCION"
            .DataValueField = "PropSTICODIGO"
        End With
        ddlSubtipoIncEdi.DataBind()
        ddlSubtipoIncEdi.Items.Insert(0, New ListItem("(Todos)", "0"))


    End Sub

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim oBE As CCOINCIDENCIA_BE = New CCOINCIDENCIA_BE
        Dim oBL As CCOINCIDENCIA_BL = New CCOINCIDENCIA_BL
        Dim oBEPOL As CCOPARTEDIARIO_BE = New CCOPARTEDIARIO_BE
        Dim oBLPOL As CCOPARTEDIARIO_BL = New CCOPARTEDIARIO_BL
        lblMensajeReg.Text = ""


        'If ddlTipoCmpntEdit.SelectedItem.Text = "(Seleccione)" Then
        '    lblMensajeReg.Text = "<li>Seleccione el Tipo de componente</li>"
        'End If
        'If ddlEstadoCmpntEdit.SelectedItem.Text = "(Seleccione)" Then
        '    lblMensajeReg.Text = lblMensajeReg.Text & "<li>Seleccione el Estado de componente</li>"
        'End If

        If hfCodPerEncEdi.Value.ToString = "" Or hfCodPerSupEdi.Value.ToString = "" Then
            lblMensajeReg.Text = lblMensajeReg.Text & "<li>Indique Personal Campo y Supervisor</li>"
        End If

        If hfGeoX.Value.ToString = "" Or hfGeoY.Value.ToString = "" Then
            lblMensajeReg.Text = lblMensajeReg.Text & "<li>Ubique en el mapa la ubicacion del Incidente</li>"
        End If

        If lblMensajeReg.Text = "" Then
            Try

                With oBE
                    If (txtNumeroIncEdi.Text <> "") Then
                        .PropINCCODIGO = txtNumeroIncEdi.Text
                    End If
                    .PropINCCOMENTARIO = Nothing
                    .PropINCLOCVIACODIGO1 = Nothing
                    .PropINCLOCVIANOMBRE1 = txtCalleIncEdi.Text
                    .PropINCLOCVIACODIGO2 = Nothing
                    .PropINCLOCVIANOMBRE2 = Nothing
                    .PropINCLOCNUMERO = txtNroIncEdi.Text
                    .PropINCLOCCUADRA = txtCdraIncEdi.Text
                    .PropINCLOCMANZANA = txtMzaIncEdi.Text
                    .PropINCLOCLOTE = txtLteIncEdi.Text
                    .PropINCLOCDPTO = txtDptoIncEdi.Text
                    .PropINCLOCBLOCK = Nothing
                    .PropINCLOCHABCODIGO = hfCodHabUrbEdi.Value
                    .PropINCLOCHABNOMBRE = txtUrbIncEdi.Text
                    .PropINCLOCSECTOR = Nothing
                    .PropINCLOCCUADRANTE = Nothing
                    .PropINCLOCCOMENTARIO = txtComIncEdi.Text
                    .PropINCRELATO = txtRelatoIncEdi.Text
                    .PropINCANONIMO = Nothing
                    .PropTPECODIGO = ddlTipoPersonaIncEdi.SelectedValue
                    .PropTIDCODIGO = ddlTipoDocIncEdi.SelectedValue
                    .PropINCNOMBRECOMP = txtNombreIncEdi.Text
                    .PropINCDOCUMENTO = txtNumDocIncEdi.Text
                    .PropINCRESULTADO = Nothing
                    .PropINCESTADO = Nothing
                    .PropINCACODIGO = Nothing
                    .PropINCANUMERO = Nothing
                    .PropORICODIGO = ddlOrigenIncEdi.SelectedValue
                    .PropTINCODIGO = ddlTipoIncEdi.SelectedValue
                    .PropSTICODIGO = ddlSubtipoIncEdi.SelectedValue
                    .PropPRICODIGO = ddlPrioridadIncEdi.SelectedValue
                    .PropPINCODIGO = Nothing
                    .PropRESCODIGO = Nothing
                    .PropAUDFECMODIF = Now.Date
                    .PropAUDUSUMODIF = Session("USUARIO")
                    .PropAUDPRGMODIF = Session("PROGRAMA")
                    .PropAUDEQPMODIF = Session("EQUIPO")

                    .PropINCPARTEPOLICIAL = ddlDenunciaIncEdi.SelectedValue
                    .PropINCINTERVENIDOS = ddlDetenidosIncEdi.SelectedValue
                    .PropINCIDLATITUDE = Nothing
                    .PropINCIDLONGITUDE = Nothing
                    .PropINCLOCXGEO = hfGeoX.Value
                    .PropINCLOCYGEO = hfGeoY.Value
                    .PropVCHINCLOCCUADRANTE = txtCuadranteIncEdi.Text
                    .PropVCHINCLOCSECTOR = txtSectorIncEdi.Text
                End With
                With oBEPOL
                    .PropINCCODIGO = txtNumeroIncEdi.Text
                    .PropINCAGRESORES = ddlDetenidosIncEdi.SelectedValue
                    .PropINCCONSECUENCIA = txtConsecuenciaIncEdi.Text
                    .PropOBJCODIGO = ddlObjetivoIncEdi.SelectedValue
                    .PropMODCODIGO = ddlModalidadIncEdi.SelectedValue
                    .PropINTCODIGO = ddlDenunciaIncEdi.SelectedValue
                    .PropAUDPRGCREACION = Session("PROGRAMA")
                    .PropAUDEQPCREACION = Session("EQUIPO")
                    .PropAUDFECCREACION = Now.Date
                    .PropAUDUSUCREACION = Session("USUARIO")
                    .PropAUDROLCREACION = Nothing
                    .PropPERCODOPERADOR = hfCodPerSupEdi.Value
                    .PropPERCODSERENO = hfCodPerEncEdi.Value
                    .PropTURNOCODIGO = ddlTurnoIncEdi.SelectedValue
                    .PropFUGACODIGO = ddlFugaIncEdi.SelectedValue
                    .PropFINATENCION = txtFechaAteIncEdi.Text.ToString
                    .PropTIPODELITO = ddlDelitoIncEdi.SelectedValue
                End With

                Dim intID As Integer = 0
                If hdTipoAccion.Value = "I" Then
                ElseIf hdTipoAccion.Value = "U" Then
                    oBL.Actualizar_SQL_DB2(oBE)
                    oBLPOL.Actualizar_SQL_DB2(oBEPOL)
                    lblMensajeReg.Text = "Se Actualizó de manera Exitosa"
                    ModoBusqueda()
                End If
            Catch ex As Exception
                lblMensajeReg.Text = ex.Message
                Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            End Try
        End If

    End Sub
End Class
