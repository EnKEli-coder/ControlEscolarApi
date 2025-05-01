using AutoMapper;
using ControlEscolarApi.Application.Alumnos.Commands.CreateAlumno;
using ControlEscolarApi.Application.TiposPersonal.Commands.CreateTipoPersonal;
using ControlEscolarApi.Application.TiposPersonal.Commands.DeleteTipoPersonal;
using ControlEscolarApi.Application.TiposPersonal.Commands.UpdateTipoPersonal;
using ControlEscolarApi.Contracts.Alumnos;
using ControlEscolarApi.Contracts.TiposPersonal;
using ControlEscolarApi.Domain.Entities;

namespace ControlEscolarApi.Api.Common.Mappings;

public class TiposPersonalMappingConfig : Profile {

  public TiposPersonalMappingConfig() {
    CreateMap<TipoPersonal, TipoPersonalResponse>();
    CreateMap<CreateTipoPersonalRequest, CreateTipoPersonalCommand>();
    CreateMap<UpdateTipoPersonalRequest, UpdateTipoPersonalCommand>();
    CreateMap<DeleteTipoPersonalRequest, DeleteTipoPersonalCommand>();
    CreateMap<UpdateTipoPersonalCommand, TipoPersonal>()
      .ForAllMembers(options => options.Condition((src, dest, member) => member != null));
  }

} 