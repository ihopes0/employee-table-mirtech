using EmployeeTable.Domain.Entities;
using EmployeeTable.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTable.Infrastructure.Repositories;

/// <inheritdoc />
public class EmployeeRepository : IEmployeeRepository
{
    /// <summary>
    /// Контекст БД
    /// </summary>
    private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Employees.ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task CreateAsync(Employee employee, CancellationToken cancellationToken = default)
    {
        await _context.Employees.AddAsync(employee, cancellationToken);
    }

    /// <inheritdoc />
    public void Update(Employee employee)
    {
        _context.Employees.Update(employee);
    }

    /// <inheritdoc />
    public void Delete(Employee employee)
    {
        _context.Employees.Remove(employee);
    }
}