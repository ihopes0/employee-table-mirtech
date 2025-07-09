using System.Runtime.InteropServices;
using EmployeeTable.Domain.Exceptions;
using EmployeeTable.Domain.ValueObjects;

namespace EmployeeTable.Domain.Entities;

/// <summary>
/// Сущность сотрудника
/// </summary>
public class Employee : Entity, IAggregateRoot
{
    public new Guid Id { get; private init; }
    public string FullName { get; private set; }
    public DateTime BirthDate { get; private set; }
    public DateTime EmploymentDate { get; private set; }
    public Salary Salary { get; private set; }
    public Department Department { get; private set; }

    private Employee()
    {
    }

    private Employee(
        string fullName,
        DateTime birthDate,
        DateTime employmentDate,
        Salary salary,
        Department department
    )
        : base(new Guid())
    {
        FullName = fullName;
        BirthDate = birthDate;
        EmploymentDate = employmentDate;
        Salary = salary;
        Department = department;
    }

    /// <summary>
    /// Метод для обновления данных о сотруднике
    /// </summary>
    /// <param name="fullName">ФИО</param>
    /// <param name="birthDate">Дата рождения</param>
    /// <param name="employmentDate">Дата трудоустройства</param>
    /// <param name="salary">Заработная плата</param>
    /// <param name="department">Отдел</param>
    public void Update(string fullName, DateTime birthDate,
        DateTime employmentDate, Salary salary,
        Department department)
    {
        FullName = fullName;
        BirthDate = birthDate;
        EmploymentDate = employmentDate;
        Salary = salary;
        Department = department;
    }

    /// <summary>
    /// Создать экземпляр сущности Employee
    /// </summary>
    /// <param name="fullName">ФИО</param>
    /// <param name="birthDate">Дата рождения</param>
    /// <param name="employmentDate">Дата трудоустройства</param>
    /// <param name="salary">Заработная плата</param>
    /// <param name="department">Отдел</param>
    /// <exception cref="DomainException">При неуспешной валидации данных</exception>
    public static Employee Create(
        string fullName,
        DateTime birthDate,
        DateTime employmentDate,
        Salary salary,
        Department department
    )
    {
        if (!Validate(fullName, birthDate, employmentDate, salary, department))
        {
            throw new DomainException("Неверные данные");
        }
        return new Employee(fullName, birthDate, employmentDate, salary, department);
    }

    private static bool Validate(
        string fullName,
        DateTime birthDate,
        DateTime employmentDate,
        Salary salary,
        Department department
    )
    {
        // правила для валидации
        return true;
    }
}