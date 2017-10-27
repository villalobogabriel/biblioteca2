Imports System.Windows.Forms
Public Class MenuForm

    Private Sub Autor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Autores.Click


        ToolStrip1.Enabled = False

        Dim gridAutores As New AutoresGrid

        gridAutores.MdiParent = Me

        gridAutores.Show()

    End Sub


    Private Sub Libro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Libros.Click

        ToolStrip1.Enabled = False

        Dim gridLibros As New LibrosGrid

        gridLibros.MdiParent = Me

        gridLibros.Show()

    End Sub
    Private Sub Salir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Salir.Click

        End

    End Sub


End Class