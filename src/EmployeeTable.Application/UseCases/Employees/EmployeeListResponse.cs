namespace EmployeeTable.Application.UseCases.Employees;

/// <summary>
/// Ответ списка всех сотрудников
/// </summary>
/// <param name="Employees">Список сотрудников</param>
public sealed record EmployeeListResponse(EmployeeResponse[] Employees);