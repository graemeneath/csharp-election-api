using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("election-api.tests")]

Console.WriteLine("Starting service...");

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:8080");

// Add services for controllers
builder.Services.AddControllers();

var app = builder.Build();

// Enable routing and controllers
app.UseRouting();

// Top level route registrations
app.MapControllers();

// Keeps the application running and monitoring requests
app.Run();
