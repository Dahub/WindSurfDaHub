using Microsoft.EntityFrameworkCore;
using WindSurfDaGet.Application;
using WindSurfDaGet.Infrastructure;
using WindSurfDaGet.Api.Endpoints;
using WindSurfDaGet.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add health checks
builder.Services.AddHealthChecks();

// Add Application Layer
builder.Services.AddApplication();

// Add Infrastructure Layer
builder.Services.AddInfrastructure(builder.Configuration);

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Désactivation de la redirection HTTPS en développement
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// Use routing and CORS before endpoints
app.UseRouting();
app.UseCors();

// Map health check endpoint
app.MapHealthChecks("/health");

// Apply migrations
try
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}
catch (Exception ex)
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred while migrating the database.");
}

// Map endpoints
app.MapUserEndpoints();

app.Run();
