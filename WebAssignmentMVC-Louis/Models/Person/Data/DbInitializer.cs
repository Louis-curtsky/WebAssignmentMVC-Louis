using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Identity;

namespace WebAssignmentMVC.Models.Person.Data
{
    public class DbInitializer
    {
        public static void Initialize(
        PersonDBContext context,
        RoleManager<IdentityRole> roleManager,
        UserManager<PersonUser> userManager
        )
        {
            //context.Database.EnsureCreated();//If not using EF migrations
            context.Database.Migrate();

            if (context.Roles.Any())
            {
                return; //i´ll assume database is seeded becouse i found roles
            }

            //------ Seed into database -----------------------------------------------------------

            string[] rolesToSeed = new string[] { "Admin", "User", "Supervisor" };

            foreach (var roleName in rolesToSeed)
            {
                IdentityRole role = new IdentityRole(roleName);

                var result = roleManager.CreateAsync(role).Result;

                if (!result.Succeeded)
                {
                    throw new Exception("Faild to create Role: " + roleName);
                }
            }

            string AdminId = Guid.NewGuid().ToString();
            PersonUser user = new PersonUser()
            {
              //  Id = AdminId,
                UserName = "PowerUser",
                Email = "admin@gmail.com",
                PasswordHash = new PasswordHasher<PersonUser>().HashPassword(null, "P@ssW0rd"),
                FirstName = "Louis",
                LastName = "Lim",
                EmailConfirmed = true,
                DateOfBirth = DateTime.Now
            };
            IdentityResult resultUser = userManager.CreateAsync(user, "Qwerty!23456").Result;

            if (!resultUser.Succeeded)
            {
                throw new Exception("Faild to create Admin Acc: AdminPower");
            }

            IdentityResult resultAssign = userManager.AddToRoleAsync(user, rolesToSeed[0]).Result;

            if (!resultAssign.Succeeded)
            {
                throw new Exception($"Faild to grant {rolesToSeed[0]} role to AdminPower");
            }
        }
    }
}
