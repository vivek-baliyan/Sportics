using Api.Entities;

namespace Api.Repository.Interface;

public interface IPlayerRepository : IRepository<Player>
{
    void Update(Player player);
}