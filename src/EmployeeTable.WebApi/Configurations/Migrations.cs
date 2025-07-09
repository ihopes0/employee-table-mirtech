using EmployeeTable.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTable.WebApi.Configurations;

/// <summary>
/// Миграции
/// </summary>
public static class Migrations
{
    /// <summary>
    /// Применение миграции к бд.
    /// </summary>
    /// <param name="webApplication"><see cref="WebApplication"/>.</param>
    public static void ApplyMigrations(this WebApplication webApplication)
    {
        using var scope = webApplication.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var pendingMigrations = context.Database.GetPendingMigrations();

        if (pendingMigrations.Any())
        {
            context.Database.Migrate();
            Console.WriteLine("--> Migration apply");
        }
    }
}