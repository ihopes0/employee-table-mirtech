namespace EmployeeTable.Application.Exceptions;

/// <summary>
/// Неверный запрос (400)
/// </summary>
public class BadRequestException : Exception
{
    /// <summary>
    /// Инициализирует новый экземпляр класса BadRequestException
    /// </summary>
    public BadRequestException() : base() { }

    /// <summary>
    /// Инициализирует новый экземпляр класса BadRequestException с определенным сообщением об ошибке
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    public BadRequestException(string message) : base(message) { }

    /// <summary>
    /// Инициализирует новый экземпляр класса BadRequestException с определенным сообщением об ошибке
    /// и ссылкой на внутреннюю ошибку, которая стала причиной этой ошибки
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <param name="innerException">Вложенное исключение</param>
    public BadRequestException(string message, Exception innerException) : base(message, innerException) { }
}