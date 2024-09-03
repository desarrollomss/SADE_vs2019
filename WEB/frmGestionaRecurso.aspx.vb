Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data
Imports Util

Partial Class frmGestionaRecurso
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
        btnNuevo.Attributes.Add("onclick", "javascript:return ValidaNuevo();")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        txtCodRecursoBus.Attributes.Add("onkeypress ", "javascript:return validarNum(event)")

        If Not Page.IsPostBack Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: MANTENIMIENTO DE RECURSOS DE SEGURIDAD ::"
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

        txtCodRecursodEdit.Attributes.Add("onkeypress ", "javascript:return validarNum(event)")

        hdTipoAccion.Value = accion
        txtCodRecursodEdit.Text = ""
        CargaCombosEdicion()

        'ddlTipoRecursoEdit
        txtDesRecursoEdit.Text = ""
        txtAltRecursoEdit.Text = ""
        txtPlacaRecursoEdit.Text = ""
        txtMarcaRecursoEdit.Text = ""
        txtModeloRecursoEdit.Text = ""
        txtPatrimRecursoEdit.Text = ""
        txtISSIRecursoEdit.Text = ""
        'ddlEstRecursoEdit

        txtCodRecursodEdit.Enabled = False
        ddlTipoRecursoEdit.Enabled = True
        txtDesRecursoEdit.Enabled = True
        txtAltRecursoEdit.Enabled = True
        txtPlacaRecursoEdit.Enabled = True
        txtMarcaRecursoEdit.Enabled = True
        txtModeloRecursoEdit.Enabled = True
        txtPatrimRecursoEdit.Enabled = True
        txtISSIRecursoEdit.Enabled = True
        ddlEstRecursoEdit.Enabled = True




        If accion = "V" Or accion = "U" Then

            If gvTetras.SelectedIndex >= 0 Then
                Dim dk As DataKey = Me.gvTetras.DataKeys(gvTetras.SelectedIndex)
                txtCodRecursodEdit.Text = dk.Item("INTRECCODIGO")
            End If
            txtCodRecursodEdit.Enabled = False


            Dim oBE As New CCORECURSO_BE
            Dim oBESel As New CCORECURSO_BE
            Dim oBL As New CCORECURSO_BL
            Try
                With oBE
                    .PropRECCODIGO = txtCodRecursodEdit.Text
                End With
                oBESel = oBL.ListarKey(oBE)

                ddlTipoRecursoEdit.SelectedValue = oBESel.PropTRECODIGO
                txtDesRecursoEdit.Text = oBESel.PropRECDESCRIPCION
                txtAltRecursoEdit.Text = oBESel.PropRECCODIGOALTERNO
                txtPlacaRecursoEdit.Text = oBESel.PropRECPLACA
                txtMarcaRecursoEdit.Text = oBESel.PropRECMARCA
                txtModeloRecursoEdit.Text = oBESel.PropRECMODELO
                txtPatrimRecursoEdit.Text = oBESel.PropRECCODIGOPATRIMONIAL
                'txtISSIRecursoEdit.Text = oBESel.prop
                ddlEstRecursoEdit.SelectedValue = oBESel.PropRECESTADO
            Catch ex As Exception
                lblMensajeReg.Text = ex.Message
            End Try

            If accion = "V" Then
                btnGrabar.Visible = False
                txtCodRecursodEdit.Enabled = False
                ddlTipoRecursoEdit.Enabled = False
                txtDesRecursoEdit.Enabled = False
                txtAltRecursoEdit.Enabled = False
                txtPlacaRecursoEdit.Enabled = False
                txtMarcaRecursoEdit.Enabled = False
                txtModeloRecursoEdit.Enabled = False
                txtPatrimRecursoEdit.Enabled = False
                txtISSIRecursoEdit.Enabled = False
                ddlEstRecursoEdit.Enabled = False
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
            Dim oCCORECURSO_BE As New CCORECURSO_BE
            Dim oCCORECURSO_BL As New CCORECURSO_BL

            Dim dk As DataKey = Me.gvTetras.DataKeys(gvTetras.SelectedIndex)
            Dim intID As Integer = dk.Item("INTRECCODIGO")
            Try
                With oCCORECURSO_BE
                    .PropRECCODIGO = intID
                End With
                oCCORECURSO_BL.Eliminar(oCCORECURSO_BE)
                CargaGrilla()
            Catch ex As Exception
                lblMensaje.Text = ex.Message
                Bitacora.Escribir(ex.Message, LogMsg.ERROR)
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
        Dim intID As Integer = dk.Item("INTRECCODIGO")  ' se pone el nombre de la llave 
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
                Dim intID2 As Integer = dk.Item("INTRECCODIGO")
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

        Dim oCCORECURSO_BL As New CCORECURSO_BL
        Dim oCCOTIPORECURSO_BL As New CCOTIPORECURSO_BL
        Dim oESTADORECURSO_BL As New CCOTABLA_BL
        Dim oESTADORECURSO_BE As New CCOTABLA_BE
        Try

            ddlTipoRecursoBus.DataSource = oCCOTIPORECURSO_BL.ListarCombo
            ddlTipoRecursoBus.DataTextField = "PropTREDESCRIPCION"
            ddlTipoRecursoBus.DataValueField = "PropTRECODIGO"
            ddlTipoRecursoBus.DataBind()
            ddlTipoRecursoBus.Items.Insert(0, "(Todos)")
            ddlTipoRecursoBus.Items(0).Value = 0

            oESTADORECURSO_BE.PropTTACODIGO = "ESTADOGENERICO1"
            ddlEstRecursoBus.DataSource = oESTADORECURSO_BL.Listar(oESTADORECURSO_BE)
            ddlEstRecursoBus.DataTextField = "DESCRIPCION"
            ddlEstRecursoBus.DataValueField = "ID"
            ddlEstRecursoBus.DataBind()
            ddlEstRecursoBus.Items.Insert(0, "(Todos)")
            ddlEstRecursoBus.Items(0).Value = -1

        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Private Sub CargaGrilla()
        Dim oBE As New CCORECURSO_BE
        Dim oCCORECURSO_BL As New CCORECURSO_BL
        Try

            With oBE
                If txtCodRecursoBus.Text.Trim = "" Then
                    .PropRECCODIGO = 0
                Else
                    .PropRECCODIGO = CType(txtCodRecursoBus.Text, Int32)
                End If
                .PropRECDESCRIPCION = txtDesRecursoBus.Text.ToUpper
                .PropRECCODIGOALTERNO = txtDesAltRecursoBus.Text.ToUpper
                .PropTRECODIGO = ddlTipoRecursoBus.SelectedValue
                .PropRECESTADO = ddlEstRecursoBus.SelectedValue
            End With
            Dim dt As DataTable = New DataTable
            dt = oCCORECURSO_BL.Busqueda(oBE)
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

    Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        ModoBusqueda()
    End Sub

    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

        Dim oCCORECURSO_BE As New CCORECURSO_BE
        Dim oCCORECURSO_BL As New CCORECURSO_BL


        lblMensajeReg.Text = ""
        If ddlTipoRecursoEdit.SelectedItem.Text = "(Seleccione)" Then
            lblMensajeReg.Text = "<li>Seleccione el Tipo de componente</li>"
        End If
        If ddlEstRecursoEdit.SelectedItem.Text = "(Seleccione)" Then
            lblMensajeReg.Text = lblMensajeReg.Text & "<li>Seleccione el Estado de componente</li>"
        End If


        If lblMensajeReg.Text = "" Then
            Try

                With oCCORECURSO_BE
                    If (txtCodRecursodEdit.Text <> "") Then
                        .PropRECCODIGO = txtCodRecursodEdit.Text
                    End If
                    .PropRECDESCRIPCION = txtDesRecursoEdit.Text.ToUpper
                    .PropRECCODIGOALTERNO = txtAltRecursoEdit.Text.ToUpper
                    .PropRECMARCA = txtMarcaRecursoEdit.Text.ToUpper
                    .PropRECMODELO = txtModeloRecursoEdit.Text.ToUpper
                    .PropRECPLACA = txtModeloRecursoEdit.Text.ToUpper
                    .PropRECESTADO = ddlEstRecursoEdit.SelectedValue
                    .PropTRECODIGO = ddlTipoRecursoEdit.SelectedValue
                    .PropRECCODIGOPATRIMONIAL = txtPatrimRecursoEdit.Text.ToUpper
                    .PropAUDPRGCREACION = Session("APP")
                    .PropAUDPRGMODIF = Session("APP")
                    .PropAUDEQPCREACION = Session("EQUIPO")
                    .PropAUDEQPMODIF = Session("EQUIPO")
                    .PropAUDFECCREACION = Now.Date
                    .PropAUDFECMODIF = Now.Date
                    .PropAUDUSUCREACION = Session("USUARIO")
                    .PropAUDUSUMODIF = Session("USUARIO")
                End With


                Dim intID As Integer = 0
                If hdTipoAccion.Value = "I" Then
                    intID = oCCORECURSO_BL.Insertar(oCCORECURSO_BE)
                    lblMensajeReg.Text = "Se Registro de manera Exitosa"

                ElseIf hdTipoAccion.Value = "U" Then
                    oCCORECURSO_BL.Actualizar(oCCORECURSO_BE)
                    lblMensajeReg.Text = "Se Actualizó de manera Exitosa"
                End If
                ModoBusqueda()

            Catch ex As Exception
                lblMensajeReg.Text = ex.Message
                Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            End Try
        End If

    End Sub

#End Region

#Region "Metodos Edicion"

    Private Sub CargaCombosEdicion()

        Dim oCCORECURSO_BL As New CCORECURSO_BL
        Dim oCCOTIPORECURSO_BL As New CCOTIPORECURSO_BL
        Dim oESTADORECURSO_BL As New CCOTABLA_BL
        Dim oESTADORECURSO_BE As New CCOTABLA_BE
        Try

            ddlTipoRecursoEdit.DataSource = oCCOTIPORECURSO_BL.ListarCombo
            ddlTipoRecursoEdit.DataTextField = "PropTREDESCRIPCION"
            ddlTipoRecursoEdit.DataValueField = "PropTRECODIGO"
            ddlTipoRecursoEdit.DataBind()
            ddlTipoRecursoEdit.Items.Insert(0, "(Seleccione)")
            ddlTipoRecursoEdit.Items(0).Value = 0

            oESTADORECURSO_BE.PropTTACODIGO = "ESTADOGENERICO1"
            ddlEstRecursoEdit.DataSource = oESTADORECURSO_BL.Listar(oESTADORECURSO_BE)
            ddlEstRecursoEdit.DataTextField = "DESCRIPCION"
            ddlEstRecursoEdit.DataValueField = "ID"
            ddlEstRecursoEdit.DataBind()
            ddlEstRecursoEdit.Items.Insert(0, "(Seleccione)")
            ddlEstRecursoEdit.Items(0).Value = -1

        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub


#End Region

    Protected Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Dim oBE As New CCORECURSO_BE
        Dim oCCORECURSO_BL As New CCORECURSO_BL
        Try

            With oBE
                If txtCodRecursoBus.Text.Trim = "" Then
                    .PropRECCODIGO = 0
                Else
                    .PropRECCODIGO = CType(txtCodRecursoBus.Text, Int32)
                End If
                .PropRECDESCRIPCION = txtDesRecursoBus.Text.ToUpper
                .PropRECCODIGOALTERNO = txtDesAltRecursoBus.Text.ToUpper
                .PropTRECODIGO = ddlTipoRecursoBus.SelectedValue
                .PropRECESTADO = ddlEstRecursoBus.SelectedValue
            End With
            Dim dt As DataTable = New DataTable
            Dim GV As GridView = New GridView
            dt = oCCORECURSO_BL.Busqueda(oBE)
            GV.DataSource = dt
            GV.DataBind()
            GridViewExportUtil.ExportaUsuario("RecursosSeguridad.xls", GV)
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub
End Class
