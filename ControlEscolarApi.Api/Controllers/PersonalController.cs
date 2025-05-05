using AutoMapper;
using ControlEscolarApi.Application.Common.QueryParams;
using ControlEscolarApi.Application.Personal.Commands.CreatePersonal;
using ControlEscolarApi.Application.Personal.Commands.DeletePersonal;
using ControlEscolarApi.Application.Personal.Commands.UpdatePersonal;
using ControlEscolarApi.Application.Personal.Queries.GetPersonal;
using ControlEscolarApi.Application.Personal.Queries.GetPersonalById;
using ControlEscolarApi.Contracts.Common;
using ControlEscolarApi.Contracts.Personal;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControlEscolarApi.Api.Controllers;

[Route("personal")]
public class PersonalController(ISender mediator, IMapper mapper) : ApiController
{
    private readonly ISender _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> GetPersonal([FromQuery] PaginationQueryParams queryParams) {

        var result = await _mediator.Send(new GetPersonalQuery { QueryParams = queryParams });

        return result.Match(
            result => Ok(_mapper.Map<PaginatedListResponse<PersonalResponse>>(result)),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPersonalById(int id)
    {
        var result = await _mediator.Send(new GetPersonalByIdQuery { Id = id });

        return result.Match(
            result => Ok(_mapper.Map<PersonalDetailedResponse>(result)),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> CreatePersonal(CreatePersonalRequest request) {
        var command = _mapper.Map<CreatePersonalCommand>(request);
        var result = await _mediator.Send(command);

        return result.Match(
            result => Ok(_mapper.Map<PersonalResponse>(result)),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePersonal(UpdatePersonalRequest request) {

        var command = _mapper.Map<UpdatePersonalCommand>(request);
        var result = await _mediator.Send(command);

        return result.Match(
            result => Ok(_mapper.Map<PersonalResponse>(result)),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersonal(int id) {

        var command = new DeletePersonalCommand{ Id = id};
        var result = await _mediator.Send(command);


        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}
