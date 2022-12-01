using Core.Extensions;
using Domain.DTOs.ApplicationUser;
using Domain.DTOs.Responses;
using Domain.Enums;
using Domain.Interfaces.APP_Services;
using Domain.Interfaces.General_Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.APP_Services
{
    public class AccountService : IAccountService
    {
        private readonly IRequestorService _requestorService;
        public AccountService(IRequestorService requestorService)
        {
            _requestorService = requestorService;
        }

        public async Task<ApiResponse> Login(LoginPost dto)
        {
            return await _requestorService.Call(string.Empty, "Account/Login", MethodTypes.POST, dto, string.Empty);
        }

        public async Task<ApiResponse> Register(ApplicationUserPost dto)
        {
            return await _requestorService.Call(string.Empty, "Account", MethodTypes.POST, dto, string.Empty);
        }
    }
}
