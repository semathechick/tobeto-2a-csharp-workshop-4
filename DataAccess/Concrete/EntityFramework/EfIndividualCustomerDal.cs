using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfIndividualCustomerDal : EfEntityRepositoryBase<IndividualCustomer, int, RentACarContext>, IIndividualCustomerDal
    {
        public EfIndividualCustomerDal(RentACarContext context) : base(context)
        {
        }
    }
}
