

using Core.DataAccess;
using Core.Entities;
using DataAccess.Abstract.BaseDal;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityDalBase<User, int>
    {
    }
}
