using AutoMapper;
using Api.Dtos;
using Api.Entities;
using Api.Dtos.Match;
using Api.Entities.Match;
using Api.Entities.Tournament;
using Api.Dtos.Tournament;

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
            CreateMap<Match, MatchDto>()
            .ForMember(dto => dto.Team1Name, opts =>
            {
                opts.MapFrom(src => src == null || src.Team1 == null || string.IsNullOrEmpty(src.Team1.TeamName) ? string.Empty : src.Team1.TeamName);
            })
            .ForMember(dto => dto.Team2Name, opts =>
            {
                opts.MapFrom(src => src == null || src.Team2 == null || string.IsNullOrEmpty(src.Team2.TeamName) ? string.Empty : src.Team2.TeamName);
            });
            CreateMap<Tournament, TournamentDto>();
            CreateMap<Inning, InningDto>();

            CreateMap<TeamDto, Team>();
            CreateMap<PlayerDto, Player>();
            CreateMap<MatchDto, Match>();
            CreateMap<InningDto, Inning>();
        }
    }
}