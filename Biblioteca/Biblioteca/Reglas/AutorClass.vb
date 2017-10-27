Imports System.IO

Public Class AutorClass

    Private Id_ As Integer

    Public Property Id() As Integer

        Get

            Return Id_

        End Get

        Set(ByVal value As Integer)

            Id_ = value

        End Set

    End Property
    Private Nombre_, Pais_, FNacimiento_ As String
    Public Property Nombre() As String

        Get

            Return Nombre_

        End Get

        Set(ByVal value As String)

            Nombre_ = value

        End Set

    End Property
    Public Property Pais() As String

        Get

            Return Pais_

        End Get

        Set(ByVal value As String)

            Pais_ = value

        End Set

    End Property
    Public Property FNacimiento() As String

        Get

            Return FNacimiento_

        End Get

        Set(ByVal value As String)

            FNacimiento_ = value

        End Set

    End Property
End Class

