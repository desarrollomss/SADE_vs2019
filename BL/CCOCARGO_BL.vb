'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOCARGO_BL
		Private oCCOCARGO_DL As New DAL.CCOCARGO_DL

		Public Sub Insertar(ByVal pCCOCARGO_BE As CCOCARGO_BE)
			Try
				oCCOCARGO_DL.Insertar(pCCOCARGO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOCARGO_BE As CCOCARGO_BE)
			Try
				oCCOCARGO_DL.Actualizar(pCCOCARGO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOCARGO_BE As CCOCARGO_BE)
			Try
				oCCOCARGO_DL.Eliminar(pCCOCARGO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOCARGO_BE As CCOCARGO_BE) As CCOCARGO_BE
			Try
				Return oCCOCARGO_DL.ListarKey(pCCOCARGO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
