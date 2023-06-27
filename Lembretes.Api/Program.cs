using Lembretes.Domain.Interfaces;
using Lembretes.Infra.Data.Repositories;
using Lembretes.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dependency injection - Services
builder.Services.AddScoped<ILembretesService, LembretesService>();
builder.Services.AddScoped<IPessoasService, PessoasService>();
builder.Services.AddScoped<IVendasService, VendasService>();

//dependency injection - Repositories
builder.Services.AddSingleton<ILembretesRepository, LembretesRepository>();
builder.Services.AddSingleton<IPessoasRepository, PessoasRepository>();
builder.Services.AddSingleton<IVendasRepository, VendasRepository>();

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
