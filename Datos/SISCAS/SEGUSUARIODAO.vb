
Imports IBM.Data.DB2
Imports System.Data.Common
Imports Framework.Util
Imports System.Data
Imports Recurso.Encriptador
Imports Framework.Entidades
Imports Datos.SISCAS
Imports Entidades.SISCAS
'Imports Entidades.
Namespace SISCAS
    <Serializable()> _
    Partial Public Class SEGUSUARIODAO
        Inherits SISCASDAOBase(Of SEGUSUARIOEntidad)
        Sub New()
            MyBase.New("SISCAS", "SISCAS", "SEGUSUARIO")
        End Sub

        Public Function CambiarPassword(ByVal codigousuario As Integer, ByVal PassNuevo As String, ByRef msg As String) As Boolean
            Dim exito As Boolean = False
            Try
                Dim encpassanterior As String = ""
                encpassanterior = SecurityEncryptor.Encriptar(PassNuevo, "")
                If (encpassanterior = "") Then
                    exito = False
                Else

                    Dim dbc As DbCommand = Me.CrearComando("SISCAS_CAMBIARPASSWORD", codigousuario, encpassanterior)

                    Dim tran As DB2Transaction = Me.IniciarTransaccion()
                    Try
                        Me.Ejecutar(dbc, tran)
                        tran.Commit()
                        exito = True
                    Catch ex As Exception
                        msg = ex.Message.ToString().Trim()
                        exito = False
                    End Try
                    Me.cerrarConexion()
                End If
            Catch ex As Exception
                msg = ex.Message.ToString().Trim()
            End Try

            Return exito
        End Function
        '
        Public Function CambiarPasswordxUsuario(ByVal codigoUsuario As String, ByVal PassNuevo As String, ByRef msg As String, ByRef opcion As Integer) As Boolean
            Dim exito As Boolean = False
            Try
                Dim encpassanterior As String = ""

                encpassanterior = SecurityEncryptor.Encriptar(PassNuevo, "")
                If (encpassanterior = "") Then
                    exito = False : opcion = -1
                Else
                    Dim p As New DB2Parameter("P_OPCION", DB2Type.Integer)
                    p.Direction = ParameterDirection.Output
                    Dim dbc As DbCommand = Me.CrearComando("SISCAS_CAMBIARPASSWORDXUSUARIO", codigoUsuario, encpassanterior)
                    dbc.Parameters.Add(p)
                    Dim tran As DB2Transaction = Me.IniciarTransaccion()
                    Try
                        Me.Ejecutar(dbc, tran)
                        tran.Commit()
                        exito = True
                        opcion = IIf((p.Value Is Nothing OrElse p.Value Is DBNull.Value), 0, CType(p.Value.ToString().Trim(), Integer))
                    Catch ex As Exception
                        msg = ex.Message.ToString().Trim()
                        exito = False
                    End Try
                    Me.cerrarConexion()
                End If
            Catch ex As Exception
                msg = ex.Message.ToString().Trim()
            End Try
            Return exito
        End Function

        Public Function VerificarUsuario(ByVal nombreDeUsuario As String, ByRef intusuidentificador As Integer, ByRef usupass As String) As Boolean

            Dim exito As Boolean = False
            Dim dbc As DbCommand = Me.CrearComando("SISCAS_VERIFICARUSUARIO", nombreDeUsuario)
            Dim db1 As New DB2Parameter("P_INTUSUIDENTIFICADOR", DB2Type.Integer)
            db1.Direction = ParameterDirection.Output
            Dim db2 As New DB2Parameter("P_VCHUSUPASSWORD", DB2Type.VarChar, 64)
            db2.Direction = ParameterDirection.Output
            dbc.Parameters.Add(db1)
            dbc.Parameters.Add(db2)
            Try
                Me.Ejecutar(dbc)
                ' Me.EjecutarDataTable(dbc)
                intusuidentificador = CType(db1.Value.ToString().Trim(), Integer)
                usupass = db2.Value.ToString().Trim()
                exito = True
            Catch ex As Exception
                Dim msg As String = ex.Message.ToString().Trim()
            End Try
            Me.cerrarConexion()
            Return exito
        End Function

        Public Function LogeoUsuario(ByVal siscodigo As Integer, ByVal nombreDeUsuario As String, ByVal clave As String, ByRef objUsu As SEGUSUARIOEntidad, ByRef msg As String) As Boolean

            Dim dt As New DataTable
            Dim exito As Boolean = False
            Dim P_INTSISCODIGO As Integer = siscodigo
            Dim dbc As DbCommand = Me.CrearComando("SISCAS_SEGUSUARIO_LOGEOUSUARIOGNRL", P_INTSISCODIGO, nombreDeUsuario)
            Dim p1 As New DB2Parameter("P_INTUSUIDENTIFICADOR", DB2Type.Integer)
            p1.Direction = ParameterDirection.Output
            Dim p2 As New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
            p2.Direction = ParameterDirection.Output
            Dim p3 As New DB2Parameter("P_VCHPERDESCRIPCION", DB2Type.VarChar, 50)
            p3.Direction = ParameterDirection.Output
            Dim p6 As New DB2Parameter("P_VCHUSUPASSWORD", DB2Type.VarChar, 64)
            p6.Direction = ParameterDirection.Output
            Dim p7 As New DB2Parameter("P_VCHNOMBUSU", DB2Type.VarChar, 150)
            p7.Direction = ParameterDirection.Output
            dbc.Parameters.Add(p1)
            dbc.Parameters.Add(p2)
            dbc.Parameters.Add(p3)
            dbc.Parameters.Add(p6)
            dbc.Parameters.Add(p7)
            Try
                dt = Me.EjecutarDataTable(dbc)
            Catch ex As Exception
                dt = New DataTable()
                msg = ex.Message.ToString().Trim()
                Dim msg1 As String = msg
                msg += "<br>"
                msg += "Se ha producido un error en el sistema. Inténtelo de nuevo"
                If CType(p2.Value.ToString().Trim(), Integer) = "0" Then
                End If
                exito = False
            End Try
            Me.cerrarConexion()

            If p1.Value = 0 Then
                msg = "Usuario No Existente."
                Return False
            End If

            If p1.Value IsNot Nothing AndAlso Not (p1.Value Is DBNull.Value) Then
                Dim pidusuario = CType(p1.Value.ToString().Trim(), Integer)
                Dim pass As String = p6.Value.ToString.Trim()
                Dim pintpercodigo As Integer = CType(p2.Value.ToString().Trim(), Integer)
                'Dim g As String = SecurityEncryptor.Encriptar(clave, "")
                'Dim g1 As String = g
                Dim passdesc As String = SecurityEncryptor.Desencriptar(pass, "")
                If (passdesc.ToUpper = clave.ToUpper) Then
                    If (pidusuario > 0) Then
                        exito = True
                        'info de usuario
                        objUsu = New SEGUSUARIOEntidad
                        objUsu.Usuidentificador = pidusuario
                        objUsu.Usucodigo = nombreDeUsuario
                        objUsu.Usunombre = IIf((p7.Value Is DBNull.Value OrElse p7.Value = Nothing), "", p7.Value.ToString().Trim())
                        'info de perfil
                        Dim objPerfil As New SEGPERFILEntidad
                        objPerfil.Percodigo = CType(p2.Value.ToString().Trim(), Integer)
                        objPerfil.Perdescripcion = p3.Value.ToString().Trim()
                        'inf  usario cosoto  y centro de costo
                        Dim dt1 As New DataTable
                        Dim dbc1 As DbCommand = Me.CrearComando("SYSUSUARIO_LISTARDATOS", pidusuario)
                        Try
                            dt1 = Me.EjecutarDataTable(dbc1)
                        Catch ex As Exception
                        End Try
                        Dim dtpadres As DataTable = dt.Clone()
                        Dim dwp As DataView = New DataView(dt, "intobjpadrecodigo=0", "intobjcodigo", DataViewRowState.CurrentRows)
                        If (dwp IsNot Nothing AndAlso dwp.Count > 0) Then
                            For Each drv As DataRowView In dwp
                                dtpadres.ImportRow(drv.Row)
                            Next
                            dtpadres.AcceptChanges()
                            Me.EliminarDatosRepetidos("intobjcodigo", dtpadres)
                            dtpadres.AcceptChanges()
                        End If
                        Dim dtpad As DataTable = New DataTable()
                        dtpad = dtpadres.Clone()
                        Dim dwpad As New DataView(dtpadres, "", "intobjnumorden", DataViewRowState.CurrentRows)
                        If dwpad IsNot Nothing AndAlso dwpad.Count > 0 Then
                            For Each drv As DataRowView In dwpad
                                dtpad.ImportRow(drv.Row)
                            Next
                        End If
                        dtpad.AcceptChanges()
                        Dim nroFilasxPadre As Integer = dtpad.Rows.Count
                        For ip As Integer = 1 To (nroFilasxPadre)
                            dtpadres.Rows.RemoveAt(0)
                        Next
                        dtpadres.AcceptChanges()
                        For Each drp As DataRow In dtpad.Rows
                            dtpadres.ImportRow(drp)
                        Next
                        dtpadres.AcceptChanges()
                        Me.liberarDataTable(dtpad)
                        Dim pcodob As String = "", psubcodob As String = ""
                        If dtpadres IsNot Nothing AndAlso dtpadres.Rows.Count > 0 Then
                            msg = "ok"
                            For Each dr As DataRow In dtpadres.Rows
                                pcodob = dr("intobjcodigo").ToString().Trim()
                                Dim objOb As New SEGOBJETOEntidad
                                objOb.Objcodigo = pcodob
                                objOb.Objpadrecodigo = CType(dr("intobjpadrecodigo").ToString().Trim(), Integer)
                                objOb.Objdescripcion = dr("VCHOBJDESCRIPCION").ToString().Trim()
                                objOb.Objurl = dr("VCHOBJURL").ToString().Trim()
                                objPerfil.ListadoObjetos.Add(objOb)

                                Dim dwpriv As New DataView(dt, "intobjpadrecodigo=" + pcodob, "", DataViewRowState.CurrentRows)
                                If dwpriv IsNot Nothing AndAlso dwpriv.Count > 0 Then

                                    Dim dtpriviv As DataTable = dt.Clone()
                                    For Each drv As DataRowView In dwpriv
                                        dtpriviv.ImportRow(drv.Row)
                                    Next
                                    Me.EliminarDatosRepetidos("intobjcodigo", dtpriviv)
                                    dtpriviv.AcceptChanges()

                                    For Each drpriv As DataRow In dtpriviv.Rows
                                        Dim objObP As New SEGOBJETOEntidad
                                        psubcodob = drpriv("intobjcodigo").ToString().Trim()
                                        objObP.Objcodigo = CType(psubcodob, Integer)
                                        objObP.Objpadrecodigo = CType(drpriv("intobjpadrecodigo").ToString().Trim(), Integer)
                                        objObP.Objdescripcion = drpriv("VCHOBJDESCRIPCION").ToString().Trim()
                                        objObP.Objurl = drpriv("VCHOBJURL").ToString().Trim()

                                        Dim dwacc As DataView = New DataView(dt, "intobjcodigo=" + psubcodob + " and intobjpadrecodigo=" + objObP.Objpadrecodigo.ToString(), "", DataViewRowState.CurrentRows)
                                        If dwacc IsNot Nothing AndAlso dwacc.Count > 0 Then
                                            For Each drvacc As DataRowView In dwacc
                                                Dim objAcc As New SEGACCIONEntidad
                                                objAcc.Acccodigo = CType(drvacc.Row("INTACCCODIGO").ToString().Trim(), Integer)
                                                objAcc.Accdescripcion = drvacc.Row("VCHACCDESCRIPCION").ToString().Trim()
                                                objAcc.Accnombrectrol = drvacc.Row("VCHACCNOMBRECTROL").ToString().Trim()
                                                objObP.ListadoAciones.Add(objAcc)
                                            Next

                                        End If
                                        Me.liberarDataView(dwacc)
                                        objPerfil.ListadoObjetos.Add(objObP)
                                    Next
                                    Me.liberarDataTable(dtpriviv)
                                End If
                                Me.liberarDataView(dwpriv)
                            Next
                        End If
                        objUsu.Perfilesxusuario.Add(objPerfil)
                    Else
                        exito = False : msg = "El usuario no existe en el sistema pueda que no se le haya asignado . Inténtelo de nuevo"
                    End If
                Else
                    msg = "Contraseña incorrecta.."
                    exito = False
                End If
            Else
                msg += "<br>Se ha producido un error en la aplicacion al momento de procesar su solicitud. Por favor inténtelo de nuevo"
            End If

            Return exito
        End Function

        Public Function LogeoUsuario(ByVal siscodigo As Integer, ByVal nombreDeUsuario As String, ByVal clave As String, ByRef objUsu As SEGUSUARIOEntidad, ByRef msg As String, ByVal anoejec As Integer) As Boolean
            Dim dt As New DataTable
            Dim exito As Boolean = False
            Dim P_INTSISCODIGO As Integer = siscodigo
            Dim dbc As DbCommand = Me.CrearComando("SISCAS_SEGUSUARIO_LOGEOUSUARIOGNRL", P_INTSISCODIGO, nombreDeUsuario)
            Dim p1 As New DB2Parameter("P_INTUSUIDENTIFICADOR", DB2Type.Integer)
            p1.Direction = ParameterDirection.Output
            Dim p2 As New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
            p2.Direction = ParameterDirection.Output
            Dim p3 As New DB2Parameter("P_VCHPERDESCRIPCION", DB2Type.VarChar, 50)
            p3.Direction = ParameterDirection.Output
            Dim p6 As New DB2Parameter("P_VCHUSUPASSWORD", DB2Type.VarChar, 64)
            p6.Direction = ParameterDirection.Output
            Dim p7 As New DB2Parameter("P_VCHNOMBUSU", DB2Type.VarChar, 150)
            p7.Direction = ParameterDirection.Output
            dbc.Parameters.Add(p1)
            dbc.Parameters.Add(p2)
            dbc.Parameters.Add(p3)
            dbc.Parameters.Add(p6)
            dbc.Parameters.Add(p7)
            Try
                dt = Me.EjecutarDataTable(dbc)
            Catch ex As Exception
                dt = New DataTable()
                msg = ex.Message.ToString().Trim()
                Dim msg1 As String = msg
                msg += "<br>"
                msg += "Se ha producido un error en el sistema. Inténtelo de nuevo"
                If CType(p2.Value.ToString().Trim(), Integer) = "0" Then
                End If
                exito = False
            End Try
            Me.cerrarConexion()

             If p1.Value = 0 Then
                msg = "Usuario No Existente."
                Return False
            End If

            If p1.Value IsNot Nothing AndAlso Not (p1.Value Is DBNull.Value) Then

                Dim pidusuario = CType(p1.Value.ToString().Trim(), Integer)
                'aqui se agrega los campos para la busqueda
                Dim mParam() = {pidusuario, anoejec}

                Dim pass As String = p6.Value.ToString.Trim()
                Dim pintpercodigo As Integer = CType(p2.Value.ToString().Trim(), Integer)
                'Dim g As String = SecurityEncryptor.Encriptar(clave, "")
                'Dim g1 As String = g
                Dim passdesc As String = SecurityEncryptor.Desencriptar(pass, "")
                If (passdesc.ToUpper = clave.ToUpper) Then
                    If (pidusuario > 0) Then
                        exito = True
                        'info de usuario
                        objUsu = New SEGUSUARIOEntidad
                        objUsu.Usuidentificador = pidusuario
                        objUsu.Usucodigo = nombreDeUsuario
                        objUsu.Usunombre = IIf((p7.Value Is DBNull.Value OrElse p7.Value = Nothing), "", p7.Value.ToString().Trim())
                        'info de perfil
                        Dim objPerfil As New SEGPERFILEntidad
                        objPerfil.Percodigo = CType(p2.Value.ToString().Trim(), Integer)
                        objPerfil.Perdescripcion = p3.Value.ToString().Trim()
                        'inf  usario cosoto  y centro de costo
                        Dim dt1 As New DataTable
                        Dim dbc1 As DbCommand = Me.CrearComando("SYSUSUARIO_LISTARDATOS", mParam)
                        Try
                            dt1 = Me.EjecutarDataTable(dbc1)
                        Catch ex As Exception
                        End Try
                        Dim dtpadres As DataTable = dt.Clone()
                        Dim dwp As DataView = New DataView(dt, "intobjpadrecodigo=0", "intobjcodigo", DataViewRowState.CurrentRows)
                        If (dwp IsNot Nothing AndAlso dwp.Count > 0) Then
                            For Each drv As DataRowView In dwp
                                dtpadres.ImportRow(drv.Row)
                            Next
                            dtpadres.AcceptChanges()
                            Me.EliminarDatosRepetidos("intobjcodigo", dtpadres)
                            dtpadres.AcceptChanges()
                        End If
                        Dim dtpad As DataTable = New DataTable()
                        dtpad = dtpadres.Clone()
                        Dim dwpad As New DataView(dtpadres, "", "intobjnumorden", DataViewRowState.CurrentRows)
                        If dwpad IsNot Nothing AndAlso dwpad.Count > 0 Then
                            For Each drv As DataRowView In dwpad
                                dtpad.ImportRow(drv.Row)
                            Next
                        End If
                        dtpad.AcceptChanges()
                        Dim nroFilasxPadre As Integer = dtpad.Rows.Count
                        For ip As Integer = 1 To (nroFilasxPadre)
                            dtpadres.Rows.RemoveAt(0)
                        Next
                        dtpadres.AcceptChanges()
                        For Each drp As DataRow In dtpad.Rows
                            dtpadres.ImportRow(drp)
                        Next
                        dtpadres.AcceptChanges()
                        Me.liberarDataTable(dtpad)
                        Dim pcodob As String = "", psubcodob As String = ""
                        If dtpadres IsNot Nothing AndAlso dtpadres.Rows.Count > 0 Then
                            msg = "ok"
                            For Each dr As DataRow In dtpadres.Rows
                                pcodob = dr("intobjcodigo").ToString().Trim()
                                Dim objOb As New SEGOBJETOEntidad
                                objOb.Objcodigo = pcodob
                                objOb.Objpadrecodigo = CType(dr("intobjpadrecodigo").ToString().Trim(), Integer)
                                objOb.Objdescripcion = dr("VCHOBJDESCRIPCION").ToString().Trim()
                                objOb.Objurl = dr("VCHOBJURL").ToString().Trim()
                                objPerfil.ListadoObjetos.Add(objOb)

                                Dim dwpriv As New DataView(dt, "intobjpadrecodigo=" + pcodob, "", DataViewRowState.CurrentRows)
                                If dwpriv IsNot Nothing AndAlso dwpriv.Count > 0 Then

                                    Dim dtpriviv As DataTable = dt.Clone()
                                    For Each drv As DataRowView In dwpriv
                                        dtpriviv.ImportRow(drv.Row)
                                    Next
                                    Me.EliminarDatosRepetidos("intobjcodigo", dtpriviv)
                                    dtpriviv.AcceptChanges()

                                    For Each drpriv As DataRow In dtpriviv.Rows
                                        Dim objObP As New SEGOBJETOEntidad
                                        psubcodob = drpriv("intobjcodigo").ToString().Trim()
                                        objObP.Objcodigo = CType(psubcodob, Integer)
                                        objObP.Objpadrecodigo = CType(drpriv("intobjpadrecodigo").ToString().Trim(), Integer)
                                        objObP.Objdescripcion = drpriv("VCHOBJDESCRIPCION").ToString().Trim()
                                        objObP.Objurl = drpriv("VCHOBJURL").ToString().Trim()

                                        Dim dwacc As DataView = New DataView(dt, "intobjcodigo=" + psubcodob + " and intobjpadrecodigo=" + objObP.Objpadrecodigo.ToString(), "", DataViewRowState.CurrentRows)
                                        If dwacc IsNot Nothing AndAlso dwacc.Count > 0 Then
                                            For Each drvacc As DataRowView In dwacc
                                                Dim objAcc As New SEGACCIONEntidad
                                                objAcc.Acccodigo = CType(drvacc.Row("INTACCCODIGO").ToString().Trim(), Integer)
                                                objAcc.Accdescripcion = drvacc.Row("VCHACCDESCRIPCION").ToString().Trim()
                                                objAcc.Accnombrectrol = drvacc.Row("VCHACCNOMBRECTROL").ToString().Trim()
                                                objObP.ListadoAciones.Add(objAcc)
                                            Next

                                        End If
                                        Me.liberarDataView(dwacc)
                                        objPerfil.ListadoObjetos.Add(objObP)
                                    Next
                                    Me.liberarDataTable(dtpriviv)
                                End If
                                Me.liberarDataView(dwpriv)
                            Next
                        End If
                        objUsu.Perfilesxusuario.Add(objPerfil)
                    Else
                        exito = False : msg = "El usuario no existe en el sistema pueda que no se le haya asignado . Inténtelo de nuevo"
                    End If
                Else
                    msg = "Contraseña incorrecta.."
                    exito = False
                End If
            Else
                msg += "<br>Se ha producido un error en la aplicacion al momento de procesar su solicitud. Por favor inténtelo de nuevo"
            End If

            Return exito
        End Function

        Public Function encripta(ByVal PassNuevo As String) As String
            Dim asdf As String = ""
            Dim passSS As String = ""
            Dim encpassanterior As String = ""
            encpassanterior = SecurityEncryptor.Encriptar(PassNuevo, "")
            Return encpassanterior
        End Function

        Public Function LogeoUsuario(ByVal siscodigo As Integer, ByVal nombreDeUsuario As String, ByVal clave As String) As SEGUSUARIOEntidad
            Dim objUsu As New SEGUSUARIOEntidad
            Dim msg As String = ""
            Dim dt As New DataTable
            Dim exito As Boolean = False
            Dim P_INTSISCODIGO As Integer = siscodigo
            Dim dbc As DbCommand = Me.CrearComando("SISCAS_SEGUSUARIO_LOGEOUSUARIOGNRL", P_INTSISCODIGO, nombreDeUsuario)
            Dim p1 As New DB2Parameter("P_INTUSUIDENTIFICADOR", DB2Type.Integer)
            p1.Direction = ParameterDirection.Output
            Dim p2 As New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
            p2.Direction = ParameterDirection.Output
            Dim p3 As New DB2Parameter("P_VCHPERDESCRIPCION", DB2Type.VarChar, 50)
            p3.Direction = ParameterDirection.Output
            Dim p6 As New DB2Parameter("P_VCHUSUPASSWORD", DB2Type.VarChar, 64)
            p6.Direction = ParameterDirection.Output
            Dim p7 As New DB2Parameter("P_VCHNOMBUSU", DB2Type.VarChar, 150)
            p7.Direction = ParameterDirection.Output
            dbc.Parameters.Add(p1)
            dbc.Parameters.Add(p2)
            dbc.Parameters.Add(p3)
            dbc.Parameters.Add(p6)
            dbc.Parameters.Add(p7)
            Try
                dt = Me.EjecutarDataTable(dbc)
            Catch ex As Exception
                dt = New DataTable()
                msg = ex.Message.ToString().Trim()
                Dim msg1 As String = msg
                msg += "<br>"
                msg += "Se ha producido un error en el sistema. Inténtelo de nuevo"
                exito = False
            End Try
            Me.cerrarConexion()

            If p1.Value = 0 Then
                msg = "Usuario No Existente."
                Return objUsu
            End If

            If p1.Value IsNot Nothing AndAlso Not (p1.Value Is DBNull.Value) Then
                Dim pidusuario = CType(p1.Value.ToString().Trim(), Integer)
                Dim pass As String = p6.Value.ToString.Trim()
                Dim pintpercodigo As Integer = CType(p2.Value.ToString().Trim(), Integer)
                'Dim g As String = SecurityEncryptor.Encriptar(clave, "")
                'Dim g1 As String = g
                Dim passdesc As String = SecurityEncryptor.Desencriptar(pass, "")
                If (passdesc.ToUpper = clave.ToUpper) Then
                    If (pidusuario > 0) Then
                        exito = True
                        'info de usuario
                        objUsu = New SEGUSUARIOEntidad
                        objUsu.Usuidentificador = pidusuario
                        objUsu.Usucodigo = nombreDeUsuario
                        objUsu.Usunombre = IIf((p7.Value Is DBNull.Value OrElse p7.Value = Nothing), "", p7.Value.ToString().Trim())
                        'info de perfil
                        Dim objPerfil As New SEGPERFILEntidad
                        objPerfil.Percodigo = CType(p2.Value.ToString().Trim(), Integer)
                        objPerfil.Perdescripcion = p3.Value.ToString().Trim()
                        'inf  usario cosoto  y centro de costo
                        Dim dt1 As New DataTable
                        Dim dbc1 As DbCommand = Me.CrearComando("SYSUSUARIO_LISTARDATOS", pidusuario)
                        Try
                            dt1 = Me.EjecutarDataTable(dbc1)
                        Catch ex As Exception
                        End Try
                        Dim dtpadres As DataTable = dt.Clone()
                        Dim dwp As DataView = New DataView(dt, "intobjpadrecodigo=0", "intobjcodigo", DataViewRowState.CurrentRows)
                        If (dwp IsNot Nothing AndAlso dwp.Count > 0) Then
                            For Each drv As DataRowView In dwp
                                dtpadres.ImportRow(drv.Row)
                            Next
                            dtpadres.AcceptChanges()
                            Me.EliminarDatosRepetidos("intobjcodigo", dtpadres)
                            dtpadres.AcceptChanges()
                        End If
                        Dim dtpad As DataTable = New DataTable()
                        dtpad = dtpadres.Clone()
                        Dim dwpad As New DataView(dtpadres, "", "intobjnumorden", DataViewRowState.CurrentRows)
                        If dwpad IsNot Nothing AndAlso dwpad.Count > 0 Then
                            For Each drv As DataRowView In dwpad
                                dtpad.ImportRow(drv.Row)
                            Next
                        End If
                        dtpad.AcceptChanges()
                        Dim nroFilasxPadre As Integer = dtpad.Rows.Count
                        For ip As Integer = 1 To (nroFilasxPadre)
                            dtpadres.Rows.RemoveAt(0)
                        Next
                        dtpadres.AcceptChanges()
                        For Each drp As DataRow In dtpad.Rows
                            dtpadres.ImportRow(drp)
                        Next
                        dtpadres.AcceptChanges()
                        Me.liberarDataTable(dtpad)
                        Dim pcodob As String = "", psubcodob As String = ""
                        If dtpadres IsNot Nothing AndAlso dtpadres.Rows.Count > 0 Then
                            msg = "ok"
                            For Each dr As DataRow In dtpadres.Rows
                                pcodob = dr("intobjcodigo").ToString().Trim()
                                Dim objOb As New SEGOBJETOEntidad
                                objOb.Objcodigo = pcodob
                                objOb.Objpadrecodigo = CType(dr("intobjpadrecodigo").ToString().Trim(), Integer)
                                objOb.Objdescripcion = dr("VCHOBJDESCRIPCION").ToString().Trim()
                                objOb.Objurl = dr("VCHOBJURL").ToString().Trim()
                                objPerfil.ListadoObjetos.Add(objOb)

                                Dim dwpriv As New DataView(dt, "intobjpadrecodigo=" + pcodob, "", DataViewRowState.CurrentRows)
                                If dwpriv IsNot Nothing AndAlso dwpriv.Count > 0 Then

                                    Dim dtpriviv As DataTable = dt.Clone()
                                    For Each drv As DataRowView In dwpriv
                                        dtpriviv.ImportRow(drv.Row)
                                    Next
                                    Me.EliminarDatosRepetidos("intobjcodigo", dtpriviv)
                                    dtpriviv.AcceptChanges()

                                    For Each drpriv As DataRow In dtpriviv.Rows
                                        Dim objObP As New SEGOBJETOEntidad
                                        psubcodob = drpriv("intobjcodigo").ToString().Trim()
                                        objObP.Objcodigo = CType(psubcodob, Integer)
                                        objObP.Objpadrecodigo = CType(drpriv("intobjpadrecodigo").ToString().Trim(), Integer)
                                        objObP.Objdescripcion = drpriv("VCHOBJDESCRIPCION").ToString().Trim()
                                        objObP.Objurl = drpriv("VCHOBJURL").ToString().Trim()

                                        Dim dwacc As DataView = New DataView(dt, "intobjcodigo=" + psubcodob + " and intobjpadrecodigo=" + objObP.Objpadrecodigo.ToString(), "", DataViewRowState.CurrentRows)
                                        If dwacc IsNot Nothing AndAlso dwacc.Count > 0 Then
                                            For Each drvacc As DataRowView In dwacc
                                                Dim objAcc As New SEGACCIONEntidad
                                                objAcc.Acccodigo = CType(drvacc.Row("INTACCCODIGO").ToString().Trim(), Integer)
                                                objAcc.Accdescripcion = drvacc.Row("VCHACCDESCRIPCION").ToString().Trim()
                                                objAcc.Accnombrectrol = drvacc.Row("VCHACCNOMBRECTROL").ToString().Trim()
                                                objObP.ListadoAciones.Add(objAcc)
                                            Next

                                        End If
                                        Me.liberarDataView(dwacc)
                                        objPerfil.ListadoObjetos.Add(objObP)
                                    Next
                                    Me.liberarDataTable(dtpriviv)
                                End If
                                Me.liberarDataView(dwpriv)
                            Next
                        End If
                        objUsu.Perfilesxusuario.Add(objPerfil)
                    Else
                        exito = False : msg = "El usuario no existe en el sistema pueda que no se le haya asignado . Inténtelo de nuevo"
                    End If
                Else
                    msg = "Contraseña incorrecta..."
                    exito = False
                End If
            Else
                msg += "<br>Se ha producido un error en la aplicacion al momento de procesar su solicitud. Por favor inténtelo de nuevo"
            End If

            Return objUsu
        End Function


        Private Sub liberarDataView(ByRef dt As DataView)
            If Not (dt Is Nothing) Then
                dt.Dispose()
            End If
        End Sub
        Private Sub liberarDataTable(ByRef dt As DataTable)
            If Not (dt Is Nothing) Then
                dt.Dispose()
            End If
        End Sub

        Private Sub EliminarDatosRepetidos(ByVal nombcol As String, ByRef dt As DataTable)
            Dim nroRows As Integer = dt.Rows.Count - 1
            Dim i As Integer = 0
            For i = 0 To (nroRows) Step 1
                If nroRows > 0 AndAlso ((i + 1) <= nroRows) Then
                    Dim codc As String = dt.Rows(i)(nombcol).ToString().Trim()
                    If (dt.Rows(i)(nombcol).ToString().Trim() = dt.Rows(i + 1)(nombcol).ToString().Trim()) Then
                        dt.Rows.RemoveAt(i + 1)
                        i = i - 1
                        nroRows = nroRows - 1
                    End If
                Else
                    Exit For
                End If
            Next
        End Sub

        Public Function ListaUsuarios(ByVal sistema As Integer) As DataSet
            Dim ds As New DataSet
            Dim dbc As DbCommand = Me.CrearComando("SISCAS_SEGPERFILXUSUARIOXSISTEMA", sistema)
            Try
                ds = Me.EjecutarDataSet(dbc)
            Catch ex As Exception
                ds = New DataSet()
            End Try
            Me.cerrarConexion()
            Return ds
        End Function

        Public Function AsignarPerfilaUsuario(ByVal P_INTSISCODIGO As Integer, ByVal P_INTUSUIDENTIFICADOR As Integer, ByVal P_INTPERCODIGO As Integer, ByVal P_VCHAUDPROGRAMACREACION As String, ByVal P_VCHAUDEQUIPOCREACION As String, ByVal P_VCHAUDUSUCREACION As String) As Boolean
            Dim dbc As DbCommand = Me.CrearComando("SISCAS_SEGPERFIL_ASIGNAR_USUARIO", P_INTSISCODIGO, P_INTUSUIDENTIFICADOR, P_INTPERCODIGO, P_VCHAUDPROGRAMACREACION, P_VCHAUDEQUIPOCREACION, P_VCHAUDUSUCREACION)
            Try
                Me.Ejecutar(dbc)
            Catch ex As Exception
                Me.cerrarConexion()
                Return False
            End Try
            Me.cerrarConexion()
            Return True
        End Function
    End Class

End Namespace
