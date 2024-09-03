Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOCARGO_BE

		Private intcrgcodigo As Nullable(Of Integer)
		Private vchcrgdescripcion As String
		Private intcrgestado As Nullable(Of Integer)
		Private intttucodigo As Nullable(Of Integer)

		Public Property PropCRGCODIGO() As Nullable(Of Integer)
		  Get
			  Return intcrgcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intcrgcodigo = value
		  End Set
		End Property
		Public Property PropCRGDESCRIPCION() As String
		  Get
			  Return vchcrgdescripcion
		  End Get
		  Set(ByVal value As String)
			  vchcrgdescripcion = value
		  End Set
		End Property
		Public Property PropCRGESTADO() As Nullable(Of Integer)
		  Get
			  Return intcrgestado
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intcrgestado = value
		  End Set
		End Property
		Public Property PropTTUCODIGO() As Nullable(Of Integer)
		  Get
			  Return intttucodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intttucodigo = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropCRGCODIGO = Nothing
			PropCRGDESCRIPCION = Nothing
			PropCRGESTADO = Nothing
			PropTTUCODIGO = Nothing
		End Sub

	End Class
End Namespace
