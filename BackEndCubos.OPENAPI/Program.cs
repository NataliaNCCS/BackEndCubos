using BackEndCubos.Domain.Core.Interfaces.Repositories;
using BackEndCubos.Domain.Core.Interfaces.Services;
using BackEndCubos.Domain.Services;
using BackEndCubos.Infra.Data;
using BackEndCubos.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

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


// Add scoped services to the container.
builder.Services.AddScoped<IServicePerson, ServicePerson>();
builder.Services.AddScoped<IServicePersonAccount, ServicePersonAccount>();
builder.Services.AddScoped<IServiceCard, ServiceCard>();
builder.Services.AddScoped<IServiceTransaction, ServiceTransaction>();
builder.Services.AddScoped<IRepositoryPerson, RepositoryPerson>();
builder.Services.AddScoped<IRepositoryPersonAccount, RepositoryPersonAccount>();
builder.Services.AddScoped<IRepositoryCard, RepositoryCard>();
builder.Services.AddScoped<IRepositoryTransaction, RepositoryTransaction>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
