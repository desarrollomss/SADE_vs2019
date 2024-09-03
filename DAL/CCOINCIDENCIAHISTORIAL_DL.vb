Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class CCOINCIDENCIAHISTORIAL_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			HISCODIGO = 0
			INCCODIGO = 1
			HISUSUARIO = 2
			HISROLUSUARIO = 3
			HISFECHAHORA = 4
			HISEQUIPO = 5
			HISPROGRAMA = 6
			HISOPERACION = 7
			INRCODIGO = 8
			HISCOMENTARIO = 9
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pCCOINCIDENCIAHISTORIAL_BE As CCOINCIDENCIAHISTORIAL_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(9) {}
				arrParam(0) = New DB2Parameter("P_INTHISCODIGO", DB2Type.INTEGER)
				arrParam(0).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISCODIGO
				arrParam(1) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
				arrParam(1).Value = pCCOINCIDENCIAHISTORIAL_BE.PropINCCODIGO
				arrParam(2) = New DB2Parameter("P_VCHHISUSUARIO", DB2Type.VARCHAR, 10)
				arrParam(2).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISUSUARIO
				arrParam(3) = New DB2Parameter("P_INTHISROLUSUARIO", DB2Type.INTEGER)
				arrParam(3).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISROLUSUARIO
				arrParam(4) = New DB2Parameter("P_DTMHISFECHAHORA", DB2Type.TIMESTAMP)
				arrParam(4).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISFECHAHORA
				arrParam(5) = New DB2Parameter("P_VCHHISEQUIPO", DB2Type.VARCHAR, 60)
				arrParam(5).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISEQUIPO
				arrParam(6) = New DB2Parameter("P_VCHHISPROGRAMA", DB2Type.VARCHAR, 150)
				arrParam(6).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISPROGRAMA
				arrParam(7) = New DB2Parameter("P_VCHHISOPERACION", DB2Type.VARCHAR, 30)
				arrParam(7).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISOPERACION
				arrParam(8) = New DB2Parameter("P_INTINRCODIGO", DB2Type.INTEGER)
				arrParam(8).Value = pCCOINCIDENCIAHISTORIAL_BE.PropINRCODIGO
				arrParam(9) = New DB2Parameter("P_VCHHISCOMENTARIO", DB2Type.VARCHAR, 250)
				arrParam(9).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISCOMENTARIO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAHISTORIAL_INSERTAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOINCIDENCIAHISTORIAL_BE As CCOINCIDENCIAHISTORIAL_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(9) {}
                arrParam(0) = New DB2Parameter("P_INTHISCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISCODIGO
                arrParam(1) = New DB2Parameter("P_INTINCCODIGO", DB2Type.INTEGER)
                arrParam(1).Value = pCCOINCIDENCIAHISTORIAL_BE.PropINCCODIGO
                arrParam(2) = New DB2Parameter("P_VCHHISUSUARIO", DB2Type.VARCHAR, 10)
                arrParam(2).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISUSUARIO
                arrParam(3) = New DB2Parameter("P_INTHISROLUSUARIO", DB2Type.INTEGER)
                arrParam(3).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISROLUSUARIO
                arrParam(4) = New DB2Parameter("P_DTMHISFECHAHORA", DB2Type.TIMESTAMP)
                arrParam(4).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISFECHAHORA
                arrParam(5) = New DB2Parameter("P_VCHHISEQUIPO", DB2Type.VARCHAR, 60)
                arrParam(5).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISEQUIPO
                arrParam(6) = New DB2Parameter("P_VCHHISPROGRAMA", DB2Type.VARCHAR, 150)
                arrParam(6).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISPROGRAMA
                arrParam(7) = New DB2Parameter("P_VCHHISOPERACION", DB2Type.VARCHAR, 30)
                arrParam(7).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISOPERACION
                arrParam(8) = New DB2Parameter("P_INTINRCODIGO", DB2Type.INTEGER)
                arrParam(8).Value = pCCOINCIDENCIAHISTORIAL_BE.PropINRCODIGO
                arrParam(9) = New DB2Parameter("P_VCHHISCOMENTARIO", DB2Type.VARCHAR, 250)
                arrParam(9).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISCOMENTARIO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAHISTORIAL_ACTUALIZAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOINCIDENCIAHISTORIAL_BE As CCOINCIDENCIAHISTORIAL_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTHISCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISCODIGO
                DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAHISTORIAL_ELIMINAR", arrParam)
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOINCIDENCIAHISTORIAL_BE As CCOINCIDENCIAHISTORIAL_BE) As CCOINCIDENCIAHISTORIAL_BE
            Dim oCCOINCIDENCIAHISTORIAL_BE As New CCOINCIDENCIAHISTORIAL_BE
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTHISCODIGO", DB2Type.INTEGER)
                arrParam(0).Value = pCCOINCIDENCIAHISTORIAL_BE.PropHISCODIGO
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAHISTORIAL_LISTARKEY", arrParam)
                Do While oDataReader.Read()
                    If oDataReader.IsDBNull(Campos.HISCODIGO) Then oCCOINCIDENCIAHISTORIAL_BE.PropHISCODIGO = Nothing Else oCCOINCIDENCIAHISTORIAL_BE.PropHISCODIGO = CType(oDataReader(Campos.HISCODIGO), Int32)
                    If oDataReader.IsDBNull(Campos.INCCODIGO) Then oCCOINCIDENCIAHISTORIAL_BE.PropINCCODIGO = Nothing Else oCCOINCIDENCIAHISTORIAL_BE.PropINCCODIGO = CType(oDataReader(Campos.INCCODIGO), Int32)
                    oCCOINCIDENCIAHISTORIAL_BE.PropHISUSUARIO = IIf(oDataReader.IsDBNull(Campos.HISUSUARIO), "", oDataReader(Campos.HISUSUARIO))
                    If oDataReader.IsDBNull(Campos.HISROLUSUARIO) Then oCCOINCIDENCIAHISTORIAL_BE.PropHISROLUSUARIO = Nothing Else oCCOINCIDENCIAHISTORIAL_BE.PropHISROLUSUARIO = CType(oDataReader(Campos.HISROLUSUARIO), Int32)
                    If oDataReader.IsDBNull(Campos.HISFECHAHORA) Then oCCOINCIDENCIAHISTORIAL_BE.PropHISFECHAHORA = Nothing Else oCCOINCIDENCIAHISTORIAL_BE.PropHISFECHAHORA = CType(oDataReader(Campos.HISFECHAHORA), DateTime)
                    oCCOINCIDENCIAHISTORIAL_BE.PropHISEQUIPO = IIf(oDataReader.IsDBNull(Campos.HISEQUIPO), "", oDataReader(Campos.HISEQUIPO))
                    oCCOINCIDENCIAHISTORIAL_BE.PropHISPROGRAMA = IIf(oDataReader.IsDBNull(Campos.HISPROGRAMA), "", oDataReader(Campos.HISPROGRAMA))
                    oCCOINCIDENCIAHISTORIAL_BE.PropHISOPERACION = IIf(oDataReader.IsDBNull(Campos.HISOPERACION), "", oDataReader(Campos.HISOPERACION))
                    If oDataReader.IsDBNull(Campos.INRCODIGO) Then oCCOINCIDENCIAHISTORIAL_BE.PropINRCODIGO = Nothing Else oCCOINCIDENCIAHISTORIAL_BE.PropINRCODIGO = CType(oDataReader(Campos.INRCODIGO), Int32)
                    oCCOINCIDENCIAHISTORIAL_BE.PropHISCOMENTARIO = IIf(oDataReader.IsDBNull(Campos.HISCOMENTARIO), "", oDataReader(Campos.HISCOMENTARIO))
                    Exit Do
                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return oCCOINCIDENCIAHISTORIAL_BE
        End Function

        Public Function Listar(ByVal pCCOINCIDENCIAHISTORIAL_BE As CCOINCIDENCIAHISTORIAL_BE) As DataTable
            Dim dt As New DataTable
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                arrParam(0) = New DB2Parameter("P_INTINCCODIGO", DB2Type.Integer)
                arrParam(0).Value = pCCOINCIDENCIAHISTORIAL_BE.PropINCCODIGO
                dt.Load(DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "CCOINCIDENCIAHISTORIAL_LISTAR", arrParam))
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return dt
        End Function


	End Class
End Namespace
