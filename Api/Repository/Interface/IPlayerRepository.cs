using Sportics.Api.Entities;

namespace Sportics.Api.Repository.Interface;

public interface IPlayerRepository : IRepository<Player>
{
    void Update(Player player);
}