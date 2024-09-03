Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOALTERNATIVARESPUESTA_BE

		Private smlaltcodigo As Nullable(Of Int16)
		Private vchaltdescripcion As String
		Private smltrecodigo As Nullable(Of Int16)

		Public Property PropALTCODIGO() As Nullable(Of Int16)
		  Get
			  Return smlaltcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlaltcodigo = value
		  End Set
		End Property
		Public Property PropALTDESCRIPCION() As String
		  Get
			  Return vchaltdescripcion
		  End Get
		  Set(ByVal value As String)
			  vchaltdescripcion = value
		  End Set
		End Property
		Public Property PropTRECODIGO() As Nullable(Of Int16)
		  Get
			  Return smltrecodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smltrecodigo = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropALTCODIGO = Nothing
			PropALTDESCRIPCION = Nothing
			PropTRECODIGO = Nothing
		End Sub

	End Class
End Namespace
