using Api.Entities;
using Api.Entities.Match;

namespace Api.Repository.Interface;

public interface IMatchRepository : IRepository<Match>
{
    void Update(Match match);
}