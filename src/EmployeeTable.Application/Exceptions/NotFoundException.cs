namespace EmployeeTable.Application.Exceptions;

/// <summary>
/// Не найдено (404)
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    /// Инициализирует новый экземпляр класса NotFoundException
    /// </summary>
    public NotFoundException() : base() { }

    /// <summary>
    /// Инициализирует новый экземпляр класса NotFoundException с определенным сообщением об ошибке
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    public NotFoundException(string message) : base(message) { }

    /// <summary>
    /// Инициализирует новый экземпляр класса NotFoundException с определенным сообщением об ошибке
    /// и ссылкой на внутреннюю ошибку, которая стала причиной этой ошибки
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <param name="innerException">Вложенное исключение</param>
    public NotFoundException(string message, Exception innerException) : base(message, innerException) { }
}