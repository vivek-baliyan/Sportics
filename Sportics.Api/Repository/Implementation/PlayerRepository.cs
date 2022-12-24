using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sportics.Api.Data;
using Sportics.Api.Entities;
using Sportics.Api.Repository.Interface;

namespace Sportics.Api.Repository.Implementation;

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