using Domain.DTOs.EquipoMedico;
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
    public class EquipoService : IEquipoService
    {
        private readonly IRequestorService _requestorService;
        public EquipoService(IRequestorService requestorService)
        {
            _requestorService = requestorService;
        }
        public async Task<ApiResponse> Create(EquipoMedicoDTO dto)
        {
            return await _requestorService.Call(string.Empty, $"Equipo", MethodTypes.POST, dto, string.Empty);
        }

        public async Task<ApiResponse> Delete(int id)
        {
            return await _requestorService.Call(string.Empty, $"Equipo/{id}", MethodTypes.DELETE, null, string.Empty);

        }

        public async Task<ApiResponse> Get()
        {
            return await _requestorService.Call(string.Empty, "Equipo", MethodTypes.GET, null, string.Empty);

        }

        public async Task<ApiResponse> Get(int id)
        {
            return await _requestorService.Call(string.Empty, $"Equipo/{id}", MethodTypes.GET, null, string.Empty);

        }

        public async Task<ApiResponse> Update(int equipoId, EquipoMedicoDTO dto)
        {
            return await _requestorService.Call(string.Empty, $"Equipo/{equipoId}", MethodTypes.PUT, dto, string.Empty);

        }

 
    }
}
