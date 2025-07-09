using EmployeeTable.Application.Exceptions;
using EmployeeTable.Domain.Entities;
using EmployeeTable.Domain.Exceptions;
using EmployeeTable.Domain.Repositories;
using EmployeeTable.Domain.ValueObjects;
using MediatR;

namespace EmployeeTable.Application.UseCases.Employees.Commands.CreateEmployee;

/// <summary>
/// Обработчик команды создания нового сотрудника
/// </summary>
internal class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CreateEmployeeResponse>
{
    
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// .ctor
    /// </summary>
    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc />
    public async Task<CreateEmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = Employee.Create(
                fullName: request.FullName,
                birthDate: request.BirthDate,
                employmentDate: request.EmploymentDate,
                salary: new Salary(request.Salary),
                department: new Department(request.Department)
            );

            await _employeeRepository.CreateAsync(employee, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateEmployeeResponse(employee.Id);
        }
        catch (DomainException e)
        {
            throw new BadRequestException(e.Message, e);
        }
    }
}