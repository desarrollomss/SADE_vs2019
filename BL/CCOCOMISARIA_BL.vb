'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOCOMISARIA_BL
		Private oCCOCOMISARIA_DL As New DAL.CCOCOMISARIA_DL

		Public Sub Insertar(ByVal pCCOCOMISARIA_BE As CCOCOMISARIA_BE)
			Try
				oCCOCOMISARIA_DL.Insertar(pCCOCOMISARIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOCOMISARIA_BE As CCOCOMISARIA_BE)
			Try
				oCCOCOMISARIA_DL.Actualizar(pCCOCOMISARIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOCOMISARIA_BE As CCOCOMISARIA_BE)
			Try
				oCCOCOMISARIA_DL.Eliminar(pCCOCOMISARIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOCOMISARIA_BE As CCOCOMISARIA_BE) As CCOCOMISARIA_BE
			Try
				Return oCCOCOMISARIA_DL.ListarKey(pCCOCOMISARIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
