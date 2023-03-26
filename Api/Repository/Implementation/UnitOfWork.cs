using Api.Data;
using Api.Repository.Interface;

namespace Api.Repository.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    public IPlayerRepository Player { get; private set; }
    public ITeamRepository Team { get; private set; }
    public ITournamentRepository Tournament { get; private set; }
    public IMatchRepository Match { get; private set; }

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Player = new PlayerRepository(_db);
        Team = new TeamRepository(_db);
        Tournament = new TournamentRepository(_db);
        Match = new MatchRepository(_db);
    }

    public async Task<bool> Complete()
    {
        return await _db.SaveChangesAsync() > 0;
    }
}