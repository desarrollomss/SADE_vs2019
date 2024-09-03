Imports Microsoft.VisualBasic
Imports System.Data
Imports System

Public Class Tabla
    Private table As New DataTable()
    Private pnroFilas As Integer
    Private col As DataColumn
    Private numColumnas As Integer

    Public Sub New()
    End Sub

    Public Sub New(ByVal columnas(,) As String)
        Dim lengthFilas As Integer = columnas.GetLength(0)
        Dim lengthColumns As Integer = columnas.GetLength(1)

        For i As Integer = 0 To lengthFilas - 1
            Dim tip As String = columnas(i, 1).ToString()
            Dim tipo As System.Type = System.Type.GetType(tip)
            col = table.Columns.Add(columnas(i, 0).ToString(), tipo)
        Next
        Me.numColumnas = lengthFilas
    End Sub

    Public Property Datos() As DataTable
        Get
            Return Me.table
        End Get
        Set(ByVal value As DataTable)
            Me.table = value
        End Set
    End Property

    Public ReadOnly Property NroFilas() As Integer
        Get
            Return Me.table.Rows.Count
        End Get
    End Property

    Public ReadOnly Property NroColumns() As Integer
        Get
            Return Me.numColumnas
        End Get
    End Property

    Public Sub EliminarTabla()
        table.Clear()
        Me.pnroFilas = 0
        table.AcceptChanges()
    End Sub

    Public Sub Agregar_Fila(ByVal ParamArray cols As Object())
        Dim mifila As DataRow
        mifila = table.NewRow()
        For i As Integer = 0 To Me.numColumnas - 1
            Dim tipo As String = table.Columns(i).DataType.ToString()
            If cols(i) = Nothing Then
                mifila(i) = DBNull.Value
            ElseIf tipo = "System.String" Then
                mifila(i) = cols(i)
            ElseIf tipo = "System.Decimal" Then
                mifila(i) = cols(i)
            ElseIf tipo = "System.Int32" Then
                mifila(i) = cols(i)
            ElseIf tipo = "System.Int16" Then
                mifila(i) = cols(i)
            End If
        Next
        table.Rows.Add(mifila)
    End Sub
    Public Sub Eliminar_Fila(ByVal fila As Integer)
        table.Rows(fila).Delete()
    End Sub
    Public Sub Modificar_Celda(ByVal row As Integer, ByVal colum As Integer, ByVal valor As String)
        Dim mifila As DataRow
        mifila = table.Rows(row)
        mifila.BeginEdit()
        mifila(colum) = valor
        mifila.EndEdit()
    End Sub
    Public Function Obtener_Celda(ByVal row As Integer, ByVal colum As Integer) As String
        Dim valor As String = ""
        valor = table.Rows(row)(colum).ToString()
        Return valor
    End Function

End Class
