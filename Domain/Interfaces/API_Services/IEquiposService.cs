using Domain.DTOs.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.API_Services
{
    public interface IEquiposService
    {
        Task<Response<List<EquipoMedico>>> GetEquipos();
        Task<Response<EquipoMedico>> GetEquipo(int id);
        Task<Response<EquipoMedico>> PostEquipo(EquipoMedico equipo);
        Task<Response<EquipoMedico>> PutEquipo(int id, EquipoMedico equipo);
        Task<Response<EquipoMedico>> DeleteEquipo(int id);
    }
}
