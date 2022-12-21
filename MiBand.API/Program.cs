using AutoMapper;
using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories;
using MiBand.API.Domain.Services;
using MiBand.API.Mapping;
using MiBand.API.Persistence.Contexts;
using MiBand.API.Persistence.Repositories;
using MiBand.API.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDb");


var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new ModelToResourceProfile());
    cfg.AddProfile(new RecourceToModelProfile());
});

var mapper = config.CreateMapper();

// Add services to the container.

//Add Repository Pattern
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Using db connection
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

//Add Swagger Support
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper Setup
builder.Services.AddSingleton(mapper);

var app = builder.Build();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger(x => x.SerializeAsV2 = true);

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
