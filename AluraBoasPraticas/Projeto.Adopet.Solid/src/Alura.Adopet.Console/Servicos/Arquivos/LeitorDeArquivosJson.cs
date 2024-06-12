using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Text.Json;

namespace Alura.Adopet.Console.Servicos.Arquivos;
public class LeitorDeArquivosJson<T>: ILeitorDeArquivos<T>
{
    private string caminhoArquivo;
    public LeitorDeArquivosJson(string caminhoArquivo)
    {
        this.caminhoArquivo = caminhoArquivo;
    }
    
    public IEnumerable<T> RealizaLeitura()
    {
        using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
        return JsonSerializer.Deserialize<IEnumerable<T>>(stream)??Enumerable.Empty<T>();
    }
}
