using Sportics.Api.Data;
using Sportics.Api.Repository.Interface;

namespace Sportics.Api.Repository.Implementation;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    public IPlayerRepository Player { get; private set; }

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Player = new PlayerRepository(_db);
    }

    public async Task<bool> Save()
    {
        return await _db.SaveChangesAsync() > 0;
    }
}