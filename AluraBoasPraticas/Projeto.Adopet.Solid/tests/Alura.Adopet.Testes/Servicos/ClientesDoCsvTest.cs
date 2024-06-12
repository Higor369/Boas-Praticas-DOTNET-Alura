using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Testes.Servicos;
public class ClientesDoCsvTest : IDisposable
{
    private readonly string caminhoArquivo;

    public ClientesDoCsvTest()
    {
        //Setup
        string linha = "456b24f4-19e2-0192-845d-4a80e8854a41;Mariana;mari@email.com;1121221";

        string nomeRandomico = $"{Guid.NewGuid()}.csv";

        File.WriteAllText(nomeRandomico, linha);
        caminhoArquivo = Path.GetFullPath(nomeRandomico);
    }

    [Fact]
    public void QuandoArquivoExistenteDeveRetornarUmaListaDeClientes()
    {
        //Arrange            
        //Act
        var lista = new ClientesDoCsv(caminhoArquivo).RealizaLeitura()!;
        //Assert
        Assert.NotNull(lista);
        Assert.Single(lista);
    }

    public void Dispose()
    {
        File.Delete(caminhoArquivo);
    }
}