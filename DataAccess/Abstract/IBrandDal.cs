using Core.DataAccess;
using DataAccess.Abstract.BaseDal;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Abstract;

public interface IBrandDal : IEntityDalBase<Brand, int>
{
    // CRUD - Create, Read, Update, Delete

    // IEntityRepository<Brand, int> kalıtımının örnek canlandırması:
    //public void Add(Brand entity);
    //public void Delete(Brand entity);
    //public Brand? GetById(int id);
    //public IList<Brand> GetList();
    //public void Update(Brand entity);
    //

    //public IList<Brand> GetBrandsByNameSearch(string nameSearch);
}
