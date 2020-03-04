-- INSERINDO TIPOS DE USUÁRIOS
INSERT INTO TipoUsuario    
VALUES ('Administrador'), ('Cliente');
   GO
-- INSERINDO USUARIOS
INSERT INTO Usuarios
VALUES ('admin@admin.com', 'admin',1), ('cliente@cliente.com', 'cliente',2);
  GO
--INSERINDO OS ESTÚDIOS
INSERT INTO Estudios
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix');
   GO
--INSERINDO OS JOGOS
INSERT INTO Jogos
VALUES ('Diablo 3', 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fa.', '15/05/2012', 99, 1),
		('Red Dead Redemption II', 'Jogo eletrônico de ação-aventura western',  '26/10/2018', 120, 2);
   GO