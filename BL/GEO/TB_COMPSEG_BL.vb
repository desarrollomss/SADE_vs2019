
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class TB_COMPSEG_BL
		Private oTB_COMPSEG_DL As New DAL.TB_COMPSEG_DL

        Public Function Insertar(ByVal pTB_COMPSEG_BE As TB_COMPSEG_BE) As Integer
            Try
                Return oTB_COMPSEG_DL.Insertar(pTB_COMPSEG_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

		Public Sub Actualizar(ByVal pTB_COMPSEG_BE As TB_COMPSEG_BE)
			Try
				oTB_COMPSEG_DL.Actualizar(pTB_COMPSEG_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pTB_COMPSEG_BE As TB_COMPSEG_BE)
			Try
				oTB_COMPSEG_DL.Eliminar(pTB_COMPSEG_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pTB_COMPSEG_BE As TB_COMPSEG_BE) As TB_COMPSEG_BE
			Try
				Return oTB_COMPSEG_DL.ListarKey(pTB_COMPSEG_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function

        Public Function Listar(ByVal pTB_COMPSEG_BE As TB_COMPSEG_BE) As DataTable
            Try
                Return oTB_COMPSEG_DL.Listar(pTB_COMPSEG_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function ListarComboTipoCmpnt() As DataTable
            Try
                Return oTB_COMPSEG_DL.ListarComboTipoCmpnt()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Function ListarComboEstadoCmpnt() As DataTable
            Try
                Return oTB_COMPSEG_DL.ListarComboEstadoCmpnt()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function


        Public Function ListarComboGrupoCmpnt() As DataTable
            Try
                Return oTB_COMPSEG_DL.ListarComboGrupoCmpnt()
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

	End Class
End Namespace
