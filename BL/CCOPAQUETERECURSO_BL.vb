'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOPAQUETERECURSO_BL
		Private oCCOPAQUETERECURSO_DL As New DAL.CCOPAQUETERECURSO_DL

		Public Sub Insertar(ByVal pCCOPAQUETERECURSO_BE As CCOPAQUETERECURSO_BE)
			Try
				oCCOPAQUETERECURSO_DL.Insertar(pCCOPAQUETERECURSO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOPAQUETERECURSO_BE As CCOPAQUETERECURSO_BE)
			Try
				oCCOPAQUETERECURSO_DL.Actualizar(pCCOPAQUETERECURSO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOPAQUETERECURSO_BE As CCOPAQUETERECURSO_BE)
			Try
				oCCOPAQUETERECURSO_DL.Eliminar(pCCOPAQUETERECURSO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOPAQUETERECURSO_BE As CCOPAQUETERECURSO_BE) As CCOPAQUETERECURSO_BE
			Try
				Return oCCOPAQUETERECURSO_DL.ListarKey(pCCOPAQUETERECURSO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
