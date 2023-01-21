namespace Api.Repository.Interface;

public interface IUnitOfWork
{
    IPlayerRepository Player { get; }
    ITeamRepository Team { get; }
    Task<bool> Complete();
}