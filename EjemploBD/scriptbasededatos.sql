CREATE DATABASE EjemploBD
GO

USE EjemploBD
GO

CREATE TABLE Empleados
(
	IdPersonas int IDENTITY PRIMARY KEY NOT NULL,
	Nombre nvarchar (25) NULL,
	Apellidos nvarchar (25) NULL,
	FechaNacimiento date NULL,
	IdSexo Int Null
)
GO

CREATE TABLE Sexo
(
	IdSexo int IDENTITY PRIMARY KEY NOT NULL,
	Sexo nvarchar (10) NULL
)
GO

INSERT Sexo (Sexo) VALUES (N'Femenino')
INSERT Sexo (Sexo) VALUES (N'Masculino')

ALTER TABLE Empleados ADD CONSTRAINT FK_Empleados_Sexo FOREIGN KEY(IdSexo) REFERENCES Sexo(IdSexo)
GO 