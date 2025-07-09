using EmployeeTable.Application.Exceptions;
using EmployeeTable.Domain.Repositories;
using EmployeeTable.Domain.ValueObjects;
using MediatR;

namespace EmployeeTable.Application.UseCases.Employees.Commands.UpdateEmployee;

/// <summary>
/// Обработчик команды обновления данных о сотруднике
/// </summary>
internal class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeResponse>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// .ctor
    /// </summary>
    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc />
    public async Task<EmployeeResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (employee is null)
        {
            throw new NotFoundException($"Сотрудник с ID {request.Id} не найден");
        }

        employee.Update(
            fullName: request.FullName,
            birthDate: request.BirthDate,
            employmentDate: request.EmploymentDate,
            salary: new Salary(request.Salary),
            department: new Department(request.Department)
        );

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new EmployeeResponse(
            Id: employee.Id,
            FullName: employee.FullName,
            BirthDate: employee.BirthDate,
            EmploymentDate: employee.EmploymentDate,
            Salary: employee.Salary.Value,
            Department: employee.Department.Value);
    }
}