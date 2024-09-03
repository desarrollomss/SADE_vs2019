Option Explicit On
Option Strict On

Imports log4net

Public Enum LogMsg
    INFO
    [ERROR]
End Enum

Public Module Bitacora

    ' definir y obtener interface de log4net
    Private ReadOnly logBitacora As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)


    ''' <summary>
    ''' Limpiar el mensaje del control literal (litError)
    ''' </summary>
    ''' <param name="litError">Control literal para mostrar el mensaje de error</param>
    Public Sub Limpiar(ByRef litError As Literal)
        Try
            ' limpiar mensaje
            litError.Text = ""
            ' ocultar mensaje
        Catch ex As Exception
            ' bitacora heredar
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Guardar en la bitácora la excepción, con el formato especificado en App.config sección configSections y log4net
    ''' </summary>
    ''' <param name="mensaje">Representa un error que se produce durante la ejecución de la aplicación, ver <see cref="System.Exception"/></param>
    Public Sub Escribir(ByRef mensaje As String, ByRef sLogMsg As LogMsg)
        Dim sError As String
        Dim sMensaje As String
        Dim blnErrorDefinido As Boolean = False
        Try

            ' mensaje por defecto
            'sMensaje = "Ha ocurrido una excepción, por favor levante un reporte con el administrador de la aplicación."

            ' excepciones controladas
            'If exceptionTmp.Message.StartsWith("-99999") Then sMensaje = "Excepción controlada. Mensaje personalizado número uno." : blnErrorDefinido = True
            'If exceptionTmp.Message.StartsWith("-99998") Then sMensaje = "Excepción controlada. Mensaje personalizado número dos." : blnErrorDefinido = True

            ' excepcion no controlada

            If logBitacora.IsErrorEnabled Then
                ' escribir en bitacora
                If sLogMsg = LogMsg.ERROR Then
                    logBitacora.Error(mensaje)
                ElseIf sLogMsg = LogMsg.INFO Then
                    logBitacora.Info(mensaje)
                End If

            End If

            ' mostrar error
            'litError.Text = sMensaje

        Catch ex As Exception
            ' heredar
            Throw ex
        End Try
    End Sub

End Module
