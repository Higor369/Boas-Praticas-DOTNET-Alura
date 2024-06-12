using FluentResults;

namespace Alura.Adopet.Console.Results;

public class SuccessWithDocs : Success
{
    public IEnumerable<string> Documentacao { get; }
    public SuccessWithDocs(IEnumerable<string> documentacao)
    {
        Documentacao = documentacao;
    }
}
