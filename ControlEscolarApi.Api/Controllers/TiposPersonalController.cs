using AutoMapper;
using ControlEscolarApi.Application.Common.QueryParams;
using ControlEscolarApi.Application.TiposPersonal.Commands.CreateTipoPersonal;
using ControlEscolarApi.Application.TiposPersonal.Commands.DeleteTipoPersonal;
using ControlEscolarApi.Application.TiposPersonal.Commands.UpdateTipoPersonal;
using ControlEscolarApi.Application.TiposPersonal.Queries.GetTipoPersonalById;
using ControlEscolarApi.Application.TiposPersonal.Queries.GetTiposPersonal;
using ControlEscolarApi.Contracts.Common;
using ControlEscolarApi.Contracts.TiposPersonal;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControlEscolarApi.Api.Controllers;

/// <summary>
/// Controlador de la entidad TipoPersonal
/// </summary>
[Route("tipos-personal")]
public class TiposPersonalController(ISender mediator, IMapper mapper) : ApiController
{

  private readonly ISender _mediator = mediator;
  private readonly IMapper _mapper = mapper;

  /// <summary>
  /// Obtiene una lista de tipo de personal con datos de paginación
  /// </summary>
  /// <returns>Lista paginada de tipo de personal o un problem</returns>
  [HttpGet]
  public async Task<IActionResult> GetTiposPersonal([FromQuery] PaginationQueryParams queryParams)
  {

    var result = await _mediator.Send(new GetTiposPersonalQuery { QueryParams = queryParams });

    return result.Match(
      result => Ok(_mapper.Map<PaginatedListResponse<TipoPersonalResponse>>(result)),
      errors => Problem(errors)
    );
  }

  /// <summary>
  /// Obtiene todos los tipos de personal
  /// </summary>
  /// <returns>Una lista de tipos de personal o un problem</returns>
  [HttpGet("all")]
  public async Task<IActionResult> GetAllTiposPersonal()
  {
    var result = await _mediator.Send(new GetAllTiposPersonalQuery());

    return result.Match(
        result => Ok(_mapper.Map<List<TipoPersonalResponse>>(result)),
        errors => Problem(errors)
    );
  }

  /// <summary>
  /// Obtiene un tipo de personal por su id
  /// </summary>
  /// <returns>Un tipo de personal o un problem o un problem</returns>
  [HttpGet("item/{id}")]
  public async Task<IActionResult> GetTipoPersonalById(int id)
  {
    var result = await _mediator.Send(new GetTipoPersonalByIdQuery { Id = id });

    return result.Match(
        result => Ok(_mapper.Map<TipoPersonalResponse>(result)),
        errors => Problem(errors)
    );
  }

  /// <summary>
  /// Crea un nuevo tipo de personal
  /// </summary>
  /// <returns>un tipo de personal o un problem</returns>
  [HttpPost]
  public async Task<IActionResult> CreateTipoPersonal(CreateTipoPersonalRequest request)
  {
    var command = _mapper.Map<CreateTipoPersonalCommand>(request);
    var result = await _mediator.Send(command);

    return result.Match(
      result => Ok(_mapper.Map<TipoPersonalResponse>(result)),
      errors => Problem(errors)
    );
  }

  /// <summary>
  /// Actualiza la información de un tipo de personal
  /// </summary>
  /// <returns>Un tipo de personal o un problem</returns>
  [HttpPut]
  public async Task<IActionResult> UpdateTipoPersonal(UpdateTipoPersonalRequest request)
  {

    var command = _mapper.Map<UpdateTipoPersonalCommand>(request);
    var result = await _mediator.Send(command);

    return result.Match(
      result => Ok(_mapper.Map<TipoPersonalResponse>(result)),
      errors => Problem(errors)
    );
  }

  /// <summary>
  /// Elimina un tipo de personal
  /// </summary>
  /// <returns>Boolean o un problem</returns>
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteTipoPersonal(int id)
  {

    var command = new DeleteTipoPersonalCommand { Id = id };
    var result = await _mediator.Send(command);

    return result.Match(
      result => Ok(result),
      errors => Problem(errors)
    );
  }

}
