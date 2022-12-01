using Domain.DTOs.ApplicationUser;
using Domain.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.APP_Services
{
    public interface IAccountService
    {
        Task<ApiResponse> Register(ApplicationUserPost dto);
        Task<ApiResponse> Login(LoginPost dto);
    }
}
