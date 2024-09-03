Imports System

Namespace BE
    <Serializable()> _
    Public Class FISPREDIO_BE
        Private intregcodigo As Nullable(Of Integer)
        Private vchcodlote As String
        Private intucatid As Integer
        Private intcodpre As Integer
        Private vchcodcat As String
        Private vchcodsec As String
        Private vchcodurb As String
        Private vchcodvia As String
        Private vchnumpri As String
        Private vchtippta As String
        Private vchnumint As String
        Private vchedific As String
        Private vchaudusucreacion As String
        Private dataudfeccreacion As DateTime
        Private vchaudusumodif As String
        Private dataudfecmodif As DateTime
        Private vchaudequipo As String
        Private vchaudprograma As String
        Private vchsubsector As String
        Private smlfisestado As Nullable(Of Int16)
        Private smlfisdeuda As Nullable(Of Int16)
        Private decfisdeuda As Nullable(Of Decimal)
        Private smlfismulta As Nullable(Of Int16)
        Private decfismulta As Nullable(Of Decimal)
        Private vchfisoserv As String



        Public Property p_INTREGCODIGO As Nullable(Of Integer)
            Get
                Return intregcodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                intregcodigo = value
            End Set
        End Property

        Public Property p_VCHCODLOTE As String
            Get
                Return vchcodlote
            End Get
            Set(ByVal value As String)
                vchcodlote = value
            End Set
        End Property

        Public Property p_INTUCATID As Integer
            Get
                Return intucatid
            End Get
            Set(ByVal value As Integer)
                intucatid = value
            End Set
        End Property

        Public Property p_INTCODPRE As Integer
            Get
                Return intcodpre
            End Get
            Set(ByVal value As Integer)
                intcodpre = value
            End Set
        End Property

        Public Property p_VCHCODCAT As String
            Get
                Return vchcodcat
            End Get
            Set(ByVal value As String)
                vchcodcat = value
            End Set
        End Property

        Public Property p_VCHCODSEC As String
            Get
                Return vchcodsec
            End Get
            Set(ByVal value As String)
                vchcodsec = value
            End Set
        End Property

        Public Property p_VCHCODURB As String
            Get
                Return vchcodurb
            End Get
            Set(ByVal value As String)
                vchcodurb = value
            End Set
        End Property

        Public Property p_VCHCODVIA As String
            Get
                Return vchcodvia
            End Get
            Set(ByVal value As String)
                vchcodvia = value
            End Set
        End Property

        Public Property p_VCHNUMPRI As String
            Get
                Return vchnumpri
            End Get
            Set(ByVal value As String)
                vchnumpri = value
            End Set
        End Property

        Public Property p_VCHTIPPTA As String
            Get
                Return vchtippta
            End Get
            Set(ByVal value As String)
                vchtippta = value
            End Set
        End Property

        Public Property p_VCHNUMINT As String
            Get
                Return vchnumint
            End Get
            Set(ByVal value As String)
                vchnumint = value
            End Set
        End Property

        Public Property p_VCHEDIFIC As String
            Get
                Return vchedific
            End Get
            Set(ByVal value As String)
                vchedific = value
            End Set
        End Property

        Public Property p_VCHAUDUSUCREACION As String
            Get
                Return vchaudusucreacion
            End Get
            Set(ByVal value As String)
                vchaudusucreacion = value
            End Set
        End Property

        Public Property p_DATAUDFECCREACION As DateTime
            Get
                Return dataudfeccreacion
            End Get
            Set(ByVal value As DateTime)
                dataudfeccreacion = value
            End Set
        End Property

        Public Property p_VCHAUDUSUMODIF As String
            Get
                Return vchaudusumodif
            End Get
            Set(ByVal value As String)
                vchaudusumodif = value
            End Set
        End Property

        Public Property p_DATAUDFECMODIF As DateTime
            Get
                Return dataudfecmodif
            End Get
            Set(ByVal value As DateTime)
                dataudfecmodif = value
            End Set
        End Property

        Public Property p_VCHAUDEQUIPO As String
            Get
                Return vchaudequipo
            End Get
            Set(ByVal value As String)
                vchaudequipo = value
            End Set
        End Property

        Public Property p_VCHAUDPROGRAMA As String
            Get
                Return vchaudprograma
            End Get
            Set(ByVal value As String)
                vchaudprograma = value
            End Set
        End Property

        Public Property p_VCHSUBSECTOR As String
            Get
                Return vchsubsector
            End Get
            Set(ByVal value As String)
                vchsubsector = value
            End Set
        End Property

        Public Property p_SMLFISESTADO As Nullable(Of Int16)
            Get
                Return smlfisestado
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlfisestado = value
            End Set
        End Property

        Public Property p_SMLFISDEUDA As Nullable(Of Int16)
            Get
                Return smlfisdeuda
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlfisdeuda = value
            End Set
        End Property

        Public Property p_DECFISDEUDA As Nullable(Of Decimal)
            Get
                Return decfisdeuda
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                decfisdeuda = value
            End Set
        End Property

        Public Property p_SMLFISMULTA As Nullable(Of Int16)
            Get
                Return smlfismulta
            End Get
            Set(ByVal value As Nullable(Of Int16))
                smlfismulta = value
            End Set
        End Property

        Public Property p_DECFISMULTA As Nullable(Of Decimal)
            Get
                Return decfismulta
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                decfismulta = value
            End Set
        End Property

        Public Property p_VCHFISOSERV As String
            Get
                Return vchfisoserv
            End Get
            Set(ByVal value As String)
                vchfisoserv = value
            End Set
        End Property

        Public Sub LimpiaPropiedades()
            p_INTREGCODIGO = Nothing
            p_VCHCODLOTE = Nothing
            p_INTUCATID = Nothing
            p_INTCODPRE = Nothing
            p_VCHCODCAT = Nothing
            p_VCHCODSEC = Nothing
            p_VCHCODURB = Nothing
            p_VCHCODVIA = Nothing
            p_VCHNUMPRI = Nothing
            p_VCHTIPPTA = Nothing
            p_VCHNUMINT = Nothing
            p_VCHEDIFIC = Nothing
            p_VCHAUDUSUCREACION = Nothing
            p_DATAUDFECCREACION = Nothing
            p_VCHAUDUSUMODIF = Nothing
            p_DATAUDFECMODIF = Nothing
            p_VCHAUDEQUIPO = Nothing
            p_VCHAUDPROGRAMA = Nothing
            p_VCHSUBSECTOR = Nothing
            p_SMLFISESTADO = Nothing
            p_SMLFISDEUDA = Nothing
            p_DECFISDEUDA = Nothing
            p_SMLFISMULTA = Nothing
            p_DECFISMULTA = Nothing
            p_VCHFISOSERV = Nothing
        End Sub


    End Class

End Namespace

