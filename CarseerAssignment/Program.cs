using CarseerAssignment;
using CarseerAssignment.Repos;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//register the CSV service
builder.Services.AddScoped<ICSVService, CSVService>();
builder.Services.AddScoped<IFilterCars, FilterCars>();

//builder.Services.AddDbContext<DBcontext>(options => options.UseNpgsql("Host=localhost; Database=Carseer; Username=postgres; Password=Tala&2732000"));
builder.Services.AddDbContext<DBcontext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));
var options = new JsonSerializerOptions
{
    // Set the maximum depth to 64
    MaxDepth = 64
};
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
