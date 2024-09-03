'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOTIPODOCUMENTO_BL
		Private oCCOTIPODOCUMENTO_DL As New DAL.CCOTIPODOCUMENTO_DL

		Public Sub Insertar(ByVal pCCOTIPODOCUMENTO_BE As CCOTIPODOCUMENTO_BE)
			Try
				oCCOTIPODOCUMENTO_DL.Insertar(pCCOTIPODOCUMENTO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOTIPODOCUMENTO_BE As CCOTIPODOCUMENTO_BE)
			Try
				oCCOTIPODOCUMENTO_DL.Actualizar(pCCOTIPODOCUMENTO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOTIPODOCUMENTO_BE As CCOTIPODOCUMENTO_BE)
			Try
				oCCOTIPODOCUMENTO_DL.Eliminar(pCCOTIPODOCUMENTO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOTIPODOCUMENTO_BE As CCOTIPODOCUMENTO_BE) As CCOTIPODOCUMENTO_BE
			Try
				Return oCCOTIPODOCUMENTO_DL.ListarKey(pCCOTIPODOCUMENTO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function ListarCombo() As List(Of CCOTIPODOCUMENTO_BE)
            Try
                Return oCCOTIPODOCUMENTO_DL.ListarCombo()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

	End Class
End Namespace
