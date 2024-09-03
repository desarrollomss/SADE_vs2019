Imports System

Namespace BE

    <Serializable()>
    Public Class TB_CAMARA_BE

        Private intidcamara As Nullable(Of Integer)
        Private intcodmarca As Nullable(Of Integer)
        Private vchmodelo As String
        Private vchnroserie As String
        Private intcodcovv As Nullable(Of Integer)
        Private vchipcamara As String
        Private vchlat As String
        Private vchlon As String
        Private geom As String
        Private vchcodarea As String
        Private vchcodsector As String
        Private vchssecvecinal As String
        Private vchcodcuadrante As String
        Private vchcodaxxon As String
        Private vchubicacion As String
        Private vchurbanizacion As String
        Private txtestado As String
        Private vchobserva As String
        Private intcodestado As Nullable(Of Integer)
        Private vchaudusuariocrea As String
        Private vchaudequipocrea As String
        Private tmsaudfechacrea As DateTime
        Private vchaudusuariomodif As String
        Private vchaudequipomodif As String
        Private tmsaudfechamodif As DateTime

        Public Property PropINTIDCAMARA As Nullable(Of Integer)
            Get
                Return intidcamara
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intidcamara = value
            End Set
        End Property
        Public Property PropINTCODMARCA As Nullable(Of Integer)
            Get
                Return intcodmarca
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intcodmarca = value
            End Set
        End Property
        Public Property PropVCHMODELO As String
            Get
                Return vchmodelo
            End Get
            Set(ByVal value As String)
                vchmodelo = value
            End Set
        End Property
        Public Property PropVCHNROSERIE As String
            Get
                Return vchnroserie
            End Get
            Set(ByVal value As String)
                vchnroserie = value
            End Set
        End Property
        Public Property PropINTCODCOVV As Nullable(Of Integer)
            Get
                Return intcodcovv
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intcodcovv = value
            End Set
        End Property
        Public Property PropVCHIPCAMARA As String
            Get
                Return vchipcamara
            End Get
            Set(ByVal value As String)
                vchipcamara = value
            End Set
        End Property
        Public Property PropVCHLAT As String
            Get
                Return vchlat
            End Get
            Set(ByVal value As String)
                vchlat = value
            End Set
        End Property
        Public Property PropVCHLON As String
            Get
                Return vchlon
            End Get
            Set(ByVal value As String)
                vchlon = value
            End Set
        End Property
        Public Property PropGEOM As String
            Get
                Return geom
            End Get
            Set(ByVal value As String)
                geom = value
            End Set
        End Property
        Public Property PropVCHCODAREA As String
            Get
                Return vchcodarea
            End Get
            Set(ByVal value As String)
                vchcodarea = value
            End Set
        End Property
        Public Property PropVCHCODSECTOR As String
            Get
                Return vchcodsector
            End Get
            Set(ByVal value As String)
                vchcodsector = value
            End Set
        End Property
        Public Property PropVCHSSECVECINAL As String
            Get
                Return vchssecvecinal
            End Get
            Set(ByVal value As String)
                vchssecvecinal = value
            End Set
        End Property
        Public Property PropVCHCODCUADRANTE As String
            Get
                Return vchcodcuadrante
            End Get
            Set(ByVal value As String)
                vchcodcuadrante = value
            End Set
        End Property
        Public Property PropVCHCODAXXON As String
            Get
                Return vchcodaxxon
            End Get
            Set(ByVal value As String)
                vchcodaxxon = value
            End Set
        End Property
        Public Property PropVCHUBICACION As String
            Get
                Return vchubicacion
            End Get
            Set(ByVal value As String)
                vchubicacion = value
            End Set
        End Property
        Public Property PropVCHURBANIZACION As String
            Get
                Return vchurbanizacion
            End Get
            Set(ByVal value As String)
                vchurbanizacion = value
            End Set
        End Property
        Public Property PropTXTESTADO As String
            Get
                Return txtestado
            End Get
            Set(ByVal value As String)
                txtestado = value
            End Set
        End Property
        Public Property PropVCHOBSERVA As String
            Get
                Return vchobserva
            End Get
            Set(ByVal value As String)
                vchobserva = value
            End Set
        End Property
        Public Property PropINTCODESTADO As Nullable(Of Integer)
            Get
                Return intcodestado
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intcodestado = value
            End Set
        End Property
        Public Property PropVCHAUDUSUARIOCREA As String
            Get
                Return vchaudusuariocrea
            End Get
            Set(ByVal value As String)
                vchaudusuariocrea = value
            End Set
        End Property
        Public Property PropVCHAUDEQUIPOCREA As String
            Get
                Return vchaudequipocrea
            End Get
            Set(ByVal value As String)
                vchaudequipocrea = value
            End Set
        End Property
        Public Property PropTMSAUDFECHACREA As DateTime
            Get
                Return tmsaudfechacrea
            End Get
            Set(ByVal value As DateTime)
                tmsaudfechacrea = value
            End Set
        End Property
        Public Property PropVCHAUDUSUARIOMODIF As String
            Get
                Return vchaudusuariomodif
            End Get
            Set(ByVal value As String)
                vchaudusuariomodif = value
            End Set
        End Property
        Public Property PropVCHAUDEQUIPOMODIF As String
            Get
                Return vchaudequipomodif
            End Get
            Set(ByVal value As String)
                vchaudequipomodif = value
            End Set
        End Property
        Public Property PropTMSAUDFECHAMODIF As DateTime
            Get
                Return tmsaudfechamodif
            End Get
            Set(ByVal value As DateTime)
                tmsaudfechamodif = value
            End Set
        End Property

        Public Sub LimpiaPropiedades()

            PropINTIDCAMARA = Nothing
            PropINTCODMARCA = Nothing
            PropVCHMODELO = Nothing
            PropVCHNROSERIE = Nothing
            PropINTCODCOVV = Nothing
            PropVCHIPCAMARA = Nothing
            PropVCHLAT = Nothing
            PropVCHLON = Nothing
            PropGEOM = Nothing
            PropVCHCODAREA = Nothing
            PropVCHCODSECTOR = Nothing
            PropVCHSSECVECINAL = Nothing
            PropVCHCODCUADRANTE = Nothing
            PropVCHCODAXXON = Nothing
            PropVCHUBICACION = Nothing
            PropVCHURBANIZACION = Nothing
            PropTXTESTADO = Nothing
            PropVCHOBSERVA = Nothing
            PropINTCODESTADO = Nothing
            PropVCHAUDUSUARIOCREA = Nothing
            PropVCHAUDEQUIPOCREA = Nothing
            PropTMSAUDFECHACREA = Nothing
            PropVCHAUDUSUARIOMODIF = Nothing
            PropVCHAUDEQUIPOMODIF = Nothing
            PropTMSAUDFECHAMODIF = Nothing

        End Sub

    End Class
End Namespace
