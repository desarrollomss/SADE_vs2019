Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOOBJETIVOINCIDENCIA_BE

		Private intobjcodigo As Nullable(Of Integer)
		Private vchobjdescripcion As String

		Public Property PropOBJCODIGO() As Nullable(Of Integer)
		  Get
			  Return intobjcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intobjcodigo = value
		  End Set
		End Property
		Public Property PropOBJDESCRIPCION() As String
		  Get
			  Return vchobjdescripcion
		  End Get
		  Set(ByVal value As String)
			  vchobjdescripcion = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropOBJCODIGO = Nothing
			PropOBJDESCRIPCION = Nothing
		End Sub

	End Class
End Namespace
