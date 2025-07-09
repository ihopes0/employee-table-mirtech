using EmployeeTable.Application.Exceptions;
using EmployeeTable.Domain.Repositories;
using MediatR;

namespace EmployeeTable.Application.UseCases.Employees.Queries.GetEmployeeById;

/// <summary>
/// Обработчик запроса данных о сотруднике по Id
/// </summary>
internal sealed class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse>
{
    private readonly IEmployeeRepository _employeeRepository;

    /// <summary>
    /// .ctor
    /// </summary>
    public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    /// <inheritdoc />
    public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (employee is null)
        {
            throw new NotFoundException($"Сотрудник с ID {request.Id} не найден");
        }

        return new EmployeeResponse(
            employee.Id,
            employee.FullName,
            employee.BirthDate,
            employee.EmploymentDate,
            employee.Salary.Value,
            employee.Department.Value
        );
    }
}