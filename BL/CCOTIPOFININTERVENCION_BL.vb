'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOTIPOFININTERVENCION_BL
		Private oCCOTIPOFININTERVENCION_DL As New DAL.CCOTIPOFININTERVENCION_DL

		Public Sub Insertar(ByVal pCCOTIPOFININTERVENCION_BE As CCOTIPOFININTERVENCION_BE)
			Try
				oCCOTIPOFININTERVENCION_DL.Insertar(pCCOTIPOFININTERVENCION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOTIPOFININTERVENCION_BE As CCOTIPOFININTERVENCION_BE)
			Try
				oCCOTIPOFININTERVENCION_DL.Actualizar(pCCOTIPOFININTERVENCION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOTIPOFININTERVENCION_BE As CCOTIPOFININTERVENCION_BE)
			Try
				oCCOTIPOFININTERVENCION_DL.Eliminar(pCCOTIPOFININTERVENCION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOTIPOFININTERVENCION_BE As CCOTIPOFININTERVENCION_BE) As CCOTIPOFININTERVENCION_BE
			Try
				Return oCCOTIPOFININTERVENCION_DL.ListarKey(pCCOTIPOFININTERVENCION_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function


	End Class
End Namespace
