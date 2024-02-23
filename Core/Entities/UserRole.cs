using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserRole : Entity<int>
    {
        public UserRole(int userId, User user, int roleId, Role role, ICollection<Role> roles)
        {
            UserId = userId;
            User = user;
            RoleId = roleId;
            Role = role;
            Roles = roles;
        }
        UserRole() { }

        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}

