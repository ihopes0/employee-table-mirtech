using Microsoft.Extensions.DependencyInjection;

namespace EmployeeTable.Application;

/// <summary>
/// Статический класс для добавления зависимостей
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Добавляет в DI все зависимости из Application
    /// </summary>
    /// <param name="services">Провайдер DI сервис контейнера</param>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        
        return services;
    }
}