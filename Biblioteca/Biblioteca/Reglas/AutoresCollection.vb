Imports System.ComponentModel
Imports System.Text
Public Class AutoresCollection

    Inherits BindingList(Of AutorClass)

    Protected Overrides Sub OnAddingNew(ByVal e As System.ComponentModel.AddingNewEventArgs)

        MyBase.OnAddingNew(e)

        e.NewObject = New AutorClass

    End Sub
    Protected Overrides ReadOnly Property SupportsSearchingCore() As Boolean
        Get

            Return True

        End Get

    End Property
    Protected Overrides Function FindCore(ByVal prop As PropertyDescriptor, ByVal key As Object) As Integer

        For Each Autor In Me
            If prop.GetValue(Autor).Equals(key) Then
                Return Me.IndexOf(Autor)
            End If
        Next

        Return -1

    End Function
    Public Sub New()

        Me.TraerAutores()

    End Sub
    Public Function TraerAutores() As AutoresCollection

        Dim objBaseDatos As New BaseDatosClass
        Dim MiDataTable As New DataTable
        Dim MiAutor As AutorClass

        objBaseDatos.objTabla = "Autor"

        MiDataTable = objBaseDatos.Consultar

        For Each dr As DataRow In MiDataTable.Rows

            MiAutor = New AutorClass
            MiAutor.Id = CInt(dr("Id"))
            MiAutor.Nombre = CStr(dr("Nombre"))
            MiAutor.Pais = CStr(dr("Pais"))
            MiAutor.FNacimiento = CStr(dr("FNacimiento"))
            Me.Add(MiAutor)

        Next
        Return Me
    End Function
    Public Sub InsertarAutor(ByVal MiAutor As AutorClass)

        Dim objBaseDatos As New BaseDatosClass
        objBaseDatos.objTabla = "Autor"

        Dim vSQL As New StringBuilder
        Dim vResultado As Boolean = False

        vSQL.Append("(Nombre")
        vSQL.Append(",Pais")
        vSQL.Append(",FNacimiento)")

        vSQL.Append(" VALUES ")
        vSQL.Append("('" & MiAutor.Nombre & "'")
        vSQL.Append(",'" & MiAutor.Pais & "'")
        vSQL.Append(",'" & MiAutor.FNacimiento & "')")

        MiAutor.Id = objBaseDatos.Insertar(vSQL.ToString)

        'Evalúa el resultado del comando SQL.
        If MiAutor.Id = 0 Then
            MsgBox("No fue posible agregar el autor " + MiAutor.Nombre)
            Exit Sub
        End If

        Me.Add(MiAutor)

    End Sub

    Public Sub EliminarAutor(ByVal MiAutor As AutorClass)

        Dim objBaseDatos As New BaseDatosClass
        objBaseDatos.objTabla = "Autor"

        Dim resultado As Boolean

        resultado = objBaseDatos.Eliminar(MiAutor.Id)

        If Not resultado Then
            MessageBox.Show("No fue posible eliminar el Responsable " + MiAutor.Nombre)
            Exit Sub
        End If

        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(MiAutor)
        Dim myProperty As PropertyDescriptor = properties.Find("Id", True)

        Me.RemoveAt(Me.FindCore(myProperty, MiAutor.Id))

    End Sub
    Public Sub ActualizarAutor(ByVal MiAutor As AutorClass)

        Dim objBaseDatos As New BaseDatosClass
        objBaseDatos.objTabla = "Autor"

        Dim vSQL As New StringBuilder
        Dim vResultado As Boolean = False

        vSQL.Append("Nombre='" & MiAutor.Nombre & "'")
        vSQL.Append(",Pais='" & MiAutor.Pais & "'")
        vSQL.Append(",FNacimiento='" & MiAutor.FNacimiento & "'")

        Dim resultado As Boolean

        resultado = objBaseDatos.Actualizar(vSQL.ToString, MiAutor.Id)

        If Not resultado Then
            MessageBox.Show("No fue posible modificar el Responsable " + MiAutor.Nombre)
            Exit Sub
        End If

        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(MiAutor)

        Dim myProperty As PropertyDescriptor = properties.Find("Id", True)
        Me.Items.Item(Me.FindCore(myProperty, MiAutor.Id)) = MiAutor

    End Sub

End Class

