Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

	Public Class CCOPERSONALFAMILIA_BL
		Private oCCOPERSONALFAMILIA_DL As New DAL.CCOPERSONALFAMILIA_DL

		Public Sub Insertar(ByVal pCCOPERSONALFAMILIA_BE As CCOPERSONALFAMILIA_BE)
			Try
				oCCOPERSONALFAMILIA_DL.Insertar(pCCOPERSONALFAMILIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Actualizar(ByVal pCCOPERSONALFAMILIA_BE As CCOPERSONALFAMILIA_BE)
			Try
				oCCOPERSONALFAMILIA_DL.Actualizar(pCCOPERSONALFAMILIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Sub Eliminar(ByVal pCCOPERSONALFAMILIA_BE As CCOPERSONALFAMILIA_BE)
			Try
				oCCOPERSONALFAMILIA_DL.Eliminar(pCCOPERSONALFAMILIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Sub

		Public Function ListarKey(ByVal pCCOPERSONALFAMILIA_BE As CCOPERSONALFAMILIA_BE) As CCOPERSONALFAMILIA_BE
			Try
				Return oCCOPERSONALFAMILIA_DL.ListarKey(pCCOPERSONALFAMILIA_BE)
			Catch ex As Exception
				Throw ex
			Finally
			End Try
		End Function
        Public Function Listar(ByVal pCCOPERSONALFAMILIA_BE As CCOPERSONALFAMILIA_BE) As DataTable
            Try
                Return oCCOPERSONALFAMILIA_DL.Listar(pCCOPERSONALFAMILIA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

	End Class
End Namespace
