using Domain.DTOs.EquipoMedico;
using Domain.Entities;
using Domain.Interfaces.API_Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EquipoController : ControllerBase
    {
        private IEquiposService _service;
        public EquipoController(IEquiposService applicationUserService)
        {
            _service = applicationUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var serviceResponse = await _service.GetEquipos();
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var serviceResponse = await _service.GetEquipo(id);
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(EquipoMedicoDTO dto)
        {
            var serviceResponse = await _service.PostEquipo(dto);
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, EquipoMedicoDTO dto)
        {
            var serviceResponse = await _service.PutEquipo(id, dto);
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var serviceResponse = await _service.DeleteEquipo(id);
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }
    }
}
