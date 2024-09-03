Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data

Partial Class frmProgMensualAuto
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If Session("DatosUsuarioActivo") Is Nothing Then
            Session.Clear()
            Session.Abandon()
            Response.Redirect(Request.ApplicationPath & "/frmLogin.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = "Programación mensual automática"
            Session("activo") = "2"
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
            cargacombo()
            CreaTablasTemporales()
        End If

    End Sub

    Protected Sub btnRecursoBuscar_Click(sender As Object, e As System.EventArgs) Handles btnRecursoBuscar.Click
        cargagrillapersona()
    End Sub
    Protected Sub btnAgregar_Click(sender As Object, e As System.EventArgs) Handles btnAgregar.Click
        MostrarPopup("personal")
        cargagrillapersona()
        chkTodos.Checked = False
    End Sub

    Protected Sub chkTodos_CheckedChanged1(sender As Object, e As System.EventArgs) Handles chkTodos.CheckedChanged
        For Each row As GridViewRow In gvPersonalBusca.Rows
            Dim cb As CheckBox = row.FindControl("chkSelecciona")
            If chkTodos.Checked Then cb.Checked = True Else cb.Checked = False
        Next
    End Sub

    Protected Sub btnRecursoAgregar_Click(sender As Object, e As System.EventArgs) Handles btnRecursoAgregar.Click
        Try
            Dim dt As DataTable = CType(ViewState("dtprogramacion"), DataTable)
            For Each fila As GridViewRow In gvPersonalBusca.Rows
                Dim cb As CheckBox = fila.FindControl("chkSelecciona")
                If cb.Checked Then
                    Dim columna As DataColumnCollection = dt.Columns
                    Dim rowPlantilla As DataRow
                    rowPlantilla = dt.NewRow()
                    rowPlantilla(columna(0)) = fila.Cells(0).Text
                    rowPlantilla(columna(1)) = fila.Cells(1).Text
                    rowPlantilla(columna(2)) = fila.Cells(2).Text
                    rowPlantilla(columna(3)) = fila.Cells(3).Text
                    rowPlantilla(columna(4)) = 0
                    rowPlantilla(columna(5)) = 0
                    dt.Rows.Add(rowPlantilla)
                    dt.AcceptChanges()
                End If
            Next
            ViewState("dtprogramacion") = dt
            gvProgramacion.DataSource = dt
            gvProgramacion.DataBind()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub gvProgramacion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvProgramacion.SelectedIndexChanged
        Dim dt As DataTable = CType(ViewState("dtprogramacion"), DataTable)
        ViewState("INTPERCODIGO") = dt.Rows(gvProgramacion.SelectedIndex).Item("INTPERCODIGO")
        EliminarProgramacion()
    End Sub

    Protected Sub gvProgramacion_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvProgramacion.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim ddlSecuencia As DropDownList = CType(e.Row.FindControl("ddlSecuenciaUpd"), DropDownList)
            Dim ddlInicioSecuencia As DropDownList = CType(e.Row.FindControl("ddlInicioSecuenciaUpd"), DropDownList)
            Dim oBESecuencia As CCOSECUENCIASERVICIO_BE = New CCOSECUENCIASERVICIO_BE
            Dim oBLSecuencia As CCOSECUENCIASERVICIO_BL = New CCOSECUENCIASERVICIO_BL
            Dim dt As DataTable = New DataTable
            oBESecuencia.PropSSECODIGO = 0
            dt = oBLSecuencia.Listar(oBESecuencia)
            ddlSecuencia.DataSource = dt
            ddlSecuencia.DataTextField = "VCHSSEDESCRIPCION"
            ddlSecuencia.DataValueField = "SMLSSECODIGO"
            ddlSecuencia.DataBind()

            Dim oBEdetalleSecuencia As CCODETALLESECUENCIASERVICIO_BE = New CCODETALLESECUENCIASERVICIO_BE
            Dim oBLdetalleSecuencia As CCODETALLESECUENCIASERVICIO_BL = New CCODETALLESECUENCIASERVICIO_BL
            Dim dtdet As DataTable = New DataTable
            oBEdetalleSecuencia.PropSSECODIGO = ddlSecuencia.SelectedValue
            oBEdetalleSecuencia.PropDSSCODIGO = 0
            dtdet = oBLdetalleSecuencia.Listar(oBEdetalleSecuencia)
            ddlInicioSecuencia.DataSource = dtdet
            ddlInicioSecuencia.DataTextField = "VCHSECUENCIA"
            ddlInicioSecuencia.DataValueField = "SMLDSSCODIGO"
            ddlInicioSecuencia.DataBind()

        End If
    End Sub

    Protected Sub btnGrabaProgramacion_Click(sender As Object, e As System.EventArgs) Handles btnGrabaProgramacion.Click, btnGrabaProgramacion2.Click
        Try
            Dim ddlInicioSecuencia As DropDownList
            Dim oBE As CCOROLSERVICIO_BE = New CCOROLSERVICIO_BE
            Dim oBL As CCOROLSERVICIO_BL = New CCOROLSERVICIO_BL

            Dim i As Integer = 0
            For i = 0 To gvProgramacion.Rows.Count - 1
                ddlInicioSecuencia = CType(gvProgramacion.Rows(i).FindControl("ddlInicioSecuenciaUpd"), DropDownList)
                With oBE
                    .PropPERCODIGO = Integer.Parse(gvProgramacion.Rows(i).Cells(1).Text)
                    .PropTURCODIGO = ViewState("anio")
                    .PropPFICODIGO = ViewState("mes")
                    .PropGRSCODIGO = ViewState("smlgrscodigo")
                    .PropSECCODIGO = ViewState("smlseccodigo")
                    .PropCRGCODIGO = ddlInicioSecuencia.SelectedValue
                End With
                oBL.InsertarProgramacion(oBE)
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
    Protected Sub btnCancelaProgramacion_Click(sender As Object, e As System.EventArgs) Handles btnCancelaProgramacion.Click, btnCancelaProgramacion2.Click
        Response.Redirect("frmBuscaRolServicio.aspx")
    End Sub
#Region "FDU"
    Private Sub cargagrillapersona()
        Dim oBE As CCOPERSONAL_BE = New CCOPERSONAL_BE
        Dim oBL As CCOPERSONAL_BL = New CCOPERSONAL_BL
        Dim _cod As Integer = 0
        If txtCodigoBusca.Text.Length > 0 Then
            If IsNumeric(txtCodigoBusca.Text) Then
                _cod = Integer.Parse(txtCodigoBusca.Text)
            End If
        End If
        With oBE
            .PropPERCODIGO = _cod
            .PropPERAPELLIDOPATERNO = txtPaternoBusca.Text.ToUpper
            .PropPERAPELLIDOMATERNO = txtMaternoBusca.Text.ToUpper
            .PropPERNOMBRE = txtNombreBusca.Text.ToUpper
            .PropCRGCODIGO = ddlCargoBusca.SelectedValue
            .PropPERESTADO = 1
            .Propturcodigo = 0
            .PropSECCODIGO = ViewState("smlseccodigo")
        End With
        Dim dt As DataTable = New DataTable
        dt = oBL.Listar(oBE)
        ViewState("dtPersona") = dt
        gvPersonalBusca.DataSource = dt
        gvPersonalBusca.DataBind()
    End Sub
    Private Sub cargacombo()
        Dim oBE As CCOCARGOPERSONAL_BE = New CCOCARGOPERSONAL_BE
        Dim oBL As CCOCARGOPERSONAL_BL = New CCOCARGOPERSONAL_BL
        oBE.PropCRGCODIGO = 0
        oBE.PropCRGDESCRIPCION = String.Empty
        ddlCargoBusca.DataSource = oBL.Listar(oBE)
        ddlCargoBusca.DataTextField = "VCHCRGDESCRIPCION"
        ddlCargoBusca.DataValueField = "SMLCRGCODIGO"
        ddlCargoBusca.DataBind()
        ddlCargoBusca.Items.Insert(0, " (Todos) ")
        ddlCargoBusca.Items(0).Value = 0
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
    Private Sub CreaTablasTemporales()
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("INTPERCODIGO", Type.GetType("System.Int32"))
        dt.Columns.Add("VCHCOMPLETO", Type.GetType("System.String"))
        dt.Columns.Add("VCHCARGO", Type.GetType("System.String"))
        dt.Columns.Add("VCHMODALIDAD", Type.GetType("System.String"))
        dt.Columns.Add("SMLSSECODIGO", Type.GetType("System.Int16"))
        dt.Columns.Add("SMLDSSSECUENCIA", Type.GetType("System.Int16"))
        dt.AcceptChanges()
        ViewState("dtprogramacion") = dt
    End Sub
    Private Sub EliminarProgramacion()
        Try
            If gvProgramacion.SelectedIndex = -1 Then
                Util.MSG_ALERTA("Seleccione el registro que desea eliminar", Me)
                Exit Sub
            End If

            Dim dt As DataTable = CType(ViewState("dtprogramacion"), DataTable)
            If dt.Rows(gvProgramacion.SelectedIndex).Item("INTPERCODIGO") = ViewState("INTPERCODIGO") Then
                dt.Rows(gvProgramacion.SelectedIndex).Delete()
                dt.AcceptChanges()
            End If
            ViewState("dtprogramacion") = dt
            gvProgramacion.DataSource = dt
            gvProgramacion.DataBind()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try

    End Sub
#End Region

    

End Class
