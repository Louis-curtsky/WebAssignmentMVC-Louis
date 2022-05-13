using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAssignmentMVC.Models.Person;
using WebAssignmentMVC.Models.Person.Data;
using WebAssignmentMVC.Models.Person.Services;

namespace WebAssignmentMVC.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: Cities
        public ActionResult Index()
        {
            return View(_cityService.GetAll());
        }

        // GET: Cities/Details/5
        public IActionResult Details(int? id)
        {
            return View();
        }

        // GET: Cities/Create
        public IActionResult Create()
        {

            //Pending
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
               City cityView = _cityService.Create(city);
                if (cityView != null)
                {
                  return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Fail to Create City!!!");
            }
            return View(city);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int id)
        {
            City city = _cityService.FindById(id);

            if (city == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.id = id;
            return View(new CreateCityViewModel(city));
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, City city)
        {
            if (ModelState.IsValid)
            {
                if (_cityService.Edit(city) == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Fail to edit City!!!");
            }
            ViewBag.id = id;
            return View(city);
        }

        // GET: Cities/Delete/5
        public IActionResult Delete(int id)
        {
            City city = _cityService.FindById(id);

            if (city != null)
            {
                if (_cityService.Remove(city))
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("System", "Fail to create country!!!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetCities()
        {
            return Json(_cityService.GetAll());
        }

    }
}
