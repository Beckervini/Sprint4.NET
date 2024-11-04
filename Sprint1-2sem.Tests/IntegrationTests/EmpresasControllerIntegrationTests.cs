using Moq;
using Microsoft.AspNetCore.Mvc;
using Sprint1_2semestre.Controllers;
using Sprint1_2semestre.Models;
using Sprint1_2semestre.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace Sprint1_2semestre.Tests.IntegrationTests
{
    public class EmpresasControllerIntegrationTests
    {
        private readonly Mock<IEmpresaService> _mockEmpresaService;
        private readonly Mock<IRecommendationService> _mockRecommendationService;
        private readonly EmpresasController _controller;

        public EmpresasControllerIntegrationTests()
        {
            // Configura o mock para o serviço de empresas
            _mockEmpresaService = new Mock<IEmpresaService>();

            // Configura o mock para o serviço de recomendação
            _mockRecommendationService = new Mock<IRecommendationService>();

            // Injeta o mock do IEmpresaService e do IRecommendationService no controlador
            _controller = new EmpresasController(_mockEmpresaService.Object, _mockRecommendationService.Object);
        }

        [Fact]
        public async Task PostEmpresa_ReturnsCreatedAtActionResult_WhenModelIsValid()
        {
            // Configura o mock para o serviço (exemplo de uma empresa válida)
            var empresa = new Empresa { Id = 1, Nome = "Empresa Teste", Cnpj = "12345678000195" };
            _mockEmpresaService.Setup(service => service.SaveEmpresaAsync(It.IsAny<Empresa>()))
                               .ReturnsAsync(empresa);

            // Atuar - chama o método PostEmpresa
            var result = await _controller.PostEmpresa(empresa);

            // Asserções - verifica se o resultado foi o esperado
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<Empresa>(actionResult.Value);
            Assert.Equal("Empresa Teste", returnValue.Nome);
        }
    }
}
