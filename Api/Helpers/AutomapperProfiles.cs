using AutoMapper;
using Api.Dtos;
using Api.Entities;
using Api.Dtos.Match;
using Api.Entities.Match;

namespace Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Team, TeamDto>();
            CreateMap<Player, PlayerDto>()
            .ForMember(dest => dest.TeamName, opts =>
            {
                opts.MapFrom(src => src == null || src.Team == null || string.IsNullOrEmpty(src.Team.Name) ? string.Empty : src.Team.Name);
            });
            CreateMap<Match, MatchDto>();
            CreateMap<Inning, InningDto>();

            CreateMap<TeamDto, Team>();
            CreateMap<PlayerDto, Player>();
            CreateMap<MatchDto, Match>();
            CreateMap<InningDto, Inning>();
        }
    }
}