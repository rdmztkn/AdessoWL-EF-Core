using AdessoWL.Application.Features.Queries.GetGroups;
using AdessoWL.Domain.Entities;
using AutoMapper;

namespace AdessoWL.Application.MappingConfiguration;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        CreateMap<TeamEntity, TeamViewModel>()
            .ReverseMap();
    }
}
