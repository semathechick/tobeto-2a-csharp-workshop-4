using Business.Requests.Role;
using Business.Requests.UserRole;
using Business.Responses.Role;
using Business.Responses.UserRole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleService
    {
        public AddRoleResponse Add(AddRoleRequest request);
    }
}
