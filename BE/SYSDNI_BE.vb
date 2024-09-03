Imports System

Namespace BE

    <Serializable()> _
    Public Class SYSDNI_BE

        Private p_saVCHDNI As String
        Private p_saVCHAPEPAT As String
        Private p_saVCHAPEMAT As String
        Private p_saVCHNOMBRES As String
        Private p_saVCHFECNAC As String
        Private p_saVCHNOMBRECOMPLETO As String
        Private p_sastrdesvaloropc1 As String
        Private p_sastrdesvaloropc2 As String

        Public Property p_VCHDNI As String
            Get
                Return p_saVCHDNI
            End Get
            Set(ByVal value As String)
                p_saVCHDNI = value
            End Set
        End Property

        Public Property p_VCHAPEPAT As String
            Get
                Return p_saVCHAPEPAT
            End Get
            Set(ByVal value As String)
                p_saVCHAPEPAT = value
            End Set
        End Property

        Public Property p_VCHAPEMAT As String
            Get
                Return p_saVCHAPEMAT
            End Get
            Set(ByVal value As String)
                p_saVCHAPEMAT = value
            End Set
        End Property

        Public Property p_VCHNOMBRES As String
            Get
                Return p_saVCHNOMBRES
            End Get
            Set(ByVal value As String)
                p_saVCHNOMBRES = value
            End Set
        End Property


        Public Property p_VCHFECNAC As String
            Get
                Return p_saVCHFECNAC
            End Get
            Set(ByVal value As String)
                p_saVCHFECNAC = value
            End Set
        End Property

        Public Property p_VCHNOMBRECOMPLETO As String
            Get
                Return p_saVCHNOMBRECOMPLETO
            End Get
            Set(ByVal value As String)
                p_saVCHNOMBRECOMPLETO = value
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

            p_VCHDNI = Nothing
            p_VCHAPEPAT = Nothing
            p_VCHAPEMAT = Nothing
            p_VCHNOMBRES = Nothing
            p_VCHFECNAC = Nothing
            p_VCHNOMBRECOMPLETO = Nothing
            p_strdesvaloropc1 = Nothing
            p_strdesvaloropc2 = Nothing
        End Sub

    End Class
End Namespace
