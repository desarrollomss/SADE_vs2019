Imports System

Namespace BE

    <Serializable()> _
    Public Class CCOINCIDENCIADEVICE_BE

        Private intINCCODIGO As Nullable(Of Integer)
        Private vchINCDEVSDK As String
        Private vchINCDEVMODEL As String
        Private vchINCDEVDEVICE As String
        Private vchINCDEVHOST As String
        Private vchINCDEVID As String
        Private vchINCDEVDISPLAY As String
        Private vchINCDEVMANUFAC As String
        Private vchINCDEVUSER As String
        Private dtmaudfeccreacion As DateTime
        Private vchaudusucreacion As String
        Private vchaudprgcreacion As String
        Private vchaudeqpcreacion As String


        Public Property PropINCCODIGO() As Nullable(Of Integer)
            Get
                Return intINCCODIGO
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intINCCODIGO = value
            End Set
        End Property

        Public Property PropINCDEVSDK() As String
            Get
                Return vchINCDEVSDK
            End Get
            Set(ByVal value As String)
                vchINCDEVSDK = value
            End Set
        End Property

        Public Property PropINCDEVMODEL() As String
            Get
                Return vchINCDEVMODEL
            End Get
            Set(ByVal value As String)
                vchINCDEVMODEL = value
            End Set
        End Property

        Public Property PropINCDEVDEVICE() As String
            Get
                Return vchINCDEVDEVICE
            End Get
            Set(ByVal value As String)
                vchINCDEVDEVICE = value
            End Set
        End Property

        Public Property PropINCDEVHOST() As String
            Get
                Return vchINCDEVHOST
            End Get
            Set(ByVal value As String)
                vchINCDEVHOST = value
            End Set
        End Property

        Public Property PropINCDEVID() As String
            Get
                Return vchINCDEVID
            End Get
            Set(ByVal value As String)
                vchINCDEVID = value
            End Set
        End Property

        Public Property PropINCDEVDISPLAY() As String
            Get
                Return vchINCDEVDISPLAY
            End Get
            Set(ByVal value As String)
                vchINCDEVDISPLAY = value
            End Set
        End Property

        Public Property PropINCDEVMANUFAC() As String
            Get
                Return vchINCDEVMANUFAC
            End Get
            Set(ByVal value As String)
                vchINCDEVMANUFAC = value
            End Set
        End Property

        Public Property PropINCDEVUSER() As String
            Get
                Return vchINCDEVUSER
            End Get
            Set(ByVal value As String)
                vchINCDEVUSER = value
            End Set
        End Property

        Public Property PropAUDFECCREACION() As DateTime
            Get
                Return dtmaudfeccreacion
            End Get
            Set(ByVal value As DateTime)
                dtmaudfeccreacion = value
            End Set
        End Property
        Public Property PropAUDUSUCREACION() As String
            Get
                Return vchaudusucreacion
            End Get
            Set(ByVal value As String)
                vchaudusucreacion = value
            End Set
        End Property
        Public Property PropAUDPRGCREACION() As String
            Get
                Return vchaudprgcreacion
            End Get
            Set(ByVal value As String)
                vchaudprgcreacion = value
            End Set
        End Property
        Public Property PropAUDEQPCREACION() As String
            Get
                Return vchaudeqpcreacion
            End Get
            Set(ByVal value As String)
                vchaudeqpcreacion = value
            End Set
        End Property
        Public Sub New()
            LimpiaPropiedades()
        End Sub

        Public Sub LimpiaPropiedades()
            PropINCCODIGO = Nothing
            PropINCDEVSDK = Nothing
            PropINCDEVMODEL = Nothing
            PropINCDEVDEVICE = Nothing
            PropINCDEVHOST = Nothing
            PropINCDEVID = Nothing
            PropINCDEVDISPLAY = Nothing
            PropINCDEVMANUFAC = Nothing
            PropINCDEVUSER = Nothing
            PropAUDFECCREACION = Now.Date
            PropAUDUSUCREACION = Nothing
            PropAUDPRGCREACION = Nothing
            PropAUDEQPCREACION = Nothing

        End Sub

    End Class
End Namespace
