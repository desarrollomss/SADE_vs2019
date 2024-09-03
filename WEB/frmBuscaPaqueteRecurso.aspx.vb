Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data
Imports Util


Partial Class frmBuscaPaqueteRecurso
    Inherits System.Web.UI.Page
    Enum Estado
        Activo = 1
        Inactivo = 0
    End Enum
    Enum Cargo
        Supervisor = 2
    End Enum

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If Session("DatosUsuarioActivo") Is Nothing Then
            Session.Clear()
            Session.Abandon()
            Response.Redirect(Request.ApplicationPath & "/frmLogin.aspx")
        End If
        btnBuscar.Attributes.Add("onclick", "javascript:return ValidaBuscar();")
        'btnActualizaBusca.Attributes.Add("onclick", "javascript:return ValidaActualizaBusca();")
        btnNuevo.Attributes.Add("onclick", "javascript:return ValidaNuevo();")
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: DISTRIBUCION DE PAQUETE DE RECURSOS"
            Session("activo") = "2"
            IniciaValores()
            Cargacombo()
            CargaGrilla()
            CargaRecursosDisponible()
        End If
    End Sub

    Private Sub IniciaValores()
        txtFechaBusca.Text = Date.Now
    End Sub

    Private Sub Cargacombo()
        Dim oBE As CCOPAQUETE_BE = New CCOPAQUETE_BE
        Dim oBL As CCOPAQUETE_BL = New CCOPAQUETE_BL
        Try
            Dim ds As DataSet = New DataSet
            ds = oBL.ListarTurnoSector()
            ddlTurnoBusca.DataSource = ds.Tables(0)
            ddlTurnoBusca.DataTextField = "DESCRIPCION"
            ddlTurnoBusca.DataValueField = "CODIGO"
            ddlTurnoBusca.DataBind()
            ddlSectorBusca.DataSource = ds.Tables(1)
            ddlSectorBusca.DataTextField = "DESCRIPCION"
            ddlSectorBusca.DataValueField = "CODIGO"
            ddlSectorBusca.DataBind()
            ddlSectorBusca.Items.Insert(0, "(Ver Todos)")
            ddlSectorBusca.Items(0).Value = 0
            ddlTipoPaqueteBusca.DataSource = ds.Tables(2)
            ddlTipoPaqueteBusca.DataTextField = "DESCRIPCION"
            ddlTipoPaqueteBusca.DataValueField = "CODIGO"
            ddlTipoPaqueteBusca.DataBind()
            ddlTipoPaqueteBusca.Items.Insert(0, "(Ver Todos)")
            ddlTipoPaqueteBusca.Items(0).Value = 0
        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

    Private Sub CargaRecursosDisponible()

        Dim oBE As CCOPAQUETE_BE = New CCOPAQUETE_BE
        Dim oBL As CCOPAQUETE_BL = New CCOPAQUETE_BL
        Try

            With oBE
                .PropSECCODIGO = ddlSectorBusca.SelectedValue
                .PropTURCODIGO = ddlTurnoBusca.SelectedValue
                .PropPAQFECHA = txtFechaBusca.Text
            End With
            Dim dt As DataTable = New DataTable
            gvRecursosDisponibles.DataSource = oBL.ListarRecursosDisponibles(oBE)
            gvRecursosDisponibles.DataBind()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub
    Private Sub CargaGrilla()

        Dim oBE As CCOPAQUETE_BE = New CCOPAQUETE_BE
        Dim oBL As CCOPAQUETE_BL = New CCOPAQUETE_BL
        Try

            With oBE
                .PropPAQCODIGO = 0
                .PropPAQFECHA = txtFechaBusca.Text
                .PropTURCODIGO = ddlTurnoBusca.SelectedValue
                .PropSECCODIGO = ddlSectorBusca.SelectedValue
                .PropTPQCODIGO = ddlTipoPaqueteBusca.SelectedValue
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
    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        CargaRecursosDisponible()
        CargaGrilla()
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As System.EventArgs) Handles btnNuevo.Click
        Dim sec As String = ddlSectorBusca.SelectedValue.ToString
        Dim nom As String = ddlSectorBusca.SelectedItem.Text
        Dim tur As String = ddlTurnoBusca.SelectedValue.ToString
        Dim dtur As String = ddlTurnoBusca.SelectedItem.Text.ToUpper
        Dim fec As String = txtFechaBusca.Text.Trim
        Response.Redirect("frmRegistraPaqueteRecurso.aspx?acc=N&sec=" & sec & "&nom=" & nom & "&tur=" & tur & "&fec=" & fec & "&dtur=" & dtur & "&cpq=0&num=0")
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
        End If
    End Sub

    Protected Sub gvDatos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvDatos.SelectedIndexChanged
        Dim dt As DataTable = CType(ViewState("datos"), DataTable)
        ViewState("intpaqcodigo") = dt.Rows(gvDatos.SelectedIndex + (gvDatos.PageIndex * gvDatos.PageSize)).Item("INTPAQCODIGO")
        ViewState("smlturcodigo") = dt.Rows(gvDatos.SelectedIndex + (gvDatos.PageIndex * gvDatos.PageSize)).Item("SMLTURCODIGO")
        ViewState("dtur") = dt.Rows(gvDatos.SelectedIndex + (gvDatos.PageIndex * gvDatos.PageSize)).Item("VCHTURDESCRIPCION")
        ViewState("numero") = dt.Rows(gvDatos.SelectedIndex + (gvDatos.PageIndex * gvDatos.PageSize)).Item("VCHPAQNUMERO")
    End Sub


    Protected Sub btnModificar_Click(sender As Object, e As System.EventArgs) Handles btnModificar.Click
        If (gvDatos.SelectedIndex + (gvDatos.PageIndex * gvDatos.PageSize)) >= 0 Then
            Dim tur As String = ViewState("smlturcodigo").ToString
            Dim dtur As String = ViewState("dtur")
            Dim fec As String = txtFechaBusca.Text.Trim
            Dim oBL As CCOPAQUETE_BL = New CCOPAQUETE_BL
            If oBL.VerificaIncidencia(ViewState("intpaqcodigo")) = 0 Then
                Response.Redirect("frmRegistraPaqueteRecurso.aspx?acc=M&sec=&nom=&tur=" & tur & "&fec=" & fec & "&dtur=" & dtur & "&cpq=" & ViewState("intpaqcodigo") & "&num=" & ViewState("numero"))
            Else
                Util.MSG_ALERTA(" EL PAQUETE SE ENCUENTRA ASIGNADO A UNA INCIDENCIA... NO ES POSIBLE MODIFICAR ", Me)
                Exit Sub
            End If
        Else
            Util.MSG_ALERTA(" DEBE SELECCIONAR UN REGISTRO ", Me)
        End If

    End Sub
    Private Sub MostrarPopup(ByVal pdiv As String)
        Dim sb As New StringBuilder
        sb.AppendLine("javascript:void(0);")
        sb.AppendLine("document.getElementById('" & pdiv & "').style.display='block';document.getElementById('fade').style.display='block';")
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "alert0001", sb.ToString(), True)
    End Sub

    Protected Sub btnReplicar_Click(sender As Object, e As System.EventArgs) Handles btnReplicar.Click
        txtFechaDestino.Text = Date.Now
        txtFechaOrigen.Text = DateAdd(DateInterval.Day, -1, Now.Date)
        MostrarPopup("mensaje")
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As System.EventArgs) Handles btnEliminar.Click
        Try
            If (gvDatos.SelectedIndex + (gvDatos.PageIndex * gvDatos.PageSize)) >= 0 Then
                Dim cod As Integer = ViewState("intpaqcodigo")
                Dim OBE As CCOPAQUETE_BE = New CCOPAQUETE_BE
                Dim OBL As CCOPAQUETE_BL = New CCOPAQUETE_BL
                If OBL.VerificaIncidencia(cod) = 0 Then
                    OBE.PropPAQCODIGO = cod
                    OBL.EliminarTodo(OBE)
                    CargaGrilla()
                    CargaRecursosDisponible()
                Else
                    Util.MSG_ALERTA(" EL PAQUETE SE ENCUENTRA ASIGNADO A UNA INCIDENCIA... NO ES POSIBLE ELIMINAR ", Me)
                    Exit Sub
                End If

            Else
                Util.MSG_ALERTA(" DEBE SELECCIONAR UN REGISTRO ", Me)
            End If
        Catch ex As Exception
            lblMensaje.Text = "No es posible eliminar un paquete con transacción"
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub btnVer_Click(sender As Object, e As System.EventArgs) Handles btnVer.Click
        If (gvDatos.SelectedIndex + (gvDatos.PageIndex * gvDatos.PageSize)) >= 0 Then
            Dim tur As String = ViewState("smlturcodigo").ToString
            Dim dtur As String = ViewState("dtur")
            Dim fec As String = txtFechaBusca.Text.Trim
            Response.Redirect("frmRegistraPaqueteRecurso.aspx?acc=V&sec=&nom=&tur=" & tur & "&fec=" & fec & "&dtur=" & dtur & "&cpq=" & ViewState("intpaqcodigo") & "&num=" & ViewState("numero"))
        Else
            Util.MSG_ALERTA(" DEBE SELECCIONAR UN REGISTRO ", Me)
        End If
    End Sub
End Class
