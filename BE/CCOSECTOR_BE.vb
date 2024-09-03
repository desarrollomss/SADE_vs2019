Imports System

Namespace BE

	<Serializable()> _
	Public Class CCOSECTOR_BE

        Private intseccodigo As Nullable(Of Integer)
        Private vchseccodigo As String
		Private vchsecdescripcion As String
		Private intsecestado As Nullable(Of Integer)

		Public Property PropSECCODIGO() As Nullable(Of Integer)
		  Get
			  Return intseccodigo
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intseccodigo = value
		  End Set
		End Property
		Public Property PropSECDESCRIPCION() As String
		  Get
			  Return vchsecdescripcion
		  End Get
		  Set(ByVal value As String)
			  vchsecdescripcion = value
		  End Set
		End Property
		Public Property PropSECESTADO() As Nullable(Of Integer)
		  Get
			  Return intsecestado
		  End Get
		  Set(ByVal value As Nullable(Of Integer))
			  intsecestado = value
		  End Set
		End Property

        Public Property PropCSECCODIGO() As String
            Get
                Return vchseccodigo
            End Get
            Set(ByVal value As String)
                vchseccodigo = value
            End Set
        End Property


		Public Sub New()
			LimpiaPropiedades()
		End Sub

		Public Sub LimpiaPropiedades()
			PropSECCODIGO = Nothing
			PropSECDESCRIPCION = Nothing
            PropSECESTADO = Nothing
            PropCSECCODIGO = Nothing
		End Sub

	End Class
End Namespace
