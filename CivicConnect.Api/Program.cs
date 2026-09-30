using System.Text.Json.Serialization;
using CivicConnect.Api.Middleware;
using CivicConnect.Core.Interfaces;
using CivicConnect.Core.Observers;
using CivicConnect.Core.Services;
using CivicConnect.Core.Strategies;
using CivicConnect.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// --- Web API basics ---
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        // Show enums as "Critical" instead of 3 in requests and responses
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Infrastructure (database, repositories, unit of work) ---
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is missing from appsettings.json.");
builder.Services.AddInfrastructure(connectionString);

// --- Core wiring (this file is the ONLY place that knows all the concrete classes) ---
builder.Services.AddSingleton<IPriorityCalculationStrategy, EmergencyPriorityStrategy>();
builder.Services.AddSingleton<IPriorityCalculationStrategy, StandardPriorityStrategy>();
builder.Services.AddSingleton<PriorityCalculationContext>();
builder.Services.AddScoped<ITicketObserver, AuditLogTicketObserver>();
builder.Services.AddScoped<ITicketService, TicketService>();

var app = builder.Build();

app.UseMiddleware<DomainExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Services.EnsureDatabaseCreated();   // creates civicconnect.db on first run
}

app.MapControllers();
app.Run();

// Lets a future integration-test project start the app in memory
public partial class Program { }
