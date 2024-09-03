'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOTIPOPAQUETERECURSO_BL
		Private oCCOTIPOPAQUETERECURSO_DL As New DAL.CCOTIPOPAQUETERECURSO_DL

		Public Sub Insertar(ByVal pCCOTIPOPAQUETERECURSO_BE As CCOTIPOPAQUETERECURSO_BE)
			Try
				oCCOTIPOPAQUETERECURSO_DL.Insertar(pCCOTIPOPAQUETERECURSO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOTIPOPAQUETERECURSO_BE As CCOTIPOPAQUETERECURSO_BE)
			Try
				oCCOTIPOPAQUETERECURSO_DL.Actualizar(pCCOTIPOPAQUETERECURSO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOTIPOPAQUETERECURSO_BE As CCOTIPOPAQUETERECURSO_BE)
			Try
				oCCOTIPOPAQUETERECURSO_DL.Eliminar(pCCOTIPOPAQUETERECURSO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOTIPOPAQUETERECURSO_BE As CCOTIPOPAQUETERECURSO_BE) As CCOTIPOPAQUETERECURSO_BE
			Try
				Return oCCOTIPOPAQUETERECURSO_DL.ListarKey(pCCOTIPOPAQUETERECURSO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
