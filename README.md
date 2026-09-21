Sistema de Jogos

Integrantes:
Caio Gomes
Davi Peres
Vinicios Alves

Banco de dados utilizado:
O projeto utiliza o MySQL para armazenar os dados dos jogos. O banco de dados se chama Games e possui uma tabela chamada jogos, que guarda informações como ID, nome, plataforma e gênero.

Biblioteca/driver utilizado:
Foi utilizada a biblioteca MySql.Data. Ela permite que o programa em C# consiga se conectar ao banco de dados MySQL e realizar operações.

Como instalar as dependências:
Para instalar a biblioteca necessária, é preciso abrir o terminal na pasta do projeto e usar o comando:
dotnet add package MySql.Data

Como configurar o banco:
Primeiro, é necessário ter o MySQL instalado e funcionando.
Para criar o banco de dados, usamos:

CREATE DATABASE Games;
Depois, selecionamos o banco:
USE Games;
E criamos a tabela:
CREATE TABLE jogos (
id INT PRIMARY KEY,
nome VARCHAR(100),
plataforma VARCHAR(100),
genero VARCHAR(100)
);

No programa, a conexão com o banco é configurada usando:
string connectionString = "Server=localhost;Database=Games;Uid=root;Pwd=Senac2026;";
Se o usuário ou a senha do MySQL forem diferentes, essas informações precisam ser alteradas.

Como executar o projeto:
Depois de configurar o banco de dados e deixar o MySQL funcionando, abrimos o terminal na pasta do projeto e usamos o comando:
dotnet run
Depois disso, o programa mostra um menu com as opções de cadastrar, listar, buscar, atualizar e deletar jogos.

Como funciona a conexão:
O programa usa a classe MySqlConnection para fazer a conexão com o banco de dados.
Quando uma função precisa acessar o banco, é feita uma conexão usando:
using var conn = new MySqlConnection(connectionString);
Depois, a conexão é aberta usando:
conn.Open();
Para enviar comandos para o banco, o programa utiliza a classe MySqlCommand. Com ela são feitos os comandos SQL para cadastrar, buscar, atualizar e deletar os jogos.
Quando a operação termina, a conexão é fechada automaticamente.