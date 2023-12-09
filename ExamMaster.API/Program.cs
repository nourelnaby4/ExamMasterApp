using ExamMaster.Application;
using ExamMaster.Persistence;
using ExamMaster.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Dependencies
builder.Services.AddApplicationDependencies()
                .AddDomainDependencies()
                .AddPersistenceDependencies(builder.Configuration)
                .AddRegistrationModuleDependencies(builder.Configuration);
#endregion




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
