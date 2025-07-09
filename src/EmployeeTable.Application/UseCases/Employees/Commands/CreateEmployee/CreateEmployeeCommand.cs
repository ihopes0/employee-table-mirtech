using MediatR;

namespace EmployeeTable.Application.UseCases.Employees.Commands.CreateEmployee;

/// <summary>
/// Команда для создания нового сотрудника
/// </summary>
/// <param name="FullName">ФИО</param>
/// <param name="BirthDate">Дата рождения</param>
/// <param name="EmploymentDate">Дата трудоустройства</param>
/// <param name="Salary">Заработная плата</param>
/// <param name="Department">Отдел</param>
public sealed record CreateEmployeeCommand(
    string FullName,
    DateTime BirthDate,
    DateTime EmploymentDate,
    decimal Salary,
    string Department
) : IRequest<CreateEmployeeResponse>;