using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Util;
using System.Reflection;

namespace Alura.Adopet.Testes.Util;

public class GeraDocumentacaoTest
{
    [Fact]
    public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
    {
        //Arrange
        Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComandoAttribute))!;

        //Act
        Dictionary<string, DocComandoAttribute> dicionario =
              DocumentacaoDoSistema.ToDictionary(assemblyComOTipoDocComando);

        //Assert            
        Assert.NotNull(dicionario);
        Assert.NotEmpty(dicionario);
        Assert.Equal(5, dicionario.Count);

    }
}
