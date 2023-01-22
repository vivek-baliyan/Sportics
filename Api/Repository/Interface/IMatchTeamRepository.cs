using Api.Entities;
using Api.Entities.Match;

namespace Api.Repository.Interface;

public interface IMatchTeamRepository : IRepository<MatchTeam>
{
    void Update(MatchTeam matchTeam);
}