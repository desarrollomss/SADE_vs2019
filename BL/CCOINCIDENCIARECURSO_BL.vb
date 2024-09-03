'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

    Public Class CCOINCIDENCIARECURSO_BL
        Private oCCOINCIDENCIARECURSO_DL As New DAL.CCOINCIDENCIARECURSO_DL

        Public Sub Insertar(ByVal pCCOINCIDENCIARECURSO_BE As CCOINCIDENCIARECURSO_BE)
            Try
                oCCOINCIDENCIARECURSO_DL.Insertar(pCCOINCIDENCIARECURSO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function Listar(ByVal pINTINCCODIGO As Integer) As DataTable
            Try
                Return oCCOINCIDENCIARECURSO_DL.Listar(pINTINCCODIGO)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Function ActualizaLlegada(ByVal pCCOINCIDENCIARECURSO_BE As CCOINCIDENCIARECURSO_BE) As DataTable
            Try
                Return oCCOINCIDENCIARECURSO_DL.ActualizaLlegada(pCCOINCIDENCIARECURSO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        Public Sub Eliminar(ByVal pCCOINCIDENCIARECURSO_BE As CCOINCIDENCIARECURSO_BE)
            Try
                oCCOINCIDENCIARECURSO_DL.Eliminar(pCCOINCIDENCIARECURSO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function AsignarRecursoAPP(ByVal pCCOINCIDENCIARECURSO_BE As CCOINCIDENCIARECURSO_BE) As Integer
            Try
                Return oCCOINCIDENCIARECURSO_DL.AsignarRecursoAPP(pCCOINCIDENCIARECURSO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function
        Public Sub LiberarRecursoAPP(ByVal pCCOINCIDENCIARECURSO_BE As CCOINCIDENCIARECURSO_BE)
            Try
                oCCOINCIDENCIARECURSO_DL.LiberarRecursoAPP(pCCOINCIDENCIARECURSO_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub


    End Class
End Namespace
