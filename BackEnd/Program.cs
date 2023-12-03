using BackEnd.Middleware;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Entities.Utilities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region ConnString
//Configuración específica para traer un string de conexión
string connString = builder
                            .Configuration
                            .GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<RENTCARContext>(options =>
                        options.UseSqlServer(
                            connString
                            ));

Util.ConnectionString = connString;
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependency Injection
builder.Services.AddDbContext<RENTCARContext>();
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<IAutomovilDAL, AutomovilDALImpl>();
builder.Services.AddScoped<IAutomovilService, AutomovilService>();
builder.Services.AddScoped<ICategoriaDAL, CategoriaDALImpl>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IClienteDAL, ClienteDALImpl>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IEmpleadoDAL, EmpleadoDALImpl>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<IMantenimientoDAL, MantenimientoDALImpl>();
builder.Services.AddScoped<IMantenimientoService, MantenimientoService>();
builder.Services.AddScoped<ISedeDAL, SedeDALImpl>();
builder.Services.AddScoped<ISedeService, SedeService>();
builder.Services.AddScoped<ISeguroDAL, SeguroDALImpl>();
builder.Services.AddScoped<ISeguroService,  SeguroService>();
builder.Services.AddScoped<ITransaccionDAL, TransaccionDALImpl>();
builder.Services.AddScoped<ITransaccionService, TransaccionService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
