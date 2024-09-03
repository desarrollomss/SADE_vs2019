Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data
Partial Class frmGestionaEstacion
    Inherits System.Web.UI.Page
    Dim oSCUROL_BE As New SCUROL_BE
    Dim oSCUROL_BL As New SCUROL_BL
    Dim oSCUESTACION_BE As New SCUESTACION_BE


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim mp As MasterPage = Me.Master
            Dim tit As Label = CType(mp.FindControl("lblTitulo"), Label)
            tit.Text = ":: MANTENIMIENTO DE ESTACIONES "
            CargaCombos()
            CargaGrilla()

        End If
    End Sub
    Private Sub CargaCombos()

        Dim oESTADO_BL As New CCOTABLA_BL
        Dim oESTADO_BE As New CCOTABLA_BE

        oESTADO_BE.PropTTACODIGO = "ESTADOGENERICO1"
        ddlEstOperadorBus.DataSource = oESTADO_BL.Listar(oESTADO_BE)
        ddlEstOperadorBus.DataTextField = "DESCRIPCION"
        ddlEstOperadorBus.DataValueField = "ID"
        ddlEstOperadorBus.DataBind()
        ddlEstOperadorBus.Items.Insert(0, "(Todos)")
        ddlEstOperadorBus.Items(0).Value = -1

        ddlEstOperadorAdd.DataSource = oESTADO_BL.Listar(oESTADO_BE)
        ddlEstOperadorAdd.DataTextField = "DESCRIPCION"
        ddlEstOperadorAdd.DataValueField = "ID"
        ddlEstOperadorAdd.DataBind()
        'ddlEstOperadorAdd.Items.Insert(0, "(Seleccione)")
        'ddlEstOperadorAdd.Items(0).Value = -1


    End Sub

    Private Sub CargaGrilla()
        Dim oSCUESTACION_BL As New SCUESTACION_BL

        Try
            oSCUESTACION_BE.PropESTCNUMIP = txtUsuarioBus.Text.ToUpper
            oSCUESTACION_BE.PropESTCDESCRI = txtDescripBus.Text.ToUpper
            oSCUESTACION_BE.PropESTCESTADO = ddlEstOperadorBus.SelectedValue
            Dim dt As DataTable = New DataTable
            dt = oSCUESTACION_BL.Busqueda(oSCUESTACION_BE)
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

            Dim ddlEstado As DropDownList = CType(e.Row.FindControl("ddlEstadoEstacion"), DropDownList)
            Dim hfSEstado As HiddenField = CType(e.Row.FindControl("hfEstadoEstacion"), HiddenField)

            Dim oESTADO_BL As New CCOTABLA_BL
            Dim oESTADO_BE As New CCOTABLA_BE

            oESTADO_BE.PropTTACODIGO = "ESTADOGENERICO1"
            With ddlEstado
                .DataSource = oESTADO_BL.Listar(oESTADO_BE)
                .DataTextField = "DESCRIPCION"
                .DataValueField = "ID"
            End With
            ddlEstado.DataBind()
            ddlEstado.Items.Insert(0, New ListItem("(Ninguno)", "0"))
            If (hfSEstado IsNot Nothing) Then
                ddlEstado.SelectedValue = hfSEstado.Value
            End If

        End If
    End Sub

    Protected Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargaGrilla()
    End Sub


    Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        MostrarPopup("agregarOperador")
        txtEstacionAdd.Focus()
    End Sub


    Protected Sub btnAgregarCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregarCancelar.Click
        Try
            CerrarPopup("agregarOperador")
        Catch ex As Exception
            lblMensajeError.Text = ex.Message
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
        Dim oSCUESTACION_BL As New SCUESTACION_BL
        Dim oSCUESTACION_BE As New SCUESTACION_BE
        Try
            If (txtEstacionAdd.Text = String.Empty Or txtEstacionAdd.Text = "Estación") Then
                Exit Sub
            End If

            oSCUESTACION_BE.PropESTCNUMIP = txtEstacionAdd.Text.ToUpper
            oSCUESTACION_BE.PropESTCDESCRI = txtDescripcionAdd.Text.ToUpper
            oSCUESTACION_BE.PropESTCESTADO = ddlEstOperadorAdd.SelectedValue
            oSCUESTACION_BE.PropAUDUSUCREACION = CType(Session("Usuario"), String)
            oSCUESTACION_BE.PropAUDFECCREACION = Now.Date
            oSCUESTACION_BE.PropAUDPRGCREACION = CType(Session("proyecto"), String)
            oSCUESTACION_BE.PropAUDEQPCREACION = CType(Session("equipo"), String)

            oSCUESTACION_BL.Insertar(oSCUESTACION_BE)
            CargaGrilla()
            txtEstacionAdd.Text = "Estación"
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
        End Try

    End Sub

End Class
