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
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public CitiesController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }

        // GET: Cities
        public ActionResult Index()
        {
            return View(_cityService.GetAll());
        }

        // GET: Cities/Details/5
        public IActionResult Details(int id)
        {
            string cityName = _cityService.FindById(id);
            return Json(cityName);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
           CreateCityViewModel model = new CreateCityViewModel();
            model.CountryList = _countryService.GetAll();
            return View(model);
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCityViewModel createCity)
        {
            if (ModelState.IsValid)
            {
               City cityView = _cityService.Create(createCity);
                if (cityView != null)
                {
                  return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("System", "Fail to Create City!!!");
            }
            createCity.CountryList = _countryService.GetAll();
            return View(createCity);
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int id)
        {
            string city = _cityService.FindById(id);

            if (city == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CreateCityViewModel editCity = new CreateCityViewModel()
            {
                CName = city
            };
            editCity.CountryList = _countryService.GetAll();

            ViewBag.id = id;

            return View(editCity);
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

            if (_cityService.FindById(id) != null)
            {
                City city = _cityService.GetCity(id);
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
