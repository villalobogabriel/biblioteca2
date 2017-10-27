Public Class LibroForm

    Dim operacion_ As String

    Public MiLibro As New LibroClass

    Public Property operacion() As String
        Get
            Return operacion_
        End Get
        Set(ByVal value As String)
            operacion_ = value
        End Set
    End Property
    Dim combo_ As Integer

    Public Property combo() As Integer
        Get
            Return combo_
        End Get
        Set(ByVal value As Integer)
            combo_ = value
        End Set
    End Property
    Private Sub Aceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Aceptar.Click

        If operacion_ <> "Agregar" Then

            MiLibro.Id = CInt(TextBox1.Text)


        End If

        MiLibro.Titulo = TextBox2.Text

        MiLibro.IdAutor = CInt(ComboBox1.SelectedValue)

        MiLibro.Fecha = TextBox3.Text


        Select Case operacion_

            Case "Agregar"

                Libros_list.InsertarLibro(MiLibro)

            Case "Modificar"
                Libros_list.ActualizarLibro(MiLibro)

                LibrosGrid.DataGridView1.Refresh()

            Case "Eliminar"

                Libros_list.EliminarLibro(MiLibro)

        End Select

        Me.Close()

    End Sub

    Private Sub Cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancelar.Click

        Me.Close()

    End Sub

    Private Sub Libroform_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.DataSource = Autores_list
        ComboBox1.ValueMember = "Id"
        ComboBox1.DisplayMember = "Nombre"
        ComboBox1.SelectedValue = combo


    End Sub

End Class