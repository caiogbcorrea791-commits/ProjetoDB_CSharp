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



    public override string ToString()
    {
        return $"Jogo: {Nome} | Id: {id} | Plataforma: {plataforma} | Genero: {genero}";
    }

}

