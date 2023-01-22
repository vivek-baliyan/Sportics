using AutoMapper;
using Api.Dtos;
using Api.Entities;

namespace Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TeamDto, Team>();
            CreateMap<Team, TeamDto>();
            CreateMap<PlayerDto, Player>();
            CreateMap<Player, PlayerDto>()
            .ForMember(dest => dest.TeamName, opts =>
            {
                opts.MapFrom(src => src == null || src.Team == null || string.IsNullOrEmpty(src.Team.TeamName) ? string.Empty : src.Team.TeamName);
            });
        }
    }
}