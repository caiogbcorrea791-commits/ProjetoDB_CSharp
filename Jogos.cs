public class Jogos
{
    private int id;
    
    private string nome;

    private string plataforma;

    private string genero;

    public int Id
    {
        get {return id;}

        set
        {
           if (value == 0)
            {
                 throw new ArgumentException("O id não foi informado.");
            }
        }
    }

    public string Nome
    {
        get {return nome;}

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                 throw new ArgumentException("O nome não pode ser nulo ou vazio.");
            }
            

        }

    }
}
