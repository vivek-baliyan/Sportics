namespace Api.Repository.Interface;

public interface IUnitOfWork
{
    IPlayerRepository Player { get; }
    ITeamRepository Team { get; }
    ITournamentRepository Tournament { get; }
    IMatchRepository Match { get; }
    Task<bool> Complete();
}