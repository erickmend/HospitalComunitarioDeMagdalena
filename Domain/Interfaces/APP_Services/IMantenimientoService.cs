using Domain.DTOs.Mantenimiento;
using Domain.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.APP_Services
{
    public interface IMantenimientoService
    {
        Task<ApiResponse> Get();
        Task<ApiResponse> Get(int id);
        Task<ApiResponse> Create(int equipoId, MantenimientoDTO dto);
        Task<ApiResponse> Update(int mantenimientoId, MantenimientoDTO dto);
        Task<ApiResponse> Delete(int id);

    }
}
