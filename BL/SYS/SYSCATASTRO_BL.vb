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

        Public Function ListarLoteGIS(ByVal pCODLOTE As String) As DataSet
            Dim obj As New SYSCATASTRO_DL
            Return obj.ListarLoteGIS(pCODLOTE)
        End Function

        Public Function consultarViasGIS(ByVal P_NOMVIA As String) As List(Of SYSVIA_BE)
            Dim obj As New SYSCATASTRO_DL
            Return obj.consultarViasGIS(P_NOMVIA)
        End Function

        Public Function consultarNroGIS(ByVal P_CODVIA As String) As List(Of SYSNRO_BE)
            Dim obj As New SYSCATASTRO_DL
            Return obj.consultarNroGIS(P_CODVIA)
        End Function

        Public Function ListarCodLoteGIS(ByVal pCODLOTE As String) As DataTable
            Dim obj As New SYSCATASTRO_DL
            Return obj.ListarCodLoteGIS(pCODLOTE)
        End Function

        Public Function ListarAdminGIS(ByVal pNOMBRE As String) As DataTable
            Dim obj As New SYSCATASTRO_DL
            Return obj.ListarAdminGIS(pNOMBRE)
        End Function

        Public Sub GuardaLoteFIS(ByVal pTOKEN As String, ByVal pCODLOTE As String, ByVal pPOSLAT As String, ByVal pPOSLON As String, ByVal pDISTANCE As Decimal)
            Dim obj As New SYSCATASTRO_DL
            obj.GuardaLotesFIS(pTOKEN, pCODLOTE, pPOSLAT, pPOSLON, pDISTANCE)

        End Sub

        Public Function ListarLoteFIS(ByVal pTOKEN As String) As DataTable
            Dim obj As New SYSCATASTRO_DL
            Return obj.ListarLoteFIS(pTOKEN)
        End Function

        Public Sub ActualizaLoteFIS(ByVal pBE As FISPREDIO_BE)
            Dim obj As New SYSCATASTRO_DL
            obj.ActualizaLotesFIS(pBE)
        End Sub

        Public Function BuscarLoteFIS(ByVal pBE As FISPREDIO_BE) As DataTable
            Dim obj As New SYSCATASTRO_DL
            Return obj.BuscarLoteFIS(pBE)
        End Function

    End Class
End Namespace
