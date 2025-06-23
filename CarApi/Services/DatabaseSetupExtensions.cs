using CarApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CarApi.Services
{
    public static class DatabaseSetupExtensions
    {
        public static async Task SetupDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var Pending = await context.Database.GetPendingMigrationsAsync();

            if (Pending.Any())
            {
                await context.Database.MigrateAsync();
            }
        }
    }
}
