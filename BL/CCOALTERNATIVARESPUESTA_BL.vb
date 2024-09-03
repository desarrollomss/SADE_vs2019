'--Imports IBM.Data.DB2
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

    Public Class CCOALTERNATIVARESPUESTA_BL
        Private oCCOALTERNATIVARESPUESTA_DL As New DAL.CCOALTERNATIVARESPUESTA_DL

        Public Sub Insertar(ByVal pCCOALTERNATIVARESPUESTA_BE As CCOALTERNATIVARESPUESTA_BE)
            Try
                oCCOALTERNATIVARESPUESTA_DL.Insertar(pCCOALTERNATIVARESPUESTA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Actualizar(ByVal pCCOALTERNATIVARESPUESTA_BE As CCOALTERNATIVARESPUESTA_BE)
            Try
                oCCOALTERNATIVARESPUESTA_DL.Actualizar(pCCOALTERNATIVARESPUESTA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Sub Eliminar(ByVal pCCOALTERNATIVARESPUESTA_BE As CCOALTERNATIVARESPUESTA_BE)
            Try
                oCCOALTERNATIVARESPUESTA_DL.Eliminar(pCCOALTERNATIVARESPUESTA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Sub

        Public Function ListarKey(ByVal pCCOALTERNATIVARESPUESTA_BE As CCOALTERNATIVARESPUESTA_BE) As CCOALTERNATIVARESPUESTA_BE
            Try
                Return oCCOALTERNATIVARESPUESTA_DL.ListarKey(pCCOALTERNATIVARESPUESTA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function


        Public Function ListarCombo(ByVal pCCOALTERNATIVARESPUESTA_BE As CCOALTERNATIVARESPUESTA_BE) As DataTable
            Try
                Return oCCOALTERNATIVARESPUESTA_DL.ListarCombo(pCCOALTERNATIVARESPUESTA_BE)
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

    End Class
End Namespace
