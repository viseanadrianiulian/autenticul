using Autenticul.Gaming.Persistence;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Autenticul.Gaming.Api.Utility;
using Autenticul.Gaming.Application;
using Serilog;
using Autenticul.Gaming.Api.Middleware;
using Autenticul.Gaming.Application.Contracts.Persistence;
using Autenticul.Gaming.Persistence.Repositories;

namespace Autenticul.Gaming.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {


            builder.Services
                .AddApplicationServices()
                .AddPersistenceServices(builder.Configuration);

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                );
            });

            AddSwagger(builder.Services);

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Autenticul.Gaming Api");
                });
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();
            app.UseCors("Open");

            app.UseCustomExceptionHandler();

            app.UseAuthentication();

            app.UseAuthorization();

  

       

         

            app.MapControllers();

            return app;
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "PlanAhead.FoodTrack Api",
                });
                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }

        //public static async Task ResetDatabaseAsync(this WebApplication app)
        //{
        //    using var scope = app.Services.CreateScope();
        //    try
        //    {
        //        var context = scope.ServiceProvider.GetService<FoodTrackDbContext>();
        //        if (context != null)
        //        {
        //            await context.Database.EnsureDeletedAsync();
        //            await context.Database.MigrateAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
        //        logger.LogError(ex, "An error occurred while migrating the database.");
        //    }
        //}
    }
}
