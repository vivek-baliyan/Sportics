using Api.Data;
using Api.Entities;
using Api.Repository.Interface;

namespace Api.Repository.Implementation;

public class PlayerRepository : Repository<Player>, IPlayerRepository
{
    private readonly ApplicationDbContext _context;
    public PlayerRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Player player)
    {
        if (_context != null && _context.Players != null)
            _context.Players.Update(player);
    }
}