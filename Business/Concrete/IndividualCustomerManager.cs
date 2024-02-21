

using AutoMapper;
using Business.Abstract;
using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class IndividualCustomerManager : IIndividualCustomerService
    {
        private readonly IIndividualCustomerDal _individualCustomerDal;
        private readonly IMapper _mapper;

        public IndividualCustomerManager(IIndividualCustomerDal individualCustomerDal, IMapper mapper)
        {

            _individualCustomerDal = individualCustomerDal;
            _mapper = mapper;
        }


        public AddIndividualCustomerResponse Add(AddIndividualCustomerRequest request)
        {
            IndividualCustomer individualCustomerToAdd = _mapper.Map<IndividualCustomer>(request);
            _individualCustomerDal.Add(individualCustomerToAdd);
            AddIndividualCustomerResponse addIndividualCustomerResponse = _mapper.Map<AddIndividualCustomerResponse>(individualCustomerToAdd);
            return addIndividualCustomerResponse;
        }

        public GetIndividualCustomerByIdResponse GetById(GetIndividualCustomerByIdRequest request)
        {
            IndividualCustomer? individualCustomer = _individualCustomerDal.Get(predicate: indCustomer => indCustomer.Id == request.Id);
            var response = _mapper.Map<GetIndividualCustomerByIdResponse>(individualCustomer);
            return response;
        }
    }
}
