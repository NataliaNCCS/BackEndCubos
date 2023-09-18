using BackEndCubos.Application.Interfaces;
using BackEndCubos.Application;
using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Infra.Data.Repositories;
using BackEndCubos.Infra.Data;
using Microsoft.EntityFrameworkCore;
using BackEndCubos.Domain.Services;
using Microsoft.Win32;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContext<PostgreSQLContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection")));

//bool isWindows = System.Runtime.InteropServices.RuntimeInformation
//                                           .IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows);

//ProcessStartInfo processStartInfo = new ProcessStartInfo();

//if (isWindows)
//{

//    processStartInfo.FileName = "cmd.exe";
//    processStartInfo.Arguments = "";
//}
//else
//{
//    processStartInfo.FileName = @"bash";
//    processStartInfo.Arguments = "";
//}

// Add scoped services to the container.
builder.Services.AddScoped<IApplicationServicePerson, ApplicationServicePerson>();
builder.Services.AddScoped<IApplicationServicePersonAccount, ApplicationServicePersonAccount>();
builder.Services.AddScoped<IServicePerson, ServicePerson>();
builder.Services.AddScoped<IServicePersonAccount, ServicePersonAccount>();
builder.Services.AddScoped<IRepositoryPerson, RepositoryPerson>();
builder.Services.AddScoped<IRepositoryPersonAccount, RepositoryPersonAccount>();

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
