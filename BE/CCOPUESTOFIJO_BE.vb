Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOPUESTOFIJO_BE

		Private intpficodigo As Nullable(Of Integer)
		Private vchpfiubicacion As String
		Private intseccodigo As Nullable(Of Integer)

		Public Property PropPFICODIGO() As Nullable(Of Integer)
		  Get
			  Return intpficodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpficodigo = value
		  End Set
		End Property
		Public Property PropPFIUBICACION() As String
		  Get
			  Return vchpfiubicacion
		  End Get
		  Set(ByVal value As String)
			  vchpfiubicacion = value
		  End Set
		End Property
		Public Property PropSECCODIGO() As Nullable(Of Integer)
		  Get
			  Return intseccodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intseccodigo = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropPFICODIGO = Nothing
			PropPFIUBICACION = Nothing
			PropSECCODIGO = Nothing
		End Sub

	End Class
End Namespace
