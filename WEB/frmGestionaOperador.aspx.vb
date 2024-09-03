Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data
Partial Class frmGestionaOperador
    Inherits System.Web.UI.Page
    Dim oSCUROL_BE As New SCUROL_BE
    Dim oSCUROL_BL As New SCUROL_BL


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: MANTENIMIENTO DE OPERADORES Y PERFILES "
            CargaCombos()
            CargaGrilla()

        End If
    End Sub
    Private Sub CargaCombos()

        Dim oESTADO_BL As New CCOTABLA_BL
        Dim oESTADO_BE As New CCOTABLA_BE

        With ddlRolOperadorBus
            .DataSource = oSCUROL_BL.ListarCombo
            .DataTextField = "VCHROLDESCRIP"
            .DataValueField = "INTROLCODIGO"
        End With
        ddlRolOperadorBus.DataBind()
        ddlRolOperadorBus.Items.Insert(0, New ListItem("(Todos)", "0"))

        oESTADO_BE.PropTTACODIGO = "ESTADOGENERICO1"
        ddlEstOperadorBus.DataSource = oESTADO_BL.Listar(oESTADO_BE)
        ddlEstOperadorBus.DataTextField = "DESCRIPCION"
        ddlEstOperadorBus.DataValueField = "ID"
        ddlEstOperadorBus.DataBind()
        ddlEstOperadorBus.Items.Insert(0, "(Todos)")
        ddlEstOperadorBus.Items(0).Value = -1

    End Sub

    Private Sub CargaGrilla()
        Dim oCCOUSUARIOSESION_BL As New CCOUSUARIOSESION_BL
        Try
            Dim dt As DataTable = New DataTable
            dt = oCCOUSUARIOSESION_BL.Busqueda(txtUsuOperadorBus.Text.ToUpper, ddlRolOperadorBus.SelectedValue, ddlEstOperadorBus.SelectedValue)
            ViewState("dt") = dt
            gvDatos.DataSource = dt
            gvDatos.DataBind()
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub btnEliminarUsuario_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tabla As Tabla = New Tabla
        tabla.Datos = CType(ViewState("dt"), DataTable)
        Try
            Dim gwrow As GridViewRow = CType(CType(sender, Button).NamingContainer, GridViewRow)
            Dim oCCOUSUARIOSESION_BL As New CCOUSUARIOSESION_BL

            Dim oUsuario As String = tabla.Datos.Rows(gwrow.DataItemIndex).Item("USUARIO")

            oCCOUSUARIOSESION_BL.EliminarUsuario(oUsuario)
            CargaGrilla()
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub gvDatos_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvDatos.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dcfc As DataControlFieldCell = CType(e.Row.Controls(1), DataControlFieldCell)
            Dim btnActivarUsuario As Button = CType(e.Row.FindControl("btnActivarUsuario"), Button)
            If dcfc.Text = "ACTIVO" Then
                btnActivarUsuario.Text = "Desactivar Usuario"
                btnActivarUsuario.BackColor = Drawing.Color.FromName("#888484")
            Else
                btnActivarUsuario.Text = " Activar Usuario "
                btnActivarUsuario.BackColor = Drawing.Color.FromName("#8DAA33")
            End If
            Dim ddlSCUROL As DropDownList = CType(e.Row.FindControl("ddlRolUsuario"), DropDownList)
            Dim hfSCUROL As HiddenField = CType(e.Row.FindControl("hfRolUsuario"), HiddenField)


            With ddlSCUROL
                .DataSource = oSCUROL_BL.ListarCombo
                .DataTextField = "VCHROLDESCRIP"
                .DataValueField = "INTROLCODIGO"
            End With
            ddlSCUROL.DataBind()
            ddlSCUROL.Items.Insert(0, New ListItem("(Ninguno)", "0"))
            If (hfSCUROL IsNot Nothing) Then
                ddlSCUROL.SelectedValue = hfSCUROL.Value
            End If
        End If
    End Sub

    Protected Sub btnActivarUsuario_Click(sender As Object, e As System.EventArgs)
        Dim tabla As Tabla = New Tabla
        tabla.Datos = CType(ViewState("dt"), DataTable)
        Try
            Dim gwrow As GridViewRow = CType(CType(sender, Button).NamingContainer, GridViewRow)
            Dim oSYS_BL As SYSESTACION_BL = New SYSESTACION_BL

            Dim oUsuario As String = tabla.Datos.Rows(gwrow.DataItemIndex).Item("USUARIO")
            Dim oEstado As String = tabla.Datos.Rows(gwrow.DataItemIndex).Item("ESTADO")

            If oEstado = "ACTIVO" Then
                oSYS_BL.ActivaSesion(oUsuario, 0)
            Else
                oSYS_BL.ActivaSesion(oUsuario, 1)
            End If
            CargaGrilla()
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub btnLiberarSesion_Click(sender As Object, e As System.EventArgs)
        Dim tabla As Tabla = New Tabla
        tabla.Datos = CType(ViewState("dt"), DataTable)
        Try
            Dim gwrow As GridViewRow = CType(CType(sender, Button).NamingContainer, GridViewRow)
            Dim oSYS_BL As SYSESTACION_BL = New SYSESTACION_BL

            Dim oUsuario As String = tabla.Datos.Rows(gwrow.DataItemIndex).Item("USUARIO")
            oSYS_BL.LiberarAlerta(0, oUsuario)
            CargaGrilla()
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub


    Protected Sub ddlRolUsuario_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tabla As Tabla = New Tabla
        tabla.Datos = CType(ViewState("dt"), DataTable)
        Try
            Dim gwrow As GridViewRow = CType(CType(sender, DropDownList).NamingContainer, GridViewRow)
            Dim ddlROL As DropDownList = CType(sender, DropDownList)
            Dim oCCOUSUARIOSESION_BL As New CCOUSUARIOSESION_BL
            Dim oCCOUSUARIOSESION_BE As New CCOUSUARIOSESION_BE
            Dim oUsuario As String = tabla.Datos.Rows(gwrow.DataItemIndex).Item("USUARIO")

            oCCOUSUARIOSESION_BE.PropUSUARIO = oUsuario
            oCCOUSUARIOSESION_BE.PropROLCODIGO = ddlROL.SelectedValue
            oCCOUSUARIOSESION_BE.PropAUDUSUMODIF = CType(Session("Usuario"), String)
            oCCOUSUARIOSESION_BE.PropAUDFECMODIF = Now.Date
            oCCOUSUARIOSESION_BE.PropAUDPRGMODIF = CType(Session("proyecto"), String)
            oCCOUSUARIOSESION_BE.PropAUDEQPMODIF = CType(Session("equipo"), String)

            oCCOUSUARIOSESION_BL.AsignaRol(oCCOUSUARIOSESION_BE)
            CargaGrilla()

        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargaGrilla()
    End Sub


    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        MostrarPopup("agregarOperador")
        txtUsuarioAdd.Focus()
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
        Dim oCCOUSUARIOSESION_BL As New CCOUSUARIOSESION_BL
        Dim oCCOUSUARIOSESION_BE As New CCOUSUARIOSESION_BE
        Try
            If (txtUsuarioAdd.Text = String.Empty Or txtUsuarioAdd.Text = "Escribe el nombre de usuario") Then
                Exit Sub
            End If
            oCCOUSUARIOSESION_BE.PropUSUIDENTIFICADOR = 0
            oCCOUSUARIOSESION_BE.PropUSUARIO = txtUsuarioAdd.Text.ToUpper
            oCCOUSUARIOSESION_BE.PropAUDUSUCREACION = CType(Session("Usuario"), String)
            oCCOUSUARIOSESION_BE.PropAUDFECCREACION = Now.Date
            oCCOUSUARIOSESION_BE.PropAUDPRGCREACION = CType(Session("proyecto"), String)
            oCCOUSUARIOSESION_BE.PropAUDEQPCREACION = CType(Session("equipo"), String)

            oCCOUSUARIOSESION_BL.InsertarUsuario(oCCOUSUARIOSESION_BE)
            CargaGrilla()
            txtUsuarioAdd.Text = "Escribe el nombre de usuario"
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub


End Class
