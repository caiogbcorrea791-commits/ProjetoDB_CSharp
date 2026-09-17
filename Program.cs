using System;
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
        Console.WriteLine();
    }
    else if (opcao == 2)
    {
        Console.WriteLine();
    }
    else if (opcao == 3)
    {
        Console.WriteLine();
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
        Console.WriteLine();
        Console.WriteLine("Saindo...");
    }
}

void Criar()
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
    Console.WriteLine("| Pressione ENTER para continuar...");
    Console.ReadLine();

}
