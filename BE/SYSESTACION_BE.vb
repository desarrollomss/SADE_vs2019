Imports System

Namespace BE

	<Serializable()> _
	Public Class SYSESTACION_BE

		Private vchextension As String
		Private vchidllamada As String
		Private vchnumorigen As String
		Private intinccodigo As Nullable(Of Integer)
		Private smlconectado As Nullable(Of Int16)

		Public Property PropEXTENSION() As String
		  Get
			  Return vchextension
		  End Get
		  Set(ByVal value As String)
			  vchextension = value
		  End Set
		End Property
		Public Property PropIDLLAMADA() As String
		  Get
			  Return vchidllamada
		  End Get
		  Set(ByVal value As String)
			  vchidllamada = value
		  End Set
		End Property
		Public Property PropNUMORIGEN() As String
		  Get
			  Return vchnumorigen
		  End Get
		  Set(ByVal value As String)
			  vchnumorigen = value
		  End Set
		End Property
		Public Property PropINCCODIGO() As Nullable(Of Integer)
		  Get
			  Return intinccodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intinccodigo = value
		  End Set
		End Property
		Public Property PropCONECTADO() As Nullable(Of Int16)
		  Get
			  Return smlconectado
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlconectado = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropEXTENSION = Nothing
			PropIDLLAMADA = Nothing
			PropNUMORIGEN = Nothing
			PropINCCODIGO = Nothing
			PropCONECTADO = Nothing
		End Sub

	End Class
End Namespace
