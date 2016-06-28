using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SimpleBlog.Models.ManageUsersViewModels
{
    public class EditRolesViewModel
    {

        public EditRolesViewModel(ApplicationUser user, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            User = user;
            AssignedRoles = userManager.GetRolesAsync(user).Result;
            AvailableRoles = roleManager.Roles.Select(role => role.Name);
        }

        public ApplicationUser User { get; }

        [Display(Name = "Assigned Roles")]
        public IEnumerable<string> AssignedRoles { get; private set; }

        [Display(Name = "Available Roles")]
        public IEnumerable<string> AvailableRoles { get; private set; }
    }
}
