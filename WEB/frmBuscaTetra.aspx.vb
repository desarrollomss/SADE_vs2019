Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data
Imports Util

Partial Class frmBuscaTetra
    Inherits System.Web.UI.Page

#Region "Eventos Iniciales"

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        If Session("DatosUsuarioActivo") Is Nothing Then
            Session.Clear()
            Session.Abandon()
            Response.Redirect(Request.ApplicationPath & "/frmLogin.aspx")
        End If
        ViewState("dkincidencia") = 0
        ViewState("oRowIndex") = -1
        btnBuscar.Attributes.Add("onclick", "javascript:return ValidaBuscar();")
        'btnActualizaBusca.Attributes.Add("onclick", "javascript:return ValidaActualizaBusca();")
        btnNuevo.Attributes.Add("onclick", "javascript:return ValidaNuevo();")
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        txtISSI.Attributes.Add("onkeypress ", "javascript:return validarNum(event)")

        If Not Page.IsPostBack Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: GESTIONAR RECURSOS TETRA"
            CargaComboBusqueda()
            CargaGrilla()
        End If
    End Sub

#End Region

#Region "Modos"

    Private Sub ModoBusqueda()
        pnlEdicion.Visible = False
        pnlBusqueda.Visible = True
        lblMensajeReg.Text = ""
        CargaGrilla()
    End Sub

    Private Sub ModoEdicion(ByVal accion As String)
        pnlEdicion.Visible = True
        pnlBusqueda.Visible = False

        txtISSIEdit.Attributes.Add("onkeypress ", "javascript:return validarNum(event)")

        hdTipoAccion.Value = accion
        txtISSIEdit.Text = ""
        CargaCombosEdicion()

        hdIdPersonalEdit.Value = "0"
        txtPersonalEdit.Text = ""
        txtObservacion.Text = ""

        txtISSIEdit.Enabled = True
        ddlSectorEdit.Enabled = True
        ddlTipoRecursoEdit.Enabled = True
        txtObservacion.Enabled = True
        ddlEstadoEdit.Enabled = True
        btnBuscarPer.Visible = True

        btnBuscarPer.Visible = True

        
        If accion = "V" Or accion = "U" Then

            If gvTetras.SelectedIndex >= 0 Then
                Dim dk As DataKey = Me.gvTetras.DataKeys(gvTetras.SelectedIndex)
                txtISSIEdit.Text = dk.Item("INTNISSI")
            End If
            txtISSIEdit.Enabled = False


            Dim oBE As GPSTETRA_BE = New GPSTETRA_BE
            Dim oBESel As GPSTETRA_BE = New GPSTETRA_BE
            Dim oBL As GPSTETRA_BL = New GPSTETRA_BL
            Try
                With oBE
                    .PropNISSI = txtISSIEdit.Text
                End With
                oBESel = oBL.ListarKey(oBE)

                ddlSectorEdit.SelectedValue = oBESel.PropSECCODIGO
                ddlTipoRecursoEdit.SelectedValue = oBESel.PropTRECODIGO
                If oBESel.PropPERCODIGO Is Nothing Then hdIdPersonalEdit.Value = "0" Else hdIdPersonalEdit.Value = oBESel.PropPERCODIGO
                txtPersonalEdit.Text = oBESel.PropAUDPRGCREACION
                txtObservacion.Text = oBESel.PropOBSERVACION
                ddlEstadoEdit.SelectedValue = oBESel.PropESTADO
            Catch ex As Exception
                lblMensajeReg.Text = ex.Message
                Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            End Try

            If accion = "V" Then
                ddlSectorEdit.Enabled = False
                ddlTipoRecursoEdit.Enabled = False
                txtObservacion.Enabled = False
                ddlEstadoEdit.Enabled = False
                btnBuscarPer.Visible = False

            End If
            
        End If
    End Sub

#End Region

#Region "Eventos Busqueda"

    Protected Sub btnNuevo_Click(sender As Object, e As System.EventArgs) Handles btnNuevo.Click
        ModoEdicion("I")
    End Sub

    Protected Sub btnModificar_Click(sender As Object, e As System.EventArgs) Handles btnModificar.Click
        If gvTetras.SelectedIndex >= 0 Then
            ModoEdicion("U")
        End If
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As System.EventArgs) Handles btnEliminar.Click
        If gvTetras.SelectedIndex >= 0 Then
            Dim oBE As GPSTETRA_BE = New GPSTETRA_BE
            Dim oBL As GPSTETRA_BL = New GPSTETRA_BL

            Dim dk As DataKey = Me.gvTetras.DataKeys(gvTetras.SelectedIndex)
            Dim intID As Integer = dk.Item("INTNISSI")
            Try
                With oBE
                    .PropNISSI = intID
                End With
                oBL.Eliminar(oBE)
                CargaGrilla()
            Catch ex As Exception
                'lblMensaje.Text = ex.Message
                Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            End Try
        End If

    End Sub

    Protected Sub btnVer_Click(sender As Object, e As System.EventArgs) Handles btnVer.Click
        If gvTetras.SelectedIndex >= 0 Then
            ModoEdicion("V")
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        CargaGrilla()
    End Sub

    Protected Sub gvTetras_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvTetras.SelectedIndexChanged
        Dim dk As DataKey = Me.gvTetras.DataKeys(gvTetras.SelectedIndex) '-- es la fila de la grilla 
        Dim intID As Integer = dk.Item("INTNISSI")  ' se pone el nombre de la llave 
        ViewState("dkincidencia") = intID
        ViewState("oRowIndex") = gvTetras.SelectedIndex
    End Sub

    Protected Sub gvTetras_RowCreated(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTetras.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "javascript: this.style.cursor='pointer';"
            e.Row.Attributes("onmouseout") = "javascript: this.style.cursor='normal';"
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvTetras, "Select$" + e.Row.RowIndex.ToString)

        End If
    End Sub

    Protected Sub gvTetras_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTetras.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If gvTetras.PageSize < 10 Then
                Dim dk As DataKey = Me.gvTetras.DataKeys(e.Row.DataItemIndex)
                Dim intID2 As Integer = dk.Item("INTNISSI")
                If intID2 = ViewState("dkincidencia") Then
                    ViewState("oRowIndex") = e.Row.RowIndex
                    For i = 0 To e.Row.Cells.Count - 1
                        Dim dcfc2 As DataControlFieldCell = CType(e.Row.Controls(i), DataControlFieldCell)
                        dcfc2.BackColor = Drawing.Color.FromName("#a3a2a7")
                        dcfc2.ForeColor = Drawing.Color.FromName("#F0F0F0")
                    Next
                End If
            End If
        End If
    End Sub

    Protected Sub gvTetras_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvTetras.PageIndexChanging
        gvTetras.PageIndex = e.NewPageIndex
        gvTetras.DataSource = ViewState("datos")
        gvTetras.DataBind()
    End Sub

#End Region

#Region "Metodos Busqueda"

    Private Sub CargaComboBusqueda()

        Dim oCCOSECTOR_BL As CCOSECTOR_BL = New CCOSECTOR_BL
        Dim oCCOTIPORECURSO_BL As CCOTIPORECURSO_BL = New CCOTIPORECURSO_BL
        Try

            ddlSectorBusca.DataSource = oCCOSECTOR_BL.ListarCombo
            ddlSectorBusca.DataTextField = "PropSECDESCRIPCION"
            ddlSectorBusca.DataValueField = "PropSECCODIGO"
            ddlSectorBusca.DataBind()
            ddlSectorBusca.Items.Insert(0, "(Ver Todos)")
            ddlSectorBusca.Items(0).Value = 0

            ddlTipoRecurso.DataSource = oCCOTIPORECURSO_BL.ListarCombo
            ddlTipoRecurso.DataTextField = "PropTREDESCRIPCION"
            ddlTipoRecurso.DataValueField = "PropTRECODIGO"
            ddlTipoRecurso.DataBind()
            ddlTipoRecurso.Items.Insert(0, "(Ver Todos)")
            ddlTipoRecurso.Items(0).Value = 0

            ddlEstado.Items.Clear()
            ddlEstado.Items.Insert(0, "Inactivo")
            ddlEstado.Items.Insert(0, "Activo")
            ddlEstado.Items.Insert(0, "(Ver Todos)")
            ddlEstado.Items(0).Value = -1
            ddlEstado.Items(1).Value = 1
            ddlEstado.Items(2).Value = 0

        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Private Sub CargaGrilla()

        Dim oBE As GPSTETRA_BE = New GPSTETRA_BE
        Dim oBL As GPSTETRA_BL = New GPSTETRA_BL
        Try

            With oBE
                If txtISSI.Text.Trim = "" Then .PropNISSI = 0 Else .PropNISSI = CType(txtISSI.Text, Int32)
                .PropOBSERVACION = txtPersonal.Text.ToUpper
                .PropTRECODIGO = ddlTipoRecurso.SelectedValue
                .PropSECCODIGO = ddlSectorBusca.SelectedValue
                .PropESTADO = ddlEstado.SelectedValue
            End With
            Dim dt As DataTable = New DataTable
            dt = oBL.Listar(oBE)
            ViewState("datos") = dt
            gvTetras.DataSource = dt
            gvTetras.DataBind()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

#End Region

#Region "Eventos Edicion"

    Protected Sub btnRegresar_Click(sender As Object, e As System.EventArgs) Handles btnRegresar.Click
        ModoBusqueda()
    End Sub

    Protected Sub btnBuscarPersonal_Click(sender As Object, e As System.EventArgs) Handles btnBuscarPersonal.Click
        CargaGrillaPersonal()
    End Sub

    Protected Sub gvPersonal_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPersonal.RowCommand

        Dim comando As String = e.CommandName
        Dim currentRowIndex As Integer = Int32.Parse(e.CommandArgument.ToString())

        If gvTetras.PageSize >= currentRowIndex Then
            Dim IDPersonal As String = gvPersonal.DataKeys(currentRowIndex).Value

            If comando = "Seleccionar" Then
                hdIdPersonalEdit.Value = IDPersonal
                txtPersonalEdit.Text = gvPersonal.Rows(currentRowIndex).Cells(1).Text

                Dim sb As New StringBuilder
                sb.Append("<script>")
                sb.Append("document.getElementById('verimagen').style.display = 'none';")
                sb.Append("document.getElementById('fade').style.display = 'none';")
                sb.Append("</script>")
                ScriptManager.RegisterStartupScript(Me, Me.GetType, "Cerrar", sb.ToString, False)

            End If
        End If

    End Sub

    Protected Sub gvPersonal_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvPersonal.PageIndexChanging
        gvPersonal.PageIndex = e.NewPageIndex
        gvPersonal.DataSource = ViewState("datosPersonal")
        gvPersonal.DataBind()
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click

        Dim oBE As GPSTETRA_BE = New GPSTETRA_BE
        Dim oBL As GPSTETRA_BL = New GPSTETRA_BL

        lblMensajeReg.Text = ""
        If txtISSIEdit.Text.Trim = "" Or txtISSIEdit.Text.Trim = "0" Then
            lblMensajeReg.Text = "<li>Ingrese el Código</li>"
        End If
        If ddlSectorEdit.SelectedItem.Text = "(Seleccione)" Then
            lblMensajeReg.Text = "<li>Seleccione el Sector</li>"
        End If
        If ddlTipoRecursoEdit.SelectedItem.Text = "(Seleccione)" Then
            lblMensajeReg.Text = lblMensajeReg.Text & "<li>Seleccione el Tipo de Recurso</li>"
        End If
        If ddlEstadoEdit.SelectedItem.Text = "(Seleccione)" Then
            lblMensajeReg.Text = lblMensajeReg.Text & "<li>Seleccione el Estado</li>"
        End If

        If lblMensajeReg.Text = "" Then
            Try

                With oBE
                    .PropNISSI = txtISSIEdit.Text
                    .PropSECCODIGO = ddlSectorEdit.SelectedValue
                    .PropTRECODIGO = ddlTipoRecursoEdit.SelectedValue
                    .PropPERCODIGO = hdIdPersonalEdit.Value
                    .PropOBSERVACION = txtObservacion.Text.ToUpper
                    .PropESTADO = ddlEstadoEdit.SelectedValue
                    .PropAUDPRGCREACION = Session("PROGRAMA")
                    .PropAUDEQPCREACION = Session("EQUIPO")
                    .PropAUDUSUCREACION = Session("USUARIO")
                End With

                Dim MSG As String
                MSG = ""
                If hdTipoAccion.Value = "I" Then
                    oBL.Insertar(oBE, MSG)
                    If MSG = "" Then
                        lblMensajeReg.Text = "Se Registro de manera Exitosa"
                    Else
                        lblMensajeReg.Text = MSG
                    End If
                ElseIf hdTipoAccion.Value = "U" Then
                    oBL.Actualizar(oBE)
                    lblMensajeReg.Text = "Se Actualizó de manera Exitosa"
                End If
            Catch ex As Exception
                lblMensajeReg.Text = ex.Message
                Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            End Try
        End If

    End Sub

#End Region

#Region "Metodos Edicion"

    Private Sub CargaCombosEdicion()

        Dim oCCOSECTOR_BL As CCOSECTOR_BL = New CCOSECTOR_BL
        Dim oCCOTIPORECURSO_BL As CCOTIPORECURSO_BL = New CCOTIPORECURSO_BL
        Try

            ddlSectorEdit.DataSource = oCCOSECTOR_BL.ListarCombo
            ddlSectorEdit.DataTextField = "PropSECDESCRIPCION"
            ddlSectorEdit.DataValueField = "PropSECCODIGO"
            ddlSectorEdit.DataBind()
            ddlSectorEdit.Items.Insert(0, "(Seleccione)")
            ddlSectorEdit.Items(0).Value = 0

            ddlTipoRecursoEdit.DataSource = oCCOTIPORECURSO_BL.ListarCombo
            ddlTipoRecursoEdit.DataTextField = "PropTREDESCRIPCION"
            ddlTipoRecursoEdit.DataValueField = "PropTRECODIGO"
            ddlTipoRecursoEdit.DataBind()
            ddlTipoRecursoEdit.Items.Insert(0, "(Seleccione)")
            ddlTipoRecursoEdit.Items(0).Value = 0

            ddlEstadoEdit.Items.Clear()
            ddlEstadoEdit.Items.Insert(0, "Inactivo")
            ddlEstadoEdit.Items.Insert(0, "Activo")
            ddlEstadoEdit.Items.Insert(0, "(Seleccione)")
            ddlEstadoEdit.Items(0).Value = -1
            ddlEstadoEdit.Items(1).Value = 1
            ddlEstadoEdit.Items(2).Value = 0

        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Private Sub CargaGrillaPersonal()

        Dim oBE As CCOPERSONAL_BE = New CCOPERSONAL_BE
        Dim oBL As CCOPERSONAL_BL = New CCOPERSONAL_BL
        Try

            With oBE
                .PropPERNOMBRE = txtNomPersonal.Text.ToUpper
            End With
            Dim dt As DataTable = New DataTable
            dt = oBL.ListarNombres(oBE)
            ViewState("datosPersonal") = dt
            gvPersonal.DataSource = dt
            gvPersonal.DataBind()
            'gvPersonal.SelectedIndex = -1
        Catch ex As Exception
            'Throw ex
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

#End Region

End Class
