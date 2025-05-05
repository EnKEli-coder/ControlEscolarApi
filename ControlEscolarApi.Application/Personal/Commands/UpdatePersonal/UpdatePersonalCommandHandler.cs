using ControlEscolarApi.Application.Interfaces.Persistence;
using ControlEscolarApi.Application.Personal.Common;
using ControlEscolarApi.Domain.Common.Errors;
using ControlEscolarApi.Domain.Entities;
using ErrorOr;
using MediatR;

namespace ControlEscolarApi.Application.Personal.Commands.UpdatePersonal;

/// <summary>
/// Maneja la actualización de un personal, valida duplicados y reglas de negocio
/// </summary>
public class UpdatePersonalCommandHandler(
  IGenericRepository<Domain.Entities.Personal> personalRepository,
  IGenericRepository<TipoPersonal> tipoPersonalRepository,
  IGeneradorNumeroControl generadorNumeroControl )  : IRequestHandler<UpdatePersonalCommand, ErrorOr<PersonalResult>>
{
  IGenericRepository<Domain.Entities.Personal> _personalRepository = personalRepository;
  IGenericRepository<TipoPersonal> _tipoPersonalRepository = tipoPersonalRepository;
  IGeneradorNumeroControl _generadorNumeroControl = generadorNumeroControl;

  public async Task<ErrorOr<PersonalResult>> Handle(UpdatePersonalCommand request, CancellationToken cancellationToken)
  {
    var personal = await _personalRepository.GetByIdAsync(request.Id);
    TipoPersonal? tipoPersonal =  null;

    if( personal is null) {
      return Errors.Personal.MissingPersonal;
    }

    if (request.Nombre != null) {
        personal.Nombre = request.Nombre;
    }

    if (request.ApellidoPaterno != null) {
        personal.ApellidoPaterno = request.ApellidoPaterno;
    }

    if (request.ApellidoMaterno != null) {
        personal.ApellidoMaterno = request.ApellidoMaterno;
    }

    if (request.Correo != null) {

        if( await _personalRepository.SelectAsync(personal => personal.Correo == request.Correo && personal.Id != request.Id) is not null) {
            return Errors.Personal.DuplicatedEmail;
        }

        personal.Correo = request.Correo;
    }

    if (request.FechaNacimiento != null) {
        personal.FechaNacimiento = request.FechaNacimiento.Value;
    }

    if (request.TipoPersonalId != null) {
        personal.TipoPersonalId = request.TipoPersonalId.Value;

        tipoPersonal = await _tipoPersonalRepository.GetByIdAsync(personal.TipoPersonalId);

        if( tipoPersonal is null) {
            return Errors.TipoPersonal.MissingTipoPersonal;
        }

        var numeroControl = _generadorNumeroControl.GenerarNumeroControl(tipoPersonal.Prefijo);

        personal.NumeroControl = numeroControl;
    }

    if (request.Sueldo != null) {
        tipoPersonal ??= await _tipoPersonalRepository.GetByIdAsync(personal.TipoPersonalId);

        if( tipoPersonal is null) {
            return Errors.TipoPersonal.MissingTipoPersonal;
        }

        if(request.Sueldo > tipoPersonal.SueldoMaximo || request.Sueldo < tipoPersonal.SueldoMinimo){
            return Errors.Personal.WrongSueldo;
        }

        personal.Sueldo = request.Sueldo.Value;
    }

    if (request.Estatus != null) {
        personal.Estatus = request.Estatus.Value;
    }

    await _personalRepository.SaveAsync();

    var personalResult = new PersonalResult {
      Id = personal.Id,
      Nombre = personal.Nombre + " " + personal.ApellidoPaterno + " " + personal.ApellidoMaterno,
      Correo = personal.Correo,
      NumeroControl = personal.NumeroControl,
      TipoPersonalId = personal.TipoPersonalId,
      TipoPersonal = personal.TipoPersonal.Nombre,
      Sueldo = personal.Sueldo
    };


    return personalResult;
  }
}