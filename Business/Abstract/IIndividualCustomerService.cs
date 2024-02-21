


using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;

namespace Business.Abstract
{
    public interface IIndividualCustomerService
    {
        public GetIndividualCustomerByIdResponse GetById(GetIndividualCustomerByIdRequest request);

        public AddIndividualCustomerResponse Add(AddIndividualCustomerRequest request);
    }
}
