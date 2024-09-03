Imports IBM.Data.DB2
Imports SISSADE.AccesoDatos
Imports SISSADE.BE

Namespace DAL

	Public Class GPSPOSITION_DL
		Private cnDB2 As DB2Connection

		#Region "Numerador"
		Public Enum Campos
			NISSI = 0
			LATITUDE = 1
			LONGITUDE = 2
			DATETIME = 3
			DATETIME2 = 4
			STATUS = 5
			USER = 6
			UNITTYPE = 7
			DESCRIPTION = 8
			PRECISION = 9
			TRIGGER = 10
			VELOCIDAD_HOR = 11
			DIRECCION = 12
			UNITSEC = 13
		End Enum
		#End Region

		Public Sub New()
			cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
		End Sub

		Public Sub Insertar(ByVal pGPSPOSITION_BE As GPSPOSITION_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(13) {}
				arrParam(0) = New DB2Parameter("P_INTNISSI", DB2Type.INTEGER)
				arrParam(0).Value = pGPSPOSITION_BE.PropNISSI
				arrParam(1) = New DB2Parameter("P_DECLATITUDE", DB2Type.DECIMAL)
				arrParam(1).Value = pGPSPOSITION_BE.PropLATITUDE
				arrParam(2) = New DB2Parameter("P_DECLONGITUDE", DB2Type.DECIMAL)
				arrParam(2).Value = pGPSPOSITION_BE.PropLONGITUDE
				arrParam(3) = New DB2Parameter("P_TMSDATETIME", DB2Type.TIMESTAMP)
				arrParam(3).Value = pGPSPOSITION_BE.PropDATETIME
				arrParam(4) = New DB2Parameter("P_TMSDATETIME2", DB2Type.TIMESTAMP)
				arrParam(4).Value = pGPSPOSITION_BE.PropDATETIME2
				arrParam(5) = New DB2Parameter("P_SMLSTATUS", DB2Type.SMALLINT)
				arrParam(5).Value = pGPSPOSITION_BE.PropSTATUS
				arrParam(6) = New DB2Parameter("P_VCHUSER", DB2Type.VARCHAR, 30)
				arrParam(6).Value = pGPSPOSITION_BE.PropUSER
				arrParam(7) = New DB2Parameter("P_SMLUNITTYPE", DB2Type.SMALLINT)
				arrParam(7).Value = pGPSPOSITION_BE.PropUNITTYPE
				arrParam(8) = New DB2Parameter("P_VCHDESCRIPTION", DB2Type.VARCHAR, 20)
				arrParam(8).Value = pGPSPOSITION_BE.PropDESCRIPTION
				arrParam(9) = New DB2Parameter("P_INTPRECISION", DB2Type.INTEGER)
				arrParam(9).Value = pGPSPOSITION_BE.PropPRECISION
				arrParam(10) = New DB2Parameter("P_VCHTRIGGER", DB2Type.VARCHAR, 12)
				arrParam(10).Value = pGPSPOSITION_BE.PropTRIGGER
				arrParam(11) = New DB2Parameter("P_VCHVELOCIDAD_HOR", DB2Type.VARCHAR, 10)
				arrParam(11).Value = pGPSPOSITION_BE.PropVELOCIDAD_HOR
				arrParam(12) = New DB2Parameter("P_VCHDIRECCION", DB2Type.VARCHAR, 10)
				arrParam(12).Value = pGPSPOSITION_BE.PropDIRECCION
				arrParam(13) = New DB2Parameter("P_SMLUNITSEC", DB2Type.SMALLINT)
				arrParam(13).Value = pGPSPOSITION_BE.PropUNITSEC
				DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, ".GPSPOSITION_INSERTAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Sub Actualizar(ByVal pGPSPOSITION_BE As GPSPOSITION_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(13) {}
				arrParam(0) = New DB2Parameter("P_INTNISSI", DB2Type.INTEGER)
				arrParam(0).Value = pGPSPOSITION_BE.PropNISSI
				arrParam(1) = New DB2Parameter("P_DECLATITUDE", DB2Type.DECIMAL)
				arrParam(1).Value = pGPSPOSITION_BE.PropLATITUDE
				arrParam(2) = New DB2Parameter("P_DECLONGITUDE", DB2Type.DECIMAL)
				arrParam(2).Value = pGPSPOSITION_BE.PropLONGITUDE
				arrParam(3) = New DB2Parameter("P_TMSDATETIME", DB2Type.TIMESTAMP)
				arrParam(3).Value = pGPSPOSITION_BE.PropDATETIME
				arrParam(4) = New DB2Parameter("P_TMSDATETIME2", DB2Type.TIMESTAMP)
				arrParam(4).Value = pGPSPOSITION_BE.PropDATETIME2
				arrParam(5) = New DB2Parameter("P_SMLSTATUS", DB2Type.SMALLINT)
				arrParam(5).Value = pGPSPOSITION_BE.PropSTATUS
				arrParam(6) = New DB2Parameter("P_VCHUSER", DB2Type.VARCHAR, 30)
				arrParam(6).Value = pGPSPOSITION_BE.PropUSER
				arrParam(7) = New DB2Parameter("P_SMLUNITTYPE", DB2Type.SMALLINT)
				arrParam(7).Value = pGPSPOSITION_BE.PropUNITTYPE
				arrParam(8) = New DB2Parameter("P_VCHDESCRIPTION", DB2Type.VARCHAR, 20)
				arrParam(8).Value = pGPSPOSITION_BE.PropDESCRIPTION
				arrParam(9) = New DB2Parameter("P_INTPRECISION", DB2Type.INTEGER)
				arrParam(9).Value = pGPSPOSITION_BE.PropPRECISION
				arrParam(10) = New DB2Parameter("P_VCHTRIGGER", DB2Type.VARCHAR, 12)
				arrParam(10).Value = pGPSPOSITION_BE.PropTRIGGER
				arrParam(11) = New DB2Parameter("P_VCHVELOCIDAD_HOR", DB2Type.VARCHAR, 10)
				arrParam(11).Value = pGPSPOSITION_BE.PropVELOCIDAD_HOR
				arrParam(12) = New DB2Parameter("P_VCHDIRECCION", DB2Type.VARCHAR, 10)
				arrParam(12).Value = pGPSPOSITION_BE.PropDIRECCION
				arrParam(13) = New DB2Parameter("P_SMLUNITSEC", DB2Type.SMALLINT)
				arrParam(13).Value = pGPSPOSITION_BE.PropUNITSEC
				DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, ".GPSPOSITION_ACTUALIZAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Sub Eliminar(ByVal pGPSPOSITION_BE As GPSPOSITION_BE)
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
				arrParam(0) = New DB2Parameter("P_INTNISSI", DB2Type.INTEGER)
				arrParam(0).Value = pGPSPOSITION_BE.PropNISSI
				DB2helper.ExecuteNonQuery(cnDB2, CommandType.StoredProcedure, ".GPSPOSITION_ELIMINAR", arrParam)
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
		End Sub

		Public Function ListarKey(ByVal pGPSPOSITION_BE As GPSPOSITION_BE) As GPSPOSITION_BE
			Dim oGPSPOSITION_BE As New GPSPOSITION_BE
			Try
				Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
				arrParam(0) = New DB2Parameter("P_INTNISSI", DB2Type.INTEGER)
				arrParam(0).Value = pGPSPOSITION_BE.PropNISSI
				Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, ".GPSPOSITION_LISTARKEY", arrParam)
				Do While oDataReader.Read()
					If oDataReader.IsDBNull(Campos.NISSI) Then oGPSPOSITION_BE.PropNISSI = Nothing Else oGPSPOSITION_BE.PropNISSI = CType(oDataReader(Campos.NISSI), Int32)
					If oDataReader.IsDBNull(Campos.LATITUDE) Then oGPSPOSITION_BE.PropLATITUDE = Nothing Else oGPSPOSITION_BE.PropLATITUDE = CType(oDataReader(Campos.LATITUDE), Decimal)
					If oDataReader.IsDBNull(Campos.LONGITUDE) Then oGPSPOSITION_BE.PropLONGITUDE = Nothing Else oGPSPOSITION_BE.PropLONGITUDE = CType(oDataReader(Campos.LONGITUDE), Decimal)
					If oDataReader.IsDBNull(Campos.DATETIME) Then oGPSPOSITION_BE.PropDATETIME = Nothing Else oGPSPOSITION_BE.PropDATETIME = CType(oDataReader(Campos.DATETIME), DateTime)
					If oDataReader.IsDBNull(Campos.DATETIME2) Then oGPSPOSITION_BE.PropDATETIME2 = Nothing Else oGPSPOSITION_BE.PropDATETIME2 = CType(oDataReader(Campos.DATETIME2), DateTime)
					If oDataReader.IsDBNull(Campos.STATUS) Then oGPSPOSITION_BE.PropSTATUS = Nothing Else oGPSPOSITION_BE.PropSTATUS = CType(oDataReader(Campos.STATUS), Int16)
					oGPSPOSITION_BE.PropUSER = IIf(oDataReader.IsDBNull(Campos.USER), "", oDataReader(Campos.USER))
					If oDataReader.IsDBNull(Campos.UNITTYPE) Then oGPSPOSITION_BE.PropUNITTYPE = Nothing Else oGPSPOSITION_BE.PropUNITTYPE = CType(oDataReader(Campos.UNITTYPE), Int16)
					oGPSPOSITION_BE.PropDESCRIPTION = IIf(oDataReader.IsDBNull(Campos.DESCRIPTION), "", oDataReader(Campos.DESCRIPTION))
					If oDataReader.IsDBNull(Campos.PRECISION) Then oGPSPOSITION_BE.PropPRECISION = Nothing Else oGPSPOSITION_BE.PropPRECISION = CType(oDataReader(Campos.PRECISION), Int32)
					oGPSPOSITION_BE.PropTRIGGER = IIf(oDataReader.IsDBNull(Campos.TRIGGER), "", oDataReader(Campos.TRIGGER))
					oGPSPOSITION_BE.PropVELOCIDAD_HOR = IIf(oDataReader.IsDBNull(Campos.VELOCIDAD_HOR), "", oDataReader(Campos.VELOCIDAD_HOR))
					oGPSPOSITION_BE.PropDIRECCION = IIf(oDataReader.IsDBNull(Campos.DIRECCION), "", oDataReader(Campos.DIRECCION))
					If oDataReader.IsDBNull(Campos.UNITSEC) Then oGPSPOSITION_BE.PropUNITSEC = Nothing Else oGPSPOSITION_BE.PropUNITSEC = CType(oDataReader(Campos.UNITSEC), Int16)
					Exit Do
				Loop
			Catch ex As Exception
				Throw ex
			Finally
				If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
			End Try
			Return oGPSPOSITION_BE
		End Function


        Public Function ListarGPS() As List(Of GPSPOSITION_BE)

            Dim Items As New List(Of GPSPOSITION_BE)
            Try
                Dim arrParam() As DB2Parameter = New DB2Parameter(0) {}
                Dim oDataReader As IDataReader = DB2helper.ExecuteReader(cnDB2, CommandType.StoredProcedure, "GPSPOSITION_LISTAR", arrParam)
                Do While oDataReader.Read()
                    Dim oGPSPOSITION_BE As New GPSPOSITION_BE
                    If oDataReader.IsDBNull(Campos.NISSI) Then oGPSPOSITION_BE.PropNISSI = Nothing Else oGPSPOSITION_BE.PropNISSI = CType(oDataReader(Campos.NISSI), Int32)
                    If oDataReader.IsDBNull(Campos.LATITUDE) Then oGPSPOSITION_BE.PropLATITUDE = Nothing Else oGPSPOSITION_BE.PropLATITUDE = CType(oDataReader(Campos.LATITUDE), Decimal)
                    If oDataReader.IsDBNull(Campos.LONGITUDE) Then oGPSPOSITION_BE.PropLONGITUDE = Nothing Else oGPSPOSITION_BE.PropLONGITUDE = CType(oDataReader(Campos.LONGITUDE), Decimal)
                    If oDataReader.IsDBNull(Campos.DATETIME) Then oGPSPOSITION_BE.PropDATETIME = Nothing Else oGPSPOSITION_BE.PropDATETIME = CType(oDataReader(Campos.DATETIME), DateTime)
                    If oDataReader.IsDBNull(Campos.DATETIME2) Then oGPSPOSITION_BE.PropDATETIME2 = Nothing Else oGPSPOSITION_BE.PropDATETIME2 = CType(oDataReader(Campos.DATETIME2), DateTime)
                    If oDataReader.IsDBNull(Campos.STATUS) Then oGPSPOSITION_BE.PropSTATUS = Nothing Else oGPSPOSITION_BE.PropSTATUS = CType(oDataReader(Campos.STATUS), Int16)
                    oGPSPOSITION_BE.PropUSER = IIf(oDataReader.IsDBNull(Campos.USER), "", oDataReader(Campos.USER))
                    If oDataReader.IsDBNull(Campos.UNITTYPE) Then oGPSPOSITION_BE.PropUNITTYPE = Nothing Else oGPSPOSITION_BE.PropUNITTYPE = CType(oDataReader(Campos.UNITTYPE), Int16)
                    oGPSPOSITION_BE.PropDESCRIPTION = IIf(oDataReader.IsDBNull(Campos.DESCRIPTION), "", oDataReader(Campos.DESCRIPTION))
                    If oDataReader.IsDBNull(Campos.PRECISION) Then oGPSPOSITION_BE.PropPRECISION = Nothing Else oGPSPOSITION_BE.PropPRECISION = CType(oDataReader(Campos.PRECISION), Int32)
                    oGPSPOSITION_BE.PropTRIGGER = IIf(oDataReader.IsDBNull(Campos.TRIGGER), "", oDataReader(Campos.TRIGGER))
                    oGPSPOSITION_BE.PropVELOCIDAD_HOR = IIf(oDataReader.IsDBNull(Campos.VELOCIDAD_HOR), "", oDataReader(Campos.VELOCIDAD_HOR))
                    oGPSPOSITION_BE.PropDIRECCION = IIf(oDataReader.IsDBNull(Campos.DIRECCION), "", oDataReader(Campos.DIRECCION))
                    If oDataReader.IsDBNull(Campos.UNITSEC) Then oGPSPOSITION_BE.PropUNITSEC = Nothing Else oGPSPOSITION_BE.PropUNITSEC = CType(oDataReader(Campos.UNITSEC), Int16)
                    'Exit Do
                    '-- INSERTAMOS ELEMENTOS A LA LISTA
                    Items.Add(oGPSPOSITION_BE)

                Loop
            Catch ex As Exception
                Throw ex
            Finally
                If cnDB2.State = ConnectionState.Open Then cnDB2.Close()
            End Try
            Return Items
        End Function

	End Class
End Namespace
