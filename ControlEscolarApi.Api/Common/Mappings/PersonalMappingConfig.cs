using AutoMapper;
using ControlEscolarApi.Application.Personal.Commands.CreatePersonal;
using ControlEscolarApi.Application.Personal.Commands.DeletePersonal;
using ControlEscolarApi.Application.Personal.Commands.UpdatePersonal;
using ControlEscolarApi.Contracts.Personal;
using ControlEscolarApi.Domain.Entities;

namespace ControlEscolarApi.Api.Common.Mappings;

public class PersonalMappingConfig : Profile {

  public PersonalMappingConfig() {
    CreateMap<Personal, PersonalResponse>();
    CreateMap<CreatePersonalRequest, CreatePersonalCommand>();
    CreateMap<UpdatePersonalRequest, UpdatePersonalCommand>();
    CreateMap<DeletePersonalRequest, DeletePersonalCommand>();
  }

} 