using System.Net.Mime;
using EmployeeTable.Application.Exceptions;
using EmployeeTable.Application.UseCases.Employees;
using EmployeeTable.Application.UseCases.Employees.Commands.CreateEmployee;
using EmployeeTable.Application.UseCases.Employees.Commands.DeleteEmployee;
using EmployeeTable.Application.UseCases.Employees.Commands.UpdateEmployee;
using EmployeeTable.Application.UseCases.Employees.Queries.GetEmployeeById;
using EmployeeTable.Application.UseCases.Employees.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTable.WebApi.Controllers;

/// <summary>
/// Контроллер для работы с сотрудниками
/// </summary>
[ApiController]
[Route("api/employees")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class EmployeesController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Получить всех сотрудников
    /// </summary>
    /// <param name="departmentFilter">Фильтр для отдела</param>
    /// <param name="nameFilter">Фильтр для ФИО</param>
    /// <param name="birthDateFilter">Фильтр для даты рождения</param>
    /// <param name="employmentDateFilter">Фильтр для даты трудоустройства</param>
    /// <param name="salaryFilter">Фильтр для заработной платы</param>
    [HttpGet]
    [ProducesResponseType(typeof(EmployeeListResponse), 200)]
    public async Task<ActionResult> GetAllEmployees(
        [FromQuery] string departmentFilter = "",
        [FromQuery] string nameFilter = "",
        [FromQuery] DateTime? birthDateFilter = null,
        [FromQuery] DateTime? employmentDateFilter = null,
        [FromQuery] decimal? salaryFilter = null
    )
    {
        var query = new GetEmployeesQuery(
            DepartmentFilter: departmentFilter,
            NameFilter: nameFilter,
            BirthDateFilter: birthDateFilter,
            EmploymentDateFilter: employmentDateFilter,
            SalaryFilter: salaryFilter
        );

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    /// <summary>
    /// Получить сотрудника по Id
    /// </summary>
    /// <param name="id">Идентификатор сотрудника</param>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(EmployeeResponse), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetById(Guid id)
    {
        var query = new GetEmployeeByIdQuery(id);
        try
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /// <summary>
    /// Создать сотрудника
    /// </summary>
    /// <param name="command">Данные для создания сотрудника</param>
    [HttpPost]
    [ProducesResponseType(typeof(CreateEmployeeResponse), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Create([FromBody] CreateEmployeeCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Обновить данные о сотрудника
    /// </summary>
    /// <param name="id">Идентификатор сотрудника</param>
    /// <param name="command">Обновленные данные о сотруднике</param>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(EmployeeResponse), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdateEmployeeCommand command)
    {
        if (id != command.Id)
            return BadRequest("Отличающиеся ID");

        try
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Удалить сотрудника
    /// </summary>
    /// <param name="id">Идентификатор сотрудника</param>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteEmployeeCommand(id);

        try
        {
            await _mediator.Send(command);

            return Ok();
        }
        catch (NotFoundException)
        {
            return NoContent();
        }
    }
}