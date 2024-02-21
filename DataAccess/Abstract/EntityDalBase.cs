using Core.DataAccess;
using Core.Entities;
using DataAccess.Abstract.BaseDal;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Abstract
{
    public class  EntityDalBase<TEntity,TEntityId, TContext> :IEntityDalBase<TEntity,TEntityId>
        where TContext : DbContext
        where TEntity: Entity<TEntityId>
    {
        private readonly TContext Context;

        public EntityDalBase(TContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            Context.Add(entity);
            entity.CreatedAt = DateTime.UtcNow;
            Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity, bool isSoftDelete = true)
        {
            entity.DeletedAt = DateTime.UtcNow;
            if (!isSoftDelete)
            {
                Context.Remove(entity);
            }
            Context.SaveChanges();
            return entity;
        }

        public TEntity? Get(Func<TEntity, bool> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IList<TEntity> GetList(Func<TEntity, bool>? predicate = null)
        {
            IQueryable<TEntity> entities = Context.Set<TEntity>();
            if (predicate is not null)
                entities = entities.Where(predicate).AsQueryable();

            return entities.ToList();
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdateAt = DateTime.UtcNow;
            Context.Update(entity);
            Context.SaveChanges();
            return entity;
        }
    }
}
