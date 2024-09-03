Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data
Partial Class frmGestionaTipificacion
    Inherits System.Web.UI.Page
    Dim oCCOTIPOINCIDENCIA_BE As New CCOTIPOINCIDENCIA_BE
    Dim oCCOTIPOINCIDENCIA_BL As New CCOTIPOINCIDENCIA_BL
    Dim oCCOSUBTIPOINCIDENCIA_BE As New CCOSUBTIPOINCIDENCIA_BE
    Dim oCCOSUBTIPOINCIDENCIA_BL As New CCOSUBTIPOINCIDENCIA_BL
    Dim oCCOPRIORIDADINCIDENCIA_BL As New CCOPRIORIDADINCIDENCIA_BL


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: MANTENIMIENTO DE TIPOS Y SUBTIPOS"
            CargaCombos()
            CargaGrilla()

        End If
    End Sub
    Private Sub CargaCombos()

        Dim oESTADO_BL As New CCOTABLA_BL
        Dim oESTADO_BE As New CCOTABLA_BE
        Dim oCCOCLASEINCIDENCIA_BL As New CCOCLASEINCIDENCIA_BL
        oESTADO_BE.PropTTACODIGO = "ESTADOGENERICO1"
        ddlEstadoBus.DataSource = oESTADO_BL.Listar(oESTADO_BE)
        ddlEstadoBus.DataTextField = "DESCRIPCION"
        ddlEstadoBus.DataValueField = "ID"
        ddlEstadoBus.DataBind()
        ddlEstadoBus.Items.Insert(0, "(Todos)")
        ddlEstadoBus.Items(0).Value = -1

        ddlEstadoAdd.DataSource = oESTADO_BL.Listar(oESTADO_BE)
        ddlEstadoAdd.DataTextField = "DESCRIPCION"
        ddlEstadoAdd.DataValueField = "ID"
        ddlEstadoAdd.DataBind()
        'ddlEstOperadorAdd.Items.Insert(0, "(Seleccione)")
        'ddlEstOperadorAdd.Items(0).Value = -1

        ddlClasificaBus.DataSource = oCCOCLASEINCIDENCIA_BL.ListarCombo
        ddlClasificaBus.DataTextField = "VCHCINDESCRIPCION"
        ddlClasificaBus.DataValueField = "SMLCINCODIGO"
        ddlClasificaBus.DataBind()
        ddlClasificaBus.Items.Insert(0, "(Todos)")
        ddlClasificaBus.Items(0).Value = 0

        ddlClasificaAdd.DataSource = oCCOCLASEINCIDENCIA_BL.ListarCombo
        ddlClasificaAdd.DataTextField = "VCHCINDESCRIPCION"
        ddlClasificaAdd.DataValueField = "SMLCINCODIGO"
        ddlClasificaAdd.DataBind()
        ddlClasificaAdd.Items.Insert(0, "(Seleccione)")
        ddlClasificaAdd.Items(0).Value = 0


        With ddlPrioridadSubtipoEdit
            .DataSource = oCCOPRIORIDADINCIDENCIA_BL.ListarCombo()
            .DataTextField = "PropPRIDESCRIPCION"
            .DataValueField = "PropPRICODIGO"
        End With
        ddlPrioridadSubtipoEdit.DataBind()
        ddlPrioridadSubtipoEdit.Items.Insert(0, New ListItem("(Seleccione)", "0"))



        ddlEstadoSubtipoEdit.DataSource = oESTADO_BL.Listar(oESTADO_BE)
        ddlEstadoSubtipoEdit.DataTextField = "DESCRIPCION"
        ddlEstadoSubtipoEdit.DataValueField = "ID"
        ddlEstadoSubtipoEdit.DataBind()
        'ddlEstOperadorAdd.Items.Insert(0, "(Seleccione)")
        'ddlEstOperadorAdd.Items(0).Value = -1



    End Sub

    Private Sub CargaGrilla()
        Dim oCCOTIPOINCIDENCIA_BL As New CCOTIPOINCIDENCIA_BL
        Dim oCCOTIPOINCIDENCIA_BE As New CCOTIPOINCIDENCIA_BE

        Try
            If txtCodigoBus.Text.Trim = "" Then
                oCCOTIPOINCIDENCIA_BE.PropTINCODIGO = 0
            Else
                oCCOTIPOINCIDENCIA_BE.PropTINCODIGO = CType(txtCodigoBus.Text.Trim, Integer)
            End If


            oCCOTIPOINCIDENCIA_BE.PropTINDESCRIPCION = txtDescripBus.Text.ToUpper
            oCCOTIPOINCIDENCIA_BE.PropTINESTADO = ddlEstadoBus.SelectedValue
            oCCOTIPOINCIDENCIA_BE.PropCINCODIGO = ddlClasificaBus.SelectedValue

            Dim dt As DataTable = New DataTable
            dt = oCCOTIPOINCIDENCIA_BL.Busqueda(oCCOTIPOINCIDENCIA_BE)
            ViewState("dt") = dt
            gvDatos.DataSource = dt
            gvDatos.DataBind()
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub gvDatos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            'Dim ddlEstado As DropDownList = CType(e.Row.FindControl("ddlEstadoEstacion"), DropDownList)
            'Dim hfSEstado As HiddenField = CType(e.Row.FindControl("hfEstadoEstacion"), HiddenField)

            'Dim oESTADO_BL As New CCOTABLA_BL
            'Dim oESTADO_BE As New CCOTABLA_BE

            'oESTADO_BE.PropTTACODIGO = "ESTADOGENERICO1"
            'With ddlEstado
            '    .DataSource = oESTADO_BL.Listar(oESTADO_BE)
            '    .DataTextField = "DESCRIPCION"
            '    .DataValueField = "ID"
            'End With
            'ddlEstado.DataBind()
            'ddlEstado.Items.Insert(0, New ListItem("(Ninguno)", "0"))
            'If (hfSEstado IsNot Nothing) Then
            '    ddlEstado.SelectedValue = hfSEstado.Value
            'End If

        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargaGrilla()
    End Sub


    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        MostrarPopup("agregarOperador")
        txtTipoAdd.Focus()
    End Sub


    Protected Sub btnAgregarCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarCancelar.Click
        Try
            CerrarPopup("agregarOperador")
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub



    Private Sub MostrarPopup(ByVal pdiv As String)
        Dim sb As New StringBuilder
        sb.AppendLine("javascript:void(0);")
        sb.AppendLine("document.getElementById('" & pdiv & "').style.display='block';document.getElementById('fade').style.display='block';")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub

    Private Sub CerrarPopup(ByVal pdiv As String)
        Dim sb As New StringBuilder
        sb.AppendLine("javascript:void(0);")
        sb.AppendLine("document.getElementById('" & pdiv & "').style.display='none';document.getElementById('fade').style.display='none';")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub

    Protected Sub btnAgregarAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarAceptar.Click
        Dim oCCOTIPOINCIDENCIA_BE As New CCOTIPOINCIDENCIA_BE
        Dim oCCOTIPOINCIDENCIA_BL As New CCOTIPOINCIDENCIA_BL
        Try
            'If (txtEstacionAdd.Text = String.Empty Or txtEstacionAdd.Text = "Estación") Then
            'Exit Sub
            'End If

            oCCOTIPOINCIDENCIA_BE.PropTINCODIGO = 0
            oCCOTIPOINCIDENCIA_BE.PropTINDESCRIPCION = txtDescripcionAdd.Text.ToUpper
            oCCOTIPOINCIDENCIA_BE.PropCINCODIGO = ddlClasificaAdd.SelectedValue
            oCCOTIPOINCIDENCIA_BE.PropTINESTADO = ddlEstadoAdd.SelectedValue
            oCCOTIPOINCIDENCIA_BE.PropAUDUSUCREACION = CType(Session("Usuario"), String)
            oCCOTIPOINCIDENCIA_BE.PropAUDPRGCREACION = CType(Session("proyecto"), String)
            oCCOTIPOINCIDENCIA_BE.PropAUDEQPCREACION = CType(Session("equipo"), String)
            oCCOTIPOINCIDENCIA_BE.PropAUDFECCREACION = Now.Date

            oCCOTIPOINCIDENCIA_BL.Insertar(oCCOTIPOINCIDENCIA_BE)
            CargaGrilla()
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub




    Protected Sub btnEliminarEstacion_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tabla As Tabla = New Tabla
        tabla.Datos = CType(ViewState("dt"), DataTable)
        Try
            Dim gwrow As GridViewRow = CType(CType(sender, Button).NamingContainer, GridViewRow)
            Dim oSCUESTACION_BL As New SCUESTACION_BL
            Dim oSCUESTACION_BE As New SCUESTACION_BE

            oSCUESTACION_BE.PropESTCNUMIP = tabla.Datos.Rows(gwrow.DataItemIndex).Item("VCHESTCNUMIP")

            oSCUESTACION_BL.Eliminar(oSCUESTACION_BE)
            CargaGrilla()
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub


    Protected Sub ddlEstadoEstacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tabla As Tabla = New Tabla
        tabla.Datos = CType(ViewState("dt"), DataTable)
        Try
            Dim gwrow As GridViewRow = CType(CType(sender, DropDownList).NamingContainer, GridViewRow)
            Dim ddlEstacion As DropDownList = CType(sender, DropDownList)
            Dim oSCUESTACION_BL As New SCUESTACION_BL
            Dim oSCUESTACION_BE As New SCUESTACION_BE

            Dim oEstacion As String = tabla.Datos.Rows(gwrow.DataItemIndex).Item("VCHESTCNUMIP")

            oSCUESTACION_BE.PropESTCNUMIP = oEstacion
            oSCUESTACION_BE.PropESTCESTADO = ddlEstacion.SelectedValue
            oSCUESTACION_BE.PropAUDUSUMODIF = CType(Session("Usuario"), String)
            oSCUESTACION_BE.PropAUDFECMODIF = Now.Date
            oSCUESTACION_BE.PropAUDPRGMODIF = CType(Session("proyecto"), String)
            oSCUESTACION_BE.PropAUDEQPMODIF = CType(Session("equipo"), String)

            oSCUESTACION_BL.Actualizar(oSCUESTACION_BE)
            CargaGrilla()

        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub

    Protected Sub btnTipoDetalle_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim tabla As Tabla = New Tabla
        'tabla.Datos = CType(ViewState("dt"), DataTable)
        'Try
        '    Dim gwrow As GridViewRow = CType(CType(sender, Button).NamingContainer, GridViewRow)
        '    Dim oSYS_BL As SYSESTACION_BL = New SYSESTACION_BL

        '    Dim oUsuario As String = tabla.Datos.Rows(gwrow.DataItemIndex).Item("USUARIO")
        '    oSYS_BL.LiberarAlerta(0, oUsuario)
        '    CargaGrilla()
        'Catch ex As Exception
        '    lblMensajeError.Text = ex.Message
        'End Try
        pnlDetalle.Visible = True
        pnlBusqueda.Visible = False

    End Sub


    Protected Sub btnEditar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        pnlDetalle.Visible = True
        pnlBusqueda.Visible = False

        Dim tabla As Tabla = New Tabla
        tabla.Datos = CType(ViewState("dt"), DataTable)
        Try
            Dim gwrow As GridViewRow = CType(CType(sender, Button).NamingContainer, GridViewRow)
            Dim vTIPO As String = tabla.Datos.Rows(gwrow.DataItemIndex).Item("SMLTINCODIGO")
            hfCodTipo.Value = vTIPO
            txtCodTipoEdit.Text = vTIPO
            txtDesTipoEdit.Text = tabla.Datos.Rows(gwrow.DataItemIndex).Item("VCHTINDESCRIPCION")
            txtClaseEdit.Text = tabla.Datos.Rows(gwrow.DataItemIndex).Item("VCHCINDESCRIPCION")
            txtEstadoEdit.Text = tabla.Datos.Rows(gwrow.DataItemIndex).Item("SMLTINESTADO")

            CargarGrillaDetalle()


        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub CargarGrillaDetalle()
        Dim dtDET As New DataTable
        oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = hfCodTipo.Value

        dtDET = oCCOSUBTIPOINCIDENCIA_BL.Listar(oCCOSUBTIPOINCIDENCIA_BE)
        ViewState("dtDET") = dtDET
        gvDetalle.DataSource = dtDET
        gvDetalle.DataBind()
        If dtDET.Rows.Count > 0 Then
            Me.btnAddSubtipoCab.Visible = False
        Else
            Me.btnAddSubtipoCab.Visible = True
        End If

    End Sub

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        pnlDetalle.Visible = False
        pnlBusqueda.Visible = True
    End Sub

    Protected Sub btnAddSubtipo_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim vTIPO As String = txtCodTipoEdit.Text
        Dim vSUBTIPO As String = CType(sender, Button).Text

        If vSUBTIPO = "+" Then
            oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = vTIPO
            oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = 0
            txtSubtipoEdit.Text = 0
            txtDescSubtipoEdit.Text = ""
            ddlPrioridadSubtipoEdit.SelectedValue = 0
            ddlEstadoSubtipoEdit.SelectedValue = 0
            MostrarPopup("editarSubtipo")
        Else
            oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = vTIPO
            oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = vSUBTIPO
            Dim tablaD As Tabla = New Tabla
            tablaD.Datos = CType(ViewState("dtDET"), DataTable)
            Dim gwrow As GridViewRow = CType(CType(sender, Button).NamingContainer, GridViewRow)

            txtSubtipoEdit.Text = tablaD.Datos.Rows(gwrow.DataItemIndex).Item("SMLSTICODIGO")
            txtDescSubtipoEdit.Text = tablaD.Datos.Rows(gwrow.DataItemIndex).Item("VCHSTIDESCRIPCION")
            ddlPrioridadSubtipoEdit.SelectedValue = tablaD.Datos.Rows(gwrow.DataItemIndex).Item("SMLPRICODIGO")
            ddlEstadoSubtipoEdit.SelectedValue = tablaD.Datos.Rows(gwrow.DataItemIndex).Item("SMLSTIESTADO")

            MostrarPopup("editarSubtipo")
        End If

    End Sub

    Protected Sub btnAceptarEditSubtipo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptarEditSubtipo.Click
        Try

            oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = hfCodTipo.Value
            oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = txtSubtipoEdit.Text
            oCCOSUBTIPOINCIDENCIA_BE.PropPRICODIGO = ddlPrioridadSubtipoEdit.SelectedValue
            oCCOSUBTIPOINCIDENCIA_BE.PropSTIDESCRIPCION = txtDescSubtipoEdit.Text.ToUpper
            oCCOSUBTIPOINCIDENCIA_BE.PropSTIESTADO = ddlEstadoSubtipoEdit.SelectedValue


            oCCOSUBTIPOINCIDENCIA_BE.PropAUDUSUMODIF = CType(Session("Usuario"), String)
            oCCOSUBTIPOINCIDENCIA_BE.PropAUDFECMODIF = Now.Date
            oCCOSUBTIPOINCIDENCIA_BE.PropAUDPRGMODIF = CType(Session("proyecto"), String)
            oCCOSUBTIPOINCIDENCIA_BE.PropAUDEQPMODIF = CType(Session("equipo"), String)

            oCCOSUBTIPOINCIDENCIA_BE.PropAUDUSUCREACION = CType(Session("Usuario"), String)
            oCCOSUBTIPOINCIDENCIA_BE.PropAUDFECCREACION = Now.Date
            oCCOSUBTIPOINCIDENCIA_BE.PropAUDPRGCREACION = CType(Session("proyecto"), String)
            oCCOSUBTIPOINCIDENCIA_BE.PropAUDEQPCREACION = CType(Session("equipo"), String)

            If txtSubtipoEdit.Text = "0" Then
                oCCOSUBTIPOINCIDENCIA_BL.Insertar(oCCOSUBTIPOINCIDENCIA_BE)
            Else
                oCCOSUBTIPOINCIDENCIA_BL.Actualizar(oCCOSUBTIPOINCIDENCIA_BE)
            End If
            CerrarPopup("editarSubtipo")
            cargarGrillaDetalle()
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub btnCancelarEditSubtipo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelarEditSubtipo.Click
        Try
            CerrarPopup("editarSubtipo")
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub gvDetalle_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvDetalle.RowDeleting

        Dim btnSubtipo As Button = gvDetalle.Rows(e.RowIndex).FindControl("btnEditSubtipo")
        Dim lblTipo As Label = gvDetalle.Rows(e.RowIndex).FindControl("lblEditTipo")

        Try
            oCCOSUBTIPOINCIDENCIA_BE.PropTINCODIGO = lblTipo.Text
            oCCOSUBTIPOINCIDENCIA_BE.PropSTICODIGO = btnSubtipo.Text
            oCCOSUBTIPOINCIDENCIA_BL.Eliminar(oCCOSUBTIPOINCIDENCIA_BE)
            cargarGrillaDetalle()
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub

    Protected Sub gvDatos_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvDatos.RowDeleting

        Dim btntipo As Button = gvDatos.Rows(e.RowIndex).FindControl("btnEditar")

        Try
            oCCOTIPOINCIDENCIA_BE.PropTINCODIGO = btntipo.Text
            oCCOTIPOINCIDENCIA_BL.Eliminar(oCCOTIPOINCIDENCIA_BE)
            CargaGrilla()
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try


    End Sub


End Class
