using AutoMapper;
using Business.Requests.User;
using Business.Responses.User;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Mapping.AutoMapper
{
    public class UserMapperProfiles :Profile

    {
        public UserMapperProfiles()
        {
            CreateMap<LoginRequest, User>();
            CreateMap<User, LoginResponse>();
            CreateMap<RegisterRequest, User>();
            CreateMap<User, RegisterResponse>();
        }
        
    }
}
