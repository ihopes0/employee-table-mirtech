using EmployeeTable.Domain.Entities;
using EmployeeTable.Domain.Repositories;
using MediatR;

namespace EmployeeTable.Application.UseCases.Employees.Queries.GetEmployees;

/// <summary>
/// Обработчик запроса на получение всех сотрудников
/// </summary>
internal sealed class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, EmployeeListResponse>
{
    private readonly IEmployeeRepository _employeeRepository;

    /// <summary>
    /// .ctor
    /// </summary>
    public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    /// <inheritdoc />
    public async Task<EmployeeListResponse> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var query = (await _employeeRepository.GetAllAsync(cancellationToken)).AsQueryable();

        var employees = ApplyFilters(query, request);

        if (employees.Count == 0)
        {
            return new EmployeeListResponse([]);
        }

        return new EmployeeListResponse(
            employees
                .Select(e => new EmployeeResponse(
                    e.Id,
                    e.FullName,
                    e.BirthDate,
                    e.EmploymentDate,
                    e.Salary.Value,
                    e.Department.Value
                ))
                .ToArray()
        );
    }

    private static List<Employee> ApplyFilters(IQueryable<Employee> employees, GetEmployeesQuery request)
    {
        if (!String.IsNullOrEmpty(request.DepartmentFilter))
        {
            employees = employees.Where(e => e.Department.Value.ToLower().Contains(request.DepartmentFilter));
        }

        if (!String.IsNullOrEmpty(request.NameFilter))
        {
            employees = employees.Where(e => e.FullName.ToLower().Contains(request.NameFilter));
        }

        if (request.BirthDateFilter.HasValue)
        {
            employees = employees.Where(e => e.BirthDate.Date == request.BirthDateFilter.Value.Date);
        }

        if (request.EmploymentDateFilter.HasValue)
        {
            employees = employees.Where(e => e.BirthDate.Date == request.EmploymentDateFilter.Value.Date);
        }

        if (request.SalaryFilter.HasValue)
        {
            employees = employees.Where(e => e.Salary.Value == request.SalaryFilter.Value);
        }

        return employees.ToList();
    }
}