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


Jogos jogo = new Jogos();

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
        jogo.Cadastrar();
    }
    else if (opcao == 2)
    {
        jogo.Listar();
    }
    else if (opcao == 3)
    {
        jogo.Buscar();
    }
    else if (opcao == 4)
    {
        jogo.Atualizar();
    }
    else if (opcao == 5)
    {
        jogo.Deletar();
    }
    else if (opcao == 6)
    {
        Console.WriteLine("|");
        Console.WriteLine("| Saindo...");
    }
}
