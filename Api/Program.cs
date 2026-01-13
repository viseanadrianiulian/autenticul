using Autenticul.Gaming.Api;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Build app with services and pipeline
var app = builder
    .ConfigureServices()
    .ConfigurePipeline();

// Optional: reset DB
// await app.ApplyMigrationsAsync();

// SPA fallback
app.MapFallbackToFile("index.html");

app.Run();
