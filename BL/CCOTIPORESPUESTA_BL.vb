'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOTIPORESPUESTA_BL
		Private oCCOTIPORESPUESTA_DL As New DAL.CCOTIPORESPUESTA_DL

		Public Sub Insertar(ByVal pCCOTIPORESPUESTA_BE As CCOTIPORESPUESTA_BE)
			Try
				oCCOTIPORESPUESTA_DL.Insertar(pCCOTIPORESPUESTA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOTIPORESPUESTA_BE As CCOTIPORESPUESTA_BE)
			Try
				oCCOTIPORESPUESTA_DL.Actualizar(pCCOTIPORESPUESTA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOTIPORESPUESTA_BE As CCOTIPORESPUESTA_BE)
			Try
				oCCOTIPORESPUESTA_DL.Eliminar(pCCOTIPORESPUESTA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOTIPORESPUESTA_BE As CCOTIPORESPUESTA_BE) As CCOTIPORESPUESTA_BE
			Try
				Return oCCOTIPORESPUESTA_DL.ListarKey(pCCOTIPORESPUESTA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
