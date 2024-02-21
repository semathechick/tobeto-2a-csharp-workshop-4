using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Customer : Entity<int>
    {
        public Customer(int ındividualCustomerId, int userId)
        {
            IndividualCustomerId = ındividualCustomerId;
            UserId = userId;
        }

        public int IndividualCustomerId { get; set; }
        public int UserId { get; set; }


        public User? User { get; set; } = null;
        public IndividualCustomer? IndividualCustomer { get; set; } = null;
        


        

    }
}
