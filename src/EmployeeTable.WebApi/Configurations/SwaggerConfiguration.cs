using Microsoft.OpenApi.Models;

namespace EmployeeTable.WebApi.Configurations;

/// <summary>
/// Конфигурация Swagger
/// </summary>
internal static class SwaggerConfiguration
{
    public static IServiceCollection AddConfiguredSwagger(
        this IServiceCollection services
    )
    {
        services.AddSwaggerGen(static options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Version = "v1",
                Title = "API EmployeeTable",
                Description = "EmployeeTable",
                Contact = new OpenApiContact
                {
                    Name = "Email разработчика",
                    Email = "brnv.ma@gmail.com"
                }
            });

            foreach (var name in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.xml",
                         SearchOption.AllDirectories))
            {
                options.IncludeXmlComments(name);
            }

            options.SchemaFilter<SwaggerEnumSchemaFilter>();
        });

        return services;
    }
}