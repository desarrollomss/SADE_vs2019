Imports System

Namespace BE

    <Serializable()> _
    Public Class GPSPOSICION_BE

        Private _intposid As Nullable(Of Int64)
        Private _intissi As Nullable(Of Integer)
        Private _decposlon As String
        Private _decposlat As String
        Private _datposfreg As String
        Private _vchcodunidad As String
        Private _intinccodigo As Nullable(Of Integer)
        Private _vchestcod As String
        Private _vchposcodhu As String
        Private _vchposdenhu As String
        Private _vchposcodvia As String
        Private _vchposnomvia As String
        Private _vchposcdavia As String
        Private _vchposxgeo As String
        Private _vchposygeo As String
        Private _vchposcdte As String
        Private _vchpossector As String
        Private _vchestdesc As String
        Private _vchestrad As String
        Private _vchestnimg As String
        Private _vchestcweb As String
        Private _intreccodigo As Nullable(Of Integer)
        Private _vchrecdescripcion As String
        Private _smltrecodigo As Nullable(Of Integer)
        Private _vchtredescripcion As String
        Private _smlseccodigo As Nullable(Of Integer)
        Private _vchseccodigo As String


        Public Property INTPOSID() As Nullable(Of Int64)
            Get
                Return _intposid
            End Get
            Set(ByVal value As Nullable(Of Int64))
                _intposid = value
            End Set
        End Property
        Public Property INTISSI() As Nullable(Of Integer)
            Get
                Return _intissi
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _intissi = value
            End Set
        End Property
        Public Property DECPOSLON() As String
            Get
                Return _decposlon
            End Get
            Set(ByVal value As String)
                _decposlon = value
            End Set
        End Property
        Public Property DECPOSLAT() As String
            Get
                Return _decposlat
            End Get
            Set(ByVal value As String)
                _decposlat = value
            End Set
        End Property
        Public Property DATPOSFREG() As String
            Get
                Return _datposfreg
            End Get
            Set(ByVal value As String)
                _datposfreg = value
            End Set
        End Property

        Public Property VCHCODUNIDAD() As String
            Get
                Return _vchcodunidad
            End Get
            Set(ByVal value As String)
                _vchcodunidad = value
            End Set
        End Property

        Public Property INTINCCODIGO() As Nullable(Of Integer)
            Get
                Return _intinccodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _intinccodigo = value
            End Set
        End Property

        Public Property VCHESTCOD() As String
            Get
                Return _vchestcod
            End Get
            Set(ByVal value As String)
                _vchestcod = value
            End Set
        End Property

        Public Property VCHPOSCODHU() As String
            Get
                Return _vchposcodhu
            End Get
            Set(ByVal value As String)
                _vchposcodhu = value
            End Set
        End Property
        Public Property VCHPOSDENHU() As String
            Get
                Return _vchposdenhu
            End Get
            Set(ByVal value As String)
                _vchposdenhu = value
            End Set
        End Property
        Public Property VCHPOSCODVIA() As String
            Get
                Return _vchposcodvia
            End Get
            Set(ByVal value As String)
                _vchposcodvia = value
            End Set
        End Property
        Public Property VCHPOSNOMVIA() As String
            Get
                Return _vchposnomvia
            End Get
            Set(ByVal value As String)
                _vchposnomvia = value
            End Set
        End Property
        Public Property VCHPOSCDAVIA() As String
            Get
                Return _vchposcdavia
            End Get
            Set(ByVal value As String)
                _vchposcdavia = value
            End Set
        End Property
        Public Property VCHPOSXGEO() As String
            Get
                Return _vchposxgeo
            End Get
            Set(ByVal value As String)
                _vchposxgeo = value
            End Set
        End Property
        Public Property VCHPOSYGEO() As String
            Get
                Return _vchposygeo
            End Get
            Set(ByVal value As String)
                _vchposygeo = value
            End Set
        End Property
        Public Property VCHPOSCDTE() As String
            Get
                Return _vchposcdte
            End Get
            Set(ByVal value As String)
                _vchposcdte = value
            End Set
        End Property
        Public Property VCHPOSSECTOR() As String
            Get
                Return _vchpossector
            End Get
            Set(ByVal value As String)
                _vchpossector = value
            End Set
        End Property
        Public Property VCHESTDESC() As String
            Get
                Return _vchestdesc
            End Get
            Set(ByVal value As String)
                _vchestdesc = value
            End Set
        End Property
        Public Property VCHESTRAD() As String
            Get
                Return _vchestrad
            End Get
            Set(ByVal value As String)
                _vchestrad = value
            End Set
        End Property
        Public Property VCHESTNIMG() As String
            Get
                Return _vchestnimg
            End Get
            Set(ByVal value As String)
                _vchestnimg = value
            End Set
        End Property
        Public Property VCHESTCWEB() As String
            Get
                Return _vchestcweb
            End Get
            Set(ByVal value As String)
                _vchestcweb = value
            End Set
        End Property

        Public Property INTRECCODIGO As Nullable(Of Integer)
            Get
                Return _intreccodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _intreccodigo = value
            End Set
        End Property

        Public Property VCHRECDESCRIPCION As String
            Get
                Return _vchrecdescripcion
            End Get
            Set(ByVal value As String)
                _vchrecdescripcion = value
            End Set
        End Property

        Public Property SMLTRECODIGO As Nullable(Of Integer)
            Get
                Return _smltrecodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _smltrecodigo = value
            End Set
        End Property

        Public Property VCHTREDESCRIPCION As String
            Get
                Return _vchtredescripcion
            End Get
            Set(ByVal value As String)
                _vchtredescripcion = value
            End Set
        End Property

        Public Property SMLSECCODIGO As Nullable(Of Integer)
            Get
                Return _smlseccodigo
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _smlseccodigo = value
            End Set
        End Property

        Public Property VCHSECCODIGO As String
            Get
                Return _vchseccodigo
            End Get
            Set(ByVal value As String)
                _vchseccodigo = value
            End Set
        End Property

        Public Sub New()
            LimpiaPropiedades()
        End Sub

        Public Sub LimpiaPropiedades()
            INTPOSID = Nothing
            INTISSI = Nothing
            DECPOSLON = Nothing
            DECPOSLAT = Nothing
            VCHCODUNIDAD = Nothing
            DATPOSFREG = Nothing
            VCHESTCOD = Nothing
            VCHPOSCODHU = Nothing
            VCHPOSDENHU = Nothing
            VCHPOSCODVIA = Nothing
            VCHPOSNOMVIA = Nothing
            VCHPOSCDAVIA = Nothing
            VCHPOSXGEO = Nothing
            VCHPOSYGEO = Nothing
            VCHPOSCDTE = Nothing
            VCHPOSSECTOR = Nothing
            VCHESTDESC = Nothing
            VCHESTRAD = Nothing
            VCHESTNIMG = Nothing
            VCHESTCWEB = Nothing
            INTRECCODIGO = Nothing
            VCHRECDESCRIPCION = Nothing
            SMLTRECODIGO = Nothing
            VCHTREDESCRIPCION = Nothing
            SMLSECCODIGO = Nothing
            VCHSECCODIGO = Nothing

        End Sub

    End Class
End Namespace
