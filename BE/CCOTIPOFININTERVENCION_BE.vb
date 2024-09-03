Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOTIPOFININTERVENCION_BE

		Private intintcodigo As Nullable(Of Integer)
		Private vchintdescripcion As String

		Public Property PropINTCODIGO() As Nullable(Of Integer)
		  Get
			  Return intintcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intintcodigo = value
		  End Set
		End Property
		Public Property PropINTDESCRIPCION() As String
		  Get
			  Return vchintdescripcion
		  End Get
		  Set(ByVal value As String)
			  vchintdescripcion = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropINTCODIGO = Nothing
			PropINTDESCRIPCION = Nothing
		End Sub

	End Class
End Namespace
