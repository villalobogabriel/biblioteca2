Public Class LibrosGrid
    Private Sub LibrosGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DataGridView1.DataSource = Libros_list

        Me.Text = "......"

    End Sub

    Private Sub Agregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Agregar.Click

        LibroForm.operacion = "Agregar"

        LibroForm.Text = "Agregar Compra"

        LibroForm.Show()



    End Sub

    Private Sub llenarLibrosForm()

        LibroForm.TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
        LibroForm.TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        LibroForm.TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        LibroForm.combo = CInt(DataGridView1.CurrentRow.Cells(3).Value.ToString)
    End Sub

    Private Sub Eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Eliminar.Click

        If DataGridView1.SelectedRows.Count = 0 Then

            MsgBox("Seleccione para eliminar")

            Exit Sub

        End If

        LibroForm.operacion = "Eliminar"

        llenarLibrosForm()

        LibroForm.Text = "Eliminar compra"

        LibroForm.Show()



    End Sub

    Private Sub Salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Salir.Click


        MenuForm.ToolStrip1.Enabled = True

        Me.Dispose()

    End Sub

    Private Sub Modificar_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Modificar.Click

        If DataGridView1.SelectedRows.Count = 0 Then

            MsgBox("Seleccione para modificar")

            Exit Sub

        End If

        If Libros_list.Count = 0 Then Exit Sub

        LibroForm.operacion = "Modificar"

        llenarLibrosForm()

        LibroForm.Text = "Modificar Carrera"

        LibroForm.Show()

    End Sub
End Class