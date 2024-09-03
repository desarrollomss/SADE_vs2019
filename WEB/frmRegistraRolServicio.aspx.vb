Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data
Imports System.Drawing
Partial Class frmRegistraRolServicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If Session("DatosUsuarioActivo") Is Nothing Then
            Session.Clear()
            Session.Abandon()
            Response.Redirect(Request.ApplicationPath & "/frmLogin.aspx")
        End If
        btnProgramacion.Attributes.Add("onclick", "javascript:return ValidaProgramacion();")
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: REGISTRO DE ROL DE SERVICIO"
            Session("activo") = "1"
            Dim anio As String = Request.QueryString("anio")
            Dim idmes As String = Request.QueryString("idmes")
            Dim dmes As String = Request.QueryString("dmes")
            Dim idgrp As String = Request.QueryString("idgrp")
            Dim dgrp As String = Request.QueryString("dgrp")
            Dim idsec As String = Request.QueryString("idsec")
            Dim dsec As String = Request.QueryString("dsec")
            Dim cod As String = Request.QueryString("cod")
            lblPeriodo.Text = dmes & "/" & anio
            lbGrupoServicio.Text = dgrp.ToUpper
            lblSector.Text = dsec.ToUpper
            ViewState("smlseccodigo") = Int16.Parse(idsec)
            ViewState("intpercodigo") = Integer.Parse(cod)
            ViewState("anio") = Int16.Parse(anio)
            ViewState("smlgrscodigo") = Int16.Parse(idgrp)
            ViewState("mes") = Int16.Parse(idmes)
            If ViewState("intpercodigo") <> 0 Then
                cargapersona()
                cargagrilla()
                btnBuscarPersona.Enabled = False
                txtCodigo.ReadOnly = True
                txtCargo.ReadOnly = True
                txtNombre.ReadOnly = True
                txtModalidad.ReadOnly = True
                btnBuscarPersona.Enabled = False
            Else
                btnBuscarPersona.Enabled = True
            End If
        End If
    End Sub

    Protected Sub btnBuscarPersona_Click(sender As Object, e As System.EventArgs) Handles btnBuscarPersona.Click
        Dim sb As New StringBuilder
        sb.Append("<script>")
        sb.Append("var url = 'frmPopBuscaPersonal.aspx?sec=" + ViewState("smlseccodigo").ToString + "';")
        sb.Append("var setting = 'directories=no,height=600,left=20,location=no,menubar=no,resizable=yes,scrollbars=yes,status=no,toolbar=no,top=20,width=800';")
        sb.Append("window.open(url, 'frmPopBuscaPersonal', setting);")
        sb.Append("</script>")
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "CargarTrabajador", sb.ToString, False)
    End Sub

    Protected Sub gvProgramacion_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProgramacion.RowDataBound
        Try

            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim ddlTurno As DropDownList = CType(e.Row.FindControl("ddlTurnoUpd"), DropDownList)
                Dim lblTurno As Label = CType(e.Row.FindControl("lblTurnoUpd"), Label)
                Dim ddlMotivo As DropDownList = CType(e.Row.FindControl("ddlMotivoUpd"), DropDownList)
                Dim lblMotivo As Label = CType(e.Row.FindControl("lblMotivoUpd"), Label)
                Dim ddlPuestoFijo As DropDownList = CType(e.Row.FindControl("ddlPuestoFijoUpd"), DropDownList)
                Dim lblPuestoFijo As Label = CType(e.Row.FindControl("lblPuestoFijoUpd"), Label)
                Dim txtComentario As TextBox = CType(e.Row.FindControl("txtComentarioUpd"), TextBox)

                Dim oBL As CCOPAQUETE_BL = New CCOPAQUETE_BL
                Dim ds As DataSet = New DataSet
                ds = oBL.ListarTurnoSector
                ddlTurno.DataSource = ds.Tables(0)
                ddlTurno.DataTextField = "DESCRIPCION"
                ddlTurno.DataValueField = "CODIGO"
                ddlTurno.DataBind()
                ddlTurno.Items.Insert(0, "(Seleccione)")
                ddlTurno.Items(0).Value = 0
                ddlTurno.SelectedValue = Int16.Parse(lblTurno.Text)

                Dim oBLTabla As CCOTABLA_BL = New CCOTABLA_BL
                Dim oBETabla As CCOTABLA_BE = New CCOTABLA_BE

                oBETabla.PropTTACODIGO = "MOTIVOAUSENCIA"
                oBLTabla.Listar(oBETabla)

                ddlMotivo.DataSource = oBLTabla.Listar(oBETabla)
                ddlMotivo.DataTextField = "DESCRIPCION"
                ddlMotivo.DataValueField = "ID"
                ddlMotivo.DataBind()
                ddlMotivo.Items.Insert(0, "(Seleccione)")
                ddlMotivo.Items(0).Value = 0
                ddlMotivo.SelectedValue = lblMotivo.Text

                If ddlMotivo.SelectedValue > 0 Then
                    ddlTurno.SelectedValue = 0
                    ddlTurno.Enabled = False
                Else
                    ddlTurno.Enabled = True
                End If

                Dim oBE As CCOPAQUETE_BE = New CCOPAQUETE_BE
                oBE.PropSECCODIGO = ViewState("smlseccodigo")
                oBE.PropCUACODIGO = 0

                Dim dspf As DataSet = New DataSet
                dspf = oBL.ListaCombo(oBE)

                ddlPuestoFijo.DataSource = dspf.Tables(1)
                ddlPuestoFijo.DataTextField = "DESCRIPCION"
                ddlPuestoFijo.DataValueField = "CODIGO"
                ddlPuestoFijo.DataBind()
                ddlPuestoFijo.Items.Insert(0, "(Seleccione)")
                ddlPuestoFijo.Items(0).Value = 0
                ddlPuestoFijo.SelectedValue = lblPuestoFijo.Text


                Dim dcfc As DataControlFieldCell = CType(e.Row.Controls(5), DataControlFieldCell)
                If dcfc.Text = "P" Then
                    dcfc.ForeColor = Color.FromName("#1b3c63")
                    ddlTurno.Enabled = False
                    ddlMotivo.Enabled = False
                    ddlPuestoFijo.Enabled = False
                    txtComentario.Enabled = False
                    ddlTurno.ToolTip = "El campo no puede ser editado"
                    ddlMotivo.ToolTip = "El campo no puede ser editado"
                    ddlPuestoFijo.ToolTip = "El campo no puede ser editado"
                    txtComentario.ToolTip = "El campo no puede ser editado"
                ElseIf dcfc.Text = "A" Then
                    dcfc.ForeColor = Color.FromName("#89132A")
                    ddlTurno.Enabled = False
                    ddlMotivo.Enabled = False
                    ddlPuestoFijo.Enabled = False
                    txtComentario.Enabled = False
                    ddlTurno.ToolTip = "El campo no puede ser editado"
                    ddlMotivo.ToolTip = "El campo no puede ser editado"
                    ddlPuestoFijo.ToolTip = "El campo no puede ser editado"
                    txtComentario.ToolTip = "El campo no puede ser editado"
                Else
                    dcfc.ForeColor = Color.FromName("#555555")
                    ddlTurno.Enabled = True
                    ddlMotivo.Enabled = True
                    ddlPuestoFijo.Enabled = True
                    txtComentario.Enabled = True
                    If ddlMotivo.SelectedValue > 0 Then
                        ddlTurno.Enabled = False
                        ddlTurno.CssClass = "CajaComboOff"
                        ddlPuestoFijo.Enabled = False
                        ddlPuestoFijo.CssClass = "CajaComboOff"
                        ddlMotivo.Enabled = True
                        ddlMotivo.CssClass = "CajaCombo"

                    Else
                        ddlTurno.Enabled = True
                        ddlTurno.CssClass = "CajaCombo"
                        ddlPuestoFijo.Enabled = True
                        ddlPuestoFijo.CssClass = "CajaCombo"
                        ddlMotivo.Enabled = False
                        ddlMotivo.CssClass = "CajaComboOff"
                    End If

                End If
            End If
        Catch ex As Exception
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            Throw ex
        End Try

    End Sub

    Protected Sub btnProgramacion_Click(sender As Object, e As System.EventArgs) Handles btnProgramacion.Click
        txtCodigo.Enabled = False
        txtCargo.Enabled = False
        txtModalidad.Enabled = False
        txtNombre.Enabled = False
        btnBuscarPersona.Enabled = False
        cargagrilla()
        'Util.MSG_ALERTA("codigo:" & txtNombre.Text, Me)
    End Sub
    Protected Sub btnCancelaPaquete_Click(sender As Object, e As System.EventArgs) Handles btnCancelaPaquete.Click, btnCancelaPaquete2.Click
        Response.Redirect("frmBuscaRolServicio.aspx")
    End Sub

    Protected Sub btnGrabaRol_Click(sender As Object, e As System.EventArgs) Handles btnGrabaRol.Click, btnGrabaRol2.Click
        Try

            If Not validagrilla() Then
                Exit Sub
            End If
            Dim oBE As CCOROLSERVICIO_BE = New CCOROLSERVICIO_BE
            Dim oBL As CCOROLSERVICIO_BL = New CCOROLSERVICIO_BL
            Dim dt As DataTable = CType(ViewState("datos"), DataTable)
            Dim i As Integer = 0
            For i = 0 To gvProgramacion.Rows.Count - 1

                Dim ddlTurno As DropDownList = CType(gvProgramacion.Rows(i).FindControl("ddlTurnoUpd"), DropDownList)
                Dim ddlMotivo As DropDownList = CType(gvProgramacion.Rows(i).FindControl("ddlMotivoUpd"), DropDownList)
                Dim ddlPuestoFijo As DropDownList = CType(gvProgramacion.Rows(i).FindControl("ddlPuestoFijoUpd"), DropDownList)
                Dim txtComentario As TextBox = CType(gvProgramacion.Rows(i).FindControl("txtComentarioUpd"), TextBox)

                With oBE
                    .PropGRSCODIGO = ViewState("smlgrscodigo")
                    .PropPERCODIGO = Integer.Parse(txtCodigo.Text)
                    If ddlPuestoFijo.SelectedValue = 0 Then
                        .PropPFICODIGO = Nothing
                    Else
                        .PropPFICODIGO = ddlPuestoFijo.SelectedValue
                    End If
                    .PropRSECOMENTARIO = txtComentario.Text
                    .PropCRGCODIGO = Nothing
                    If ddlTurno.SelectedValue > 0 Then
                        .PropRSEDISPONIBLE = 1
                    Else
                        .PropRSEDISPONIBLE = 0
                    End If
                    .PropRSEFECHA = Date.Parse(dt.Rows(i).Item("DATRSEFECHA"))
                    If ddlMotivo.SelectedValue = 0 Then
                        .PropRSEMOTAUSENCIA = Nothing
                    Else
                        .PropRSEMOTAUSENCIA = ddlMotivo.SelectedValue
                    End If
                    .PropSECCODIGO = ViewState("smlseccodigo")
                    If ddlTurno.SelectedValue = 0 Then
                        .PropTURCODIGO = Nothing
                    Else
                        .PropTURCODIGO = ddlTurno.SelectedValue
                    End If
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

                If ddlTurno.SelectedValue > 0 Or ddlMotivo.SelectedValue > 0 Then
                    oBL.Insertar(oBE)
                End If
            Next
            lblMensajeSistema.Text = "La operación fue realizada satisfactoriamente"
            MostrarPopup("mensaje")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub
    Protected Sub btnRedirecciona_Click(sender As Object, e As System.EventArgs) Handles btnRedirecciona.Click
        Response.Redirect("frmBuscaRolServicio.aspx")
    End Sub
#Region "FDU"
    Private Function validagrilla() As Boolean
        Dim valor As Boolean = True
        Dim dt As DataTable = CType(ViewState("datos"), DataTable)
        Dim i As Integer = 0
        For i = 0 To gvProgramacion.Rows.Count - 1
            Dim ddlTurno As DropDownList = CType(gvProgramacion.Rows(i).FindControl("ddlTurnoUpd"), DropDownList)
            Dim ddlMotivo As DropDownList = CType(gvProgramacion.Rows(i).FindControl("ddlMotivoUpd"), DropDownList)
            Dim ddlPuestoFijo As DropDownList = CType(gvProgramacion.Rows(i).FindControl("ddlPuestoFijoUpd"), DropDownList)

            If ddlTurno.SelectedValue > 0 And ddlMotivo.SelectedValue > 0 Then
                Util.MSG_ALERTA("El DIA :" & gvProgramacion.Rows(i).Cells(0).Text.ToUpper.Trim & " PRESENTA INCONSISTENCIAS ... REVISE ", Me)
                valor = False
                Exit For
            End If
            If ddlTurno.SelectedValue = 0 And ddlPuestoFijo.SelectedValue > 0 Then
                Util.MSG_ALERTA("EL DIA :" & gvProgramacion.Rows(i).Cells(0).Text.ToUpper.Trim & " DEBE SELECCIONAR UN TURNO OBLIGATORIAMENTE ", Me)
                valor = False
                Exit For
            End If
        Next
        Return valor
    End Function

    Private Sub cargagrilla()
        Try
            Dim oBE As CCOROLSERVICIO_BE = New CCOROLSERVICIO_BE
            Dim oBL As CCOROLSERVICIO_BL = New CCOROLSERVICIO_BL
            With oBE
                .PropPERCODIGO = Integer.Parse(txtCodigo.Text)
                .PropTURCODIGO = ViewState("anio")
                .PropPFICODIGO = ViewState("mes")
                .PropGRSCODIGO = ViewState("smlgrscodigo")
                .PropSECCODIGO = ViewState("smlseccodigo")
            End With
            Dim dt As DataTable = New DataTable
            dt = oBL.ListarProgramacion(oBE)
            ViewState("datos") = dt
            gvProgramacion.DataSource = dt
            gvProgramacion.DataBind()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub
    Private Sub cargapersona()
        Try
            Dim oBE As CCOPERSONAL_BE = New CCOPERSONAL_BE
            Dim oBL As CCOPERSONAL_BL = New CCOPERSONAL_BL
            With oBE
                .PropPERCODIGO = ViewState("intpercodigo")
                .PropPERAPELLIDOPATERNO = ""
                .PropPERAPELLIDOMATERNO = ""
                .PropPERNOMBRE = ""
                .PropCRGCODIGO = 0
                .PropPERESTADO = 1
                .Propturcodigo = 0
                .PropSECCODIGO = ViewState("smlseccodigo")
            End With
            Dim dt As DataTable = New DataTable
            dt = oBL.Listar(oBE)
            If dt.Rows.Count > 0 Then
                txtCodigo.Text = dt.Rows(0).Item("INTPERCODIGO")
                txtNombre.Text = dt.Rows(0).Item("VCHCOMPLETO")
                txtCargo.Text = dt.Rows(0).Item("VCHCRGDESCRIPCION")
                txtModalidad.Text = dt.Rows(0).Item("CHRPERMODALIDADDES")
            End If
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
    Private Sub CerrarPopup(ByVal pdiv As String)
        Dim sb As New StringBuilder
        sb.AppendLine("javascript:void(0);")
        sb.AppendLine("document.getElementById('" & pdiv & "').style.display='none';document.getElementById('fade').style.display='none';")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub
#End Region

    Protected Sub ddlMotivoUpd_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        For Each Row As GridViewRow In gvProgramacion.Rows
            If Row.RowType = DataControlRowType.DataRow Then
                Dim ddlTurno As DropDownList = CType(Row.FindControl("ddlTurnoUpd"), DropDownList)
                Dim ddlMotivo As DropDownList = CType(Row.FindControl("ddlMotivoUpd"), DropDownList)
                Dim ddlPuestoFijo As DropDownList = CType(Row.FindControl("ddlPuestoFijoUpd"), DropDownList)

                Dim dcfc As DataControlFieldCell = CType(Row.Controls(5), DataControlFieldCell)
                If dcfc.Text = "P" Or dcfc.Text = "A" Then
                    ddlTurno.Enabled = False
                    ddlTurno.CssClass = "CajaComboOff"
                    ddlPuestoFijo.Enabled = False
                    ddlPuestoFijo.CssClass = "CajaComboOff"
                    ddlMotivo.Enabled = False
                    ddlMotivo.CssClass = "CajaComboOff"
                Else
                    If ddlMotivo.SelectedValue > 0 Then
                        ddlTurno.Enabled = False
                        ddlTurno.CssClass = "CajaComboOff"
                        ddlPuestoFijo.Enabled = False
                        ddlPuestoFijo.CssClass = "CajaComboOff"
                        ddlMotivo.Enabled = True
                        ddlMotivo.CssClass = "CajaCombo"
                    Else
                        ddlTurno.Enabled = True
                        ddlTurno.CssClass = "CajaCombo"
                        ddlPuestoFijo.Enabled = True
                        ddlPuestoFijo.CssClass = "CajaCombo"
                        ddlMotivo.Enabled = False
                        ddlMotivo.CssClass = "CajaComboOff"
                    End If
                End If
            End If
        Next
    End Sub

    Protected Sub ddlTurnoUpd_SelectedIndexChanged(sender As Object, e As System.EventArgs)
        For Each Row As GridViewRow In gvProgramacion.Rows
            If Row.RowType = DataControlRowType.DataRow Then
                Dim ddlTurno As DropDownList = CType(Row.FindControl("ddlTurnoUpd"), DropDownList)
                Dim ddlMotivo As DropDownList = CType(Row.FindControl("ddlMotivoUpd"), DropDownList)
                Dim ddlPuestoFijo As DropDownList = CType(Row.FindControl("ddlPuestoFijoUpd"), DropDownList)
                Dim dcfc As DataControlFieldCell = CType(Row.Controls(5), DataControlFieldCell)
                If dcfc.Text = "P" Or dcfc.Text = "A" Then
                    ddlTurno.Enabled = False
                    ddlTurno.CssClass = "CajaComboOff"
                    ddlPuestoFijo.Enabled = False
                    ddlPuestoFijo.CssClass = "CajaComboOff"
                    ddlMotivo.Enabled = False
                    ddlMotivo.CssClass = "CajaComboOff"
                Else
                    If ddlTurno.SelectedValue > 0 Then
                        ddlMotivo.Enabled = False
                        ddlMotivo.CssClass = "CajaComboOff"
                        ddlPuestoFijo.Enabled = True
                        ddlPuestoFijo.CssClass = "CajaCombo"
                        ddlTurno.Enabled = True
                        ddlTurno.CssClass = "CajaCombo"
                    Else
                        ddlMotivo.Enabled = True
                        ddlMotivo.CssClass = "CajaCombo"
                        ddlPuestoFijo.Enabled = False
                        ddlPuestoFijo.CssClass = "CajaComboOff"
                        ddlTurno.Enabled = False
                        ddlTurno.CssClass = "CajaComboOff"
                    End If
                End If
            End If
        Next
    End Sub
End Class
