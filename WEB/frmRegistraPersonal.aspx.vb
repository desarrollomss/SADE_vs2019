Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data

Partial Class frmRegistraPersonal
    Inherits System.Web.UI.Page
    Dim codigo As Integer
    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        btnGrabar.Attributes.Add("onclick", "javascript:return validaGrabar();")
        txtCodigo.Attributes.Add("onkeypress", "javascript:return solonumeros(event);")
        txtTalla.Attributes.Add("onkeypress", "javascript:return solomontos(event);")
        txtPeso.Attributes.Add("onkeypress", "javascript:return solomontos(event);")
        txtSueldo.Attributes.Add("onkeypress", "javascript:return solomontos(event);")

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim mp As MasterPage = Me.Master
        Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
        tit.Text = ":: REGISTRO DE PERSONAL"
        If Not Page.IsPostBack Then
            ViewState("INTPERCODIGO") = Request.QueryString("id")
            CargaCombo()
            CargaGrillaFamiliar()
            If Integer.Parse(Request.QueryString("id").ToString) > 0 Then
                CargarFicha()
                DesBloquearDIV()
            End If
        End If
    End Sub

    Private Sub MostrarPopup(ByVal pdiv As String)
        Dim sb As New StringBuilder
        'sb.AppendLine("javascript:void(0);")
        sb.AppendLine("document.getElementById('" & pdiv & "').style.display='block';document.getElementById('fade').style.display='block';")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub
    Private Sub CerrarPopup(ByVal pdiv As String)
        Dim sb As New StringBuilder
        sb.AppendLine("javascript:void(0);")
        sb.AppendLine("document.getElementById('" & pdiv & "').style.display='none';document.getElementById('fade').style.display='none';")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub
    Private Sub BloquearDIV()
        Dim sb As New StringBuilder
        sb.AppendLine("$(""#pnlDatosFamiliares"").block({ message: null });")
        'sb.AppendLine("$(""#pnlDatosPersonales"").block({ message: null });")
        'sb.AppendLine("$(""#pnlMunicipalidad"").block({ message: null });")
        'sb.AppendLine("$(""#pnlDatosVehiculo"").block({ message: null });")
        sb.AppendLine("$(""#div_file"").block({ message: null });")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub
    Private Sub DesBloquearDIV()
        Dim sb As New StringBuilder
        sb.AppendLine("$(""#pnlDatosFamiliares"").unblock();")
        sb.AppendLine("$(""#div_file"").unblock();")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click
        Dim oCCOPERSONAL_BE As CCOPERSONAL_BE = New CCOPERSONAL_BE
        Dim oCCOPERSONAL_BL As CCOPERSONAL_BL = New CCOPERSONAL_BL
        Try
            codigo = Integer.Parse(ViewState("INTPERCODIGO"))
            With oCCOPERSONAL_BE
                .PropPERCODIGO = codigo
                .PropPERAPELLIDOPATERNO = txtAPellidoPaterno.Text.ToUpper
                .PropPERAPELLIDOMATERNO = txtApellidoMaterno.Text.ToUpper
                .PropPERNOMBRE = txtNombres.Text.ToUpper
                .PropPERDNI = txtDNI.Text
                .PropPERRUC = txtRuc.Text
                If (txtFechaNacimiento.Text = "__/__/____" Or txtFechaNacimiento.Text.Length = 0) Then
                    .PropPERFECNACIMIENTO = Nothing
                Else
                    .PropPERFECNACIMIENTO = Date.Parse(txtFechaNacimiento.Text)
                End If
                .PropPERLUGNACIMIENTO = txtLugarNacimiento.Text.ToUpper
                .PropPERDIRECCION = txtDireccion.Text.ToUpper
                .PropPERHABURBANA = txtUrbanizacion.Text.ToUpper
                .PropUBICODIGO = ddlDistrito.SelectedValue
                .PropPERCORREO = txtCorreoElectronico.Text
                .PropECICODIGO = ddlEstadoCivil.SelectedValue
                .PropPERTELEFONO1 = txtTelefonoCasa.Text
                .PropPERTELEFONO2 = txtTelefonoMovil.Text
                .PropPERTELEFONO3 = txtTelefonoEmergencia.Text
                .PropPERCUENTABANCO = txtCuentaBancaria.Text
                .PropGINCODIGO = ddlGradoInstruccion.SelectedValue
                .PropPERPROFESION = txtProfesion.Text.ToUpper
                If chkLicenciado.Checked Then
                    .PropPERLICENCIADO = 1
                Else
                    .PropPERLICENCIADO = 0
                End If
                .PropPERFUERZAARMADA = txtFuerzaArmada.Text.ToUpper
                .PropPERLIBRETAMILITAR = txtLibretaMilitar.Text.ToUpper
                .PropAFPCODIGO = ddlAfp.SelectedValue
                .PropPERNUMEROAFP = txtCodAfp.Text
                .PropPERNUMEROESSALUD = txtCodEssalud.Text
                .PropPERSUNAT4TA = txtSunatCuarta.Text
                .PropPERGRUPOSANGUINEO = txtGrupoSanguineo.Text
                If txtTalla.Text.Length = 0 Then
                    .PropPERTALLA = Nothing
                Else
                    If IsNumeric(txtTalla.Text) Then
                        .PropPERTALLA = Decimal.Parse(txtTalla.Text)
                    Else
                        .PropPERTALLA = Nothing
                    End If
                End If

                If txtPeso.Text.Length = 0 Then
                    .PropPERPESO = Nothing
                Else
                    If IsNumeric(txtPeso.Text) Then
                        .PropPERPESO = Decimal.Parse(txtPeso.Text)
                    Else
                        .PropPERPESO = Nothing
                    End If
                End If
                .PropPERCURSOS = txtCursosRealizados.Text.ToUpper
                .PropPERFOTO = Nothing
                If (txtFecIngresoMunicipalidad.Text = "__/__/____" Or txtFecIngresoMunicipalidad.Text.Length = 0) Then
                    .PropPERFECINGMUNI = Nothing
                Else
                    .PropPERFECINGMUNI = Date.Parse(txtFecIngresoMunicipalidad.Text)
                End If
                .PropSBGCODIGO = ddlSubgerencia.SelectedValue
                If (txtFecIngArea.Text = "__/__/____" Or txtFecIngArea.Text.Length = 0) Then
                    .PropPERFECINGAREA = Nothing
                Else
                    .PropPERFECINGAREA = Date.Parse(txtFecIngArea.Text)
                End If
                If ddlModalidadContrato.SelectedValue = 0 Then
                    .PropMODCODIGO = Nothing
                Else
                    .PropMODCODIGO = ddlModalidadContrato.SelectedValue
                End If
                If (txtFecIngModalidad.Text = "__/__/____" Or txtFecIngModalidad.Text.Length = 0) Then
                    .PropPERFECINGMODAL = Nothing
                Else
                    .PropPERFECINGMODAL = Date.Parse(txtFecIngModalidad.Text)
                End If

                If ddlSector.SelectedValue = 0 Then
                    .PropSECCODIGO = Nothing
                Else
                    .PropSECCODIGO = ddlSector.SelectedValue
                End If
                If (txtFecIngSector.Text = "__/__/____" Or txtFecIngSector.Text.Length = 0) Then
                    .PropPERFECINGSECTOR = Nothing
                Else
                    .PropPERFECINGSECTOR = Date.Parse(txtFecIngSector.Text)
                End If

                If ddlCargo.SelectedValue = 0 Then
                    .PropCRGCODIGO = Nothing
                Else
                    .PropCRGCODIGO = ddlCargo.SelectedValue
                End If
                If (txtFecIngCargo.Text = "__/__/____" Or txtFecIngCargo.Text.Length = 0) Then
                    .PropPERFECINGCARGO = Nothing
                Else
                    .PropPERFECINGCARGO = Date.Parse(txtFecIngCargo.Text)
                End If

                If ddlSecuenciaServicio.SelectedValue = 0 Then
                    .PropSSECODIGO = Nothing
                Else
                    .PropSSECODIGO = ddlSecuenciaServicio.SelectedValue
                End If

                If ddlRango.SelectedValue = 0 Then
                    .PropRANCODIGO = Nothing
                Else
                    .PropRANCODIGO = ddlRango.SelectedValue
                End If
                If txtSueldo.Text.Length = 0 Then
                    .PropPERSUELDO = Nothing
                Else
                    If IsNumeric(txtSueldo.Text) Then
                        .PropPERSUELDO = Decimal.Parse(txtSueldo.Text)
                    Else
                        .PropPERSUELDO = Nothing
                    End If
                End If
                .PropPERNUMEBREVAUTO = txtBreveteVehiculo.Text
                If ddlCategoriaVehiculo.SelectedValue = 0 Then
                    .PropCAUCODIGO = Nothing
                Else
                    .PropCAUCODIGO = ddlCategoriaVehiculo.SelectedValue
                End If

                If (txtFecRevalidaVehiculo.Text = "__/__/____" Or txtFecRevalidaVehiculo.Text.Length = 0) Then
                    .PropPERREVABREVAUTO = Nothing
                Else
                    .PropPERREVABREVAUTO = Date.Parse(txtFecRevalidaVehiculo.Text)
                End If
                .PropPERRESTBREVAUTO = txtRestriccionVehiculo.Text.ToUpper
                .PropPERNUMEBREVMOTO = txtBreveteMoto.Text
                If ddlCategoriaMoto.SelectedValue = 0 Then
                    .PropCMOCODIGO = Nothing
                Else
                    .PropCMOCODIGO = ddlCategoriaMoto.SelectedValue
                End If

                If (txtFecRevalidaMoto.Text = "__/__/____" Or txtFecRevalidaMoto.Text.Length = 0) Then
                    .PropPERREVABREVMOTO = Nothing
                Else
                    .PropPERREVABREVMOTO = Date.Parse(txtFecRevalidaMoto.Text)
                End If
                .PropPERRESTBREVMOTO = txtRestriccionMoto.Text.ToUpper

                If ddlEstado.SelectedValue = 0 Then
                    .PropPERESTADO = Nothing
                Else
                    .PropPERESTADO = ddlEstado.SelectedValue
                End If

                If (txtFecUltimoEstado.Text = "__/__/____" Or txtFecUltimoEstado.Text.Length = 0) Then
                    .PropPERFECESTADO = Nothing
                Else
                    .PropPERFECESTADO = Date.Parse(txtFecUltimoEstado.Text)
                End If
                .Propturcodigo = Nothing
                .PropAUDUSUCREACION = Session("Usuario")
                .PropAUDFECCREACION = Date.Now
                .PropAUDEQPCREACION = Session("equipo")
                .PropAUDROLCREACION = Session("Rol")
                .PropAUDPRGCREACION = Session("proyecto")
                .PropAUDUSUMODIF = Session("Usuario")
                .PropAUDFECMODIF = Date.Now
                .PropAUDEQPMODIF = Session("equipo")
                .PropAUDROLMODIF = Session("Rol")
                .PropAUDPRGMODIF = Session("proyecto")
            End With
            If txtCodigo.Text.Length = 0 Then
                codigo = oCCOPERSONAL_BL.Insertar(oCCOPERSONAL_BE)
                ViewState("INTPERCODIGO") = codigo
                txtCodigo.Text = codigo
            Else
                oCCOPERSONAL_BL.Actualizar(oCCOPERSONAL_BE)
            End If
            lblMensajeSistema.Text = "Se has realizado el proceso satisfactoriamente"
            MostrarPopup("mensaje")
        Catch ex As Exception
            BloquearDIV()
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            Throw ex
        End Try
    End Sub
    Private Sub CargaCombo()
        Dim pCCOTABLA_BE As CCOTABLA_BE = New CCOTABLA_BE
        Dim pCCOTABLA_BL As CCOTABLA_BL = New CCOTABLA_BL
        Dim pCCOPERSONAL_BE As CCOPERSONAL_BE = New CCOPERSONAL_BE
        Dim pCCOPERSONAL_BL As CCOPERSONAL_BL = New CCOPERSONAL_BL
        Dim pCCOCARGOPERSONAL_BL As CCOCARGOPERSONAL_BL = New CCOCARGOPERSONAL_BL
        Dim pCCOCARGOPERSONAL_BE As CCOCARGOPERSONAL_BE = New CCOCARGOPERSONAL_BE
        Dim pCCOSECTOR_BE As CCOSECTOR_BE = New CCOSECTOR_BE
        Dim pCCOSECTOR_BL As CCOSECTOR_BL = New CCOSECTOR_BL
        Dim pCCOSECUENCIASERVICIO_BE As CCOSECUENCIASERVICIO_BE = New CCOSECUENCIASERVICIO_BE
        Dim pCCOSECUENCIASERVICIO_BL As CCOSECUENCIASERVICIO_BL = New CCOSECUENCIASERVICIO_BL

        Try
            ddlDistrito.DataSource = CType(pCCOPERSONAL_BL.ListarCombo, DataSet).Tables(0)
            ddlDistrito.DataTextField = "DESCRIPCION"
            ddlDistrito.DataValueField = "CODIGO"
            ddlDistrito.DataBind()
            ddlDistrito.Items.Insert(0, " (Seleccione) ")
            ddlDistrito.Items(0).Value = ""
            pCCOTABLA_BE.PropTTACODIGO = "ESTADOCIVIL"
            ddlEstadoCivil.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlEstadoCivil.DataTextField = "DESCRIPCION2"
            ddlEstadoCivil.DataValueField = "ID"
            ddlEstadoCivil.DataBind()
            ddlEstadoCivil.Items.Insert(0, " (Seleccione) ")
            ddlEstadoCivil.Items(0).Value = 0
            pCCOTABLA_BE.PropTTACODIGO = "AFP"
            ddlAfp.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlAfp.DataTextField = "DESCRIPCION2"
            ddlAfp.DataValueField = "ID"
            ddlAfp.DataBind()
            ddlAfp.Items.Insert(0, " (Seleccione) ")
            ddlAfp.Items(0).Value = 0
            pCCOTABLA_BE.PropTTACODIGO = "GRADOINSTRUCCION"
            ddlGradoInstruccion.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlGradoInstruccion.DataTextField = "DESCRIPCION2"
            ddlGradoInstruccion.DataValueField = "ID"
            ddlGradoInstruccion.DataBind()
            ddlGradoInstruccion.Items.Insert(0, " (Seleccione) ")
            ddlGradoInstruccion.Items(0).Value = 0
            pCCOTABLA_BE.PropTTACODIGO = "MODALIDADCONTRATO"
            ddlModalidadContrato.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlModalidadContrato.DataTextField = "DESCRIPCION2"
            ddlModalidadContrato.DataValueField = "ID"
            ddlModalidadContrato.DataBind()
            ddlModalidadContrato.Items.Insert(0, " (Seleccione) ")
            ddlModalidadContrato.Items(0).Value = 0
            pCCOTABLA_BE.PropTTACODIGO = "ESTADOGENERICO1"
            ddlEstado.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlEstado.DataTextField = "DESCRIPCION2"
            ddlEstado.DataValueField = "ID"
            ddlEstado.DataBind()
            ddlEstado.Items.Insert(0, " (Seleccione) ")
            ddlEstado.Items(0).Value = 0
            pCCOTABLA_BE.PropTTACODIGO = "RANGOPERSONAL"
            ddlRango.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlRango.DataTextField = "DESCRIPCION2"
            ddlRango.DataValueField = "ID"
            ddlRango.DataBind()
            ddlRango.Items.Insert(0, " (Seleccione) ")
            ddlRango.Items(0).Value = 0
            pCCOTABLA_BE.PropTTACODIGO = "SUBGERENCIA"
            ddlSubgerencia.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlSubgerencia.DataTextField = "DESCRIPCION2"
            ddlSubgerencia.DataValueField = "ID"
            ddlSubgerencia.DataBind()
            ddlSubgerencia.Items.Insert(0, " (Seleccione) ")
            ddlSubgerencia.Items(0).Value = 0

            pCCOTABLA_BE.PropTTACODIGO = "CATEGORIAAUTO"
            ddlCategoriaVehiculo.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlCategoriaVehiculo.DataTextField = "DESCRIPCION2"
            ddlCategoriaVehiculo.DataValueField = "ID"
            ddlCategoriaVehiculo.DataBind()
            ddlCategoriaVehiculo.Items.Insert(0, " (Seleccione) ")
            ddlCategoriaVehiculo.Items(0).Value = 0
            pCCOTABLA_BE.PropTTACODIGO = "CATEGORIAMOTO"
            ddlCategoriaMoto.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlCategoriaMoto.DataTextField = "DESCRIPCION2"
            ddlCategoriaMoto.DataValueField = "ID"
            ddlCategoriaMoto.DataBind()
            ddlCategoriaMoto.Items.Insert(0, " (Seleccione) ")
            ddlCategoriaMoto.Items(0).Value = 0
            pCCOTABLA_BE.PropTTACODIGO = "PARENTESCO"
            ddlParentesco.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlParentesco.DataTextField = "DESCRIPCION2"
            ddlParentesco.DataValueField = "ID"
            ddlParentesco.DataBind()
            'ddlParentesco.Items.Insert(0, " (Seleccione) ")
            'ddlParentesco.Items(0).Value = 0

            pCCOCARGOPERSONAL_BE.PropCRGCODIGO = 0
            pCCOCARGOPERSONAL_BE.PropCRGDESCRIPCION = String.Empty
            ddlCargo.DataSource = pCCOCARGOPERSONAL_BL.Listar(pCCOCARGOPERSONAL_BE)
            ddlCargo.DataTextField = "VCHCRGDESCRIPCION"
            ddlCargo.DataValueField = "SMLCRGCODIGO"
            ddlCargo.DataBind()
            ddlCargo.Items.Insert(0, " (Seleccione) ")
            ddlCargo.Items(0).Value = 0

            ddlSector.DataSource = pCCOSECTOR_BL.ListarCombo()
            ddlSector.DataTextField = "PropSECDESCRIPCION"
            ddlSector.DataValueField = "PropSECCODIGO"
            ddlSector.DataBind()
            ddlSector.Items.Insert(0, " (Seleccione) ")
            ddlSector.Items(0).Value = 0

            pCCOSECUENCIASERVICIO_BE.PropSSECODIGO = 0
            ddlSecuenciaServicio.DataSource = pCCOSECUENCIASERVICIO_BL.Listar(pCCOSECUENCIASERVICIO_BE)
            ddlSecuenciaServicio.DataTextField = "VCHSSEDESCRIPCION"
            ddlSecuenciaServicio.DataValueField = "SMLSSECODIGO"
            ddlSecuenciaServicio.DataBind()
            ddlSecuenciaServicio.Items.Insert(0, " (Seleccione) ")
            ddlSecuenciaServicio.Items(0).Value = 0
        Catch ex As Exception
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            Throw ex
        End Try
    End Sub
    Private Sub CargarFicha()
        Dim oCCOPERSONAL_BE As CCOPERSONAL_BE = New CCOPERSONAL_BE
        Dim oCCOPERSONAL_BL As CCOPERSONAL_BL = New CCOPERSONAL_BL

        oCCOPERSONAL_BE.PropPERCODIGO = Integer.Parse(ViewState("INTPERCODIGO"))
        oCCOPERSONAL_BE = oCCOPERSONAL_BL.ListarKey(oCCOPERSONAL_BE)

        With oCCOPERSONAL_BE
            txtCodigo.Text = .PropPERCODIGO
            txtAPellidoPaterno.Text = .PropPERAPELLIDOPATERNO
            txtApellidoMaterno.Text = .PropPERAPELLIDOMATERNO
            txtNombres.Text = .PropPERNOMBRE
            txtDNI.Text = .PropPERDNI
            txtRuc.Text = .PropPERRUC
            If Not .PropPERFECNACIMIENTO Is Nothing Then
                txtFechaNacimiento.Text = .PropPERFECNACIMIENTO
            End If
            txtLugarNacimiento.Text = .PropPERLUGNACIMIENTO
            txtDireccion.Text = .PropPERDIRECCION
            txtUrbanizacion.Text = .PropPERHABURBANA
            If Not .PropUBICODIGO Is Nothing Then
                ddlDistrito.SelectedValue = .PropUBICODIGO
            End If

            txtCorreoElectronico.Text = .PropPERCORREO
            If Not .PropECICODIGO Is Nothing Then
                ddlEstadoCivil.SelectedValue = .PropECICODIGO
            End If
            txtTelefonoCasa.Text = .PropPERTELEFONO1
            txtTelefonoMovil.Text = .PropPERTELEFONO2
            txtTelefonoEmergencia.Text = .PropPERTELEFONO3
            txtCuentaBancaria.Text = .PropPERCUENTABANCO
            If Not .PropGINCODIGO Is Nothing Then
                ddlGradoInstruccion.SelectedValue = .PropGINCODIGO
            End If
            txtProfesion.Text = .PropPERPROFESION
            If .PropPERLICENCIADO = 1 Then
                chkLicenciado.Checked = True
            Else
                chkLicenciado.Checked = False
            End If
            txtFuerzaArmada.Text = .PropPERFUERZAARMADA
            txtLibretaMilitar.Text = .PropPERLIBRETAMILITAR
            If Not .PropAFPCODIGO Is Nothing Then
                ddlAfp.SelectedValue = .PropAFPCODIGO
            End If
            txtCodAfp.Text = .PropPERNUMEROAFP
            txtCodEssalud.Text = .PropPERNUMEROESSALUD
            txtSunatCuarta.Text = .PropPERSUNAT4TA
            txtGrupoSanguineo.Text = .PropPERGRUPOSANGUINEO
            If Not .PropPERTALLA Is Nothing Then
                txtTalla.Text = .PropPERTALLA
            End If

            If Not .PropPERPESO Is Nothing Then
                txtPeso.Text = .PropPERPESO
            End If
            txtCursosRealizados.Text = .PropPERCURSOS

            If Not .PropPERFECINGMUNI Is Nothing Then
                txtFecIngresoMunicipalidad.Text = .PropPERFECINGMUNI
            End If
            If Not .PropSBGCODIGO Is Nothing Then
                ddlSubgerencia.SelectedValue = .PropSBGCODIGO
            End If

            If Not .PropPERFECINGAREA Is Nothing Then
                txtFecIngArea.Text = .PropPERFECINGAREA
            End If
            If Not .PropMODCODIGO Is Nothing Then
                ddlModalidadContrato.SelectedValue = .PropMODCODIGO
            End If

            If Not .PropPERFECINGMODAL Is Nothing Then
                txtFecIngModalidad.Text = .PropPERFECINGMODAL
            End If
            If Not .PropSECCODIGO Is Nothing Then
                ddlSector.SelectedValue = .PropSECCODIGO
            End If
            If Not .PropPERFECINGSECTOR Is Nothing Then
                txtFecIngSector.Text = .PropPERFECINGSECTOR
            End If

            If Not .PropCRGCODIGO Is Nothing Then
                ddlCargo.SelectedValue = .PropCRGCODIGO
            End If

            If Not .PropPERFECINGCARGO Is Nothing Then
                txtFecIngCargo.Text = .PropPERFECINGCARGO
            End If

            If Not .PropSSECODIGO Is Nothing Then
                ddlSecuenciaServicio.SelectedValue = .PropSSECODIGO
            End If
            If Not .PropRANCODIGO Is Nothing Then
                ddlRango.SelectedValue = .PropRANCODIGO
            End If
            If Not .PropPERSUELDO Is Nothing Then
                txtSueldo.Text = .PropPERSUELDO
            End If
            txtBreveteVehiculo.Text = .PropPERNUMEBREVAUTO
            If Not .PropCAUCODIGO Is Nothing Then
                ddlCategoriaVehiculo.SelectedValue = .PropCAUCODIGO
            End If

            If Not .PropPERREVABREVAUTO Is Nothing Then
                txtFecRevalidaVehiculo.Text = .PropPERREVABREVAUTO
            End If

            txtRestriccionVehiculo.Text = .PropPERRESTBREVAUTO
            txtBreveteMoto.Text = .PropPERNUMEBREVMOTO
            If Not .PropCMOCODIGO Is Nothing Then
                ddlCategoriaMoto.SelectedValue = .PropCMOCODIGO
            End If
            If Not .PropPERREVABREVMOTO Is Nothing Then
                txtFecRevalidaMoto.Text = .PropPERREVABREVMOTO
            End If

            txtRestriccionMoto.Text = .PropPERRESTBREVMOTO
            If Not .PropPERESTADO Is Nothing Then
                ddlEstado.SelectedValue = .PropPERESTADO
            End If

            If Not .PropPERFECESTADO Is Nothing Then
                txtFecUltimoEstado.Text = .PropPERFECESTADO
            End If
        End With


    End Sub

    Protected Sub btnRedirecciona_Click(sender As Object, e As System.EventArgs) Handles btnRedirecciona.Click
        DesBloquearDIV()
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        Response.Redirect("frmGestionaPersonal.aspx")
    End Sub

    Private Sub MostrarFoto()
        Dim archivo As String = "PER_" & txtCodigo.Text.Trim & ".jpg"
        Dim sb As New StringBuilder
        sb.AppendLine("document.getElementById(""holder"").style.backgroundImage =url(fotos/" & archivo & "); ")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub

    Private Sub CargaGrillaFamiliar()
        Try
            Dim dt As DataTable = New DataTable
            Dim codigo As Integer = ViewState("INTPERCODIGO")
            Dim oCCOPERSONALFAMILIA_BE As CCOPERSONALFAMILIA_BE = New CCOPERSONALFAMILIA_BE
            Dim oCCOPERSONALFAMILIA_BL As CCOPERSONALFAMILIA_BL = New CCOPERSONALFAMILIA_BL
            oCCOPERSONALFAMILIA_BE.PropPERCODIGO = codigo
            dt = oCCOPERSONALFAMILIA_BL.Listar(oCCOPERSONALFAMILIA_BE)
            ViewState("dtFamiliar") = dt
            gvFamiliar.DataSource = dt
            gvFamiliar.DataBind()
        Catch ex As Exception
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            Throw ex
        End Try
    End Sub

    Protected Sub btnAgregaFamiliar_Click(sender As Object, e As System.EventArgs) Handles btnAgregaFamiliar.Click
        Dim codigo As Integer = ViewState("INTPERCODIGO")
        Dim oCCOPERSONALFAMILIA_BE As CCOPERSONALFAMILIA_BE = New CCOPERSONALFAMILIA_BE
        Dim oCCOPERSONALFAMILIA_BL As CCOPERSONALFAMILIA_BL = New CCOPERSONALFAMILIA_BL
        With oCCOPERSONALFAMILIA_BE
            .PropPFACODIGO = 0
            .PropPERCODIGO = codigo
            .PropPARCODIGO = ddlParentesco.SelectedValue
            .PropPFANOMBRE = txtNombreFamiliar.Text.ToUpper
        End With
        oCCOPERSONALFAMILIA_BL.Insertar(oCCOPERSONALFAMILIA_BE)
        CargaGrillaFamiliar()
        DesBloquearDIV()
    End Sub

    Protected Sub gvFamiliar_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvFamiliar.SelectedIndexChanged
        Try
            If gvFamiliar.SelectedIndex = -1 Then
                Util.MSG_ALERTA("Seleccione el item que desea eliminar", Me)
                Exit Sub
            End If

            Dim dt As DataTable = CType(ViewState("dtFamiliar"), DataTable)
            Dim oCCOPERSONALFAMILIA_BE As CCOPERSONALFAMILIA_BE = New CCOPERSONALFAMILIA_BE
            Dim oCCOPERSONALFAMILIA_BL As CCOPERSONALFAMILIA_BL = New CCOPERSONALFAMILIA_BL

            oCCOPERSONALFAMILIA_BE.PropPFACODIGO = dt.Rows(gvFamiliar.SelectedIndex).Item("INTPFACODIGO")
            oCCOPERSONALFAMILIA_BL.Eliminar(oCCOPERSONALFAMILIA_BE)
            CargaGrillaFamiliar()
            DesBloquearDIV()
        Catch ex As Exception
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            Throw ex
        End Try

    End Sub
End Class
