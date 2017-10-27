IF DB_ID('Biblioteca') IS NULL
CREATE DATABASE Biblioteca;
GO
USE Biblioteca;

IF OBJECT_ID ('Autor') IS NULL
CREATE TABLE Autor
(
Id Int identity(1,1),
Nombre Nvarchar(50) NOT NULL,
Pais Nvarchar(50) NOT NULL,
FNacimiento Nvarchar(50) NOT NULL,
CONSTRAINT PK_Autor_Id PRIMARY KEY (Id)
);

IF OBJECT_ID ('Libro') IS NULL
CREATE TABLE Libro
(
Id Int identity(1,1),
Titulo Nvarchar(50) NOT NULL,
Fecha Nvarchar(50) NOT NULL,
IdAutor	int Foreign Key references Autor(id) NOT NULL,
CONSTRAINT PK_Libro_Id PRIMARY KEY (Id)
);
