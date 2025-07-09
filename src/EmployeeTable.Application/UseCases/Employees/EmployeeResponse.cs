namespace EmployeeTable.Application.UseCases.Employees;

/// <summary>
/// DTO данных о сотруднике
/// </summary>
/// <param name="Id">Идентификатор сотрудника</param>
/// <param name="FullName">ФИО</param>
/// <param name="BirthDate">Дата рождения</param>
/// <param name="EmploymentDate">Дата трудоустройства</param>
/// <param name="Salary">Заработная плата</param>
/// <param name="Department">ОТдел</param>
public sealed record EmployeeResponse(
    Guid Id,
    string FullName,
    DateTime BirthDate,
    DateTime EmploymentDate,
    decimal Salary,
    string Department
);