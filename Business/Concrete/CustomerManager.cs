using AutoMapper;
using Business.Abstract;
using Business.Requests.Customer;
using Business.Responses.Customer;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        
        private readonly ICustomerDal _customerDal;
        private readonly IMapper _mapper;

        public CustomerManager( ICustomerDal customerDal, IMapper mapper)
        {
            
            _customerDal = customerDal;
            _mapper = mapper;
        }

        
        public AddCustomerResponse Add(AddCustomerRequest request)
        {
            Customer customerToAdd = _mapper.Map<Customer>(request);
            _customerDal.Add(customerToAdd);
            AddCustomerResponse addCustomerResponse = _mapper.Map<AddCustomerResponse>(customerToAdd);
            return addCustomerResponse;
        }

        public GetCustomerByIdResponse GetById(GetCustomerByIdRequest request)
        {
            Customer? customer = _customerDal.Get(predicate: customer =>  customer.Id == request.Id);  
            var response = _mapper.Map<GetCustomerByIdResponse>(customer);
            return response;
        }
    }
}
