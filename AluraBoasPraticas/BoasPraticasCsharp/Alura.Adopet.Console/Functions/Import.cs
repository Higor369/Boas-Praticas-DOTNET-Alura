using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Functions;
internal class Import
{
    private HttpClient client;

    public Import()
    {
         client = ConfiguraHttpClient("http://localhost:5057");
    }

    public async Task ImportacaoArquivoPetAsync(string caminhoDoArquivoDeImportacao)
    {
        List<Pet> listaDePet = new List<Pet>();

        using (StreamReader sr = new StreamReader(caminhoDoArquivoDeImportacao))
        {
            while (!sr.EndOfStream)
            {
                // separa linha usando ponto e vírgula
                string[] propriedades = sr.ReadLine().Split(';');
                // cria objeto Pet a partir da separação
                Pet pet = new Pet(Guid.Parse(propriedades[0]),
                  propriedades[1],
                  TipoPet.Cachorro
                 );

                System.Console.WriteLine(pet);
                listaDePet.Add(pet);
            }
        }
        foreach (var pet in listaDePet)
        {
            try
            {
                var resposta = await CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        System.Console.WriteLine("Importação concluída!");
    }

    private HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }
    private async Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        HttpResponseMessage? response = null;
        using (response = new HttpResponseMessage())
        {
            return await client.PostAsJsonAsync("pet/add", pet);
        }
    }

    

}
