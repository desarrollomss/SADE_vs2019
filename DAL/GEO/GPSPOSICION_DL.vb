Imports System.Configuration
Imports System
Imports AccesoDatosGEO
Imports SISSADE.BE
Imports Npgsql


Namespace DAL

    Public Class GPSPOSICION_DL
        Private cnPsg As NpgsqlConnection

#Region "Numerador"
        Public Enum Campos
            INTPOSID = 0
            INTISSI = 1
            DECPOSLON = 2
            DECPOSLAT = 3
            DATPOSFREG = 4
            VCHESTCOD = 8
            VCHPOSCODHU = 10
            VCHPOSDENHU = 11
            VCHPOSCODVIA = 12
            VCHPOSNOMVIA = 13
            VCHPOSCDAVIA = 14
            VCHPOSXGEO = 15
            VCHPOSYGEO = 16
            VCHPOSCDTE = 17
            VCHPOSSECTOR = 18
            VCHESTDESC = 19
            VCHESTRAD = 20
            VCHESTNIMG = 21
            VCHESTCWEB = 22
            INTRECCODIGO = 23
            VCHRECDESCRIPCION = 24
            SMLTRECODIGO = 25
            VCHTREDESCRIPCION = 26
            SMLSECCODIGO = 27
            VCHSECCODIGO = 28
        End Enum
#End Region

        'Public Sub New()
        '    cnDB2 = New DB2Connection(DB2_Conexion.f_ConeccionDB2)
        'End Sub

        Public Function Insertar(ByVal pGPSPOSICION_BE As GPSPOSICION_BE) As Integer
            Try
                Dim MiCnx As ConnectionStringSettings = Nothing
                MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
                Dim cadena As String = MiCnx.ConnectionString
                Dim strSQL As String = ""

                'Dim arrParam() As NpgsqlParameter = New NpgsqlParameter(6) {}
                'arrParam(0) = New NpgsqlParameter("p_intposid", NpgsqlTypes.NpgsqlDbType.Bigint)
                'arrParam(0).Direction = ParameterDirection.Output
                'arrParam(1) = New NpgsqlParameter("p_intissi", NpgsqlTypes.NpgsqlDbType.Varchar, 15)
                'arrParam(1).Value = pGPSPOSICION_BE.INTISSI
                'arrParam(2) = New NpgsqlParameter("p_datposfreg", NpgsqlTypes.NpgsqlDbType.Varchar, 20)
                'arrParam(2).Value = pGPSPOSICION_BE.DATPOSFREG
                'arrParam(3) = New NpgsqlParameter("p_decposlat", NpgsqlTypes.NpgsqlDbType.Varchar, 20)
                'arrParam(3).Value = pGPSPOSICION_BE.DECPOSLAT
                'arrParam(4) = New NpgsqlParameter("p_decposlon", NpgsqlTypes.NpgsqlDbType.Varchar, 20)
                'arrParam(4).Value = pGPSPOSICION_BE.DECPOSLON
                'arrParam(5) = New NpgsqlParameter("p_vchcodunidad", NpgsqlTypes.NpgsqlDbType.Varchar, 15)
                'arrParam(5).Value = pGPSPOSICION_BE.VCHCODUNIDAD
                'arrParam(6) = New NpgsqlParameter("p_intinccodigo", NpgsqlTypes.NpgsqlDbType.Varchar, 15)
                'arrParam(6).Value = pGPSPOSICION_BE.INTINCCODIGO
                'NpgsqlHelper.ExecuteDataset(cadena, CommandType.StoredProcedure, "spu_gps_posicion_insertar", arrParam)
                'Return arrParam(0).Value

                strSQL = " INSERT INTO sade.gps_posicion(intissi, decposlon, decposlat, datposfreg, vchcodunidad, intinccodigo) "
                strSQL &= " VALUES ("
                strSQL &= " '" & pGPSPOSICION_BE.INTISSI & "', "
                strSQL &= " '" & pGPSPOSICION_BE.DECPOSLAT & "', "
                strSQL &= " '" & pGPSPOSICION_BE.DECPOSLON & "', "
                strSQL &= " '" & pGPSPOSICION_BE.DATPOSFREG & "', "
                strSQL &= " '" & pGPSPOSICION_BE.VCHCODUNIDAD & "', "
                strSQL &= " '" & pGPSPOSICION_BE.INTINCCODIGO & "' "
                strSQL &= " ); "

                Return NpgsqlHelper.ExecuteNonQuery(cadena, CommandType.Text, strSQL)

            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

    End Class

End Namespace
