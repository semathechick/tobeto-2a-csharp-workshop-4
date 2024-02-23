using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Role : Entity<int>
    {
        public string RoleName { get; set; }
       
        public Role()
        { }

        public Role(string roleName, int? userRoleId)
        {
            RoleName = roleName;
        }
    }
}
