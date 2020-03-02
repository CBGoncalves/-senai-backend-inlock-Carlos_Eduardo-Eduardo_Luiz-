SELECT IdUsuario, Email, Senha FROM Usuarios;

SELECT IdEstudio, NomeEstudio FROM Estudios;

SELECT IdJogo, NomeJogo, DataLancamento, Valor, Descricao FROM Jogos

SELECT IdJogo, NomeJogo, Descricao, DataLancamento, Valor, IdEstudio, NomeEstudio FROM Jogos
INNER JOIN Estudios ON Jogos.IdEstudio = Estudio.IdEstudio;

SELECT IdEstudio, NomeEstudio FROM Estudios;

SELECT IdUsuario, Email, Senha,  FROM Usuarios 
WHERE Email = 'cliente@cliente.com' AND Senha = 'cliente';

SELECT IdJogo, NomeJogo, DataLancamento, Valor, Descricao FROM Jogos
WHERE IdJogo = '1';

SELECT  IdEstudio, NomeEstudio FROM Estudios
WHERE IdEstudio = '1';