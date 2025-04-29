using Microsoft.EntityFrameworkCore;
using studentRegistration.API.studentRegistration.Infrastructure;
using studentRegistration.Infrastructure.Persistence;
using System;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//// Eliminar referencias circulares
builder.Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<StudentRegistrationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(9, 3, 0))
    )
);

//registro servicios de infraestructura
builder.Services.AddInfrastructureServices();

//registro casos de uso
builder.Services.AddApplicationServices();

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
