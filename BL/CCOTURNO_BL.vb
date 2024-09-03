Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOTURNO_BL
		Private oCCOTURNO_DL As New DAL.CCOTURNO_DL

		Public Sub Insertar(ByVal pCCOTURNO_BE As CCOTURNO_BE)
			Try
				oCCOTURNO_DL.Insertar(pCCOTURNO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOTURNO_BE As CCOTURNO_BE)
			Try
				oCCOTURNO_DL.Actualizar(pCCOTURNO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOTURNO_BE As CCOTURNO_BE)
			Try
				oCCOTURNO_DL.Eliminar(pCCOTURNO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOTURNO_BE As CCOTURNO_BE) As CCOTURNO_BE
			Try
				Return oCCOTURNO_DL.ListarKey(pCCOTURNO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
