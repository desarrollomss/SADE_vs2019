Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

    Public Class SYSPERSONA_DL
        Private cnDB2 As DB2Connection

#Region "Numerador"
        Public Enum Campos
            p_ADMCODIGO = 0
            p_ADMAPEPAT = 1
            p_ADMAPEMAT = 2
            p_ADMNOMBRES = 3
            p_ADMCOMPLETO = 4
            p_ADMTIPDOC = 5
            p_ADMNUMDOC = 6
            p_strdesvaloropc1 = 7
            p_strdesvaloropc2 = 8
        End Enum
#End Region

        Public Sub New()
            cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2("cadSATTI"))
        End Sub

        Public Function consultAutoNombre(ByVal P_NOMBRE As String) As List(Of SYSPERSONA_BE)
            Dim oSYSPERSONA_BE As New SYSPERSONA_BE
            Dim lstGeneral As New List(Of SYSPERSONA_BE)

            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_NOMBRE", DB2Type.VarChar)
                arrParam(0).Value = P_NOMBRE
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.SYSCATASTRO_AUTONOMBRE_LISTAR", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oSYSPERSONA_BE = New SYSPERSONA_BE
                        If oDataReader.IsDBNull(0) Then oSYSPERSONA_BE.p_INTADMCODIGO = Nothing Else oSYSPERSONA_BE.p_INTADMCODIGO = CType(oDataReader(0), Int32)
                        oSYSPERSONA_BE.p_VCHADMCOMPLETO = IIf(oDataReader.IsDBNull(1), "", oDataReader(1))
                        oSYSPERSONA_BE.p_strdesvaloropc1 = ""
                        oSYSPERSONA_BE.p_strdesvaloropc2 = ""
                        lstGeneral.Add(oSYSPERSONA_BE)
                    Loop
                End Using
                Return lstGeneral
            Catch ex As Exception
                Dim strErrNumber As String
                Dim strErrDescripcion As String
                strErrNumber = Err.Number.ToString
                strErrDescripcion = " Error en la consulta " + Err.Description.Trim
                oSYSPERSONA_BE = New SYSPERSONA_BE
                oSYSPERSONA_BE.p_strdesvaloropc1 = strErrNumber
                oSYSPERSONA_BE.p_strdesvaloropc2 = strErrDescripcion
                lstGeneral.Add(oSYSPERSONA_BE)
                oSYSPERSONA_BE = Nothing
                Return lstGeneral
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return lstGeneral
        End Function

        Public Function consultAutoCodigo(ByVal P_CODIGO As Integer) As List(Of SYSPERSONA_BE)
            Dim oSYSPERSONA_BE As New SYSPERSONA_BE
            Dim lstGeneral As New List(Of SYSPERSONA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_CODIGO", DB2Type.Integer)
                arrParam(0).Value = P_CODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.SYSCATASTRO_AUTOCODIGO_LISTAR", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oSYSPERSONA_BE = New SYSPERSONA_BE
                        If oDataReader.IsDBNull(Campos.p_ADMCODIGO) Then oSYSPERSONA_BE.p_INTADMCODIGO = Nothing Else oSYSPERSONA_BE.p_INTADMCODIGO = CType(oDataReader(Campos.p_ADMCODIGO), Int32)
                        oSYSPERSONA_BE.p_VCHADMAPEPAT = IIf(oDataReader.IsDBNull(Campos.p_ADMAPEPAT), "", oDataReader(Campos.p_ADMAPEPAT))
                        oSYSPERSONA_BE.p_VCHADMAPEMAT = IIf(oDataReader.IsDBNull(Campos.p_ADMAPEMAT), "", oDataReader(Campos.p_ADMAPEMAT))
                        oSYSPERSONA_BE.p_VCHADMNOMBRES = IIf(oDataReader.IsDBNull(Campos.p_ADMNOMBRES), "", oDataReader(Campos.p_ADMNOMBRES))
                        oSYSPERSONA_BE.p_VCHADMCOMPLETO = IIf(oDataReader.IsDBNull(Campos.p_ADMCOMPLETO), "", oDataReader(Campos.p_ADMCOMPLETO))
                        oSYSPERSONA_BE.p_VCHADMTIPDOC = IIf(oDataReader.IsDBNull(Campos.p_ADMTIPDOC), "", oDataReader(Campos.p_ADMTIPDOC))
                        oSYSPERSONA_BE.p_VCHADMNUMDOC = IIf(oDataReader.IsDBNull(Campos.p_ADMNUMDOC), "", oDataReader(Campos.p_ADMNUMDOC))
                        oSYSPERSONA_BE.p_strdesvaloropc1 = IIf(oDataReader.IsDBNull(Campos.p_strdesvaloropc1), "", oDataReader(Campos.p_strdesvaloropc1))
                        oSYSPERSONA_BE.p_strdesvaloropc2 = IIf(oDataReader.IsDBNull(Campos.p_strdesvaloropc2), "", oDataReader(Campos.p_strdesvaloropc2))
                        lstGeneral.Add(oSYSPERSONA_BE)
                    Loop
                End Using
                Return lstGeneral
            Catch ex As Exception
                Dim strErrNumber As String
                Dim strErrDescripcion As String
                strErrNumber = Err.Number.ToString
                strErrDescripcion = " Error en la consulta " + Err.Description.Trim
                oSYSPERSONA_BE = New SYSPERSONA_BE
                oSYSPERSONA_BE.p_strdesvaloropc1 = strErrNumber
                oSYSPERSONA_BE.p_strdesvaloropc2 = strErrDescripcion
                lstGeneral.Add(oSYSPERSONA_BE)
                oSYSPERSONA_BE = Nothing
                Return lstGeneral
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return lstGeneral
        End Function

    End Class
End Namespace
