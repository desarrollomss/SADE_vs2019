Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOPAQUETEPERSONAL_BE

		Private intpqpcodigo As Nullable(Of Integer)
		Private intpaqcodigo As Nullable(Of Integer)
		Private intpercodigo As Nullable(Of Integer)
		Private smlpqpresponsable As Nullable(Of Int16)

		Public Property PropPQPCODIGO() As Nullable(Of Integer)
		  Get
			  Return intpqpcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpqpcodigo = value
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
		Public Property PropPERCODIGO() As Nullable(Of Integer)
		  Get
			  Return intpercodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpercodigo = value
		  End Set
		End Property
		Public Property PropPQPRESPONSABLE() As Nullable(Of Int16)
		  Get
			  Return smlpqpresponsable
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlpqpresponsable = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropPQPCODIGO = Nothing
			PropPAQCODIGO = Nothing
			PropPERCODIGO = Nothing
			PropPQPRESPONSABLE = Nothing
		End Sub

	End Class
End Namespace
