using ExamMaster.Application;
using ExamMaster.Persistence;
using ExamMaster.Domain;
using ExamMaster.Service;
using Microsoft.AspNetCore.Diagnostics;
using AVMS.Application.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Dependencies
builder.Services.AddApplicationDependencies(builder.Configuration)
                .AddDomainDependencies()
                .AddPersistenceDependencies(builder.Configuration)
                .AddRegistrationModuleDependencies(builder.Configuration)
                .AddServiceModuleDependencies(builder.Configuration);
#endregion


#region ADD CORS
var CORS = "_cors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(CORS,
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<GlobalExceptionHandlerMiddelware>();


app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors(CORS);
app.UseAuthorization();
app.MapControllers();
app.Run();
