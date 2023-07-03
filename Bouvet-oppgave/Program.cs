using Bouvet_oppgave.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(builder => builder
    .WithOrigins("http://localhost:3000") // Allow requests from "http://localhost:3000"
    .WithOrigins("http://localhost:3001") // Allow requests from "http://localhost:3001"
    .AllowAnyHeader() // Allow any header in the requests
    .AllowAnyMethod() // Allow any HTTP method (GET, POST, PUT, DELETE, etc.)
    .AllowCredentials()); // Allow the inclusion of credentials (cookies) in the requests


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bouvet-oppgave v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();