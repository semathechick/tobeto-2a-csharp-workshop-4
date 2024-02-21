using Business.Requests.Customer;
using Business.Requests.Model;
using Business.Responses.Customer;
using Business.Responses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        

        public GetCustomerByIdResponse GetById(GetCustomerByIdRequest request);

        public AddCustomerResponse Add(AddCustomerRequest request);

    }
}

