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
        Task<List<Mantenimiento>> GetMantenimientos();
        Task<Mantenimiento> GetMantenimiento(int id);
        Task<Mantenimiento> PostMantenimiento(Mantenimiento mantenimiento);
        Task<Mantenimiento> PutMantenimiento(int id, Mantenimiento mantenimiento);
        Task<Mantenimiento> DeleteMantenimiento(int id);
    }
}
