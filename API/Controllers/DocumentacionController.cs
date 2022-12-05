using Domain.DTOs.Documentacion;
using Domain.DTOs.EquipoMedico;
using Domain.Interfaces.API_Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentacionController : ControllerBase
    {
        private IDocumentacion _service;
        public DocumentacionController(IDocumentacion applicationUserService)
        {
            _service = applicationUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var serviceResponse = await _service.GetDocumentos();
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var serviceResponse = await _service.GetDocumento(id);
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(DocumentacionDTO dto)
        {
            var serviceResponse = await _service.PostDocumento(dto);
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }
 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var serviceResponse = await _service.DeleteDocumento(id);
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }
    }
}
