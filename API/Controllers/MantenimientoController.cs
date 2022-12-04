using Domain.DTOs.Mantenimiento;
using Domain.Entities;
using Domain.Interfaces.API_Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MantenimientoController : ControllerBase
    {
        private IMantenimientoService _service;
        public MantenimientoController(IMantenimientoService applicationUserService)
        {
            _service = applicationUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var serviceResponse = await _service.GetMantenimientos();
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var serviceResponse = await _service.GetMantenimiento(id);
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(int equipoId, MantenimientoDTO dto)
        {
            var serviceResponse = await _service.PostMantenimiento(equipoId, dto);
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, MantenimientoDTO dto)
        {
            var serviceResponse = await _service.PutMantenimiento(id, dto);
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var serviceResponse = await _service.DeleteMantenimiento(id);
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }
    }
}
