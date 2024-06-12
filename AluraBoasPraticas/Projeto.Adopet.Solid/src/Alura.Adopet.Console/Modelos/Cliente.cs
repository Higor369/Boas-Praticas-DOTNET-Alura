namespace Alura.Adopet.Console.Modelos;

public class Cliente
{
    public Cliente(Guid id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string? CPF { get; set; }

    public override string? ToString()
    {
        return $"{Id} - {Nome} - {Email}";
    }
}