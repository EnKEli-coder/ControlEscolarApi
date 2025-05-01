using AutoMapper;
using ControlEscolarApi.Application.Alumnos.Commands.CreateAlumno;
using ControlEscolarApi.Application.Alumnos.Commands.DeleteAlumno;
using ControlEscolarApi.Application.Alumnos.Commands.UpdateAlumno;
using ControlEscolarApi.Contracts.Alumnos;
using ControlEscolarApi.Domain.Entities;

namespace ControlEscolarApi.Api.Common.Mappings;

public class AlumnosMappingConfig : Profile {

  public AlumnosMappingConfig() {
    CreateMap<Alumno, AlumnoResponse>();
    CreateMap<CreateAlumnoRequest, CreateAlumnoCommand>();
    CreateMap<UpdateAlumnoRequest, UpdateAlumnoCommand>();
    CreateMap<DeleteAlumnoRequest, DeleteAlumnoCommand>();
  }

} 