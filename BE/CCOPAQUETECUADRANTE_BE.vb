Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOPAQUETECUADRANTE_BE

		Private intpqccodigo As Nullable(Of Integer)
		Private intpaqcodigo As Nullable(Of Integer)
		Private smlseccodigo As Nullable(Of Integer)
		Private smlcuacodigo As Nullable(Of Integer)
		Private smlpficodigo As Nullable(Of Int16)

		Public Property PropPQCCODIGO() As Nullable(Of Integer)
		  Get
			  Return intpqccodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpqccodigo = value
		  End Set
		End Property
		Public Property PropPAQCODIGO() As Nullable(Of Integer)
		  Get
			  Return intpaqcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpaqcodigo = value
		  End Set
		End Property
		Public Property PropSECCODIGO() As Nullable(Of Integer)
		  Get
			  Return smlseccodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  smlseccodigo = value
		  End Set
		End Property
		Public Property PropCUACODIGO() As Nullable(Of Integer)
		  Get
			  Return smlcuacodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  smlcuacodigo = value
		  End Set
		End Property
		Public Property PropPFICODIGO() As Nullable(Of Int16)
		  Get
			  Return smlpficodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlpficodigo = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropPQCCODIGO = Nothing
			PropPAQCODIGO = Nothing
			PropSECCODIGO = Nothing
			PropCUACODIGO = Nothing
			PropPFICODIGO = Nothing
		End Sub

	End Class
End Namespace
