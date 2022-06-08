using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Identity;

namespace WebAssignmentMVC.Models.Person.Data
{
    internal class DbInitializer
    {
        internal static async Task InitializeAsync(
        PersonDBContext context,
        RoleManager<IdentityRole> roleManager,
        UserManager<AppUser> userManager
        )

        {
            //context.Database.EnsureCreated();//If not using EF migrations
            context.Database.Migrate();

            if (context.Roles.Any())
            {
                //i´ll assume database is seeded becouse i found roles
                IdentityRole role = new IdentityRole("SuperAdmin");
                IdentityResult result = await roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    throw new Exception("Faild to create Role: " + result);
                }
                //seed in the following into the Db SuperAdmin
                AppUser appUser = new AppUser
                {
                    FirstName = "Super",
                    LastName = "SuperAdmin",
                    DateOfBirth = DateTime.Now,
                    UserName = "SuperAdmin",
                    Email = "superadmin@admin.se"
                };
                IdentityResult userResult = await userManager.CreateAsync(appUser, "Asdf!234");
                if (!userResult.Succeeded)
                {
                    throw new Exception("Faild to create Role: " + userResult); 
                }
                userManager.AddToRoleAsync(appUser, role.Name).Wait();
            }
            else
            //------ Seed into database -----------------------------------------------------------
            {
                IdentityRole roleA = new IdentityRole("Admin");
                IdentityResult resultA = await roleManager.CreateAsync(roleA);

                if (!resultA.Succeeded)
                {
                    throw new Exception("Faild to create Role: " + resultA);
                }

                string AdminId = Guid.NewGuid().ToString();
                AppUser admin = new AppUser()
                {
                    Id = AdminId,
                    UserName = "admin",
                    Email = "admin@contoso.com",
                    NormalizedUserName = "ADMIN",
                    NormalizedEmail = "ADMIN@CONTOSO.COM",
                    FirstName = "Louis",
                    LastName = "Lim",
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "P@ssW0rd"),
                    DateOfBirth = DateTime.Now,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                IdentityResult resultUser = userManager.CreateAsync(admin, "Password!123").Result;

                if (!resultUser.Succeeded)
                {
                    throw new Exception("Faild to create Admin Acc: AdminPower");
                }

                IdentityResult resultAssign = userManager.AddToRoleAsync(admin, roleA.Name).Result;

                if (!resultAssign.Succeeded)
                {
                    throw new Exception($"Faild to grant {roleA.Name} role to Admin");
                }

                IdentityRole roleU = new IdentityRole("User");
                IdentityResult resultU = await roleManager.CreateAsync(roleU);

                if (!resultA.Succeeded)
                {
                    throw new Exception("Faild to create Role: " + resultU);
                }
                string userId = Guid.NewGuid().ToString();
                AppUser user = new AppUser()
                {
                    Id = userId,
                    UserName = "User1",
                    Email = "user1@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "NeWY@8rs"),
                    FirstName = "Vicient",
                    LastName = "Kent",
                    DateOfBirth = DateTime.Now,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                if (!resultUser.Succeeded)
                {
                    throw new Exception("Faild to create Admin Acc: AdminPower");
                }

                IdentityResult resultUassign = userManager.AddToRoleAsync(user, roleU.Name).Result;

                if (!resultUassign.Succeeded)
                {
                    throw new Exception($"Faild to grant {roleU.Name} role to Admin");
                }
                context.SaveChanges();
            } // End looing for Roles
        }
    }
}
