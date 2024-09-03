'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOPARTEDIARIO_BL
		Private oCCOPARTEDIARIO_DL As New DAL.CCOPARTEDIARIO_DL

		Public Sub Insertar(ByVal pCCOPARTEDIARIO_BE As CCOPARTEDIARIO_BE)
			Try
				oCCOPARTEDIARIO_DL.Insertar(pCCOPARTEDIARIO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOPARTEDIARIO_BE As CCOPARTEDIARIO_BE)
			Try
				oCCOPARTEDIARIO_DL.Actualizar(pCCOPARTEDIARIO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOPARTEDIARIO_BE As CCOPARTEDIARIO_BE)
			Try
				oCCOPARTEDIARIO_DL.Eliminar(pCCOPARTEDIARIO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOPARTEDIARIO_BE As CCOPARTEDIARIO_BE) As CCOPARTEDIARIO_BE
			Try
				Return oCCOPARTEDIARIO_DL.ListarKey(pCCOPARTEDIARIO_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Sub Actualizar_SQL_DB2(ByVal pCCOPARTEDIARIO_BE As CCOPARTEDIARIO_BE)
            Try
                oCCOPARTEDIARIO_DL.Actualizar_SQL_DB2(pCCOPARTEDIARIO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub


	End Class
End Namespace
