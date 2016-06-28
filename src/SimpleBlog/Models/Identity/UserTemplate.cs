using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog.Models.Identity
{
    public class UserTemplate
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string[] Roles { get; set; }
    }
}
