Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOINCIDENCIAHISTORIAL_BE

		Private inthiscodigo As Nullable(Of Integer)
		Private intinccodigo As Nullable(Of Integer)
		Private vchhisusuario As String
		Private inthisrolusuario As Nullable(Of Integer)
		Private dtmhisfechahora As DateTime
		Private vchhisequipo As String
		Private vchhisprograma As String
		Private vchhisoperacion As String
		Private intinrcodigo As Nullable(Of Integer)
		Private vchhiscomentario As String

		Public Property PropHISCODIGO() As Nullable(Of Integer)
		  Get
			  Return inthiscodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  inthiscodigo = value
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
		Public Property PropHISUSUARIO() As String
		  Get
			  Return vchhisusuario
		  End Get
		  Set(ByVal value As String)
			  vchhisusuario = value
		  End Set
		End Property
		Public Property PropHISROLUSUARIO() As Nullable(Of Integer)
		  Get
			  Return inthisrolusuario
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  inthisrolusuario = value
		  End Set
		End Property
		Public Property PropHISFECHAHORA() As DateTime
		  Get
			  Return dtmhisfechahora
		  End Get
		  Set(ByVal value As DateTime)
			  dtmhisfechahora = value
		  End Set
		End Property
		Public Property PropHISEQUIPO() As String
		  Get
			  Return vchhisequipo
		  End Get
		  Set(ByVal value As String)
			  vchhisequipo = value
		  End Set
		End Property
		Public Property PropHISPROGRAMA() As String
		  Get
			  Return vchhisprograma
		  End Get
		  Set(ByVal value As String)
			  vchhisprograma = value
		  End Set
		End Property
		Public Property PropHISOPERACION() As String
		  Get
			  Return vchhisoperacion
		  End Get
		  Set(ByVal value As String)
			  vchhisoperacion = value
		  End Set
		End Property
		Public Property PropINRCODIGO() As Nullable(Of Integer)
		  Get
			  Return intinrcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intinrcodigo = value
		  End Set
		End Property
		Public Property PropHISCOMENTARIO() As String
		  Get
			  Return vchhiscomentario
		  End Get
		  Set(ByVal value As String)
			  vchhiscomentario = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropHISCODIGO = Nothing
			PropINCCODIGO = Nothing
			PropHISUSUARIO = Nothing
			PropHISROLUSUARIO = Nothing
			PropHISFECHAHORA = Now.Date
			PropHISEQUIPO = Nothing
			PropHISPROGRAMA = Nothing
			PropHISOPERACION = Nothing
			PropINRCODIGO = Nothing
			PropHISCOMENTARIO = Nothing
		End Sub

	End Class
End Namespace
