Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data
Partial Class frmGestionaPersonal
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        txtCodgoBusca.Attributes.Add("onkeypress", "javascript:return solonumeros(event);")
        txtDniBusca.Attributes.Add("onkeypress", "javascript:return solonumeros(event);")
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: GESTION DE PERSONAL"
            Session("activo") = "3"
            CargaCombo()
            CargaGrilla()
            ViewState("INTPERCODIGO") = 0
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        cargaGrilla()
    End Sub
    Private Sub CargaGrilla()

        Dim pCCOPERSONAL_BE As CCOPERSONAL_BE = New CCOPERSONAL_BE
        Dim pCCOPERSONAL_BL As CCOPERSONAL_BL = New CCOPERSONAL_BL
        Dim oUtil As Util = New Util
        Try
            With pCCOPERSONAL_BE
                .PropPERCODIGO = oUtil.nNulo(txtDniBusca.Text)
                .PropPERAPELLIDOPATERNO = txtApePaternoBusca.Text.ToUpper
                .PropPERAPELLIDOMATERNO = txtApeMaternoBusca.Text.ToUpper
                .PropPERNOMBRE = txtNombreBusca.Text.ToUpper
                .PropPERDNI = txtDniBusca.Text
                .PropUBICODIGO = ddlDistritoBusca.SelectedValue
                .PropECICODIGO = ddlEstadoCivilBusca.SelectedValue
                .PropGINCODIGO = ddlGradoinstruccionBusca.SelectedValue
                .PropAFPCODIGO = ddlAfpBusca.SelectedValue
                .PropMODCODIGO = ddlModalidadContratoBusca.SelectedValue
                .PropSECCODIGO = ddlSectorBusca.SelectedValue
                .PropCRGCODIGO = ddlCargoBusca.SelectedValue
                .PropPERESTADO = ddlEstadoBusca.SelectedValue
            End With
            Dim dt As DataTable = New DataTable
            dt = pCCOPERSONAL_BL.ListarBusqueda(pCCOPERSONAL_BE)
            ViewState("dtDatos") = dt
            gvDatos.DataSource = dt
            gvDatos.DataBind()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub
    Private Sub CargaCombo()
        Dim pCCOPERSONAL_BE As CCOPERSONAL_BE = New CCOPERSONAL_BE
        Dim pCCOPERSONAL_BL As CCOPERSONAL_BL = New CCOPERSONAL_BL
        Dim pCCOTABLA_BE As CCOTABLA_BE = New CCOTABLA_BE
        Dim pCCOTABLA_BL As CCOTABLA_BL = New CCOTABLA_BL
        Dim pCCOCARGOPERSONAL_BL As CCOCARGOPERSONAL_BL = New CCOCARGOPERSONAL_BL
        Dim pCCOCARGOPERSONAL_BE As CCOCARGOPERSONAL_BE = New CCOCARGOPERSONAL_BE
        Dim pCCOSECTOR_BE As CCOSECTOR_BE = New CCOSECTOR_BE
        Dim pCCOSECTOR_BL As CCOSECTOR_BL = New CCOSECTOR_BL



        Try

            ddlDistritoBusca.DataSource = CType(pCCOPERSONAL_BL.ListarCombo, DataSet).Tables(0)
            ddlDistritoBusca.DataTextField = "DESCRIPCION"
            ddlDistritoBusca.DataValueField = "CODIGO"
            ddlDistritoBusca.DataBind()
            ddlDistritoBusca.Items.Insert(0, " (Todos) ")
            ddlDistritoBusca.Items(0).Value = ""

            pCCOTABLA_BE.PropTTACODIGO = "ESTADOCIVIL"
            ddlEstadoCivilBusca.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlEstadoCivilBusca.DataTextField = "DESCRIPCION2"
            ddlEstadoCivilBusca.DataValueField = "ID"
            ddlEstadoCivilBusca.DataBind()
            ddlEstadoCivilBusca.Items.Insert(0, " (Todos) ")
            ddlEstadoCivilBusca.Items(0).Value = 0
            pCCOTABLA_BE.PropTTACODIGO = "AFP"
            ddlAfpBusca.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlAfpBusca.DataTextField = "DESCRIPCION2"
            ddlAfpBusca.DataValueField = "ID"
            ddlAfpBusca.DataBind()
            ddlAfpBusca.Items.Insert(0, " (Todos) ")
            ddlAfpBusca.Items(0).Value = 0
            pCCOTABLA_BE.PropTTACODIGO = "GRADOINSTRUCCION"
            ddlGradoinstruccionBusca.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlGradoinstruccionBusca.DataTextField = "DESCRIPCION2"
            ddlGradoinstruccionBusca.DataValueField = "ID"
            ddlGradoinstruccionBusca.DataBind()
            ddlGradoinstruccionBusca.Items.Insert(0, " (Todos) ")
            ddlGradoinstruccionBusca.Items(0).Value = 0
            pCCOTABLA_BE.PropTTACODIGO = "MODALIDADCONTRATO"
            ddlModalidadContratoBusca.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlModalidadContratoBusca.DataTextField = "DESCRIPCION2"
            ddlModalidadContratoBusca.DataValueField = "ID"
            ddlModalidadContratoBusca.DataBind()
            ddlModalidadContratoBusca.Items.Insert(0, " (Todos) ")
            ddlModalidadContratoBusca.Items(0).Value = 0
            pCCOTABLA_BE.PropTTACODIGO = "ESTADOGENERICO1"
            ddlEstadoBusca.DataSource = pCCOTABLA_BL.Listar(pCCOTABLA_BE)
            ddlEstadoBusca.DataTextField = "DESCRIPCION2"
            ddlEstadoBusca.DataValueField = "ID"
            ddlEstadoBusca.DataBind()
            ddlEstadoBusca.Items.Insert(0, " (Todos) ")
            ddlEstadoBusca.Items(0).Value = 0

            pCCOCARGOPERSONAL_BE.PropCRGCODIGO = 0
            pCCOCARGOPERSONAL_BE.PropCRGDESCRIPCION = String.Empty
            ddlCargoBusca.DataSource = pCCOCARGOPERSONAL_BL.Listar(pCCOCARGOPERSONAL_BE)
            ddlCargoBusca.DataTextField = "VCHCRGDESCRIPCION"
            ddlCargoBusca.DataValueField = "SMLCRGCODIGO"
            ddlCargoBusca.DataBind()
            ddlCargoBusca.Items.Insert(0, " (Todos) ")
            ddlCargoBusca.Items(0).Value = 0

            ddlSectorBusca.DataSource = pCCOSECTOR_BL.ListarCombo()
            ddlSectorBusca.DataTextField = "PropSECDESCRIPCION"
            ddlSectorBusca.DataValueField = "PropSECCODIGO"
            ddlSectorBusca.DataBind()
            ddlSectorBusca.Items.Insert(0, " (Todos) ")
            ddlSectorBusca.Items(0).Value = 0

        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub


    Protected Sub gvDatos_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatos.PageIndexChanging
        gvDatos.PageIndex = e.NewPageIndex
        CargaGrilla()
    End Sub


    Protected Sub gvDatos_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowCreated
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

    Protected Sub gvDatos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvDatos.SelectedIndexChanged
        Dim dk As DataKey = Me.gvDatos.DataKeys(gvDatos.SelectedIndex) '-- es la fila de la grilla 
        Dim intID As Integer = dk.Item("INTPERCODIGO")  ' se pone el nombre de la llave 
        ViewState("INTPERCODIGO") = intID
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As System.EventArgs) Handles btnNuevo.Click
        Response.Redirect("frmRegistraPersonal.aspx?id=0")
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As System.EventArgs) Handles btnModificar.Click
        If (ViewState("INTPERCODIGO") Is Nothing Or ViewState("INTPERCODIGO") = 0) Then
            Exit Sub
        End If
        Response.Redirect("frmRegistraPersonal.aspx?id=" & ViewState("INTPERCODIGO"))
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As System.EventArgs) Handles btnEliminar.Click
        If (ViewState("INTPERCODIGO") Is Nothing Or ViewState("INTPERCODIGO") = 0) Then
            Exit Sub
        End If
        Dim oCCOPERSONAL_BE As CCOPERSONAL_BE = New CCOPERSONAL_BE
        Dim oCCOPERSONAL_BL As CCOPERSONAL_BL = New CCOPERSONAL_BL
        Dim codigo As Integer = ViewState("INTPERCODIGO")
        oCCOPERSONAL_BE.PropPERCODIGO = codigo
        oCCOPERSONAL_BL.Eliminar(oCCOPERSONAL_BE)
        CargaGrilla()
    End Sub
End Class
