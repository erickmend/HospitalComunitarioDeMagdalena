using Domain.DTOs.Documentacion;
using Domain.DTOs.EquipoMedico;
using Domain.DTOs.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.API_Services
{
    public interface IDocumentacion
    {
        Task<Response<List<Documentacion>>> GetDocumentos();
        Task<Response<Documentacion>> GetDocumento(int id);
        Task<Response<Documentacion>> PostDocumento(DocumentacionDTO dto);
        Task<Response<Documentacion>> DeleteDocumento(int id);
    }
}
