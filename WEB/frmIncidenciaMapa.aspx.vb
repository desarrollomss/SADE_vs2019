Imports System.Data
Imports SISSADE.BE
Imports SISSADE.BL

Partial Class frmIncidenciaMapa
    Inherits System.Web.UI.Page

    Enum Estado
        Abierto = 7
        Derivado = 8
        Recepcionado = 9
        Despachado = 10
        Atencion = 11
        Cerrado = 12
    End Enum

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            Dim mp As MasterPage = Me.Master

            ViewState("pID") = Request.QueryString("pID")

            If CType(ViewState("pID"), Integer) > 0 Then
                Dim oINC As New CCOINCIDENCIA_BE
                Dim oINC_BL As New CCOINCIDENCIA_BL
                oINC.PropINCCODIGO = CType(ViewState("pID"), Integer)
                oINC = oINC_BL.ListarKey(oINC)
                CargaDatosControl(oINC)
            End If

        End If
    End Sub



    Public Sub CargaDatosControl(ByVal oINC As CCOINCIDENCIA_BE)

        Me.Title = oINC.PropINCCODIGO


        hfGeoX.Value = oINC.PropINCLOCXGEO
        hfGeoY.Value = oINC.PropINCLOCYGEO


        hfViaInc.Value = oINC.PropINCLOCVIACODIGO1
        txtViaInc.Text = oINC.PropINCLOCVIANOMBRE1
        hfIntInc.Value = oINC.PropINCLOCVIACODIGO2
        txtIntInc.Text = oINC.PropINCLOCVIANOMBRE2

        txtNroInc.Text = oINC.PropINCLOCNUMERO
        txtCdraInc.Text = oINC.PropINCLOCCUADRA
        txtLteInc.Text = oINC.PropINCLOCLOTE
        txtMzaInc.Text = oINC.PropINCLOCMANZANA
        txtDptoInc.Text = oINC.PropINCLOCDPTO

        hfUrbInc.Value = oINC.PropINCLOCHABCODIGO
        txtUrbInc.Text = oINC.PropINCLOCHABNOMBRE
        txtComInc.Text = oINC.PropINCLOCCOMENTARIO
        txtSector.Text = oINC.PropVCHINCLOCSECTOR
        txtCuadrante.Text = oINC.PropVCHINCLOCCUADRANTE


    End Sub



End Class
