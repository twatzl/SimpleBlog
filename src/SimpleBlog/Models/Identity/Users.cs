using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SimpleBlog.Models.Identity
{
    public static class Users
    {
        private static readonly UserTemplate[] users =
        {
            new UserTemplate(){ UserName = "Admin", Password = "password", Email = "admin@admin.com", Roles = new []{"Admin"}}
        };

        public static UserTemplate Admin { get { return users[0]; } }

        public static IEnumerable<UserTemplate> All { get { return users; } }
    }
}
