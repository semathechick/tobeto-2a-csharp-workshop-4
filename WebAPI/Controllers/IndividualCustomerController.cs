using Business.Abstract;
using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class IndividualCustomerController : Controller
    {
        private readonly IIndividualCustomerService _individualCustomerService;

        public IndividualCustomerController(IIndividualCustomerService individualCustomerService)
        {
            _individualCustomerService = individualCustomerService;
        }
        [HttpGet("{GetById}")]
        public GetIndividualCustomerByIdResponse GetById([FromRoute] GetIndividualCustomerByIdRequest request)
        {
            GetIndividualCustomerByIdResponse response = _individualCustomerService.GetById(request);
            return response;
        }

        [HttpPost]
        public ActionResult<AddIndividualCustomerResponse> Add(AddIndividualCustomerRequest request)
        {
            AddIndividualCustomerResponse response = _individualCustomerService.Add(request);
            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new { Id = response.Id },

                value: response
            );
        }
    }
}
