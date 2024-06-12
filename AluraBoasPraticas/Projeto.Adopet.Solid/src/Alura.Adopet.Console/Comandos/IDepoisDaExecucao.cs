using FluentResults;

namespace Alura.Adopet.Console.Comandos;
public interface IDepoisDaExecucao
{
    event Action<Result>? DepoisDaExecucao;
}
