using Business.Abstract;
using Business.Concrete.SaglikManager;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var config = builder.Configuration.GetSection("Redis");
    var host = config["Host"];
    var port = config["Port"];
    var connectionString = $"{host}:{port}";
    return ConnectionMultiplexer.Connect(connectionString);
}); 
builder.Services.AddDbContext<HastaneContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConn")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepo<>));
builder.Services.AddScoped<SaglikManager>();

builder.Services.AddControllers();
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
