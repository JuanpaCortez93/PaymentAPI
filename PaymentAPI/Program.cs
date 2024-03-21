using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.DataAccess.ApplicationDataBaseContext;
using PaymentAPI.DataAccess.Repos;
using PaymentAPI.DataAccess.Repos.Interfaces;
using PaymentAPI.DataAccess.Services;
using PaymentAPI.Models.AutoMappingProfiles;
using PaymentAPI.Models.DTOs;
using PaymentAPI.Models.FormatValidators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Entity Framework ORM
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"), b => b.MigrationsAssembly("PaymentAPI")));

// Services
// Repository
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Another Services
builder.Services.AddKeyedScoped<IPaymentDetailsService, PaymentDetailsService>("PaymentDetailsService");

//Mappers
builder.Services.AddAutoMapper(typeof(PaymentDetailsAutoMapperProfile));

//Validators
builder.Services.AddScoped<IValidator<PaymentDetailsPostDTO>, PaymentDetailsPostFormatValidator>();
builder.Services.AddScoped<IValidator<PaymentDetailsPutDTO>, PaymentsDetailsPutFormatValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();