using StoreApi.BLL;
using StoreApi.DAL;
//using StoreApi.DAL.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IProductActions, ProductActions>();
builder.Services.AddScoped<IProduct, StoreApi.DAL.Product>();

builder.Services.AddScoped<ILoggerActions, LoggerActions>();
builder.Services.AddScoped<StoreApi.DAL.ILogger, Logger>();

/*
var mySqlConnectionConfig = new StoreContext();
builder.Services.AddScoped<mySqlConnectionConfig>();
*/

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
