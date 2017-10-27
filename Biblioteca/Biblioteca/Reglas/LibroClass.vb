Imports System.IO
Public Class LibroClass

    Private Id_, IdAutor_ As Integer
    Public Property Id() As Integer

        Get

            Return Id_

        End Get

        Set(ByVal value As Integer)

            Id_ = value

        End Set

    End Property
    Public Property IdAutor() As Integer

        Get

            Return IdAutor_

        End Get

        Set(ByVal value As Integer)

            IdAutor_ = value

        End Set

    End Property

    Private Titulo_, Fecha_, autorDet_ As String
    Public Property Titulo() As String

        Get

            Return Titulo_

        End Get

        Set(ByVal value As String)

            Titulo_ = value

        End Set

    End Property

    Public Property Fecha() As String

        Get

            Return Fecha_

        End Get

        Set(ByVal value As String)

            Fecha_ = value

        End Set
    End Property
    Public ReadOnly Property autorDet() As String
        Get

            For Each autor In Autores_list

                If autor.Id = IdAutor_ Then

                    autorDet_ = autor.Nombre

                End If
            Next

            Return autorDet_

        End Get


    End Property





End Class


