Imports System

Namespace BE

	<Serializable()> _
	Public Class TB_COMPSEG_BE

		Private idcs As Nullable(Of Integer)
		Private direccion As String
        Private geom As String
		Private idcst As Nullable(Of Integer)
		Private idcse As Nullable(Of Integer)
		Private observ_est As String
		Private info_cs As String
		Private idcs_padre As Nullable(Of Integer)
		Private comunica_cs As String
		Private ipred_cs As String
        Private audusuario_crea As String
		Private audequipo_crea As String
        Private audfecha_crea As DateTime
        Private m_xGeo As String
        Private m_yGeo As String
        Private m_idcst As String
        Private m_idcse As String
        Private fecinst_cs As Date
        Private fecinstcs As String

        Public Property PropIDCS() As Nullable(Of Integer)
            Get
                Return idcs
            End Get
            Set(ByVal value As Nullable(Of Integer))
                idcs = value
            End Set
        End Property
        Public Property PropDIRECCION() As String
            Get
                Return direccion
            End Get
            Set(ByVal value As String)
                direccion = value
            End Set
        End Property
        Public Property PropGEOM() As String
            Get
                Return geom
            End Get
            Set(ByVal value As String)
                geom = value
            End Set
        End Property
        Public Property PropIDCST() As Nullable(Of Integer)
            Get
                Return idcst
            End Get
            Set(ByVal value As Nullable(Of Integer))
                idcst = value
            End Set
        End Property
        Public Property PropIDCSE() As Nullable(Of Integer)
            Get
                Return idcse
            End Get
            Set(ByVal value As Nullable(Of Integer))
                idcse = value
            End Set
        End Property
        Public Property PropOBSERV_EST() As String
            Get
                Return observ_est
            End Get
            Set(ByVal value As String)
                observ_est = value
            End Set
        End Property
        Public Property PropINFO_CS() As String
            Get
                Return info_cs
            End Get
            Set(ByVal value As String)
                info_cs = value
            End Set
        End Property
        Public Property PropIDCS_PADRE() As Nullable(Of Integer)
            Get
                Return idcs_padre
            End Get
            Set(ByVal value As Nullable(Of Integer))
                idcs_padre = value
            End Set
        End Property
        Public Property PropCOMUNICA_CS() As String
            Get
                Return comunica_cs
            End Get
            Set(ByVal value As String)
                comunica_cs = value
            End Set
        End Property
        Public Property PropIPRED_CS() As String
            Get
                Return ipred_cs
            End Get
            Set(ByVal value As String)
                ipred_cs = value
            End Set
        End Property
        Public Property PropAUDUSUARIO_CREA() As String
            Get
                Return audusuario_crea
            End Get
            Set(ByVal value As String)
                audusuario_crea = value
            End Set
        End Property
        Public Property PropAUDEQUIPO_CREA() As String
            Get
                Return audequipo_crea
            End Get
            Set(ByVal value As String)
                audequipo_crea = value
            End Set
        End Property
        Public Property PropAUDFECHA_CREA() As DateTime
            Get
                Return audfecha_crea
            End Get
            Set(ByVal value As DateTime)
                audfecha_crea = value
            End Set
        End Property

        Public Property PropGeoX() As String
            Get
                Return m_xGeo
            End Get
            Set(ByVal value As String)
                m_xGeo = value
            End Set
        End Property

        Public Property PropGeoY() As String
            Get
                Return m_yGeo
            End Get
            Set(ByVal value As String)
                m_yGeo = value
            End Set
        End Property

        Public Property PropDIDCST() As String
            Get
                Return m_idcst
            End Get
            Set(ByVal value As String)
                m_idcst = value
            End Set
        End Property

        Public Property PropDIDCSE() As String
            Get
                Return m_idcse
            End Get
            Set(ByVal value As String)
                m_idcse = value
            End Set
        End Property

        Public Property PropFECINST_CS() As Date
            Get
                Return fecinst_cs
            End Get
            Set(ByVal value As Date)
                fecinst_cs = value
            End Set
        End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

        Public Property PropFECINSTCS() As String
            Get
                Return fecinstcs
            End Get
            Set(ByVal value As String)
                fecinstcs = value
            End Set
        End Property

		Public Sub LimpiaPropiedades()
            PropIDCS = Nothing
            PropDIRECCION = Nothing
            PropGEOM = Nothing
            PropIDCST = Nothing
            PropIDCSE = Nothing
            PropOBSERV_EST = Nothing
            PropINFO_CS = Nothing
            PropIDCS_PADRE = Nothing
            PropCOMUNICA_CS = Nothing
            PropIPRED_CS = Nothing
            PropAUDUSUARIO_CREA = Nothing
            PropAUDEQUIPO_CREA = Nothing
            PropAUDFECHA_CREA = Nothing
            PropGeoX = Nothing
            PropGeoY = Nothing
            PropDIDCST = Nothing
            PropDIDCSE = Nothing
            PropFECINST_CS = Nothing
            PropFECINSTCS = Nothing
        End Sub

	End Class
End Namespace
