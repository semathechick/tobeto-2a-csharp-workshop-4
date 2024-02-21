using Business.Abstract;
using Business.Requests.Customer;
using Business.Responses.Customer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("{GetById}")] 
        public GetCustomerByIdResponse GetById([FromRoute] GetCustomerByIdRequest request)
        {
            GetCustomerByIdResponse response = _customerService.GetById(request);
            return response;
        }

        [HttpPost] 
        public ActionResult<AddCustomerResponse> Add(AddCustomerRequest request)
        {
            AddCustomerResponse response = _customerService.Add(request);
            return CreatedAtAction( 
                actionName: nameof(GetById),
                routeValues: new { Id = response.Id },

                value: response 
            );
        }
    }
}
