using AutoMapper;
using Business.Requests.User;
using Business.Requests.UserRole;
using Business.Responses.User;
using Business.Responses.UserRole;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class UserRoleMapperProfiles : Profile
    {
        public UserRoleMapperProfiles() 
        {
            CreateMap<AddUserRoleRequest, UserRole>();
            CreateMap<UserRole, AddUserRoleResponse>();
        }
    }
}
