using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Arquivos;
public class PetsDoCsv : LeitorDeArquivoCsv<Pet>
{
    public PetsDoCsv(string caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
    {
    }

    public override Pet CriarDaLinhaCsv(string linha)
    {
        string[] propriedades = linha.Split(';');
        bool guidValido = Guid.TryParse(propriedades[0], out Guid petId);
        if (!guidValido) throw new ArgumentException("Identificador do pet inválido!");

        bool tipoValido = int.TryParse(propriedades[2], out int tipoPet);
        if (!tipoValido) throw new ArgumentException("Tipo do pet inválido!");

        TipoPet tipo = tipoPet == 1 ? TipoPet.Gato : TipoPet.Cachorro;

       return new Pet(petId, propriedades[1], tipo);
    }
}
