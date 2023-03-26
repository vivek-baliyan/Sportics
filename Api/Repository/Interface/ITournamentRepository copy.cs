using Api.Entities.Tournament;

namespace Api.Repository.Interface;

public interface ITournamentRepository : IRepository<Tournament>
{
    void Update(Tournament tournament);
}