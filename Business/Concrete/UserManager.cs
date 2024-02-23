using Azure.Core;
using Business.Abstract;
using Business.Requests.User;
using Business.Requests.UserRole;
using Business.Responses.UserRole;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserRoleService _userRoleService;
        private readonly IUserRoleDal _userRoleDal;
        public UserManager(IUserDal userDal, ITokenHelper tokenHelper, IUserRoleService userRoleService, IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
            _userDal = userDal;
            _tokenHelper = tokenHelper;
            _userRoleService = userRoleService;
            
        }
        
        
        
         public Core.Utilities.Security.JWT.AccessToken Login(LoginRequest request)
            
        {

            User? user = _userDal.Get(i => i.Email == request.Email );
            UserRole? userRole = _userRoleDal.Get(u => u.Id == request.RoleId);
            
            bool isPasswordCorrect = HashingHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);

            if (!isPasswordCorrect)
                throw new Exception("Şifre yanlış.");
            else if (userRole == null)
                throw new Exception("Wrong role");

            AddUserRoleRequest userRoleRequest = new AddUserRoleRequest
            {
                UserId = user.Id,
                RoleId = userRole.Id
            };
            _userRoleService.Add(userRoleRequest);
            return _tokenHelper.CreateToken(user,userRole);

        }
        public void Register(RegisterRequest request)
        {
            
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            //TODO:Auto-Mapping
            User user = new User();
            user.Email = request.Email;
            user.Approved = false;
            user.PasswordSalt = passwordSalt;
            user.PasswordHash= passwordHash;
            
            _userDal.Add(user);

        }
    }
}
