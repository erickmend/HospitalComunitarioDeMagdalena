using Domain.Data;
using Domain.DTOs.ApplicationUser;
using Domain.DTOs.Responses;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.API_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.API_Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;


        public ApplicationUserService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<Response<LoginPost>> Login(LoginPost dto)
        {
            InternalStatusCodes internalStatus;
            try
            {
                var user = await _userManager.FindByEmailAsync(dto.Email);
                if (user == null || user.IsDeleted)
                {
                    internalStatus = InternalStatusCodes.GetEntity_ERROR;
                    return new Response<LoginPost>(internalStatus, new LoginPost());
                }


                string role = _userManager.GetRolesAsync(user).Result[0];

                var result = await _userManager.CheckPasswordAsync(user, dto.Password);
                if (result)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var appsettings = _configuration.GetSection("AppSettings");
                    var key = Encoding.ASCII.GetBytes(appsettings["Secret"]);
                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                    claims.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                    claims.AddClaim(new Claim(ClaimTypes.Role, role));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddDays(30),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwt = tokenHandler.WriteToken(token);

                    dto.Role = role;
                    dto.Token = jwt;
                    dto.Password = "";
                    dto.UserId = user.Id;

                    internalStatus = InternalStatusCodes.GetEntity_Ok;
                    return new Response<LoginPost>(internalStatus, dto);
                }

                internalStatus = InternalStatusCodes.GetEntity_ERROR;
                return new Response<LoginPost>(internalStatus, new LoginPost());

            }
            catch
            {
                internalStatus = InternalStatusCodes.GetEntity_ERROR;
                return new Response<LoginPost>(internalStatus, new LoginPost());
            }
        }

        public async Task<Response<ApplicationUserOutput>> Post(ApplicationUserPost applicationUserPost)
        {

            InternalStatusCodes internalStatus;
            try
            {
                if (await _userManager.FindByEmailAsync(applicationUserPost.Email) != null)
                {
                    internalStatus = InternalStatusCodes.CreateEntity_ERROR;
                    return new Response<ApplicationUserOutput>(internalStatus, null);
                }

                var user = new ApplicationUser
                {
                    UserName = applicationUserPost.Email,
                    Email = applicationUserPost.Email,
                    Name = applicationUserPost.Name,
                    LastName = applicationUserPost.LastName,
                    BirthDate = applicationUserPost.Birthdate,
                    IsActive = true,
                    IsDeleted = false,
                    CreationDate = DateTime.UtcNow,
                    LastUpdate = DateTime.UtcNow,
                    PhoneNumber = applicationUserPost.PhoneNumber,
                    EmailConfirmed = false,
                };

                var resultCreate = await _userManager.CreateAsync(user, applicationUserPost.Password);
                if (!resultCreate.Succeeded)
                {
                    internalStatus = InternalStatusCodes.CreateEntity_ERROR;
                    return new Response<ApplicationUserOutput>(internalStatus, null);
                }
                
                internalStatus = InternalStatusCodes.CreateEntity_Ok;
                await _userManager.AddToRoleAsync(user, "User");
                ApplicationUserOutput output = new ApplicationUserOutput
                {
                    Email = applicationUserPost.Email,
                    PhoneNumber = applicationUserPost.PhoneNumber,
                    UserName = applicationUserPost.Name,
                };
                return new Response<ApplicationUserOutput>(internalStatus, output);

            }
            catch  
            {
                internalStatus = InternalStatusCodes.Unknown_ERROR;
                return new Response<ApplicationUserOutput>(internalStatus, null);
            }
        }
    }
}
