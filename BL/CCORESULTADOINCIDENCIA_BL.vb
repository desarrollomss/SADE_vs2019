'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCORESULTADOINCIDENCIA_BL
		Private oCCORESULTADOINCIDENCIA_DL As New DAL.CCORESULTADOINCIDENCIA_DL

		Public Sub Insertar(ByVal pCCORESULTADOINCIDENCIA_BE As CCORESULTADOINCIDENCIA_BE)
			Try
				oCCORESULTADOINCIDENCIA_DL.Insertar(pCCORESULTADOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCORESULTADOINCIDENCIA_BE As CCORESULTADOINCIDENCIA_BE)
			Try
				oCCORESULTADOINCIDENCIA_DL.Actualizar(pCCORESULTADOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCORESULTADOINCIDENCIA_BE As CCORESULTADOINCIDENCIA_BE)
			Try
				oCCORESULTADOINCIDENCIA_DL.Eliminar(pCCORESULTADOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCORESULTADOINCIDENCIA_BE As CCORESULTADOINCIDENCIA_BE) As CCORESULTADOINCIDENCIA_BE
			Try
				Return oCCORESULTADOINCIDENCIA_DL.ListarKey(pCCORESULTADOINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
