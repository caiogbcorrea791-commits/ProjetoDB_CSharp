public class Jogos
{
    private int id;
    
    private string nome;

    private string plataforma;

    private string genero;

    public int Id
    {
        get {return id;}

        set{id = value;}
    }

    public string Nome
    {
        get {return nome;}

        set{nome = value;}

    }

    public string Plataforma
    {
        get {return plataforma;}

        set{plataforma = value;}

    }

    public string Genero
    {
        get {return genero;}

        set{genero = value;}

    }

    public Jogos (string nome, int id, string plataforma, string genero)
    {
        Nome = nome;
        Id = id;
        Plataforma = plataforma;
        Genero = genero;
       
    }

    public void Cadastrar()
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
        Thread.Sleep(3000);

    }


    public void Listar()
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
        Thread.Sleep(5000);
    }

    public void Buscar()
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
            Thread.Sleep(5000);
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("| Jogo não encontrado!");
            Thread.Sleep(2000);
        }

    }

    public void Atualizar()
    {
        Console.Write("| Digite o ID do jogo: ");
        if (!int.TryParse(Console.ReadLine(), out int id_jogo))
        {
            Console.WriteLine("| Id inválido!");
            Thread.Sleep(2000);
            return;
        }

        Console.Write("| Digite o nome do jogo: ");
        string novo_nome = Console.ReadLine()!;

        Console.Write("| Digite a plataforma do jogo: ");
        string nova_plataforma = Console.ReadLine()!;

        Console.Write("| Digite o genero do jogo: ");
        string novo_genero = Console.ReadLine()!;


        using var conn = new MySqlConnection(connectionString);
        conn.Open();

        string sql = @"
            UPDATE jogos 
                SET nome = @novo_nome,
                plataforma = @nova_plataforma,
                genero = @novo_genero
            WHERE id = @id_jogo";

        using var cmd = new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@id_jogo", id_jogo);
        cmd.Parameters.AddWithValue("@novo_nome", novo_nome);
        cmd.Parameters.AddWithValue("@nova_plataforma", nova_plataforma);
        cmd.Parameters.AddWithValue("@novo_genero", novo_genero);

        int linhas = cmd.ExecuteNonQuery();

        if (linhas > 0)
        {
            Console.WriteLine("| Jogo atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("| Nenhum jogo com esse Id");
        }
        Thread.Sleep(3000);
    }

    public void Deletar()
    {
        Console.Write("| digite o ID do jogo que você quer deletar: ");
        int id = int.Parse(Console.ReadLine()!);
    
        using var conn = new MySqlConnection(connectionString);
        conn.Open();
    
        string sql = "DELETE FROM jogos WHERE id = @id";
    
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@id", id);
    
        int linhaE = cmd.ExecuteNonQuery();
    
        if (linhaE > 0)
            Console.WriteLine("| jogo excluido");
        else
            Console.WriteLine("| jogo não encontrado");
    }


    public override string ToString()
    {
        return $"Jogo: {Nome} | Id: {id} | Plataforma: {plataforma} | Genero: {genero}";
    }

}
