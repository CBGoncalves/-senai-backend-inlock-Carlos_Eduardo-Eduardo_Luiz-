--DDL INLOCK

CREATE DATABASE InLock_Games_Manha

USE InLock_Games_Manha;

CREATE TABLE Estudios (
	IdEstudio   INT PRIMARY KEY IDENTITY,
	NomeEstudio VARCHAR (255) UNIQUE
);
GO

CREATE TABLE Jogos (
	IdJogo		   INT PRIMARY KEY IDENTITY,
	NomeJogo	   VARCHAR (255) NOT NULL UNIQUE,
	Descricao	   VARCHAR (255) NOT NULL,
	DataLancamento DATE,
	Valor		   VARCHAR (255) NOT NULL,
	IdEstudio	   INT FOREIGN KEY REFERENCES Estudios (IdEstudio)
);
GO

CREATE TABLE TipoUsuario (
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo		  VARCHAR (255) NOT NULL UNIQUE
);

CREATE TABLE Usuarios (
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR (255) NOT NULL UNIQUE,
	Senha VARCHAR (255) NOT NULL,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);
