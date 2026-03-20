using Microsoft.EntityFrameworkCore;
using ProductManager.Application.Interfaces;
using ProductManager.Application.Services;
using ProductManager.Infrastructure.Data;
using ProductManager.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();

// Apenas para este caso challenge, em um cenário real, o ideal seria usar um banco de dados relacional, como SQL Server, PostgreSQL, etc.
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("TOTVS-product-challend-DB"));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS (Angular)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAngular");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers(); 

app.Run();