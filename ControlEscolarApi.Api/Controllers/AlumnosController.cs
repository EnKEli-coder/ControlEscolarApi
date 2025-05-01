using AutoMapper;
using ControlEscolarApi.Application.Alumnos.Commands.CreateAlumno;
using ControlEscolarApi.Application.Alumnos.Commands.DeleteAlumno;
using ControlEscolarApi.Application.Alumnos.Commands.UpdateAlumno;
using ControlEscolarApi.Application.Alumnos.Queries.GetAlumnos;
using ControlEscolarApi.Application.Common;
using ControlEscolarApi.Application.Common.QueryParams;
using ControlEscolarApi.Contracts.Alumnos;
using ControlEscolarApi.Contracts.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControlEscolarApi.Api.Controllers;

[Route("alumnos")]
public class AlumnosController(ISender mediator, IMapper mapper) : ApiController
{
    
    private readonly ISender _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> GetAlumnos([FromQuery] PaginationQueryParams queryParams) {

        var result = await _mediator.Send(new GetAlumnosQuery { QueryParams = queryParams });

        return result.Match(
            result => Ok(_mapper.Map<PaginatedListResponse<AlumnoResponse>>(result)),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreateAlumno(CreateAlumnoRequest request) {
        var command = _mapper.Map<CreateAlumnoCommand>(request);
        var result = await _mediator.Send(command);

        return result.Match(
            result => Ok(_mapper.Map<AlumnoResponse>(result)),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAlumno(UpdateAlumnoRequest request) {

        var command = _mapper.Map<UpdateAlumnoCommand>(request);
        var result = await _mediator.Send(command);

        return result.Match(
            result => Ok(_mapper.Map<AlumnoResponse>(result)),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlumno(int id) {

        var command = new DeleteAlumnoCommand { Id  = id };
        var result = await _mediator.Send(command);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}
