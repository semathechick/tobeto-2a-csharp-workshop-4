using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, int, RentACarContext>, ICustomerDal
    {
        public EfCustomerDal(RentACarContext context) : base(context)
        {
        }
    }
}
