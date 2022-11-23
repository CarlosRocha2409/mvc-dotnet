USE master
CREATE DATABASE Notas

USE Notas
go

CREATE TABLE Nota (
	ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Carnet VARCHAR(9) NOT NULL UNIQUE,
	Nombre TEXT NOT NULL,
	N_Sistematico INT NOT NULL DEFAULT 0,
	N_1Parcial INT NOT NULL DEFAULT 0,
	N_2Parcial INT NOT NULL DEFAULT 0,
	E_Convo1 INT NULL,
	E_Convo2 INT NULL
)
go
CREATE VIEW ViewNotas AS 
SELECT Carnet, Nombre, N_1Parcial, N_2Parcial, N_Sistematico, 
	(N_1Parcial+N_2Parcial+N_Sistematico) AS N_Final,
	E_Convo1, (N_Sistematico+E_Convo1) AS E_FConvo1,
	E_Convo2 
FROM Nota

