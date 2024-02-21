using Core.DataAccess;
using DataAccess.Abstract.BaseDal;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IModelDal : IEntityDalBase<Model, int>
{
    // IEntityRepository<Model, int> kalıtımının örnek canlandırması:
    //public IList<Model> GetList();
    //public Model? GetById(int id);
    //public void Add(Model entity);
    //public void Update(Model entity);
    //public void Delete(Model entity);
}
