using Core.Entities;


namespace DataAccess.Abstract.BaseDal
{
    public interface IEntityDalBase<TEntity, TEntityId> where TEntity : Entity<TEntityId>

    {
        public TEntity Add(TEntity entity);
        public TEntity Delete(TEntity entity, bool isSoftDelete = true);
        public TEntity? Get(Func<TEntity, bool> predicate);
        public IList<TEntity> GetList(Func<TEntity, bool>? predicate = null);
        public TEntity Update(TEntity entity);
    }
}
