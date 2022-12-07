//System
using System.Linq.Expressions;

namespace MyIoT.Core.DataAccess.EntityFramework;

public interface IEntityRepository<T> where T:class,IEntity,new()
{
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    T Get(Expression<Func<T, bool>> filter);
    List<T> GetList(Expression<Func<T, bool>> filter = null);

    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetAsync(Expression<Func<T, bool>> filter);
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
}
