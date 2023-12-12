using BackEnd.Middleware;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Entities.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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


#region Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>

{
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

}



    )
    .AddEntityFrameworkStores<RENTCARContext>()
    .AddDefaultTokenProviders();



#endregion



#region JWT


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

})

    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });




#endregion



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
