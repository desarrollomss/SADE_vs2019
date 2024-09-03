Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOMENSAJEROLUSUARIO_BE

		Private introlcodigo As Nullable(Of Integer)
		Private intmjrcodigo As Nullable(Of Integer)
		Private intmsjcodigo As Nullable(Of Integer)

		Public Property PropROLCODIGO() As Nullable(Of Integer)
		  Get
			  Return introlcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  introlcodigo = value
		  End Set
		End Property
		Public Property PropMJRCODIGO() As Nullable(Of Integer)
		  Get
			  Return intmjrcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intmjrcodigo = value
		  End Set
		End Property
		Public Property PropMSJCODIGO() As Nullable(Of Integer)
		  Get
			  Return intmsjcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intmsjcodigo = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropROLCODIGO = Nothing
			PropMJRCODIGO = Nothing
			PropMSJCODIGO = Nothing
		End Sub

	End Class
End Namespace
