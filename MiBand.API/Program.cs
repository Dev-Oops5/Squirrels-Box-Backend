using AutoMapper;
using MiBand.API.Domain.Models;
using MiBand.API.Domain.Repositories;
using MiBand.API.Domain.Repositories.Base;
using MiBand.API.Domain.Services;
using MiBand.API.Domain.Services.Communications;
using MiBand.API.Mapping;
using MiBand.API.Persistence.Contexts;
using MiBand.API.Persistence.Repositories;
using MiBand.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AppDb");


var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new ModelToResourceProfile());
    cfg.AddProfile(new ResourceToModelProfile());
});

var mapper = config.CreateMapper();

// Add services to the container.

//Add Repository Pattern
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IBaseRespository<Session>, SessionRepository>();
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<IBaseRespository<User>, UserRepository>();
builder.Services.AddScoped<IStateRepository<Box>, BoxRepository>();
builder.Services.AddScoped<IStateRepository<Section>, SectionRepository>();
builder.Services.AddScoped<IStateRepository<Item>, ItemRepository>();
builder.Services.AddScoped<IStateRepository<Spec>, SpecRepository>();
builder.Services.AddScoped<IStateRepository<Shared>, SharedRepository>();

builder.Services.AddScoped<IBaseService<Session,SessionResponse>, SessionService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IBaseService<User, UserResponse>, UserService>();
builder.Services.AddScoped<IStateService<Box,BoxResponse>, BoxService>();
builder.Services.AddScoped<IStateService<Section, SectionResponse>, SectionService>();
builder.Services.AddScoped<IStateService<Item, ItemResponse>, ItemService>();
builder.Services.AddScoped<IStateService<Spec, SpecResponse>, SpecService>();
builder.Services.AddScoped<IStateService<Shared, SharedResponse>, SharedService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Using db connection
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

//Add Swagger Support
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// AutoMapper Setup
builder.Services.AddSingleton(mapper);

// Token authentication view
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test01", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."

    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});

// Authentication init service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
