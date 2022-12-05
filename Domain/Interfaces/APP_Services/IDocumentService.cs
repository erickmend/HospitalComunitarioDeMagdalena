using Domain.DTOs.Documentacion;
using Domain.DTOs.EquipoMedico;
using Domain.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.APP_Services
{
    public interface IDocumentService
    {
        Task<ApiResponse> Get();
        Task<ApiResponse> Get(int id);
        Task<ApiResponse> Create(DocumentacionDTO dto);
        Task<ApiResponse> Delete(int id);
    }
}
