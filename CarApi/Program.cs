using CarApi.Data;
using CarApi.Services;
using CarApi.Services.LoadEmulation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<AppDbContext>(options =>
{
    DatabaseSettings Dbsettings = new DatabaseSettings();

    builder.Configuration.GetSection("Postgress").Bind(Dbsettings);

    Console.WriteLine($"HERE >>>> {Dbsettings.GetConnectionString()}");

    options.UseNpgsql(Dbsettings.GetConnectionString());
});

builder.Services.AddScoped<ICarService,CarService>();
builder.Services.AddScoped<IPersonService,PersonService>();
builder.Services.AddScoped<ICarModelService,CarModelService>();


LoadEmulationOptions loadEmulationOptions = new();
builder.Configuration.GetSection("LEoptions").Bind(loadEmulationOptions);

builder.AddLoadEmulartion(loadEmulationOptions); // Load emulator services

builder.Services.AddOpenApi();

var app = builder.Build();

await app.SetupDatabaseAsync(); // create database

app.MapOpenApi();

app.UseLoadEmulationBucket(); // Set load emulation bucket
app.UseLoadEmulationDelay(); // Set load emulation delay

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
