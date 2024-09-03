Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports SISSADE.BL
Imports SISSADE.BE
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Web.Script.Services
Imports System.ServiceModel
Imports System.Net
Imports System.IO
Imports System.Drawing
Imports System.IO.Stream
Imports System.Drawing.Drawing2D
Imports AccesoDatosGEO

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.None)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebServiceAPP
    Inherits System.Web.Services.WebService

    Dim oSYSPERSONA_BL As New SYSPERSONA_BL
    Dim oCCOINCIDENCIA_BL As New CCOINCIDENCIA_BL
    Public jsoncallback As String

#Region "Numerador"
    Public Enum EstadoINC
        ABIERTO = 7
        DESPACHO = 8
        DESPACHADO = 9
        ATENDIENDO = 10
        FINALIZADO = 11
        CERRADO = 12
    End Enum

    Public Enum OrigenINC
        TELEFONO = 1
        RADIO = 2
        NEXTEL = 3
        SURCOALERTA = 4
        VECINOALERTA = 5
        ANALITICA = 6
    End Enum

    Public Enum TipoAlerta
        Emergencia = 1
        Denuncia = 2
    End Enum

    Public Enum Emergencia
        Ambulacia = 1
        Serenazgo = 2
        Bomberos = 3
    End Enum

    Public Enum Denuncia
        Jardines = 11
        RuidosMolestos = 12
        PistasyVeredas = 13
    End Enum



#End Region

    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub registrarAlerta(
                          ByVal pCodigoAPP As String,
                          ByVal pNombre As String,
                          ByVal pNumTelefono As String,
                          ByVal pNumDocIdent As String,
                          ByVal pEmail As String,
                          ByVal pTipo As String,
                          ByVal pSubTipo As String,
                          ByVal pURL As String,
                          ByVal pLat As String,
                          ByVal pLon As String)
        Dim strMensaje As String
        Dim strEstado As String
        Dim oAnexo As String = "0000"
        Dim oUsuario As String = "AlertaSurcov2"
        Dim intIncId As Integer = 0

        Dim oCCOINCIDENCIA_BE As New CCOINCIDENCIA_BE
        Dim oL_BE As New LUGAR_BE
        Dim oL_BL As New LUGAR_BL

        If pNumTelefono.Trim Is String.Empty Then
            strMensaje = "Problemas de envio, no existe informacion"
            strEstado = "9"
        Else
            '-- Registro Usuario
            Dim oR_BE As New GPSREGISTRO_BE

            With oR_BE
                .PropREGCODIGO = Nothing
                .PropREGNUMERO = pNumTelefono
                .PropREGNOMBRE = pNombre
                .PropREGDCMNTO = pNumDocIdent
                .PropREGEMAIL = pEmail
                .PropREGACTIVO = 1
                .PropAUDPRGCREACION = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
                .PropAUDEQPCREACION = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
                .PropAUDFECCREACION = Nothing

            End With
            '-- Georeferencia Inversa
            Try
                oL_BE = oL_BL.proj_LonLat2XY(pLon, pLat)
            Catch ex As Exception
            End Try

            '-- Registrar Incidencia
            Try
                Dim oCCOINCIDENCIA_BL As New CCOINCIDENCIA_BL
                Dim intInc As Integer = 0

                If pTipo = 1 Then
                    oCCOINCIDENCIA_BE.PropORICODIGO = OrigenINC.SURCOALERTA
                ElseIf pTipo = 2 Then
                    oCCOINCIDENCIA_BE.PropORICODIGO = OrigenINC.VECINOALERTA
                End If

                oCCOINCIDENCIA_BE.PropINCCODIGOAPP = pCodigoAPP
                oCCOINCIDENCIA_BE.PropINCIDLLAMADA = pNumTelefono
                oCCOINCIDENCIA_BE.PropINCNUMEROORIGEN = pNumTelefono
                oCCOINCIDENCIA_BE.PropINCIDLATITUDE = pLat.ToString().Trim()
                oCCOINCIDENCIA_BE.PropINCIDLONGITUDE = pLon.ToString().Trim()
                oCCOINCIDENCIA_BE.PropINCNOMBRE = pNombre.ToUpper
                oCCOINCIDENCIA_BE.PropTINCODIGO = pTipo
                oCCOINCIDENCIA_BE.PropSTICODIGO = pSubTipo
                oCCOINCIDENCIA_BE.PropINCESTADO = EstadoINC.ABIERTO
                oCCOINCIDENCIA_BE.PropAUDFECCREACION = Nothing
                oCCOINCIDENCIA_BE.PropAUDUSUCREACION = oUsuario
                oCCOINCIDENCIA_BE.PropAUDPRGCREACION = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
                oCCOINCIDENCIA_BE.PropAUDEQPCREACION = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
                '--- Datos Georeferencia Inversa
                oCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE = oL_BE.nCuadrante
                oCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR = oL_BE.nSector
                oCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1 = oL_BE.nVia
                oCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE = oL_BE.nHabilita
                oCCOINCIDENCIA_BE.PropINCLOCXGEO = oL_BE.xGeo
                oCCOINCIDENCIA_BE.PropINCLOCYGEO = oL_BE.yGeo
                oCCOINCIDENCIA_BE.PropINCARCHIVOURL = pURL

                '-- Registra Incidencia en BD
                intIncId = oCCOINCIDENCIA_BL.RegistrarAlertaSurcoV2(oCCOINCIDENCIA_BE, oR_BE)

                '-- Asigna Id Incidencia
                oCCOINCIDENCIA_BE.PropINCCODIGO = intIncId
                '--ya no enviara correo
                '-- Envia correo con Incidencia
                strMensaje = "Alerta registrada " + intIncId.ToString
                strEstado = "0"
            Catch ex As Exception
                strMensaje = "Problemas de conexion al enviar Alerta"
                strMensaje = ex.Message
                strEstado = "-1"
            End Try

        End If

        Dim sb As New StringBuilder
        Dim sw As New IO.StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            With jw
                .WriteStartObject()
                .WritePropertyName("numEstado")
                .WriteValue(strEstado)
                .WritePropertyName("txtMensaje")
                .WriteValue(strMensaje)

                If strEstado <> "-1" Then
                    .WritePropertyName("codSADE")
                    .WriteValue(intIncId)
                    .WritePropertyName("codAPP")
                    .WriteValue(pCodigoAPP)
                    .WritePropertyName("numTelefono")
                    .WriteValue(pNumTelefono)
                    .WritePropertyName("numLatitud")
                    .WriteValue(pLat.ToString().Trim())
                    .WritePropertyName("numLongitud")
                    .WriteValue(pLon.ToString().Trim())
                    .WritePropertyName("numCuadrante")
                    .WriteValue(oCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE)
                    .WritePropertyName("numSector")
                    .WriteValue(oCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR)
                    .WritePropertyName("nomVia")
                    .WriteValue(oCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1)
                    .WritePropertyName("nomHabilita")
                    .WriteValue(oCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE)
                End If
                .WriteEndObject()
            End With
            strOut = sw.ToString
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")
    End Sub




    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub insertarPosicionGPS(
                                    ByVal pIntPosId As Integer,
                                    ByVal pIntISSI As String,
                                    ByVal pDatPosFReg As String,
                                    ByVal pDecPosLat As String,
                                    ByVal pDecPosLon As String,
                                    ByVal pVchCodUnidad As String,
                                    ByVal pIntIncCodigo As Integer)

        Dim strMensaje As String
        Dim strEstado As String
        Dim _intposid As Int64
        Try
            Dim oGPSPOSICION_BE As New GPSPOSICION_BE
            Dim oGPSPOSICION_BL As New GPSPOSICION_BL

            oGPSPOSICION_BE.INTPOSID = pIntPosId
            oGPSPOSICION_BE.INTISSI = pIntISSI
            oGPSPOSICION_BE.DATPOSFREG = pDatPosFReg
            oGPSPOSICION_BE.DECPOSLAT = pDecPosLat
            oGPSPOSICION_BE.DECPOSLON = pDecPosLon
            oGPSPOSICION_BE.VCHCODUNIDAD = pVchCodUnidad
            oGPSPOSICION_BE.INTINCCODIGO = pIntIncCodigo

            _intposid = oGPSPOSICION_BL.Insertar(oGPSPOSICION_BE)

            strMensaje = "posicion registrada satisfactoriamente."
            strEstado = "0"
        Catch ex As Exception
            strMensaje = ex.Message
            strEstado = "9"
        End Try

        Dim sb As New StringBuilder
        Dim sw As New IO.StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            With jw

                .WriteStartObject()
                .WritePropertyName("intPosId")
                .WriteValue(_intposid)
                .WritePropertyName("numEstado")
                .WriteValue(strEstado)
                .WritePropertyName("txtMensaje")
                .WriteValue(strMensaje)
                .WriteEndObject()
            End With
            strOut = sw.ToString
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")


    End Sub

    <WebMethod(EnableSession:=True)>
    Public Function listarCallejero() As List(Of Calle)

        Dim MiCnx As ConnectionStringSettings = Nothing
        MiCnx = ConfigurationManager.ConnectionStrings("PgMSS")
        Dim cadena As String = MiCnx.ConnectionString

        Dim pgsql As String
        pgsql = "SELECT v.idvia,v.cod, v.nom_act as nom_act,vh.apr_acon ,vh.cla_vial ,c.nro_cdra, "
        pgsql += "  ST_x(ST_centroid(ST_Transform(c.geom,4326))) as _lon, "
        pgsql += "  ST_y(ST_centroid(ST_Transform(c.geom,4326))) as _lat  "
        pgsql += " FROM carto.tb_via AS v"
        pgsql += " INNER JOIN carto.tb_via_hisn  AS vh ON v.idvia=vh.idvia and act=1"
        pgsql += " INNER JOIN carto.tb_via_cuadra AS c ON v.idvia=c.idvia"
        pgsql += " ORDER BY v.idvia, c.nro_cdra"


        Dim dtP As New DataTable()
        dtP = NpgsqlHelper.ExecuteDataset(cadena, CommandType.Text, pgsql).Tables(0)

        Dim oCalle As New List(Of Calle)
        For Each row As DataRow In dtP.Rows
            Dim oC As New Calle()
            oC.idvia = row("idvia").ToString()
            oC.codvia = row("cod").ToString()
            oC.nomvia = row("nom_act").ToString()
            oC.nrocdra = row("nro_cdra").ToString()
            oC.Lat = row("_lat").ToString()
            oC.Lon = row("_lon").ToString()
            oCalle.Add(oC)
        Next
        Return oCalle
    End Function


    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub asignarRecursoAlerta(
                          ByVal pCodSADE As String,
                          ByVal pCodUnidad As String,
                          ByVal pFecHora As String
                            )
        Dim strMensaje As String
        Dim strEstado As String
        Dim strUsuario As String = "AppSurco"
        Dim intIncRecId As Integer = 0

        Dim oCCOINCIDENCIARECURSO_BE As New CCOINCIDENCIARECURSO_BE
        Dim oCCOINCIDENCIARECURSO_BL As New CCOINCIDENCIARECURSO_BL

        Dim sbLog As New StringBuilder
        sbLog.AppendFormat("[URL] : {0} | ", "asignarRecursoAlerta")
        sbLog.AppendFormat("pCodSADE : {0} | ", pCodSADE)
        sbLog.AppendFormat("pCodUnidad : {0} | ", pCodUnidad)
        sbLog.AppendFormat("pFecHora : {0} | ", pFecHora)
        sbLog.AppendLine("")

        Try
            With oCCOINCIDENCIARECURSO_BE
                .PropINCCODIGO = pCodSADE
                .PropINCRASIGNA = pFecHora
                .PropTRECODIGO = Nothing
                .PropRECCODIGO = Nothing
                .PropRECPERSONAL = pCodUnidad.ToUpper

                .PropAUDPRGCREACION = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
                .PropAUDEQPCREACION = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
                .PropAUDFECCREACION = Now.Date
                .PropAUDUSUCREACION = strUsuario
                .PropAUDROLCREACION = 3
            End With

            intIncRecId = oCCOINCIDENCIARECURSO_BL.AsignarRecursoAPP(oCCOINCIDENCIARECURSO_BE)

            '-- Asigna Id RecursoIncidencia
            oCCOINCIDENCIARECURSO_BE.PropINCRCODIGO = intIncRecId

            strMensaje = "Recurso asignado ...."
            strEstado = "0"
            sbLog.AppendFormat("RECURSO ASIGNADO : {0}", intIncRecId.ToString)
            sbLog.AppendLine("")

        Catch ex As Exception
            strMensaje = ex.Message
            strEstado = "-1"
            sbLog.AppendFormat("ERROR : {0} {1} ", strEstado, strMensaje)
            sbLog.AppendLine("")
        Finally
            Bitacora.Escribir(sbLog.ToString, LogMsg.INFO)
        End Try


        Dim sb As New StringBuilder
        Dim sw As New IO.StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            With jw
                .WriteStartObject()
                .WritePropertyName("numEstado")
                .WriteValue(strEstado)
                .WritePropertyName("txtMensaje")
                .WriteValue(strMensaje)

                If strEstado <> "-1" Then
                    .WritePropertyName("codSADE")
                    .WriteValue(pCodSADE)
                    .WritePropertyName("idAsignaRec")
                    .WriteValue(intIncRecId)
                End If
                .WriteEndObject()
            End With
            strOut = sw.ToString
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")
    End Sub

    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub liberarRecursoAlerta(
                          ByVal pCodSADE As String,
                          ByVal pIdAsignaRec As String,
                          ByVal pFecHora As String
                            )
        Dim strMensaje As String
        Dim strEstado As String
        Dim strUsuario As String = "AppSurco"

        Dim oCCOINCIDENCIARECURSO_BE As New CCOINCIDENCIARECURSO_BE
        Dim oCCOINCIDENCIARECURSO_BL As New CCOINCIDENCIARECURSO_BL

        Dim sbLog As New StringBuilder
        sbLog.AppendFormat("[URL] : {0} | ", "liberarRecursoAlerta")
        sbLog.AppendFormat("pCodSADE : {0} | ", pCodSADE)
        sbLog.AppendFormat("pIdAsignaRec : {0} | ", pIdAsignaRec)
        sbLog.AppendFormat("pFecHora : {0} | ", pFecHora)
        sbLog.AppendLine("")

        Try
            With oCCOINCIDENCIARECURSO_BE
                .PropINCCODIGO = pCodSADE
                .PropINCRCODIGO = pIdAsignaRec

                .PropAUDPRGMODIF = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
                .PropAUDEQPMODIF = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
                .PropAUDFECMODIF = Now.Date
                .PropAUDUSUMODIF = strUsuario
                .PropAUDROLMODIF = 3
            End With

            oCCOINCIDENCIARECURSO_BL.LiberarRecursoAPP(oCCOINCIDENCIARECURSO_BE)

            strMensaje = "Recurso liberado....."
            strEstado = "0"
            sbLog.AppendFormat("RECURSO LIBERADO : {0}", pIdAsignaRec.ToString)
            sbLog.AppendLine("")
        Catch ex As Exception
            strMensaje = ex.Message
            strEstado = "-1"
            sbLog.AppendFormat("ERROR : {0} {1} ", strEstado, strMensaje)
            sbLog.AppendLine("")
        Finally
            Bitacora.Escribir(sbLog.ToString, LogMsg.INFO)
        End Try


        Dim sb As New StringBuilder
        Dim sw As New IO.StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            With jw
                .WriteStartObject()
                .WritePropertyName("numEstado")
                .WriteValue(strEstado)
                .WritePropertyName("txtMensaje")
                .WriteValue(strMensaje)

                If strEstado <> "-1" Then
                    .WritePropertyName("codSADE")
                    .WriteValue(pCodSADE)
                    .WritePropertyName("idAsignaRec")
                    .WriteValue(pIdAsignaRec)
                End If
                .WriteEndObject()
            End With
            strOut = sw.ToString
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")
    End Sub


    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub registrarLlamada(
                          ByVal pNumTelefono As String,
                          ByVal pNumExtension As String,
                          ByVal pFecLlamada As String)
        Dim strMensaje As String
        Dim strEstado As String
        Dim oAnexo As String = System.Configuration.ConfigurationManager.AppSettings("ALERTA_ANEXO")
        Dim oUsuario As String = System.Configuration.ConfigurationManager.AppSettings("APP_USUARIO")
        Dim intIncId As Integer = 0

        Dim oCCOINCIDENCIA_BE As New CCOINCIDENCIA_BE
        Dim oL_BE As New LUGAR_BE
        Dim oL_BL As New LUGAR_BL

        Dim sbLog As New StringBuilder
        sbLog.AppendFormat("[URL] : {0} | ", "registrarLlamada")
        sbLog.AppendFormat("pNumTelefono : {0} | ", pNumTelefono)
        sbLog.AppendFormat("pNumExtension : {0} | ", pNumExtension)
        sbLog.AppendFormat("pFecLlamada : {0} | ", pFecLlamada)
        sbLog.AppendLine("")

        If (pNumTelefono.Trim Is String.Empty Or pNumExtension.Trim Is String.Empty) Then
            strMensaje = "Problemas de envio, no existe informacion, Telefono o Anexo"
            strEstado = "9"
            sbLog.AppendFormat("ERROR : {0} {1} ", strEstado, strMensaje)
            sbLog.AppendLine("")
            Bitacora.Escribir(sbLog.ToString, LogMsg.ERROR)
        Else
            '-- Registrar Incidencia
            Try
                Dim oCCOINCIDENCIA_BL As New CCOINCIDENCIA_BL
                Dim intInc As Integer = 0

                oCCOINCIDENCIA_BE.PropORICODIGO = OrigenINC.TELEFONO
                oCCOINCIDENCIA_BE.PropINCIDLLAMADA = pNumTelefono
                oCCOINCIDENCIA_BE.PropINCNUMEROORIGEN = pNumTelefono
                oCCOINCIDENCIA_BE.PropINCIDANEXO = pNumExtension
                oCCOINCIDENCIA_BE.PropINCESTADO = EstadoINC.ABIERTO

                oCCOINCIDENCIA_BE.PropAUDFECCREACION = Nothing
                oCCOINCIDENCIA_BE.PropAUDUSUCREACION = oUsuario
                oCCOINCIDENCIA_BE.PropAUDPRGCREACION = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
                oCCOINCIDENCIA_BE.PropAUDEQPCREACION = HttpContext.Current.Request.UserHostAddress.ToString().Trim()

                '-- Registra Incidencia en BD
                intIncId = oCCOINCIDENCIA_BL.RegistrarLlamada(oCCOINCIDENCIA_BE)
                '-- Asigna Id Incidencia
                oCCOINCIDENCIA_BE.PropINCCODIGO = intIncId
                strMensaje = "Llamada registrada " + intIncId.ToString
                strEstado = "0"
                sbLog.AppendFormat("LLAMADA REGISTRADA : {0}", intIncId.ToString)
                sbLog.AppendLine("")
            Catch ex As Exception
                strMensaje = "Problemas de conexion al Registrar llamada"
                strMensaje = ex.Message
                strEstado = "-1"
                sbLog.AppendFormat("ERROR : {0} {1} ", strEstado, strMensaje)
                sbLog.AppendLine("")
            Finally
                Bitacora.Escribir(sbLog.ToString, LogMsg.INFO)
            End Try

        End If

        Dim sb As New StringBuilder
        Dim sw As New IO.StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            With jw
                .WriteStartObject()
                .WritePropertyName("numEstado")
                .WriteValue(strEstado)
                .WritePropertyName("txtMensaje")
                .WriteValue(strMensaje)

                If strEstado <> "-1" Then
                    .WritePropertyName("codSADE")
                    .WriteValue(intIncId)
                    .WritePropertyName("numTelefono")
                    .WriteValue(pNumTelefono)
                    .WritePropertyName("numExtension")
                    .WriteValue(pNumExtension)
                End If
                .WriteEndObject()
            End With
            strOut = sw.ToString
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")
    End Sub

    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub registrarAlertaV3(
                          ByVal pCodigoAPP As String,
                          ByVal pNombre As String,
                          ByVal pNumTelefono As String,
                          ByVal pNumDocIdent As String,
                          ByVal pEmail As String,
                          ByVal pTipo As String,
                          ByVal pSubTipo As String,
                          ByVal pURL As String,
                          ByVal pLat As String,
                          ByVal pLon As String)
        Dim strMensaje As String
        Dim strEstado As String
        Dim oAnexo As String = System.Configuration.ConfigurationManager.AppSettings("ALERTA_ANEXO")
        Dim oUsuario As String = System.Configuration.ConfigurationManager.AppSettings("APP_USUARIO")
        Dim intIncId As Integer = 0

        Dim oCCOINCIDENCIA_BE As New CCOINCIDENCIA_BE
        Dim oL_BE As New LUGAR_BE
        Dim oL_BL As New LUGAR_BL

        Dim sbLog As New StringBuilder
        sbLog.AppendFormat("[URL] : {0} | ", "registrarAlertaV3")
        sbLog.AppendFormat("pCodigoAPP : {0} | ", pCodigoAPP)
        sbLog.AppendFormat("pNumTelefono : {0} | ", pNumTelefono)
        sbLog.AppendFormat("pNumDocIdent : {0} | ", pNumDocIdent)
        sbLog.AppendFormat("pEmail : {0} | ", pEmail)
        sbLog.AppendFormat("pTipo : {0} | ", pTipo)
        sbLog.AppendFormat("pSubTipo : {0} | ", pSubTipo)
        sbLog.AppendFormat("pURL : {0} | ", pURL)
        sbLog.AppendFormat("pLat : {0} | ", pLat)
        sbLog.AppendFormat("pLon : {0} | ", pLon)
        sbLog.AppendLine("")


        If (pNumTelefono.Trim Is String.Empty Or pTipo.Trim Is String.Empty Or pSubTipo.Trim Is String.Empty) Then
            strMensaje = "Problemas de envio, no existe informacion, Telefono o Tipo o Subtipo"
            strEstado = "9"
            sbLog.AppendFormat("ERROR : {0} {1} ", strEstado, strMensaje)
            sbLog.AppendLine("")
            Bitacora.Escribir(sbLog.ToString, LogMsg.ERROR)
        Else
            '-- Registro Usuario
            Dim oR_BE As New GPSREGISTRO_BE

                With oR_BE
                    .PropREGCODIGO = Nothing
                    .PropREGNUMERO = pNumTelefono
                    .PropREGNOMBRE = pNombre
                    .PropREGDCMNTO = pNumDocIdent
                    .PropREGEMAIL = pEmail
                    .PropREGACTIVO = 1
                    .PropAUDPRGCREACION = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
                    .PropAUDEQPCREACION = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
                    .PropAUDFECCREACION = Nothing

                End With
                '-- Georeferencia Inversa
                Try
                    oL_BE = oL_BL.proj_LonLat2XY(pLon, pLat)
                Catch ex As Exception

                End Try

                '-- Registrar Incidencia
                Try
                    Dim oCCOINCIDENCIA_BL As New CCOINCIDENCIA_BL
                    Dim intInc As Integer = 0

                    If pTipo = 1 Then
                        oCCOINCIDENCIA_BE.PropORICODIGO = OrigenINC.SURCOALERTA
                    ElseIf pTipo = 2 Then
                        oCCOINCIDENCIA_BE.PropORICODIGO = OrigenINC.VECINOALERTA
                    End If

                    oCCOINCIDENCIA_BE.PropINCCODIGOAPP = pCodigoAPP
                    oCCOINCIDENCIA_BE.PropINCIDLLAMADA = pNumTelefono
                    oCCOINCIDENCIA_BE.PropINCNUMEROORIGEN = pNumTelefono
                    oCCOINCIDENCIA_BE.PropINCIDLATITUDE = pLat.ToString().Trim()
                    oCCOINCIDENCIA_BE.PropINCIDLONGITUDE = pLon.ToString().Trim()
                    oCCOINCIDENCIA_BE.PropINCNOMBRE = pNombre.ToUpper
                    oCCOINCIDENCIA_BE.PropTINCODIGO = pTipo
                    oCCOINCIDENCIA_BE.PropSTICODIGO = pSubTipo
                    oCCOINCIDENCIA_BE.PropINCESTADO = EstadoINC.ABIERTO
                    oCCOINCIDENCIA_BE.PropAUDFECCREACION = Nothing
                    oCCOINCIDENCIA_BE.PropAUDUSUCREACION = oUsuario
                    oCCOINCIDENCIA_BE.PropAUDPRGCREACION = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
                    oCCOINCIDENCIA_BE.PropAUDEQPCREACION = HttpContext.Current.Request.UserHostAddress.ToString().Trim()
                    '--- Datos Georeferencia Inversa
                    oCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE = oL_BE.nCuadrante
                    oCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR = oL_BE.nSector
                    oCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1 = oL_BE.nVia
                    oCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE = oL_BE.nHabilita
                    oCCOINCIDENCIA_BE.PropINCLOCXGEO = oL_BE.xGeo
                    oCCOINCIDENCIA_BE.PropINCLOCYGEO = oL_BE.yGeo
                    oCCOINCIDENCIA_BE.PropINCARCHIVOURL = pURL

                    '-- Registra Incidencia en BD Version 2
                    intIncId = oCCOINCIDENCIA_BL.RegistrarAlertaSurcoV3(oCCOINCIDENCIA_BE, oR_BE)

                    '-- Asigna Id Incidencia
                    oCCOINCIDENCIA_BE.PropINCCODIGO = intIncId
                '--ya no enviara correo
                strMensaje = "Alerta registrada " + intIncId.ToString
                strEstado = "0"
                    sbLog.AppendFormat("ALERTA REGISTRADA : {0}", intIncId.ToString)
                    sbLog.AppendLine("")
                Catch ex As Exception
                    strMensaje = "Problemas de conexion al enviar Alerta"
                    strMensaje = ex.Message
                    strEstado = "-1"
                    sbLog.AppendFormat("ERROR : {0} {1} ", strEstado, strMensaje)
                    sbLog.AppendLine("")
                Finally
                    Bitacora.Escribir(sbLog.ToString, LogMsg.INFO)
                End Try
            End If


            Dim sb As New StringBuilder
        Dim sw As New IO.StringWriter(sb)
        Dim strOut As String = String.Empty
        Using jw As New JsonTextWriter(sw)
            With jw
                .WriteStartObject()
                .WritePropertyName("numEstado")
                .WriteValue(strEstado)
                .WritePropertyName("txtMensaje")
                .WriteValue(strMensaje)

                If strEstado <> "-1" Then
                    .WritePropertyName("codSADE")
                    .WriteValue(intIncId)
                    .WritePropertyName("codAPP")
                    .WriteValue(pCodigoAPP)
                    .WritePropertyName("numTelefono")
                    .WriteValue(pNumTelefono)
                    .WritePropertyName("numLatitud")
                    .WriteValue(pLat.ToString().Trim())
                    .WritePropertyName("numLongitud")
                    .WriteValue(pLon.ToString().Trim())
                    .WritePropertyName("numCuadrante")
                    .WriteValue(oCCOINCIDENCIA_BE.PropVCHINCLOCCUADRANTE)
                    .WritePropertyName("numSector")
                    .WriteValue(oCCOINCIDENCIA_BE.PropVCHINCLOCSECTOR)
                    .WritePropertyName("nomVia")
                    .WriteValue(oCCOINCIDENCIA_BE.PropINCLOCVIANOMBRE1)
                    .WritePropertyName("nomHabilita")
                    .WriteValue(oCCOINCIDENCIA_BE.PropINCLOCHABNOMBRE)
                End If
                .WriteEndObject()
            End With
            strOut = sw.ToString
        End Using
        jsoncallback = HttpContext.Current.Request.QueryString("jsoncallback")
        HttpContext.Current.Response.Write(jsoncallback & "(" & strOut & ");")
    End Sub



End Class