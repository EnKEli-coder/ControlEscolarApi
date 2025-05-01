using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Application.Personal.Common;
using ControlEscolarApi.Domain.Common.Errors;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Personal.Commands.CreatePersonal;

public class CreatePersonalCommandHandler(
  IGenericRepository<Domain.Entities.Personal> personalRepository,
  IGenericRepository<TipoPersonal> tipoPersonalRepository,
  IGeneradorNumeroControl generadorNumeroControl) : IRequestHandler<CreatePersonalCommand, ErrorOr<Domain.Entities.Personal>>
{
  IGenericRepository<Domain.Entities.Personal> _personalRepository = personalRepository;
  IGenericRepository<TipoPersonal> _tipoPersonalRepository = tipoPersonalRepository;
  IGeneradorNumeroControl _generadorNumeroControl = generadorNumeroControl;

  public async Task<ErrorOr<Domain.Entities.Personal>> Handle(CreatePersonalCommand request, CancellationToken cancellationToken)
  {
    if( await _personalRepository.SelectAsync(personal => personal.Correo == request.Correo) is not null) {
      return Errors.Personal.DuplicatedEmail;
    }

    var tipoPersonal = await _tipoPersonalRepository.GetByIdAsync(request.TipoPersonalId);

    if( tipoPersonal is null) {
      return Errors.Personal.MissingPersonal;
    }

    if(request.Sueldo > tipoPersonal.SueldoMaximo || request.Sueldo < tipoPersonal.SueldoMinimo){
      return Errors.Personal.WrongSueldo;
    }

    var numeroControl = _generadorNumeroControl.GenerarNumeroControl(tipoPersonal.Prefijo);

    var personal = new Domain.Entities.Personal {
      Nombre = request.Nombre,
      ApellidoPaterno = request.ApellidoPaterno,
      ApellidoMaterno = request.ApellidoMaterno,
      Correo = request.Correo,
      FechaNacimiento = request.FechaNacimiento,
      NumeroControl = numeroControl,
      Estatus = request.Estatus,
      Sueldo = request.Sueldo,
      TipoPersonalId = request.TipoPersonalId,
    };

    _personalRepository.Add(personal);
    await _personalRepository.SaveAsync();
    return personal;
  }
}