Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOSECUENCIASERVICIO_BL
		Private oCCOSECUENCIASERVICIO_DL As New DAL.CCOSECUENCIASERVICIO_DL

		Public Sub Insertar(ByVal pCCOSECUENCIASERVICIO_BE As CCOSECUENCIASERVICIO_BE)
			Try
				oCCOSECUENCIASERVICIO_DL.Insertar(pCCOSECUENCIASERVICIO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOSECUENCIASERVICIO_BE As CCOSECUENCIASERVICIO_BE)
			Try
				oCCOSECUENCIASERVICIO_DL.Actualizar(pCCOSECUENCIASERVICIO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOSECUENCIASERVICIO_BE As CCOSECUENCIASERVICIO_BE)
			Try
				oCCOSECUENCIASERVICIO_DL.Eliminar(pCCOSECUENCIASERVICIO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOSECUENCIASERVICIO_BE As CCOSECUENCIASERVICIO_BE) As CCOSECUENCIASERVICIO_BE
			Try
				Return oCCOSECUENCIASERVICIO_DL.ListarKey(pCCOSECUENCIASERVICIO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function
        Public Function Listar(ByVal pCCOSECUENCIASERVICIO_BE As CCOSECUENCIASERVICIO_BE) As DataTable
            Try
                Return oCCOSECUENCIASERVICIO_DL.Listar(pCCOSECUENCIASERVICIO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

    End Class
End Namespace
