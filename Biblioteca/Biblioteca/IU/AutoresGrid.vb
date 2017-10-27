Public Class AutoresGrid
    Private Sub AutoresGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DataGridView1.DataSource = Autores_list

        Me.Text = "....."

    End Sub


    Private Sub Agregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Agregar.Click

        AutorForm.operacion = "Agregar"

        AutorForm.Text = "Agregar"

        AutorForm.Show()



    End Sub


    Private Sub llenarFormAutor()

        AutorForm.TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
        AutorForm.TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        AutorForm.TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        AutorForm.TextBox4.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString


    End Sub
    Private Sub Modificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Modificar.Click

        If DataGridView1.SelectedRows.Count = 0 Then

            MsgBox("Seleccione para modificar")

            Exit Sub

        End If

        AutorForm.operacion = "Modificar"

        AutorForm.Text = "Modificar"

        AutorForm.Show()

        llenarFormAutor()


    End Sub

    Private Sub Eliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Eliminar.Click

        If DataGridView1.SelectedRows.Count = 0 Then

            MsgBox("Seleccione para eliminar")

            Exit Sub

        End If

        AutorForm.operacion = "Eliminar"

        AutorForm.Text = " Eliminar "

        AutorForm.Show()

        llenarFormAutor()


    End Sub

    Private Sub Salir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Salir.Click

        MenuForm.ToolStrip1.Enabled = True

        Me.Dispose()

    End Sub
End Class