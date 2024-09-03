Imports System.Data.SqlClient
Imports System.Data
Imports SISSADE.BE
Imports SISSADE.BL



Partial Class frmGeoRefIncidencia
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack() Then
            ViewState("pID") = Request.QueryString("codinc")
            ViewState("pUser") = Request.QueryString("codusu")
            ViewState("pMode") = Request.QueryString("accion")
            ModoEdicion(ViewState("pMode"))
        End If

    End Sub

    Private Sub ModoEdicion(ByVal accion As String)

        btnGrabar.Visible = True

        hdTipoAccion.Value = accion
        txtNumeroIncEdi.Text = ""

        txtNumeroIncEdi.Text = ""
        txtFechaIncEdi.Text = ""
        txtCalleIncEdi.Text = ""
        txtNroIncEdi.Text = ""
        txtCdraIncEdi.Text = ""
        txtMzaIncEdi.Text = ""
        txtLteIncEdi.Text = ""
        txtDptoIncEdi.Text = ""
        txtUrbIncEdi.Text = ""
        txtComIncEdi.Text = ""
        txtSectorIncEdi.Text = ""
        txtCuadranteIncEdi.Text = ""

        hfGeoX.Value = ""
        hfGeoY.Value = ""


        txtNumeroIncEdi.Enabled = False
        txtFechaIncEdi.Enabled = False
        txtCalleIncEdi.Enabled = True
        txtNroIncEdi.Enabled = True
        txtCdraIncEdi.Enabled = True
        txtMzaIncEdi.Enabled = True
        txtLteIncEdi.Enabled = True
        txtDptoIncEdi.Enabled = True
        txtUrbIncEdi.Enabled = True
        txtComIncEdi.Enabled = True
        txtSectorIncEdi.Enabled = True
        txtCuadranteIncEdi.Enabled = True


        If accion = "V" Or accion = "U" Then
            txtNumeroIncEdi.Text = ViewState("pID")
        
            Dim oBE As CCOINCIDENCIA_BE = New CCOINCIDENCIA_BE
            Dim oBESel As CCOINCIDENCIA_BE = New CCOINCIDENCIA_BE
            Dim oBL As CCOINCIDENCIA_BL = New CCOINCIDENCIA_BL
            Try
                With oBE
                    .PropINCCODIGO = txtNumeroIncEdi.Text
                End With
                oBESel = oBL.ListarKey(oBE)

                hfGeoX.Value = oBESel.PropINCLOCXGEO
                hfGeoY.Value = oBESel.PropINCLOCYGEO
                txtNumeroIncEdi.Text = oBESel.PropINCCODIGO
                txtFechaIncEdi.Text = oBESel.PropINCFECHA
                txtCalleIncEdi.Text = oBESel.PropINCLOCVIANOMBRE1
                txtNroIncEdi.Text = oBESel.PropINCLOCNUMERO
                txtCdraIncEdi.Text = oBESel.PropINCLOCCUADRA
                txtMzaIncEdi.Text = oBESel.PropINCLOCMANZANA
                txtLteIncEdi.Text = oBESel.PropINCLOCLOTE
                txtDptoIncEdi.Text = oBESel.PropINCLOCDPTO
                txtUrbIncEdi.Text = oBESel.PropINCLOCHABNOMBRE
                txtComIncEdi.Text = oBESel.PropINCLOCCOMENTARIO
                txtSectorIncEdi.Text = oBESel.PropVCHINCLOCSECTOR
                txtCuadranteIncEdi.Text = oBESel.PropVCHINCLOCCUADRANTE
                hfGeoX.Value = oBESel.PropINCLOCXGEO
                hfGeoY.Value = oBESel.PropINCLOCYGEO
            Catch ex As Exception
                lblMensajeReg.Text = ex.Message
                Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            End Try
            If accion = "V" Then

                btnGrabar.Visible = False

                txtNumeroIncEdi.Enabled = False
                txtFechaIncEdi.Enabled = False
                txtCalleIncEdi.Enabled = False
                txtNroIncEdi.Enabled = False
                txtCdraIncEdi.Enabled = False
                txtMzaIncEdi.Enabled = False
                txtLteIncEdi.Enabled = False
                txtDptoIncEdi.Enabled = False
                txtUrbIncEdi.Enabled = False
                txtComIncEdi.Enabled = False
                txtSectorIncEdi.Enabled = False
                txtCuadranteIncEdi.Enabled = False

            End If


        End If
    End Sub


    Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        Dim oBE As CCOINCIDENCIA_BE = New CCOINCIDENCIA_BE
        Dim oBL As CCOINCIDENCIA_BL = New CCOINCIDENCIA_BL
        lblMensajeReg.Text = ""
        If hfGeoX.Value.ToString = "" Or hfGeoY.Value.ToString = "" Then
            lblMensajeReg.Text = lblMensajeReg.Text & "<li>Ubique en el mapa la ubicacion del Incidente</li>"
        End If



        If lblMensajeReg.Text = "" Then
            Try

                With oBE
                    .PropINCCODIGO = txtNumeroIncEdi.Text
                    .PropINCLOCVIACODIGO1 = hfCodViaIncEdi.Value
                    .PropINCLOCVIANOMBRE1 = txtCalleIncEdi.Text
                    .PropINCLOCNUMERO = txtNroIncEdi.Text
                    .PropINCLOCCUADRA = txtCdraIncEdi.Text
                    .PropINCLOCMANZANA = txtMzaIncEdi.Text
                    .PropINCLOCLOTE = txtLteIncEdi.Text
                    .PropINCLOCDPTO = txtDptoIncEdi.Text
                    .PropINCLOCHABCODIGO = hfCodHabUrbEdi.Value
                    .PropINCLOCHABNOMBRE = txtUrbIncEdi.Text
                    .PropINCLOCCOMENTARIO = txtComIncEdi.Text
                    .PropAUDFECMODIF = Now.Date
                    .PropAUDUSUMODIF = Session("USUARIO")
                    .PropAUDPRGMODIF = Session("PROGRAMA")
                    .PropAUDEQPMODIF = Session("EQUIPO")
                    .PropINCIDLATITUDE = Nothing
                    .PropINCIDLONGITUDE = Nothing
                    .PropINCLOCXGEO = hfGeoX.Value
                    .PropINCLOCYGEO = hfGeoY.Value
                    .PropVCHINCLOCCUADRANTE = txtCuadranteIncEdi.Text
                    .PropVCHINCLOCSECTOR = txtSectorIncEdi.Text
                End With

                Dim intID As Integer = 0
                If hdTipoAccion.Value = "I" Then
                ElseIf hdTipoAccion.Value = "U" Then
                    oBL.Actualizar_GEO_SIAVE(oBE)
                    lblMensajeReg.Text = "Se Actualizó de manera Exitosa"
                End If
            Catch ex As Exception
                lblMensajeReg.Text = ex.Message
                Bitacora.Escribir(ex.Message, LogMsg.ERROR)
            End Try
        End If

    End Sub



End Class
