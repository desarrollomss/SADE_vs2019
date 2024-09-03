Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOPAQUETERECURSO_BE

		Private intpqrcodigo As Nullable(Of Integer)
		Private intpaqcodigo As Nullable(Of Integer)
		Private intreccodigo As Nullable(Of Integer)

		Public Property PropPQRCODIGO() As Nullable(Of Integer)
		  Get
			  Return intpqrcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpqrcodigo = value
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
		Public Property PropRECCODIGO() As Nullable(Of Integer)
		  Get
			  Return intreccodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intreccodigo = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropPQRCODIGO = Nothing
			PropPAQCODIGO = Nothing
			PropRECCODIGO = Nothing
		End Sub

	End Class
End Namespace
