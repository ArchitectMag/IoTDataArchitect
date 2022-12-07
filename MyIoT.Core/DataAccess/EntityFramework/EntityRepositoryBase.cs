//System
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MyIoT.Core.DataAccess.EntityFramework;

public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity, new()
    where TContext : DbContext, new()

{
    public async Task AddAsync(TEntity entity)
    {
        using (var context = new TContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(TEntity entity)
    {
        using (var context = new TContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(TEntity entity)
    {
        using (var context = new TContext())
        {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        using (var context = new TContext())
        {
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        using (var context = new TContext())
        {
            return filter == null
                   ? await context.Set<TEntity>().ToListAsync()
                   : await context.Set<TEntity>().Where(filter).ToListAsync();
        }
    }

    public void Add(TEntity entity)
    {
        using (var context = new TContext())
        {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Update(TEntity entity)
    {
        using (var context = new TContext())
        {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }

    public void Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
    {
        throw new NotImplementedException();
    }
}