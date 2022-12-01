using Domain.DTOs.ApplicationUser;
using Domain.Interfaces.API_Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private IApplicationUserService _service;
        public AccountController(IApplicationUserService applicationUserService)
        {
            _service = applicationUserService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(ApplicationUserPost dto)
        {
            var serviceResponse = await _service.Post(dto);
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginPost dto)
        {
            var serviceResponse = await _service.Login(dto);
            return StatusCode(serviceResponse.StatusCode, serviceResponse);
        }
    }
}
