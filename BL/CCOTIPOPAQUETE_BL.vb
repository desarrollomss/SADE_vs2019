'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOTIPOPAQUETE_BL
		Private oCCOTIPOPAQUETE_DL As New DAL.CCOTIPOPAQUETE_DL

		Public Sub Insertar(ByVal pCCOTIPOPAQUETE_BE As CCOTIPOPAQUETE_BE)
			Try
				oCCOTIPOPAQUETE_DL.Insertar(pCCOTIPOPAQUETE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOTIPOPAQUETE_BE As CCOTIPOPAQUETE_BE)
			Try
				oCCOTIPOPAQUETE_DL.Actualizar(pCCOTIPOPAQUETE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOTIPOPAQUETE_BE As CCOTIPOPAQUETE_BE)
			Try
				oCCOTIPOPAQUETE_DL.Eliminar(pCCOTIPOPAQUETE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOTIPOPAQUETE_BE As CCOTIPOPAQUETE_BE) As CCOTIPOPAQUETE_BE
			Try
				Return oCCOTIPOPAQUETE_DL.ListarKey(pCCOTIPOPAQUETE_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
