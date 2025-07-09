using EmployeeTable.Domain.Exceptions;

namespace EmployeeTable.Domain.ValueObjects;

/// <summary>
/// Отдел
/// </summary>
public sealed class Department : ValueObject
{
    
    /// <summary>
    /// Строковое значение названия отдела
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// .ctor
    /// </summary>
    /// <param name="name">Название отдела</param>
    /// <exception cref="DomainException">При пустом названии отдела</exception>
    public Department(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Отдел не может быть пустым");

        Value = name;
    }
    
    /// <inheritdoc />
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}