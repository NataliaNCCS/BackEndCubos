using BackEndCubos.Application;
using BackEndCubos.Application.Interfaces;
using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Domain.Services;
using BackEndCubos.Infra.Data;
using BackEndCubos.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddDbContext<PostgreSQLContext>(options =>
        options.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection")));


// Add scoped services to the container.
builder.Services.AddScoped<IApplicationServicePerson, ApplicationServicePerson>();
builder.Services.AddScoped<IApplicationServicePersonAccount, ApplicationServicePersonAccount>();
builder.Services.AddScoped<IServicePerson, ServicePerson>();
builder.Services.AddScoped<IServicePersonAccount, ServicePersonAccount>();
builder.Services.AddScoped<IRepositoryPerson, RepositoryPerson>();
builder.Services.AddScoped<IRepositoryPersonAccount, RepositoryPersonAccount>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cubos API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cubos API");
    c.RoutePrefix = "swagger";
});

app.MapRazorPages();

app.Run();
