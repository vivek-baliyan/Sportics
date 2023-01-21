using Api.Data;
using Api.Entities;
using Api.Repository.Interface;

namespace Api.Repository.Implementation;

public class TeamRepository : Repository<Team>, ITeamRepository
{
    private readonly ApplicationDbContext _context;
    public TeamRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(Team team)
    {
        if (_context != null && _context.Teams != null)
            _context.Teams.Update(team);
    }
}