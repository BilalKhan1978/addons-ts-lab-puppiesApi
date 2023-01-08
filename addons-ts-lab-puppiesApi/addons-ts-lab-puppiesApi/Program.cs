using addons_ts_lab_puppiesApi.Data;
using addons_ts_lab_puppiesApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// I Injected following service for dependency Injection

builder.Services.AddScoped<IPuppyService, PuppyService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//I added to connect with Sql Server

builder.Services.AddDbContext<PuppyDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("PuppiesApiConnectionString")));



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
