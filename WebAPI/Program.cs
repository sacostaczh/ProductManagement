using Infrastructure.Persistence;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Application.Commands.AddProduct;
using Application.Interfaces;
using Infrastructure.Repositories;
using Application.Queries.GetAllProducts;
using Application.Queries.GetProductById;


var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión a la base de datos
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Agregar DbContext al contenedor de servicios
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(connectionString)); // Usa el proveedor adecuado si no es SQL Server


// Registrar los Repositorios de Application
builder.Services.AddScoped<IProductRepository, ProductRepository>();


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddProductCommandHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddProductCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllProductsQuery).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetProductByIdQuery).Assembly));


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
