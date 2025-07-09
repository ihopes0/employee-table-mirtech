using EmployeeTable.Application.Exceptions;
using EmployeeTable.Domain.Repositories;
using MediatR;

namespace EmployeeTable.Application.UseCases.Employees.Commands.DeleteEmployee;

/// <summary>
/// Обработчик команды удаления сотрудника
/// </summary>
internal sealed class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// .ctor
    /// </summary>
    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc />
    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (employee is null)
        {
            throw new NotFoundException($"Пользователь с ID {request.Id} не найден");
        }
        
        _employeeRepository.Delete(employee);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}