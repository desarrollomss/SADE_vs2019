'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOTIPORECURSO_BL
		Private oCCOTIPORECURSO_DL As New DAL.CCOTIPORECURSO_DL

		Public Sub Insertar(ByVal pCCOTIPORECURSO_BE As CCOTIPORECURSO_BE)
			Try
				oCCOTIPORECURSO_DL.Insertar(pCCOTIPORECURSO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOTIPORECURSO_BE As CCOTIPORECURSO_BE)
			Try
				oCCOTIPORECURSO_DL.Actualizar(pCCOTIPORECURSO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOTIPORECURSO_BE As CCOTIPORECURSO_BE)
			Try
				oCCOTIPORECURSO_DL.Eliminar(pCCOTIPORECURSO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOTIPORECURSO_BE As CCOTIPORECURSO_BE) As CCOTIPORECURSO_BE
			Try
				Return oCCOTIPORECURSO_DL.ListarKey(pCCOTIPORECURSO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function ListarCombo() As List(Of CCOTIPORECURSO_BE)
            Try
                Return oCCOTIPORECURSO_DL.ListarCombo()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

	End Class
End Namespace
