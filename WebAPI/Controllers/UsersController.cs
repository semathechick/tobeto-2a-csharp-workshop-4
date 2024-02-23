using Business.Abstract;
using Business.Requests.Role;
using Business.Requests.User;
using Business.Requests.UserRole;
using Business.Responses.Role;
using Business.Responses.UserRole;
using Core.Entities;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IRoleService _roleService;
        private readonly IUserService _userService; 

        public UsersController(IUserRoleService userRoleService, IUserService userService)
        {
            _userService = userService;
            _userRoleService = userRoleService;
        }
        [HttpPost("Roles")]
        public ActionResult<AddRoleResponse> UserRole([FromBody]AddRoleRequest request)
        {
            AddRoleResponse response = _roleService.Add(request);
            return response;
        }
        [HttpGet("UserRoles")]
        public ActionResult<AddUserRoleResponse> UserRole([FromQuery] AddUserRoleRequest request)
        {
            AddUserRoleResponse response = _userRoleService.Add(request);
            return response;
        }

        [HttpPost("Register")]
        public void Register([FromBody] RegisterRequest request)
        {
            _userService.Register(request);
        }
        [HttpPost("Login")]
        public AccessToken Login([FromBody] LoginRequest request)
        {
            return _userService.Login(request);
        }
    }
}
