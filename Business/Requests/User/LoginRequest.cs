﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.User
{
    public class LoginRequest
    {
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
