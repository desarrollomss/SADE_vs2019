'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOCUADRANTESECTOR_BL
		Private oCCOCUADRANTESECTOR_DL As New DAL.CCOCUADRANTESECTOR_DL

		Public Sub Insertar(ByVal pCCOCUADRANTESECTOR_BE As CCOCUADRANTESECTOR_BE)
			Try
				oCCOCUADRANTESECTOR_DL.Insertar(pCCOCUADRANTESECTOR_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOCUADRANTESECTOR_BE As CCOCUADRANTESECTOR_BE)
			Try
				oCCOCUADRANTESECTOR_DL.Actualizar(pCCOCUADRANTESECTOR_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOCUADRANTESECTOR_BE As CCOCUADRANTESECTOR_BE)
			Try
				oCCOCUADRANTESECTOR_DL.Eliminar(pCCOCUADRANTESECTOR_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOCUADRANTESECTOR_BE As CCOCUADRANTESECTOR_BE) As CCOCUADRANTESECTOR_BE
			Try
				Return oCCOCUADRANTESECTOR_DL.ListarKey(pCCOCUADRANTESECTOR_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
