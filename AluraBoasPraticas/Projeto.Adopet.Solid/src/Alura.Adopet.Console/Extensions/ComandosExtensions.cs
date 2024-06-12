using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Comandos;
using System.Reflection;

namespace Alura.Adopet.Console.Extensions;
public static class ComandosExtensions
{
    public static Type? GetTipoComando(this Assembly assembly,string instrucao)
    {
        return assembly
            .GetTypes() // lista de tipos
                        // filtrar apenas os tipos concretos que são comandos
            .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComando))) // IComando comando = t                                                                             
            .FirstOrDefault(t => t.GetCustomAttributes<DocComandoAttribute>()
            .Any(d => d.Instrucao.Equals(instrucao))); // recuperar apenas aquele que atende à instrução "instrucao"
    }

    public static IEnumerable<IComandoFactory?> GetFabricas(this Assembly assembly)
    {
        return assembly
            .GetTypes()
            // filtre os tipos concretos que implementam IComandoFactory
            .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComandoFactory)))
            // criar instâncias de cada fábrica (não é o ideal)
            .Select(f => Activator.CreateInstance(f) as IComandoFactory);
    }


}
