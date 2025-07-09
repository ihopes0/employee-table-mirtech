using EmployeeTable.Domain.Repositories;
using EmployeeTable.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeTable.Infrastructure;

/// <summary>
/// Статический класс для добавления зависимостей
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Добавить инфраструктурные зависимости
    /// </summary>
    /// <param name="services">Провайдер DI сервис контейнера</param>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                @"Server=mssql,1433;Database=EmployeeTableDB;User Id=sa;Password=Adminxyz22#;TrustServerCertificate=True",
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(5), 
                        errorNumbersToAdd: null); 
                })
        );

        // Repositories
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        // Unit of work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}