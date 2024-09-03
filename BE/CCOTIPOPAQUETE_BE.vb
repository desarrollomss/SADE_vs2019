Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOTIPOPAQUETE_BE

		Private intpaqcodigo As Nullable(Of Integer)
		Private vctpaqdescripcion As String
		Private intpaqestado As String

		Public Property PropPAQCODIGO() As Nullable(Of Integer)
		  Get
			  Return intpaqcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intpaqcodigo = value
		  End Set
		End Property
		Public Property PropPAQDESCRIPCION() As String
		  Get
			  Return vctpaqdescripcion
		  End Get
		  Set(ByVal value As String)
			  vctpaqdescripcion = value
		  End Set
		End Property
		Public Property PropPAQESTADO() As String
		  Get
			  Return intpaqestado
		  End Get
		  Set(ByVal value As String)
			  intpaqestado = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropPAQCODIGO = Nothing
			PropPAQDESCRIPCION = Nothing
			PropPAQESTADO = Nothing
		End Sub

	End Class
End Namespace
