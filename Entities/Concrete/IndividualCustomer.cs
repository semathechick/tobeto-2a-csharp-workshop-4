using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class IndividualCustomer : Entity<int>
    {
        public IndividualCustomer(string firstName, string lastName, string nationalIdentity,int customerId, Customer customer)
        {

            FirstName = firstName;
            LastName = lastName;
            NationalIdentity = nationalIdentity;
            CustomerId = customerId; 
            Customer = customer;
        }
        IndividualCustomer() { }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }

    }
}
