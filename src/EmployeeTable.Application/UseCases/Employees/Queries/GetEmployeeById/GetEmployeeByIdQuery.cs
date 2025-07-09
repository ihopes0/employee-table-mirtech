using MediatR;

namespace EmployeeTable.Application.UseCases.Employees.Queries.GetEmployeeById;

/// <summary>
/// Запрос на получение данных о сотруднике по Id
/// </summary>
/// <param name="Id">Идентификатор сотрудника</param>
public sealed record GetEmployeeByIdQuery(Guid Id) : IRequest<EmployeeResponse>;