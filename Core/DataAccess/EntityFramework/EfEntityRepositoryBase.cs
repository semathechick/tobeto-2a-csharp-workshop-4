using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Core.DataAccess.EntityFramework
{
    // T => Type
    public class EfEntityRepositoryBase<TEntity, TEntityId, TContext> : IEntityRepository<TEntity, TEntityId> //generic context'le istedigi contexe gecebilcek.
        where TEntity : Entity<TEntityId> //veri tablosu olan bir clası alması için 
        where TContext : DbContext //zorunluluk where'de.
    {
        private readonly TContext Context;//RentACarContextten almadık cunku core katmanı baska bir katmanı bagımlılık almaz, ayrıca bagımlılık yaratır,generic yapıyı bozar

        public EfEntityRepositoryBase(TContext context)
        {
            this.Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity, bool isSoftDelete = true)
        {
            entity.DeletedAt = DateTime.UtcNow;
            // Context.Entry(entity).State = EntityState.Modified;

            if (!isSoftDelete)
                Context.Remove(entity);

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
                entities = entities.Where(predicate).AsQueryable();//where islemi IEnumerablea donusturdugu için tekrar casting yaptık.

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
