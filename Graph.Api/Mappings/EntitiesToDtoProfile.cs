using AutoMapper;
using Graph.Api.Dto;
using Graph.Core.Entities;
using Graph.Core.ValueObjects;

namespace Graph.Api.Mappings;

public class EntitiesToDtoProfile : Profile
{
    public EntitiesToDtoProfile()
    {
        CreateMap<ElementType, TypeDto>();
        CreateMap<Element, ElementDto>();
        CreateMap<ElementsLink, LinkDto>()
            .ForMember(d => d.Source, o => o.MapFrom(s => s.Source.Id))
            .ForMember(d => d.Destination, o => o.MapFrom(s => s.Destination.Id));
        CreateMap<TypesLink, LinkDto>()
            .ForMember(d => d.Source, o => o.MapFrom(s => s.Source.Id))
            .ForMember(d => d.Destination, o => o.MapFrom(s => s.Destination.Id));
        CreateMap<ElementGraph, GraphDto>();
        CreateMap<ElementGraph, GraphInfoDto>();
    }
}