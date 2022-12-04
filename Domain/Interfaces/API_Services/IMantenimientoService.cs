using Domain.DTOs.Mantenimiento;
using Domain.DTOs.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.API_Services
{
    public interface IMantenimientoService
    {
        Task<Response<List<Mantenimiento>>> GetMantenimientos();
        Task<Response<Mantenimiento>> GetMantenimiento(int id);
        Task<Response<Mantenimiento>> PostMantenimiento(int EquipoId , MantenimientoDTO mantenimiento);
        Task<Response<Mantenimiento>> PutMantenimiento(int id, MantenimientoDTO mantenimiento);
        Task<Response<Mantenimiento>> DeleteMantenimiento(int id);
    }
}
