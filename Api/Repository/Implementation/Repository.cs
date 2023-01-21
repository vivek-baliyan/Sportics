using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Repository.Interface;

namespace Api.Repository.Implementation;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _db;
    internal DbSet<T> _dbSet;

    public Repository(ApplicationDbContext db)
    {
        _db = db;
        _dbSet = _db.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public async Task<IEnumerable<T>> GetAll(string? includeroperties = null)
    {
        IQueryable<T> query = _dbSet;
        if (includeroperties != null)
        {
            foreach (var includeProp in includeroperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        return await query.ToListAsync();
    }

    public async Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeroperties = null)
    {
        IQueryable<T> query = _dbSet;
        query = query.Where(filter);
        if (includeroperties != null)
        {
            foreach (var includeProp in includeroperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        return await query.FirstOrDefaultAsync();
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
        _dbSet.RemoveRange(entity);
    }
}
