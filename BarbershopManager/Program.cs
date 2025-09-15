using BarbershopManager.BarbershopManager.Application.UseCases.CreateRevenue;
using BarbershopManager.BarbershopManager.Application.UseCases.DeleteRevenue;
using BarbershopManager.BarbershopManager.Application.UseCases.GetAllRevenue;
using BarbershopManager.BarbershopManager.Application.UseCases.GetRevenueById;
using BarbershopManager.BarbershopManager.Application.UseCases.UpdateRevenue;
using BarbershopManager.BarbershopManager.Domain.Repositories;
using BarbershopManager.BarbershopManager.Infrastructure.Repositories;
using Fluent.Infrastructure.FluentDBContext;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRevenueRepository, RevenueRepository>();

builder.Services.AddScoped<IGetAllRevenue, GetAllRevenueUseCase>();
builder.Services.AddScoped<IGetRevenueById, GetRevenueByIdUseCase>();
builder.Services.AddScoped<ICreateRevenue, CreateRevenueUseCase>();
builder.Services.AddScoped<IDeleteRevenue, DeleteRevenueUseCase>();
builder.Services.AddScoped<IUpdateRevenue, UpdateRevenueUseCase>();

builder.Services.AddAutoMapper(typeof(Program));


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
