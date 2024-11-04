using Sprint1_2sem.Tests.Factories;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Sprint1_2sem.Tests.SystemTests
{
    public class EmpresasControllerSystemTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        // Injeção da fábrica customizada para os testes
        public EmpresasControllerSystemTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Should_Return_Empresas_List()
        {
            // Realiza a chamada à API
            var response = await _client.GetAsync("/api/empresas");

            
            response.EnsureSuccessStatusCode(); 

            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Empresa X", responseString); 
        }
    }
}
