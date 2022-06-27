using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Identity;
using WebAssignmentMVC.Models.Identity.Services;
using WebAssignmentMVC.Models.Identity.ViewModels;

namespace WebAssignmentMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRoleService _roleService;

        public AdminController(UserManager<AppUser> userManager,  RoleManager<IdentityRole> roleManager, IRoleService roleService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleService = roleService;
        }
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRolesViewModel createRoleModel)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(createRoleModel.Name));
                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("System", "Fail to create role!!!");
            }
            return View(createRoleModel);
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
