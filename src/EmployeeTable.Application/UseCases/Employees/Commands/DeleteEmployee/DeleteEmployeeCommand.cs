using MediatR;

namespace EmployeeTable.Application.UseCases.Employees.Commands.DeleteEmployee;

/// <summary>
/// Команда для удаления сотрудника
/// </summary>
/// <param name="Id">Идентификатор сотрудника</param>
public sealed record DeleteEmployeeCommand(Guid Id) : IRequest;