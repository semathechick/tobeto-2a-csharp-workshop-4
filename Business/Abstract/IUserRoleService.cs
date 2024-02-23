using Business.Requests.Model;
using Business.Requests.UserRole;
using Business.Responses.Model;
using Business.Responses.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserRoleService
    {
        public AddUserRoleResponse Add(AddUserRoleRequest request);
    }
}
