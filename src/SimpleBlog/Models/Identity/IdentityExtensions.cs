using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SimpleBlog.Data;

namespace SimpleBlog.Models.Identity
{
    public static class IdentityExtensions
    {
        public static void EnsureRolesCreated(this IApplicationBuilder app)
        {
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetService(typeof(RoleManager<IdentityRole>)) as RoleManager<IdentityRole>;

            if (roleManager == null)
            {
                throw new NullReferenceException("RoleManager could not be loaded!");
            }

            foreach (var role in Roles.All)
            {
                if (!roleManager.RoleExistsAsync(role.ToUpper()).Result)
                {
                    roleManager.CreateAsync(new IdentityRole { Name = role });
                }
            }
        }

        public static void EnsureUsersCreated(this IApplicationBuilder app)
        {
            UserManager<ApplicationUser> userManager =
                app.ApplicationServices.GetService(typeof(UserManager<ApplicationUser>)) as UserManager<ApplicationUser>;

            if (userManager == null)
            {
                throw new NullReferenceException("UserManager could not be loaded!");
            }

            foreach (var userTemplate in Users.All)
            {
                CreateUserFromTemplate(userManager, userTemplate);
            }
        }

        private static void CreateUserFromTemplate(UserManager<ApplicationUser> userManager, UserTemplate userTemplate)
        {
            if (!userManager.Users.Any(user => user.UserName == userTemplate.UserName))
            {
                var user = new ApplicationUser() {UserName = userTemplate.UserName, Email = userTemplate.Email};
                CreateUserSync(userManager, userTemplate, user);
            }
        }

        private static async Task CreateUserSync(UserManager<ApplicationUser> userManager, UserTemplate userTemplate, ApplicationUser user)
        {
            await userManager.CreateAsync(user, userTemplate.Password);
            await userManager.AddToRolesAsync(user, userTemplate.Roles);
        }
    }
}
