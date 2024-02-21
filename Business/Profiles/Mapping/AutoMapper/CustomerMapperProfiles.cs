using AutoMapper;
using Business.Requests.Customer;
using Business.Responses.Customer;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class CustomerMapperProfiles: Profile
    {
        public CustomerMapperProfiles() 
        {
            CreateMap<AddCustomerRequest, Customer>();
            CreateMap<Customer, AddCustomerResponse>();

            CreateMap<GetCustomerByIdRequest, Customer>();
            CreateMap<Customer, GetCustomerByIdResponse>();
        }

        
        
    }
}
