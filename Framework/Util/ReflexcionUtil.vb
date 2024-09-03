Imports System.Reflection
Namespace Util
    <Serializable()> _
    Public Class RefleccionUtil
        Public Shared Function CrearObjeto(Of TipoObjeto)(ByVal ParamArray parametrosConstructorEnOrden() As Object) As TipoObjeto
            Dim tipo As Type = GetType(TipoObjeto)
            Dim cantidadDeParametros As Integer = parametrosConstructorEnOrden.Length - 1
            Dim tiposDeParametrosDeConstructor(cantidadDeParametros) As Type

            For indice As Integer = 0 To cantidadDeParametros
                tiposDeParametrosDeConstructor(indice) = parametrosConstructorEnOrden(indice).GetType
            Next
            Dim constructor As ConstructorInfo = tipo.GetConstructor(tiposDeParametrosDeConstructor)
            Return constructor.Invoke(parametrosConstructorEnOrden)
        End Function

        Public Shared Sub EjecutarSub(ByVal objeto As Object, ByVal nombreSub As String, ByVal ParamArray parametrosDeEjecucionEnOrden() As Object)
            Dim tipo As Type = objeto.GetType
            Dim subrutina As MethodInfo = tipo.GetMethod(nombreSub)
            subrutina.Invoke(objeto, parametrosDeEjecucionEnOrden)
        End Sub

        Public Shared Function EjecutarFunction(ByVal objeto As Object, ByVal nombreFunction As String, ByVal ParamArray parametrosDeEjecucionEnOrden() As Object) As Object
            Dim tipo As Type = objeto.GetType
            Dim subrutina As MethodInfo = tipo.GetMethod(nombreFunction)
            Return subrutina.Invoke(objeto, parametrosDeEjecucionEnOrden)
        End Function

    End Class
End Namespace
