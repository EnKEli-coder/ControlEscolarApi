using AutoMapper;
using ControlEscolarApi.Application.Alumnos.Commands.CreateAlumno;
using ControlEscolarApi.Application.Common.QueryParams;
using ControlEscolarApi.Application.Services;
using ControlEscolarApi.Application.TiposPersonal.Commands.CreateTipoPersonal;
using ControlEscolarApi.Application.TiposPersonal.Commands.DeleteTipoPersonal;
using ControlEscolarApi.Application.TiposPersonal.Commands.UpdateTipoPersonal;
using ControlEscolarApi.Application.TiposPersonal.Queries.GetTiposPersonal;
using ControlEscolarApi.Contracts.Alumnos;
using ControlEscolarApi.Contracts.Common;
using ControlEscolarApi.Contracts.TiposPersonal;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControlEscolarApi.Api.Controllers;

[Route("tipos-personal")]
public class TiposPersonalController(ISender mediator, IMapper mapper) : ApiController
{

  private readonly ISender _mediator = mediator;
  private readonly IMapper _mapper = mapper;

  [HttpGet]
  public async Task<IActionResult> GetTiposPersonal([FromQuery] PaginationQueryParams queryParams) {

    var result = await _mediator.Send(new GetTiposPersonalQuery { QueryParams = queryParams });

    return result.Match(
      result => Ok(_mapper.Map<PaginatedListResponse<TipoPersonalResponse>>(result)),
      errors => Problem(errors)
    );
  }

  [HttpPost]
  public async Task<IActionResult> CreateTipoPersonal(CreateTipoPersonalRequest request) {
    var command = _mapper.Map<CreateTipoPersonalCommand>(request);
    var result = await _mediator.Send(command);

    return result.Match(
      result => Ok(_mapper.Map<TipoPersonalResponse>(result)),
      errors => Problem(errors)
    );
  }

  [HttpPut]
  public async Task<IActionResult> UpdateTipoPersonal(UpdateTipoPersonalRequest request) {

    var command = _mapper.Map<UpdateTipoPersonalCommand>(request);
    var result = await _mediator.Send(command);

    return result.Match(
      result => Ok(_mapper.Map<TipoPersonalResponse>(result)),
      errors => Problem(errors)
    );
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteTipoPersonal(int id) {

    var command = new DeleteTipoPersonalCommand {Id = id };
    var result = await _mediator.Send(command);

    return result.Match(
      result => Ok(result),
      errors => Problem(errors)
    );
  }

}
