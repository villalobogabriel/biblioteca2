Imports System.ComponentModel
Imports System.Text

Public Class LibrosCollection

    Inherits BindingList(Of LibroClass)

    Protected Overrides Sub OnAddingNew(ByVal e As System.ComponentModel.AddingNewEventArgs)

        MyBase.OnAddingNew(e)

        e.NewObject = New LibroClass

    End Sub
    Protected Overrides ReadOnly Property SupportsSearchingCore() As Boolean
        Get

            Return True

        End Get

    End Property
    Protected Overrides Function FindCore(ByVal prop As PropertyDescriptor, ByVal key As Object) As Integer

        For Each Libro In Me
            If prop.GetValue(Libro).Equals(key) Then
                Return Me.IndexOf(Libro)
            End If
        Next

        Return -1

    End Function

    Public Sub New()

        Me.TraerLibros()

    End Sub
    Public Function TraerLibros() As LibrosCollection

        Dim objBaseDatos As New BaseDatosClass
        Dim MiDataTable As New DataTable
        Dim MiLibro As LibroClass

        objBaseDatos.objTabla = "Libro"

        MiDataTable = objBaseDatos.Consultar

        For Each dr As DataRow In MiDataTable.Rows

            MiLibro = New LibroClass
            MiLibro.Id = Int(dr("Id"))
            MiLibro.Titulo = CStr(dr("Titulo"))
            MiLibro.IdAutor = CInt(dr("IdAutor"))
            MiLibro.Fecha = CStr(dr("Fecha"))


            Me.Add(MiLibro)

        Next

        Return Me

    End Function

    Public Sub InsertarLibro(ByVal MiLibro As LibroClass)

        ' Instancio en el objeto BaseDatosClass para accede a la base 
        Dim objBaseDatos As New BaseDatosClass
        objBaseDatos.objTabla = "Libro"

        Dim vSQL As New StringBuilder
        Dim vResultado As Boolean = False

        vSQL.Append("(Titulo")
        vSQL.Append(",IdAutor")
        vSQL.Append(",Fecha)")
        vSQL.Append(" VALUES ")
        vSQL.Append("('" & MiLibro.Titulo & "'")
        vSQL.Append(",'" & MiLibro.IdAutor & "'")
        vSQL.Append(",'" & MiLibro.Fecha & "')")


        MiLibro.Id = objBaseDatos.Insertar(vSQL.ToString)

        'Evalúa el resultado del comando SQL.
        If MiLibro.Id = 0 Then
            MsgBox("No fue posible agregar el libro " + MiLibro.Titulo)
            Exit Sub
        End If


        Me.Add(MiLibro)

    End Sub

    Public Sub EliminarLibro(ByVal MiLibro As LibroClass)

        Dim objBaseDatos As New BaseDatosClass
        objBaseDatos.objTabla = "Libro"

        'ejecuta el método base eliminar 
        Dim resultado As Boolean

        resultado = objBaseDatos.Eliminar(MiLibro.Id)

        If Not resultado Then
            MessageBox.Show("No fue posible eliminar " + MiLibro.Titulo)
            Exit Sub
        End If

        'Creates a new collection and assign it the properties for modulo.
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(MiLibro)

        'Sets as PropertyDescriptor to the specific property Id.
        Dim myProperty As PropertyDescriptor = properties.Find("Id", True)
        Me.RemoveAt(Me.FindCore(myProperty, MiLibro.Id))

    End Sub

    Public Sub ActualizarLibro(ByVal Milibro As LibroClass)

        Dim objBaseDatos As New BaseDatosClass
        objBaseDatos.objTabla = "Libro"
        Dim vSQL As New StringBuilder
        Dim vResultado As Boolean = False

        vSQL.Append("Titulo='" & Milibro.Titulo & "'")
        vSQL.Append(",IdAutor='" & Milibro.IdAutor & "'")
        vSQL.Append(",Fecha='" & Milibro.Fecha & "'")


        'Actualizo la tabla Mesas con el Id.
        Dim resultado As Boolean
        'El método actualizar es una función que devuelve True o False
        'Según como haya resultado la operación sobre la tabla SQL.
        resultado = objBaseDatos.Actualizar(vSQL.ToString, Milibro.Id)

        If Not resultado Then
            MessageBox.Show("No fue posible modificar " + Milibro.Titulo)
            Exit Sub
        End If

        'El código a continuación sirve para localizar el ítem en la lista
        'en este caso un Mesa.
        ' Creates a new collection and assign it the properties for modulo.
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(Milibro)

        'Sets an PropertyDescriptor to the specific property Id.
        Dim myProperty As PropertyDescriptor = properties.Find("Id", True)
        Me.Items.Item(Me.FindCore(myProperty, Milibro.Id)) = Milibro

    End Sub

End Class


