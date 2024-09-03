'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOMODALIDADFUGAINCIDENCIA_BL
		Private oCCOMODALIDADFUGAINCIDENCIA_DL As New DAL.CCOMODALIDADFUGAINCIDENCIA_DL

		Public Sub Insertar(ByVal pCCOMODALIDADFUGAINCIDENCIA_BE As CCOMODALIDADFUGAINCIDENCIA_BE)
			Try
				oCCOMODALIDADFUGAINCIDENCIA_DL.Insertar(pCCOMODALIDADFUGAINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOMODALIDADFUGAINCIDENCIA_BE As CCOMODALIDADFUGAINCIDENCIA_BE)
			Try
				oCCOMODALIDADFUGAINCIDENCIA_DL.Actualizar(pCCOMODALIDADFUGAINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOMODALIDADFUGAINCIDENCIA_BE As CCOMODALIDADFUGAINCIDENCIA_BE)
			Try
				oCCOMODALIDADFUGAINCIDENCIA_DL.Eliminar(pCCOMODALIDADFUGAINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOMODALIDADFUGAINCIDENCIA_BE As CCOMODALIDADFUGAINCIDENCIA_BE) As CCOMODALIDADFUGAINCIDENCIA_BE
			Try
				Return oCCOMODALIDADFUGAINCIDENCIA_DL.ListarKey(pCCOMODALIDADFUGAINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function ListaCombo() As DataTable
            Try
                Return oCCOMODALIDADFUGAINCIDENCIA_DL.ListarCombo()
            Catch ex As Exception
                Throw ex
            End Try
        End Function


	End Class
End Namespace
