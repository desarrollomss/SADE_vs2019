Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOPERSONALFAMILIA_BE

		Private intpfacodigo As Nullable(Of Integer)
		Private smlpfasecuencia As Nullable(Of Int16)
		Private vchpfanombre As String
		Private intpercodigo As Nullable(Of Integer)
		Private smlparcodigo As Nullable(Of Int16)

		Public Property PropPFACODIGO() As Nullable(Of Integer)
		  Get
			  Return intpfacodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpfacodigo = value
		  End Set
		End Property
		Public Property PropPFASECUENCIA() As Nullable(Of Int16)
		  Get
			  Return smlpfasecuencia
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlpfasecuencia = value
		  End Set
		End Property
		Public Property PropPFANOMBRE() As String
		  Get
			  Return vchpfanombre
		  End Get
		  Set(ByVal value As String)
			  vchpfanombre = value
		  End Set
		End Property
		Public Property PropPERCODIGO() As Nullable(Of Integer)
		  Get
			  Return intpercodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpercodigo = value
		  End Set
		End Property
		Public Property PropPARCODIGO() As Nullable(Of Int16)
		  Get
			  Return smlparcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlparcodigo = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropPFACODIGO = Nothing
			PropPFASECUENCIA = Nothing
			PropPFANOMBRE = Nothing
			PropPERCODIGO = Nothing
			PropPARCODIGO = Nothing
		End Sub

	End Class
End Namespace
