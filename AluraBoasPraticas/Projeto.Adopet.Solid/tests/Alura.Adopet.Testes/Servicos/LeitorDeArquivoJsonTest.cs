using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Testes.Servicos;

public class LeitorDeArquivoJsonTest : IDisposable
{
    private string caminhoArquivo;
    public LeitorDeArquivoJsonTest()
    {
        //Setup
        string conteudo = @"
            [
              {
                ""Id"": ""68286fbf-f6f4-4924-adab-0637511813e0"",
                ""Nome"": ""Mancha"",
                ""Tipo"": 1
              },
              {
                ""Id"": ""68286fbf-f6f4-4924-adab-0637511672e0"",
                ""Nome"": ""Alvo"",
                ""Tipo"": 1
              },
              {
                ""Id"": ""68286fbf-f6f4-1234-adab-0637511672e0"",
                ""Nome"": ""Pinta"",
                ""Tipo"": 1
              }
            ]
        ";

        string nomeRandomico = $"{Guid.NewGuid()}.json";

        File.WriteAllText(nomeRandomico, conteudo);
        caminhoArquivo = Path.GetFullPath(nomeRandomico);
    }

    [Fact]
    public void QuandoArquivoExistenteDeveRetornarUmaListaDePets()
    {
        //Arrange            
        //Act
        var listaDePets = new LeitorDeArquivosJson<Pet>(caminhoArquivo).RealizaLeitura()!;
        //Assert
        Assert.NotNull(listaDePets);
        Assert.IsType<List<Pet>?>(listaDePets);
    }

    public void Dispose()
    {
        //ClearDown
        File.Delete(caminhoArquivo);
    }
}