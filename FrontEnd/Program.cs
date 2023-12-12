using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x => x.LoginPath = "/account/login");

builder.Services.AddSession();

builder.Services.AddHttpClient<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IAutomovileHelper, AutomovileHelper>();
builder.Services.AddScoped<ICategoriaHelper, CategoriaHelper>();
builder.Services.AddScoped<IClienteHelper, ClienteHelper>();
builder.Services.AddScoped<IEmpleadoHelper, EmpleadoHelper>();
builder.Services.AddScoped<IMantenimientoHelper, MantenimientoHelper>();
builder.Services.AddScoped<ISedeHelper, SedeHelper>();
builder.Services.AddScoped<ISeguroHelper, SeguroHelper>();
builder.Services.AddScoped<ITransaccioneHelper, TransaccioneHelper>();
builder.Services.AddScoped<ISecurityHelper, SecurityHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
