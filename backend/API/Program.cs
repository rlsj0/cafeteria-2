using CafeteriaApp.Business;
using CafeteriaApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// TODO: uno de estos por servicio
builder.Services.AddScoped<ICafeService, CafeService>();

// TODO: crear cadena de conexión en appsettings.json
var connectionString = builder.Configuration.GetConnectionString("ServerDB_localhost");

// Añadimos el contexto
builder.Services.AddDbContext<CafeteriaAppContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Relacionamos la implementacion e interfaz del repositorio
// TODO: uno de estos por repositorio
builder.Services.AddScoped<ICafeRepository, CafeRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

