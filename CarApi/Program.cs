using CarApi.Data;
using CarApi.Services;
using CarApi.Services.FakeLoad;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<AppDbContext>(options =>
{
    DatabaseSettings Dbsettings = new DatabaseSettings();

    builder.Configuration.GetSection("Postgress").Bind(Dbsettings);

    options.UseNpgsql(Dbsettings.GetConnectionString());
});

builder.Services.AddScoped<ICarService,CarService>();
builder.Services.AddScoped<IPersonService,PersonService>();
builder.Services.AddScoped<ICarModelService,CarModelService>();


builder.Services.AddOpenApi();

var app = builder.Build();

await app.SetupDatabaseAsync(); // create database

app.MapStaticAssets();
app.MapScalarApiReference();
app.MapOpenApi();
app.MapScalarApiReference();

app.UseFakeLoad();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
