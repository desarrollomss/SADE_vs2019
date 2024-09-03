Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data
Imports Util

Partial Class frmBuscaCargasFIS
    Inherits System.Web.UI.Page

#Region "Eventos Iniciales"

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txtID.Attributes.Add("onkeypress ", "javascript:return validarNum(event)")

        If Not Page.IsPostBack Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: GESTIONAR CARGAS FISCALIZACION ::"
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
        btnGrabar.Visible = True

        txtIdEdit.Attributes.Add("onkeypress ", "javascript:return validarNum(event)")

        hdTipoAccion.Value = accion
        txtIdEdit.Text = ""
        CargaCombosEdicion()


        txtInfoEdit.Text = ""
        txtObservacionEdit.Text = ""
        txtDescripcionEdit.Text = ""
        txtContactoEdit.Text = ""
        txtIPRedEdit.Text = ""
        hfGeoX.Value = ""
        hfGeoY.Value = ""
        txtFechaInstEdit.Text = ""

        txtIdEdit.Enabled = False
        txtInfoEdit.Enabled = False
        ddlTipoCmpntEdit.Enabled = True
        ddlEstadoCmpntEdit.Enabled = True
        txtObservacionEdit.Enabled = True
        txtDescripcionEdit.Enabled = True
        txtContactoEdit.Enabled = True
        txtIPRedEdit.Enabled = True



        If accion = "V" Or accion = "U" Then

            If gvTetras.SelectedIndex >= 0 Then
                Dim dk As DataKey = Me.gvTetras.DataKeys(gvTetras.SelectedIndex)
                txtIdEdit.Text = dk.Item("idcs")
            End If
            txtIdEdit.Enabled = False


            Dim oBE As TB_COMPSEG_BE = New TB_COMPSEG_BE
            Dim oBESel As TB_COMPSEG_BE = New TB_COMPSEG_BE
            Dim oBL As TB_COMPSEG_BL = New TB_COMPSEG_BL
            Try
                With oBE
                    .PropIDCS = txtIdEdit.Text
                End With
                oBESel = oBL.ListarKey(oBE)

                ddlTipoCmpntEdit.SelectedValue = oBESel.PropIDCST
                ddlEstadoCmpntEdit.SelectedValue = oBESel.PropIDCSE
                If oBESel.PropIDCS_PADRE IsNot Nothing Then
                    ddlGrupoCmpntEdit.SelectedValue = oBESel.PropIDCS_PADRE
                End If
                txtFechaInstEdit.Text = oBESel.PropFECINST_CS
                txtInfoEdit.Text = oBESel.PropINFO_CS.ToUpper
                txtObservacionEdit.Text = oBESel.PropOBSERV_EST.ToUpper
                txtDescripcionEdit.Text = oBESel.PropDIRECCION.ToUpper
                txtContactoEdit.Text = oBESel.PropCOMUNICA_CS.ToUpper
                txtIPRedEdit.Text = oBESel.PropIPRED_CS
                hfGeoX.Value = oBESel.PropGeoX
                hfGeoY.Value = oBESel.PropGeoY

            Catch ex As Exception
                lblMensajeReg.Text = ex.Message
            End Try

            If accion = "V" Then
                btnGrabar.Visible = False
                txtObservacionEdit.Enabled = False
                txtDescripcionEdit.Enabled = False
                txtContactoEdit.Enabled = False
                txtIPRedEdit.Enabled = False
                ddlGrupoCmpntEdit.Enabled = False
                txtFechaInstEdit.Enabled = False
                ddlTipoCmpntEdit.Enabled = False
                ddlEstadoCmpntEdit.Enabled = False
                txtObservacionEdit.Enabled = False
            End If

        End If
    End Sub

#End Region

#Region "Eventos Busqueda"

    Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        ModoEdicion("I")
    End Sub

    Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        If gvTetras.SelectedIndex >= 0 Then
            ModoEdicion("U")
        End If
    End Sub

    Protected Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        If gvTetras.SelectedIndex >= 0 Then
            Dim oBE As TB_COMPSEG_BE = New TB_COMPSEG_BE
            Dim oBL As TB_COMPSEG_BL = New TB_COMPSEG_BL

            Dim dk As DataKey = Me.gvTetras.DataKeys(gvTetras.SelectedIndex)
            Dim intID As Integer = dk.Item("idcs")
            Try
                With oBE
                    .PropIDCS = intID
                End With
                oBL.Eliminar(oBE)
                CargaGrilla()
            Catch ex As Exception
                'lblMensaje.Text = ex.Message
            End Try
        End If

    End Sub

    Protected Sub btnVer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVer.Click
        If gvTetras.SelectedIndex >= 0 Then
            ModoEdicion("V")
        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargaGrilla()
    End Sub

    Protected Sub gvTetras_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvTetras.SelectedIndexChanged
        Dim dk As DataKey = Me.gvTetras.DataKeys(gvTetras.SelectedIndex) '-- es la fila de la grilla 
        Dim intID As Integer = dk.Item("INTNISSI")  ' se pone el nombre de la llave 
        ViewState("dkincidencia") = intID
        ViewState("oRowIndex") = gvTetras.SelectedIndex
    End Sub

    Protected Sub gvTetras_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTetras.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onmouseover") = "javascript: this.style.cursor='pointer';"
            e.Row.Attributes("onmouseout") = "javascript: this.style.cursor='normal';"
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(gvTetras, "Select$" + e.Row.RowIndex.ToString)

        End If
    End Sub

    Protected Sub gvTetras_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTetras.RowDataBound
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

    Protected Sub gvTetras_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvTetras.PageIndexChanging
        gvTetras.PageIndex = e.NewPageIndex
        gvTetras.DataSource = ViewState("datos")
        gvTetras.DataBind()
    End Sub

#End Region

#Region "Metodos Busqueda"

    Private Sub CargaComboBusqueda()

        Dim oTB_COMPSEG_BL As TB_COMPSEG_BL = New TB_COMPSEG_BL
        Try

            ddlTipoCmpnt.DataSource = oTB_COMPSEG_BL.ListarComboTipoCmpnt()
            ddlTipoCmpnt.DataTextField = "DESCRIPCION"
            ddlTipoCmpnt.DataValueField = "CODIGO"
            ddlTipoCmpnt.DataBind()
            ddlTipoCmpnt.Items.Insert(0, "(Seleccione)")
            ddlTipoCmpnt.Items(0).Value = 0

            ddlEstadoCmpnt.DataSource = oTB_COMPSEG_BL.ListarComboEstadoCmpnt()
            ddlEstadoCmpnt.DataTextField = "DESCRIPCION"
            ddlEstadoCmpnt.DataValueField = "CODIGO"
            ddlEstadoCmpnt.DataBind()
            ddlEstadoCmpnt.Items.Insert(0, "(Seleccione)")
            ddlEstadoCmpnt.Items(0).Value = 0

            ddlGrupoCmpnt.DataSource = oTB_COMPSEG_BL.ListarComboGrupoCmpnt()
            ddlGrupoCmpnt.DataTextField = "DESCRIPCION"
            ddlGrupoCmpnt.DataValueField = "CODIGO"
            ddlGrupoCmpnt.DataBind()
            ddlGrupoCmpnt.Items.Insert(0, "(Seleccione)")
            ddlGrupoCmpnt.Items(0).Value = 0


        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

    Private Sub CargaGrilla()

        Dim oBE As FISPREDIO_BE = New FISPREDIO_BE
        Dim oBL As SYSCATASTRO_BL = New SYSCATASTRO_BL
        Try

            With oBE
                .p_VCHCODCAT = ""
                .p_SMLFISESTADO = 0
                .p_VCHCODSEC = ""
                .p_VCHCODURB = ""
            End With
            Dim dt As DataTable = New DataTable
            dt = oBL.BuscarLoteFIS(oBE)
            ViewState("datos") = dt
            gvTetras.DataSource = dt
            gvTetras.DataBind()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

#End Region

#Region "Eventos Edicion"

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        ModoBusqueda()
    End Sub

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        Dim oBE As TB_COMPSEG_BE = New TB_COMPSEG_BE
        Dim oBL As TB_COMPSEG_BL = New TB_COMPSEG_BL

        lblMensajeReg.Text = ""
        'If txtIdEdit.Text.Trim = "" Or txtIdEdit.Text.Trim = "0" Then
        '    lblMensajeReg.Text = "<li>Ingrese el Código</li>"
        'End If
        If ddlTipoCmpntEdit.SelectedItem.Text = "(Seleccione)" Then
            lblMensajeReg.Text = "<li>Seleccione el Tipo de componente</li>"
        End If
        If ddlEstadoCmpntEdit.SelectedItem.Text = "(Seleccione)" Then
            lblMensajeReg.Text = lblMensajeReg.Text & "<li>Seleccione el Estado de componente</li>"
        End If
        If hfGeoX.Value.ToString = "" Or hfGeoY.Value.ToString = "" Then
            lblMensajeReg.Text = lblMensajeReg.Text & "<li>Ubique en el mapa la ubicacion del componente</li>"
        End If

        If txtFechaInstEdit.Text.ToString = "" Then
            lblMensajeReg.Text = lblMensajeReg.Text & "<li>Ingrese fecha de instalacion</li>"
        End If


        If lblMensajeReg.Text = "" Then
            Try

                With oBE
                    If (txtIdEdit.Text <> "") Then
                        .PropIDCS = txtIdEdit.Text
                    End If

                    .PropDIRECCION = txtDescripcionEdit.Text.ToUpper
                    .PropGEOM = hfGeoX.Value.ToString + " " + hfGeoY.Value.ToString
                    .PropIDCST = ddlTipoCmpntEdit.SelectedValue
                    .PropIDCSE = ddlEstadoCmpntEdit.SelectedValue
                    .PropOBSERV_EST = txtObservacionEdit.Text.ToUpper
                    .PropINFO_CS = txtInfoEdit.Text.ToUpper
                    .PropIDCS_PADRE = Nothing
                    .PropCOMUNICA_CS = txtContactoEdit.Text.ToUpper
                    .PropIPRED_CS = txtIPRedEdit.Text
                    .PropAUDUSUARIO_CREA = Session("USUARIO")
                    .PropAUDEQUIPO_CREA = Session("EQUIPO")
                    .PropAUDFECHA_CREA = Now.Date
                    .PropFECINST_CS = txtFechaInstEdit.Text
                    If ddlGrupoCmpntEdit.SelectedValue <> 0 Then
                        .PropIDCS_PADRE = ddlGrupoCmpntEdit.SelectedValue
                    End If
                End With
                Dim intID As Integer = 0
                If hdTipoAccion.Value = "I" Then

                    intID = oBL.Insertar(oBE)
                    If intID > 0 Then
                        lblMensajeReg.Text = "Se Registro de manera Exitosa"
                        ModoBusqueda()
                    Else
                        lblMensajeReg.Text = "Problemas de insercion!!!"
                    End If

                ElseIf hdTipoAccion.Value = "U" Then
                    oBL.Actualizar(oBE)
                    lblMensajeReg.Text = "Se Actualizó de manera Exitosa"
                    ModoBusqueda()
                End If
            Catch ex As Exception
                lblMensajeReg.Text = ex.Message
            End Try
        End If

    End Sub

#End Region

#Region "Metodos Edicion"

    Private Sub CargaCombosEdicion()
        Dim oTB_COMPSEG_BL As TB_COMPSEG_BL = New TB_COMPSEG_BL
        Try
            ddlTipoCmpntEdit.DataSource = oTB_COMPSEG_BL.ListarComboTipoCmpnt()
            ddlTipoCmpntEdit.DataTextField = "DESCRIPCION"
            ddlTipoCmpntEdit.DataValueField = "CODIGO"
            ddlTipoCmpntEdit.DataBind()
            ddlTipoCmpntEdit.Items.Insert(0, "(Seleccione)")
            ddlTipoCmpntEdit.Items(0).Value = 0

            ddlEstadoCmpntEdit.DataSource = oTB_COMPSEG_BL.ListarComboEstadoCmpnt()
            ddlEstadoCmpntEdit.DataTextField = "DESCRIPCION"
            ddlEstadoCmpntEdit.DataValueField = "CODIGO"
            ddlEstadoCmpntEdit.DataBind()
            ddlEstadoCmpntEdit.Items.Insert(0, "(Seleccione)")
            ddlEstadoCmpntEdit.Items(0).Value = 0

            ddlGrupoCmpntEdit.DataSource = oTB_COMPSEG_BL.ListarComboGrupoCmpnt()
            ddlGrupoCmpntEdit.DataTextField = "DESCRIPCION"
            ddlGrupoCmpntEdit.DataValueField = "CODIGO"
            ddlGrupoCmpntEdit.DataBind()
            ddlGrupoCmpntEdit.Items.Insert(0, "(Seleccione)")
            ddlGrupoCmpntEdit.Items(0).Value = 0

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub


#End Region

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click

        Dim oBE As TB_COMPSEG_BE = New TB_COMPSEG_BE
        Dim oBL As TB_COMPSEG_BL = New TB_COMPSEG_BL
        Try
            With oBE
                If txtID.Text.Trim = "" Then .PropIDCS = 0 Else .PropIDCS = CType(txtID.Text, Int32)
                .PropDIRECCION = txtDescripcion.Text.ToUpper
                .PropIDCST = ddlTipoCmpnt.SelectedValue
                .PropIDCSE = ddlEstadoCmpnt.SelectedValue
            End With
            Dim dt As DataTable = New DataTable
            Dim GV As GridView = New GridView
            dt = oBL.Listar(oBE)
            GV.DataSource = dt
            GV.DataBind()
            GridViewExportUtil.ExportaUsuario("ComponenteSeguridad.xls", GV)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try



    End Sub
End Class
