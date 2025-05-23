using AutoMapper;
using ControlEscolarApi.Application.Authentication.Common;
using ControlEscolarApi.Application.Authentication.Queries.Login;
using ControlEscolarApi.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlEscolarApi.Api.Controllers
{
    /// <summary>
    /// Controlador de autenticación
    /// </summary>
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController(ISender mediator, IMapper mapper) : ApiController
    {

        private readonly ISender _mediator = mediator;
        private readonly IMapper _mapper = mapper;

        /// <summary>
        /// Inicia la sesión del usuario
        /// </summary>
        /// <returns>Datos de la sesión con jwt o Problem</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);
            ErrorOr<AuthenticationResult> result = await _mediator.Send(query);

            return result.Match(
                result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                errors => Problem(errors)
            );
        }
    }
}