using AutoMapper;
using ControlEscolarApi.Application.Alumnos.Commands.CreateAlumno;
using ControlEscolarApi.Application.Alumnos.Commands.DeleteAlumno;
using ControlEscolarApi.Application.Alumnos.Commands.UpdateAlumno;
using ControlEscolarApi.Application.Alumnos.Queries.GetAlumnoById;
using ControlEscolarApi.Application.Alumnos.Queries.GetAlumnos;
using ControlEscolarApi.Application.Common;
using ControlEscolarApi.Application.Common.QueryParams;
using ControlEscolarApi.Contracts.Alumnos;
using ControlEscolarApi.Contracts.Common;
using ControlEscolarApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControlEscolarApi.Api.Controllers;

/// <summary>
/// Controlador de la entidad Alumno
/// </summary>
[Route("alumnos")]
public class AlumnosController(ISender mediator, IMapper mapper) : ApiController
{

    private readonly ISender _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Obtiene una lista de alumnos con datos de paginación
    /// </summary>
    /// <returns>Lista paginada de alumnos o un problem</returns>
    [HttpGet]
    public async Task<IActionResult> GetAlumnos([FromQuery] PaginationQueryParams queryParams)
    {

        var result = await _mediator.Send(new GetAlumnosQuery { QueryParams = queryParams });

        return result.Match(
            result => Ok(_mapper.Map<PaginatedListResponse<AlumnoResponse>>(result)),
            errors => Problem(errors)
        );
    }

    /// <summary>
    /// Obtiene un alumno por su id
    /// </summary>
    /// <returns>Un alumno o un problem</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAlumnoById(int id)
    {
        var result = await _mediator.Send(new GetAlumnoByIdQuery { Id = id });

        return result.Match(
            result => Ok(_mapper.Map<AlumnoDetailedResponse>(result)),
            errors => Problem(errors)
        );
    }

    /// <summary>
    /// Crea un nuevo alumno
    /// </summary>
    /// <returns>un alumno o un problem</returns>
    [HttpPost]
    public async Task<IActionResult> CreateAlumno(CreateAlumnoRequest request)
    {
        var command = _mapper.Map<CreateAlumnoCommand>(request);
        var result = await _mediator.Send(command);

        return result.Match(
            result => Ok(_mapper.Map<AlumnoResponse>(result)),
            errors => Problem(errors)
        );
    }

    /// <summary>
    /// Actualiza la información de un alumno
    /// </summary>
    /// <returns>Un alumno o un problem</returns>
    [HttpPut]
    public async Task<IActionResult> UpdateAlumno(UpdateAlumnoRequest request)
    {

        var command = _mapper.Map<UpdateAlumnoCommand>(request);
        var result = await _mediator.Send(command);

        return result.Match(
            result => Ok(_mapper.Map<AlumnoResponse>(result)),
            errors => Problem(errors)
        );
    }

    /// <summary>
    /// Elimina un alumno
    /// </summary>
    /// <returns>Boolean o un problem</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlumno(int id)
    {

        var command = new DeleteAlumnoCommand { Id = id };
        var result = await _mediator.Send(command);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}
