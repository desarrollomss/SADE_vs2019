Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOPERSONALFAMILIA_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			PFACODIGO = 0
			PFASECUENCIA = 1
			PFANOMBRE = 2
			PERCODIGO = 3
			PARCODIGO = 4
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOPERSONALFAMILIA_BE As CCOPERSONALFAMILIA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
				arrParam(0) = New DB2Parameter("P_INTPFACODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOPERSONALFAMILIA_BE.PropPFACODIGO
				arrParam(1) = New DB2Parameter("P_SMLPFASECUENCIA", DB2Type.SMALLINT)
				arrParam(1).Value = pCCOPERSONALFAMILIA_BE.PropPFASECUENCIA
				arrParam(2) = New DB2Parameter("P_VCHPFANOMBRE", DB2Type.VARCHAR, 50)
				arrParam(2).Value = pCCOPERSONALFAMILIA_BE.PropPFANOMBRE
				arrParam(3) = New DB2Parameter("P_INTPERCODIGO", DB2Type.INTEGER)
				arrParam(3).Value = pCCOPERSONALFAMILIA_BE.PropPERCODIGO
				arrParam(4) = New DB2Parameter("P_SMLPARCODIGO", DB2Type.SMALLINT)
				arrParam(4).Value = pCCOPERSONALFAMILIA_BE.PropPARCODIGO
				DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SADE.CCOPERSONALFAMILIA_INSERTAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOPERSONALFAMILIA_BE As CCOPERSONALFAMILIA_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(4) {}
				arrParam(0) = New DB2Parameter("P_INTPFACODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOPERSONALFAMILIA_BE.PropPFACODIGO
				arrParam(1) = New DB2Parameter("P_SMLPFASECUENCIA", DB2Type.SMALLINT)
				arrParam(1).Value = pCCOPERSONALFAMILIA_BE.PropPFASECUENCIA
				arrParam(2) = New DB2Parameter("P_VCHPFANOMBRE", DB2Type.VARCHAR, 50)
				arrParam(2).Value = pCCOPERSONALFAMILIA_BE.PropPFANOMBRE
				arrParam(3) = New DB2Parameter("P_INTPERCODIGO", DB2Type.INTEGER)
				arrParam(3).Value = pCCOPERSONALFAMILIA_BE.PropPERCODIGO
				arrParam(4) = New DB2Parameter("P_SMLPARCODIGO", DB2Type.SMALLINT)
				arrParam(4).Value = pCCOPERSONALFAMILIA_BE.PropPARCODIGO
				DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SADE.CCOPERSONALFAMILIA_ACTUALIZAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOPERSONALFAMILIA_BE As CCOPERSONALFAMILIA_BE)
			Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPFACODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOPERSONALFAMILIA_BE.PropPFACODIGO
				DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "SADE.CCOPERSONALFAMILIA_ELIMINAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOPERSONALFAMILIA_BE As CCOPERSONALFAMILIA_BE) As CCOPERSONALFAMILIA_BE
			Dim oCCOPERSONALFAMILIA_BE As New CCOPERSONALFAMILIA_BE
			Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPFACODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOPERSONALFAMILIA_BE.PropPFACODIGO
				Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "SADE.CCOPERSONALFAMILIA_LISTARKEY", arrParam)
				Do While oDataReader.Read()
					If oDataReader.IsDBNull(Campos.PFACODIGO) Then oCCOPERSONALFAMILIA_BE.PropPFACODIGO = Nothing Else oCCOPERSONALFAMILIA_BE.PropPFACODIGO = CType(oDataReader(Campos.PFACODIGO), Int32)
					If oDataReader.IsDBNull(Campos.PFASECUENCIA) Then oCCOPERSONALFAMILIA_BE.PropPFASECUENCIA = Nothing Else oCCOPERSONALFAMILIA_BE.PropPFASECUENCIA = CType(oDataReader(Campos.PFASECUENCIA), Int16)
					oCCOPERSONALFAMILIA_BE.PropPFANOMBRE = IIf(oDataReader.IsDBNull(Campos.PFANOMBRE), "", oDataReader(Campos.PFANOMBRE))
					If oDataReader.IsDBNull(Campos.PERCODIGO) Then oCCOPERSONALFAMILIA_BE.PropPERCODIGO = Nothing Else oCCOPERSONALFAMILIA_BE.PropPERCODIGO = CType(oDataReader(Campos.PERCODIGO), Int32)
					If oDataReader.IsDBNull(Campos.PARCODIGO) Then oCCOPERSONALFAMILIA_BE.PropPARCODIGO = Nothing Else oCCOPERSONALFAMILIA_BE.PropPARCODIGO = CType(oDataReader(Campos.PARCODIGO), Int16)
					Exit Do
				Loop
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
			Return oCCOPERSONALFAMILIA_BE
		End Function

        Public Function Listar(ByVal pCCOPERSONALFAMILIA_BE As CCOPERSONALFAMILIA_BE) As DataTable
            Dim odt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPERCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOPERSONALFAMILIA_BE.PropPERCODIGO

                Using dataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPERSONALFAMILIA_LISTAR", arrParam)
                    odt.Load(dataReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return odt
        End Function
	End Class
End Namespace
