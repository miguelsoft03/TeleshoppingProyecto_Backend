using Microsoft.EntityFrameworkCore;
using TeleshoppingProyecto.Entidades;
using TeleshoppingProyecto.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//add Cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
                                builder => builder.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod()));

// Agrega la conexion de la BD
builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
    opciones.UseSqlServer("name=DefaultConnection"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();
builder.Services.AddScoped<IRepositorioRoles, RepositorioRoles>();
builder.Services.AddScoped<IRepositorioProductos, RepositorioProductos>();
builder.Services.AddScoped<IRepositorioCompras, RepositorioCompras>();
builder.Services.AddScoped<IRepositorioOrdenes, RepositorioOrdenes>();
builder.Services.AddScoped<IRepositorioPagos, RepositorioPagos>();
builder.Services.AddScoped<IRepositorioEntrega, RepositorioEntrega>();
builder.Services.AddScoped<IRepositorioTiposTransporte, RepositorioTiposTransporte>();
builder.Services.AddScoped<IRepositorioEmpresasTransporte, RepositorioEmpresasTransporte>();
builder.Services.AddScoped<IRepositorioQuejas, RepositorioQuejas>();
builder.Services.AddScoped<IRepositorioProveedores, RepositorioProveedores>();
builder.Services.AddScoped<IRepositorioStocks, RepositorioStocks>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Apply CORS policy
app.UseCors("AllowWebApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
