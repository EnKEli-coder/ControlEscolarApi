using AutoMapper;
using ControlEscolarApi.Application.Common;
using ControlEscolarApi.Contracts.Common;

namespace ControlEscolarApi.Api.Common.Mappings;

public class CommonMappingConfig : Profile {

  public CommonMappingConfig() {
    CreateMap(typeof(PaginatedList<>), typeof(PaginatedListResponse<>))
        .ForMember("Items", opt => opt.MapFrom("Items"))
        .ForMember("Page", opt => opt.MapFrom("Page"))
        .ForMember("PageSize", opt => opt.MapFrom("PageSize"))
        .ForMember("TotalCount", opt => opt.MapFrom("TotalCount"))
        .ForMember("HasNextPage", opt => opt.MapFrom("HasNextPage"))
        .ForMember("HasPreviousPage", opt => opt.MapFrom("HasPreviousPage"));
  }

} 