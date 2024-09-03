'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOPREGUNTAINCIDENCIA_BL
		Private oCCOPREGUNTAINCIDENCIA_DL As New DAL.CCOPREGUNTAINCIDENCIA_DL

		Public Sub Insertar(ByVal pCCOPREGUNTAINCIDENCIA_BE As CCOPREGUNTAINCIDENCIA_BE)
			Try
				oCCOPREGUNTAINCIDENCIA_DL.Insertar(pCCOPREGUNTAINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOPREGUNTAINCIDENCIA_BE As CCOPREGUNTAINCIDENCIA_BE)
			Try
				oCCOPREGUNTAINCIDENCIA_DL.Actualizar(pCCOPREGUNTAINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOPREGUNTAINCIDENCIA_BE As CCOPREGUNTAINCIDENCIA_BE)
			Try
				oCCOPREGUNTAINCIDENCIA_DL.Eliminar(pCCOPREGUNTAINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOPREGUNTAINCIDENCIA_BE As CCOPREGUNTAINCIDENCIA_BE) As CCOPREGUNTAINCIDENCIA_BE
			Try
				Return oCCOPREGUNTAINCIDENCIA_DL.ListarKey(pCCOPREGUNTAINCIDENCIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function ListarGrilla(ByVal pCCOPREGUNTAINCIDENCIA_BE As CCOPREGUNTAINCIDENCIA_BE, ByVal pINTINCCODIGO As Integer) As DataTable
            Try
                Return oCCOPREGUNTAINCIDENCIA_DL.ListarGrilla(pCCOPREGUNTAINCIDENCIA_BE, pINTINCCODIGO)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

	End Class
End Namespace
