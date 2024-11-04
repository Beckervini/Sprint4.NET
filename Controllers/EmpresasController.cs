using Sprint1_2semestre.Services;
using Sprint1_2semestre.Models;
using Sprint1_2semestre.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprint1_2semestre.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;
        private readonly IRecommendationService _recommendationService;

        // Construtor com injeção de dependência dos serviços IEmpresaService e IRecommendationService
        public EmpresasController(IEmpresaService empresaService, IRecommendationService recommendationService)
        {
            _empresaService = empresaService;
            _recommendationService = recommendationService;
        }

        // Ação para criar uma nova empresa
        [HttpPost]
        public async Task<ActionResult<Empresa>> PostEmpresa(Empresa empresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var savedEmpresa = await _empresaService.SaveEmpresaAsync(empresa);
            return CreatedAtAction(nameof(GetEmpresa), new { id = savedEmpresa.Id }, savedEmpresa);
        }

        // Ação para obter todas as empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
            return Ok(await _empresaService.GetEmpresasAsync());
        }

        // Ação para obter uma empresa específica por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
            var empresa = await _empresaService.GetEmpresaByIdAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        // Ação para deletar uma empresa
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            var result = await _empresaService.DeleteEmpresaAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Ação para atualizar uma empresa
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresa(int id, Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return BadRequest();
            }

            var result = await _empresaService.UpdateEmpresaAsync(empresa);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Ação para obter recomendações de empresas para networking
        [HttpGet("{companyId}/recommendations")]
        public ActionResult<List<Recommendation>> GetRecommendations(int companyId)
        {
            var recommendations = _recommendationService.GetRecommendations((uint)companyId);
            return Ok(recommendations);
        }
    }
}
