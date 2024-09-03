Imports SISSADE.BE
Imports SISSADE.BL
Imports System.Data



Partial Class frmRegistraPaqueteRecurso
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
            tit.Text = "Registro de paquete de recursos"
            Session("activo") = "1"
            Dim sec As Int16 = 0
            Dim tur As Int16 = 0
            Dim cod As Integer = 0
            Dim sectores As String = ""
            If IsNumeric(Request.QueryString("sec")) Then
                sec = Int16.Parse(Request.QueryString("sec"))
            End If
            If IsNumeric(Request.QueryString("tur")) Then
                tur = Int16.Parse(Request.QueryString("tur"))
            End If
            If IsNumeric(Request.QueryString("cpq")) Then
                cod = Integer.Parse(Request.QueryString("cpq"))
            End If
            ViewState("intpaqcodigo") = cod
            ViewState("intturcodigo") = tur
            ViewState("intseccodigo") = sec
            ViewState("datpaqfecha") = Request.QueryString("fec")
            ViewState("paqnumero") = Request.QueryString("num")
            ViewState("sectores") = sectores
            lblFecha.Text = Request.QueryString("fec")
            lblTurno.Text = Request.QueryString("dtur")
            LblCodigoPaquete.Text = cod
            CargaCombo()
            CreaTablasTemporales()
            If cod > 0 Then
                CargaTablasTemporales()
                CargaDatosFormulario()
                ActualizaComboPersonal()
                ddlEstado.Enabled = True
                If Request.QueryString("acc") = "V" Then
                    ModoVer()
                End If
            Else
                ddlEstado.Enabled = False
            End If
        End If
    End Sub
    Private Sub CargaCombo()
        Dim oBE As CCOPAQUETE_BE = New CCOPAQUETE_BE
        Dim oBL As CCOPAQUETE_BL = New CCOPAQUETE_BL
        Dim ds As DataSet = New DataSet
        oBE.PropSECCODIGO = ViewState("intseccodigo")
        oBE.PropCUACODIGO = 0
        ds = oBL.ListaCombo(oBE)

        Dim dsSector As DataSet = New DataSet
        dsSector = oBL.ListarTurnoSector()


        ddlTipoPaquete.DataSource = CType(ds.Tables(0), DataTable)
        ddlTipoPaquete.DataTextField = "DESCRIPCION"
        ddlTipoPaquete.DataValueField = "CODIGO"
        ddlTipoPaquete.DataBind()

        ddlPuestoFijo.DataSource = ds.Tables(1)
        ddlPuestoFijo.DataTextField = "DESCRIPCION"
        ddlPuestoFijo.DataValueField = "CODIGO"
        ddlPuestoFijo.DataBind()
        ddlPuestoFijo.Items.Insert(0, "(Seleccione)")
        ddlPuestoFijo.Items(0).Value = 0

        ddlCuadrante.DataSource = ds.Tables(2)
        ddlCuadrante.DataTextField = "DESCRIPCION"
        ddlCuadrante.DataValueField = "CODIGO"
        ddlCuadrante.DataBind()
        ddlCuadrante.Items.Insert(0, "(Todos)")
        ddlCuadrante.Items(0).Value = 0

        ddlSector.DataSource = dsSector.Tables(1)
        ddlSector.DataTextField = "DESCRIPCION"
        ddlSector.DataValueField = "CODIGO"
        ddlSector.DataBind()
        ddlSector.Items.Insert(0, "(Seleccione)")
        ddlSector.Items(0).Value = 0
        ddlSector.SelectedValue = ViewState("intseccodigo")

        Dim removeListItemSector As ListItem = ddlSector.Items.FindByText("Sin Sector")
        ddlSector.Items.Remove(removeListItemSector)


        Dim oCCOTABLA_BE As CCOTABLA_BE = New CCOTABLA_BE
        Dim oCCOTABLA_BL As CCOTABLA_BL = New CCOTABLA_BL
        oCCOTABLA_BE.PropTTACODIGO = "ESTADOPAQUETE"
        ddlEstado.DataSource = oCCOTABLA_BL.Listar(oCCOTABLA_BE)
        ddlEstado.DataTextField = "DESCRIPCION"
        ddlEstado.DataValueField = "ID"
        ddlEstado.DataBind()
        ddlEstado.Items.Insert(0, "(Seleccione)")
        ddlEstado.Items(0).Value = 0
        ddlEstado.SelectedValue = 13

        Dim removeListItem As ListItem = ddlEstado.Items.FindByText("EN ATENCIÓN DE INCIDENCIA")
        ddlEstado.Items.Remove(removeListItem)

        'Dim oCCOPERSONAL_BE As CCOPERSONAL_BE = New CCOPERSONAL_BE
        'Dim oCCOPERSONAL_BL As CCOPERSONAL_BL = New CCOPERSONAL_BL

        'With oCCOPERSONAL_BE
        '    .PropPERCODIGO = 0
        '    .PropPERAPELLIDOPATERNO = ""
        '    .PropPERAPELLIDOMATERNO = ""
        '    .PropPERNOMBRE = ""
        '    .PropPERESTADO = 1
        '    .PropCRGCODIGO = 0
        '    .Propturcodigo = ViewState("intturcodigo")
        '    '.PropSECCODIGO = ViewState("intseccodigo")
        '    .PropPERCURSOS = SectoresSeleccionados()
        '    .PropPERFECESTADO = Date.Parse(ViewState("datpaqfecha"))
        'End With
        'Dim dt As DataTable = New DataTable
        'dt = oCCOPERSONAL_BL.RolListar(oCCOPERSONAL_BE)
        'ViewState("dtPersonal") = dt
        'ddlPersonal.DataSource = dt
        'ddlPersonal.DataTextField = "VCHCOMPLETO"
        'ddlPersonal.DataValueField = "INTPERCODIGO"
        'ddlPersonal.DataBind()
        'ddlPersonal.Items.Insert(0, "(Seleccione)")
        'ddlPersonal.Items(0).Value = 0
    End Sub
    Protected Sub btnCancelaPaquete_Click(sender As Object, e As System.EventArgs) Handles btnCancelaPaquete.Click, btnCancelaPaquete2.Click
        Response.Redirect("frmBuscaPaqueteRecurso.aspx")
    End Sub

    Protected Sub btnCargaPlantilla_Click(sender As Object, e As System.EventArgs) Handles btnCargaPlantilla.Click
        Try
            CargaPlantilla()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub
    Private Sub CargaPlantilla()
        Dim dt As DataTable = New DataTable
        Dim dtPlantilla As DataTable = New DataTable
        Dim oBE As CCOPAQUETE_BE = New CCOPAQUETE_BE
        Dim oBL As CCOPAQUETE_BL = New CCOPAQUETE_BL
        Try
            oBE.PropPAQCODIGO = ddlTipoPaquete.SelectedValue
            ViewState("tipopaquete") = ddlTipoPaquete.SelectedValue
            dt = oBL.ListarPlantilla(oBE)
            dtPlantilla.Columns.Add("SMLTRECODIGO", Type.GetType("System.Int16"))
            dtPlantilla.Columns.Add("VCHTREDESCRIPCION", Type.GetType("System.String"))
            dtPlantilla.Columns.Add("VCHRECCODIGOALTERNO", Type.GetType("System.String"))
            dtPlantilla.Columns.Add("VCHRECDESCRIPCION", Type.GetType("System.String"))
            dtPlantilla.Columns.Add("VCHTABDESCRIPCION", Type.GetType("System.String"))
            dtPlantilla.Columns.Add("INTRECCODIGO", Type.GetType("System.Int32"))
            Dim columna As DataColumnCollection = dtPlantilla.Columns
            Dim rowPlantilla As DataRow
            Dim i As Integer = 0
            For i = 0 To dt.Rows.Count - 1
                rowPlantilla = dtPlantilla.NewRow()
                rowPlantilla(columna(0)) = dt.Rows(i).Item("SMLTRECODIGO")
                rowPlantilla(columna(1)) = dt.Rows(i).Item("VCHTREDESCRIPCION")
                rowPlantilla(columna(2)) = ""
                rowPlantilla(columna(3)) = ""
                rowPlantilla(columna(4)) = ""
                dtPlantilla.Rows.Add(rowPlantilla)
            Next
            dtPlantilla.AcceptChanges()
            ViewState("dtPlantilla") = dtPlantilla
            gvRecursos.DataSource = dtPlantilla
            gvRecursos.DataBind()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub
    Protected Sub ddlTipoPaquete_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlTipoPaquete.SelectedIndexChanged
        CargaPlantilla()
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
    Protected Sub gvRecursos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvRecursos.SelectedIndexChanged
        If gvUbicacion.Rows.Count = 0 Then
            If ddlSector.SelectedValue = 0 Then
                Util.MSG_ALERTA("DEBE SELECCIONAR EL SECTOR", Me)
                Exit Sub
            End If
            ViewState("VCHSECODIGO") = ddlSector.SelectedValue.ToString
        Else
            ViewState("VCHSECODIGO") = SectoresSeleccionados()
        End If
        Dim dt As DataTable = CType(ViewState("dtPlantilla"), DataTable)
        ViewState("SMLTRECODIGO") = dt.Rows(gvRecursos.SelectedIndex).Item("SMLTRECODIGO")
        CargaGrillaRecursoBuscar()
        MostrarPopup("detalle")
    End Sub
    Private Function SectoresSeleccionados() As String
        Dim resultado As String = ""
        Dim dt As DataTable = CType(ViewState("dtubicacion"), DataTable)
        Dim i As Integer
        For i = 0 To dt.Rows.Count - 1
            resultado = resultado & dt.Rows(i).Item("SMLSECCODIGO")
            If i <> dt.Rows.Count - 1 Then
                resultado = resultado & ","
            End If
        Next
        Return resultado
    End Function
    Protected Sub gvRecursosBurca_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvRecursosBurca.SelectedIndexChanged
        Try
            ActualizaPlantilla()
            CerrarPopup("detalle")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub
    Private Sub ActualizaPlantilla()
        Try
            Dim dt As DataTable = CType(ViewState("gvRecursosBurca"), DataTable)
            Dim cod As Integer = dt.Rows(gvRecursosBurca.SelectedIndex).Item("INTRECCODIGO")
            Dim codalt As String = dt.Rows(gvRecursosBurca.SelectedIndex).Item("VCHRECCODIGOALTERNO")
            Dim des As String = dt.Rows(gvRecursosBurca.SelectedIndex).Item("VCHRECDESCRIPCION")
            Dim est As String = dt.Rows(gvRecursosBurca.SelectedIndex).Item("VCHTABDESCRIPCION")
            Dim dtpl_ant As DataTable = CType(ViewState("dtPlantilla"), DataTable)
            Dim dtPlantilla As DataTable = New DataTable
            dtPlantilla.Columns.Add("SMLTRECODIGO", Type.GetType("System.Int16"))
            dtPlantilla.Columns.Add("VCHTREDESCRIPCION", Type.GetType("System.String"))
            dtPlantilla.Columns.Add("VCHRECCODIGOALTERNO", Type.GetType("System.String"))
            dtPlantilla.Columns.Add("VCHRECDESCRIPCION", Type.GetType("System.String"))
            dtPlantilla.Columns.Add("VCHTABDESCRIPCION", Type.GetType("System.String"))
            dtPlantilla.Columns.Add("INTRECCODIGO", Type.GetType("System.Int32"))
            Dim columna As DataColumnCollection = dtPlantilla.Columns
            Dim rowPlantilla As DataRow
            Dim i As Integer = 0
            For i = 0 To dtpl_ant.Rows.Count - 1
                rowPlantilla = dtPlantilla.NewRow()
                rowPlantilla(columna(0)) = dtpl_ant.Rows(i).Item("SMLTRECODIGO")
                rowPlantilla(columna(1)) = dtpl_ant.Rows(i).Item("VCHTREDESCRIPCION")
                If dtpl_ant.Rows(i).Item("SMLTRECODIGO") = ViewState("SMLTRECODIGO") Then
                    rowPlantilla(columna(2)) = codalt
                    rowPlantilla(columna(3)) = des
                    rowPlantilla(columna(4)) = est
                    rowPlantilla(columna(5)) = cod
                Else
                    rowPlantilla(columna(2)) = dtpl_ant.Rows(i).Item("VCHRECCODIGOALTERNO")
                    rowPlantilla(columna(3)) = dtpl_ant.Rows(i).Item("VCHRECDESCRIPCION")
                    rowPlantilla(columna(4)) = dtpl_ant.Rows(i).Item("VCHTABDESCRIPCION")
                    rowPlantilla(columna(5)) = dtpl_ant.Rows(i).Item("INTRECCODIGO")
                End If
                dtPlantilla.Rows.Add(rowPlantilla)
            Next
            dtPlantilla.AcceptChanges()
            ViewState("dtPlantilla") = dtPlantilla
            gvRecursos.DataSource = dtPlantilla
            gvRecursos.DataBind()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub
    Protected Sub btnRecursoBuscar_Click(sender As Object, e As System.EventArgs) Handles btnRecursoBuscar.Click
        CargaGrillaRecursoBuscar()
    End Sub
    Private Sub CargaGrillaRecursoBuscar()
        Try
            Dim oBE As CCORECURSO_BE = New CCORECURSO_BE
            Dim oBL As CCORECURSO_BL = New CCORECURSO_BL
            With oBE
                .PropRECCODIGO = 0
                .PropRECDESCRIPCION = txtDesRecBusca.Text.ToUpper
                .PropRECMODELO = ViewState("VCHSECODIGO")
                .PropTRECODIGO = ViewState("SMLTRECODIGO")
                .PropRECCODIGOALTERNO = txtCodigoRecBusca.Text
            End With
            Dim dt As DataTable = New DataTable
            Dim fecha As Date = Date.Parse(ViewState("datpaqfecha"))
            dt = oBL.Listar(oBE, fecha)
            ViewState("gvRecursosBurca") = dt
            gvRecursosBurca.DataSource = dt
            gvRecursosBurca.DataBind()
            MostrarPopup("detalle")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub btnAgregaPersona_Click(sender As Object, e As System.EventArgs) Handles btnAgregaPersona.Click
        Try
            Dim oBE As CCOPERSONAL_BE = New CCOPERSONAL_BE
            Dim oBL As CCOPERSONAL_BL = New CCOPERSONAL_BL

            Dim dt As DataTable = New DataTable
            With oBE
                .PropPERCODIGO = ddlPersonal.SelectedValue
                .PropPERAPELLIDOPATERNO = ""
                .PropPERAPELLIDOMATERNO = ""
                .PropPERNOMBRE = ""
                .PropPERESTADO = 1
                .PropCRGCODIGO = 0
                .Propturcodigo = ViewState("intturcodigo")
                .PropSECCODIGO = ViewState("intseccodigo")
            End With
            dt = oBL.Listar(oBE)
            Dim dttmpPersonal As DataTable = CType(ViewState("dttmpPersonal"), DataTable)
            Dim columna As DataColumnCollection = dttmpPersonal.Columns
            Dim rowPlantilla As DataRow
            rowPlantilla = dttmpPersonal.NewRow()
            rowPlantilla(columna(0)) = dt.Rows(0).Item("INTPERCODIGO")
            rowPlantilla(columna(1)) = dt.Rows(0).Item("VCHCOMPLETO")
            rowPlantilla(columna(2)) = dt.Rows(0).Item("VCHCRGDESCRIPCION")
            rowPlantilla(columna(3)) = dt.Rows(0).Item("VCHPERESTADODES")
            dttmpPersonal.Rows.Add(rowPlantilla)

            dttmpPersonal.AcceptChanges()
            ViewState("dttmpPersonal") = dttmpPersonal
            gvPersona.DataSource = dttmpPersonal
            gvPersona.DataBind()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Private Sub Eliminar()
        Try
            If gvPersona.SelectedIndex = -1 Then
                Util.MSG_ALERTA("Seleccione la persona que desea eliminar", Me)
                Exit Sub
            End If

            Dim dt As DataTable = CType(ViewState("dttmpPersonal"), DataTable)
            If dt.Rows(gvPersona.SelectedIndex).Item("INTPERCODIGO") = ViewState("INTPERCODIGO") Then
                dt.Rows(gvPersona.SelectedIndex).Delete()
                dt.AcceptChanges()
            End If
            ViewState("dttmpPersonal") = dt
            gvPersona.DataSource = dt
            gvPersona.DataBind()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub
    Protected Sub gvPersona_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPersona.SelectedIndexChanged
        Dim dt As DataTable = CType(ViewState("dttmpPersonal"), DataTable)
        ViewState("INTPERCODIGO") = dt.Rows(gvPersona.SelectedIndex).Item("INTPERCODIGO")
        Eliminar()
    End Sub

    Protected Sub btnGrabaPaquete_Click(sender As Object, e As System.EventArgs) Handles btnGrabaPaquete.Click, btnGrabaPaquete2.Click
        Dim oCCOPAQUETE_BE As CCOPAQUETE_BE = New CCOPAQUETE_BE
        Dim oCCOPAQUETE_BL As CCOPAQUETE_BL = New CCOPAQUETE_BL
        Dim dt As DataTable = CType(ViewState("dttmpPersonal"), DataTable)
        If gvUbicacion.Rows.Count = 0 Then
            Util.MSG_ALERTA("DEBE INGRESAR AL MENOS UNA UBICACION", Me)
            Exit Sub
        End If
        If AsignaRecurso() > 0 Then
            Util.MSG_ALERTA("ES NECESARIO ASIGNAR EL RECURSO DEL PAQUETE", Me)
            Exit Sub
        End If
        If dt.Rows.Count = 0 Then
            Util.MSG_ALERTA("DEBE SELECCIONAR EL PERSONAL", Me)
            Exit Sub
        End If
        If validaResponsable() > 1 Then
            Util.MSG_ALERTA("SOLO DEBE SELECCIONAR SOLO UN RESPONSABLE", Me)
            Exit Sub
        End If
        Dim codresponsable As Integer = PersonaResponsable()
        If codresponsable = 0 Then
            Util.MSG_ALERTA("DEBE SELECCIONAR UN RESPONSABLE", Me)
            Exit Sub
        End If
        If (ddlSector.SelectedValue = 0 And chkConUbicacion.Checked = False) Then
            Util.MSG_ALERTA("DEBE SELECCIONAR UN SECTOR", Me)
            Exit Sub
        End If
        If (ddlEstado.SelectedValue = 0) Then
            Util.MSG_ALERTA("DEBE SELECCIONAR EL ESTADO DEL PAQUETE", Me)
            Exit Sub
        End If
        Try
            With oCCOPAQUETE_BE
                .PropPAQCODIGO = ViewState("intpaqcodigo")
                .PropPAQNUMERO = ViewState("paqnumero")
                .PropPAQESTADO = ddlEstado.SelectedValue
                .PropTURCODIGO = ViewState("intturcodigo")
                .PropPAQCOMENTARIO = txtComentario.Text.ToUpper
                .PropPAQFECHA = Date.Parse(ViewState("datpaqfecha"))
                .PropPERCODIGO = codresponsable
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

                If chkAlertarAbandono.Checked Then
                    .PropPAQAVISARABANDONO = 1
                Else
                    .PropPAQAVISARABANDONO = 0
                End If
                .PropTPQCODIGO = Int16.Parse(ViewState("tipopaquete"))
                If chkConUbicacion.Checked Then
                    .PropPAQCONUBICACION = 1
                Else
                    .PropPAQCONUBICACION = 0
                End If
            End With
            Dim intpaqcodigo As Integer = 0
            If ViewState("intpaqcodigo") = 0 Then
                intpaqcodigo = oCCOPAQUETE_BL.Insertar(oCCOPAQUETE_BE)
            Else
                oCCOPAQUETE_BL.Eliminar(oCCOPAQUETE_BE)
                oCCOPAQUETE_BL.Actualizar(oCCOPAQUETE_BE)
                intpaqcodigo = ViewState("intpaqcodigo")
            End If

            '-------------------------------------------------------------------------'

            Dim oCCOPAQUETERECURSO_BE As CCOPAQUETERECURSO_BE = New CCOPAQUETERECURSO_BE
            Dim oCCOPAQUETERECURSO_BL As CCOPAQUETERECURSO_BL = New CCOPAQUETERECURSO_BL

            Dim dtRecurso As DataTable = CType(ViewState("dtPlantilla"), DataTable)
            Dim i As Integer = 0
            For i = 0 To dtRecurso.Rows.Count - 1
                With oCCOPAQUETERECURSO_BE
                    .PropPAQCODIGO = intpaqcodigo
                    .PropPQRCODIGO = 0
                    .PropRECCODIGO = dtRecurso.Rows(i).Item("INTRECCODIGO")
                End With
                oCCOPAQUETERECURSO_BL.Insertar(oCCOPAQUETERECURSO_BE)
            Next

            '-------------------------------------------------------------------------'

            Dim oCCOPAQUETEPERSONAL_BE As CCOPAQUETEPERSONAL_BE = New CCOPAQUETEPERSONAL_BE
            Dim oCCOPAQUETEPERSONAL_BL As CCOPAQUETEPERSONAL_BL = New CCOPAQUETEPERSONAL_BL
            Dim chk As CheckBox
            Dim p As Integer = 0
            For p = 0 To gvPersona.Rows.Count - 1
                With oCCOPAQUETEPERSONAL_BE
                    .PropPQPCODIGO = 0
                    .PropPAQCODIGO = intpaqcodigo
                    .PropPERCODIGO = Integer.Parse(gvPersona.Rows(p).Cells(1).Text)
                    chk = CType(gvPersona.Rows(p).FindControl("chkResponsable"), CheckBox)
                    If chk.Checked Then
                        .PropPQPRESPONSABLE = 1
                    Else
                        .PropPQPRESPONSABLE = 0
                    End If

                End With
                oCCOPAQUETEPERSONAL_BL.Insertar(oCCOPAQUETEPERSONAL_BE)
            Next

            '-------------------------------------------------------------------------'
            Dim oCCOPAQUETECUADRANTE_BE As CCOPAQUETECUADRANTE_BE = New CCOPAQUETECUADRANTE_BE
            Dim oCCOPAQUETECUADRANTE_BL As CCOPAQUETECUADRANTE_BL = New CCOPAQUETECUADRANTE_BL

            Dim dtUbicacion As DataTable = CType(ViewState("dtubicacion"), DataTable)
            Dim outil As Util = New Util

            Dim u As Integer = 0
            For u = 0 To dtUbicacion.Rows.Count - 1
                With oCCOPAQUETECUADRANTE_BE
                    .PropPAQCODIGO = intpaqcodigo
                    If dtUbicacion.Rows.Count = 0 Then
                        .PropSECCODIGO = ddlSector.SelectedValue
                    Else
                        .PropSECCODIGO = Int16.Parse(dtUbicacion.Rows(u).Item("SMLSECCODIGO"))
                        If outil.nNulo(dtUbicacion.Rows(u).Item("SMLCUACODIGO")) > 0 Then
                            .PropCUACODIGO = Int16.Parse(dtUbicacion.Rows(u).Item("SMLCUACODIGO"))
                        End If
                        If outil.nNulo(dtUbicacion.Rows(u).Item("SMLPFICODIGO")) > 0 Then
                            .PropPFICODIGO = Int16.Parse(dtUbicacion.Rows(u).Item("SMLPFICODIGO"))
                        End If
                    End If
                End With
                oCCOPAQUETECUADRANTE_BL.Insertar(oCCOPAQUETECUADRANTE_BE)
            Next


            lblMensajeSistema.Text = "La operación fue realizada satisfactoriamente"
            MostrarPopup("mensaje")
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub

    Protected Sub chkResponsable_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If validaResponsable() > 1 Then
            Util.MSG_ALERTA("SOLO DEBE SELECCIONAR UN RESPONSABLE", Me)
        End If
    End Sub
    Private Function validaResponsable() As Integer
        Dim cont As Integer = 0
        For i As Integer = 0 To gvPersona.Rows.Count - 1
            If CType(gvPersona.Rows(i).FindControl("chkResponsable"), CheckBox).Checked Then
                cont = cont + 1
            End If
        Next
        Return cont
    End Function
    Private Function AsignaRecurso() As Integer
        Dim cont As Integer = 0
        For i As Integer = 0 To gvRecursos.Rows.Count - 1
            If (gvRecursos.Rows(i).Cells(3).Text.Length = 0 Or gvRecursos.Rows(i).Cells(4).Text.Length = 0) Then
                cont = cont + 1
            End If
        Next
        Return cont
    End Function

    Private Function PersonaResponsable() As Integer
        Dim cod As Integer = 0
        For i As Integer = 0 To gvPersona.Rows.Count - 1
            If CType(gvPersona.Rows(i).FindControl("chkResponsable"), CheckBox).Checked Then
                cod = Integer.Parse(gvPersona.Rows(i).Cells(1).Text)
            End If
        Next
        Return cod
    End Function

    Protected Sub chkConUbicacion_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkConUbicacion.CheckedChanged
        gvUbicacion.DataBind()
        Dim dt As DataTable = CType(ViewState("dtubicacion"), DataTable)
        dt.Clear()
        ViewState("dtubicacion") = dt
        chkAlertarAbandono.Checked = False
        ddlPuestoFijo.SelectedValue = 0
        ddlCuadrante.SelectedValue = 0
        If chkConUbicacion.Checked = False Then ddlSector.SelectedValue = 10
        pnlPuestoFijo.Visible = chkConUbicacion.Checked
    End Sub

    Protected Sub btnAgregaUbicacion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregaUbicacion.Click
        If ddlSector.SelectedValue = 0 Then
            Util.MSG_ALERTA("ES NECESARIO SELECCIONAR EL SECTOR", Me)
            Exit Sub
        End If
        If Not UbicacionYaIngresada(ddlPuestoFijo.SelectedItem.Text, ddlCuadrante.SelectedItem.Text, ddlSector.SelectedItem.Text) Then
            CargaPlantillaUbicacion()
            CargaPlantilla()
            ActualizaComboPersonal()
        Else
            Util.MSG_ALERTA("YA EXISTE LA UBICACION INGRESADA O EXISTE UN NIVEL SUPERIOR QUE INCLUYE LA UBICACION", Me)
        End If
    End Sub
    Private Sub ActualizaComboPersonal()
        Try

            Dim oCCOPERSONAL_BE As CCOPERSONAL_BE = New CCOPERSONAL_BE
            Dim oCCOPERSONAL_BL As CCOPERSONAL_BL = New CCOPERSONAL_BL

            With oCCOPERSONAL_BE
                .PropPERCODIGO = 0
                .PropPERAPELLIDOPATERNO = ""
                .PropPERAPELLIDOMATERNO = ""
                .PropPERNOMBRE = ""
                .PropPERESTADO = 1
                .PropCRGCODIGO = 0
                .Propturcodigo = ViewState("intturcodigo")
                '.PropSECCODIGO = ViewState("intseccodigo")
                .PropPERCURSOS = SectoresSeleccionados()
                .PropPERFECESTADO = Date.Parse(ViewState("datpaqfecha"))
            End With
            Dim dt As DataTable = New DataTable
            dt = oCCOPERSONAL_BL.RolListar(oCCOPERSONAL_BE)
            ViewState("dtPersonal") = dt
            ddlPersonal.DataSource = dt
            ddlPersonal.DataTextField = "VCHCOMPLETO"
            ddlPersonal.DataValueField = "INTPERCODIGO"
            ddlPersonal.DataBind()
            ddlPersonal.Items.Insert(0, "(Seleccione)")
            ddlPersonal.Items(0).Value = 0

        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub
    Private Sub CargaPlantillaUbicacion()
        Try

            Dim dt As DataTable = CType(ViewState("dtubicacion"), DataTable)
            Dim columna As DataColumnCollection = dt.Columns
            Dim rowPlantilla As DataRow
            rowPlantilla = dt.NewRow()
            rowPlantilla(columna(0)) = ddlSector.SelectedValue
            rowPlantilla(columna(1)) = ddlCuadrante.SelectedValue
            rowPlantilla(columna(2)) = ddlPuestoFijo.SelectedValue
            rowPlantilla(columna(3)) = ddlSector.SelectedItem.Text
            rowPlantilla(columna(4)) = ddlCuadrante.SelectedItem.Text
            rowPlantilla(columna(5)) = ddlPuestoFijo.SelectedItem.Text
            dt.Rows.Add(rowPlantilla)
            dt.AcceptChanges()
            ViewState("dtubicacion") = dt
            gvUbicacion.DataSource = dt
            gvUbicacion.DataBind()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub ddlSector_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSector.SelectedIndexChanged
        Try
            Dim oBE As CCOPAQUETE_BE = New CCOPAQUETE_BE
            Dim oBL As CCOPAQUETE_BL = New CCOPAQUETE_BL
            Dim ds As DataSet = New DataSet
            oBE.PropSECCODIGO = ddlSector.SelectedValue
            oBE.PropCUACODIGO = 0
            ds = oBL.ListaCombo(oBE)
            ddlPuestoFijo.DataSource = ds.Tables(1)
            ddlPuestoFijo.DataTextField = "DESCRIPCION"
            ddlPuestoFijo.DataValueField = "CODIGO"
            ddlPuestoFijo.DataBind()
            ddlPuestoFijo.Items.Insert(0, "(Ninguno)")
            ddlPuestoFijo.Items(0).Value = 0
            ViewState("ddlPuestoFijo") = ds.Tables(1)

            ddlCuadrante.DataSource = ds.Tables(2)
            ddlCuadrante.DataTextField = "DESCRIPCION"
            ddlCuadrante.DataValueField = "CODIGO"
            ddlCuadrante.DataBind()
            ddlCuadrante.Items.Insert(0, "(Todos)")
            ddlCuadrante.Items(0).Value = 0
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub

    Protected Sub ddlCuadrante_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCuadrante.SelectedIndexChanged
        Try
            Dim oBE As CCOPAQUETE_BE = New CCOPAQUETE_BE
            Dim oBL As CCOPAQUETE_BL = New CCOPAQUETE_BL
            Dim ds As DataSet = New DataSet
            oBE.PropSECCODIGO = ddlSector.SelectedValue
            oBE.PropCUACODIGO = ddlCuadrante.SelectedValue
            ds = oBL.ListaCombo(oBE)
            ddlPuestoFijo.DataSource = ds.Tables(1)
            ddlPuestoFijo.DataTextField = "DESCRIPCION"
            ddlPuestoFijo.DataValueField = "CODIGO"
            ddlPuestoFijo.DataBind()
            ddlPuestoFijo.Items.Insert(0, "(Ninguno)")
            ddlPuestoFijo.Items(0).Value = 0
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try
    End Sub
    Private Sub CreaTablasTemporales()
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("SMLSECCODIGO", Type.GetType("System.Int16"))
        dt.Columns.Add("SMLCUACODIGO", Type.GetType("System.Int16"))
        dt.Columns.Add("SMLPFICODIGO", Type.GetType("System.Int16"))
        dt.Columns.Add("VCHSECDESCRIPCION", Type.GetType("System.String"))
        dt.Columns.Add("VCHCUACODIGOALTERNO", Type.GetType("System.String"))
        dt.Columns.Add("VCHPFIUBICACION", Type.GetType("System.String"))
        dt.AcceptChanges()
        ViewState("dtubicacion") = dt

        Dim dttmpPersonal As DataTable = New DataTable
        dttmpPersonal.Columns.Add("INTPERCODIGO", Type.GetType("System.Int32"))
        dttmpPersonal.Columns.Add("VCHCOMPLETO", Type.GetType("System.String"))
        dttmpPersonal.Columns.Add("VCHCRGDESCRIPCION", Type.GetType("System.String"))
        dttmpPersonal.Columns.Add("VCHPERESTADODES", Type.GetType("System.String"))
        dttmpPersonal.AcceptChanges()
        ViewState("dttmpPersonal") = dttmpPersonal
    End Sub
    Private Sub EliminarUbicacion()
        Try
            If gvUbicacion.SelectedIndex = -1 Then
                Util.MSG_ALERTA("Seleccione la ubicación que desea eliminar", Me)
                Exit Sub
            End If

            Dim dt As DataTable = CType(ViewState("dtubicacion"), DataTable)
            Dim oUtil As Util = New Util
            If oUtil.nNulo(dt.Rows(gvUbicacion.SelectedIndex).Item("SMLSECCODIGO")) = ViewState("SMLSECCODIGO") AndAlso
                  oUtil.nNulo(dt.Rows(gvUbicacion.SelectedIndex).Item("SMLCUACODIGO")) = ViewState("SMLCUACODIGO") AndAlso
                  oUtil.nNulo(dt.Rows(gvUbicacion.SelectedIndex).Item("SMLPFICODIGO")) = ViewState("SMLPFICODIGO") Then
                dt.Rows(gvUbicacion.SelectedIndex).Delete()
                dt.AcceptChanges()
            End If
            ViewState("dtubicacion") = dt
            gvUbicacion.DataSource = dt
            gvUbicacion.DataBind()
            ActualizaComboPersonal()
        Catch ex As Exception
            lblMensaje.Text = ex.Message
            Bitacora.Escribir(ex.Message, LogMsg.ERROR)
        End Try

    End Sub

    Protected Sub gvUbicacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvUbicacion.SelectedIndexChanged
        Dim dt As DataTable = CType(ViewState("dtubicacion"), DataTable)
        Dim oUtil As Util = New Util

        ViewState("SMLSECCODIGO") = oUtil.nNulo(dt.Rows(gvUbicacion.SelectedIndex).Item("SMLSECCODIGO"))
        ViewState("SMLCUACODIGO") = oUtil.nNulo(dt.Rows(gvUbicacion.SelectedIndex).Item("SMLCUACODIGO"))
        ViewState("SMLPFICODIGO") = oUtil.nNulo(dt.Rows(gvUbicacion.SelectedIndex).Item("SMLPFICODIGO"))
        EliminarUbicacion()
        EliminaRecursos()
    End Sub
    Private Sub EliminaRecursos()
        btnCargaPlantilla_Click(Nothing, Nothing)
    End Sub

    Protected Sub btnRedirecciona_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRedirecciona.Click
        Response.Redirect("frmBuscaPaqueteRecurso.aspx")
    End Sub
    Private Sub CargaTablasTemporales()

        Dim dtubicacion As DataTable = CType(ViewState("dtubicacion"), DataTable)
        Dim dttmpPersonal As DataTable = CType(ViewState("dttmpPersonal"), DataTable)
        Dim dtPlantilla As DataTable = CType(ViewState("dtPlantilla"), DataTable)
        Dim oBE As CCOPAQUETE_BE = New CCOPAQUETE_BE
        Dim oBL As CCOPAQUETE_BL = New CCOPAQUETE_BL
        Dim ds As DataSet = New DataSet
        oBE.PropPAQCODIGO = ViewState("intpaqcodigo")
        ds = oBL.ListaTablaTemporal(oBE)
        ViewState("dtubicacion") = ds.Tables(0)
        ViewState("dttmpPersonal") = ds.Tables(1)
        ViewState("dtPlantilla") = ds.Tables(2)
        gvUbicacion.DataSource = ds.Tables(0)
        gvUbicacion.DataBind()
        gvPersona.DataSource = ds.Tables(1)
        gvPersona.DataBind()
        gvRecursos.DataSource = ds.Tables(2)
        gvRecursos.DataBind()
    End Sub
    Private Sub CargaDatosFormulario()
        Dim oBE As CCOPAQUETE_BE = New CCOPAQUETE_BE
        Dim oBL As CCOPAQUETE_BL = New CCOPAQUETE_BL
        oBE.PropPAQCODIGO = ViewState("intpaqcodigo")
        oBE = oBL.ListarKey(oBE)
        If oBE.PropPAQCONUBICACION = 1 Then
            chkConUbicacion.Checked = True
        End If
        If oBE.PropPAQAVISARABANDONO = 1 Then
            chkAlertarAbandono.Checked = 1
        End If
        txtComentario.Text = oBE.PropPAQCOMENTARIO
        ddlEstado.SelectedValue = oBE.PropPAQESTADO

        Dim cod As Integer = 0
        For Each row As GridViewRow In gvPersona.Rows
            cod = Integer.Parse(gvPersona.Rows(row.RowIndex).Cells(1).Text)
            If cod = oBE.PropPERCODIGO Then
                Dim cb As CheckBox = row.FindControl("chkResponsable")
                cb.Checked = True
            End If
        Next
        ViewState("tipopaquete") = oBE.PropTPQCODIGO
    End Sub
    Private Function UbicacionYaIngresada(ByVal pf As String, ByVal cua As String, ByVal sec As String) As Boolean
        Dim existe As Boolean = False

        ' verificamos si existe todo el sector
        For i As Integer = 0 To gvUbicacion.Rows.Count - 1
            If gvUbicacion.Rows(i).Cells(2).Text = sec And gvUbicacion.Rows(i).Cells(3).Text = "(Todos)" And gvUbicacion.Rows(i).Cells(4).Text = "(Ninguno)" Then
                existe = True
            End If
        Next
        If existe = False Then
            If cua = "(Todos)" Then
                For i As Integer = 0 To gvUbicacion.Rows.Count - 1
                    If gvUbicacion.Rows(i).Cells(2).Text = sec And gvUbicacion.Rows(i).Cells(3).Text.Length > 0 Then
                        existe = True
                    End If
                Next
            End If
        End If
        If existe = False Then
            ' verificamos mismo sector con todos los cuadrantes
            For i As Integer = 0 To gvUbicacion.Rows.Count - 1
                If gvUbicacion.Rows(i).Cells(2).Text = sec And gvUbicacion.Rows(i).Cells(3).Text = "(Todos)" Then
                    existe = True
                End If
            Next
        End If
        If existe = False Then
            For i As Integer = 0 To gvUbicacion.Rows.Count - 1
                If gvUbicacion.Rows(i).Cells(2).Text = sec And gvUbicacion.Rows(i).Cells(3).Text = cua And gvUbicacion.Rows(i).Cells(4).Text = pf Then
                    existe = True
                End If
            Next
        End If

        Return existe
    End Function
    Private Sub ModoVer()
        btnAgregaPersona.Visible = False
        btnAgregaUbicacion.Visible = False
        btnCargaPlantilla.Visible = False
        btnGrabaPaquete.Visible = False
        btnGrabaPaquete2.Visible = False
        gvPersona.Enabled = False
        gvRecursos.Enabled = False
        gvUbicacion.Enabled = False
        chkAlertarAbandono.Enabled = False
        chkConUbicacion.Enabled = False
        gvUbicacion.Columns(0).Visible = False
        gvRecursos.Columns(2).Visible = False
        gvPersona.Columns(0).Visible = False
        txtComentario.Enabled = False
        ddlEstado.Enabled = False
    End Sub

    Protected Sub ddlPuestoFijo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlPuestoFijo.SelectedIndexChanged
        Dim dt As DataTable = CType(ViewState("ddlPuestoFijo"), DataTable)
        Dim filtro As String = "CODIGO=" & ddlPuestoFijo.SelectedValue.ToString
        Dim reg() As DataRow = dt.Select(filtro)
        Dim oUtil As Util = New Util
        Dim cua As Int16 = oUtil.nNulo(reg(0)(2))
        ddlCuadrante.SelectedValue = cua
    End Sub
End Class
