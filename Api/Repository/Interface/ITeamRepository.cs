using Api.Entities;

namespace Api.Repository.Interface;

public interface ITeamRepository : IRepository<Team>
{
    void Update(Team team);
}