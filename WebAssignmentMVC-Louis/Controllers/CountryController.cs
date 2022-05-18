using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person;
using WebAssignmentMVC.Models.Person.Services;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        // GET: CountryController
        public ActionResult Index()
        {        
            return View(_countryService.GetAll());
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            // More coding..pending
            return View();
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCountryViewModel createCountry)
        {
            if (ModelState.IsValid)
            {
                Country country = _countryService.Create(createCountry); 
                if (country != null)
                   return RedirectToAction(nameof(Index));
                ModelState.AddModelError("System", "Fail to create country!!!");
            }
                return View(createCountry);
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            string country = _countryService.FindById(id);

            if (country == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CreateCountryViewModel editCountry = new CreateCountryViewModel()
            {
                CountryName = country
            };

            ViewBag.id = id;

            return View(editCountry);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreateCountryViewModel country)
        {
            if (ModelState.IsValid)
            {
                if (_countryService.Edit(id, country) != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Fail to edit Country!!!");
            }
            ViewBag.id = id;
            return View(country);
        }

        // GET: CountryController/Delete/5
            public ActionResult Delete(int id)
        {
            string country = _countryService.FindById(id);

            if (country != null)
            {
                if (_countryService.Remove(id))
                return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("System", "Fail to delete country!!!");
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetCountries()
        {
            return Json(_countryService.GetAll());
        }
    }
}
