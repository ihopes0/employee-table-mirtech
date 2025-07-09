using MediatR;

namespace EmployeeTable.Application.UseCases.Employees.Queries.GetEmployees;

/// <summary>
/// Запрос на получение всех сотрудников
/// </summary>
/// <param name="DepartmentFilter">Фильтр по отделу</param>
/// <param name="NameFilter">Фильтр по ФИО</param>
/// <param name="BirthDateFilter">Фильтр по дате рождения</param>
/// <param name="EmploymentDateFilter">Фильтр по дате трудоустройства</param>
/// <param name="SalaryFilter">Фильтр по заработной плате</param>
public sealed record GetEmployeesQuery(
    string DepartmentFilter,
    string NameFilter,
    DateTime? BirthDateFilter,
    DateTime? EmploymentDateFilter,
    decimal? SalaryFilter
) : IRequest<EmployeeListResponse>;