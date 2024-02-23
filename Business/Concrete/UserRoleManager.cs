using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Model;
using Business.Requests.User;
using Business.Requests.UserRole;
using Business.Responses.Model;
using Business.Responses.UserRole;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserRoleManager:IUserRoleService
    {
        private readonly IUserRoleDal _userRoleDal;
        private readonly IMapper _mapper;
        
        public UserRoleManager(IUserRoleDal userRoleDal, IMapper mapper)
        {
            _userRoleDal = userRoleDal;
            _mapper = mapper;
        }
        public AddUserRoleResponse Add(AddUserRoleRequest request)
        {
            UserRole? userRole = _userRoleDal.Get(u => u.Id == request.UserId);

            var roleToAdd = _mapper.Map<UserRole>(request);

            UserRole addedRole = _userRoleDal.Add(roleToAdd);

            
            var response = _mapper.Map<AddUserRoleResponse>(addedRole);
            return response;
        }
    }
}
