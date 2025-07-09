namespace EmployeeTable.Application.UseCases.Employees.Commands.CreateEmployee;

/// <summary>
/// Ответ на создание нового сотрудника
/// </summary>
/// <param name="Id">Идентификатор сотрудника</param>
public sealed record CreateEmployeeResponse(Guid Id);