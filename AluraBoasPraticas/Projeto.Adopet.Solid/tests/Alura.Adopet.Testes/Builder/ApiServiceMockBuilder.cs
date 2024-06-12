using Alura.Adopet.Console.Servicos.Abstracoes;
using Moq;

namespace Alura.Adopet.Testes.Builder;

internal static class ApiServiceMockBuilder
{
    public static Mock<IApiService<T>> GetMock<T>()
    {
        return new Mock<IApiService<T>>(MockBehavior.Default);
    }

    public static Mock<IApiService<T>> GetMockList<T>(List<T> lista)
    {
        var mockService = new Mock<IApiService<T>>(MockBehavior.Default);
        mockService.Setup(_ => _.ListAsync())
            .ReturnsAsync(lista);
        return mockService;
    }

}