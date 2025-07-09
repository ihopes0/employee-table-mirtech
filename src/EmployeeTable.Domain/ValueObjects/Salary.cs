using EmployeeTable.Domain.Exceptions;

namespace EmployeeTable.Domain.ValueObjects;

/// <summary>
/// Зарплата
/// </summary>
public sealed class Salary : ValueObject
{
    /// <summary>
    /// Значение заработной платы
    /// </summary>
    public decimal Value { get; }

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="value">Размер заработной платы</param>
    /// <exception cref="DomainException">При значении меньше 0</exception>
    public Salary(decimal value)
    {
        if (value < 0)
            throw new DomainException("Зарплата не может быть меньше 0");
            
        Value = value;
    }

    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}