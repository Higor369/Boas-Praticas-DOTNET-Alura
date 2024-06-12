using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;
using Alura.Adopet.Console.Servicos.Mail;
using Alura.Adopet.Console.Settings;

namespace Alura.Adopet.Console.Comandos;
public class ImportFactory: IComandoFactory
{
    public bool ConsegueCriarOTipo(Type tipoComando)
    {
        return tipoComando?.IsAssignableTo(typeof(Import)) ?? false;
    }

    public IComando? CriarComando(string[] argumentos)
    {
        var httpClientPet = new PetService(new AdopetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
        var leitorDeArquivos = LeitorDeArquivosFactory.CreatePetFrom(argumentos[1]);
        if (leitorDeArquivos is null) { return null; }
        var import = new Import(httpClientPet, leitorDeArquivos);
        import.DepoisDaExecucao += EnvioDeEmail.Disparar;
        return import;
    }
}
