using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticul.Gaming.Persistence.Migrations
{
    public static class MigrationExtensions
    {

        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using GamingDbContext context = scope.ServiceProvider.GetRequiredService<GamingDbContext>();

            context.Database.Migrate();
        }
    }
}
