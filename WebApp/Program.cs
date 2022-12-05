using Core.APP_Services;
using Core.General_Services;
using Domain.Interfaces.APP_Services;
using Domain.Interfaces.General_Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using WebApp.Authentication;
using WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationCore();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<IRequestorService, RequestorService>();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddSingleton<IMantenimientoService, MantenimientoService>();
builder.Services.AddSingleton<IEquipoService, EquipoService>();
builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddScoped<IDocumentService, DocumentacionService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
