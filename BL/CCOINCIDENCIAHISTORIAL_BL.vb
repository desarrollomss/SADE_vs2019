Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOINCIDENCIAHISTORIAL_BL
		Private oCCOINCIDENCIAHISTORIAL_DL As New DAL.CCOINCIDENCIAHISTORIAL_DL

		Public Sub Insertar(ByVal pCCOINCIDENCIAHISTORIAL_BE As CCOINCIDENCIAHISTORIAL_BE)
			Try
				oCCOINCIDENCIAHISTORIAL_DL.Insertar(pCCOINCIDENCIAHISTORIAL_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOINCIDENCIAHISTORIAL_BE As CCOINCIDENCIAHISTORIAL_BE)
			Try
				oCCOINCIDENCIAHISTORIAL_DL.Actualizar(pCCOINCIDENCIAHISTORIAL_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOINCIDENCIAHISTORIAL_BE As CCOINCIDENCIAHISTORIAL_BE)
			Try
				oCCOINCIDENCIAHISTORIAL_DL.Eliminar(pCCOINCIDENCIAHISTORIAL_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOINCIDENCIAHISTORIAL_BE As CCOINCIDENCIAHISTORIAL_BE) As CCOINCIDENCIAHISTORIAL_BE
			Try
				Return oCCOINCIDENCIAHISTORIAL_DL.ListarKey(pCCOINCIDENCIAHISTORIAL_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function Listar(ByVal pCCOINCIDENCIAHISTORIAL_BE As CCOINCIDENCIAHISTORIAL_BE) As DataTable
            Try
                Return oCCOINCIDENCIAHISTORIAL_DL.Listar(pCCOINCIDENCIAHISTORIAL_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

	End Class
End Namespace
