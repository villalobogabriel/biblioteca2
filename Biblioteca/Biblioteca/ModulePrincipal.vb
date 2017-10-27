Option Strict On
Option Explicit Off
Imports System.IO
Module ModulePrincipal

    Public Autores_list As AutoresCollection
    Public Libros_list As LibrosCollection

    Sub main()

        Autores_list = New AutoresCollection
        Libros_list = New LibrosCollection

        Application.Run(MenuForm)


    End Sub
End Module