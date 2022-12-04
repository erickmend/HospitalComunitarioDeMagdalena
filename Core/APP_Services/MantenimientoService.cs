using Domain.DTOs.Mantenimiento;
using Domain.DTOs.Responses;
using Domain.Enums;
using Domain.Interfaces.APP_Services;
using Domain.Interfaces.General_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.APP_Services
{
    public class MantenimientoService : IMantenimientoService
    {
        private readonly IRequestorService _requestorService;
        public MantenimientoService(IRequestorService requestorService)
        {
            _requestorService = requestorService;
        }
        public async Task<ApiResponse> Create(int equipoId,MantenimientoDTO dto)
        {
            return await _requestorService.Call(string.Empty, $"Mantenimiento/{equipoId}", MethodTypes.POST, dto, string.Empty);
        }

        public async Task<ApiResponse> Delete(int id)
        {
            return await _requestorService.Call(string.Empty, $"Mantenimiento/{id}", MethodTypes.DELETE, null, string.Empty);
        }

        public async Task<ApiResponse> Get()
        {
            return await _requestorService.Call(string.Empty, "Mantenimiento", MethodTypes.GET, null, string.Empty);
        }

        public async Task<ApiResponse> Get(int id)
        {
            return await _requestorService.Call(string.Empty, $"Mantenimiento/{id}", MethodTypes.GET, null, string.Empty);
        }

        public async Task<ApiResponse> Update(int id, MantenimientoDTO dto)
        {
            return await _requestorService.Call(string.Empty, $"Mantenimiento/{id}", MethodTypes.PUT, dto, string.Empty);
        }
    }
}
