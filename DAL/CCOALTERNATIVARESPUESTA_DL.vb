Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOALTERNATIVARESPUESTA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			ALTCODIGO = 0
			ALTDESCRIPCION = 1
			TRECODIGO = 2
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOALTERNATIVARESPUESTA_BE As CCOALTERNATIVARESPUESTA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
				arrParam(0) = New DB2Parameter("P_SMLALTCODIGO", DB2Type.SMALLINT)
				arrParam(0).Value = pCCOALTERNATIVARESPUESTA_BE.PropALTCODIGO
				arrParam(1) = New DB2Parameter("P_VCHALTDESCRIPCION", DB2Type.VARCHAR, 60)
				arrParam(1).Value = pCCOALTERNATIVARESPUESTA_BE.PropALTDESCRIPCION
				arrParam(2) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.SMALLINT)
				arrParam(2).Value = pCCOALTERNATIVARESPUESTA_BE.PropTRECODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOALTERNATIVARESPUESTA_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOALTERNATIVARESPUESTA_BE As CCOALTERNATIVARESPUESTA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(2) {}
                arrParam(0) = New DB2Parameter("P_SMLALTCODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCOALTERNATIVARESPUESTA_BE.PropALTCODIGO
                arrParam(1) = New DB2Parameter("P_VCHALTDESCRIPCION", DB2Type.VARCHAR, 60)
                arrParam(1).Value = pCCOALTERNATIVARESPUESTA_BE.PropALTDESCRIPCION
                arrParam(2) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.SMALLINT)
                arrParam(2).Value = pCCOALTERNATIVARESPUESTA_BE.PropTRECODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOALTERNATIVARESPUESTA_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOALTERNATIVARESPUESTA_BE As CCOALTERNATIVARESPUESTA_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_SMLALTCODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCOALTERNATIVARESPUESTA_BE.PropALTCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOALTERNATIVARESPUESTA_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOALTERNATIVARESPUESTA_BE As CCOALTERNATIVARESPUESTA_BE) As CCOALTERNATIVARESPUESTA_BE
            Dim oCCOALTERNATIVARESPUESTA_BE As New CCOALTERNATIVARESPUESTA_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_SMLALTCODIGO", DB2Type.SMALLINT)
                arrParam(0).Value = pCCOALTERNATIVARESPUESTA_BE.PropALTCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOALTERNATIVARESPUESTA_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.ALTCODIGO) Then oCCOALTERNATIVARESPUESTA_BE.PropALTCODIGO = Nothing Else oCCOALTERNATIVARESPUESTA_BE.PropALTCODIGO = CType(oDataReader(Campos.ALTCODIGO), Int16)
                    oCCOALTERNATIVARESPUESTA_BE.PropALTDESCRIPCION = IIf(oDataReader.IsDBNull(Campos.ALTDESCRIPCION), "", oDataReader(Campos.ALTDESCRIPCION))
                    If oDataReader.IsDBNull(Campos.TRECODIGO) Then oCCOALTERNATIVARESPUESTA_BE.PropTRECODIGO = Nothing Else oCCOALTERNATIVARESPUESTA_BE.PropTRECODIGO = CType(oDataReader(Campos.TRECODIGO), Int16)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOALTERNATIVARESPUESTA_BE
        End Function


        Public Function ListarCombo(ByVal pCCOALTERNATIVARESPUESTA_BE As CCOALTERNATIVARESPUESTA_BE) As DataTable
            Dim dt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_SMLTRECODIGO", DB2Type.SmallInt)
                arrParam(0).Value = pCCOALTERNATIVARESPUESTA_BE.PropTRECODIGO
                dt.Load(DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOALTERNATIVARESPUESTA_LISTARCOMBO", arrParam))
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return dt
        End Function


	End Class
End Namespace
