using System.Linq.Expressions;

namespace Sportics.Api.Repository.Interface;

public interface IRepository<T> where T : class
{
    T? GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeroperties = null);
    IEnumerable<T> GetAll(string? includeroperties = null);
    void Add(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entity);
}