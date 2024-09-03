Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOPARAMETRO_BE

		Private vchparcodigo As String
		Private vchpardescripcion As String
		Private intparrelacion As Nullable(Of Integer)
		Private vchparrelacion As String

		Public Property PropPARCODIGO() As String
		  Get
			  Return vchparcodigo
		  End Get
		  Set(ByVal value As String)
			  vchparcodigo = value
		  End Set
		End Property
		Public Property PropPARDESCRIPCION() As String
		  Get
			  Return vchpardescripcion
		  End Get
		  Set(ByVal value As String)
			  vchpardescripcion = value
		  End Set
		End Property
		Public Property PropPARRELACION() As Nullable(Of Integer)
		  Get
			  Return intparrelacion
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intparrelacion = value
		  End Set
		End Property
        Public Property PropPARRELACIONC() As String
            Get
                Return vchparrelacion
            End Get
            Set(ByVal value As String)
                vchparrelacion = value
            End Set
        End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropPARCODIGO = Nothing
			PropPARDESCRIPCION = Nothing
			PropPARRELACION = Nothing
            PropPARRELACIONC = Nothing
		End Sub

	End Class
End Namespace
