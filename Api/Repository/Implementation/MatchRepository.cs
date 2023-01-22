using Api.Data;
using Api.Entities;
using Api.Entities.Match;
using Api.Repository.Interface;

namespace Api.Repository.Implementation;

public class MatchRepository : Repository<Match>, IMatchRepository
{
    private readonly ApplicationDbContext _context;
    public MatchRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Match match)
    {
        if (_context != null && _context.Matches != null)
            _context.Matches.Update(match);
    }
}