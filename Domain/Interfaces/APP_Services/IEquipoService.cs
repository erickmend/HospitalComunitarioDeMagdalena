using Domain.DTOs.EquipoMedico;
using Domain.DTOs.Mantenimiento;
using Domain.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.APP_Services
{
    public interface IEquipoService
    {
        Task<ApiResponse> Get();
        Task<ApiResponse> Get(int id);
        Task<ApiResponse> Create(EquipoMedicoDTO dto);
        Task<ApiResponse> Update(int equipoId, EquipoMedicoDTO dto);
        Task<ApiResponse> Delete(int id);
    }
}
