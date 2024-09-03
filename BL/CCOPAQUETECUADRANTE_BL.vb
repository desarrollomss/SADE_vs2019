Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOPAQUETECUADRANTE_BL
		Private oCCOPAQUETECUADRANTE_DL As New DAL.CCOPAQUETECUADRANTE_DL

		Public Sub Insertar(ByVal pCCOPAQUETECUADRANTE_BE As CCOPAQUETECUADRANTE_BE)
			Try
				oCCOPAQUETECUADRANTE_DL.Insertar(pCCOPAQUETECUADRANTE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOPAQUETECUADRANTE_BE As CCOPAQUETECUADRANTE_BE)
			Try
				oCCOPAQUETECUADRANTE_DL.Actualizar(pCCOPAQUETECUADRANTE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOPAQUETECUADRANTE_BE As CCOPAQUETECUADRANTE_BE)
			Try
				oCCOPAQUETECUADRANTE_DL.Eliminar(pCCOPAQUETECUADRANTE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOPAQUETECUADRANTE_BE As CCOPAQUETECUADRANTE_BE) As CCOPAQUETECUADRANTE_BE
			Try
				Return oCCOPAQUETECUADRANTE_DL.ListarKey(pCCOPAQUETECUADRANTE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
