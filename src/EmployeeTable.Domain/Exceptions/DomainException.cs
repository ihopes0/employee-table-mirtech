namespace EmployeeTable.Domain.Exceptions;

/// <summary>
/// Доменное исключение
/// </summary>
public class DomainException : Exception
{
    /// <summary>
    /// Инициализирует новый экземпляр класса DomainException
    /// </summary>
    public DomainException(string message)
        : base(message)
    {
    }
}