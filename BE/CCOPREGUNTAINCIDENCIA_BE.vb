Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOPREGUNTAINCIDENCIA_BE

		Private smlprgcodigo As Nullable(Of Int16)
		Private vchprgdescripcion As String
		Private smlprgestado As Nullable(Of Int16)
		Private smltrecodigo As Nullable(Of Int16)
		Private smlsticodigo As Nullable(Of Int16)

		Public Property PropPRGCODIGO() As Nullable(Of Int16)
		  Get
			  Return smlprgcodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlprgcodigo = value
		  End Set
		End Property
		Public Property PropPRGDESCRIPCION() As String
		  Get
			  Return vchprgdescripcion
		  End Get
		  Set(ByVal value As String)
			  vchprgdescripcion = value
		  End Set
		End Property
		Public Property PropPRGESTADO() As Nullable(Of Int16)
		  Get
			  Return smlprgestado
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlprgestado = value
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
		Public Property PropSTICODIGO() As Nullable(Of Int16)
		  Get
			  Return smlsticodigo
		  End Get
		  Set(ByVal value As Nullable(Of Int16))
			  smlsticodigo = value
		  End Set
		End Property

		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropPRGCODIGO = Nothing
			PropPRGDESCRIPCION = Nothing
			PropPRGESTADO = Nothing
			PropTRECODIGO = Nothing
			PropSTICODIGO = Nothing
		End Sub

	End Class
End Namespace
