namespace Alura.Adopet.Console.Comandos;
public class HelpFactory : IComandoFactory
{
    public bool ConsegueCriarOTipo(Type? tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Help)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var comandoASerExibido = argumentos.Length == 2 ? argumentos[1] : null;
        return new Help(comandoASerExibido);
    }
}
