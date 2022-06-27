using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Identity;
using WebAssignmentMVC.Models.Identity.ViewModels;
using WebAssignmentMVC.Models.Person.Data;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Controllers
{
 //   [Authorize]
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)// Constructor Injection
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel userReg)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    UserName = userReg.UserName,
                    Email = userReg.Email,
                    FirstName = userReg.FirstName,
                    LastName = userReg.LastName,
                    DateOfBirth = userReg.DateOfBirth,
                    PhoneNumber = userReg.Phone,
                    // UserRoleID string is taken from NetUser after Seeding

                    // Admin = 
                    // UserRoleID = 
                };
                IdentityResult result = await _userManager.CreateAsync(user, userReg.Password);

                if (result.Succeeded)
                {
                    // Login with user role assigned...but if policy is only allow superAdmin to assign roles then remark this
                    // personally it is normal to have login creation with use role assign and limit user role accessibility.

 //                   await _roleManager.CreateAsync(new IdentityRole("User"));
                 
                    return RedirectToAction("Index", "Home");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
            }
            return View(userReg);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AppUser loginUser, string password)
        {

            if (ModelState.IsValid)
            {

                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginUser.UserName, password, false, false);

                if (result.Succeeded)
                {
                    AppUser identUser = new AppUser();
                    identUser.UserName = loginUser.UserName;
                  


                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Msg = "Login Successful!";
            }
            else
            {
                ViewBag.Msg = "Invalid State!!!";
                //Invalid Model state. Repeat Login
                throw new ArgumentException(
                    "Problem with Login occurred! Please try again!");

            }
            return View(loginUser);


        } // End Login Post

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

