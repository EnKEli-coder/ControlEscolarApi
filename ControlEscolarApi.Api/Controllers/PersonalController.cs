using AutoMapper;
using ControlEscolarApi.Application.Personal.Commands.CreatePersonal;
using ControlEscolarApi.Application.Personal.Commands.DeletePersonal;
using ControlEscolarApi.Application.Personal.Commands.UpdatePersonal;
using ControlEscolarApi.Application.Personal.Queries.GetPersonal;
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
    public async Task<IActionResult> GetPersonal() {

        var result = await _mediator.Send(new GetPersonalQuery());

        return result.Match(
            result => Ok(_mapper.Map<List<PersonalResponse>>(result)),
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
