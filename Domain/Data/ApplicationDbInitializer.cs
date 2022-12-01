using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public static class ApplicationDbInitializer
    {
        public static void Seed(UserManager<ApplicationUser> usermanager, RoleManager<Role> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            {
                Role role = new Role
                {
                    Name = "Admin"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).GetAwaiter().GetResult();
            }
            if (!roleManager.RoleExistsAsync("User").GetAwaiter().GetResult())
            {
                Role role = new Role
                {
                    Name = "User"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).GetAwaiter().GetResult();
            }

            var checkuseradmin = usermanager.FindByEmailAsync("IBMagdalena@admin.com").GetAwaiter().GetResult();
            if (checkuseradmin == null)
            {
                ApplicationUser user = new()
                {
                    Email = "IBMagdalena@admin.com",
                    UserName = "IBMagdalena",
                    Name = "Administrador",
                    CreationDate = DateTime.UtcNow,
                    LastUpdate = DateTime.UtcNow,
                    EmailConfirmed = true
                };
                IdentityResult Result = usermanager.CreateAsync(user, "Hcmagdalena123!").GetAwaiter().GetResult();
                if (Result.Succeeded)
                {
                    var admin = usermanager.FindByEmailAsync("IBMagdalena@admin.com").GetAwaiter().GetResult();
                    usermanager.AddToRoleAsync(admin, "Admin").GetAwaiter().GetResult();
                }
            }
        }
    }
}
