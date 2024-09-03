Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data
Imports System.Drawing
Imports System.Diagnostics

Partial Class frmBuscaRolServicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        btnBuscar.Attributes.Add("onclick", "javascript:return ValidaBuscar();")
        btnNuevo.Attributes.Add("onclick", "javascript:return ValidaNuevo();")
        btnProgramacion.Attributes.Add("onclick", "javascript:return ValidaNuevo();")
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: ROL DE SERVICIO"
            Session("activo") = "1"
            cargacombo()
            cargagrilla()
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        cargagrilla()
    End Sub

    Protected Sub gvDatos_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvDatos.PageIndexChanging
        gvDatos.PageIndex = e.NewPageIndex
        cargagrilla()
    End Sub
#Region "fdu"
    Private Sub cargacombo()
        Try

            Dim oBL As CCOPAQUETE_BL = New CCOPAQUETE_BL
            Dim ds As DataSet = New DataSet
            ds = oBL.ListarTurnoSector()
            ddlSectorBusca.DataSource = ds.Tables(1)
            ddlSectorBusca.DataTextField = "DESCRIPCION"
            ddlSectorBusca.DataValueField = "CODIGO"
            ddlSectorBusca.DataBind()
            ddlSectorBusca.Items.Insert(0, " (Seleccione) ")
            ddlSectorBusca.Items(0).Value = 0

            ddlGrupoServicioBusca.DataSource = ds.Tables(3)
            ddlGrupoServicioBusca.DataTextField = "DESCRIPCION"
            ddlGrupoServicioBusca.DataValueField = "CODIGO"
            ddlGrupoServicioBusca.DataBind()
            ddlGrupoServicioBusca.Items.Insert(0, " (Seleccione) ")
            ddlGrupoServicioBusca.Items(0).Value = 0
            Dim oBETabla As CCOTABLA_BE = New CCOTABLA_BE
            Dim oBLTabla As CCOTABLA_BL = New CCOTABLA_BL

            oBETabla.PropTTACODIGO = "MESES"
            ddlMesBusca.DataSource = oBLTabla.Listar(oBETabla)
            ddlMesBusca.DataTextField = "DESCRIPCION2"
            ddlMesBusca.DataValueField = "CODIGO"
            ddlMesBusca.DataBind()
            ddlMesBusca.SelectedValue = Format(Now.Month, "00")

            txtAnioBusca.Text = Now.Year.ToString

        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub
    Private Sub cargagrilla()
        Try
            Dim oBE As CCOROLSERVICIO_BE = New CCOROLSERVICIO_BE
            Dim oBL As CCOROLSERVICIO_BL = New CCOROLSERVICIO_BL
            With oBE
                .PropPERCODIGO = 0
                If txtAnioBusca.Text.Length > 0 Then
                    If IsNumeric(txtAnioBusca.Text) Then
                        .PropTURCODIGO = Int16.Parse(txtAnioBusca.Text)
                    End If
                End If
                .PropPFICODIGO = Int16.Parse(ddlMesBusca.SelectedValue)
                .PropGRSCODIGO = ddlGrupoServicioBusca.SelectedValue
                .PropSECCODIGO = ddlSectorBusca.SelectedValue
            End With

            Dim dt As DataTable = New DataTable
            dt = oBL.Listar(oBE)
            ViewState("datos") = dt
            gvDatos.DataSource = dt
            gvDatos.DataBind()

        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub
#End Region

    Protected Sub gvDatos_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowCreated
        If e.Row.Cells.Count > 1 Then
            e.Row.Cells(1).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "javascript: this.style.cursor='pointer';"
            e.Row.Attributes("onmouseout") = "javascript: this.style.cursor='normal';"
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvDatos, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub

    Protected Sub gvDatos_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then

            Dim cell0 As TableCell = e.Row.Cells(0)
            cell0.Width = New Unit("30px")
            Dim cell2 As TableCell = e.Row.Cells(2)
            cell2.Width = New Unit("200px")
            Dim cell3 As TableCell = e.Row.Cells(3)
            cell3.Width = New Unit("100px")
            For i = 4 To e.Row.Cells.Count - 1
                Dim celldemas As TableCell = e.Row.Cells(i)
                celldemas.Width = New Unit("20px")
            Next
        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            For i = 4 To e.Row.Cells.Count - 1
                Dim dcfc As DataControlFieldCell = CType(e.Row.Controls(i), DataControlFieldCell)
                dcfc.ForeColor = Color.FromName("#555555")
                If dcfc.Text = "M" Or dcfc.Text = "T" Or dcfc.Text = "N" Then
                    'dcfc.BackColor = Color.FromName("#DBDE48")
                    'dcfc.ForeColor = Color.FromName("#ffffff")
                Else
                    If dcfc.Text <> "&nbsp;" Then
                        dcfc.BackColor = Color.FromName("#A9313D")
                        dcfc.ForeColor = Color.FromName("#ffffff")
                    End If
                End If
            Next
        End If
    End Sub

    Protected Sub gvDatos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvDatos.SelectedIndexChanged
        Dim dt As DataTable = CType(ViewState("datos"), DataTable)
        cargagrilla()
        ViewState("intpercodigo") = dt.Rows(gvDatos.SelectedIndex + (gvDatos.PageIndex * gvDatos.PageSize)).Item("CODIGO")
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As System.EventArgs) Handles btnNuevo.Click
        Dim anio As String = txtAnioBusca.Text
        Dim idmes As String = ddlMesBusca.SelectedValue.ToString
        Dim dmes As String = ddlMesBusca.SelectedItem.Text
        Dim idgrp As String = ddlGrupoServicioBusca.SelectedValue.ToString
        Dim dgrp As String = ddlGrupoServicioBusca.SelectedItem.Text
        Dim idsec As String = ddlSectorBusca.SelectedValue.ToString
        Dim dsec As String = ddlSectorBusca.SelectedItem.Text

        Response.Redirect("frmRegistraRolServicio.aspx?anio=" & anio & "&idmes=" & idmes & "&dmes=" & dmes & "&idgrp=" & idgrp & "&dgrp=" & dgrp & "&idsec=" & idsec & "&dsec=" & dsec & "&cod=0")

    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As System.EventArgs) Handles btnModificar.Click
        If (gvDatos.SelectedIndex + (gvDatos.PageIndex * gvDatos.PageSize)) >= 0 Then
            Dim anio As String = txtAnioBusca.Text
            Dim idmes As String = ddlMesBusca.SelectedValue.ToString
            Dim dmes As String = ddlMesBusca.SelectedItem.Text
            Dim idgrp As String = ddlGrupoServicioBusca.SelectedValue.ToString
            Dim dgrp As String = ddlGrupoServicioBusca.SelectedItem.Text
            Dim idsec As String = ddlSectorBusca.SelectedValue.ToString
            Dim dsec As String = ddlSectorBusca.SelectedItem.Text
            Response.Redirect("frmRegistraRolServicio.aspx?anio=" & anio & "&idmes=" & idmes & "&dmes=" & dmes & "&idgrp=" & idgrp & "&dgrp=" & dgrp & "&idsec=" & idsec & "&dsec=" & dsec & "&cod=" & ViewState("intpercodigo").ToString)
        Else
            Util.MSG_ALERTA(" DEBE SELECCIONAR UN REGISTRO ", Me)
        End If
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As System.EventArgs) Handles btnEliminar.Click
        If (gvDatos.SelectedIndex + (gvDatos.PageIndex * gvDatos.PageSize)) >= 0 Then
            Dim oBE As CCOROLSERVICIO_BE = New CCOROLSERVICIO_BE
            Dim oBL As CCOROLSERVICIO_BL = New CCOROLSERVICIO_BL
            With oBE
                .PropPERCODIGO = ViewState("intpercodigo")
                If txtAnioBusca.Text.Length > 0 Then
                    If IsNumeric(txtAnioBusca.Text) Then
                        .PropTURCODIGO = Int16.Parse(txtAnioBusca.Text)
                    End If
                End If
                .PropPFICODIGO = Int16.Parse(ddlMesBusca.SelectedValue)
                .PropGRSCODIGO = ddlGrupoServicioBusca.SelectedValue
                .PropSECCODIGO = ddlSectorBusca.SelectedValue
            End With
            oBL.Eliminar(oBE)
            cargagrilla()
        Else
            Util.MSG_ALERTA(" DEBE SELECCIONAR UN REGISTRO ", Me)
        End If
    End Sub

    Protected Sub btnProgramacion_Click(sender As Object, e As System.EventArgs) Handles btnProgramacion.Click
        Dim anio As String = txtAnioBusca.Text
        Dim idmes As String = ddlMesBusca.SelectedValue.ToString
        Dim dmes As String = ddlMesBusca.SelectedItem.Text
        Dim idgrp As String = ddlGrupoServicioBusca.SelectedValue.ToString
        Dim dgrp As String = ddlGrupoServicioBusca.SelectedItem.Text
        Dim idsec As String = ddlSectorBusca.SelectedValue.ToString
        Dim dsec As String = ddlSectorBusca.SelectedItem.Text

        Response.Redirect("frmProgMensualAuto.aspx?anio=" & anio & "&idmes=" & idmes & "&dmes=" & dmes & "&idgrp=" & idgrp & "&dgrp=" & dgrp & "&idsec=" & idsec & "&dsec=" & dsec & "&cod=0")

    End Sub

    Protected Sub btnExportar_Click(sender As Object, e As System.EventArgs) Handles btnExportar.Click
        GridViewExportUtil.Export("RolServicios.xls", gvDatos)
    End Sub
End Class
