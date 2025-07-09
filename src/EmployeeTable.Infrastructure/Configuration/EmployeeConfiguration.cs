using EmployeeTable.Domain.Entities;
using EmployeeTable.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTable.Infrastructure.Configuration;

/// <summary>
/// Конфигурация таблицы БД для сущности Employee
/// </summary>
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");
        
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.FullName)
            .IsRequired()
            .HasMaxLength(100);
            
        builder.Property(e => e.BirthDate)
            .IsRequired();
            
        builder.Property(e => e.EmploymentDate)
            .IsRequired();

        builder.Property(e => e.Salary).HasConversion(
            s => s.Value,
            value => new Salary(value))
            .IsRequired();

        builder.Property(e => e.Department).HasConversion(
            d => d.Value,
            value => new Department(value))
            .IsRequired();
    }
}