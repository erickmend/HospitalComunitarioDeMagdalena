using Core.API_Services;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces.API_Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Domain")));

builder.Services.AddIdentity<ApplicationUser, Role>(options => { options.Stores.MaxLengthForKeys = 128; options.User.AllowedUserNameCharacters = null; })
     .AddRoles<Role>()
     .AddEntityFrameworkStores<ApplicationDbContext>()
     .AddDefaultTokenProviders();


ConfigurationManager configuration = builder.Configuration;
var key = Encoding.ASCII.GetBytes(configuration["AppSettings:Secret"]);
builder.Services.AddAuthentication()
.AddCookie(cfg => cfg.SlidingExpiration = true)
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IApplicationUserService, ApplicationUserService>();
builder.Services.AddTransient<IEquiposService, EquipoService>();
builder.Services.AddTransient<IMantenimientoService, MantenimientoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    ApplicationDbInitializer.Seed(userManager, roleManager);
}

app.UseHttpsRedirection();

//app.UseIdentityServer();
//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

