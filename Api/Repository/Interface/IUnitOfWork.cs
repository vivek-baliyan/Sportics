namespace Api.Repository.Interface;

public interface IUnitOfWork
{
    IPlayerRepository Player { get; }
    ITeamRepository Team { get; }
    IMatchRepository Match { get; }
    IMatchTeamRepository MatchTeam { get; }
    Task<bool> Complete();
}