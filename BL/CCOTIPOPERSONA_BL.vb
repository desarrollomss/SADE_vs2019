'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOTIPOPERSONA_BL
		Private oCCOTIPOPERSONA_DL As New DAL.CCOTIPOPERSONA_DL

		Public Sub Insertar(ByVal pCCOTIPOPERSONA_BE As CCOTIPOPERSONA_BE)
			Try
				oCCOTIPOPERSONA_DL.Insertar(pCCOTIPOPERSONA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOTIPOPERSONA_BE As CCOTIPOPERSONA_BE)
			Try
				oCCOTIPOPERSONA_DL.Actualizar(pCCOTIPOPERSONA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOTIPOPERSONA_BE As CCOTIPOPERSONA_BE)
			Try
				oCCOTIPOPERSONA_DL.Eliminar(pCCOTIPOPERSONA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOTIPOPERSONA_BE As CCOTIPOPERSONA_BE) As CCOTIPOPERSONA_BE
			Try
				Return oCCOTIPOPERSONA_DL.ListarKey(pCCOTIPOPERSONA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function ListarCombo() As List(Of CCOTIPOPERSONA_BE)
            Try
                Return oCCOTIPOPERSONA_DL.ListarCombo()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function


	End Class
End Namespace
