'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOSECTOR_BL
		Private oCCOSECTOR_DL As New DAL.CCOSECTOR_DL

		Public Sub Insertar(ByVal pCCOSECTOR_BE As CCOSECTOR_BE)
			Try
				oCCOSECTOR_DL.Insertar(pCCOSECTOR_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOSECTOR_BE As CCOSECTOR_BE)
			Try
				oCCOSECTOR_DL.Actualizar(pCCOSECTOR_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOSECTOR_BE As CCOSECTOR_BE)
			Try
				oCCOSECTOR_DL.Eliminar(pCCOSECTOR_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOSECTOR_BE As CCOSECTOR_BE) As CCOSECTOR_BE
			Try
				Return oCCOSECTOR_DL.ListarKey(pCCOSECTOR_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function ListarCombo() As List(Of CCOSECTOR_BE)
            Try
                Return oCCOSECTOR_DL.ListarCombo()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function ListarCombo2() As List(Of CCOSECTOR_BE)
            Try
                Return oCCOSECTOR_DL.ListarCombo2()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function


	End Class
End Namespace
