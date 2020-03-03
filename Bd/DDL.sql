
 -- CRIANDO O BANCO DE DADOS
  CREATE DATABASE  InLock_Games_Manha;
  GO
 -- INFORMANDO O BANCO QUE SER� USADO
  USE  InLock_Games_Manha;
  GO
  --CRIANDO A TABELA ESTUDIOS
  CREATE TABLE Estudios (
  Id_Estudio INT PRIMARY KEY IDENTITY NOT NULL,
  NomeEstudio VARCHAR (150) NOT NULL
  )
 GO
  --CRIANDO A TABELA JOGOS
  CREATE TABLE Jogos(
  Id_Jogo INT PRIMARY KEY IDENTITY NOT NULL,
  NomeJogo VARCHAR (255) NOT NULL,
  Descricao VARCHAR (255) NOT NULL,
  DataLancamento DATE NOT NULL,
  Valor DECIMAL (10,2) NOT NULL,
  Fk_Estudio INT FOREIGN KEY REFERENCES Estudios (Id_Estudio)
  )
  GO
  --CRIANDO A TABELA USUARIOS
  CREATE TABLE Usuarios (
  Id_Usuario INT PRIMARY KEY IDENTITY NOT NULL,
  Email VARCHAR (150) NOT NULL,
  Senha VARCHAR (MAX) NOT NULL,
  Fk_TipoUsuario INT FOREIGN KEY REFERENCES Usuarios (Id_Usuario)
  )
  GO

  select Id_Jogo,NomeJogo,Descricao,DataLancamento,Valor,Fk_Estudio  from Jogos
	 outer JOIN left Estudios
	ON Jogos.Fk_Estudio = Estudios.Id_Estudio;
  