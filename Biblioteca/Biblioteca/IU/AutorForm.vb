Public Class AutorForm
    Dim operacion_ As String
    Public MiAutor As New AutorClass

    Public Property operacion() As String
        Get
            Return operacion_
        End Get
        Set(ByVal value As String)
            operacion_ = value
        End Set
    End Property


   

    Private Sub Cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancelar.Click

        Me.Close()

    End Sub




    Private Sub Aceptar_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Aceptar.Click




        If operacion_ <> "Agregar" Then

            MiAutor.Id = CInt(TextBox1.Text)

        End If

        MiAutor.Nombre = CStr(TextBox2.Text)
        MiAutor.Pais = CStr(TextBox3.Text)
        MiAutor.FNacimiento = TextBox4.Text


        Select Case operacion_

            Case "Agregar"

                Autores_list.InsertarAutor(MiAutor)

            Case "Eliminar"

                Autores_list.EliminarAutor(MiAutor)

            Case "Modificar"

                Autores_list.ActualizarAutor(MiAutor)


                AutoresGrid.DataGridView1.Refresh()

        End Select

        Me.Close()
    End Sub


End Class
