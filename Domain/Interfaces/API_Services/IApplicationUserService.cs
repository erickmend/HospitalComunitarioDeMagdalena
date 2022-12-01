using Domain.DTOs.ApplicationUser;
using Domain.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.API_Services
{
    public interface IApplicationUserService
    {
        Task<Response<ApplicationUserOutput>> Post(ApplicationUserPost applicationUserPost);
        Task<Response<LoginPost>> Login(LoginPost dto);
    }
}
