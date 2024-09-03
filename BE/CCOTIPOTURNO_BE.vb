Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOTIPOTURNO_BE

		Private intttucodigo As Nullable(Of Integer)
		Private vchttudescripción As String

		Public Property PropTTUCODIGO() As Nullable(Of Integer)
		  Get
			  Return intttucodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intttucodigo = value
		  End Set
		End Property
		Public Property PropTTUDESCRIPCIÓN() As String
		  Get
			  Return vchttudescripción
		  End Get
		  Set(ByVal value As String)
			  vchttudescripción = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropTTUCODIGO = Nothing
			PropTTUDESCRIPCIÓN = Nothing
		End Sub

	End Class
End Namespace
