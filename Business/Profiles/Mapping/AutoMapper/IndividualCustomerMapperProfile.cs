using AutoMapper;
using Business.Requests.Customer;
using Business.Requests.IndividualCustomer;
using Business.Responses.Customer;
using Business.Responses.IndividualCustomer;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class IndividualCustomerMapperProfile: Profile
    {
        public IndividualCustomerMapperProfile() 
        {
            CreateMap<AddIndividualCustomerRequest, IndividualCustomer>();
            CreateMap<IndividualCustomer, AddIndividualCustomerResponse>();

            CreateMap<GetCustomerByIdRequest, IndividualCustomer>();
            CreateMap<IndividualCustomer, GetIndividualCustomerByIdResponse>();
        }
    }
}
