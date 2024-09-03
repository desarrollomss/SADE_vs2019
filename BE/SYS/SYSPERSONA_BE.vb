Imports System

Namespace BE

    <Serializable()> _
    Public Class SYSPERSONA_BE

        Private p_saINTADMCODIGO As Nullable(Of Integer)
        Private p_saVCHADMAPEPAT As String
        Private p_saVCHADMAPEMAT As String
        Private p_saVCHADMNOMBRES As String
        Private p_saVCHADMCOMPLETO As String
        Private p_saVCHADMTIPDOC As String
        Private p_saVCHADMNUMDOC As String
        Private p_sastrdesvaloropc1 As String
        Private p_sastrdesvaloropc2 As String

        Public Property p_INTADMCODIGO() As Nullable(Of Integer)
            Get
                Return p_saINTADMCODIGO
            End Get
            Set(ByVal value As Nullable(Of Integer))
                p_saINTADMCODIGO = value
            End Set
        End Property

        Public Property p_VCHADMAPEPAT As String
            Get
                Return p_saVCHADMAPEPAT
            End Get
            Set(ByVal value As String)
                p_saVCHADMAPEPAT = value
            End Set
        End Property

        Public Property p_VCHADMAPEMAT As String
            Get
                Return p_saVCHADMAPEMAT
            End Get
            Set(ByVal value As String)
                p_saVCHADMAPEMAT = value
            End Set
        End Property

        Public Property p_VCHADMNOMBRES As String
            Get
                Return p_saVCHADMNOMBRES
            End Get
            Set(ByVal value As String)
                p_saVCHADMNOMBRES = value
            End Set
        End Property

        Public Property p_VCHADMCOMPLETO As String
            Get
                Return p_saVCHADMCOMPLETO
            End Get
            Set(ByVal value As String)
                p_saVCHADMCOMPLETO = value
            End Set
        End Property

        Public Property p_VCHADMTIPDOC As String
            Get
                Return p_saVCHADMTIPDOC
            End Get
            Set(ByVal value As String)
                p_saVCHADMTIPDOC = value
            End Set
        End Property
        Public Property p_VCHADMNUMDOC As String
            Get
                Return p_saVCHADMNUMDOC
            End Get
            Set(ByVal value As String)
                p_saVCHADMNUMDOC = value
            End Set
        End Property

        Public Property p_strdesvaloropc1 As String
            Get
                Return p_sastrdesvaloropc1
            End Get
            Set(ByVal value As String)
                p_sastrdesvaloropc1 = value
            End Set
        End Property
        Public Property p_strdesvaloropc2 As String
            Get
                Return p_sastrdesvaloropc2
            End Get
            Set(ByVal value As String)
                p_sastrdesvaloropc2 = value
            End Set
        End Property


        Public Sub New()
            LimpiaPropiedades()
        End Sub

        Public Sub LimpiaPropiedades()

            p_INTADMCODIGO = Nothing
            p_VCHADMAPEPAT = Nothing
            p_VCHADMAPEMAT = Nothing
            p_VCHADMNOMBRES = Nothing
            p_VCHADMCOMPLETO = Nothing
            p_VCHADMTIPDOC = Nothing
            p_VCHADMNUMDOC = Nothing
            p_strdesvaloropc1 = Nothing
            p_strdesvaloropc2 = Nothing
        End Sub

    End Class
End Namespace
