using EmployeeTable.Domain.Entities;

namespace EmployeeTable.Domain.Repositories;

/// <summary>
/// Репозиторий сотрудников
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Получить всех сотрудников
    /// </summary>
    Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получить сотрудника по ID
    /// </summary>
    /// <param name="id">ID сотрудника</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Добавить сотрудника в БД
    /// </summary>
    /// <param name="employee">Сотрудник</param>
    /// <param name="cancellationToken">Токен отмены асинхронной операции</param>
    Task CreateAsync(Employee employee, CancellationToken cancellationToken);

    /// <summary>
    /// Обновить данные сотрудника
    /// </summary>
    /// <param name="employee">Сотрудник</param>
    void Update(Employee employee);

    /// <summary>
    /// Удалить сотрудника по ID
    /// </summary>
    /// <param name="employee">Сотрудник</param>
    void Delete(Employee employee);
}