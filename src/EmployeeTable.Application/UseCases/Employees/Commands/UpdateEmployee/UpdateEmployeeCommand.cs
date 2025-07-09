using MediatR;

namespace EmployeeTable.Application.UseCases.Employees.Commands.UpdateEmployee;

/// <summary>
/// Команда обновления данных о сотруднике
/// </summary>
/// <param name="Id">Идентификатор сотрудника</param>
/// <param name="FullName">ФИО</param>
/// <param name="BirthDate">Дата рождения</param>
/// <param name="EmploymentDate">Дата трудоустройства</param>
/// <param name="Salary">Заработная плата</param>
/// <param name="Department">Отдел</param>
public sealed record UpdateEmployeeCommand(
    Guid Id,
    string FullName,
    DateTime BirthDate,
    DateTime EmploymentDate,
    decimal Salary,
    string Department
) : IRequest<EmployeeResponse>;