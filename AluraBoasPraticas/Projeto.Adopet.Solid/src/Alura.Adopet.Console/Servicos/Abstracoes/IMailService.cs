namespace Alura.Adopet.Console.Servicos.Abstracoes;
public interface IMailService
{
    Task SendMailAsync(string remetente, string destinatario,
        string titulo, string corpo);
}
