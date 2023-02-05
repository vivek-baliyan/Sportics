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
                opts.MapFrom(src => src == null || src.Team == null || string.IsNullOrEmpty(src.Team.TeamName) ? string.Empty : src.Team.TeamName);
            });
            CreateMap<Match, MatchDto>();
            CreateMap<MatchTeam, MatchTeamDto>()
            .ForMember(dest => dest.TeamName, opts =>
            {
                opts.MapFrom(src => src == null || src.Team == null || string.IsNullOrEmpty(src.Team.TeamName) ? string.Empty : src.Team.TeamName);
            }); ;
            CreateMap<MatchInning, MatchInningDto>();

            CreateMap<TeamDto, Team>();
            CreateMap<PlayerDto, Player>();
            CreateMap<MatchDto, Match>();
            CreateMap<MatchTeamDto, MatchTeam>();
            CreateMap<MatchInningDto, MatchInning>();
        }
    }
}