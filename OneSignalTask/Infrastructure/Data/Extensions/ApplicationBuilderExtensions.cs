using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OneSignalTask.Persistence;
using System.Linq;

namespace OneSignalTask.Infrastructure.Data.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                var seedService = serviceScope.ServiceProvider.GetService<IdentityDbSeed>();
                if (!context.Roles.Any()) //Dummy check
                {
                    seedService.Seed();
                }
            }
            return app;
        }

        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.Migrate();
            }
            return app;
        }
    }
}
