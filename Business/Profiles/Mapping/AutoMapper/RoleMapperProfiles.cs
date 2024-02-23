
using Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Requests.Role;
using Business.Responses.Role;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class RoleMapperProfiles : Profile
    {
        public RoleMapperProfiles() 
        {
            CreateMap<AddRoleRequest, Role>();
            CreateMap<Role, AddRoleResponse>();
        }
    }
}
