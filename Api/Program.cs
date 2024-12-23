using Autenticul.Gaming.Api;
using Serilog;

var builder = WebApplication.CreateBuilder(args);



builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder
    .ConfigureServices()
    .ConfigurePipeline();
//await app.ResetDatabaseAsync();
app.MapFallbackToFile("index.html");


app.Run();