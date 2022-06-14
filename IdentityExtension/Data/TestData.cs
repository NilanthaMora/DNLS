using IdentityExtension.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityExtension.Data
{
    public class TestData
    {
        public static async Task InitializeDB(ApplicationDbContext context, 
                                              UserManager<ApplicationUser> userManager,
                                              RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

   
            string adminRole           = "Admin";
            string adminDescription    = "Administrator Role";

            string memberRole          = "Member";
            string memberDescription   = "Member Description";

            string password             = "P@ssw0rd";

            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(adminRole, adminDescription, DateTime.Now));
            }

            if (await roleManager.FindByNameAsync(memberRole) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(memberRole, memberDescription, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("john@user.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "john@user.com",
                    Email = "john@user.com",
                    Name = "John",
                    UserRole = "Smith",
                    MobileContact = "+12 5555-5555"
                };

                var result = await userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, adminRole);
                };
            }
            

        }
    }
}
