Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

    Public Class SYSDNI_DL
        Private cnDB2 As DB2Connection

#Region "Numerador"
        Public Enum Campos
            p_VCHDNI = 0
            p_VCHAPEPAT = 1
            p_VCHAPEMAT = 2
            p_VCHNOMBRES = 3
            p_VCHFECNAC = 4
            p_VCHNOMBRECOMPLETO = 5
            p_strdesvaloropc1 = 6
            p_strdesvaloropc2 = 7
        End Enum
#End Region

        Public Sub New()
            cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2("cadSATTI"))
        End Sub


        Public Function dniBusqueda(ByVal P_NUMERO As String) As List(Of SYSDNI_BE)
            Dim oSYSDNI_BE As New SYSDNI_BE
            Dim lstGeneral As New List(Of SYSDNI_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_VCHDNI", DB2Type.VarChar, 8)
                arrParam(0).Value = P_NUMERO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SIRCAT.TMP_DNIPERU_BUSCAR", arrParam)
                Using oDataReader
                    Do While oDataReader.Read()
                        oSYSDNI_BE = New SYSDNI_BE
                        oSYSDNI_BE.p_VCHDNI = IIf(oDataReader.IsDBNull(Campos.p_VCHDNI), "", oDataReader(Campos.p_VCHDNI))
                        oSYSDNI_BE.p_VCHAPEPAT = IIf(oDataReader.IsDBNull(Campos.p_VCHAPEPAT), "", oDataReader(Campos.p_VCHAPEPAT))
                        oSYSDNI_BE.p_VCHAPEMAT = IIf(oDataReader.IsDBNull(Campos.p_VCHAPEMAT), "", oDataReader(Campos.p_VCHAPEMAT))
                        oSYSDNI_BE.p_VCHNOMBRES = IIf(oDataReader.IsDBNull(Campos.p_VCHNOMBRES), "", oDataReader(Campos.p_VCHNOMBRES))
                        oSYSDNI_BE.p_VCHFECNAC = IIf(oDataReader.IsDBNull(Campos.p_VCHFECNAC), "", oDataReader(Campos.p_VCHFECNAC))
                        oSYSDNI_BE.p_VCHNOMBRECOMPLETO = IIf(oDataReader.IsDBNull(Campos.p_VCHNOMBRECOMPLETO), "", oDataReader(Campos.p_VCHNOMBRECOMPLETO))
                        lstGeneral.Add(oSYSDNI_BE)
                    Loop
                End Using
                Return lstGeneral
            Catch ex As Exception
                Dim strErrNumber As String
                Dim strErrDescripcion As String
                strErrNumber = Err.Number.ToString
                strErrDescripcion = " Error en la consulta " + Err.Description.Trim
                oSYSDNI_BE = New SYSDNI_BE
                oSYSDNI_BE.p_strdesvaloropc1 = strErrNumber
                oSYSDNI_BE.p_strdesvaloropc2 = strErrDescripcion
                lstGeneral.Add(oSYSDNI_BE)
                oSYSDNI_BE = Nothing
                Return lstGeneral
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return lstGeneral
        End Function


    End Class
End Namespace
