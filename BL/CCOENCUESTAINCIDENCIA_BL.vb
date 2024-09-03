'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOENCUESTAINCIDENCIA_BL
		Private oCCOENCUESTAINCIDENCIA_DL As New DAL.CCOENCUESTAINCIDENCIA_DL

		Public Sub Insertar(ByVal pCCOENCUESTAINCIDENCIA_BE As CCOENCUESTAINCIDENCIA_BE)
			Try
				oCCOENCUESTAINCIDENCIA_DL.Insertar(pCCOENCUESTAINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOENCUESTAINCIDENCIA_BE As CCOENCUESTAINCIDENCIA_BE)
			Try
				oCCOENCUESTAINCIDENCIA_DL.Actualizar(pCCOENCUESTAINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOENCUESTAINCIDENCIA_BE As CCOENCUESTAINCIDENCIA_BE)
			Try
				oCCOENCUESTAINCIDENCIA_DL.Eliminar(pCCOENCUESTAINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOENCUESTAINCIDENCIA_BE As CCOENCUESTAINCIDENCIA_BE) As CCOENCUESTAINCIDENCIA_BE
			Try
				Return oCCOENCUESTAINCIDENCIA_DL.ListarKey(pCCOENCUESTAINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
