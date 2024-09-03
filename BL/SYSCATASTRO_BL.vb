'--Imports IBM.Data.DB2
Imports System.Text
Imports System.Data
Imports System.Collections.Generic
Imports SISSADE.DAL
Imports SISSADE.BE

Namespace BL

    Public Class SYSCATASTRO_BL
        Private oCCOCARGO_DL As New DAL.SYSCATASTRO_DL

        Public Function consultAutoVias(ByVal P_DESVIAS As String) As List(Of SYSCATASTRO_BE)
            Dim obj As New SYSCATASTRO_DL
            Return obj.consultAutoVias(P_DESVIAS)
        End Function

        Public Function consultAutoCodCat(ByVal P_CODVIA As String) As List(Of SYSCATASTRO_BE)
            Dim obj As New SYSCATASTRO_DL
            Return obj.consultAutoCodCat(P_CODVIA)
        End Function

        Public Function consultComboVias() As List(Of SYSCATASTRO_BE)
            Dim obj As New SYSCATASTRO_DL
            Return obj.consultComboVias()
        End Function

        Public Function listarkeyCodCat(ByVal P_CODCAT As String, ByVal P_CODVIA As String) As List(Of SYSCATASTRO_BE)
            Dim obj As New SYSCATASTRO_DL
            Return obj.listarkeyCodCat(P_CODCAT, P_CODVIA)
        End Function

        Public Function BuscarDireccion(ByVal pDIRECCION As String) As DataTable
            Dim obj As New SYSCATASTRO_DL
            Return obj.buscardireccion(pDIRECCION)
        End Function

        Public Function ListarLoteDetalle(ByVal pCODLOTE As String) As DataTable
            Dim obj As New SYSCATASTRO_DL
            Return obj.ListarLoteDetalle(pCODLOTE)
        End Function

        Public Function ListarLoteLicencia(ByVal pCODLOTE As String) As DataTable
            Dim obj As New SYSCATASTRO_DL
            Return obj.ListarLoteLicencia(pCODLOTE)
        End Function

    End Class
End Namespace
