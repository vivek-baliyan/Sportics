using Api.Data;
using Api.Entities;
using Api.Entities.Match;
using Api.Repository.Interface;

namespace Api.Repository.Implementation;

public class MatchTeamRepository : Repository<MatchTeam>, IMatchTeamRepository
{
    private readonly ApplicationDbContext _context;
    public MatchTeamRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(MatchTeam matchTeam)
    {
        if (_context != null && _context.MatchTeams != null)
            _context.MatchTeams.Update(matchTeam);
    }
}