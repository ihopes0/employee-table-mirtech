using System.ComponentModel;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EmployeeTable.WebApi.Configurations;

/// <summary>
/// Фильтр для формирования документации Enum к Swagger
/// </summary>
public class SwaggerEnumSchemaFilter : ISchemaFilter
{
    /// <summary>
    /// Применить фильтр
    /// </summary>
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsEnum)
            return;

        foreach (var name in Enum.GetNames(context.Type))
        {
            var enumValue = (Enum)Enum.Parse(context.Type, name);
            schema.Description += $"\n\n{Convert.ToInt32(enumValue)} - {enumValue.GetAttributeOfType<DescriptionAttribute>()?.Description}";
        }
    }
}