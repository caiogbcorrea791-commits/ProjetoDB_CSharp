using System;
using System.Data.Common;
using System.Threading;
using MySql.Data.MySqlClient;

string connectionString = "Server=localhost;Database=Games;Uid=root;Pwd=Senac2026;";

using (MySqlConnection conexao = new MySqlConnection(connectionString))
{
    conexao.Open();
    Console.WriteLine("Conectado!");
}


int opcao = 0;

while (opcao != 6)
{   
    Console.Clear();
    
    Console.WriteLine("|=================================================");
    Console.WriteLine("|====================  MENU  =====================");
    Console.WriteLine("|=================================================");
    Console.WriteLine("| 1 - Cadastrar Jogo");
    Console.WriteLine("| 2 - Listar Jogos");
    Console.WriteLine("| 3 - Buscar Jogos");
    Console.WriteLine("| 4 - Atualizar Jogo");
    Console.WriteLine("| 5 - Deletar Jogo");
    Console.WriteLine("| 6 - Sair");
    Console.WriteLine("|=================================================");

    Console.Write("| Digite sua escolha: ");
    int.TryParse(Console.ReadLine(), out opcao);

    while (opcao < 1 || opcao > 6)
    {
        Console.WriteLine("| Opção inválida!");
        Console.Write("| Digite novamente: ");
        int.TryParse(Console.ReadLine(), out opcao);
    }

    if (opcao == 1)
    {
        Cadastrar();
    }
    else if (opcao == 2)
    {
        Listar();
    }
    else if (opcao == 3)
    {
        Buscar();
    }
    else if (opcao == 4)
    {
        Console.WriteLine();
    }
    else if (opcao == 5)
    {
        Console.WriteLine();
    }
    else if (opcao == 6)
    {
        Console.WriteLine("|");
        Console.WriteLine("| Saindo...");
    }
}

void Cadastrar()
{
    Console.Write("| Digite o ID: ");
    int id = int.Parse(Console.ReadLine()!);

    Console.Write("| Digite o nome do jogo: ");
    string nome = Console.ReadLine()!;

    Console.Write("| Digite a plataforma do jogo: ");
    string plataforma = Console.ReadLine()!;

    Console.Write("| Digite o genero do jogo: ");
    string genero = Console.ReadLine()!;

    using var conn = new MySqlConnection(connectionString);
    conn.Open();

    string sql = @"
        INSERT INTO jogos (id, nome, plataforma, genero)
        VALUES (@id, @nome, @plataforma, @genero)";

    using var cmd = new MySqlCommand(sql, conn);

    cmd.Parameters.AddWithValue("@id", id);
    cmd.Parameters.AddWithValue("@nome", nome);
    cmd.Parameters.AddWithValue("@plataforma", plataforma);
    cmd.Parameters.AddWithValue("@genero", genero);

    cmd.ExecuteNonQuery();

    Console.WriteLine("| Jogo cadastrado com sucesso!");
    Thread.Sleep(2000);

}


void Listar()
{
    using var conn = new MySqlConnection(connectionString);
    conn.Open();

    string sql = "SELECT * FROM jogos";

    using var cmd = new MySqlCommand(sql, conn);
    using var reader = cmd.ExecuteReader();

    Console.WriteLine("|==================================================");
    Console.WriteLine("|====================  JOGOS  =====================");
    Console.WriteLine("|==================================================");

    while (reader.Read())
    {
        Console.WriteLine(
            $"ID: {reader["id"]} | " +
            $"nome: {reader["nome"]} | " +
            $"plataforma: {reader["plataforma"]} | " +
            $"genero do jogo: {reader["genero"]}"
        );
    }
    Thread.Sleep(2000);
}

void Buscar()
{
    Console.Write("| Digite o ID do jogo: ");
    if (!int.TryParse(Console.ReadLine(), out int id_jogo))
    {
        Console.WriteLine("| Id inválido!");
        Thread.Sleep(2000);
        return;
    }

    using var conn = new MySqlConnection(connectionString);
    conn.Open();

    string sql = @"
        SELECT * FROM jogos
        WHERE id = @id_jogo";

    using var cmd = new MySqlCommand(sql, conn);

    cmd.Parameters.AddWithValue("@id_jogo", id_jogo);

    using var reader = cmd.ExecuteReader();

    if (reader.Read())
    {
        Console.WriteLine();
        Console.WriteLine("|==================================================");
        Console.WriteLine("|================  JOGO ENCONTRADO  ===============");
        Console.WriteLine("|==================================================");

        Console.WriteLine($"| ID: {reader["id"]}");
        Console.WriteLine($"| Nome: {reader["nome"]}");
        Console.WriteLine($"| Plataforma: {reader["plataforma"]}");
        Console.WriteLine($"| Gênero: {reader["genero"]}");

        Console.WriteLine("|==================================================");
        Thread.Sleep(2000);
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("| Jogo não encontrado!");
        Thread.Sleep(2000);
    }

}

void Atualizar()
{
    
}

void Deletar()
{
    
}
