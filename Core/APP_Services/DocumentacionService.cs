
using Domain.DTOs.Documentacion;
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
    public class DocumentacionService : IDocumentService
    {
        private readonly IRequestorService _requestorService;
        public DocumentacionService(IRequestorService requestorService)
        {
            _requestorService = requestorService;
        }
        public async Task<ApiResponse> Create(DocumentacionDTO dto)
        {
            return await _requestorService.Call(string.Empty, $"Documentacion", MethodTypes.POST, dto, string.Empty);
        }

        public async Task<ApiResponse> Delete(int id)
        {
            return await _requestorService.Call(string.Empty, $"Documentacion/{id}", MethodTypes.DELETE, null, string.Empty);
        }

        public async Task<ApiResponse> Get()
        {
            return await _requestorService.Call(string.Empty, "Documentacion", MethodTypes.GET, null, string.Empty);
        }

        public async Task<ApiResponse> Get(int id)
        {
            return await _requestorService.Call(string.Empty, $"Documentacion/{id}", MethodTypes.GET, null, string.Empty);
        }

    }
}
