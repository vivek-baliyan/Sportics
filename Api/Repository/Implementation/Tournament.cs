using Api.Data;
using Api.Entities.Tournament;
using Api.Repository.Interface;

namespace Api.Repository.Implementation;

public class TournamentRepository : Repository<Tournament>, ITournamentRepository
{
    private readonly ApplicationDbContext _context;
    public TournamentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Tournament tournament)
    {
        if (_context != null && _context.Tournaments != null)
            _context.Tournaments.Update(tournament);
    }
}