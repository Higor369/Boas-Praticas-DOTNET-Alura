using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    public interface IComando
    {
        Task<Result> ExecutarAsync();
    }
}
