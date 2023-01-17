namespace Sportics.Api.Repository.Interface;

public interface IUnitOfWork
{
    IPlayerRepository Player { get; }
    Task<bool> Save();
}