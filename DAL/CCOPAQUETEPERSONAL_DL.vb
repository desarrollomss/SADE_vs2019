Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOPAQUETEPERSONAL_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			PQPCODIGO = 0
			PAQCODIGO = 1
			PERCODIGO = 2
			PQPRESPONSABLE = 3
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOPAQUETEPERSONAL_BE As CCOPAQUETEPERSONAL_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
				arrParam(0) = New DB2Parameter("P_INTPQPCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOPAQUETEPERSONAL_BE.PropPQPCODIGO
				arrParam(1) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
				arrParam(1).Value = pCCOPAQUETEPERSONAL_BE.PropPAQCODIGO
				arrParam(2) = New DB2Parameter("P_INTPERCODIGO", DB2Type.INTEGER)
				arrParam(2).Value = pCCOPAQUETEPERSONAL_BE.PropPERCODIGO
				arrParam(3) = New DB2Parameter("P_SMLPQPRESPONSABLE", DB2Type.SMALLINT)
				arrParam(3).Value = pCCOPAQUETEPERSONAL_BE.PropPQPRESPONSABLE
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPAQUETEPERSONAL_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOPAQUETEPERSONAL_BE As CCOPAQUETEPERSONAL_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(3) {}
                arrParam(0) = New DB2Parameter("P_INTPQPCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPAQUETEPERSONAL_BE.PropPQPCODIGO
                arrParam(1) = New DB2Parameter("P_INTPAQCODIGO", DB2Type.INTEGER)
                arrParam(1).Value = pCCOPAQUETEPERSONAL_BE.PropPAQCODIGO
                arrParam(2) = New DB2Parameter("P_INTPERCODIGO", DB2Type.INTEGER)
                arrParam(2).Value = pCCOPAQUETEPERSONAL_BE.PropPERCODIGO
                arrParam(3) = New DB2Parameter("P_SMLPQPRESPONSABLE", DB2Type.SMALLINT)
                arrParam(3).Value = pCCOPAQUETEPERSONAL_BE.PropPQPRESPONSABLE
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPAQUETEPERSONAL_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOPAQUETEPERSONAL_BE As CCOPAQUETEPERSONAL_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPQPCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPAQUETEPERSONAL_BE.PropPQPCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOPAQUETEPERSONAL_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOPAQUETEPERSONAL_BE As CCOPAQUETEPERSONAL_BE) As CCOPAQUETEPERSONAL_BE
            Dim oCCOPAQUETEPERSONAL_BE As New CCOPAQUETEPERSONAL_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTPQPCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOPAQUETEPERSONAL_BE.PropPQPCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOPAQUETEPERSONAL_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.PQPCODIGO) Then oCCOPAQUETEPERSONAL_BE.PropPQPCODIGO = Nothing Else oCCOPAQUETEPERSONAL_BE.PropPQPCODIGO = CType(oDataReader(Campos.PQPCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.PAQCODIGO) Then oCCOPAQUETEPERSONAL_BE.PropPAQCODIGO = Nothing Else oCCOPAQUETEPERSONAL_BE.PropPAQCODIGO = CType(oDataReader(Campos.PAQCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.PERCODIGO) Then oCCOPAQUETEPERSONAL_BE.PropPERCODIGO = Nothing Else oCCOPAQUETEPERSONAL_BE.PropPERCODIGO = CType(oDataReader(Campos.PERCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.PQPRESPONSABLE) Then oCCOPAQUETEPERSONAL_BE.PropPQPRESPONSABLE = Nothing Else oCCOPAQUETEPERSONAL_BE.PropPQPRESPONSABLE = CType(oDataReader(Campos.PQPRESPONSABLE), Int16)
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOPAQUETEPERSONAL_BE
        End Function


	End Class
End Namespace
