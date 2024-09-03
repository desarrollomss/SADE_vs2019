'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOTIPOTURNO_BL
		Private oCCOTIPOTURNO_DL As New DAL.CCOTIPOTURNO_DL

		Public Sub Insertar(ByVal pCCOTIPOTURNO_BE As CCOTIPOTURNO_BE)
			Try
				oCCOTIPOTURNO_DL.Insertar(pCCOTIPOTURNO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOTIPOTURNO_BE As CCOTIPOTURNO_BE)
			Try
				oCCOTIPOTURNO_DL.Actualizar(pCCOTIPOTURNO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOTIPOTURNO_BE As CCOTIPOTURNO_BE)
			Try
				oCCOTIPOTURNO_DL.Eliminar(pCCOTIPOTURNO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOTIPOTURNO_BE As CCOTIPOTURNO_BE) As CCOTIPOTURNO_BE
			Try
				Return oCCOTIPOTURNO_DL.ListarKey(pCCOTIPOTURNO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
