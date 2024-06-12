using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Servicos.Arquivos;
using System.Reflection;
using Alura.Adopet.Console.Extensions;

namespace Alura.Adopet.Console.Comandos;

public static class ComandosFactory
{
    public static IComando? CriarComando(string[] argumentos)
    {
        if ((argumentos is null) || (argumentos.Length == 0))
        {
            return null;           
        }
        var comando = argumentos[0];
        Type? tipoRetornado = Assembly.GetExecutingAssembly().GetTipoComando(comando);

        var listaDeFabricas = Assembly.GetExecutingAssembly().GetFabricas();

        var fabrica = listaDeFabricas.FirstOrDefault(f => f!.ConsegueCriarOTipo(tipoRetornado));

        if (fabrica is null) return null;

        return fabrica.CriarComando(argumentos);

    }
}
