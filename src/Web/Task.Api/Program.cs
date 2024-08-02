using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using AutoMapper;
using Application.Mappings;
using Infrastructure.Data.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Domain.Entities;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;
using Application.Dtos;
using MediatR;
using Infrastructure.Data.Exceptions;
using Application.Commands;
using Application.Queries;
using Infrastructure;






var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Add MVC Services
builder.Services.AddControllers().AddFluentValidation(
    v => v.RegisterValidatorsFromAssemblyContaining<MyEntityDto>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Task.Api",
        Version = "v1",
        Description = "A simple example ASP.NET Core Web API",
    });

    // Incluir comentarios XML de la documentación de los métodos
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});



// Inyección de dependencias

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<ITaskService, TaskService>();


builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(
        typeof(Program).Assembly,
        typeof(Application.Commands.CreateTask.CreateTaskCommandHandler).Assembly,
        typeof(Application.Commands.UpdateTask.UpdateTaskCommandHandler).Assembly,
        typeof(Application.Commands.DeleteTask.DeleteTaskCommandHandler).Assembly,
        typeof(Application.Queries.GetTasks.GetAllTasksQueryHandler).Assembly,
        typeof(Application.Queries.GetByTitleTask.GetByTitleTaskQuery).Assembly
    ));
// Registrar MediatR con todos los assemblies que contienen handlers
//var applicationAssembly = typeof(Application.Commands.CreateTask.CreateTaskCommandHandler).Assembly;
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));



builder.Services.AddAutoMapper(typeof(MappinggProfile));


// Configuración de Entity Framework Core
builder.Services.AddDbContext<DbContextConfigurer>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



//---Midleware

//Configuracion de CORS (Cross-Origin Resource Sharing) para permitir el acceso a la API desde cualquier origen

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task.Api v1");
        });
}

// Middleware de manejo de excepciones
app.UseMiddleware<ExceptionHandlingMiddleware>();


// Redirección HTTP a HTTPS
app.UseHttpsRedirection();
// Habilitar autorización
app.UseAuthorization();
// Configuración de CORS
app.UseCors("AllowAnyOrigin");
// Usar controladores
app.MapControllers();


app.Run();
