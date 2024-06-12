namespace Alura.Adopet.Console.Comandos;
public interface IComandoFactory
{
    bool ConsegueCriarOTipo(Type? tipoComando);
    IComando? CriarComando(string[] argumentos);
}
