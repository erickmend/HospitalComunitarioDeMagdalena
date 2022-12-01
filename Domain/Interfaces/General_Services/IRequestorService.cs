using Domain.DTOs.Responses;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.General_Services
{
    public interface IRequestorService
    {
        Task<ApiResponse> Call(string? client, string endpoint, MethodTypes method, object data, string? userToken);
    }
}
