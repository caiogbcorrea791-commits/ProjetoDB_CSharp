using System;
using MySql.Data.MySqlClient;

string connectionString = "Server=localhost;Database=Games;Uid=root;Pwd=Senac2026;";

using (MySqlConnection conexao = new MySqlConnection(connectionString))
{
    conexao.Open();
    Console.WriteLine("Conectado!");
}