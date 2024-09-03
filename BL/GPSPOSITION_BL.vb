Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class GPSPOSITION_BL
		Private oGPSPOSITION_DL As New DAL.GPSPOSITION_DL

		Public Sub Insertar(ByVal pGPSPOSITION_BE As GPSPOSITION_BE)
			Try
				oGPSPOSITION_DL.Insertar(pGPSPOSITION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pGPSPOSITION_BE As GPSPOSITION_BE)
			Try
				oGPSPOSITION_DL.Actualizar(pGPSPOSITION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pGPSPOSITION_BE As GPSPOSITION_BE)
			Try
				oGPSPOSITION_DL.Eliminar(pGPSPOSITION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pGPSPOSITION_BE As GPSPOSITION_BE) As GPSPOSITION_BE
			Try
				Return oGPSPOSITION_DL.ListarKey(pGPSPOSITION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function ListarGPS() As List(Of GPSPOSITION_BE)
            Try
                Return oGPSPOSITION_DL.ListarGPS
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

	End Class
End Namespace
