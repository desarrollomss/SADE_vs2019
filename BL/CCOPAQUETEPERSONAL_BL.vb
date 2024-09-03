Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOPAQUETEPERSONAL_BL
		Private oCCOPAQUETEPERSONAL_DL As New DAL.CCOPAQUETEPERSONAL_DL

		Public Sub Insertar(ByVal pCCOPAQUETEPERSONAL_BE As CCOPAQUETEPERSONAL_BE)
			Try
				oCCOPAQUETEPERSONAL_DL.Insertar(pCCOPAQUETEPERSONAL_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOPAQUETEPERSONAL_BE As CCOPAQUETEPERSONAL_BE)
			Try
				oCCOPAQUETEPERSONAL_DL.Actualizar(pCCOPAQUETEPERSONAL_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOPAQUETEPERSONAL_BE As CCOPAQUETEPERSONAL_BE)
			Try
				oCCOPAQUETEPERSONAL_DL.Eliminar(pCCOPAQUETEPERSONAL_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOPAQUETEPERSONAL_BE As CCOPAQUETEPERSONAL_BE) As CCOPAQUETEPERSONAL_BE
			Try
				Return oCCOPAQUETEPERSONAL_DL.ListarKey(pCCOPAQUETEPERSONAL_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
